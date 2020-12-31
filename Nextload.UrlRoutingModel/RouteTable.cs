using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextload.UrlRoutingModel
{
    public class RouteTable
    {
        public static RouteDictionary Routes { get; set; }

        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
}
