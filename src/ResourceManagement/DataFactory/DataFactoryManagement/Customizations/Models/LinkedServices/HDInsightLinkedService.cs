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
    /// The properties for the HDInsight linkedService.
    /// </summary>
    [AdfTypeName("HDInsight")]
    public class HDInsightLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. HDInsight cluster URI.
        /// </summary>
        [AdfRequired]
        public string ClusterUri { get; set; }

        /// <summary>
        /// Optional. Storage service name.
        /// </summary>
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Required. HDInsight cluster password.
        /// </summary>
        [AdfRequired]
        public string Password { get; set; }

        /// <summary>
        /// Required. HDInsight cluster user name.
        /// </summary>
        [AdfRequired]
        public string UserName { get; set; }

        /// <summary>
        /// The name of Azure SQL linked service that point to the HCatalog database.
        /// </summary>
        public string HcatalogLinkedServiceName { get; set; }

        /// <summary>
        /// Define what options to use for generating/altering an input and output Datasets for an HDInsight activity
        /// </summary>
        public HDInsightSchemaGenerationProperties SchemaGeneration { get; set; }

        /// <summary>
        /// Initializes a new instance of the HDInsightBYOCLinkedService class.
        /// </summary>
        public HDInsightLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the HDInsightBYOCLinkedService class
        /// with required arguments.
        /// </summary>
        public HDInsightLinkedService(string clusterUri, string userName, string password)
            : this()
        {
            Ensure.IsNotNullOrEmpty(clusterUri, "clusterUri");
            Ensure.IsNotNullOrEmpty(userName, "userName");
            Ensure.IsNotNullOrEmpty(password, "password");

            this.ClusterUri = clusterUri;
            this.UserName = userName;
            this.Password = password;
        }
    }
}
