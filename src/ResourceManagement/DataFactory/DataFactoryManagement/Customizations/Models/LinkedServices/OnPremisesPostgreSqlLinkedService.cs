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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Linked Service for PostgreSql data source.
    /// </summary>
    [AdfTypeName("OnPremisesPostgreSql")]
    public class OnPremisesPostgreSqlLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. AuthenticationType to be used for connection.
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. Database name for connection.
        /// </summary>
        [AdfRequired]
        public string Database { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for authentication.
        /// </summary>]
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. Password for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. Schema name for connection.
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Required. Server name for connection.
        /// </summary>
        [AdfRequired]
        public string Server { get; set; }

        /// <summary>
        /// Optional. Username for authentication.
        /// </summary>
        public string Username { get; set; }

        public OnPremisesPostgreSqlLinkedService()
        {
        }

        public OnPremisesPostgreSqlLinkedService(
            string gatewayName, 
            string server, 
            string database,
            string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");
            Ensure.IsNotNullOrEmpty(server, "server");
            Ensure.IsNotNullOrEmpty(database, "database");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");

            this.GatewayName = gatewayName;
            this.Server = server;
            this.Database = database;
            this.AuthenticationType = authenticationType;
        }
    }
}
