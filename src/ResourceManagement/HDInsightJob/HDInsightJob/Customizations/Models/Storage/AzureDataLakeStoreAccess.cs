// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.IO;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataLake.Store;

namespace Microsoft.Azure.Management.HDInsight.Job.Models
{
    public class AzureDataLakeStoreAccess : IStorageAccess
    {
        // Data lake store account name
        private string AccountName;

        // Default storage root of the cluster in data lake store.
        private string DefaultStorageRoot;

        // Data lake store management client.
        private DataLakeStoreFileSystemManagementClient ManagementClient;

        /// <summary>
        /// Initializes a new instance of the DataLakeStorage class.
        /// </summary>
        /// <param name='client'>
        /// Required. The data lake store management client to access Data lake store.
        /// </param>
        /// <param name='storageAccountName'>
        /// Required. The storage account name.
        /// </param>
        public AzureDataLakeStoreAccess(DataLakeStoreFileSystemManagementClient client, string storageAccountName, string defaultStorageRoot)
        {
            this.AccountName = storageAccountName;
            this.ManagementClient = client;
            this.DefaultStorageRoot = defaultStorageRoot;
        }

        /// <summary>
        /// Gets the file content from data lake store file path.
        /// </summary>
        /// <param name='filePath'>
        /// Required. File path to download the content of the file.
        /// </param>
        /// <returns>
        /// Stream which points to content of the file.
        /// </returns>
        public Stream GetFileContent(string filePath)
        {
            // The file path needs to be prefixed with this.DefaultStorageRoot to get the actual path of the file.
            return this.ManagementClient.FileSystem.Open(this.AccountName, 
                this.DefaultStorageRoot + (!this.DefaultStorageRoot.EndsWith("/") ? "/" : string.Empty) + filePath);
        }
    }
}
