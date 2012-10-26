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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobStreamTests : BlobTestBase
    {
        [TestMethod]
        //[Description("BlobSeek")]
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
                    await blob.UploadFromStreamAsync(srcStream.AsInputStream(), null, null, null);
                    IInputStream iBlobStream = await blob.OpenReadAsync();
                    using (Stream blobStream = iBlobStream.AsStreamForRead())
                    {
                        blobStream.Seek(2048, 0);
                        byte[] buff = new byte[100];
                        int numRead = await blobStream.ReadAsync(buff, 0, 100);
                        Assert.AreEqual(numRead, 0);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait(); ;
            }
        }

        [TestMethod]
        //[Description("OpenWrite")]
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
                MemoryStream memStream = new MemoryStream(buffer);
                IOutputStream iBlobStream = await blob.OpenWriteAsync(2048);
                using (Stream blobStream = iBlobStream.AsStreamForWrite())
                {
                    await blobStream.WriteAsync(buffer, 0, 2048);
                    byte[] testBuffer = new byte[2048];
                    MemoryStream dstStream = new MemoryStream(testBuffer);
                    await blob.DownloadRangeToStreamAsync(dstStream.AsOutputStream(), null, null);
                    await iBlobStream.FlushAsync();
                    TestHelper.AssertStreamsAreEqual(memStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        //[Description("OpenRead")]
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
                    await blob.UploadFromStreamAsync(srcStream.AsInputStream());

                    IInputStream iDstStream = await blob.OpenReadAsync();
                    using (Stream dstStream = iDstStream.AsStreamForRead())
                    {
                        srcStream.Seek(srcStream.Length, 0);
                        dstStream.Seek(2048, 0);
                        TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        //[Description("OpenReadWrite")]
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
                IOutputStream iBlobStream = await blob.OpenWriteAsync(2048);
                MemoryStream memoryStream = new MemoryStream(buffer);
                using (Stream blobStream = iBlobStream.AsStreamForWrite())
                {
                    await blobStream.WriteAsync(buffer, 0, 2048);
                    await blobStream.AsOutputStream().FlushAsync();
                }
                IInputStream iDstStream = await blob.OpenReadAsync();
                using (Stream dstStream = iDstStream.AsStreamForRead())
                {
                    dstStream.Seek(dstStream.Length, 0);
                    memoryStream.Seek(memoryStream.Length, 0);
                    TestHelper.AssertStreamsAreEqual(memoryStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        //[Description("OpenWriteSeekRead")]
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
                IOutputStream iBlobStream = await blob.OpenWriteAsync(2048);
                using (Stream blobStream = iBlobStream.AsStreamForWrite())
                {
                    await blobStream.WriteAsync(buffer, 0, 2048);

                    Assert.AreEqual(blobStream.Position, 2048);

                    blobStream.Seek(1024, 0);
                    memoryStream.Seek(1024, 0);
                    Assert.AreEqual(blobStream.Position, 1024);

                    byte[] testBuffer = GetRandomBuffer(1024); ;

                    await memoryStream.WriteAsync(testBuffer, 0, 1024);
                    await blobStream.WriteAsync(testBuffer, 0, 1024);
                    Assert.AreEqual(blobStream.Position, memoryStream.Position);

                    await blobStream.FlushAsync();
                }
                IInputStream iDstStream = await blob.OpenReadAsync();
                using (Stream dstStream = iDstStream.AsStreamForRead())
                {
                    dstStream.Seek(2048, 0);
                    TestHelper.AssertStreamsAreEqual(memoryStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        //[Description("Read when opened in OpenWrite")]
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
                IOutputStream iBlobStream = await blob.OpenWriteAsync(2048);
                using (Stream blobStream = iBlobStream.AsStreamForWrite())
                {
                    await blobStream.WriteAsync(buffer, 0, 2048);
                    byte[] testBuffer = new byte[2048];
                    try
                    {
                        await blobStream.ReadAsync(testBuffer, 0, 2048);
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
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        //[Description("Write when opened in OpenRead")]
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
                    await blob.UploadFromStreamAsync(srcStream.AsInputStream());
                    IInputStream iBlobStream = await blob.OpenReadAsync();
                    bool thrown = false;
                    byte[] testBuffer = new byte[2048];
                    using (Stream blobStream = iBlobStream.AsStreamForRead())
                    {
                        try
                        {
                            await blobStream.WriteAsync(testBuffer, 0, 2048);
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
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }
    }
}

