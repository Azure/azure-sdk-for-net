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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

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
            this.testContainer.CreateIfNotExists();

            if (TestBase.BlobBufferManager != null)
            {
                TestBase.BlobBufferManager.OutstandingBufferCount = 0;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.testContainer.DeleteIfExists();
            if (TestBase.BlobBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.BlobBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        [Description("Download a specific range of the blob to a stream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobDownloadToStreamRangeTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            using (MemoryStream wholeBlob = new MemoryStream(buffer))
            {
                blob.UploadFromStream(wholeBlob);

                byte[] testBuffer = new byte[1024];
                MemoryStream blobStream = new MemoryStream(testBuffer);
                StorageException storageEx = TestHelper.ExpectedException<StorageException>(
                    () => blob.DownloadRangeToStream(blobStream, 0, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                blob.DownloadRangeToStream(blobStream, 0, 1024);
                Assert.AreEqual(blobStream.Position, 1024);
                TestHelper.AssertStreamsAreEqualAtIndex(blobStream, wholeBlob, 0, 0, 1024);

                CloudPageBlob blob2 = this.testContainer.GetPageBlobReference("blob1");
                MemoryStream blobStream2 = new MemoryStream(testBuffer);
                storageEx = TestHelper.ExpectedException<StorageException>(
                    () => blob2.DownloadRangeToStream(blobStream, 1024, 0),
                    "Requesting 0 bytes when downloading range should not work");
                Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                blob2.DownloadRangeToStream(blobStream2, 1024, 1024);
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
        public void BlobUploadFromStreamTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            using (MemoryStream srcStream = new MemoryStream(buffer))
            {
                blob.UploadFromStream(srcStream);
                byte[] testBuffer = new byte[2048];
                MemoryStream dstStream = new MemoryStream(testBuffer);
                blob.DownloadRangeToStream(dstStream, null, null);
                TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
            }
        }

        [TestMethod]
        [Description("Upload from text to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobUploadWithoutMD5ValidationAndStoreBlobContentTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);

            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            BlobRequestOptions options = new BlobRequestOptions();
            options.DisableContentMD5Validation = false;
            options.StoreBlobContentMD5 = false;
            OperationContext context = new OperationContext();
            using (MemoryStream srcStream = new MemoryStream(buffer))
            {
                blob.UploadFromStream(srcStream, null, options, context);
                blob.FetchAttributes();
                string md5 = blob.Properties.ContentMD5;
                blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                blob.SetProperties(null, options, context);
                byte[] testBuffer = new byte[2048];
                MemoryStream dstStream = new MemoryStream(testBuffer);
                TestHelper.ExpectedException(() => blob.DownloadRangeToStream(dstStream, null, null, null, options, context),
                    "Try to Download a stream with a corrupted md5 and DisableMD5Validation set to false",
                    HttpStatusCode.OK);

                options.DisableContentMD5Validation = true;
                blob.SetProperties(null, options, context);
                byte[] testBuffer2 = new byte[2048];
                MemoryStream dstStream2 = new MemoryStream(testBuffer2);
                blob.DownloadRangeToStream(dstStream2, null, null, null, options, context);
            }
        }

        [TestMethod]
        [Description("Upload from text to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobEmptyHeaderSigningTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            OperationContext context = new OperationContext();
            try
            {
                container.Create(null, context);
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                context.UserHeaders = new Dictionary<string, string>();
                context.UserHeaders.Add("x-ms-foo", String.Empty);
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(srcStream, null, null, context);
                }
                byte[] testBuffer2 = new byte[2048];
                MemoryStream dstStream2 = new MemoryStream(testBuffer2);
                blob.DownloadRangeToStream(dstStream2, null, null, null, null, context);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadDownloadFile()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadDownloadFile(blob, 0, false);
            this.DoUploadDownloadFile(blob, 4096, false);
            this.DoUploadDownloadFile(blob, 4097, false);

            TestHelper.ExpectedException<IOException>(
                () => blob.UploadFromFile("non_existent.file", FileMode.Open),
                "UploadFromFile requires an existing file");
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadDownloadFile()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadDownloadFile(blob, 0, false);
            this.DoUploadDownloadFile(blob, 4096, false);

            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadDownloadFile(blob, 4097, false),
                "Page blobs must be 512-byte aligned");

            TestHelper.ExpectedException<IOException>(
                () => blob.UploadFromFile("non_existent.file", FileMode.Open),
                "UploadFromFile requires an existing file");
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadDownloadFileAPM()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadDownloadFile(blob, 0, true);
            this.DoUploadDownloadFile(blob, 4096, true);
            this.DoUploadDownloadFile(blob, 4097, true);

            TestHelper.ExpectedException<IOException>(
                () => blob.BeginUploadFromFile("non_existent.file", FileMode.Open, null, null),
                "UploadFromFile requires an existing file");
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadDownloadFileAPM()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadDownloadFile(blob, 0, true);
            this.DoUploadDownloadFile(blob, 4096, true);

            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadDownloadFile(blob, 4097, true),
                "Page blobs must be 512-byte aligned");

            TestHelper.ExpectedException<IOException>(
                () => blob.BeginUploadFromFile("non_existent.file", FileMode.Open, null, null),
                "UploadFromFile requires an existing file");
        }

#if TASK
        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadDownloadFileTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadDownloadFileTask(blob, 0);
            this.DoUploadDownloadFileTask(blob, 4096);
            this.DoUploadDownloadFileTask(blob, 4097);

            TestHelper.ExpectedException<IOException>(
                () => blob.UploadFromFileAsync("non_existent.file", FileMode.Open),
                "UploadFromFile requires an existing file");
        }

        [TestMethod]
        [Description("Upload from file to a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadDownloadFileTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadDownloadFileTask(blob, 0);
            this.DoUploadDownloadFileTask(blob, 4096);
            
            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadDownloadFileTask(blob, 4097),
                "Page blobs must be 512-byte aligned");

            TestHelper.ExpectedException<IOException>(
                () => blob.UploadFromFileAsync("non_existent.file", FileMode.Open),
                "UploadFromFile requires an existing file");
        }

        private void DoUploadDownloadFileTask(ICloudBlob blob, int fileSize)
        {
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();

            try
            {
                byte[] buffer = GetRandomBuffer(fileSize);
                using (FileStream file = new FileStream(inputFileName, FileMode.Create, FileAccess.Write))
                {
                    file.Write(buffer, 0, buffer.Length);
                }

                blob.UploadFromFileAsync(inputFileName, FileMode.Open).Wait();

                OperationContext context = new OperationContext();
                blob.UploadFromFileAsync(inputFileName, FileMode.Open, null, null, context).Wait();
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                TestHelper.ExpectedException<IOException>(
                    () => blob.DownloadToFileAsync(outputFileName, FileMode.CreateNew),
                    "CreateNew on an existing file should fail");

                context = new OperationContext();
                blob.DownloadToFileAsync(outputFileName, FileMode.Create, null, null, context).Wait();
                Assert.IsNotNull(context.LastResult.ServiceRequestID);

                using (
                    FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                               outputFileStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                {
                    TestHelper.AssertStreamsAreEqual(inputFileStream, outputFileStream);
                }

                blob.DownloadToFileAsync(outputFileName, FileMode.Append).Wait();

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
            catch (AggregateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException; 
                }

                throw;
            }
            finally
            {
                File.Delete(inputFileName);
                File.Delete(outputFileName);
            }
        }
#endif

        private void DoUploadDownloadFile(ICloudBlob blob, int fileSize, bool isAsync)
        {
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();

            try
            {
                byte[] buffer = GetRandomBuffer(fileSize);
                using (FileStream file = new FileStream(inputFileName, FileMode.Create, FileAccess.Write))
                {
                    file.Write(buffer, 0, buffer.Length);
                }

                if (isAsync)
                {
                    IAsyncResult result;
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        result = blob.BeginUploadFromFile(inputFileName, FileMode.Open,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromFile(result);

                        OperationContext context = new OperationContext();
                        result = blob.BeginUploadFromFile(inputFileName, FileMode.Open, null, null, context,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromFile(result);
                        Assert.IsNotNull(context.LastResult.ServiceRequestID);

                        TestHelper.ExpectedException<IOException>(
                            () => blob.BeginDownloadToFile(outputFileName, FileMode.CreateNew, null, null),
                            "CreateNew on an existing file should fail");

                        context = new OperationContext();
                        result = blob.BeginDownloadToFile(outputFileName, FileMode.Create, null, null, context,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToFile(result);
                        Assert.IsNotNull(context.LastResult.ServiceRequestID);

                        using (FileStream inputFile = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                            outputFile = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                        {
                            TestHelper.AssertStreamsAreEqual(inputFile, outputFile);
                        }

                        result = blob.BeginDownloadToFile(outputFileName, FileMode.Append,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToFile(result);

                        using (FileStream inputFile = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                            outputFile = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                        {
                            Assert.AreEqual(2 * fileSize, outputFile.Length);

                            for (int i = 0; i < fileSize; i++)
                            {
                                Assert.AreEqual(inputFile.ReadByte(), outputFile.ReadByte());
                            }

                            inputFile.Seek(0, SeekOrigin.Begin);
                            for (int i = 0; i < fileSize; i++)
                            {
                                Assert.AreEqual(inputFile.ReadByte(), outputFile.ReadByte());
                            }
                        }
                    }
                }
                else
                {
                    blob.UploadFromFile(inputFileName, FileMode.Open);

                    OperationContext context = new OperationContext();
                    blob.UploadFromFile(inputFileName, FileMode.Open, null, null, context);
                    Assert.IsNotNull(context.LastResult.ServiceRequestID);

                    TestHelper.ExpectedException<IOException>(
                        () => blob.DownloadToFile(outputFileName, FileMode.CreateNew),
                        "CreateNew on an existing file should fail");

                    context = new OperationContext();
                    blob.DownloadToFile(outputFileName, FileMode.Create, null, null, context);
                    Assert.IsNotNull(context.LastResult.ServiceRequestID);

                    using (FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
                        outputFileStream = new FileStream(outputFileName, FileMode.Open, FileAccess.Read))
                    {
                        TestHelper.AssertStreamsAreEqual(inputFileStream, outputFileStream);
                    }

                    blob.DownloadToFile(outputFileName, FileMode.Append);

                    using (FileStream inputFileStream = new FileStream(inputFileName, FileMode.Open, FileAccess.Read),
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
        public void CloudBlockBlobUploadFromByteArray()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 4 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 2 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 1 * 512, 2 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 2 * 512, 2 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 512, 0, 511, false);
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromByteArrayAPM()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 4 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 2 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 1 * 512, 2 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 2 * 512, 2 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 512, 0, 511, true);
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadFromByteArray()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 4 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 2 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 1 * 512, 2 * 512, false);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 2 * 512, 2 * 512, false);

            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadFromByteArrayTest(blob, 512, 0, 511, false),
                "Page blobs must be 512-byte aligned");
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadFromByteArrayAPM()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 4 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 0, 2 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 1 * 512, 2 * 512, true);
            this.DoUploadFromByteArrayTest(blob, 4 * 512, 2 * 512, 2 * 512, true);

            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadFromByteArrayTest(blob, 512, 0, 511, true),
                "Page blobs must be 512-byte aligned");
        }

#if TASK
        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromByteArrayTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 0, 4 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 0, 2 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 1 * 512, 2 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 2 * 512, 2 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 512, 0, 511);
        }

        [TestMethod]
        [Description("Upload a blob using a byte array")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobUploadFromByteArrayTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 0, 4 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 0, 2 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 1 * 512, 2 * 512);
            this.DoUploadFromByteArrayTestTask(blob, 4 * 512, 2 * 512, 2 * 512);
            
            TestHelper.ExpectedException<ArgumentException>(
                () => this.DoUploadFromByteArrayTestTask(blob, 512, 0, 511),
                "Page blobs must be 512-byte aligned");
        }

        private void DoUploadFromByteArrayTestTask(ICloudBlob blob, int bufferSize, int bufferOffset, int count)
        {
            byte[] buffer = GetRandomBuffer(bufferSize);
            byte[] downloadedBuffer = new byte[bufferSize];
            int downloadLength;

            try
            {
                blob.UploadFromByteArrayAsync(buffer, bufferOffset, count).Wait();
                downloadLength = blob.DownloadToByteArrayAsync(downloadedBuffer, 0).Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }

                throw;
            }

            Assert.AreEqual(count, downloadLength);

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(buffer[i + bufferOffset], downloadedBuffer[i]);
            }
        }
#endif

        private void DoUploadFromByteArrayTest(ICloudBlob blob, int bufferSize, int bufferOffset, int count, bool isAsync)
        {
            byte[] buffer = GetRandomBuffer(bufferSize);
            byte[] downloadedBuffer = new byte[bufferSize];
            int downloadLength;

            if (isAsync)
            {
                IAsyncResult result;
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    result = blob.BeginUploadFromByteArray(buffer, bufferOffset, count,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob.EndUploadFromByteArray(result);

                    result = blob.BeginDownloadToByteArray(downloadedBuffer, 0,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    downloadLength = blob.EndDownloadToByteArray(result);
                }
            }
            else
            {
                blob.UploadFromByteArray(buffer, bufferOffset, count);
                downloadLength = blob.DownloadToByteArray(downloadedBuffer, 0);
            }

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
        public void CloudBlockBlobDownloadToByteArray()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 0);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 0);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 0);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToByteArrayAPM()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 1);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 1);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 1);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToByteArrayAPMOverload()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 2);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 2);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 2);
        }

