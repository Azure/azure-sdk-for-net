// -----------------------------------------------------------------------------------------
// <copyright file="MD5FlagsTest.cs" company="Microsoft">
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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class MD5FlagsTest : BlobTestBase
    {
        [TestMethod]
        /// [Description("Test StoreBlobContentMD5 flag with UploadFromStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task StoreBlobContentMD5TestAsync()
        {
            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                StoreBlobContentMD5 = false,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                StoreBlobContentMD5 = true,
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                ICloudBlob blob = container.GetBlockBlobReference("blob1");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithMD5, null);
                }
                await blob.FetchAttributesAsync();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetBlockBlobReference("blob2");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithNoMD5, null);
                }
                await blob.FetchAttributesAsync();
                Assert.IsNull(blob.Properties.ContentMD5);

                blob = container.GetBlockBlobReference("blob3");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream());
                }
                await blob.FetchAttributesAsync();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob4");
                using (Stream stream = new MemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithMD5, null);
                }
                await blob.FetchAttributesAsync();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob5");
                using (Stream stream = new MemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithNoMD5, null);
                }
                await blob.FetchAttributesAsync();
                Assert.IsNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob6");
                using (Stream stream = new MemoryStream())
                {
                    await blob.UploadFromStreamAsync(stream.AsInputStream());
                }
                await blob.FetchAttributesAsync();
                Assert.IsNull(blob.Properties.ContentMD5);
            }
            finally
            {
                container.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Test DisableContentMD5Validation flag with DownloadToStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task DisableContentMD5ValidationTestAsync()
        {
            byte[] buffer = new byte[1024];
            Random random = new Random();
            random.NextBytes(buffer);

            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                DisableContentMD5Validation = true,
                StoreBlobContentMD5 = true,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                DisableContentMD5Validation = false,
                StoreBlobContentMD5 = true,
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                await container.CreateAsync();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                using (Stream stream = new NonSeekableMemoryStream(buffer))
                {
                    await blockBlob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithMD5, null);
                }

                using (Stream stream = new MemoryStream())
                {
                    await blockBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithMD5, null);
                    await blockBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithNoMD5, null);

                    using (IRandomAccessStreamWithContentType blobStream = await blockBlob.OpenReadAsync(null, optionsWithMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    using (IRandomAccessStreamWithContentType blobStream = await blockBlob.OpenReadAsync(null, optionsWithNoMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    blockBlob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                    await blockBlob.SetPropertiesAsync();

                    OperationContext opContext = new OperationContext();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await blockBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithMD5, opContext),
                        opContext,
                        "Downloading a blob with invalid MD5 should fail",
                        HttpStatusCode.OK);
                    await blockBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithNoMD5, null);

                    using (IRandomAccessStreamWithContentType blobStream = await blockBlob.OpenReadAsync(null, optionsWithMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        TestHelper.ExpectedException<IOException>(
                            () =>
                            {
                                int read;
                                do
                                {
                                    read = blobStreamForRead.Read(buffer, 0, buffer.Length);
                                }
                                while (read > 0);
                            },
                            "Downloading a blob with invalid MD5 should fail");
                    }

                    using (IRandomAccessStreamWithContentType blobStream = await blockBlob.OpenReadAsync(null, optionsWithNoMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }
                }

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                using (Stream stream = new MemoryStream(buffer))
                {
                    await pageBlob.UploadFromStreamAsync(stream.AsInputStream(), null, optionsWithMD5, null);
                }

                using (Stream stream = new MemoryStream())
                {
                    await pageBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithMD5, null);
                    await pageBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithNoMD5, null);

                    using (IRandomAccessStreamWithContentType blobStream = await pageBlob.OpenReadAsync(null, optionsWithMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    using (IRandomAccessStreamWithContentType blobStream = await pageBlob.OpenReadAsync(null, optionsWithNoMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    pageBlob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                    await pageBlob.SetPropertiesAsync();

                    OperationContext opContext = new OperationContext();
                    await TestHelper.ExpectedExceptionAsync(
                        async () => await pageBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithMD5, opContext),
                        opContext,
                        "Downloading a blob with invalid MD5 should fail",
                        HttpStatusCode.OK);
                    await pageBlob.DownloadToStreamAsync(stream.AsOutputStream(), null, optionsWithNoMD5, null);

                    using (IRandomAccessStreamWithContentType blobStream = await pageBlob.OpenReadAsync(null, optionsWithMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        TestHelper.ExpectedException<IOException>(
                            () =>
                            {
                                int read;
                                do
                                {
                                    read = blobStreamForRead.Read(buffer, 0, buffer.Length);
                                }
                                while (read > 0);
                            },
                            "Downloading a blob with invalid MD5 should fail");
                    }

                    using (IRandomAccessStreamWithContentType blobStream = await pageBlob.OpenReadAsync(null, optionsWithNoMD5, null))
                    {
                        Stream blobStreamForRead = blobStream.AsStreamForRead();
                        int read;
                        do
                        {
                            read = await blobStreamForRead.ReadAsync(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
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
