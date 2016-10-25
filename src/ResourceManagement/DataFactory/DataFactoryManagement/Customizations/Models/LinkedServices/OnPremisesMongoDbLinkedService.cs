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
    /// An on-premises MongoDB database.
    /// </summary>
    [AdfTypeName("OnPremisesMongoDb")]
    public class OnPremisesMongoDbLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The IP address or name of the MongoDB server.
        /// </summary>
        [AdfRequired]
        public string Server { get; set; }

        /// <summary>
        /// Required. The authentication type to be used to connect to the MongoDB database. Must be Basic or Anonymous. 
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. The name of the MongoDB database that you want to access.
        /// </summary>
        [AdfRequired]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. The TCP port number that the MongoDB server uses to listen for client connections. The default value is 27017.
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
        /// Optional. The name of the MongoDB database that you want to use to check your credentials. The default is admin.
        /// </summary>
        public string AuthSource { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Basic authentication.
        /// </summary>
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnPremisesMongoDbLinkedService"/> class.
        /// </summary>
        public OnPremisesMongoDbLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnPremisesMongoDbLinkedService"/>
        /// class with required arguments.
        /// </summary>
        public OnPremisesMongoDbLinkedService(string server, string authenticationType, string databaseName, string gatewayName)
        {
            Ensure.IsNotNullOrEmpty(server, "server");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");
            Ensure.IsNotNullOrEmpty(databaseName, "databaseName");
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");
            this.Server = server;
            this.AuthenticationType = authenticationType;
            this.DatabaseName = databaseName;
            this.GatewayName = gatewayName;
        }
    }
}

