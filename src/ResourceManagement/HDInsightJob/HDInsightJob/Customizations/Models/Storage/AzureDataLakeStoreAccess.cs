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
        // Data Lake Store account name
        private string AccountName;

        // Default storage root path for the cluster in Data Lake Store.
        private string DefaultStorageRootPath;

        // Data Lake Store management client.
        private DataLakeStoreFileSystemManagementClient ManagementClient;

        /// <summary>
        /// Initializes a new instance of the AzureDataLakeStoreAccess class.
        /// </summary>
        /// <param name='client'>
        /// Required. The Data Lake Store management client.
        /// </param>
        /// <param name='storageAccountName'>
        /// Required. The Data Lake Store storage account name.
        /// </param>
        /// <param name='defaultStorageRootPath'>
        /// Required. The default storage root path in Data Lake Store for the cluster.
        /// </param>
        public AzureDataLakeStoreAccess(DataLakeStoreFileSystemManagementClient client, string storageAccountName, string defaultStorageRootPath)
        {
            this.AccountName = storageAccountName;
            this.ManagementClient = client;
            this.DefaultStorageRootPath = defaultStorageRootPath;
        }

        /// <summary>
        /// Gets the file content from Data Lake Store file path.
        /// </summary>
        /// <param name='filePath'>
        /// Required. File path to download the content of the file.
        /// </param>
        /// <returns>
        /// Stream which points to content of the file.
        /// </returns>
        public Stream GetFileContent(string filePath)
        {
            // The file path needs to be prefixed with DefaultStorageRootPath to get the actual path of the file in the cluster.
            return this.ManagementClient.FileSystem.Open(this.AccountName,
                this.DefaultStorageRootPath + (!this.DefaultStorageRootPath.EndsWith("/") ? "/" : string.Empty) + filePath);
        }
    }
}
