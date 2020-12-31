using System.Web;

namespace Nextload.UrlRoutingModel
{
    public class RequestContext
    {
        public virtual HttpContextBase HttpContext { get; set; }

        public virtual RouteData RouteData { get; set; }
    }
}