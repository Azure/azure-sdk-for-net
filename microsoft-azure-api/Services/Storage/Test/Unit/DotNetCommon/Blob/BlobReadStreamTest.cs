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
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobReadStreamTest : BlobTestBase
    {
        [TestMethod]
        [Description("Download a blob using BlobStream")]
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
                    wholeBlob.Seek(0, SeekOrigin.End);
                    using (Stream blobStream = blob.OpenRead())
                    {
                        blobStream.Seek(0, SeekOrigin.End);
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
        [Description("Download a blob using BlobStream")]
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
                    wholeBlob.Seek(0, SeekOrigin.End);
                    using (Stream blobStream = blob.OpenRead())
                    {
                        blobStream.Seek(0, SeekOrigin.End);
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
        [Description("Modify a blob while downloading it using BlobStream")]
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
                    blob.SetMetadata();
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    blob.SetMetadata();
                    long length = blobStream.Length;
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                using (Stream blobStream = blob.OpenRead(accessCondition))
                {
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Modify a blob while downloading it using BlobStream")]
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
                    blob.SetMetadata();
                    blobStream.Read(outBuffer, 0, outBuffer.Length);
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                using (Stream blobStream = blob.OpenRead())
                {
                    blob.SetMetadata();
                    long length = blobStream.Length;
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }

                AccessCondition accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1)));
                using (Stream blobStream = blob.OpenRead(accessCondition))
                {
                    blob.SetMetadata();
                    TestHelper.ExpectedException(
                        () => blobStream.Read(outBuffer, 0, outBuffer.Length),
                        "Blob read stream should fail if blob is modified during read",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Randomly seek and read in a BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobReadStreamRandomSeekTest()
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

                Random random = new Random();
                byte[] testBuffer = new byte[1024];
                using (Stream blobStream = blob.OpenRead())
                {
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
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Randomly seek and read in a BlobStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobReadStreamRandomSeekTest()
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

                Random random = new Random();
                byte[] testBuffer = new byte[1024];
                using (Stream blobStream = blob.OpenRead())
                {
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
                container.DeleteIfExists();
            }
        }
    }
}
