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
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class MD5FlagsTest : BlobTestBase
    {
        [TestMethod]
        [Description("Test StoreBlobContentMD5 flag with UploadFromStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StoreBlobContentMD5Test()
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
                container.Create();

                ICloudBlob blob = container.GetBlockBlobReference("blob1");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    blob.UploadFromStream(stream, null, optionsWithMD5);
                }
                blob.FetchAttributes();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetBlockBlobReference("blob2");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    blob.UploadFromStream(stream, null, optionsWithNoMD5);
                }
                blob.FetchAttributes();
                Assert.IsNull(blob.Properties.ContentMD5);

                blob = container.GetBlockBlobReference("blob3");
                using (Stream stream = new NonSeekableMemoryStream())
                {
                    blob.UploadFromStream(stream);
                }
                blob.FetchAttributes();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob4");
                using (Stream stream = new MemoryStream())
                {
                    blob.UploadFromStream(stream, null, optionsWithMD5);
                }
                blob.FetchAttributes();
                Assert.IsNotNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob5");
                using (Stream stream = new MemoryStream())
                {
                    blob.UploadFromStream(stream, null, optionsWithNoMD5);
                }
                blob.FetchAttributes();
                Assert.IsNull(blob.Properties.ContentMD5);

                blob = container.GetPageBlobReference("blob6");
                using (Stream stream = new MemoryStream())
                {
                    blob.UploadFromStream(stream);
                }
                blob.FetchAttributes();
                Assert.IsNull(blob.Properties.ContentMD5);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test StoreBlobContentMD5 flag with UploadFromStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StoreBlobContentMD5TestAPM()
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
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    ICloudBlob blob = container.GetBlockBlobReference("blob1");
                    using (Stream stream = new NonSeekableMemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNotNull(blob.Properties.ContentMD5);

                    blob = container.GetBlockBlobReference("blob2");
                    using (Stream stream = new NonSeekableMemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNull(blob.Properties.ContentMD5);

                    blob = container.GetBlockBlobReference("blob3");
                    using (Stream stream = new NonSeekableMemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNotNull(blob.Properties.ContentMD5);

                    blob = container.GetPageBlobReference("blob4");
                    using (Stream stream = new MemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNotNull(blob.Properties.ContentMD5);

                    blob = container.GetPageBlobReference("blob5");
                    using (Stream stream = new MemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNull(blob.Properties.ContentMD5);

                    blob = container.GetPageBlobReference("blob6");
                    using (Stream stream = new MemoryStream())
                    {
                        result = blob.BeginUploadFromStream(stream,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);
                    }
                    blob.FetchAttributes();
                    Assert.IsNull(blob.Properties.ContentMD5);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test DisableContentMD5Validation flag with DownloadToStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void DisableContentMD5ValidationTest()
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
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                using (Stream stream = new NonSeekableMemoryStream(buffer))
                {
                    blockBlob.UploadFromStream(stream, null, optionsWithMD5);
                }

                using (Stream stream = new MemoryStream())
                {
                    blockBlob.DownloadToStream(stream, null, optionsWithMD5);
                    blockBlob.DownloadToStream(stream, null, optionsWithNoMD5);

                    using (Stream blobStream = blockBlob.OpenRead(null, optionsWithMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    using (Stream blobStream = blockBlob.OpenRead(null, optionsWithNoMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    blockBlob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                    blockBlob.SetProperties();

                    TestHelper.ExpectedException(
                        () => blockBlob.DownloadToStream(stream, null, optionsWithMD5),
                        "Downloading a blob with invalid MD5 should fail",
                        HttpStatusCode.OK);
                    blockBlob.DownloadToStream(stream, null, optionsWithNoMD5);

                    using (Stream blobStream = blockBlob.OpenRead(null, optionsWithMD5))
                    {
                        TestHelper.ExpectedException<IOException>(
                            () =>
                            {
                                int read;
                                do
                                {
                                    read = blobStream.Read(buffer, 0, buffer.Length);
                                }
                                while (read > 0);
                            },
                            "Downloading a blob with invalid MD5 should fail");
                    }

                    using (Stream blobStream = blockBlob.OpenRead(null, optionsWithNoMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }
                }

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                using (Stream stream = new MemoryStream(buffer))
                {
                    pageBlob.UploadFromStream(stream, null, optionsWithMD5);
                }

                using (Stream stream = new MemoryStream())
                {
                    pageBlob.DownloadToStream(stream, null, optionsWithMD5);
                    pageBlob.DownloadToStream(stream, null, optionsWithNoMD5);

                    using (Stream blobStream = pageBlob.OpenRead(null, optionsWithMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    using (Stream blobStream = pageBlob.OpenRead(null, optionsWithNoMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }

                    pageBlob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                    pageBlob.SetProperties();

                    TestHelper.ExpectedException(
                        () => pageBlob.DownloadToStream(stream, null, optionsWithMD5),
                        "Downloading a blob with invalid MD5 should fail",
                        HttpStatusCode.OK);
                    pageBlob.DownloadToStream(stream, null, optionsWithNoMD5);

                    using (Stream blobStream = pageBlob.OpenRead(null, optionsWithMD5))
                    {
                        TestHelper.ExpectedException<IOException>(
                            () =>
                            {
                                int read;
                                do
                                {
                                    read = blobStream.Read(buffer, 0, buffer.Length);
                                }
                                while (read > 0);
                            },
                            "Downloading a blob with invalid MD5 should fail");
                    }

                    using (Stream blobStream = pageBlob.OpenRead(null, optionsWithNoMD5))
                    {
                        int read;
                        do
                        {
                            read = blobStream.Read(buffer, 0, buffer.Length);
                        }
                        while (read > 0);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test DisableContentMD5Validation flag with DownloadToStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void DisableContentMD5ValidationTestAPM()
        {
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
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    ICloudBlob blob = container.GetBlockBlobReference("blob1");
                    using (Stream stream = new NonSeekableMemoryStream())
                    {
                        blob.UploadFromStream(stream, null, optionsWithMD5);
                    }

                    using (Stream stream = new MemoryStream())
                    {
                        result = blob.BeginDownloadToStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);
                        result = blob.BeginDownloadToStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);

                        blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                        blob.SetProperties();

                        result = blob.BeginDownloadToStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        TestHelper.ExpectedException(
                            () => blob.EndDownloadToStream(result),
                            "Downloading a blob with invalid MD5 should fail",
                            HttpStatusCode.OK);
                        result = blob.BeginDownloadToStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);
                    }

                    blob = container.GetPageBlobReference("blob2");
                    using (Stream stream = new MemoryStream())
                    {
                        blob.UploadFromStream(stream, null, optionsWithMD5);
                    }

                    using (Stream stream = new MemoryStream())
                    {
                        result = blob.BeginDownloadToStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);
                        result = blob.BeginDownloadToStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);

                        blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                        blob.SetProperties();

                        result = blob.BeginDownloadToStream(stream, null, optionsWithMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        TestHelper.ExpectedException(
                            () => blob.EndDownloadToStream(result),
                            "Downloading a blob with invalid MD5 should fail",
                            HttpStatusCode.OK);
                        result = blob.BeginDownloadToStream(stream, null, optionsWithNoMD5, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndDownloadToStream(result);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test UseTransactionalMD5 flag with PutBlock and WritePages")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void UseTransactionalMD5PutTest()
        {
            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = false,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
            };

            byte[] buffer = GetRandomBuffer(1024);
            MD5 hasher = MD5.Create();
            string md5 = Convert.ToBase64String(hasher.ComputeHash(buffer));

            string lastCheckMD5 = null;
            int checkCount = 0;
            OperationContext opContextWithMD5Check = new OperationContext();
            opContextWithMD5Check.SendingRequest += (_, args) =>
            {
                if (args.Request.ContentLength >= buffer.Length)
                {
                    lastCheckMD5 = args.Request.Headers[HttpRequestHeader.ContentMd5];
                    checkCount++;
                }
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                List<string> blockIds = GetBlockIdList(3);
                checkCount = 0;
                using (Stream blockData = new MemoryStream(buffer))
                {
                    blockBlob.PutBlock(blockIds[0], blockData, null, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    blockData.Seek(0, SeekOrigin.Begin);
                    blockBlob.PutBlock(blockIds[1], blockData, null, null, optionsWithMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);

                    blockData.Seek(0, SeekOrigin.Begin);
                    blockBlob.PutBlock(blockIds[2], blockData, md5, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);
                }
                Assert.AreEqual(3, checkCount);

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                pageBlob.Create(buffer.Length);
                checkCount = 0;
                using (Stream pageData = new MemoryStream(buffer))
                {
                    pageBlob.WritePages(pageData, 0, null, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    pageData.Seek(0, SeekOrigin.Begin);
                    pageBlob.WritePages(pageData, 0, null, null, optionsWithMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);

                    pageData.Seek(0, SeekOrigin.Begin);
                    pageBlob.WritePages(pageData, 0, md5, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);
                }
                Assert.AreEqual(3, checkCount);

                blockBlob = container.GetBlockBlobReference("blob3");
                checkCount = 0;
                using (Stream blobStream = blockBlob.OpenWrite(null, optionsWithMD5, opContextWithMD5Check))
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }
                Assert.IsNotNull(lastCheckMD5);
                Assert.AreEqual(1, checkCount);

                blockBlob = container.GetBlockBlobReference("blob4");
                checkCount = 0;
                using (Stream blobStream = blockBlob.OpenWrite(null, optionsWithNoMD5, opContextWithMD5Check))
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }
                Assert.IsNull(lastCheckMD5);
                Assert.AreEqual(1, checkCount);

                pageBlob = container.GetPageBlobReference("blob5");
                checkCount = 0;
                using (Stream blobStream = pageBlob.OpenWrite(buffer.Length * 3, null, optionsWithMD5, opContextWithMD5Check))
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }
                Assert.IsNotNull(lastCheckMD5);
                Assert.AreEqual(1, checkCount);

                pageBlob = container.GetPageBlobReference("blob6");
                checkCount = 0;
                using (Stream blobStream = pageBlob.OpenWrite(buffer.Length * 3, null, optionsWithNoMD5, opContextWithMD5Check))
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }
                Assert.IsNull(lastCheckMD5);
                Assert.AreEqual(1, checkCount);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test UseTransactionalMD5 flag with PutBlock and WritePages")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void UseTransactionalMD5PutTestAPM()
        {
            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = false,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
            };

            byte[] buffer = GetRandomBuffer(1024);
            MD5 hasher = MD5.Create();
            string md5 = Convert.ToBase64String(hasher.ComputeHash(buffer));

            string lastCheckMD5 = null;
            int checkCount = 0;
            OperationContext opContextWithMD5Check = new OperationContext();
            opContextWithMD5Check.SendingRequest += (_, args) =>
            {
                if (args.Request.ContentLength >= buffer.Length)
                {
                    lastCheckMD5 = args.Request.Headers[HttpRequestHeader.ContentMd5];
                    checkCount++;
                }
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                    List<string> blockIds = GetBlockIdList(3);
                    checkCount = 0;
                    using (Stream blockData = new MemoryStream(buffer))
                    {
                        result = blockBlob.BeginPutBlock(blockIds[0], blockData, null, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndPutBlock(result);
                        Assert.IsNull(lastCheckMD5);

                        blockData.Seek(0, SeekOrigin.Begin);
                        result = blockBlob.BeginPutBlock(blockIds[1], blockData, null, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndPutBlock(result);
                        Assert.AreEqual(md5, lastCheckMD5);

                        blockData.Seek(0, SeekOrigin.Begin);
                        result = blockBlob.BeginPutBlock(blockIds[2], blockData, md5, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndPutBlock(result);
                        Assert.AreEqual(md5, lastCheckMD5);
                    }
                    Assert.AreEqual(3, checkCount);

                    CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                    pageBlob.Create(buffer.Length);
                    checkCount = 0;
                    using (Stream pageData = new MemoryStream(buffer))
                    {
                        result = pageBlob.BeginWritePages(pageData, 0, null, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndWritePages(result);
                        Assert.IsNull(lastCheckMD5);

                        pageData.Seek(0, SeekOrigin.Begin);
                        result = pageBlob.BeginWritePages(pageData, 0, null, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndWritePages(result);
                        Assert.AreEqual(md5, lastCheckMD5);

                        pageData.Seek(0, SeekOrigin.Begin);
                        result = pageBlob.BeginWritePages(pageData, 0, md5, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndWritePages(result);
                        Assert.AreEqual(md5, lastCheckMD5);
                    }
                    Assert.AreEqual(3, checkCount);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test UseTransactionalMD5 flag with DownloadRangeToStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void UseTransactionalMD5GetTest()
        {
            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = false,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
            };

            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            MD5 hasher = MD5.Create();
            string md5 = Convert.ToBase64String(hasher.ComputeHash(buffer));

            string lastCheckMD5 = null;
            int checkCount = 0;
            OperationContext opContextWithMD5Check = new OperationContext();
            opContextWithMD5Check.ResponseReceived += (_, args) =>
            {
                if (args.Response.ContentLength >= buffer.Length)
                {
                    lastCheckMD5 = args.Response.Headers[HttpResponseHeader.ContentMd5];
                    checkCount++;
                }
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                using (Stream blobStream = blockBlob.OpenWrite())
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }

                checkCount = 0;
                using (Stream stream = new MemoryStream())
                {
                    blockBlob.DownloadToStream(stream, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNotNull(lastCheckMD5);

                    blockBlob.DownloadToStream(stream, null, optionsWithMD5, opContextWithMD5Check);
                    Assert.IsNotNull(lastCheckMD5);

                    blockBlob.DownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    blockBlob.DownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);

                    blockBlob.DownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    StorageException storageEx = TestHelper.ExpectedException<StorageException>(
                        () => blockBlob.DownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithMD5, opContextWithMD5Check),
                        "Downloading more than 4MB with transactional MD5 should not be supported");
                    Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                }
                Assert.AreEqual(5, checkCount);

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                using (Stream blobStream = pageBlob.OpenWrite(buffer.Length * 2))
                {
                    blobStream.Write(buffer, 0, buffer.Length);
                    blobStream.Write(buffer, 0, buffer.Length);
                }

                checkCount = 0;
                using (Stream stream = new MemoryStream())
                {
                    pageBlob.DownloadToStream(stream, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    StorageException storageEx = TestHelper.ExpectedException<StorageException>(
                        () => pageBlob.DownloadToStream(stream, null, optionsWithMD5, opContextWithMD5Check),
                        "Page blob will not have MD5 set by default; with UseTransactional, download should fail");

                    pageBlob.DownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    pageBlob.DownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithMD5, opContextWithMD5Check);
                    Assert.AreEqual(md5, lastCheckMD5);

                    pageBlob.DownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithNoMD5, opContextWithMD5Check);
                    Assert.IsNull(lastCheckMD5);

                    storageEx = TestHelper.ExpectedException<StorageException>(
                        () => pageBlob.DownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithMD5, opContextWithMD5Check),
                        "Downloading more than 4MB with transactional MD5 should not be supported");
                    Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                }
                Assert.AreEqual(5, checkCount);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test UseTransactionalMD5 flag with DownloadRangeToStream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void UseTransactionalMD5GetTestAPM()
        {
            BlobRequestOptions optionsWithNoMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = false,
            };
            BlobRequestOptions optionsWithMD5 = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
            };

            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);
            MD5 hasher = MD5.Create();
            string md5 = Convert.ToBase64String(hasher.ComputeHash(buffer));

            string lastCheckMD5 = null;
            int checkCount = 0;
            OperationContext opContextWithMD5Check = new OperationContext();
            opContextWithMD5Check.ResponseReceived += (_, args) =>
            {
                if (args.Response.ContentLength >= buffer.Length)
                {
                    lastCheckMD5 = args.Response.Headers[HttpResponseHeader.ContentMd5];
                    checkCount++;
                }
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                    using (Stream blobStream = blockBlob.OpenWrite())
                    {
                        blobStream.Write(buffer, 0, buffer.Length);
                        blobStream.Write(buffer, 0, buffer.Length);
                    }

                    checkCount = 0;
                    using (Stream stream = new MemoryStream())
                    {
                        result = blockBlob.BeginDownloadToStream(stream, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndDownloadRangeToStream(result);
                        Assert.IsNotNull(lastCheckMD5);

                        result = blockBlob.BeginDownloadToStream(stream, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndDownloadRangeToStream(result);
                        Assert.IsNotNull(lastCheckMD5);

                        result = blockBlob.BeginDownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndDownloadRangeToStream(result);
                        Assert.IsNull(lastCheckMD5);

                        result = blockBlob.BeginDownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndDownloadRangeToStream(result);
                        Assert.AreEqual(md5, lastCheckMD5);

                        result = blockBlob.BeginDownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blockBlob.EndDownloadRangeToStream(result);
                        Assert.IsNull(lastCheckMD5);

                        result = blockBlob.BeginDownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        StorageException storageEx = TestHelper.ExpectedException<StorageException>(
                            () => blockBlob.EndDownloadRangeToStream(result),
                            "Downloading more than 4MB with transactional MD5 should not be supported");
                        Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                    }
                    Assert.AreEqual(5, checkCount);

                    CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                    using (Stream blobStream = pageBlob.OpenWrite(buffer.Length * 2))
                    {
                        blobStream.Write(buffer, 0, buffer.Length);
                        blobStream.Write(buffer, 0, buffer.Length);
                    }

                    checkCount = 0;
                    using (Stream stream = new MemoryStream())
                    {
                        result = pageBlob.BeginDownloadToStream(stream, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndDownloadRangeToStream(result);
                        Assert.IsNull(lastCheckMD5);

                        result = pageBlob.BeginDownloadToStream(stream, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        StorageException storageEx = TestHelper.ExpectedException<StorageException>(
                            () => pageBlob.EndDownloadRangeToStream(result),
                            "Page blob will not have MD5 set by default; with UseTransactional, download should fail");

                        result = pageBlob.BeginDownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndDownloadRangeToStream(result);
                        Assert.IsNull(lastCheckMD5);

                        result = pageBlob.BeginDownloadRangeToStream(stream, buffer.Length, buffer.Length, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndDownloadRangeToStream(result);
                        Assert.AreEqual(md5, lastCheckMD5);

                        result = pageBlob.BeginDownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithNoMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        pageBlob.EndDownloadRangeToStream(result);
                        Assert.IsNull(lastCheckMD5);

                        result = pageBlob.BeginDownloadRangeToStream(stream, 1024, 4 * 1024 * 1024 + 1, null, optionsWithMD5, opContextWithMD5Check,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        storageEx = TestHelper.ExpectedException<StorageException>(
                            () => pageBlob.EndDownloadRangeToStream(result),
                            "Downloading more than 4MB with transactional MD5 should not be supported");
                        Assert.IsInstanceOfType(storageEx.InnerException, typeof(ArgumentOutOfRangeException));
                    }
                    Assert.AreEqual(5, checkCount);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
