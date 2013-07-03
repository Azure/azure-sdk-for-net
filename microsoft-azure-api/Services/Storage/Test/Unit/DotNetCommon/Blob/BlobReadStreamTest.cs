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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Threading;

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
        [Description("Validate StreamMinimumReadSizeInBytes property")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadStreamReadSizeTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                BlobReadStreamReadSizeTest(blob);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Validate StreamMinimumReadSizeInBytes property")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadStreamReadSizeTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                BlobReadStreamReadSizeTest(blob);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        private void BlobReadStreamReadSizeTest(ICloudBlob blob)
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            using (MemoryStream wholeBlob = new MemoryStream(buffer))
            {
                blob.UploadFromStream(wholeBlob);
            }

            TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                () => blob.StreamMinimumReadSizeInBytes = 16 * 1024 - 1,
                "StreamMinimumReadSizeInBytes should not accept values smaller than 16KB");

            blob.StreamMinimumReadSizeInBytes = 4 * 1024 * 1024 + 1;
            BlobRequestOptions options = new BlobRequestOptions() { UseTransactionalMD5 = true };
            TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                () => blob.OpenRead(null, options, null),
                "StreamMinimumReadSizeInBytes should be smaller than 4MB if UseTransactionalMD5 is true");

            string range = null;
            OperationContext context = new OperationContext();
            context.SendingRequest += (sender, e) => range = range ?? e.Request.Headers["x-ms-range"];

            blob.StreamMinimumReadSizeInBytes = 4 * 1024 * 1024;
            using (Stream blobStream = blob.OpenRead(null, options, context))
            {
                blobStream.ReadByte();
                Assert.AreEqual("bytes=0-" + (blob.StreamMinimumReadSizeInBytes - 1).ToString(), range);
                range = null;
            }

            blob.StreamMinimumReadSizeInBytes = 6 * 1024 * 1024;
            options.UseTransactionalMD5 = false;
            using (Stream blobStream = blob.OpenRead(null, options, context))
            {
                blobStream.ReadByte();
                Assert.AreEqual("bytes=0-" + (buffer.Length - 1).ToString(), range);
                range = null;
            }

            blob.StreamMinimumReadSizeInBytes = 16 * 1024;
            using (Stream blobStream = blob.OpenRead(null, options, context))
            {
                blobStream.ReadByte();
                Assert.AreEqual("bytes=0-" + (blob.StreamMinimumReadSizeInBytes - 1).ToString(), range);
                range = null;
            }
        }

        [TestMethod]
        [Description("Validate StreamMinimumReadSizeInBytes property")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadStreamReadSizeTestAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                BlobReadStreamReadSizeTestAPM(blob);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Validate StreamMinimumReadSizeInBytes property")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadStreamReadSizeTestAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                BlobReadStreamReadSizeTestAPM(blob);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        private void BlobReadStreamReadSizeTestAPM(ICloudBlob blob)
        {
            IAsyncResult result;
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    result = blob.BeginUploadFromStream(wholeBlob,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob.EndUploadFromStream(result);
                }

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () => blob.StreamMinimumReadSizeInBytes = 16 * 1024 - 1,
                    "StreamMinimumReadSizeInBytes should not accept values smaller than 16KB");

                blob.StreamMinimumReadSizeInBytes = 4 * 1024 * 1024 + 1;
                BlobRequestOptions options = new BlobRequestOptions() { UseTransactionalMD5 = true };
                result = blob.BeginOpenRead(null, options, null,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () => blob.EndOpenRead(result),
                    "StreamMinimumReadSizeInBytes should be smaller than 4MB if UseTransactionalMD5 is true");

                string range = null;
                OperationContext context = new OperationContext();
                context.SendingRequest += (sender, e) => range = range ?? e.Request.Headers["x-ms-range"];

                blob.StreamMinimumReadSizeInBytes = 4 * 1024 * 1024;
                result = blob.BeginOpenRead(null, options, context,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                using (Stream blobStream = blob.EndOpenRead(result))
                {
                    blobStream.ReadByte();
                    Assert.AreEqual("bytes=0-" + (blob.StreamMinimumReadSizeInBytes - 1).ToString(), range);
                    range = null;
                }

                blob.StreamMinimumReadSizeInBytes = 6 * 1024 * 1024;
                options.UseTransactionalMD5 = false;
                result = blob.BeginOpenRead(null, options, context,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                using (Stream blobStream = blob.EndOpenRead(result))
                {
                    blobStream.ReadByte();
                    Assert.AreEqual("bytes=0-" + (buffer.Length - 1).ToString(), range);
                    range = null;
                }

                blob.StreamMinimumReadSizeInBytes = 16 * 1024;
                result = blob.BeginOpenRead(null, options, context,
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                using (Stream blobStream = blob.EndOpenRead(result))
                {
                    blobStream.ReadByte();
                    Assert.AreEqual("bytes=0-" + (blob.StreamMinimumReadSizeInBytes - 1).ToString(), range);
                    range = null;
                }
            }
        }

        [TestMethod]
        [Description("Download a blob using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadStreamBasicTest()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    using (Stream blobStream = blob.OpenRead())
                    {
                        TestHelper.AssertStreamsAreEqual(wholeBlob, blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Download a blob using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadStreamBasicTest()
        {
            byte[] buffer = GetRandomBuffer(5 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    using (Stream blobStream = blob.OpenRead())
                    {
                        TestHelper.AssertStreamsAreEqual(wholeBlob, blobStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadLockToETagTest()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    long length = blobStream.Length;
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                blob.SetMetadata();
                TestHelper.ExpectedException(
                    () => blob.OpenRead(accessCondition),
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadLockToETagTestAPM()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = blob.BeginOpenRead(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    using (Stream blobStream = blob.EndOpenRead(result))
                    {
                        blobStream.Read(outBuffer, 0, outBuffer.Length);
                        blob.SetMetadata();
                        TestHelper.ExpectedException(
                            () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                            "Blob read stream should fail if blob is modified during read",
                            HttpStatusCode.PreconditionFailed);
                    }

                    result = blob.BeginOpenRead(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    using (Stream blobStream = blob.EndOpenRead(result))
                    {
                        long length = blobStream.Length;
                        blob.SetMetadata();
                        TestHelper.ExpectedException(
                            () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                            "Blob read stream should fail if blob is modified during read",
                            HttpStatusCode.PreconditionFailed);
                    }

                    AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                    blob.SetMetadata();
                    result = blob.BeginOpenRead(
                        accessCondition,
                        null,
                        null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => blob.EndOpenRead(result),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadLockToETagTestTask()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStreamAsync(wholeBlob).Wait();
                }

                using (Stream blobStream = blob.OpenReadAsync().Result)
                {
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadataAsync().Wait();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenReadAsync().Result)
                {
                    long length = blobStream.Length;
                    blob.SetMetadataAsync().Wait();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                blob.SetMetadataAsync().Wait();
                TestHelper.ExpectedExceptionTask(
                    blob.OpenReadAsync(accessCondition, null, null),
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadLockToETagTest()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    long length = blobStream.Length;
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                blob.SetMetadata();
                TestHelper.ExpectedException(
                    () => blob.OpenRead(accessCondition),
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadLockToETagTestAPM()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = blob.BeginOpenRead(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    using (Stream blobStream = blob.EndOpenRead(result))
                    {
                        blobStream.Read(outBuffer, 0, outBuffer.Length);
                        blob.SetMetadata();
                        TestHelper.ExpectedException(
                            () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                            "Blob read stream should fail if blob is modified during read",
                            HttpStatusCode.PreconditionFailed);
                    }

                    result = blob.BeginOpenRead(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    using (Stream blobStream = blob.EndOpenRead(result))
                    {
                        long length = blobStream.Length;
                        blob.SetMetadata();
                        TestHelper.ExpectedException(
                            () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                            "Blob read stream should fail if blob is modified during read",
                            HttpStatusCode.PreconditionFailed);
                    }

                    AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                    blob.SetMetadata();
                    result = blob.BeginOpenRead(
                        accessCondition,
                        null,
                        null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => blob.EndOpenRead(result),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Modify a blob while downloading it using CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadLockToETagTestTask()
        {
            byte[] outBuffer = new byte[1 * 1024 * 1024];
            byte[] buffer = GetRandomBuffer(2 * outBuffer.Length);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = outBuffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStreamAsync(wholeBlob).Wait();
                }

                using (Stream blobStream = blob.OpenReadAsync().Result)
                {
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadataAsync().Wait();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenReadAsync().Result)
                {
                    long length = blobStream.Length;
                    blob.SetMetadataAsync().Wait();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                blob.SetMetadataAsync().Wait();
                TestHelper.ExpectedExceptionTask(
                    blob.OpenReadAsync(accessCondition, null, null),
                    "Blob read stream should fail if blob is modified during read",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        private static int BlobReadStreamSeekAndCompare(Stream blobStream, byte[] bufferToCompare, long offset, int readSize, int expectedReadCount, bool isAsync)
        {
            byte[] testBuffer = new byte[readSize];

            if (isAsync)
            {
                using (ManualResetEvent waitHandle = new ManualResetEvent(false))
                {
                    IAsyncResult result = blobStream.BeginRead(testBuffer, 0, readSize, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    int readCount = blobStream.EndRead(result);
                    Assert.AreEqual(expectedReadCount, readCount);
                }
            }
            else
            {
                int readCount = blobStream.Read(testBuffer, 0, readSize);
                Assert.AreEqual(expectedReadCount, readCount);
            }

            for (int i = 0; i < expectedReadCount; i++)
            {
                Assert.AreEqual(bufferToCompare[i + offset], testBuffer[i]);
            }

            return expectedReadCount;
        }

        private static int BlobReadStreamSeekTest(Stream blobStream, long streamReadSize, byte[] bufferToCompare, bool isAsync)
        {
            int attempts = 1;
            long position = 0;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 1024, isAsync);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 512, 512, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-128, SeekOrigin.End);
            position = bufferToCompare.Length - 128;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 128, isAsync);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(4096, SeekOrigin.Begin);
            position = 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 1024, isAsync);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(4096, SeekOrigin.Current);
            position += 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 1024, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-4096, SeekOrigin.Current);
            position -= 4096;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 128, 128, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(streamReadSize + 4096 - 512, SeekOrigin.Begin);
            position = streamReadSize + 4096 - 512;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 512, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 1024, isAsync);
            attempts++;
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-1024, SeekOrigin.Current);
            position -= 1024;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 2048, 2048, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            blobStream.Seek(-128, SeekOrigin.End);
            position = bufferToCompare.Length - 128;
            Assert.AreEqual(position, blobStream.Position);
            position += BlobReadStreamSeekAndCompare(blobStream, bufferToCompare, position, 1024, 128, isAsync);
            Assert.AreEqual(position, blobStream.Position);
            return attempts;
        }

        [TestMethod]
        [Description("Seek and read in a CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadStreamSeekTest()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = 2 * 1024 * 1024;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = blob.OpenRead(null, null, opContext))
                {
                    int attempts = BlobReadStreamSeekTest(blobStream, blob.StreamMinimumReadSizeInBytes, buffer, false);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }

                opContext = new OperationContext();
                using (Stream blobStream = blob.OpenRead(null, null, opContext))
                {
                    int attempts = BlobReadStreamSeekTest(blobStream, blob.StreamMinimumReadSizeInBytes, buffer, true);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Seek and read in a CloudBlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadStreamSeekTest()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamMinimumReadSizeInBytes = 2 * 1024 * 1024;
                using (MemoryStream wholeBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(wholeBlob);
                }

                OperationContext opContext = new OperationContext();
                using (Stream blobStream = blob.OpenRead(null, null, opContext))
                {
                    int attempts = BlobReadStreamSeekTest(blobStream, blob.StreamMinimumReadSizeInBytes, buffer, false);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }

                opContext = new OperationContext();
                using (Stream blobStream = blob.OpenRead(null, null, opContext))
                {
                    int attempts = BlobReadStreamSeekTest(blobStream, blob.StreamMinimumReadSizeInBytes, buffer, true);
                    TestHelper.AssertNAttempts(opContext, attempts);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
