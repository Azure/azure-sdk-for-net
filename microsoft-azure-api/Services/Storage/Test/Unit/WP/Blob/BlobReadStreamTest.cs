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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobReadStreamTest : BlobTestBase
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
        [Description("Create a service client with URI and credentials")]
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
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    using (Stream blobStream = await blob.OpenReadAsync())
                    {
                        await TestHelper.AssertStreamsAreEqualAsync(wholeBlob, blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Download a blob using CloudBlobStream")]
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
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    Stream readStream = await blob.OpenReadAsync();
                    using (Stream blobStream = readStream)
                    {
                        TestHelper.AssertStreamsAreEqual(wholeBlob, blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
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
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream;
                    await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length);
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream;
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
                await blob.SetMetadataAsync();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.OpenReadAsync(accessCondition, null, opContext),
                    opContext,
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
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
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream;
                    await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length);
                    await blob.SetMetadataAsync();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blobStreamForRead.ReadAsync(outBuffer, 0, outBuffer.Length),
                        opContext,
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    Stream blobStreamForRead = blobStream;
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
                await blob.SetMetadataAsync();
                await TestHelper.ExpectedExceptionAsync(
                    async () => await blob.OpenReadAsync(accessCondition, null, opContext),
                    opContext,
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        private static async Task<int> BlobReadStreamSeekAndCompareAsync(Stream blobStream, byte[] bufferToCompare, long offset, int readSize, int expectedReadCount)
        {
            byte[] testBuffer = new byte[readSize];

            int readCount = await blobStream.ReadAsync(testBuffer, 0, readSize);
            Assert.AreEqual(expectedReadCount, readCount);

            for (int i = 0; i < expectedReadCount; i++)
            {
                Assert.AreEqual(bufferToCompare[i + offset], testBuffer[i]);
            }

            return expectedReadCount;
        }

        private static async Task<int> BlobReadStreamSeekTestAsync(Stream blobStream, long streamReadSize, byte[] bufferToCompare)
        {
            int attempts = 1;
            long position = 0;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 1024);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 512, 512);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-128, SeekOrigin.End);
            position = bufferToCompare.Length - 128;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 128);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(4096, SeekOrigin.Begin);
            position = 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 1024);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(4096, SeekOrigin.Current);
            position += 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 1024);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-4096, SeekOrigin.Current);
            position -= 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 128, 128);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(streamReadSize + 4096 - 512, SeekOrigin.Begin);
            position = streamReadSize + 4096 - 512;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 512);
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 1024);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-1024, SeekOrigin.Current);
            position -= 1024;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 2048, 2048);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-128, SeekOrigin.End);
            position = bufferToCompare.Length - 128;
            Assert.AreEqual(position, blobStream.Position);
            position += await BlobReadStreamSeekAndCompareAsync(blobStream, bufferToCompare, position, 1024, 128);
            Assert.AreEqual(position, blobStream.Position);
            return attempts;
        }

        [TestMethod]
        [Description("Seek and read in a CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlockBlobReadStreamSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = 2 * 1024 * 1024;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    int attempts = await BlobReadStreamSeekTestAsync(blobStream, blob.StreamMinimumReadSizeInBytes, buffer);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Seek and read in a CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobReadStreamSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = 2 * 1024 * 1024;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = await blob.OpenReadAsync(null, null, opContext))
                {
                    int attempts = await BlobReadStreamSeekTestAsync(blobStream, blob.StreamMinimumReadSizeInBytes, buffer);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
    }
}
