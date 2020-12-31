using Nextload.UrlRoutingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(SimpleModel simpleModel)
        {
            string content = string.Format("Controller:{0},Action:{1}", simpleModel.Controller, simpleModel.Action);

            return new RawContentResult(content);
        }
    }
}