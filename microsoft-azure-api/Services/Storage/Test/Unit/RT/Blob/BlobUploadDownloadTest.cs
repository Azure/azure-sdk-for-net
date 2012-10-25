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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobUploadDownloadTest : BlobTestBase
    {
        [TestMethod]
        //[Description("Download a specific range of the blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task PageBlobDownloadToStreamRangeTestAsync()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
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

                    CloudPageBlob blob2 = container.GetPageBlobReference("blob1");
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
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
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
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream srcStream = new MemoryStream(buffer))
                {
                    await blob.UploadFromStreamAsync(srcStream.AsInputStream());
                    byte[] testBuffer = new byte[2048];
                    MemoryStream dstStream = new MemoryStream(testBuffer);
                    await blob.DownloadRangeToStreamAsync(dstStream.AsOutputStream(), null, null);
                    TestHelper.AssertStreamsAreEqual(srcStream, dstStream);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
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
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
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
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }

        }

    }
}