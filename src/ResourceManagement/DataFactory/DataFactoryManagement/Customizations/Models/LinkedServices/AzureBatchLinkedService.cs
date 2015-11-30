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
    [AdfTypeName("AzureBatch")]
    public class AzureBatchLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. The Azure Batch account access key.
        /// </summary>
        [AdfRequired]
        public string AccessKey { get; set; }

        /// <summary>
        /// Required. The Azure Batch account name.
        /// </summary>
        [AdfRequired]
        public string AccountName { get; set; }

        /// <summary>
        /// Required. The Azure Batch URI.
        /// </summary>
        [AdfRequired]
        public string BatchUri { get; set; }

        /// <summary>
        /// Required. The azure storage linked service name.
        /// </summary>
        [AdfRequired]
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Required. The Azure Batch pool name.
        /// </summary>
        [AdfRequired]
        public string PoolName { get; set; }

        public AzureBatchLinkedService()
        {
        }

        public AzureBatchLinkedService(
            string accountName, 
            string batchUri, 
            string accessKey, 
            string poolName, 
            string linkedServiceName)
            : this()
        {
            Ensure.IsNotNullOrEmpty(accountName, "accountName");
            Ensure.IsNotNullOrEmpty(batchUri, "batchUri");
            Ensure.IsNotNullOrEmpty(accessKey, "accessKey");
            Ensure.IsNotNullOrEmpty(poolName, "poolName");
            Ensure.IsNotNullOrEmpty(linkedServiceName, "linkedServiceName");

            this.AccountName = accountName;
            this.BatchUri = batchUri;
            this.AccessKey = accessKey;
            this.PoolName = poolName;
            this.LinkedServiceName = linkedServiceName;
        }
    }
}
