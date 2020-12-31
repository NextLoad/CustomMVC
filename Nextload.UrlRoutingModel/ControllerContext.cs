using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.UrlRoutingModel
{
    public class ControllerContext
    {
        public RequestContext RequestContext { get; internal set; }
        public ControllerBase Controller { get; internal set; }
    }
}
