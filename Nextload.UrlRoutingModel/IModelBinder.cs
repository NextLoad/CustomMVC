using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.UrlRoutingModel
{
    public interface IModelBinder
    {
        object BindModel(ControllerContext context, string name, Type parameterType);
    }
}
