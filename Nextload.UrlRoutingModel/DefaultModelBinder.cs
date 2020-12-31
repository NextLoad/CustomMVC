using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nextload.UrlRoutingModel
{
    public class DefaultModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext context, string parameterName, Type parameterType)
        {
            if (parameterType.IsValueType || typeof(string) == parameterType)
            {
                if (GetValueTypeInstance(context, parameterName, parameterType, out object instance))
                {
                    return instance;
                }

                return Activator.CreateInstance(parameterType);
            }

            object modelInstance = Activator.CreateInstance(parameterType);

            foreach (var propertyInfo in parameterType.GetProperties())
            {
                if (!propertyInfo.CanWrite || (!propertyInfo.PropertyType.IsValueType && typeof(string) != propertyInfo.PropertyType))
                {
                    continue;
                }

                if (GetValueTypeInstance(context, propertyInfo.Name, propertyInfo.PropertyType, out object propertyValue))
                {
                    propertyInfo.SetValue(modelInstance, propertyValue, null);
                }
            }

            return modelInstance;
        }

        private bool GetValueTypeInstance(ControllerContext context, string parameterName, Type parameterType, out object instance)
        {
            var form1 = HttpContext.Current.Request.Form;

            var form = context.RequestContext.HttpContext.Request.Form;

            string key = string.Empty;

            if (null != form)
            {
                key = form.AllKeys.FirstOrDefault(f => string.Compare(f, parameterName, true) == 0);

                if (!string.IsNullOrEmpty(key))
                {
                    instance = Convert.ChangeType(form[key], parameterType);

                    return true;
                }
            }

            key = context.RequestContext.RouteData.Values
                .Where(item => string.Compare(item.Key, parameterName, true) == 0)
                .Select(item => item.Key).FirstOrDefault();

            if (!string.IsNullOrEmpty(key))
            {
                instance = Convert.ChangeType(context.RequestContext.RouteData.Values[key], parameterType);

                return true;
            }

            key = context.RequestContext.RouteData.DataTokens
                .Where(item => string.Compare(item.Key, parameterName, true) == 0)
                .Select(item => item.Key).FirstOrDefault();

            if (!string.IsNullOrEmpty(key))
            {
                instance = Convert.ChangeType(context.RequestContext.RouteData.DataTokens[key], parameterType);

                return true;
            }

            instance = null;

            return false;
        }


    }
}
