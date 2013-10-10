// -----------------------------------------------------------------------------------------
// <copyright file="CopyBlobTest.cs" company="Microsoft">
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
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CopyBlobTest : BlobTestBase
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

        [TestMethod]
        // [Description("CopyFromBlob with Unicode source blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CopyBlobUsingUnicodeBlobNameAsync()
        {
            string _unicodeBlobName = "繁体字14a6c";
            string _nonUnicodeBlobName = "sample_file";

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudBlockBlob blobUnicodeSource = container.GetBlockBlobReference(_unicodeBlobName);
                string data = "Test content";
                await UploadTextAsync(blobUnicodeSource, data, Encoding.UTF8);
                CloudBlockBlob blobAsciiSource = container.GetBlockBlobReference(_nonUnicodeBlobName);
                await UploadTextAsync(blobAsciiSource, data, Encoding.UTF8);

                //Copy blobs over
                CloudBlockBlob blobAsciiDest = container.GetBlockBlobReference(_nonUnicodeBlobName + "_copy");
                string copyId = await blobAsciiDest.StartCopyFromBlobAsync(TestHelper.Defiddler(blobAsciiSource));
                await WaitForCopyAsync(blobAsciiDest);

                CloudBlockBlob blobUnicodeDest = container.GetBlockBlobReference(_unicodeBlobName + "_copy");
                copyId = await blobUnicodeDest.StartCopyFromBlobAsync(TestHelper.Defiddler(blobUnicodeSource));
                await WaitForCopyAsync(blobUnicodeDest);

                Assert.AreEqual(CopyStatus.Success, blobUnicodeDest.CopyState.Status);
                Assert.AreEqual(blobUnicodeSource.Uri.AbsolutePath, blobUnicodeDest.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, blobUnicodeDest.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, blobUnicodeDest.CopyState.BytesCopied);
                Assert.AreEqual(copyId, blobUnicodeDest.CopyState.CopyId);
                Assert.IsTrue(blobUnicodeDest.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
        
        [TestMethod]
        /// [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobCopyTestAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                string copyId = await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                OperationContext opContext = new OperationContext();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await copy.AbortCopyAsync(copyId, null, null, opContext),
                    opContext,
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                await source.FetchAttributesAsync();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = await DownloadTextAsync(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobCopyTestWithMetadataOverrideAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                copy.Metadata["Test2"] = "value2";
                string copyId = await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = await DownloadTextAsync(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                await source.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value2", copy.Metadata["Test2"], false, "Copied metadata not same");
                Assert.IsFalse(copy.Metadata.ContainsKey("Test"), "Source Metadata should not appear in destination blob");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobCopyFromSnapshotTestAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudBlockBlob snapshot = await source.CreateSnapshotAsync();

                //Modify source
                string newData = "Hello";
                source.Metadata["Test"] = "newvalue";
                await source.SetMetadataAsync();
                source.Properties.ContentMD5 = null;
                await UploadTextAsync(source, newData, Encoding.UTF8);

                Assert.AreEqual(newData, await DownloadTextAsync(source, Encoding.UTF8), "Source is modified correctly");
                Assert.AreEqual(data, await DownloadTextAsync(snapshot, Encoding.UTF8), "Modifying source blob should not modify snapshot");

                await source.FetchAttributesAsync();
                await snapshot.FetchAttributesAsync();
                Assert.AreNotEqual(source.Metadata["Test"], snapshot.Metadata["Test"], "Source and snapshot metadata should be independent");

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(snapshot));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(data, await DownloadTextAsync(copy, Encoding.UTF8), "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = snapshot.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobCopyTestAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                string copyId = await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                OperationContext opContext = new OperationContext();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await copy.AbortCopyAsync(copyId, null, null, opContext),
                    opContext,
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                await source.FetchAttributesAsync();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = await DownloadTextAsync(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobCopyTestWithMetadataOverrideAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                copy.Metadata["Test2"] = "value2";
                string copyId = await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = await DownloadTextAsync(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                await source.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value2", copy.Metadata["Test2"], false, "Copied metadata not same");
                Assert.IsFalse(copy.Metadata.ContainsKey("Test"), "Source Metadata should not appear in destination blob");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobCopyFromSnapshotTestAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                await UploadTextAsync(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                await source.SetMetadataAsync();

                CloudPageBlob snapshot = await source.CreateSnapshotAsync();

                //Modify source
                string newData = new string('b', 512);
                source.Metadata["Test"] = "newvalue";
                await source.SetMetadataAsync();
                source.Properties.ContentMD5 = null;
                await UploadTextAsync(source, newData, Encoding.UTF8);

                Assert.AreEqual(newData, await DownloadTextAsync(source, Encoding.UTF8), "Source is modified correctly");
                Assert.AreEqual(data, await DownloadTextAsync(snapshot, Encoding.UTF8), "Modifying source blob should not modify snapshot");

                await source.FetchAttributesAsync();
                await snapshot.FetchAttributesAsync();
                Assert.AreNotEqual(source.Metadata["Test"], snapshot.Metadata["Test"], "Source and snapshot metadata should be independent");

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                await copy.StartCopyFromBlobAsync(TestHelper.Defiddler(snapshot));
                await WaitForCopyAsync(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(data, await DownloadTextAsync(copy, Encoding.UTF8), "Data inside copy of blob not similar");

                await copy.FetchAttributesAsync();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = snapshot.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                await copy.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}
