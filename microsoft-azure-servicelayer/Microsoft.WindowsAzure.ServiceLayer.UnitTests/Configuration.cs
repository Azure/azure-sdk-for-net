using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    static class Configuration
    {
        private static IServiceBusService _serviceBus;

        public static string ServiceNamespace { get { throw new NotImplementedException();  } }

        public static string UserName { get { throw new NotImplementedException(); } }

        public static string Password { get { throw new NotImplementedException(); } }

        public static IServiceBusService ServiceBus
        {
            get
            {
                if (_serviceBus == null)
                {
                    _serviceBus = ServiceBusService.Create(ServiceNamespace, UserName, Password);
                }
                return _serviceBus;
            }
        }
    }
}
