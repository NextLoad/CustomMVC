namespace Nextload.UrlRoutingModel
{
    public class RawContentResult : ActionResult
    {
        private string content;

        public RawContentResult(string content)
        {
            this.content = content;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.Write(this.content);
        }
    }
}