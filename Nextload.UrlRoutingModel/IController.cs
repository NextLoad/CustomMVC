namespace Nextload.UrlRoutingModel
{
    public  interface IController
    {
        void Execute(RequestContext requestContext);
    }
}