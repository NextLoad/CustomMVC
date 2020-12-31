using System;
using System.Collections.Generic;

namespace Nextload.UrlRoutingModel
{
    public class ControllerBuilder
    {
        public static ControllerBuilder Current { get; internal set; }
        public HashSet<string> DefaultNamespaces { get; }

        private Func<IControllerFactory> _factoryTunck;
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }

        public ControllerBuilder()
        {
            this.DefaultNamespaces = new HashSet<string>();
        }

        public IControllerFactory GetControllerFactory()
        {
            return _factoryTunck?.Invoke();
        }

        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            _factoryTunck = () => controllerFactory;
        }
    }
}