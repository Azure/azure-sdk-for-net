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
    /// Azure Storage Shared Access Signatures (SAS) URI linked service. This linked service type can be used to provide restricted access to an Azure Storage resource
    /// using a SAS URI.
    /// </summary>
    [AdfTypeName("AzureStorageSas")]
    public class AzureStorageSasLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Required. SAS URI of the Azure Storage resource.
        /// </summary>
        [AdfRequired]
        public string SasUri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageSasLinkedService"/> class.
        /// </summary>
        public AzureStorageSasLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureStorageSasLinkedService"/> class with
        /// required arguments.
        /// </summary>
        public AzureStorageSasLinkedService(string sasUri)
        {
            Ensure.IsNotNullOrEmpty(sasUri, "sasUri");

            this.SasUri = sasUri;
        }
    }
}
