using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Options of the service bus service.
    /// </summary>
    public class ServiceBusServiceConfig
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
        /// Gets the service bus URI.
        /// </summary>
        internal Uri ServiceBusUri { get; private set; }

        /// <summary>
        /// Gets URI of the authentication service.
        /// </summary>
        internal Uri AuthenticationUri { get; private set; }

        /// <summary>
        /// Gets the host URI for authenticating requests.
        /// </summary>
        internal Uri ScopeHostUri { get; private set; }

        /// <summary>
        /// Constructor with explicitly specified options.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace</param>
        /// <param name="userName">User name for authentication</param>
        /// <param name="password">Password for authentication</param>
        internal ServiceBusServiceConfig(string serviceNamespace, string userName, string password)
        {
            ServiceNamespace = serviceNamespace;
            UserName = userName;
            Password = password;

            string stringUri = string.Format(CultureInfo.InvariantCulture, "https://{0}.servicebus.windows.net/", ServiceNamespace);
            ServiceBusUri = new Uri(stringUri, UriKind.Absolute);

            stringUri = string.Format(CultureInfo.InvariantCulture, "https://{0}-sb.accesscontrol.windows.net/wrapv0.9/", ServiceNamespace);
            AuthenticationUri = new Uri(stringUri, UriKind.Absolute);

            stringUri = string.Format(CultureInfo.InvariantCulture, "http://{0}.servicebus.windows.net/", ServiceNamespace);
            ScopeHostUri = new Uri(stringUri);
        }
    }
}
