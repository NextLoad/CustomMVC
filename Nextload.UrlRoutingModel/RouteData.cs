using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nextload.UrlRoutingModel
{
    public class RouteData
    {
        public IDictionary<string, object> Values { get; set; }

        public IDictionary<string, object> DataTokens { get; set; }

        public IRouteHandler RouteHandler { get; set; }

        public RouteBase RouteBase { get; set; }


        public RouteData()
        {
            Values = new Dictionary<string, object>();

            DataTokens = new Dictionary<string, object>();

            DataTokens.Add("namespaces", new List<string>());
        }

        public string ControllerName
        {
            get
            {
                this.Values.TryGetValue("controller", out object controller);

                return controller.ToString();
            }
        }

        public string ActionName
        {
            get
            {
                this.Values.TryGetValue("action", out object action);

                return action.ToString();
            }
        }

        public IEnumerable<string> Namespaces
        {
            get
            {
                return (IEnumerable<string>)this.DataTokens["namespaces"];
            }
        }
    }
}