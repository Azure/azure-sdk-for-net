/*
 * Copyright 2012 Microsoft Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Options of the service bus service.
    /// </summary>
    public class ServiceConfiguration
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
        internal ServiceConfiguration(string serviceNamespace, string userName, string password)
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
