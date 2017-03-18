﻿//
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
    /// An on-premises Oracle database.
    /// </summary>
    [AdfTypeName("OnPremisesOracle")]
    public class OnPremisesOracleLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The connection string.
        /// </summary>
        [AdfRequired]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Required. The on-premises HDIS gateway name.
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
        /// Optional. The driver type for an on-premises Oracle server. 
        /// Specify "Microsoft" to use the ODBC driver for Oracle or "ODP" to use the Oracle driver. 
        /// If not specified, the Oracle driver will be used.
        /// </summary>
        public string DriverType { get; set; }

        /// <summary>
        /// Initializes a new instance of the OnPremisesOracleLinkedService
        /// class.
        /// </summary>
        public OnPremisesOracleLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the OnPremisesOracleLinkedService
        /// class with required arguments.
        /// </summary>
        public OnPremisesOracleLinkedService(string connectionString, string gatewayName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(connectionString, "connectionString");
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");

            this.ConnectionString = connectionString;
            this.GatewayName = gatewayName;
        }
    }
}
