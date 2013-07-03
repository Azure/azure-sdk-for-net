// -----------------------------------------------------------------------------------------
// <copyright file="SASTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class SASTests : BlobTestBase
    {
        private CloudBlobContainer testContainer;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testContainer = GetRandomContainerReference();
            this.testContainer.CreateAsync().AsTask().Wait();
            
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.testContainer.DeleteAsync().AsTask().Wait();
            this.testContainer = null;
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        private static async Task TestAccessAsync(string sasToken, SharedAccessBlobPermissions permissions, CloudBlobContainer container, ICloudBlob blob)
        {
            OperationContext operationContext = new OperationContext();
            StorageCredentials credentials = string.IsNullOrEmpty(sasToken) ?
                new StorageCredentials() :
                new StorageCredentials(sasToken);

            if (container != null)
            {
                container = new CloudBlobContainer(container.Uri, credentials);
                if (blob.BlobType == BlobType.BlockBlob)
                {
                    blob = container.GetBlockBlobReference(blob.Name);
                }
                else
                {
                    blob = container.GetPageBlobReference(blob.Name);
                }
            }
            else
            {
                if (blob.BlobType == BlobType.BlockBlob)
                {
                    blob = new CloudBlockBlob(blob.Uri, credentials);
                }
                else
                {
                    blob = new CloudPageBlob(blob.Uri, credentials);
                }
            }

            if (container != null)
            {
                if ((permissions & SharedAccessBlobPermissions.List) == SharedAccessBlobPermissions.List)
                {
                    await container.ListBlobsSegmentedAsync(null);
                }
                else
                {
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.None, null, null, null, operationContext),
                        operationContext,
                        "List blobs while SAS does not allow for listing",
                        HttpStatusCode.NotFound);
                }
            }

            if ((permissions & SharedAccessBlobPermissions.Read) == SharedAccessBlobPermissions.Read)
            {
                await blob.FetchAttributesAsync();
            }
            else
            {
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.FetchAttributesAsync(null, null, operationContext),
                    operationContext,
                    "Fetch blob attributes while SAS does not allow for reading",
                    HttpStatusCode.NotFound);
            }

            if ((permissions & SharedAccessBlobPermissions.Write) == SharedAccessBlobPermissions.Write)
            {
                await blob.SetMetadataAsync();
            }
            else
            {
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(null, null, operationContext),
                    operationContext,
                    "Set blob metadata while SAS does not allow for writing",
                    HttpStatusCode.NotFound);
            }

            if ((permissions & SharedAccessBlobPermissions.Delete) == SharedAccessBlobPermissions.Delete)
            {
                await blob.DeleteAsync();
            }
            else
            {
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.DeleteAsync(DeleteSnapshotsOption.None, null, null, operationContext),
                    operationContext,
                    "Delete blob while SAS does not allow for deleting",
                    HttpStatusCode.NotFound);
            }
        }

        private static async Task TestBlobSASAsync(ICloudBlob testBlob, SharedAccessBlobPermissions permissions)
        {
            await UploadTextAsync(testBlob, "blob", Encoding.UTF8);

            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                Permissions = permissions,
            };

            string sasToken = testBlob.GetSharedAccessSignature(policy);
            await SASTests.TestAccessAsync(sasToken, permissions, null, testBlob);
        }

        [TestMethod]
        // [Description("Test updateSASToken")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerUpdateSASTokenAsync()
        {
            // Create a policy with read/write acces and get SAS.
            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write,
            };
            string sasToken = this.testContainer.GetSharedAccessSignature(policy);
            CloudBlockBlob testBlockBlob = this.testContainer.GetBlockBlobReference("blockblob");
            await UploadTextAsync(testBlockBlob, "blob", Encoding.UTF8);
            await TestAccessAsync(sasToken, SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write, this.testContainer, testBlockBlob);

            StorageCredentials creds = new StorageCredentials(sasToken);

            // Change the policy to only read and update SAS.
            SharedAccessBlobPolicy policy2 = new SharedAccessBlobPolicy()
            {
                SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                Permissions = SharedAccessBlobPermissions.Read
            };
            string sasToken2 = this.testContainer.GetSharedAccessSignature(policy2);
            creds.UpdateSASToken(sasToken2);
            
            // Extra check to make sure that we have actually uopdated the SAS token.
            CloudBlobContainer container = new CloudBlobContainer(this.testContainer.Uri, creds);
            CloudBlockBlob blob = container.GetBlockBlobReference("blockblob2");
            OperationContext operationContext = new OperationContext();

            await TestHelper.ExpectedExceptionAsync(
                async () => await UploadTextAsync(blob, "blob", Encoding.UTF8, null, null, operationContext),
                operationContext,
                "Writing to a blob while SAS does not allow for writing",
                HttpStatusCode.NotFound);

            CloudPageBlob testPageBlob = this.testContainer.GetPageBlobReference("pageblob");
            await testPageBlob.CreateAsync(0);
            await TestAccessAsync(sasToken2, SharedAccessBlobPermissions.Read, this.testContainer, testPageBlob);

        }

        [TestMethod]
        /// [Description("Test all combinations of blob permissions against a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerSASCombinationsAsync()
        {
            for (int i = 1; i < 16; i++)
            {
                SharedAccessBlobPermissions permissions = (SharedAccessBlobPermissions)i;
                SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = permissions,
                };
                string sasToken = this.testContainer.GetSharedAccessSignature(policy);

                CloudBlockBlob testBlockBlob = this.testContainer.GetBlockBlobReference("blockblob" + i);
                await UploadTextAsync(testBlockBlob, "blob", Encoding.UTF8);
                await SASTests.TestAccessAsync(sasToken, permissions, this.testContainer, testBlockBlob);

                CloudPageBlob testPageBlob = this.testContainer.GetPageBlobReference("pageblob" + i);
                await UploadTextAsync(testPageBlob, "blob", Encoding.UTF8);
                await SASTests.TestAccessAsync(sasToken, permissions, this.testContainer, testPageBlob);
            }
        }

        [TestMethod]
        /// [Description("Test access on a public container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerPublicAccessAsync()
        {
            CloudBlockBlob testBlockBlob = this.testContainer.GetBlockBlobReference("blockblob");
            await UploadTextAsync(testBlockBlob, "blob", Encoding.UTF8);

            CloudPageBlob testPageBlob = this.testContainer.GetPageBlobReference("pageblob");
            await UploadTextAsync(testPageBlob, "blob", Encoding.UTF8);

            BlobContainerPermissions permissions = new BlobContainerPermissions();

            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            await this.testContainer.SetPermissionsAsync(permissions);
            await Task.Delay(30 * 1000);
            await SASTests.TestAccessAsync(null, SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Read, this.testContainer, testBlockBlob);
            await SASTests.TestAccessAsync(null, SharedAccessBlobPermissions.List | SharedAccessBlobPermissions.Read, this.testContainer, testPageBlob);

            permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
            await this.testContainer.SetPermissionsAsync(permissions);
            await Task.Delay(30 * 1000);
            await SASTests.TestAccessAsync(null, SharedAccessBlobPermissions.Read, this.testContainer, testBlockBlob);
            await SASTests.TestAccessAsync(null, SharedAccessBlobPermissions.Read, this.testContainer, testPageBlob);
        }

        [TestMethod]
        /// [Description("Test all combinations of blob permissions against a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobSASCombinationsAsync()
        {
            for (int i = 1; i < 8; i++)
            {
                CloudBlockBlob testBlob = this.testContainer.GetBlockBlobReference("blob" + i);
                SharedAccessBlobPermissions permissions = (SharedAccessBlobPermissions)i;
                await SASTests.TestBlobSASAsync(testBlob, permissions);
            }
        }

        [TestMethod]
        /// [Description("Test all combinations of blob permissions against a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobSASCombinationsAsync()
        {
            for (int i = 1; i < 8; i++)
            {
                CloudPageBlob testBlob = this.testContainer.GetPageBlobReference("blob" + i);
                SharedAccessBlobPermissions permissions = (SharedAccessBlobPermissions)i;
                await SASTests.TestBlobSASAsync(testBlob, permissions);
            }
        }
    }
}
