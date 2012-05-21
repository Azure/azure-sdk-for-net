using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Options of the service bus service.
    /// </summary>
    public class ServiceBusServiceOptions
    {
        /// <summary>
        /// Gets the service namespace.
        /// </summary>
        public string ServiceNamespace { get; private set; }

        /// <summary>
        /// Gets the user name used for authentication.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password used for authentication.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Constructor with explicitly specified options.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace</param>
        /// <param name="userName">User name for authentication</param>
        /// <param name="password">Password for authentication</param>
        internal ServiceBusServiceOptions(string serviceNamespace, string userName, string password)
        {
            ServiceNamespace = serviceNamespace;
            UserName = userName;
            Password = password;
        }
    }
}
