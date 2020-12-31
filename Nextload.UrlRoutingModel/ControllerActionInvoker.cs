using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Nextload.UrlRoutingModel
{
    internal class ControllerActionInvoker : IActionInvoker
    {
        public IModelBinder ModelBinder { get; set; }

        public ControllerActionInvoker()
        {
            this.ModelBinder = new DefaultModelBinder();
        }

        public void InvokeAction(ControllerContext context, string actionName)
        {
            MethodInfo methodInfo = context.Controller.GetType().GetMethods().First(m => string.Compare(m.Name, actionName, true) == 0);

            List<object> parameters = new List<object>();

            foreach (var parameterInfo in methodInfo.GetParameters())
            {
                parameters.Add(this.ModelBinder.BindModel(context, parameterInfo.Name, parameterInfo.ParameterType));
            }

            ActionResult actionResult = methodInfo.Invoke(context.Controller, parameters.ToArray()) as ActionResult;

            actionResult.ExecuteResult(context);
        }
    }
}