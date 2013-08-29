// -----------------------------------------------------------------------------------------
// <copyright file="BlobUploadDownloadTest.cs" company="Microsoft">
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
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobUploadDownloadTest : BlobTestBase
    {
        private CloudBlobContainer testContainer;

        [TestInitialize]
        public async Task TestInitialize()
        {
            this.testContainer = GetRandomContainerReference();
            await this.testContainer.CreateIfNotExistsAsync();
            
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            await this.testContainer.DeleteIfExistsAsync();
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        [Description("Download a specific range of the blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobDownloadToStreamRangeTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            using (MemoryStream wholeBlob = new MemoryStream(buffer))
            {
                await blob.UploadFromStreamAsync(wholeBlob);

                byte[] testBuffer = new byte[1024];
                MemoryStream blobStream = new MemoryStream(testBuffer);
                Exception ex = await TestHelper.ExpectedExceptionAsync<Exception>(
                    async () => await blob.DownloadRangeToStreamAsync(blobStream, 0, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
                await blob.DownloadRangeToStreamAsync(blobStream, 0, 1024);
                Assert.AreEqual(blobStream.Position, 1024);
                TestHelper.AssertStreamsAreEqualAtIndex(blobStream, wholeBlob, 0, 0, 1024);

                CloudPageBlob blob2 = this.testContainer.GetPageBlobReference("blob1");
                MemoryStream blobStream2 = new MemoryStream(testBuffer);
                ex = await TestHelper.ExpectedExceptionAsync<Exception>(
                    async () => await blob2.DownloadRangeToStreamAsync(blobStream, 1024, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
                await blob2.DownloadRangeToStreamAsync(blobStream2, 1024, 1024);
                TestHelper.AssertStreamsAreEqualAtIndex(blobStream2, wholeBlob, 0, 1024, 1024);

                AssertAreEqual(blob, blob2);
            }
        }

        [TestMethod]
        [Description("Upload a stream to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobUploadFromStreamTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            using (MemoryStream srcStream = new MemoryStream(buffer))
            {
                await blob.UploadFromStreamAsync(srcStream);
                byte[] testBuffer = new byte[2048];
                MemoryStream dstStream = new MemoryStream(testBuffer);
                await blob.DownloadRangeToStreamAsync(dstStream, null, null);
                TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
            }
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadDownloadFileAsync()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoUploadDownloadFileAsync(blob, 0);
            await this.DoUploadDownloadFileAsync(blob, 4096);
            await this.DoUploadDownloadFileAsync(blob, 4097);
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobUploadDownloadFileAsync()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoUploadDownloadFileAsync(blob, 0);
            await this.DoUploadDownloadFileAsync(blob, 4096);

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await this.DoUploadDownloadFileAsync(blob, 4097),
                "Page blobs must be 512-byte aligned");
        }

        private async Task DoUploadDownloadFileAsync(ICloudBlob blob, int fileSize)
        {
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();

            try
            {
                byte[] buffer = GetRandomBuffer(fileSize);
                using (FileStream file = new FileStream(inputFileName, FileMode.Create, FileAccess.Write))
                {
                    await file.WriteAsync(buffer, 0, buffer.Length);
                }

                await blob.UploadFromFileAsync(inputFileName, FileMode.Open);

                OperationContext context = new OperationContext();
                await blob.UploadFromFileAsync(inputFileName, FileMode.Open, null, null, context);
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                await TestHelper.ExpectedExceptionAsync<IOException>(
                    async () => await blob.DownloadToFileAsync(outputFileName, FileMode.CreateNew),
                    "CreateNew on an existing file should fail");

                context = new OperationContext();
                await blob.DownloadToFileAsync(outputFileName, FileMode.Create, null, null, context);
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                using (
                    FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                               outputFileStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                {
                    await TestHelper.AssertStreamsAreEqualAsync(inputFileStream, outputFileStream);
                }

                await blob.DownloadToFileAsync(outputFileName, FileMode.Append);

                using (
                    FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                               outputFileStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                {
                    Assert.AreEqual(2 * fileSize, outputFileStream.Length);

                    for (int i = 0; i < fileSize; i++)
                    {
                        Assert.AreEqual(inputFileStream.ReadByte(), outputFileStream.ReadByte());
                    }

                    inputFileStream.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < fileSize; i++)
                    {
                        Assert.AreEqual(inputFileStream.ReadByte(), outputFileStream.ReadByte());
                    }
                }
            }
            finally
            {
                File.Delete(inputFileName);
                File.Delete(outputFileName);
            }
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobUploadFromByteArrayAsync()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 0, 4 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 0, 2 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 1 * 512, 2 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 2 * 512, 2 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 512, 0, 511);
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobUploadFromByteArrayAsync()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 0, 4 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 0, 2 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 1 * 512, 2 * 512);
            await this.DoUploadFromByteArrayTestAsync(blob, 4 * 512, 2 * 512, 2 * 512);

            await TestHelper.ExpectedExceptionAsync<ArgumentException>(
                async () => await this.DoUploadFromByteArrayTestAsync(blob, 512, 0, 511),
                "Page blobs must be 512-byte aligned");
        }

        private async Task DoUploadFromByteArrayTestAsync(ICloudBlob blob, int bufferSize, int bufferOffset, int count)
        {
            byte[] buffer = GetRandomBuffer(bufferSize);
            byte[] downloadedBuffer = new byte[bufferSize];
            int downloadLength;

            await blob.UploadFromByteArrayAsync(buffer, bufferOffset, count);
            downloadLength = await blob.DownloadToByteArrayAsync(downloadedBuffer, 0);

            Assert.AreEqual(count, downloadLength);

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(buffer[i + bufferOffset], downloadedBuffer[i]);
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadToByteArrayAsync()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 0, false);
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 1 * 512, false);
            await this.DoDownloadToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadToByteArrayAsyncOverload()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 0, true);
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 1 * 512, true);
            await this.DoDownloadToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, true);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobDownloadToByteArrayAsync()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 0, false);
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 1 * 512, false);
            await this.DoDownloadToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobDownloadToByteArrayAsyncOverload()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 0, true);
            await this.DoDownloadToByteArrayAsyncTest(blob, 1 * 512, 2 * 512, 1 * 512, true);
            await this.DoDownloadToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, true);
        }

        private async Task DoDownloadToByteArrayAsyncTest(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, bool isOverload)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                if (!isOverload)
                {
                    await blob.UploadFromStreamAsync(originalBlob);
                    downloadLength = await blob.DownloadToByteArrayAsync(resultBuffer, bufferOffset);
                }
                else
                {
                    await blob.UploadFromStreamAsync(originalBlob);
                    OperationContext context = new OperationContext();
                    downloadLength = await blob.DownloadToByteArrayAsync(resultBuffer, bufferOffset, null, null, context);
                }

                int downloadSize = Math.Min(blobSize, bufferSize - bufferOffset);
                Assert.AreEqual(downloadSize, downloadLength);

                for (int i = 0; i < blob.Properties.Length; i++)
                {
                    Assert.AreEqual(buffer[i], resultBuffer[bufferOffset + i]);
                }

                for (int j = 0; j < bufferOffset; j++)
                {
                    Assert.AreEqual(0, resultBuffer2[j]);
                }

                if (bufferOffset + blobSize < bufferSize)
                {
                    for (int k = bufferOffset + blobSize; k < bufferSize; k++)
                    {
                        Assert.AreEqual(0, resultBuffer2[k]);
                    }
                }
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadRangeToByteArrayAsync()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, null, null, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, false);

            // Edge cases
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 1023, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 0, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 512, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 0, 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadRangeToByteArrayAsyncOverload()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, null, null, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, true);

            // Edge cases
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 1023, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 0, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 512, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 0, 512, true);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobDownloadRangeToByteArrayAsync()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, null, null, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, false);

            // Edge cases
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 1023, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 0, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 512, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 1023, 1, false);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 0, 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobDownloadRangeToByteArrayAsyncOverload()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, null, null, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, true);

            // Edge cases
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 1023, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 0, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 0, 512, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 1023, 1, true);
            await this.DoDownloadRangeToByteArrayAsyncTest(blob, 1024, 1024, 512, 0, 512, true);
        }

        /// <summary>
        /// Single put blob and get blob.
        /// </summary>
        /// <param name="blobSize">The blob size.</param>
        /// <param name="bufferSize">The output buffer size.</param>
        /// <param name="bufferOffset">The output buffer offset.</param>
        /// <param name="blobOffset">The blob offset.</param>
        /// <param name="length">Length of the data range to download.</param>
        /// <param name="isOverload">True when the overloaded method for DownloadRangeToByteArrayAsync is called. False when the basic method is called.</param>
        private async Task DoDownloadRangeToByteArrayAsyncTest(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, long? blobOffset, long? length, bool isOverload)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                if (!isOverload)
                {
                    await blob.UploadFromStreamAsync(originalBlob);
                    downloadLength = await blob.DownloadRangeToByteArrayAsync(resultBuffer, bufferOffset, blobOffset, length);
                }
                else
                {
                    await blob.UploadFromStreamAsync(originalBlob);
                    OperationContext context = new OperationContext();
                    downloadLength = await blob.DownloadRangeToByteArrayAsync(resultBuffer, bufferOffset, blobOffset, length, null, null, context);
                }

                int downloadSize = Math.Min(blobSize - (int)(blobOffset.HasValue ? blobOffset.Value : 0), bufferSize - bufferOffset);
                if (length.HasValue && (length.Value < downloadSize))
                {
                    downloadSize = (int)length.Value;
                }

                Assert.AreEqual(downloadSize, downloadLength);

                for (int i = 0; i < bufferOffset; i++)
                {
                    Assert.AreEqual(0, resultBuffer[i]);
                }

                for (int j = 0; j < downloadLength; j++)
                {
                    Assert.AreEqual(buffer[(blobOffset.HasValue ? blobOffset.Value : 0) + j], resultBuffer[bufferOffset + j]);
                }

                for (int k = bufferOffset + downloadLength; k < bufferSize; k++)
                {
                    Assert.AreEqual(0, resultBuffer[k]);
                }
            }
        }

        #region Negative tests
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudBlockBlobDownloadRangeToByteArrayNegativeTestsAsync()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayNegativeTestsAsync(blob);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudPageBlobDownloadRangeToByteArrayNegativeTestsAsync()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            await this.DoDownloadRangeToByteArrayNegativeTestsAsync(blob);
        }

        private async Task DoDownloadRangeToByteArrayNegativeTestsAsync(ICloudBlob blob)
        {
            int blobLength = 1024;
            int resultBufSize = 1024;
            byte[] buffer = GetRandomBuffer(blobLength);
            byte[] resultBuffer = new byte[resultBufSize];

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                await blob.UploadFromStreamAsync(stream);

                OperationContext context = new OperationContext();
                await TestHelper.ExpectedExceptionAsync(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, 1024, 1, null, null, context), context, "Try invalid length", HttpStatusCode.RequestedRangeNotSatisfiable);
                StorageException ex = await TestHelper.ExpectedExceptionAsync<StorageException>(async () => await blob.DownloadToByteArrayAsync(resultBuffer, 1024), "Provide invalid offset");
                Assert.IsInstanceOfType(ex.InnerException, typeof(NotSupportedException));
                ex = await TestHelper.ExpectedExceptionAsync<StorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 1023, 0, 2), "Should fail when offset + length required is greater than size of the buffer");
                Assert.IsInstanceOfType(ex.InnerException, typeof(NotSupportedException));
                ex = await TestHelper.ExpectedExceptionAsync<StorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, 0, -10), "Fail when a negative length is specified");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
                await TestHelper.ExpectedExceptionAsync<ArgumentOutOfRangeException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, -10, 0, 20), "Fail if a negative offset is provided");
                ex = await TestHelper.ExpectedExceptionAsync<StorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, -10, 20), "Fail if a negative blob offset is provided");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
            }
        }
        #endregion
    }
}