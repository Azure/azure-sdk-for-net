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
    /// Linked Service for Open Database Connectivity (ODBC) data source.
    /// </summary>
    [AdfTypeName("OnPremisesOdbc")]
    public class OnPremisesOdbcLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Type of authentication used to connect to the ODBC data store. Possible values are: Anonymous and Basic.
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Required. The non-access credential portion of the connection string as well as an optional encrypted credential,
        /// e.g. "Driver={SQL Server};Server=myserver;Database=mydb;EncryptedCredential=myencryptedcredential".
        /// </summary>
        [AdfRequired]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Optional. The access credential portion of the connection string specified in driver-specific property-value format,
        /// e.g. “Uid=someusername;Pwd=somepassword;RefreshToken=mytoken;”.
        /// </summary>]
        public string Credential { get; set; }

        /// <summary>
        /// Optional. User name for Basic or Windows authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password for Basic or Windows authentication.
        /// </summary>
        public string Password { get; set; }

        public OnPremisesOdbcLinkedService()
        {
        }

        public OnPremisesOdbcLinkedService(
            string gatewayName, 
            string connectionString,
            string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");
            Ensure.IsNotNullOrEmpty(connectionString, "connectionString");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");

            this.GatewayName = gatewayName;
            this.ConnectionString = connectionString;
            this.AuthenticationType = authenticationType;
        }
    }
}
