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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage.Streams;

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
        public async Task BlobSeekTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(srcStream, null, null, null);
                    using (Stream blobStream = await blob.OpenReadAsync())
                    {
                        Stream blobStreamForRead = blobStream;
                        blobStreamForRead.Seek(2048, 0);
                        byte[] buff = new byte[100];
                        int numRead = await blobStreamForRead.ReadAsync(buff, 0, 100);
                        Assert.AreEqual(numRead, 0);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("OpenWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobOpenWriteTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (CloudBlobStream blobStream = await blob.OpenWriteAsync(2048))
                {
                    Stream blobStreamForWrite = blobStream;
                    await blobStreamForWrite.WriteAsync(buffer, 0, 2048);
                    await blobStreamForWrite.FlushAsync();

                    byte[] testBuffer = new byte[2048];
                    MemoryStream dstStream = new MemoryStream(testBuffer);
                    await blob.DownloadRangeToStreamAsync(dstStream, null, null);
                    
                    MemoryStream memStream = new MemoryStream(buffer);
                    TestHelper.AssertStreamsAreEqual(memStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("OpenRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobOpenReadTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(srcStream);

                    Stream dstStream = await blob.OpenReadAsync();
                    using (Stream dstStreamForRead = dstStream)
                    {
                        TestHelper.AssertStreamsAreEqual(srcStream, dstStreamForRead);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("OpenReadWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobOpenReadWriteTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                
                using (CloudBlobStream blobStream = await blob.OpenWriteAsync(2048))
                {
                    Stream blobStreamForWrite = blobStream;
                    await blobStreamForWrite.WriteAsync(buffer, 0, 2048);
                    await blobStreamForWrite.FlushAsync();
                }

                using (Stream dstStream = await blob.OpenReadAsync())
                {
                    Stream dstStreamForRead = dstStream;
                    MemoryStream memoryStream = new MemoryStream(buffer);
                    TestHelper.AssertStreamsAreEqual(memoryStream, dstStreamForRead);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("OpenWriteSeekRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobOpenWriteSeekReadTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");

                MemoryStream memoryStream = new MemoryStream(buffer);
                using (CloudBlobStream blobStream = await blob.OpenWriteAsync(2048))
                {
                    Stream blobStreamForWrite = blobStream;
                    await blobStreamForWrite.WriteAsync(buffer, 0, 2048);

                    Assert.AreEqual(blobStreamForWrite.Position, 2048);

                    blobStreamForWrite.Seek(1024, 0);
                    memoryStream.Seek(1024, 0);
                    Assert.AreEqual(blobStreamForWrite.Position, 1024);

                    byte[] testBuffer = GetRandomBuffer(1024);

                    await memoryStream.WriteAsync(testBuffer, 0, 1024);
                    await blobStreamForWrite.WriteAsync(testBuffer, 0, 1024);
                    Assert.AreEqual(blobStreamForWrite.Position, memoryStream.Position);

                    await blobStreamForWrite.FlushAsync();
                }

                using (Stream dstStream = await blob.OpenReadAsync())
                {
                    Stream dstStreamForRead = dstStream;
                    TestHelper.AssertStreamsAreEqual(memoryStream, dstStreamForRead);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Read when opened in OpenWrite")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobReadWhenOpenWriteAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            bool thrown = false;
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();
                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                MemoryStream memoryStream = new MemoryStream(buffer);
                using (Stream blobStream = await blob.OpenWriteAsync(2048))
                {
                    Stream blobStreamForWrite = blobStream;
                    await blobStreamForWrite.WriteAsync(buffer, 0, 2048);
                    byte[] testBuffer = new byte[2048];
                    try
                    {
                        await blobStreamForWrite.ReadAsync(testBuffer, 0, 2048);
                    }
                    catch (NotSupportedException)
                    {
                        thrown = true;
                    }

                    Assert.IsTrue(thrown);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Write when opened in OpenRead")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task BlobWriteWhenOpenReadAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(srcStream);
                    bool thrown = false;
                    byte[] testBuffer = new byte[2048];
                    using (Stream blobStream = await blob.OpenReadAsync())
                    {
                        Stream blobStreamForRead = blobStream;
                        try
                        {
                            await blobStreamForRead.WriteAsync(testBuffer, 0, 2048);
                        }
                        catch (NotSupportedException)
                        {
                            thrown = true;
                        }

                        Assert.IsTrue(thrown);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
    }
}

