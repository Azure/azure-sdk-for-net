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
    /// Linked Service for Hadoop Distributed File System (HDFS) data source.
    /// </summary>
    [AdfTypeName("Hdfs")]
    public class HdfsLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. Type of authentication used to connect to the HDFS. Possible values are: Anonymous, and Windows.
        /// </summary>
        [AdfRequired]
        public string AuthenticationType { get; set; }

        /// <summary>
        /// Required. The on-premises gateway name.
        /// </summary>
        [AdfRequired]
        public string GatewayName { get; set; }

        /// <summary>
        /// Required. The URL of the HDFS service endpoint, e.g. "http://myhostname:50070/webhdfs/v1".
        /// </summary>
        [AdfRequired]
        public string Url { get; set; }

        /// <summary>
        /// Optional. The encrypted credential for Windows authentication.
        /// </summary>]
        public string EncryptedCredential { get; set; }

        /// <summary>
        /// Optional. Username for Windows authentication.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. Password for Windows authentication.
        /// </summary>
        public string Password { get; set; }

        public HdfsLinkedService()
        {
        }

        public HdfsLinkedService(
            string gatewayName, 
            string url,
            string authenticationType)
            : this()
        {
            Ensure.IsNotNullOrEmpty(gatewayName, "gatewayName");
            Ensure.IsNotNullOrEmpty(url, "url");
            Ensure.IsNotNullOrEmpty(authenticationType, "authenticationType");

            this.GatewayName = gatewayName;
            this.Url = url;
            this.AuthenticationType = authenticationType;
        }
    }
}
