// -----------------------------------------------------------------------------------------
// <copyright file="BlobReadStreamTest.cs" company="Microsoft">
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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobReadStreamTest : BlobTestBase
    {
        [TestMethod]
        /// [Description("Create a service client with URI and credentials")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobReadStreamBasicTestAsync()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    using (IInputStream blobStream = await blob.OpenReadAsync())
                    {
                        await TestHelper.AssertStreamsAreEqualAsync(wholeBlob.AsInputStream(), blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Download a blob using BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobReadStreamBasicTestAsync()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    wholeBlob.Seek(0, SeekOrigin.End);
                    IRandomAccessStreamWithContentType readStream = await blob.OpenReadAsync();
                    using (Stream blobStream = readStream.AsStreamForRead())
                    {
                        blobStream.Seek(0, SeekOrigin.End);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Modify a blob while downloading it using BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobReadLockToETagTestAsync()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                OperationContext opContext = new OperationContext();
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length);
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    long length = blobStreamForRead.Length;
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(accessCondition, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Modify a blob while downloading it using BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobReadLockToETagTestAsync()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                OperationContext opContext = new OperationContext();
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length);
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    long length = blobStreamForRead.Length;
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                using (IRandomAccessStreamWithContentType blobStream = await blob.OpenReadAsync(accessCondition, null, opContext))
                {
                    Stream blobStreamForRead = blobStream.AsStreamForRead();
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Randomly seek and read in a BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobReadStreamRandomSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                Random random = new Random();
                byte[] testBuffer = new byte[1024];
                using (IRandomAccessStreamWithContentType readStream = await blob.OpenReadAsync())
                {
                    Stream blobStream = readStream.AsStreamForRead();
                    for (int count = 0; count < 20; count++)
                    {
                        int newPosition = random.Next(buffer.Length - testBuffer.Length);
                        SeekRandomly(blobStream, newPosition);
                        int readSize = random.Next(1, testBuffer.Length);
                        int totalRead = blobStream.Read(testBuffer, 0, readSize);
                        Assert.IsTrue(totalRead > 0 && totalRead <= readSize, "BlobStream.Read returned " + totalRead + " bytes when we asked for " + readSize + " bytes");

                        for (int i = 0; i < totalRead; i++)
                        {
                            Assert.AreEqual(buffer[i + newPosition], testBuffer[i]);
                        }
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Randomly seek and read in a BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobReadStreamRandomSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());
                }

                Random random = new Random();
                byte[] testBuffer = new byte[1024];
                using (IRandomAccessStreamWithContentType readStream = await blob.OpenReadAsync())
                {
                    Stream blobStream = readStream.AsStreamForRead();
                    for (int count = 0; count < 20; count++)
                    {
                        int newPosition = random.Next(buffer.Length - testBuffer.Length);
                        SeekRandomly(blobStream, newPosition);
                        int readSize = random.Next(1, testBuffer.Length);
                        int totalRead = blobStream.Read(testBuffer, 0, readSize);
                        Assert.IsTrue(totalRead > 0 && totalRead <= readSize, "BlobStream.Read returned " + totalRead + " bytes when we asked for " + readSize + " bytes");

                        for (int i = 0; i < totalRead; i++)
                        {
                            Assert.AreEqual(buffer[i + newPosition], testBuffer[i]);
                        }
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
