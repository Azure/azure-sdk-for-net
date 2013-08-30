// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobContainerTest.cs" company="Microsoft">
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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Windows.Globalization;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlobContainerTest : BlobTestBase
    {
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        private static async Task TestAccessAsync(BlobContainerPublicAccessType accessType, CloudBlobContainer container, ICloudBlob inputBlob)
        {
            StorageCredentials credentials = new StorageCredentials();
            container = new CloudBlobContainer(container.Uri, credentials);
            CloudPageBlob blob = new CloudPageBlob(inputBlob.Uri, credentials);
            OperationContext context = new OperationContext();
            BlobRequestOptions options = new BlobRequestOptions();

            if (accessType.Equals(BlobContainerPublicAccessType.Container))
            {
                await blob.FetchAttributesAsync();
                await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All, null, null, options, context);
                await container.FetchAttributesAsync();
            }
            else if (accessType.Equals(BlobContainerPublicAccessType.Blob))
            {
                await blob.FetchAttributesAsync();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All, null, null, options, context),
                    context,
                    "List blobs while public access does not allow for listing",
                    HttpStatusCode.NotFound);
                await TestHelper.ExpectedExceptionAsync(
                    async () => await container.FetchAttributesAsync(null, options, context),
                    context,
                    "Fetch container attributes while public access does not allow",
                    HttpStatusCode.NotFound);
            }
            else
            {
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.FetchAttributesAsync(null, options, context),
                    context,
                    "Fetch blob attributes while public access does not allow",
                    HttpStatusCode.NotFound);
                await TestHelper.ExpectedExceptionAsync(
                    async () => await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All, null, null, options, context),
                    context,
                    "List blobs while public access does not allow for listing",
                    HttpStatusCode.NotFound);
                await TestHelper.ExpectedExceptionAsync(
                    async () => await container.FetchAttributesAsync(null, options, context),
                    context,
                    "Fetch container attributes while public access does not allow",
                    HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        // [Description("Validate container references")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerReference()
        {
            CloudBlobClient client = GenerateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("container");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("directory1/blob1");
            CloudPageBlob pageBlob = container.GetPageBlobReference("directory2/blob2");
            CloudBlobDirectory directory = container.GetDirectoryReference("directory3");
            CloudBlobDirectory directory2 = directory.GetSubdirectoryReference("directory4");

            Assert.AreEqual(container, blockBlob.Container);
            Assert.AreEqual(container, pageBlob.Container);
            Assert.AreEqual(container, directory.Container);
            Assert.AreEqual(container, directory2.Container);
            Assert.AreEqual(container, directory2.Parent.Container);
            Assert.AreEqual(container, blockBlob.Parent.Container);
            Assert.AreEqual(container, blockBlob.Parent.Container);
        }

        [TestMethod]
        /// [Description("Create and delete a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            await container.CreateAsync();
            OperationContext operationContext = new OperationContext();
            Assert.ThrowsException<AggregateException>(
                () => container.CreateAsync(null, operationContext).AsTask().Wait(),
                "Creating already exists container should fail");
            Assert.AreEqual((int)HttpStatusCode.Conflict, operationContext.LastResult.HttpStatusCode);
            await container.DeleteAsync();
        }

        [TestMethod]
        /// [Description("Try to create a container after it is created")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateIfNotExistsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                Assert.IsTrue(await container.CreateIfNotExistsAsync());
                Assert.IsFalse(await container.CreateIfNotExistsAsync());
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Try to delete a non-existing container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerDeleteIfExistsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            Assert.IsFalse(await container.DeleteIfExistsAsync());
            await container.CreateAsync();
            Assert.IsTrue(await container.DeleteIfExistsAsync());
            Assert.IsFalse(await container.DeleteIfExistsAsync());
        }

        [TestMethod]
        // [Description("Create a container with AccessType")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateWithContainerAccessTypeAsyncOverload()
        {
            CloudBlobContainer container = GetRandomContainerReference();

            try
            {
                await container.CreateAsync(BlobContainerPublicAccessType.Container, null, null);
                CloudPageBlob blob1 = container.GetPageBlobReference("blob1");
                await blob1.CreateAsync(0);
                CloudPageBlob blob2 = container.GetPageBlobReference("blob2");
                await blob2.CreateAsync(0);

                await TestAccessAsync(BlobContainerPublicAccessType.Container, container, blob1);
                await TestAccessAsync(BlobContainerPublicAccessType.Container, container, blob2);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        // [Description("Create a container with AccessType")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateWithBlobAccessTypeAsyncOverload()
        {
            CloudBlobContainer container = GetRandomContainerReference();

            try
            {
                await container.CreateAsync(BlobContainerPublicAccessType.Blob, null, null);
                CloudPageBlob blob1 = container.GetPageBlobReference("blob1");
                await blob1.CreateAsync(0);
                CloudPageBlob blob2 = container.GetPageBlobReference("blob2");
                await blob2.CreateAsync(0);

                await TestAccessAsync(BlobContainerPublicAccessType.Blob, container, blob1);
                await TestAccessAsync(BlobContainerPublicAccessType.Blob, container, blob2);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        // [Description("Create a container with AccessType")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateWithPrivateAccessTypeAsyncOverload()
        {
            CloudBlobContainer container = GetRandomContainerReference();

            try
            {
                await container.CreateAsync(BlobContainerPublicAccessType.Off, null, null);
                CloudPageBlob blob1 = container.GetPageBlobReference("blob1");
                await blob1.CreateAsync(0);
                CloudPageBlob blob2 = container.GetPageBlobReference("blob2");
                await blob2.CreateAsync(0);

                await TestAccessAsync(BlobContainerPublicAccessType.Off, container, blob1);
                await TestAccessAsync(BlobContainerPublicAccessType.Off, container, blob2);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Check a container's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerExistsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);

            try
            {
                Assert.IsFalse(await container2.ExistsAsync());
                
                await container.CreateAsync();
                
                Assert.IsTrue(await container2.ExistsAsync());
                Assert.IsNotNull(container2.Properties.ETag);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }

            Assert.IsFalse(await container2.ExistsAsync());
        }

        [TestMethod]
        /// [Description("Set container permissions")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerSetPermissionsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                BlobContainerPermissions permissions = await container.GetPermissionsAsync();
                Assert.AreEqual(BlobContainerPublicAccessType.Off, permissions.PublicAccess);
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                permissions.SharedAccessPolicies.Add("key1", new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessBlobPermissions.List,
                });
                await container.SetPermissionsAsync(permissions);
                await Task.Delay(30 * 1000);

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                permissions = await container2.GetPermissionsAsync();
                Assert.AreEqual(BlobContainerPublicAccessType.Container, permissions.PublicAccess);
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.HasValue);
                Assert.AreEqual(start, permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.Value.UtcDateTime);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.HasValue);
                Assert.AreEqual(expiry, permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.Value.UtcDateTime);
                Assert.AreEqual(SharedAccessBlobPermissions.List, permissions.SharedAccessPolicies["key1"].Permissions);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerCreateWithMetadataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Metadata.Add("key1", "value1");
                await container.CreateAsync();

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                await container2.FetchAttributesAsync();
                Assert.AreEqual(1, container2.Metadata.Count);
                Assert.AreEqual("value1", container2.Metadata["key1"]);

                Assert.IsTrue(container2.Properties.LastModified.Value.AddHours(1) > DateTimeOffset.Now);
                Assert.IsNotNull(container2.Properties.ETag);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerSetMetadataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                await container2.FetchAttributesAsync();
                Assert.AreEqual(0, container2.Metadata.Count);

                container.Metadata.Add("key1", "value1");
                await container.SetMetadataAsync();

                await container2.FetchAttributesAsync();
                Assert.AreEqual(1, container2.Metadata.Count);
                Assert.AreEqual("value1", container2.Metadata["key1"]);

                ContainerResultSegment results = await container.ServiceClient.ListContainersSegmentedAsync(container.Name, ContainerListingDetails.Metadata, null, null, null, null);
                CloudBlobContainer container3 = results.Results.First();
                Assert.AreEqual(1, container3.Metadata.Count);
                Assert.AreEqual("value1", container3.Metadata["key1"]);

                container.Metadata.Clear();
                await container.SetMetadataAsync();

                await container2.FetchAttributesAsync();
                Assert.AreEqual(0, container2.Metadata.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerRegionalSetMetadataAsync()
        {
            string currentPrimaryLanguage = ApplicationLanguages.PrimaryLanguageOverride;
            ApplicationLanguages.PrimaryLanguageOverride = "sk-SK";

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Metadata.Add("sequence", "value");
                container.Metadata.Add("schema", "value");
                await container.CreateAsync();
            }
            finally
            {
                ApplicationLanguages.PrimaryLanguageOverride = currentPrimaryLanguage;
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("List blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerListBlobsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                List<string> blobNames = await CreateBlobsAsync(container, 3, BlobType.PageBlob);

                BlobResultSegment results = await container.ListBlobsSegmentedAsync(null);
                Assert.AreEqual(blobNames.Count, results.Results.Count());
                foreach (IListBlobItem blobItem in results.Results)
                {
                    Assert.IsInstanceOfType(blobItem, typeof(CloudPageBlob));
                    Assert.IsTrue(blobNames.Remove(((CloudPageBlob)blobItem).Name));
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("List blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerListBlobsSegmentedAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                List<string> blobNames = await CreateBlobsAsync(container, 3, BlobType.PageBlob);

                BlobContinuationToken token = null;
                do
                {
                    BlobResultSegment results = await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.None, 1, token, null, null);
                    int count = 0;
                    foreach (IListBlobItem blobItem in results.Results)
                    {
                        Assert.IsInstanceOfType(blobItem, typeof(CloudPageBlob));
                        Assert.IsTrue(blobNames.Remove(((CloudPageBlob)blobItem).Name));
                        count++;
                    }
                    Assert.AreEqual(1, count);
                    token = results.ContinuationToken;
                }
                while (token != null);
                Assert.AreEqual(0, blobNames.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Get a blob reference without knowing its type")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerGetBlobReferenceFromServerAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                };

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("bb");
                await blockBlob.PutBlockListAsync(new List<string>());

                CloudPageBlob pageBlob = container.GetPageBlobReference("pb");
                await pageBlob.CreateAsync(0);

                ICloudBlob blob1 = await container.GetBlobReferenceFromServerAsync("bb");
                Assert.IsInstanceOfType(blob1, typeof(CloudBlockBlob));

                CloudBlockBlob blob1Snapshot = await ((CloudBlockBlob)blob1).CreateSnapshotAsync();
                await blob1.SetPropertiesAsync();
                Uri blob1SnapshotUri = new Uri(blob1Snapshot.Uri.AbsoluteUri + "?snapshot=" + blob1Snapshot.SnapshotTime.Value.UtcDateTime.ToString("o"));
                ICloudBlob blob1SnapshotReference = await container.ServiceClient.GetBlobReferenceFromServerAsync(blob1SnapshotUri);
                AssertAreEqual(blob1Snapshot.Properties, blob1SnapshotReference.Properties);

                ICloudBlob blob2 = await container.GetBlobReferenceFromServerAsync("pb");
                Assert.IsInstanceOfType(blob2, typeof(CloudPageBlob));

                CloudPageBlob blob2Snapshot = await ((CloudPageBlob)blob2).CreateSnapshotAsync();
                await blob2.SetPropertiesAsync();
                Uri blob2SnapshotUri = new Uri(blob2Snapshot.Uri.AbsoluteUri + "?snapshot=" + blob2Snapshot.SnapshotTime.Value.UtcDateTime.ToString("o"));
                ICloudBlob blob2SnapshotReference = await container.ServiceClient.GetBlobReferenceFromServerAsync(blob2SnapshotUri);
                AssertAreEqual(blob2Snapshot.Properties, blob2SnapshotReference.Properties);

                ICloudBlob blob3 = await container.ServiceClient.GetBlobReferenceFromServerAsync(blockBlob.Uri);
                Assert.IsInstanceOfType(blob3, typeof(CloudBlockBlob));

                ICloudBlob blob4 = await container.ServiceClient.GetBlobReferenceFromServerAsync(pageBlob.Uri);
                Assert.IsInstanceOfType(blob4, typeof(CloudPageBlob));

                string blockBlobToken = blockBlob.GetSharedAccessSignature(policy);
                StorageCredentials blockBlobSAS = new StorageCredentials(blockBlobToken);
                Uri blockBlobSASUri = blockBlobSAS.TransformUri(blockBlob.Uri);

                string pageBlobToken = pageBlob.GetSharedAccessSignature(policy);
                StorageCredentials pageBlobSAS = new StorageCredentials(pageBlobToken);
                Uri pageBlobSASUri = pageBlobSAS.TransformUri(pageBlob.Uri);

                ICloudBlob blob5 = await container.ServiceClient.GetBlobReferenceFromServerAsync(blockBlobSASUri);
                Assert.IsInstanceOfType(blob5, typeof(CloudBlockBlob));

                ICloudBlob blob6 = await container.ServiceClient.GetBlobReferenceFromServerAsync(pageBlobSASUri);
                Assert.IsInstanceOfType(blob6, typeof(CloudPageBlob));

                CloudBlobClient client7 = new CloudBlobClient(container.ServiceClient.BaseUri, blockBlobSAS);
                ICloudBlob blob7 = await client7.GetBlobReferenceFromServerAsync(blockBlobSASUri);
                Assert.IsInstanceOfType(blob7, typeof(CloudBlockBlob));

                CloudBlobClient client8 = new CloudBlobClient(container.ServiceClient.BaseUri, pageBlobSAS);
                ICloudBlob blob8 = await client8.GetBlobReferenceFromServerAsync(pageBlobSASUri);
                Assert.IsInstanceOfType(blob8, typeof(CloudPageBlob));
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test conditional access on a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlobContainerConditionalAccessAsync()
        {
            OperationContext operationContext = new OperationContext();
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                await container.FetchAttributesAsync();

                string currentETag = container.Properties.ETag;
                DateTimeOffset currentModifiedTime = container.Properties.LastModified.Value;

                // ETag conditional tests
                container.Metadata["ETagConditionalName"] = "ETagConditionalValue";
                await container.SetMetadataAsync();

                await container.FetchAttributesAsync();
                string newETag = container.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");

                // LastModifiedTime tests
                currentModifiedTime = container.Properties.LastModified.Value;

                container.Metadata["DateConditionalName"] = "DateConditionalValue";

                await TestHelper.ExpectedExceptionAsync(
                    async () => await container.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(currentModifiedTime), null, operationContext),
                    operationContext,
                    "IfModifiedSince conditional on current modified time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                container.Metadata["DateConditionalName"] = "DateConditionalValue2";
                currentETag = container.Properties.ETag;

                DateTimeOffset pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                await container.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                await container.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                await container.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                await container.FetchAttributesAsync();
                newETag = container.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}
