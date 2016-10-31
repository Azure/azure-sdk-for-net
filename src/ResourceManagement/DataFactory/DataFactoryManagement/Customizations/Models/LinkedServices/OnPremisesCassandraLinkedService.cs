//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// An on-premises Cassandra database.
    /// </summary>
    [AdfTypeName("OnPremisesCassandra")]
    public class OnPremisesCassandraLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. One or more IP addresses or host names of the Cassandra server.
        /// Specify a comma-separated list of IP addresses and/or host names if attempting to connect to multiple servers.
        /// Each server is a replica.
        /// </summary>
        [AdfRequired]
        public string Host { get; set; }

        /// <summary>
        /// Required. The authentication type to be used to connect to the Cassandra database. Must be Basic or Anonymous. 
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. The TCP port number that the Cassandra server uses to listen for client connections. The default value is 9042.
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Optional. The username for Basic authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. The password for Basic authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Basic authentication.
        /// </summary>
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnPremisesCassandraLinkedService"/>.
        /// </summary>
        public OnPremisesCassandraLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnPremisesCassandraLinkedService"/>
        /// class with required arguments.
        /// </summary>
        public OnPremisesCassandraLinkedService(string host, string authenticationType, string gatewayName)
        {
            Ensure.IsNotNullOrEmpty(host, "host");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");
            this.Host = host;
            this.AuthenticationType = authenticationType;
            this.GatewayName = gatewayName;
        }
    }
}