#if TASK
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToByteArrayTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 0, false);
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 1 * 512, false);
            this.DoDownloadToByteArrayTestTask(blob, 2 * 512, 4 * 512, 1 * 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToByteArrayOverloadTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 0, true);
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 1 * 512, true);
            this.DoDownloadToByteArrayTestTask(blob, 2 * 512, 4 * 512, 1 * 512, true);
        }
#endif

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadToByteArray()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 0);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 0);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 0);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadToByteArrayAPM()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 1);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 1);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 1);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadToByteArrayAPMOverload()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 0, 2);
            this.DoDownloadToByteArrayTest(blob, 1 * 512, 2 * 512, 1 * 512, 2);
            this.DoDownloadToByteArrayTest(blob, 2 * 512, 4 * 512, 1 * 512, 2);
        }

#if TASK
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadToByteArrayTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 0, false);
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 1 * 512, false);
            this.DoDownloadToByteArrayTestTask(blob, 2 * 512, 4 * 512, 1 * 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadToByteArrayOverloadTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 0, true);
            this.DoDownloadToByteArrayTestTask(blob, 1 * 512, 2 * 512, 1 * 512, true);
            this.DoDownloadToByteArrayTestTask(blob, 2 * 512, 4 * 512, 1 * 512, true);
        }
