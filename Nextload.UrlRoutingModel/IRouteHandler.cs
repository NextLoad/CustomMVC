using System.Web;

namespace Nextload.UrlRoutingModel
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}