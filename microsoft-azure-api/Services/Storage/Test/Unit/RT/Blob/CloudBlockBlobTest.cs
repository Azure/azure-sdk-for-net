// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlockBlobTest.cs" company="Microsoft">
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlockBlobTest : BlobTestBase
    {
        private static async Task CreateForTestAsync(CloudBlockBlob blob, int blockCount, int blockSize, bool commit = true)
        {
            byte[] buffer = GetRandomBuffer(blockSize);
            List<string> blocks = GetBlockIdList(blockCount);

            foreach (string block in blocks)
            {
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await blob.PutBlockAsync(block, stream.AsInputStream(), null);
                }
            }

            if (commit)
            {
                await blob.PutBlockListAsync(blocks);
            }
        }

        [TestMethod]
        /// [Description("Create a zero-length block blob and then delete it")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobCreateAndDeleteAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 0, 0);
                Assert.IsTrue(await blob.ExistsAsync());
                await blob.DeleteAsync();
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Try to delete a non-existing block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDeleteIfExistsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                Assert.IsFalse(await blob.DeleteIfExistsAsync());
                await CreateForTestAsync(blob, 0, 0);
                Assert.IsTrue(await blob.DeleteIfExistsAsync());
                Assert.IsFalse(await blob.DeleteIfExistsAsync());
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Verify the attributes of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobFetchAttributesAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 1, 1024);
                Assert.AreEqual(0, blob.Properties.Length);
                Assert.IsNotNull(blob.Properties.ETag);
                Assert.IsTrue(blob.Properties.LastModified > DateTimeOffset.UtcNow.AddMinutes(-5));
                Assert.IsNull(blob.Properties.CacheControl);
                Assert.IsNull(blob.Properties.ContentEncoding);
                Assert.IsNull(blob.Properties.ContentLanguage);
                Assert.IsNull(blob.Properties.ContentType);
                Assert.IsNull(blob.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unspecified, blob.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob.Properties.BlobType);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                await blob2.FetchAttributesAsync();
                Assert.AreEqual(1024, blob2.Properties.Length);
                Assert.AreEqual(blob.Properties.ETag, blob2.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, blob2.Properties.LastModified);
                Assert.IsNull(blob2.Properties.CacheControl);
                Assert.IsNull(blob2.Properties.ContentEncoding);
                Assert.IsNull(blob2.Properties.ContentLanguage);
                Assert.AreEqual("application/octet-stream", blob2.Properties.ContentType);
                Assert.IsNull(blob2.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unlocked, blob2.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob2.Properties.BlobType);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Verify setting the properties of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobSetPropertiesAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 1, 1024);
                string eTag = blob.Properties.ETag;
                DateTimeOffset lastModified = blob.Properties.LastModified.Value;

                await Task.Delay(1000);

                blob.Properties.CacheControl = "no-transform";
                blob.Properties.ContentEncoding = "gzip";
                blob.Properties.ContentLanguage = "tr,en";
                blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                blob.Properties.ContentType = "text/html";
                await blob.SetPropertiesAsync();
                Assert.IsTrue(blob.Properties.LastModified > lastModified);
                Assert.AreNotEqual(eTag, blob.Properties.ETag);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                await blob2.FetchAttributesAsync();
                Assert.AreEqual("no-transform", blob2.Properties.CacheControl);
                Assert.AreEqual("gzip", blob2.Properties.ContentEncoding);
                Assert.AreEqual("tr,en", blob2.Properties.ContentLanguage);
                Assert.AreEqual("MDAwMDAwMDA=", blob2.Properties.ContentMD5);
                Assert.AreEqual("text/html", blob2.Properties.ContentType);

                CloudBlockBlob blob3 = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        DisableContentMD5Validation = true,
                    };
                    await blob3.DownloadToStreamAsync(stream.AsOutputStream(), null, options, null);
                }
                AssertAreEqual(blob2.Properties, blob3.Properties);

                BlobResultSegment results = await container.ListBlobsSegmentedAsync(null);
                CloudBlockBlob blob4 = (CloudBlockBlob)results.Results.First();
                AssertAreEqual(blob2.Properties, blob4.Properties);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Try retrieving properties of a block blob using a page blob reference")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobFetchAttributesInvalidTypeAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 1, 1024);

                CloudPageBlob blob2 = container.GetPageBlobReference("blob1");
                OperationContext operationContext = new OperationContext();

                Assert.ThrowsException<AggregateException>(
                    () => blob2.FetchAttributesAsync(null, null, operationContext).AsTask().Wait(),
                    "Fetching attributes of a block blob using a page blob reference should fail");
                Assert.IsInstanceOfType(operationContext.LastResult.Exception.InnerException, typeof(InvalidOperationException));
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Verify that creating a block blob can also set its metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobCreateWithMetadataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.Metadata["key1"] = "value1";
                await CreateForTestAsync(blob, 0, 0);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                await blob2.FetchAttributesAsync();
                Assert.AreEqual(1, blob2.Metadata.Count);
                Assert.AreEqual("value1", blob2.Metadata["key1"]);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Verify that a block blob's metadata can be updated")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobSetMetadataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 0, 0);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                await blob2.FetchAttributesAsync();
                Assert.AreEqual(0, blob2.Metadata.Count);

                OperationContext operationContext = new OperationContext();
                blob.Metadata["key1"] = null;

                Assert.ThrowsException<AggregateException>(
                    () => blob.SetMetadataAsync(null, null, operationContext).AsTask().Wait(),
                    "Metadata keys should have a non-null value");
                Assert.IsInstanceOfType(operationContext.LastResult.Exception.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "";
                Assert.ThrowsException<AggregateException>(
                    () => blob.SetMetadataAsync(null, null, operationContext).AsTask().Wait(),
                    "Metadata keys should have a non-empty value");
                Assert.IsInstanceOfType(operationContext.LastResult.Exception.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "value1";
                await blob.SetMetadataAsync();

                await blob2.FetchAttributesAsync();
                Assert.AreEqual(1, blob2.Metadata.Count);
                Assert.AreEqual("value1", blob2.Metadata["key1"]);

                BlobResultSegment results = await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.Metadata, null, null, null, null);
                CloudBlockBlob blob3 = (CloudBlockBlob)results.Results.First();
                Assert.AreEqual(1, blob3.Metadata.Count);
                Assert.AreEqual("value1", blob3.Metadata["key1"]);

                blob.Metadata.Clear();
                await blob.SetMetadataAsync();

                await blob2.FetchAttributesAsync();
                Assert.AreEqual(0, blob2.Metadata.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload blocks and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadAsync()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                    foreach (string block in blocks)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(buffer))
                        {
                            await blob.PutBlockAsync(block, memoryStream.AsInputStream(), null);
                        }
                        wholeBlob.Write(buffer, 0, buffer.Length);
                    }
                    foreach (string block in extraBlocks)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(buffer))
                        {
                            await blob.PutBlockAsync(block, memoryStream.AsInputStream(), null);
                        }
                    }

                    await blob.PutBlockListAsync(blocks);

                    CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob2.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a block blob and then verify the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadBlockListAsync()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                foreach (string block in blocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        await blob.PutBlockAsync(block, memoryStream.AsInputStream(), null);
                    }
                }
                await blob.PutBlockListAsync(blocks);

                foreach (string block in extraBlocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        await blob.PutBlockAsync(block, memoryStream.AsInputStream(), null);
                    }
                }

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                await blob2.FetchAttributesAsync();
                Assert.AreEqual(1024 * blocks.Count, blob2.Properties.Length);

                IEnumerable<ListBlockItem> blockList = await blob2.DownloadBlockListAsync();
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsTrue(blockItem.Committed);
                    Assert.IsTrue(blocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, blocks.Count);
                
                blockList = await blob2.DownloadBlockListAsync(BlockListingFilter.Uncommitted, null, null, null);
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsFalse(blockItem.Committed);
                    Assert.IsTrue(extraBlocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, extraBlocks.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Put blob in blocks and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadFromStreamInBlocksAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.ServiceClient.SingleBlobUploadThresholdInBytes = 1 * 1024 * 1024;
                blob.StreamWriteSizeInBytes = 512 * 1024;
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(originalBlob.AsInputStream());

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadFromStreamWithNonSeekableStreamAsync()
        {
            await this.CloudBlockBlobUploadFromStreamAsync(false, 0);
            await this.CloudBlockBlobUploadFromStreamAsync(false, 1024);
        }

        [TestMethod]
        /// [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadFromStreamAsync()
        {
            await this.CloudBlockBlobUploadFromStreamAsync(true, 0);
            await this.CloudBlockBlobUploadFromStreamAsync(true, 1024);
        }

        private async Task CloudBlockBlobUploadFromStreamAsync(bool seekableSourceStream, int startOffset)
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);

            CryptographicHash hasher = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
            hasher.Append(buffer.AsBuffer(startOffset, buffer.Length - startOffset));
            string md5 = CryptographicBuffer.EncodeToBase64String(hasher.GetValueAndReset());

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                using (MemoryStream originalBlob = new MemoryStream())
                {
                    originalBlob.Write(buffer, startOffset, buffer.Length - startOffset);

                    Stream sourceStream;
                    if (seekableSourceStream)
                    {
                        MemoryStream stream = new MemoryStream(buffer);
                        stream.Seek(startOffset, SeekOrigin.Begin);
                        sourceStream = stream;
                    }
                    else
                    {
                        NonSeekableMemoryStream stream = new NonSeekableMemoryStream(buffer);
                        stream.ForceSeek(startOffset, SeekOrigin.Begin);
                        sourceStream = stream;
                    }

                    using (sourceStream)
                    {
                        BlobRequestOptions options = new BlobRequestOptions()
                        {
                            StoreBlobContentMD5 = true,
                        };
                        await blob.UploadFromStreamAsync(sourceStream.AsInputStream(), null, options, null);
                    }

                    await blob.FetchAttributesAsync();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Create snapshots of a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobSnapshotAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 2, 1024);

                CloudBlockBlob snapshot1 = await blob.CreateSnapshotAsync();
                Assert.AreEqual(blob.Properties.ETag, snapshot1.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, snapshot1.Properties.LastModified);

                Assert.IsNotNull(snapshot1.SnapshotTime, "Snapshot does not have SnapshotTime set");

                CloudBlockBlob snapshot2 = await blob.CreateSnapshotAsync();
                Assert.IsTrue(snapshot2.SnapshotTime.Value > snapshot1.SnapshotTime.Value);

                await snapshot1.FetchAttributesAsync();
                await snapshot2.FetchAttributesAsync();
                await blob.FetchAttributesAsync();
                AssertAreEqual(snapshot1.Properties, blob.Properties);

                CloudBlockBlob snapshotCopy = container.GetBlockBlobReference("blob2");
                await snapshotCopy.StartCopyFromBlobAsync(TestHelper.Defiddler(snapshot1.Uri));
                await WaitForCopyAsync(snapshotCopy);
                Assert.AreEqual(CopyStatus.Success, snapshotCopy.CopyState.Status);

                await TestHelper.ExpectedExceptionAsync<InvalidOperationException>(
                    async () => await snapshot1.OpenWriteAsync(),
                    "Trying to write to a blob snapshot should fail");

                BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All, null, null, null, null);
                List<IListBlobItem> blobs = resultSegment.Results.ToList();
                Assert.AreEqual(4, blobs.Count);
                AssertAreEqual(snapshot1, (ICloudBlob)blobs[0]);
                AssertAreEqual(snapshot2, (ICloudBlob)blobs[1]);
                AssertAreEqual(blob, (ICloudBlob)blobs[2]);
                AssertAreEqual(snapshotCopy, (ICloudBlob)blobs[3]);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Create a snapshot with explicit metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobSnapshotMetadataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 2, 1024);

                blob.Metadata["Hello"] = "World";
                blob.Metadata["Marco"] = "Polo";
                await blob.SetMetadataAsync();

                IDictionary<string, string> snapshotMetadata = new Dictionary<string, string>();
                snapshotMetadata["Hello"] = "Dolly";
                snapshotMetadata["Yoyo"] = "Ma";

                CloudBlockBlob snapshot = await blob.CreateSnapshotAsync(snapshotMetadata, null, null, null);

                // Test the client view against the expected metadata
                // None of the original metadata should be present
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));

                // Test the server view against the expected metadata
                await snapshot.FetchAttributesAsync();
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test conditional access on a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobConditionalAccessAsync()
        {
            OperationContext operationContext = new OperationContext();
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                await CreateForTestAsync(blob, 2, 1024);
                await blob.FetchAttributesAsync();

                string currentETag = blob.Properties.ETag;
                DateTimeOffset currentModifiedTime = blob.Properties.LastModified.Value;

                // ETag conditional tests
                blob.Metadata["ETagConditionalName"] = "ETagConditionalValue";
                await blob.SetMetadataAsync(AccessCondition.GenerateIfMatchCondition(currentETag), null, null);

                await blob.FetchAttributesAsync();
                string newETag = blob.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");

                blob.Metadata["ETagConditionalName"] = "ETagConditionalValue2";

                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfNoneMatchCondition(newETag), null, operationContext),
                    operationContext,
                    "If none match on conditional test should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                string invalidETag = "\"0x10101010\"";
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfMatchCondition(invalidETag), null, operationContext),
                    operationContext,
                    "Invalid ETag on conditional test should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                currentETag = blob.Properties.ETag;
                await blob.SetMetadataAsync(AccessCondition.GenerateIfNoneMatchCondition(invalidETag), null, null);

                await blob.FetchAttributesAsync();
                newETag = blob.Properties.ETag;

                // LastModifiedTime tests
                currentModifiedTime = blob.Properties.LastModified.Value;

                blob.Metadata["DateConditionalName"] = "DateConditionalValue";

                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(currentModifiedTime), null, operationContext),
                    operationContext,
                    "IfModifiedSince conditional on current modified time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                DateTimeOffset pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                await blob.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                await blob.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                await blob.SetMetadataAsync(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null, null);

                currentModifiedTime = blob.Properties.LastModified.Value;

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null, operationContext),
                    operationContext,
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null, operationContext),
                    operationContext,
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.SetMetadataAsync(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null, operationContext),
                    operationContext,
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                blob.Metadata["DateConditionalName"] = "DateConditionalValue2";

                currentETag = blob.Properties.ETag;
                await blob.SetMetadataAsync(AccessCondition.GenerateIfNotModifiedSinceCondition(currentModifiedTime), null, null);

                await blob.FetchAttributesAsync();
                newETag = blob.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Put block boundaries")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobPutBlockBoundariesAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                string blockId = GetBlockIdList(1).First();

                OperationContext operationContext = new OperationContext();
                byte[] buffer = new byte[0];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blob.PutBlockAsync(blockId, stream.AsInputStream(), null, null, null, operationContext),
                        operationContext,
                        "Trying to upload a block with zero bytes should fail",
                        HttpStatusCode.BadRequest);
                }

                buffer = new byte[1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await blob.PutBlockAsync(blockId, stream.AsInputStream(), null);
                }

                buffer = new byte[4 * 1024 * 1024];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await blob.PutBlockAsync(blockId, stream.AsInputStream(), null);
                }

                buffer = new byte[4 * 1024 * 1024 + 1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blob.PutBlockAsync(blockId, stream.AsInputStream(), null, null, null, operationContext),
                        operationContext,
                        "Trying to upload a block with more than 4MB should fail",
                        HttpStatusCode.RequestEntityTooLarge);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload blocks and then verify the contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobPutBlockAsync()
        {
            byte[] buffer = GetRandomBuffer(4 * 1024 * 1024);
            CryptographicHash hasher = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
            hasher.Append(buffer.AsBuffer());
            string contentMD5 = CryptographicBuffer.EncodeToBase64String(hasher.GetValueAndReset());

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                List<string> blockList = GetBlockIdList(2);

                using (MemoryStream resultingData = new MemoryStream())
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await blob.PutBlockAsync(blockList[0], memoryStream.AsInputStream(), contentMD5);
                        resultingData.Write(buffer, 0, buffer.Length);

                        int offset = buffer.Length - 1024;
                        memoryStream.Seek(offset, SeekOrigin.Begin);
                        OperationContext opContext = new OperationContext();
                        await TestHelper.ExpectedExceptionAsync(
                            async () => await blob.PutBlockAsync(blockList[1], memoryStream.AsInputStream(), contentMD5, null, null, opContext),
                            opContext,
                            "Invalid MD5 should fail with mismatch",
                            HttpStatusCode.BadRequest,
                            "Md5Mismatch");

                        memoryStream.Seek(offset, SeekOrigin.Begin);
                        await blob.PutBlockAsync(blockList[1], memoryStream.AsInputStream(), null);
                        resultingData.Write(buffer, offset, buffer.Length - offset);
                    }

                    await blob.PutBlockListAsync(blockList);

                    using (MemoryStream blobData = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(blobData.AsOutputStream());
                        Assert.AreEqual(resultingData.Length, blobData.Length);

                        Assert.IsTrue(blobData.ToArray().SequenceEqual(resultingData.ToArray()));
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test block blob methods on a page blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobMethodsOnPageBlobAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                List<string> blobs = await CreateBlobsAsync(container, 1, BlobType.PageBlob);
                CloudBlockBlob blob = container.GetBlockBlobReference(blobs.First());
                List<string> blockList = GetBlockIdList(1);

                OperationContext operationContext = new OperationContext();
                byte[] buffer = new byte[1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blob.PutBlockAsync(blockList.First(), stream.AsInputStream(), null, null, null, operationContext),
                        operationContext,
                        "Block operations should fail on page blobs",
                        HttpStatusCode.Conflict,
                        "InvalidBlobType");
                }

                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.PutBlockListAsync(blockList, null, null, operationContext),
                    operationContext,
                    "Block operations should fail on page blobs",
                    HttpStatusCode.Conflict,
                    "InvalidBlobType");

                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.DownloadBlockListAsync(BlockListingFilter.Committed, null, null, operationContext),
                    operationContext,
                    "Block operations should fail on page blobs",
                    HttpStatusCode.Conflict,
                    "InvalidBlobType");
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test block removal/addition/reordering in a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobBlockReorderingAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                List<string> originalBlockIds = GetBlockIdList(10);
                List<string> blockIds = new List<string>(originalBlockIds);
                List<byte[]> blocks = new List<byte[]>();
                for (int i = 0; i < blockIds.Count; i++)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(i.ToString());
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        await blob.PutBlockAsync(blockIds[i], stream.AsInputStream(), null);
                    }
                    blocks.Add(buffer);
                }
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("0123456789", await DownloadTextAsync(blob, Encoding.UTF8));

                blockIds.RemoveAt(0);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("123456789", await DownloadTextAsync(blob, Encoding.UTF8));

                blockIds.RemoveAt(8);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("12345678", await DownloadTextAsync(blob, Encoding.UTF8));

                blockIds.RemoveAt(3);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("1235678", await DownloadTextAsync(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[9]))
                {
                    await blob.PutBlockAsync(originalBlockIds[9], stream.AsInputStream(), null);
                }
                blockIds.Insert(0, originalBlockIds[9]);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("91235678", await DownloadTextAsync(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[0]))
                {
                    await blob.PutBlockAsync(originalBlockIds[0], stream.AsInputStream(), null);
                }
                blockIds.Add(originalBlockIds[0]);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("912356780", await DownloadTextAsync(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[4]))
                {
                    await blob.PutBlockAsync(originalBlockIds[4], stream.AsInputStream(), null);
                }
                blockIds.Insert(2, originalBlockIds[4]);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("9142356780", await DownloadTextAsync(blob, Encoding.UTF8));

                blockIds.Insert(0, originalBlockIds[0]);
                await blob.PutBlockListAsync(blockIds);
                Assert.AreEqual("09142356780", await DownloadTextAsync(blob, Encoding.UTF8));
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload and download null/empty data")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadDownloadNoDataAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob");
                await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                    async () => await blob.UploadFromStreamAsync(null),
                    "Uploading from a null stream should fail");

                using (MemoryStream stream = new MemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream());
                }

                await TestHelper.ExpectedExceptionAsync<ArgumentNullException>(
                    async () => await blob.DownloadToStreamAsync(null),
                    "Downloading to a null stream should fail");

                using (MemoryStream stream = new MemoryStream())
                {
                    await blob.DownloadToStreamAsync(stream.AsOutputStream());
                    Assert.AreEqual(0, stream.Length);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("List committed and uncommitted blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobListUncommittedBlobsAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                List<string> committedBlobs = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    string name = "cblob" + i.ToString();
                    CloudBlockBlob committedBlob = container.GetBlockBlobReference(name);
                    await CreateForTestAsync(committedBlob, 2, 1024);
                    committedBlobs.Add(name);
                }

                List<string> uncommittedBlobs = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    string name = "ucblob" + i.ToString();
                    CloudBlockBlob uncommittedBlob = container.GetBlockBlobReference(name);
                    await CreateForTestAsync(uncommittedBlob, 2, 1024, false);
                    uncommittedBlobs.Add(name);
                }

                BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.UncommittedBlobs, null, null, null, null);
                List<IListBlobItem> blobs = resultSegment.Results.ToList();
                foreach (ICloudBlob blob in blobs)
                {
                    if (committedBlobs.Remove(blob.Name))
                    {
                        Assert.AreEqual(2 * 1024, blob.Properties.Length);
                    }
                    else if (uncommittedBlobs.Remove(blob.Name))
                    {
                        Assert.AreEqual(0, blob.Properties.Length);
                    }
                    else
                    {
                        Assert.Fail("Blob is not found in either committed or uncommitted list");
                    }
                }

                Assert.AreEqual(0, committedBlobs.Count);
                Assert.AreEqual(0, uncommittedBlobs.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}