#endif

        /// <summary>
        /// Single put blob and get blob
        /// </summary>
        /// <param name="blobSize">The blob size.</param>
        /// <param name="bufferOffset">The blob offset.</param>
        /// <param name="option"> 0 - Sunc, 1 - APM and 2 - APM overload.</param>
        private void DoDownloadToByteArrayTest(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, int option)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                if (option == 0)
                {
                    blob.UploadFromStream(originalBlob);
                    downloadLength = blob.DownloadToByteArray(resultBuffer, bufferOffset);
                }
                else if (option == 1)
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        result = blob.BeginDownloadToByteArray(resultBuffer,
                            bufferOffset,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        downloadLength = blob.EndDownloadToByteArray(result);
                    }
                }
                else
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        OperationContext context = new OperationContext();
                        result = blob.BeginDownloadToByteArray(resultBuffer,
                            bufferOffset, /* offset */
                            null, /* accessCondition */
                            null, /* options */
                            context, /* operationContext */
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        downloadLength = blob.EndDownloadToByteArray(result);
                    }
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

#if TASK
        /// <summary>
        /// Single put blob and get blob
        /// </summary>
        /// <param name="blobSize">The blob size.</param>
        /// <param name="bufferOffset">The blob offset.</param>
        /// <param name="option">Run with overloaded parameters.</param>
        private void DoDownloadToByteArrayTestTask(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, bool overload)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                blob.UploadFromStreamAsync(originalBlob).Wait();
                
                if (overload)
                {
                    downloadLength = blob.DownloadToByteArrayAsync(
                        resultBuffer, 
                        bufferOffset, 
                        null, 
                        null, 
                        new OperationContext())
                            .Result;
                }
                else
                {
                    downloadLength = blob.DownloadToByteArrayAsync(resultBuffer, bufferOffset).Result; 
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
#endif

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArray()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 0);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 0);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArrayAPM()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 1);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 1);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArrayAPMOverload()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 2);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 2);
        }

