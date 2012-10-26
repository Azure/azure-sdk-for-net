// -----------------------------------------------------------------------------------------
// <copyright file="BlobWriteStreamTest.cs" company="Microsoft">
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
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobWriteStreamTest : BlobTestBase
    {
        [TestMethod]
        /// [Description("Create blobs using blob stream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobWriteStreamOpenAndCloseAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                using (IOutputStream writeStream = await blockBlob.OpenWriteAsync())
                {
                }

                CloudBlockBlob blockBlob2 = container.GetBlockBlobReference("blob1");
                await blockBlob2.FetchAttributesAsync();
                Assert.AreEqual(0, blockBlob2.Properties.Length);
                Assert.AreEqual(BlobType.BlockBlob, blockBlob2.Properties.BlobType);

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                OperationContext opContext = new OperationContext();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await pageBlob.OpenWriteAsync(null, null, null, opContext),
                    opContext,
                    "Opening a page blob stream with no size should fail on a blob that does not exist",
                    HttpStatusCode.NotFound);
                using (IOutputStream writeStream = await pageBlob.OpenWriteAsync(1024))
                {
                }
                using (IOutputStream writeStream = await pageBlob.OpenWriteAsync(null))
                {
                }

                CloudPageBlob pageBlob2 = container.GetPageBlobReference("blob2");
                await pageBlob2.FetchAttributesAsync();
                Assert.AreEqual(1024, pageBlob2.Properties.Length);
                Assert.AreEqual(BlobType.PageBlob, pageBlob2.Properties.BlobType);
            }
            finally
            {
                container.DeleteAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobWriteStreamBasicTestAsync()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);

            CryptographicHash hasher = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.ParallelOperationThreadCount = 2;
            string name = GetRandomContainerName();
            CloudBlobContainer container = blobClient.GetContainerReference(name);
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    using (IOutputStream writeStream = await blob.OpenWriteAsync(null, options, null))
                    {
                        Stream blobStream = writeStream.AsStreamForWrite();
                        for (int i = 0; i < 3; i++)
                        {
                            await blobStream.WriteAsync(buffer, 0, buffer.Length);
                            await wholeBlob.WriteAsync(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                            hasher.Append(buffer.AsBuffer());
                        }
                    }

                    string md5 = CryptographicBuffer.EncodeToBase64String(hasher.GetValueAndReset());
                    await blob.FetchAttributesAsync();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobWriteStreamSeekTestAsync()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (IOutputStream writeStream = await blob.OpenWriteAsync())
                {
                    Stream blobStream = writeStream.AsStreamForWrite();
                    TestHelper.ExpectedException<NotSupportedException>(
                        () => blobStream.Seek(1, SeekOrigin.Begin),
                        "Block blob write stream should not be seekable");
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobWriteStreamBasicTestAsync()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);

            CryptographicHash hasher = HashAlgorithmProvider.OpenAlgorithm("MD5").CreateHash();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.ParallelOperationThreadCount = 2;
            string name = GetRandomContainerName();
            CloudBlobContainer container = blobClient.GetContainerReference(name);
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    using (IOutputStream writeStream = await blob.OpenWriteAsync(buffer.Length * 3, null, options, null))
                    {
                        Stream blobStream = writeStream.AsStreamForWrite();
                        for (int i = 0; i < 3; i++)
                        {
                            await blobStream.WriteAsync(buffer, 0, buffer.Length);
                            await wholeBlob.WriteAsync(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                            hasher.Append(buffer.AsBuffer());
                        }
                    }

                    string md5 = CryptographicBuffer.EncodeToBase64String(hasher.GetValueAndReset());
                    await blob.FetchAttributesAsync();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobWriteStreamRandomSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);

            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    using (IOutputStream writeStream = await blob.OpenWriteAsync(buffer.Length))
                    {
                        Stream blobStream = writeStream.AsStreamForWrite();
                        TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                            () => blobStream.Seek(1, SeekOrigin.Begin),
                            "Page blob stream should not allow unaligned seeks");

                        await blobStream.WriteAsync(buffer, 0, buffer.Length);
                        await wholeBlob.WriteAsync(buffer, 0, buffer.Length);
                        Random random = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            int offset = random.Next(buffer.Length / 512) * 512;
                            SeekRandomly(blobStream, offset);
                            await blobStream.WriteAsync(buffer, 0, buffer.Length - offset);
                            wholeBlob.Seek(offset, SeekOrigin.Begin);
                            await wholeBlob.WriteAsync(buffer, 0, buffer.Length - offset);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.End);
                    await blob.FetchAttributesAsync();
                    Assert.IsNull(blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        await blob.DownloadToStreamAsync(downloadedBlob.AsOutputStream());
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}
