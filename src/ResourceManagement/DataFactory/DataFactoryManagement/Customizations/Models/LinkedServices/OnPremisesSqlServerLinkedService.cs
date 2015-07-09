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
    /// An on-premises SQL server database.
    /// </summary>
    [AdfTypeName("OnPremisesSqlServer")]
    public class OnPremisesSqlServerLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The connection string.
        /// </summary>
        [AdfRequired]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Optional. The on-premises Windows authentication password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional. The on-premises Windows authentication user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Initializes a new instance of the OnPremisesSqlLinkedService class.
        /// </summary>
        public OnPremisesSqlServerLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the OnPremisesSqlLinkedService class
        /// with required arguments.
        /// </summary>
        public OnPremisesSqlServerLinkedService(string connectionString, string gatewayName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(connectionString, "connectionString");
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");

            this.ConnectionString = connectionString;
            this.GatewayName = gatewayName;
        }
    }
}