#if TASK
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArrayTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, null, null, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, false);

            // Edge cases
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 1023, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 0, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 512, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 0, 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArrayOverloadTask()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, null, null, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, true);

            // Edge cases
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 1023, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 0, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 512, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 0, 512, true);
        }
#endif

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArray()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 0);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 0);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 0);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 0);

        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArrayAPM()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 1);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 1);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 1);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 1);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArrayAPMOverload()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, null, null, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, 2);
            this.DoDownloadRangeToByteArray(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, 2);

            // Edge cases
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 1023, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 0, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 0, 512, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 1023, 1, 2);
            this.DoDownloadRangeToByteArray(blob, 1024, 1024, 512, 0, 512, 2);
        }

#if TASK
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArrayTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, null, null, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, false);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, false);

            // Edge cases
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 1023, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 0, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 512, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 1023, 1, false);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 0, 512, false);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArrayOverloadTask()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 0, 1 * 512, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, null, null, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 1 * 512, null, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 1 * 512, 0, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 1 * 512, true);
            this.DoDownloadRangeToByteArrayTask(blob, 2 * 512, 4 * 512, 2 * 512, 1 * 512, 2 * 512, true);

            // Edge cases
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 1023, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 0, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 0, 512, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 1023, 1, true);
            this.DoDownloadRangeToByteArrayTask(blob, 1024, 1024, 512, 0, 512, true);
        }
