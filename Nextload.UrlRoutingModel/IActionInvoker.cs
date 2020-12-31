namespace Nextload.UrlRoutingModel
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext context, string actionName);
    }
}