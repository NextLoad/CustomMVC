using System.Web;

namespace Nextload.UrlRoutingModel
{
    internal class MvcHandler : IHttpHandler
    {
        public RequestContext RequestContext
        {
            get; private set;
        }

        public MvcHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }

        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            string controllerName = RequestContext.RouteData.ControllerName;

            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();

            IController controller = controllerFactory.CreateController(this.RequestContext, controllerName);

            controller.Execute(this.RequestContext);
        }
    }
}