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

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Testing
{
    public static class StorageTestUtilities
    {
        /// <summary>
        /// Create a storage management client from the connection string stored in an environment variable
        /// </summary>
        /// <returns></returns>
        public static StorageManagementClient GetStorageManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<StorageManagementClient>();
        }

        public static Uri UploadFileToBlobStorage(string storageAccount, string container, string filePath)
        {
            Uri blobUri = null;
            string fileName = Path.GetFileName(filePath);
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Debug.Assert(File.Exists(filePath));
                using (StorageManagementClient client = TestBase.GetServiceClient<StorageManagementClient>())
                using (var filestream = File.OpenRead(filePath))
                {
                    var service = client.StorageAccounts.Get(storageAccount);
                    var keys = client.StorageAccounts.GetKeys(storageAccount);
                    var account = new CloudStorageAccount(
                        new Storage.Auth.StorageCredentials(storageAccount, keys.PrimaryKey),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".blob.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".queue.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".table.")),
                        service.StorageAccount.Properties.Endpoints.FirstOrDefault(e => e.ToString().ToLower().Contains(".file.")));
                    var blobClient = account.CreateCloudBlobClient();
                    var containerClient = blobClient.GetContainerReference(container);
                    containerClient.CreateIfNotExists();
                    containerClient.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });
                    var blob = containerClient.GetBlockBlobReference(fileName);
                    blob.UploadFromStream(filestream);
                    blobUri = blob.Uri;
                }
            }
            else
            {
                // in playback mode, calculate the correct blob uri
                blobUri = new Uri(string.Format("https://{0}.blob.core.windows.net/{1}/{2}", storageAccount, container, fileName));
            }

            return blobUri;
        }
    }
}
