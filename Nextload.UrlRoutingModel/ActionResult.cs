using System;

namespace Nextload.UrlRoutingModel
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}