#endif

        /// <summary>
        /// Single put blob and get blob
        /// </summary>
        /// <param name="blobSize">The blob size.</param>
        /// <param name="bufferSize">The output buffer size.</param>
        /// <param name="bufferOffset">The output buffer offset.</param>
        /// <param name="blobOffset">The blob offset.</param>
        /// <param name="length">Length of the data range to download.</param>
        /// <param name="option">0 - Sync, 1 - APM and 2 - APM overload.</param>
        private void DoDownloadRangeToByteArray(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, long? blobOffset, long? length, int option)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                if (option == 0)
                {
                    blob.UploadFromStream(originalBlob);
                    downloadLength = blob.DownloadRangeToByteArray(resultBuffer, bufferOffset, blobOffset, length);
                }
                else if (option == 1)
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        result = blob.BeginDownloadRangeToByteArray(resultBuffer,
                            bufferOffset,
                            blobOffset,
                            length,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        downloadLength = blob.EndDownloadRangeToByteArray(result);
                    }
                }
                else
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        OperationContext context = new OperationContext();
                        result = blob.BeginDownloadRangeToByteArray(resultBuffer,
                            bufferOffset,
                            blobOffset,
                            length,
                            null,
                            null,
                            context,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        downloadLength = blob.EndDownloadRangeToByteArray(result);
                    }
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

