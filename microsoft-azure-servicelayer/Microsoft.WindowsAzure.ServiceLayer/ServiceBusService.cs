using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Factory for creating service bus services
    /// </summary>
    public static class ServiceBusService
    {
        /// <summary>
        /// Creates a service bus servive using given settings.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>A service bus service with the given parameters</returns>
        public static IServiceBusService Create(string serviceNamespace, string userName, string password)
        {
            if (serviceNamespace == null)
                throw new ArgumentNullException("serviceNamespace");
            if (userName == null)
                throw new ArgumentNullException("userName");
            if (password == null)
                throw new ArgumentNullException("password");

            ServiceBusServiceConfig serviceOptions = new ServiceBusServiceConfig(serviceNamespace, userName, password);
            return new Implementation.ServiceBusRestProxy(serviceOptions);
        }
    }
}
