using System.Web;

namespace Nextload.UrlRoutingModel
{
    public abstract class RouteBase
    {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}