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

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Linq;

namespace Microsoft.Azure.Test
{
    public static class ComputeManagementTestUtilities
    {
        /// <summary>
        /// Create a management client from the connection string stored in an environment variable
        /// </summary>
        /// <returns></returns>
        public static ComputeManagementClient GetComputeManagementClient(this TestBase testBase)
        {
            return TestBase.GetServiceClient<ComputeManagementClient>();
        }

        public static Uri CopyBlobInStorage(string storageAccount, Uri srcBlobUri, string destContainer, string destBlob)
        {
            Uri blobUri = null;
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                using (StorageManagementClient client = TestBase.GetServiceClient<StorageManagementClient>())
                {
                    var service = client.StorageAccounts.Get(storageAccount);
                    var keys = client.StorageAccounts.GetKeys(storageAccount);
                    var account = new CloudStorageAccount(
                        new StorageCredentials(storageAccount, keys.PrimaryKey),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".blob.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".queue.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".table.")),
                        service.StorageAccount.Properties.Endpoints.FirstOrDefault(e => e.ToString().ToLower().Contains(".file.")));
                    var blobClient = account.CreateCloudBlobClient();
                    var containerClient = blobClient.GetContainerReference(destContainer);
                    containerClient.CreateIfNotExists();
                    containerClient.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });

                    var srcBlob = blobClient.GetBlobReferenceFromServer(srcBlobUri);
                    if (srcBlob.BlobType == BlobType.PageBlob)
                    {
                        var pageBlob = containerClient.GetPageBlobReference(destBlob);
                        pageBlob.StartCopyFromBlob(srcBlobUri);
                        blobUri = pageBlob.Uri;
                    }
                    else
                    {
                        var blockBlob = containerClient.GetBlockBlobReference(destBlob);
                        blockBlob.StartCopyFromBlob(srcBlobUri);
                        blobUri = blockBlob.Uri;
                    }
                }
            }
            else
            {
                // in playback mode, calculate the correct blob uri
                blobUri = new Uri(string.Format("https://{0}.blob.core.windows.net/{1}/{2}", storageAccount, destContainer, destBlob));
            }

            return blobUri;
        }

        public static Uri CopyPageBlobInStorage(string storageAccount, Uri srcBlobUri, string destContainer, string destBlob)
        {
            Uri blobUri = null;
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                using (StorageManagementClient client = TestBase.GetServiceClient<StorageManagementClient>())
                {
                    var service = client.StorageAccounts.Get(storageAccount);
                    var keys = client.StorageAccounts.GetKeys(storageAccount);
                    var account = new CloudStorageAccount(
                        new StorageCredentials(storageAccount, keys.PrimaryKey),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".blob.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".queue.")),
                        service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".table.")),
                        service.StorageAccount.Properties.Endpoints.FirstOrDefault(e => e.ToString().ToLower().Contains(".file.")));
                    var blobClient = account.CreateCloudBlobClient();
                    var containerClient = blobClient.GetContainerReference(destContainer);
                    containerClient.CreateIfNotExists();
                    containerClient.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });

                    var pageBlob = containerClient.GetPageBlobReference(destBlob);
                    pageBlob.StartCopyFromBlob(srcBlobUri);
                    blobUri = pageBlob.Uri;
                }
            }
            else
            {
                // in playback mode, calculate the correct blob uri
                blobUri = new Uri(string.Format("https://{0}.blob.core.windows.net/{1}/{2}", storageAccount, destContainer, destBlob));
            }

            return blobUri;
        }

        public static DateTime GetDeploymentEventStartDate()
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                return DateTime.Now.AddDays(-30);
            }
            else
            {
                return new DateTime(2015, 1, 10);
            }
        }

        public static DateTime GetDeploymentEventEndDate()
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                return DateTime.Now.AddDays(-20);
            }
            else
            {
                return new DateTime(2015, 1, 20);
            }
        }
    }
}
