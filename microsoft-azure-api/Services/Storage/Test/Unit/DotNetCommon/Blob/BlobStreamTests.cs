// -----------------------------------------------------------------------------------------
// <copyright file="BlobStreamTests.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobStreamTests : BlobTestBase
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
        [Description("BlobSeek")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobSeekTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(srcStream);
                    Stream blobStream = blob.OpenRead();
                    blobStream.Seek(2048, 0);
                    byte[] buff = new byte[100];
                    int numRead = blobStream.Read(buff, 0, 100);
                    Assert.AreEqual(numRead, 0);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }       
        }

        [TestMethod]
        [Description("OpenWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobOpenWriteTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (CloudBlobStream blobStream = blob.OpenWrite(2048))
                {
                    blobStream.Write(buffer, 0, 2048);
                    blobStream.Flush();

                    byte[] testBuffer = new byte[2048];
                    MemoryStream dstStream = new MemoryStream(testBuffer);
                    blob.DownloadRangeToStream(dstStream, null, null);

                    MemoryStream memStream = new MemoryStream(buffer);
                    TestHelper.AssertStreamsAreEqual(memStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("OpenRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobOpenReadTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(srcStream);

                    Stream dstStream = blob.OpenRead();
                    TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("OpenReadWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobOpenReadWriteTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");

                Stream blobStream = blob.OpenWrite(2048);
                blobStream.Write(buffer, 0, 2048);
                blobStream.Close();

                MemoryStream memoryStream = new MemoryStream(buffer);
                Stream dstStream = blob.OpenRead();
                TestHelper.AssertStreamsAreEqual(memoryStream, dstStream);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("OpenWriteSeekRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobOpenWriteSeekReadTest()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                MemoryStream memoryStream = new MemoryStream(buffer);
                Stream blobStream = blob.OpenWrite(2048);
                blobStream.Write(buffer, 0, 2048);

                Assert.AreEqual(blobStream.Position, 2048);

                blobStream.Seek(1024, 0);
                memoryStream.Seek(1024, 0);
                Assert.AreEqual(blobStream.Position, 1024);

                byte[] testBuffer = GetRandomBuffer(1024);

                memoryStream.Write(testBuffer, 0, 1024);
                blobStream.Write(testBuffer, 0, 1024);
                Assert.AreEqual(blobStream.Position, memoryStream.Position);

                blobStream.Close();

                Stream dstStream = blob.OpenRead();
                TestHelper.AssertStreamsAreEqual(memoryStream, dstStream);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Read when opened in OpenWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobReadWhenOpenWrite()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                MemoryStream memoryStream = new MemoryStream(buffer);
                Stream blobStream = blob.OpenWrite(2048);
                blobStream.Write(buffer, 0, 2048);
                byte[] testBuffer = new byte[2048];
                TestHelper.ExpectedException<NotSupportedException>(() => blobStream.Read(testBuffer, 0, 2048),
                        "Try reading from a stream opened for Write");
                
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Write when opened in OpenRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobWriteWhenOpenRead()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(srcStream);
                    Stream blobStream = blob.OpenRead();
                   
                    byte[] testBuffer = new byte[2048];
                    TestHelper.ExpectedException<NotSupportedException>(() => blobStream.Write(testBuffer, 0, 2048), 
                            "Try writing to a stream opened for read");
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