#if TASK
        /// <summary>
        /// Single put blob and get blob
        /// </summary>
        /// <param name="blobSize">The blob size.</param>
        /// <param name="bufferSize">The output buffer size.</param>
        /// <param name="bufferOffset">The output buffer offset.</param>
        /// <param name="blobOffset">The blob offset.</param>
        /// <param name="length">Length of the data range to download.</param>
        /// <param name="overload">Run with overloaded parameters.</param>
        private void DoDownloadRangeToByteArrayTask(ICloudBlob blob, int blobSize, int bufferSize, int bufferOffset, long? blobOffset, long? length, bool overload)
        {
            int downloadLength;
            byte[] buffer = GetRandomBuffer(blobSize);
            byte[] resultBuffer = new byte[bufferSize];
            byte[] resultBuffer2 = new byte[bufferSize];

            using (MemoryStream originalBlob = new MemoryStream(buffer))
            {
                if (overload)
                {
                    blob.UploadFromStream(originalBlob);
                    downloadLength = blob.DownloadRangeToByteArrayAsync(
                        resultBuffer, bufferOffset, blobOffset, length, null, null, new OperationContext()).Result;
                }
                else
                {
                    blob.UploadFromStream(originalBlob);
                    downloadLength = blob.DownloadRangeToByteArrayAsync(resultBuffer, bufferOffset, blobOffset, length).Result;
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
#endif

        #region Negative tests
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadRangeToByteArrayNegativeTests()
        {
            CloudBlockBlob blob = this.testContainer.GetBlockBlobReference("blob1");
            this.DoDownloadRangeToByteArrayNegativeTests(blob);
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobDownloadRangeToByteArrayNegativeTests()
        {
            CloudPageBlob blob = this.testContainer.GetPageBlobReference("blob1");
            this.DoDownloadRangeToByteArrayNegativeTests(blob);
        }

        private void DoDownloadRangeToByteArrayNegativeTests(ICloudBlob blob)
        {
            int blobLength = 1024;
            int resultBufSize = 1024;
            byte[] buffer = GetRandomBuffer(blobLength);
            byte[] resultBuffer = new byte[resultBufSize];

            using (MemoryStream stream = new MemoryStream(buffer))
            {
                blob.UploadFromStream(stream);

                TestHelper.ExpectedException(() => blob.DownloadRangeToByteArray(resultBuffer, 0, 1024, 1), "Try invalid length", HttpStatusCode.RequestedRangeNotSatisfiable);
                StorageException ex = TestHelper.ExpectedException<StorageException>(() => blob.DownloadToByteArray(resultBuffer, 1024), "Provide invalid offset");
                Assert.IsInstanceOfType(ex.InnerException, typeof(NotSupportedException));
                ex = TestHelper.ExpectedException<StorageException>(() => blob.DownloadRangeToByteArray(resultBuffer, 1023, 0, 2), "Should fail when offset + length required is greater than size of the buffer");
                Assert.IsInstanceOfType(ex.InnerException, typeof(NotSupportedException));
                ex = TestHelper.ExpectedException<StorageException>(() => blob.DownloadRangeToByteArray(resultBuffer, 0, 0, -10), "Fail when a negative length is specified");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
                TestHelper.ExpectedException<ArgumentOutOfRangeException>(() => blob.DownloadRangeToByteArray(resultBuffer, -10, 0, 20), "Fail if a negative offset is provided");
                ex = TestHelper.ExpectedException<StorageException>(() => blob.DownloadRangeToByteArray(resultBuffer, 0, -10, 20), "Fail if a negative blob offset is provided");
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentOutOfRangeException));
            }
        }
        #endregion
    }
}