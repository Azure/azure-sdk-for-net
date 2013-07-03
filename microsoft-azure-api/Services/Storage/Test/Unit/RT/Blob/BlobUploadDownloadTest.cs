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
using Windows.Storage;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobUploadDownloadTest : BlobTestBase
    {
        private CloudBlobContainer testContainer;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testContainer = GetRandomContainerReference();
            this.testContainer.CreateIfNotExistsAsync().AsTask().Wait();
            
            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.testContainer.DeleteIfExistsAsync().AsTask().Wait();
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        //[Description("Download a specific range of the blob")]
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
                await blob.UploadFromStreamAsync(wholeBlob.AsInputStream());

                byte[] testBuffer = new byte[1024];
                MemoryStream blobStream = new MemoryStream(testBuffer);
                Exception ex = await TestHelper.ExpectedExceptionAsync<Exception>(
                    async () => await blob.DownloadRangeToStreamAsync(blobStream.AsOutputStream(), 0, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(ArgumentOutOfRangeException));
                await blob.DownloadRangeToStreamAsync(blobStream.AsOutputStream(), 0, 1024);
                Assert.AreEqual(blobStream.Position, 1024);
                TestHelper.AssertStreamsAreEqualAtIndex(blobStream, wholeBlob, 0, 0, 1024);

                CloudPageBlob blob2 = this.testContainer.GetPageBlobReference("blob1");
                MemoryStream blobStream2 = new MemoryStream(testBuffer);
                ex = await TestHelper.ExpectedExceptionAsync<Exception>(
                    async () => await blob2.DownloadRangeToStreamAsync(blobStream.AsOutputStream(), 1024, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(ArgumentOutOfRangeException));
                await blob2.DownloadRangeToStreamAsync(blobStream2.AsOutputStream(), 1024, 1024);
                TestHelper.AssertStreamsAreEqualAtIndex(blobStream2, wholeBlob, 0, 1024, 1024);

                AssertAreEqual(blob, blob2);
            }
        }

        [TestMethod]
        //[Description("Upload a stream to a blob")]
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
                await blob.UploadFromStreamAsync(srcStream.AsInputStream());
                byte[] testBuffer = new byte[2048];
                MemoryStream dstStream = new MemoryStream(testBuffer);
                await blob.DownloadRangeToStreamAsync(dstStream.AsOutputStream(), null, null);
                TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
            }
        }

        [TestMethod]
        //[Description("Upload from text to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobUploadWithoutMD5ValidationAndStoreBlobContentTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            BlobRequestOptions options = new BlobRequestOptions();
            options.DisableContentMD5Validation = false;
            options.StoreBlobContentMD5 = false;
            OperationContext context = new OperationContext();
            using (MemoryStream srcStream = new MemoryStream(buffer))
            {
                await blob.UploadFromStreamAsync(srcStream.AsInputStream(), null, options, context);
                await blob.FetchAttributesAsync();
                string md5 = blob.Properties.ContentMD5;
                blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                await blob.SetPropertiesAsync(null, options, context);
                byte[] testBuffer = new byte[2048];
                MemoryStream dstStream = new MemoryStream(testBuffer);
                await TestHelper.ExpectedExceptionAsync(async () => await blob.DownloadRangeToStreamAsync(dstStream.AsOutputStream(), null, null, null, options, context),
                    context,
                    "Try to Download a stream with a corrupted md5 and DisableMD5Validation set to false",
                    HttpStatusCode.OK);

                options.DisableContentMD5Validation = true;
                await blob.SetPropertiesAsync(null, options, context);
                byte[] testBuffer2 = new byte[2048];
                MemoryStream dstStream2 = new MemoryStream(testBuffer2);
                await blob.DownloadRangeToStreamAsync(dstStream2.AsOutputStream(), null, null, null, options, context);
            }
        }

        [TestMethod]
        /// [Description("Upload from file to a blob")]
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
        /// [Description("Upload from file to a blob")]
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
            StorageFolder tempFolder = ApplicationData.Current.TemporaryFolder;
            StorageFile inputFile = await tempFolder.CreateFileAsync("input.file", CreationCollisionOption.GenerateUniqueName);
            StorageFile outputFile = await tempFolder.CreateFileAsync("output.file", CreationCollisionOption.GenerateUniqueName);

            try
            {
                byte[] buffer = GetRandomBuffer(fileSize);
                using (Stream file = await inputFile.OpenStreamForWriteAsync())
                {
                    await file.WriteAsync(buffer, 0, buffer.Length);
                }

                await blob.UploadFromFileAsync(inputFile);

                OperationContext context = new OperationContext();
                await blob.UploadFromFileAsync(inputFile, null, null, context);
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                context = new OperationContext();
                await blob.DownloadToFileAsync(outputFile, null, null, context);
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                using (Stream inputFileStream = await inputFile.OpenStreamForReadAsync(),
                    outputFileStream = await outputFile.OpenStreamForReadAsync())
                {
                    TestHelper.AssertStreamsAreEqual(inputFileStream, outputFileStream);
                }
            }
            finally
            {
                inputFile.DeleteAsync().AsTask().Wait();
                outputFile.DeleteAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Upload a blob using a byte array")]
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
        /// [Description("Upload a blob using a byte array")]
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
                    await blob.UploadFromStreamAsync(originalBlob.AsInputStream());
                    downloadLength = await blob.DownloadToByteArrayAsync(resultBuffer, bufferOffset);
                }
                else
                {
                    await blob.UploadFromStreamAsync(originalBlob.AsInputStream());
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
        /// [Description("Single put blob and get blob")]
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
                    await blob.UploadFromStreamAsync(originalBlob.AsInputStream());
                    downloadLength = await blob.DownloadRangeToByteArrayAsync(resultBuffer, bufferOffset, blobOffset, length);
                }
                else
                {
                    await blob.UploadFromStreamAsync(originalBlob.AsInputStream());
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
        // [Description("Single put blob and get blob")]
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
        // [Description("Single put blob and get blob")]
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
                await blob.UploadFromStreamAsync(stream.AsInputStream());

                OperationContext context = new OperationContext();
                await TestHelper.ExpectedExceptionAsync(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, 1024, 1, null, null, context), context, "Try invalid length", HttpStatusCode.RequestedRangeNotSatisfiable);
                WrappedStorageException ex = await TestHelper.ExpectedExceptionAsync<WrappedStorageException>(async () => await blob.DownloadToByteArrayAsync(resultBuffer, 1024), "Provide invalid offset");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(NotSupportedException));
                ex = await TestHelper.ExpectedExceptionAsync<WrappedStorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 1023, 0, 2), "Should fail when offset + length required is greater than size of the buffer");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(NotSupportedException));
                ex = await TestHelper.ExpectedExceptionAsync<WrappedStorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, 0, -10), "Fail when a negative length is specified");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(ArgumentOutOfRangeException));
                await TestHelper.ExpectedExceptionAsync<ArgumentOutOfRangeException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, -10, 0, 20), "Fail if a negative offset is provided");
                ex = await TestHelper.ExpectedExceptionAsync<WrappedStorageException>(async () => await blob.DownloadRangeToByteArrayAsync(resultBuffer, 0, -10, 20), "Fail if a negative blob offset is provided");
                Assert.IsInstanceOfType(ex.InnerException.InnerException, typeof(ArgumentOutOfRangeException));
            }
        }
        #endregion
    }
}