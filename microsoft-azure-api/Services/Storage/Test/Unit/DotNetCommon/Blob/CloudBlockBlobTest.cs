// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlockBlobTest.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlockBlobTest : BlobTestBase
    {
        private static void CreateForTest(CloudBlockBlob blob, int blockCount, int blockSize, bool isAsync, bool commit = true)
        {
            byte[] buffer = GetRandomBuffer(blockSize);
            List<string> blocks = GetBlockIdList(blockCount);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                foreach (string block in blocks)
                {
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        if (isAsync)
                        {
                            IAsyncResult result = blob.BeginPutBlock(block, stream, null,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndPutBlock(result);
                        }
                        else
                        {
                            blob.PutBlock(block, stream, null);
                        }
                    }
                }

                if (commit)
                {
                    if (isAsync)
                    {
                        IAsyncResult result = blob.BeginPutBlockList(blocks,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndPutBlockList(result);
                    }
                    else
                    {
                        blob.PutBlockList(blocks);
                    }
                }
            }
        }

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

#if TASK
        private static void CreateForTestTask(CloudBlockBlob blob, int blockCount, int blockSize, bool commit = true)
        {
            byte[] buffer = GetRandomBuffer(blockSize);
            List<string> blocks = GetBlockIdList(blockCount);
            
            foreach (string block in blocks)
            {
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.PutBlockAsync(block, stream, null, null, null, null).Wait();
                }
            }

            if (commit)
            {
                blob.PutBlockListAsync(blocks, null, null, null).Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Get a block blob reference using its constructor")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobConstructor()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 0, 0, false);

                CloudBlockBlob blob2 = new CloudBlockBlob(blob.Uri);
                Assert.AreEqual(blob.Uri, blob2.Uri);
                Assert.AreEqual(blob.Name, blob2.Name);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a zero-length block blob and then delete it")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCreateAndDelete()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 0, 0, false);
                Assert.IsTrue(blob.Exists());
                blob.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a zero-length block blob and then delete it")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCreateAndDeleteAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 0, 0, false);
                IAsyncResult result;
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    result = blob.BeginExists(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(blob.EndExists(result));
                    result = blob.BeginDelete(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    blob.EndDelete(result);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Create a zero-length block blob and then delete it")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCreateAndDeleteTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.PutBlockListAsync(new List<string>()).Wait();
                Assert.IsTrue(blob.ExistsAsync().Result);
                blob.DeleteAsync().Wait();
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Try to delete a non-existing block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDeleteIfExists()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                Assert.IsFalse(blob.DeleteIfExists());
                CreateForTest(blob, 0, 0, false);
                Assert.IsTrue(blob.DeleteIfExists());
                Assert.IsFalse(blob.DeleteIfExists());
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Try to delete a non-existing block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDeleteIfExistsAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                    IAsyncResult result = blob.BeginDeleteIfExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(blob.EndDeleteIfExists(result));
                    CreateForTest(blob, 0, 0, true);
                    result = blob.BeginDeleteIfExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(blob.EndDeleteIfExists(result));
                    result = blob.BeginDeleteIfExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(blob.EndDeleteIfExists(result));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Try to delete a non-existing block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDeleteIfExistsTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                Assert.IsFalse(blob.DeleteIfExistsAsync().Result);
                blob.PutBlockListAsync(new List<string>()).Wait();
                Assert.IsTrue(blob.DeleteIfExistsAsync().Result);
                Assert.IsFalse(blob.DeleteIfExistsAsync().Result);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Check a blob's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobExists()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");

                Assert.IsFalse(blob2.Exists());

                CreateForTest(blob, 2, 1024, false);

                Assert.IsTrue(blob2.Exists());
                Assert.AreEqual(2048, blob2.Properties.Length);

                blob.Delete();

                Assert.IsFalse(blob2.Exists());
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Check a blob's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobExistsAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = blob2.BeginExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(blob2.EndExists(result));

                    CreateForTest(blob, 2, 1024, false);

                    result = blob2.BeginExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(blob2.EndExists(result));
                    Assert.AreEqual(2048, blob2.Properties.Length);

                    blob.Delete();

                    result = blob2.BeginExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(blob2.EndExists(result));
                }
            }
            finally
            {
                container.Delete();
            }
        }

#if TASK
        [TestMethod]
        [Description("Check a blob's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobExistsTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.CreateAsync().Wait();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");

                Assert.IsFalse(blob2.ExistsAsync().Result);

                CreateForTestTask(blob, 2, 1024);

                Assert.IsTrue(blob2.ExistsAsync().Result);
                Assert.AreEqual(2048, blob2.Properties.Length);

                blob.DeleteAsync().Wait();

                Assert.IsFalse(blob2.ExistsAsync().Result);
            }
            finally
            {
                container.DeleteAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Verify the attributes of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobFetchAttributes()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, false);
                Assert.AreEqual(-1, blob.Properties.Length);
                Assert.IsNotNull(blob.Properties.ETag);
                Assert.IsTrue(blob.Properties.LastModified > DateTimeOffset.UtcNow.AddMinutes(-5));
                Assert.IsNull(blob.Properties.CacheControl);
                Assert.IsNull(blob.Properties.ContentEncoding);
                Assert.IsNull(blob.Properties.ContentLanguage);
                Assert.IsNull(blob.Properties.ContentType);
                Assert.IsNull(blob.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unspecified, blob.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob.Properties.BlobType);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual(1024, blob2.Properties.Length);
                Assert.AreEqual(blob.Properties.ETag, blob2.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, blob2.Properties.LastModified);
                Assert.IsNull(blob2.Properties.CacheControl);
                Assert.IsNull(blob2.Properties.ContentEncoding);
                Assert.IsNull(blob2.Properties.ContentLanguage);
                Assert.AreEqual("application/octet-stream", blob2.Properties.ContentType);
                Assert.IsNull(blob2.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unlocked, blob2.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob2.Properties.BlobType);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Verify the attributes of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobFetchAttributesAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, true);
                Assert.AreEqual(-1, blob.Properties.Length);
                Assert.IsNotNull(blob.Properties.ETag);
                Assert.IsTrue(blob.Properties.LastModified > DateTimeOffset.UtcNow.AddMinutes(-5));
                Assert.IsNull(blob.Properties.CacheControl);
                Assert.IsNull(blob.Properties.ContentEncoding);
                Assert.IsNull(blob.Properties.ContentLanguage);
                Assert.IsNull(blob.Properties.ContentType);
                Assert.IsNull(blob.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unspecified, blob.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob.Properties.BlobType);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                using (ManualResetEvent waitHandle = new ManualResetEvent(false))
                {
                    IAsyncResult result = blob2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob2.EndFetchAttributes(result);
                }
                Assert.AreEqual(1024, blob2.Properties.Length);
                Assert.AreEqual(blob.Properties.ETag, blob2.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, blob2.Properties.LastModified);
                Assert.IsNull(blob2.Properties.CacheControl);
                Assert.IsNull(blob2.Properties.ContentEncoding);
                Assert.IsNull(blob2.Properties.ContentLanguage);
                Assert.AreEqual("application/octet-stream", blob2.Properties.ContentType);
                Assert.IsNull(blob2.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unlocked, blob2.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob2.Properties.BlobType);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Verify the attributes of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobFetchAttributesTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try 
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTestTask(blob, 1, 1024);
                Assert.AreEqual(-1, blob.Properties.Length);
                Assert.IsNotNull(blob.Properties.ETag);
                Assert.IsTrue(blob.Properties.LastModified > DateTimeOffset.UtcNow.AddMinutes(-5));
                Assert.IsNull(blob.Properties.CacheControl);
                Assert.IsNull(blob.Properties.ContentEncoding);
                Assert.IsNull(blob.Properties.ContentLanguage);
                Assert.IsNull(blob.Properties.ContentType);
                Assert.IsNull(blob.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unspecified, blob.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob.Properties.BlobType);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual(1024, blob2.Properties.Length);
                Assert.AreEqual(blob.Properties.ETag, blob2.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, blob2.Properties.LastModified);
                Assert.IsNull(blob2.Properties.CacheControl);
                Assert.IsNull(blob2.Properties.ContentEncoding);
                Assert.IsNull(blob2.Properties.ContentLanguage);
                Assert.AreEqual("application/octet-stream", blob2.Properties.ContentType);
                Assert.IsNull(blob2.Properties.ContentMD5);
                Assert.AreEqual(LeaseStatus.Unlocked, blob2.Properties.LeaseStatus);
                Assert.AreEqual(BlobType.BlockBlob, blob2.Properties.BlobType);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Verify setting the properties of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetProperties()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, false);
                string eTag = blob.Properties.ETag;
                DateTimeOffset lastModified = blob.Properties.LastModified.Value;

                Thread.Sleep(1000);

                blob.Properties.CacheControl = "no-transform";
                blob.Properties.ContentEncoding = "gzip";
                blob.Properties.ContentLanguage = "tr,en";
                blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                blob.Properties.ContentType = "text/html";
                blob.SetProperties();
                Assert.IsTrue(blob.Properties.LastModified > lastModified);
                Assert.AreNotEqual(eTag, blob.Properties.ETag);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual("no-transform", blob2.Properties.CacheControl);
                Assert.AreEqual("gzip", blob2.Properties.ContentEncoding);
                Assert.AreEqual("tr,en", blob2.Properties.ContentLanguage);
                Assert.AreEqual("MDAwMDAwMDA=", blob2.Properties.ContentMD5);
                Assert.AreEqual("text/html", blob2.Properties.ContentType);

                CloudBlockBlob blob3 = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        DisableContentMD5Validation = true,
                    };
                    blob3.DownloadToStream(stream, null, options);
                }
                AssertAreEqual(blob2.Properties, blob3.Properties);

                CloudBlockBlob blob4 = (CloudBlockBlob)container.ListBlobs().First();
                AssertAreEqual(blob2.Properties, blob4.Properties);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Verify setting the properties of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetPropertiesAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                    CreateForTest(blob, 1, 1024, true);
                    string eTag = blob.Properties.ETag;
                    DateTimeOffset lastModified = blob.Properties.LastModified.Value;

                    Thread.Sleep(1000);

                    blob.Properties.CacheControl = "no-transform";
                    blob.Properties.ContentEncoding = "gzip";
                    blob.Properties.ContentLanguage = "tr,en";
                    blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                    blob.Properties.ContentType = "text/html";
                    IAsyncResult result = blob.BeginSetProperties(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob.EndSetProperties(result);
                    Assert.IsTrue(blob.Properties.LastModified > lastModified);
                    Assert.AreNotEqual(eTag, blob.Properties.ETag);

                    CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                    result = blob2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob2.EndFetchAttributes(result);
                    Assert.AreEqual("no-transform", blob2.Properties.CacheControl);
                    Assert.AreEqual("gzip", blob2.Properties.ContentEncoding);
                    Assert.AreEqual("tr,en", blob2.Properties.ContentLanguage);
                    Assert.AreEqual("MDAwMDAwMDA=", blob2.Properties.ContentMD5);
                    Assert.AreEqual("text/html", blob2.Properties.ContentType);

                    CloudBlockBlob blob3 = container.GetBlockBlobReference("blob1");
                    using (MemoryStream stream = new MemoryStream())
                    {
                        BlobRequestOptions options = new BlobRequestOptions()
                        {
                            DisableContentMD5Validation = true,
                        };
                        result = blob3.BeginDownloadToStream(stream, null, options, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob3.EndDownloadToStream(result);
                    }
                    AssertAreEqual(blob2.Properties, blob3.Properties);

                    result = container.BeginListBlobsSegmented(null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    BlobResultSegment results = container.EndListBlobsSegmented(result);
                    CloudBlockBlob blob4 = (CloudBlockBlob)results.Results.First();
                    AssertAreEqual(blob2.Properties, blob4.Properties);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Verify setting the properties of a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetPropertiesTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTestTask(blob, 1, 1024);
                string eTag = blob.Properties.ETag;
                DateTimeOffset lastModified = blob.Properties.LastModified.Value;

                Thread.Sleep(1000);

                blob.Properties.CacheControl = "no-transform";
                blob.Properties.ContentEncoding = "gzip";
                blob.Properties.ContentLanguage = "tr,en";
                blob.Properties.ContentMD5 = "MDAwMDAwMDA=";
                blob.Properties.ContentType = "text/html";
                blob.SetPropertiesAsync().Wait();
                Assert.IsTrue(blob.Properties.LastModified > lastModified);
                Assert.AreNotEqual(eTag, blob.Properties.ETag);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual("no-transform", blob2.Properties.CacheControl);
                Assert.AreEqual("gzip", blob2.Properties.ContentEncoding);
                Assert.AreEqual("tr,en", blob2.Properties.ContentLanguage);
                Assert.AreEqual("MDAwMDAwMDA=", blob2.Properties.ContentMD5);
                Assert.AreEqual("text/html", blob2.Properties.ContentType);

                CloudBlockBlob blob3 = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        DisableContentMD5Validation = true,
                    };
                    blob3.DownloadToStreamAsync(stream, null, options, null).Wait();
                }
                AssertAreEqual(blob2.Properties, blob3.Properties);

                CloudBlockBlob blob4 = (CloudBlockBlob)container.ListBlobsSegmentedAsync(null).Result.Results.First();
                AssertAreEqual(blob2.Properties, blob4.Properties);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Try retrieving properties of a block blob using a page blob reference")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobFetchAttributesInvalidType()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, false);

                CloudPageBlob blob2 = container.GetPageBlobReference("blob1");
                StorageException e = TestHelper.ExpectedException<StorageException>(
                    () => blob2.FetchAttributes(),
                    "Fetching attributes of a block blob using a page blob reference should fail");
                Assert.IsInstanceOfType(e.InnerException, typeof(InvalidOperationException));
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Verify that creating a block blob can also set its metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCreateWithMetadata()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.Metadata["key1"] = "value1";
                CreateForTest(blob, 0, 0, false);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual(1, blob2.Metadata.Count);
                Assert.AreEqual("value1", blob2.Metadata["key1"]);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Verify that a block blob's metadata can be updated")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetMetadata()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 0, 0, false);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual(0, blob2.Metadata.Count);

                blob.Metadata["key1"] = null;
                StorageException e = TestHelper.ExpectedException<StorageException>(
                    () => blob.SetMetadata(),
                    "Metadata keys should have a non-null value");
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "";
                e = TestHelper.ExpectedException<StorageException>(
                    () => blob.SetMetadata(),
                    "Metadata keys should have a non-empty value");
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "value1";
                blob.SetMetadata();

                blob2.FetchAttributes();
                Assert.AreEqual(1, blob2.Metadata.Count);
                Assert.AreEqual("value1", blob2.Metadata["key1"]);

                CloudBlockBlob blob3 = (CloudBlockBlob)container.ListBlobs(null, true, BlobListingDetails.Metadata, null, null).First();
                Assert.AreEqual(1, blob3.Metadata.Count);
                Assert.AreEqual("value1", blob3.Metadata["key1"]);

                blob.Metadata.Clear();
                blob.SetMetadata();

                blob2.FetchAttributes();
                Assert.AreEqual(0, blob2.Metadata.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Verify that a block blob's metadata can be updated")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetMetadataAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 0, 0, true);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                    IAsyncResult result = blob2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob2.EndFetchAttributes(result);
                    Assert.AreEqual(0, blob2.Metadata.Count);

                    blob.Metadata["key1"] = null;
                    result = blob.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Exception e = TestHelper.ExpectedException<StorageException>(
                        () => blob.EndSetMetadata(result),
                        "Metadata keys should have a non-null value");
                    Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                    blob.Metadata["key1"] = "";
                    result = blob.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    e = TestHelper.ExpectedException<StorageException>(
                        () => blob.EndSetMetadata(result),
                        "Metadata keys should have a non-empty value");
                    Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                    blob.Metadata["key1"] = "value1";
                    result = blob.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob.EndSetMetadata(result);

                    result = blob2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob2.EndFetchAttributes(result);
                    Assert.AreEqual(1, blob2.Metadata.Count);
                    Assert.AreEqual("value1", blob2.Metadata["key1"]);

                    result = container.BeginListBlobsSegmented(null, true, BlobListingDetails.Metadata, null, null, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    BlobResultSegment results = container.EndListBlobsSegmented(result);
                    CloudBlockBlob blob3 = (CloudBlockBlob)results.Results.First();
                    Assert.AreEqual(1, blob3.Metadata.Count);
                    Assert.AreEqual("value1", blob3.Metadata["key1"]);

                    blob.Metadata.Clear();
                    result = blob.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob.EndSetMetadata(result);

                    result = blob2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blob2.EndFetchAttributes(result);
                    Assert.AreEqual(0, blob2.Metadata.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Verify that a block blob's metadata can be updated")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSetMetadataTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTestTask(blob, 0, 0);

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual(0, blob2.Metadata.Count);

                blob.Metadata["key1"] = null;
                StorageException e = TestHelper.ExpectedExceptionTask<StorageException>(
                    blob.SetMetadataAsync(),
                    "Metadata keys should have a non-null value");
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "";
                e = TestHelper.ExpectedExceptionTask<StorageException>(
                    blob.SetMetadataAsync(),
                    "Metadata keys should have a non-empty value");
                Assert.IsInstanceOfType(e.InnerException, typeof(ArgumentException));

                blob.Metadata["key1"] = "value1";
                blob.SetMetadataAsync().Wait();

                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual(1, blob2.Metadata.Count);
                Assert.AreEqual("value1", blob2.Metadata["key1"]);

                CloudBlockBlob blob3 =
                    (CloudBlockBlob)
                    container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.Metadata, null, null, null, null)
                             .Result
                             .Results
                             .First();

                Assert.AreEqual(1, blob3.Metadata.Count);
                Assert.AreEqual("value1", blob3.Metadata["key1"]);

                blob.Metadata.Clear();
                blob.SetMetadataAsync().Wait();

                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual(0, blob2.Metadata.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Upload blocks and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUpload()
        {
            CloudBlockBlobUpload(true, false);
        }

        [TestMethod]
        [Description("Upload blocks with non-seekable stream and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadWithNonSeekableStream()
        {
            CloudBlockBlobUpload(false, false);
        }

        [TestMethod]
        [Description("Upload blocks and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadAPM()
        {
            CloudBlockBlobUpload(true, true);
        }

        [TestMethod]
        [Description("Upload blocks with non-seekable stream and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadWithNonSeekableStreamAPM()
        {
            CloudBlockBlobUpload(false, true);
        }

        private void CloudBlockBlobUpload(bool seekableSourceStream, bool isAsync)
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        foreach (string block in blocks)
                        {
                            using (Stream memoryStream = seekableSourceStream ? new MemoryStream(buffer) : new NonSeekableMemoryStream(buffer))
                            {
                                if (isAsync)
                                {
                                    IAsyncResult result = blob.BeginPutBlock(block, memoryStream, null,
                                        ar => waitHandle.Set(),
                                        null);
                                    waitHandle.WaitOne();
                                    blob.EndPutBlock(result);
                                }
                                else
                                {
                                    blob.PutBlock(block, memoryStream, null);
                                }
                            }
                            wholeBlob.Write(buffer, 0, buffer.Length);
                        }

                        foreach (string block in extraBlocks)
                        {
                            using (Stream memoryStream = seekableSourceStream ? new MemoryStream(buffer) : new NonSeekableMemoryStream(buffer))
                            {
                                if (isAsync)
                                {
                                    IAsyncResult result = blob.BeginPutBlock(block, memoryStream, null,
                                        ar => waitHandle.Set(),
                                        null);
                                    waitHandle.WaitOne();
                                    blob.EndPutBlock(result);
                                }
                                else
                                {
                                    blob.PutBlock(block, memoryStream, null);
                                }
                            }
                        }

                        if (isAsync)
                        {
                            IAsyncResult result = blob.BeginPutBlockList(blocks,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndPutBlockList(result);
                        }
                        else
                        {
                            blob.PutBlockList(blocks);
                        }
                    }

                    CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob2.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Upload blocks and then commit the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadTask()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                    foreach (string block in blocks)
                    {
                        using (Stream memoryStream = new MemoryStream(buffer))
                        {
                            blob.PutBlockAsync(block, memoryStream, null).Wait();
                        }
                        wholeBlob.Write(buffer, 0, buffer.Length);
                    }

                    foreach (string block in extraBlocks)
                    {
                        using (Stream memoryStream = new MemoryStream(buffer))
                        {
                            blob.PutBlockAsync(block, memoryStream, null).Wait();
                        }
                    }
                    blob.PutBlockListAsync(blocks).Wait();
                    
                    CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob2.DownloadToStreamAsync(downloadedBlob).Wait();
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Upload a block blob and then verify the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadBlockList()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                foreach (string block in blocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlock(block, memoryStream, null);
                    }
                }
                blob.PutBlockList(blocks);

                foreach (string block in extraBlocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlock(block, memoryStream, null);
                    }
                }

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual(1024 * blocks.Count, blob2.Properties.Length);

                IEnumerable<ListBlockItem> blockList = blob2.DownloadBlockList();
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsTrue(blockItem.Committed);
                    Assert.IsTrue(blocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, blocks.Count);

                blockList = blob2.DownloadBlockList(BlockListingFilter.Uncommitted, null, null, null);
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsFalse(blockItem.Committed);
                    Assert.IsTrue(extraBlocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, extraBlocks.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a block blob and then verify the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadBlockListAPM()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                foreach (string block in blocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlock(block, memoryStream, null);
                    }
                }
                blob.PutBlockList(blocks);

                foreach (string block in extraBlocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlock(block, memoryStream, null);
                    }
                }

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributes();
                Assert.AreEqual(1024 * blocks.Count, blob2.Properties.Length);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = blob2.BeginDownloadBlockList(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    IEnumerable<ListBlockItem> blockList = blob2.EndDownloadBlockList(result);
                    foreach (ListBlockItem blockItem in blockList)
                    {
                        Assert.IsTrue(blockItem.Committed);
                        Assert.IsTrue(blocks.Remove(blockItem.Name));
                    }
                    Assert.AreEqual(0, blocks.Count);

                    result = blob2.BeginDownloadBlockList(BlockListingFilter.Uncommitted, null, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blockList = blob2.EndDownloadBlockList(result);
                    foreach (ListBlockItem blockItem in blockList)
                    {
                        Assert.IsFalse(blockItem.Committed);
                        Assert.IsTrue(extraBlocks.Remove(blockItem.Name));
                    }
                    Assert.AreEqual(0, extraBlocks.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Upload a block blob and then verify the block list")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadBlockListTask()
        {
            byte[] buffer = GetRandomBuffer(1024);
            List<string> blocks = GetBlockIdList(3);
            List<string> extraBlocks = GetBlockIdList(2);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                foreach (string block in blocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlockAsync(block, memoryStream, null).Wait();
                    }
                }
                blob.PutBlockListAsync(blocks).Wait();

                foreach (string block in extraBlocks)
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        blob.PutBlockAsync(block, memoryStream, null).Wait();
                    }
                }

                CloudBlockBlob blob2 = container.GetBlockBlobReference("blob1");
                blob2.FetchAttributesAsync().Wait();
                Assert.AreEqual(1024 * blocks.Count, blob2.Properties.Length);

                IEnumerable<ListBlockItem> blockList = blob2.DownloadBlockListAsync().Result;
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsTrue(blockItem.Committed);
                    Assert.IsTrue(blocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, blocks.Count);

                blockList = blob2.DownloadBlockListAsync(BlockListingFilter.Uncommitted, null, null, null).Result;
                foreach (ListBlockItem blockItem in blockList)
                {
                    Assert.IsFalse(blockItem.Committed);
                    Assert.IsTrue(extraBlocks.Remove(blockItem.Name));
                }
                Assert.AreEqual(0, extraBlocks.Count);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStream()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStream(originalBlob);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamAPM()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        using (MemoryStream downloadedBlob = new MemoryStream())
                        {
                            result = blob.BeginDownloadToStream(downloadedBlob,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndDownloadToStream(result);
                            TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
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
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamAPMOverload()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        ICancellableAsyncResult result = blob.BeginUploadFromStream(originalBlob,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadFromStream(result);

                        using (MemoryStream downloadedBlob = new MemoryStream())
                        {
                            OperationContext context = new OperationContext();
                            result = blob.BeginDownloadRangeToStream(downloadedBlob,
                                0, /* offset */
                                buffer.Length, /* Length */
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndDownloadRangeToStream(result);
                            TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                        }
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamTask()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStreamAsync(originalBlob).Wait();

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStreamAsync(downloadedBlob).Wait();
                        TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobDownloadToStreamOverloadTask()
        {
            byte[] buffer = GetRandomBuffer(1 * 1024 * 1024);
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream originalBlob = new MemoryStream(buffer))
                {
                    blob.UploadFromStreamAsync(originalBlob).Wait();

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        OperationContext context = new OperationContext();
                        blob.DownloadRangeToStreamAsync(downloadedBlob, 0, buffer.Length).Wait();
                        TestHelper.AssertStreamsAreEqual(originalBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExistsAsync();
            }
        }
#endif

        [TestMethod]
        [Description("Single put blob with invalid options")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamInvalidOptions()
        {
            BlobRequestOptions options = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
                StoreBlobContentMD5 = false,
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    TestHelper.ExpectedException<ArgumentException>(
                        () => blob.UploadFromStream(stream, null, options, null),
                        "Single put blob with mismatching MD5 options should fail immediately");
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Single put blob with invalid options")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamAPMInvalidOptions()
        {
            BlobRequestOptions options = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
                StoreBlobContentMD5 = false,
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    TestHelper.ExpectedException<ArgumentException>(
                        () => blob.BeginUploadFromStream(stream, null, options, null, null, null),
                        "Single put blob with mismatching MD5 options should fail immediately");
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Single put blob with invalid options")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamInvalidOptionsTask()
        {
            BlobRequestOptions options = new BlobRequestOptions()
            {
                UseTransactionalMD5 = true,
                StoreBlobContentMD5 = false,
            };

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream stream = new MemoryStream())
                {
                    TestHelper.ExpectedException<ArgumentException>(
                        () => blob.UploadFromStreamAsync(stream, null, options, null),
                        "Single put blob with mismatching MD5 options should fail immediately");
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                AccessCondition accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, false, true);

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, false);
                blob.FetchAttributes();
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, false, true),
                    "Uploading a blob on top of an existing blob should fail if the ETag matches",
                    HttpStatusCode.PreconditionFailed);
                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, false, true);

                blob = container.GetBlockBlobReference("blob3");
                CreateForTest(blob, 1, 1024, false);
                blob.FetchAttributes();
                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, false, true),
                    "Uploading a blob on top of an non-existing blob should fail when the ETag doesn't match",
                    HttpStatusCode.PreconditionFailed);
                TestHelper.ExpectedException(
                    () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, false, true),
                    "Uploading a blob on top of an non-existing blob should fail when the ETag doesn't match",
                    HttpStatusCode.NotFound);
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, false, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamAPMWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                AccessCondition accessCondition = AccessCondition.GenerateIfNoneMatchCondition("\"*\"");
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, true, true);

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 1, 1024, false);
                blob.FetchAttributes();
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, true, true),
                    "Uploading a blob on top of an existing blob should fail if the ETag matches",
                    HttpStatusCode.PreconditionFailed);
                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, true, true);

                blob = container.GetBlockBlobReference("blob3");
                CreateForTest(blob, 1, 1024, false);
                blob.FetchAttributes();
                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                   () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, true, true),
                   "Uploading a blob on top of an non-existing blob should fail when the ETag doesn't match",
                   HttpStatusCode.PreconditionFailed);
                TestHelper.ExpectedException(
                    () => this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, true, true),
                    "Uploading a blob on top of an non-existing blob should fail when the ETag doesn't match",
                    HttpStatusCode.NotFound);

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 2 * 1024 * 1024, null, accessCondition, true, false, 0, true, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamWithNonSeekableStream()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, true, 1024, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, false, 1024, false, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamAPMWithNonSeekableStream()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, true, 1024, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, false, false, 1024, true, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStream()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, true, 1024, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, false, 1024, false, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, true, 1024, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, null, null, true, false, 1024, true, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamLength()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                // Upload 2MB of a 5MB stream
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, true, 1024, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, false, 1024, false, true);

                // Exclude last byte
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024 - 1, null, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024 - 1, null, true, true, 1024, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024 - 1, null, true, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024 - 1, null, true, false, 1024, false, true);

                // Upload exact amount
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024, null, true, true, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024, null, true, true, 1024, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024, null, true, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024, null, true, false, 1024, false, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamLengthAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                // Upload 2MB of a 5MB stream
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, true, 1024, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 2 * 1024 * 1024, null, true, false, 1024, true, true);

                // Exclude last byte
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024 - 1, null, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024 - 1, null, true, true, 1024, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024 - 1, null, true, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024 - 1, null, true, false, 1024, true, true);

                // Upload exact amount
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024, null, true, true, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024, null, true, true, 1024, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 5 * 1024 * 1024, null, true, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 5 * 1024 * 1024, 4 * 1024 * 1024, null, true, false, 1024, true, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamLengthInvalid()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, true, true, 0, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, true, true, 1024, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, false, true, 0, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, false, true, 1024, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, true, false, 0, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, true, false, 1024, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, false, false, 0, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, false, false, 1024, false, false),
                    "The given stream does not contain the requested number of bytes from its given position.");
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Single put blob and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadFromStreamLengthInvalidAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            try
            {
                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, true, true, 0, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, true, true, 1024, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, false, true, 0, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, false, true, 1024, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, true, false, 0, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, true, false, 1024, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 + 1, null, false, false, 0, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");

                TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                    () =>
                    this.CloudBlockBlobUploadFromStream(
                        container, 2 * 1024 * 1024, 2 * 1024 * 1024 - 1023, null, false, false, 1024, true, false),
                    "The given stream does not contain the requested number of bytes from its given position.");
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Upload blob using multiple threads and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobParallelUploadFromStream()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 8;
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 16 * 1024 * 1024, null, null, true, false, 0, false, true);
                this.CloudBlockBlobUploadFromStream(container, 16 * 1024 * 1024, null, null, true, false, 1024, false, true);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Upload blob using multiple threads and get blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobParallelUploadFromStreamAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 8;
            container.Create();
            try
            {
                this.CloudBlockBlobUploadFromStream(container, 16 * 1024 * 1024, null, null, true, false, 0, true, true);
                this.CloudBlockBlobUploadFromStream(container, 16 * 1024 * 1024, null, null, true, false, 1024, true, true);
            }
            finally
            {
                container.Delete();
            }
        }

        private void CloudBlockBlobUploadFromStream(CloudBlobContainer container, int size, long? copyLength, AccessCondition accessCondition, bool seekableSourceStream, bool allowSinglePut, int startOffset, bool isAsync, bool testMd5)
        {
            byte[] buffer = GetRandomBuffer(size);

            MD5 hasher = MD5.Create();

            string md5 = string.Empty;
            if (testMd5)
            {
                md5 = Convert.ToBase64String(hasher.ComputeHash(buffer, startOffset, copyLength.HasValue ? (int)copyLength : buffer.Length - startOffset));
            }

            CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
            blob.ServiceClient.SingleBlobUploadThresholdInBytes = allowSinglePut ? buffer.Length : buffer.Length / 2;
            blob.StreamWriteSizeInBytes = 1 * 1024 * 1024;

            using (MemoryStream originalBlobStream = new MemoryStream())
            {
                originalBlobStream.Write(buffer, startOffset, buffer.Length - startOffset);

                Stream sourceStream;
                if (seekableSourceStream)
                {
                    MemoryStream stream = new MemoryStream(buffer);
                    stream.Seek(startOffset, SeekOrigin.Begin);
                    sourceStream = stream;
                }
                else
                {
                    NonSeekableMemoryStream stream = new NonSeekableMemoryStream(buffer);
                    stream.ForceSeek(startOffset, SeekOrigin.Begin);
                    sourceStream = stream;
                }

                using (sourceStream)
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    if (isAsync)
                    {
                        using (ManualResetEvent waitHandle = new ManualResetEvent(false))
                        {
                            if (copyLength.HasValue)
                            {
                                ICancellableAsyncResult result = blob.BeginUploadFromStream(
                                    sourceStream, copyLength.Value, accessCondition, options, null, ar => waitHandle.Set(), null);
                                waitHandle.WaitOne();
                                blob.EndUploadFromStream(result);
                            }
                            else
                            {
                                ICancellableAsyncResult result = blob.BeginUploadFromStream(
                                    sourceStream, accessCondition, options, null, ar => waitHandle.Set(), null);
                                waitHandle.WaitOne();
                                blob.EndUploadFromStream(result);
                            }
                        }
                    }
                    else
                    {
                        if (copyLength.HasValue)
                        {
                            blob.UploadFromStream(sourceStream, copyLength.Value, accessCondition, options);
                        }
                        else
                        {
                            blob.UploadFromStream(sourceStream, accessCondition, options);
                        }
                    }
                }

                blob.FetchAttributes();

                if (testMd5)
                {
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);
                }

                using (MemoryStream downloadedBlobStream = new MemoryStream())
                {
                    if (isAsync)
                    {
                        using (ManualResetEvent waitHandle = new ManualResetEvent(false))
                        {
                            ICancellableAsyncResult result = blob.BeginDownloadToStream(
                                downloadedBlobStream, ar => waitHandle.Set(), null);
                            waitHandle.WaitOne();
                            blob.EndDownloadToStream(result);
                        }
                    }
                    else
                    {
                        blob.DownloadToStream(downloadedBlobStream);
                    }

                    Assert.AreEqual(copyLength ?? originalBlobStream.Length, downloadedBlobStream.Length);
                    TestHelper.AssertStreamsAreEqualAtIndex(
                        originalBlobStream,
                        downloadedBlobStream,
                        0,
                        0,
                        copyLength.HasValue ? (int)copyLength : (int)originalBlobStream.Length);
                }
            }

            blob.Delete();
        }

        [TestMethod]
        [Description("Create snapshots of a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshot()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                MemoryStream originalData = new MemoryStream(GetRandomBuffer(1024));
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.UploadFromStream(originalData);
                Assert.IsFalse(blob.IsSnapshot);
                Assert.IsNull(blob.SnapshotTime, "Root blob has SnapshotTime set");
                Assert.IsFalse(blob.SnapshotQualifiedUri.Query.Contains("snapshot"));
                Assert.AreEqual(blob.Uri, blob.SnapshotQualifiedUri);

                CloudBlockBlob snapshot1 = blob.CreateSnapshot();
                Assert.AreEqual(blob.Properties.ETag, snapshot1.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, snapshot1.Properties.LastModified);
                Assert.IsTrue(snapshot1.IsSnapshot);
                Assert.IsNotNull(snapshot1.SnapshotTime, "Snapshot does not have SnapshotTime set");
                Assert.AreEqual(blob.Uri, snapshot1.Uri);
                Assert.AreNotEqual(blob.SnapshotQualifiedUri, snapshot1.SnapshotQualifiedUri);
                Assert.AreNotEqual(snapshot1.Uri, snapshot1.SnapshotQualifiedUri);
                Assert.IsTrue(snapshot1.SnapshotQualifiedUri.Query.Contains("snapshot"));

                CloudBlockBlob snapshot2 = blob.CreateSnapshot();
                Assert.IsTrue(snapshot2.SnapshotTime.Value > snapshot1.SnapshotTime.Value);

                snapshot1.FetchAttributes();
                snapshot2.FetchAttributes();
                blob.FetchAttributes();
                AssertAreEqual(snapshot1.Properties, blob.Properties);

                CloudBlockBlob snapshot1Clone = new CloudBlockBlob(new Uri(blob.Uri + "?snapshot=" + snapshot1.SnapshotTime.Value.ToString("O")), blob.ServiceClient.Credentials);
                Assert.IsNotNull(snapshot1Clone.SnapshotTime, "Snapshot clone does not have SnapshotTime set");
                Assert.AreEqual(snapshot1.SnapshotTime.Value, snapshot1Clone.SnapshotTime.Value);
                snapshot1Clone.FetchAttributes();
                AssertAreEqual(snapshot1.Properties, snapshot1Clone.Properties);

                CloudBlockBlob snapshotCopy = container.GetBlockBlobReference("blob2");
                snapshotCopy.StartCopyFromBlob(TestHelper.Defiddler(snapshot1.Uri));
                WaitForCopy(snapshotCopy);
                Assert.AreEqual(CopyStatus.Success, snapshotCopy.CopyState.Status);

                TestHelper.ExpectedException<InvalidOperationException>(
                    () => snapshot1.OpenWrite(),
                    "Trying to write to a blob snapshot should fail");

                using (Stream snapshotStream = snapshot1.OpenRead())
                {
                    snapshotStream.Seek(0, SeekOrigin.End);
                    TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                }

                blob.PutBlockList(new List<string>());
                blob.FetchAttributes();

                using (Stream snapshotStream = snapshot1.OpenRead())
                {
                    snapshotStream.Seek(0, SeekOrigin.End);
                    TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                }

                List<IListBlobItem> blobs = container.ListBlobs(null, true, BlobListingDetails.All, null, null).ToList();
                Assert.AreEqual(4, blobs.Count);
                AssertAreEqual(snapshot1, (ICloudBlob)blobs[0]);
                AssertAreEqual(snapshot2, (ICloudBlob)blobs[1]);
                AssertAreEqual(blob, (ICloudBlob)blobs[2]);
                AssertAreEqual(snapshotCopy, (ICloudBlob)blobs[3]);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create snapshots of a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshotAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                MemoryStream originalData = new MemoryStream(GetRandomBuffer(1024));
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                IAsyncResult result;
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    result = blob.BeginUploadFromStream(originalData, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    blob.EndUploadFromStream(result);
                    Assert.IsFalse(blob.IsSnapshot);
                    Assert.IsNull(blob.SnapshotTime, "Root blob has SnapshotTime set");
                    Assert.IsFalse(blob.SnapshotQualifiedUri.Query.Contains("snapshot"));
                    Assert.AreEqual(blob.Uri, blob.SnapshotQualifiedUri);

                    result = blob.BeginCreateSnapshot(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    CloudBlockBlob snapshot1 = blob.EndCreateSnapshot(result);
                    Assert.AreEqual(blob.Properties.ETag, snapshot1.Properties.ETag);
                    Assert.AreEqual(blob.Properties.LastModified, snapshot1.Properties.LastModified);
                    Assert.IsTrue(snapshot1.IsSnapshot);
                    Assert.IsNotNull(snapshot1.SnapshotTime, "Snapshot does not have SnapshotTime set");
                    Assert.AreEqual(blob.Uri, snapshot1.Uri);
                    Assert.AreNotEqual(blob.SnapshotQualifiedUri, snapshot1.SnapshotQualifiedUri);
                    Assert.AreNotEqual(snapshot1.Uri, snapshot1.SnapshotQualifiedUri);
                    Assert.IsTrue(snapshot1.SnapshotQualifiedUri.Query.Contains("snapshot"));

                    result = blob.BeginCreateSnapshot(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    CloudBlockBlob snapshot2 = blob.EndCreateSnapshot(result);
                    Assert.IsTrue(snapshot2.SnapshotTime.Value > snapshot1.SnapshotTime.Value);

                    snapshot1.FetchAttributes();
                    snapshot2.FetchAttributes();
                    blob.FetchAttributes();
                    AssertAreEqual(snapshot1.Properties, blob.Properties);

                    CloudBlockBlob snapshotCopy = container.GetBlockBlobReference("blob2");
                    result = snapshotCopy.BeginStartCopyFromBlob(snapshot1, null, null, null, null, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    snapshotCopy.EndStartCopyFromBlob(result);
                    WaitForCopy(snapshotCopy);
                    Assert.AreEqual(CopyStatus.Success, snapshotCopy.CopyState.Status);

                    TestHelper.ExpectedException<InvalidOperationException>(
                        () => snapshot1.BeginOpenWrite(ar => waitHandle.Set(), null),
                        "Trying to write to a blob snapshot should fail");

                    TestHelper.ExpectedException<InvalidOperationException>(
                        () => snapshot2.BeginOpenWrite(null, null, null, ar => waitHandle.Set(), null),
                        "Trying to write to a blob snapshot should fail");

                    result = snapshot1.BeginOpenRead(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    using (Stream snapshotStream = snapshot1.EndOpenRead(result))
                    {
                        snapshotStream.Seek(0, SeekOrigin.End);
                        TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                    }

                    result = blob.BeginPutBlockList(new List<string>(), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    blob.EndPutBlockList(result);

                    result = blob.BeginFetchAttributes(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    blob.EndFetchAttributes(result);

                    result = snapshot1.BeginOpenRead(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    using (Stream snapshotStream = snapshot1.EndOpenRead(result))
                    {
                        snapshotStream.Seek(0, SeekOrigin.End);
                        TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                    }

                    List<IListBlobItem> blobs = container.ListBlobs(null, true, BlobListingDetails.All, null, null).ToList();
                    Assert.AreEqual(4, blobs.Count);
                    AssertAreEqual(snapshot1, (ICloudBlob)blobs[0]);
                    AssertAreEqual(snapshot2, (ICloudBlob)blobs[1]);
                    AssertAreEqual(blob, (ICloudBlob)blobs[2]);
                    AssertAreEqual(snapshotCopy, (ICloudBlob)blobs[3]);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Create snapshots of a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshotTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                MemoryStream originalData = new MemoryStream(GetRandomBuffer(1024));
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                blob.UploadFromStreamAsync(originalData).Wait();
                Assert.IsFalse(blob.IsSnapshot);
                Assert.IsNull(blob.SnapshotTime, "Root blob has SnapshotTime set");
                Assert.IsFalse(blob.SnapshotQualifiedUri.Query.Contains("snapshot"));
                Assert.AreEqual(blob.Uri, blob.SnapshotQualifiedUri);

                CloudBlockBlob snapshot1 = blob.CreateSnapshotAsync().Result;
                Assert.AreEqual(blob.Properties.ETag, snapshot1.Properties.ETag);
                Assert.AreEqual(blob.Properties.LastModified, snapshot1.Properties.LastModified);
                Assert.IsTrue(snapshot1.IsSnapshot);
                Assert.IsNotNull(snapshot1.SnapshotTime, "Snapshot does not have SnapshotTime set");
                Assert.AreEqual(blob.Uri, snapshot1.Uri);
                Assert.AreNotEqual(blob.SnapshotQualifiedUri, snapshot1.SnapshotQualifiedUri);
                Assert.AreNotEqual(snapshot1.Uri, snapshot1.SnapshotQualifiedUri);
                Assert.IsTrue(snapshot1.SnapshotQualifiedUri.Query.Contains("snapshot"));

                CloudBlockBlob snapshot2 = blob.CreateSnapshotAsync().Result;
                Assert.IsTrue(snapshot2.SnapshotTime.Value > snapshot1.SnapshotTime.Value);

                snapshot1.FetchAttributesAsync().Wait();
                snapshot2.FetchAttributesAsync().Wait();
                blob.FetchAttributesAsync().Wait();
                AssertAreEqual(snapshot1.Properties, blob.Properties);

                CloudBlockBlob snapshotCopy = container.GetBlockBlobReference("blob2");
                snapshotCopy.StartCopyFromBlobAsync(snapshot1, null, null, null, null).Wait();
                bool copyInProgress = true;
                while (copyInProgress)
                {
                    Thread.Sleep(1000);
                    snapshotCopy.FetchAttributesAsync().Wait();
                    copyInProgress = (snapshotCopy.CopyState.Status == CopyStatus.Pending);
                }
                Assert.AreEqual(CopyStatus.Success, snapshotCopy.CopyState.Status);

                TestHelper.ExpectedException<InvalidOperationException>(
                    () => snapshot1.OpenWriteAsync(),
                    "Trying to write to a blob snapshot should fail");

                TestHelper.ExpectedException<InvalidOperationException>(
                    () => snapshot2.OpenWriteAsync(null, null, null),
                    "Trying to write to a blob snapshot should fail");

                using (Stream snapshotStream = snapshot1.OpenReadAsync().Result)
                {
                    snapshotStream.Seek(0, SeekOrigin.End);
                    TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                }

                blob.PutBlockListAsync(new List<string>()).Wait();

                blob.FetchAttributesAsync().Wait();

                using (Stream snapshotStream = snapshot1.OpenReadAsync().Result)
                {
                    snapshotStream.Seek(0, SeekOrigin.End);
                    TestHelper.AssertStreamsAreEqual(originalData, snapshotStream);
                }

                List<IListBlobItem> blobs =
                    container.ListBlobsSegmentedAsync(null, true, BlobListingDetails.All, null, null, null, null)
                             .Result
                             .Results
                             .ToList();

                Assert.AreEqual(4, blobs.Count);
                AssertAreEqual(snapshot1, (ICloudBlob)blobs[0]);
                AssertAreEqual(snapshot2, (ICloudBlob)blobs[1]);
                AssertAreEqual(blob, (ICloudBlob)blobs[2]);
                AssertAreEqual(snapshotCopy, (ICloudBlob)blobs[3]);
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Create a snapshot with explicit metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshotMetadata()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 2, 1024, false);

                blob.Metadata["Hello"] = "World";
                blob.Metadata["Marco"] = "Polo";
                blob.SetMetadata();

                IDictionary<string, string> snapshotMetadata = new Dictionary<string, string>();
                snapshotMetadata["Hello"] = "Dolly";
                snapshotMetadata["Yoyo"] = "Ma";

                CloudBlockBlob snapshot = blob.CreateSnapshot(snapshotMetadata);

                // Test the client view against the expected metadata
                // None of the original metadata should be present
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));

                // Test the server view against the expected metadata
                snapshot.FetchAttributes();
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a snapshot with explicit metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshotMetadataAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 2, 1024, false);

                blob.Metadata["Hello"] = "World";
                blob.Metadata["Marco"] = "Polo";
                blob.SetMetadata();

                IDictionary<string, string> snapshotMetadata = new Dictionary<string, string>();
                snapshotMetadata["Hello"] = "Dolly";
                snapshotMetadata["Yoyo"] = "Ma";

                IAsyncResult result;
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    OperationContext context = new OperationContext();
                    result = blob.BeginCreateSnapshot(snapshotMetadata, null, null, context, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    CloudBlockBlob snapshot = blob.EndCreateSnapshot(result);

                    // Test the client view against the expected metadata
                    // None of the original metadata should be present
                    Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                    Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                    Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));

                    // Test the server view against the expected metadata
                    snapshot.FetchAttributes();
                    Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                    Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                    Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Create a snapshot with explicit metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobSnapshotMetadataTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTestTask(blob, 2, 1024);

                blob.Metadata["Hello"] = "World";
                blob.Metadata["Marco"] = "Polo";
                blob.SetMetadataAsync().Wait();

                IDictionary<string, string> snapshotMetadata = new Dictionary<string, string>();
                snapshotMetadata["Hello"] = "Dolly";
                snapshotMetadata["Yoyo"] = "Ma";

                CloudBlockBlob snapshot = blob.CreateSnapshotAsync(snapshotMetadata, null, null, null).Result;

                // Test the client view against the expected metadata
                // None of the original metadata should be present
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));

                // Test the server view against the expected metadata
                snapshot.FetchAttributesAsync().Wait();
                Assert.AreEqual("Dolly", snapshot.Metadata["Hello"]);
                Assert.AreEqual("Ma", snapshot.Metadata["Yoyo"]);
                Assert.IsFalse(snapshot.Metadata.ContainsKey("Marco"));
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Test conditional access on a blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobConditionalAccess()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                CreateForTest(blob, 2, 1024, false);
                blob.FetchAttributes();

                string currentETag = blob.Properties.ETag;
                DateTimeOffset currentModifiedTime = blob.Properties.LastModified.Value;

                // ETag conditional tests
                blob.Metadata["ETagConditionalName"] = "ETagConditionalValue";
                blob.SetMetadata(AccessCondition.GenerateIfMatchCondition(currentETag), null);

                blob.FetchAttributes();
                string newETag = blob.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");

                blob.Metadata["ETagConditionalName"] = "ETagConditionalValue2";

                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfNoneMatchCondition(newETag), null),
                    "If none match on conditional test should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                string invalidETag = "\"0x10101010\"";
                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfMatchCondition(invalidETag), null),
                    "Invalid ETag on conditional test should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                currentETag = blob.Properties.ETag;
                blob.SetMetadata(AccessCondition.GenerateIfNoneMatchCondition(invalidETag), null);

                blob.FetchAttributes();
                newETag = blob.Properties.ETag;

                // LastModifiedTime tests
                currentModifiedTime = blob.Properties.LastModified.Value;

                blob.Metadata["DateConditionalName"] = "DateConditionalValue";

                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(currentModifiedTime), null),
                    "IfModifiedSince conditional on current modified time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                DateTimeOffset pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                blob.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                blob.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                blob.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                currentModifiedTime = blob.Properties.LastModified.Value;

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null),
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null),
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                TestHelper.ExpectedException(
                    () => blob.SetMetadata(AccessCondition.GenerateIfNotModifiedSinceCondition(pastTime), null),
                    "IfNotModifiedSince conditional on past time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                blob.Metadata["DateConditionalName"] = "DateConditionalValue2";

                currentETag = blob.Properties.ETag;
                blob.SetMetadata(AccessCondition.GenerateIfNotModifiedSinceCondition(currentModifiedTime), null);

                blob.FetchAttributes();
                newETag = blob.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Put block boundaries")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobPutBlockBoundaries()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                string blockId = GetBlockIdList(1).First();

                byte[] buffer = new byte[0];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    TestHelper.ExpectedException(
                        () => blob.PutBlock(blockId, stream, null),
                        "Trying to upload a block with zero bytes should fail",
                        HttpStatusCode.BadRequest);
                }

                buffer = new byte[1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.PutBlock(blockId, stream, null);
                }

                buffer = new byte[4 * 1024 * 1024];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.PutBlock(blockId, stream, null);
                }

                buffer = new byte[4 * 1024 * 1024 + 1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    TestHelper.ExpectedException(
                        () => blob.PutBlock(blockId, stream, null),
                        "Trying to upload a block with more than 4MB should fail",
                        HttpStatusCode.RequestEntityTooLarge);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Put block boundaries")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobPutBlockBoundariesAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                string blockId = GetBlockIdList(1).First();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;
                    byte[] buffer = new byte[0];
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        result = blob.BeginPutBlock(blockId, stream, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        TestHelper.ExpectedException(
                            () => blob.EndPutBlock(result),
                            "Trying to upload a block with zero bytes should fail",
                            HttpStatusCode.BadRequest);
                    }

                    buffer = new byte[1];
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        result = blob.BeginPutBlock(blockId, stream, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndPutBlock(result);
                    }

                    buffer = new byte[4 * 1024 * 1024];
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        result = blob.BeginPutBlock(blockId, stream, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndPutBlock(result);
                    }

                    buffer = new byte[4 * 1024 * 1024 + 1];
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        result = blob.BeginPutBlock(blockId, stream, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        TestHelper.ExpectedException(
                            () => blob.EndPutBlock(result),
                            "Trying to upload a block with more than 4MB should fail",
                            HttpStatusCode.RequestEntityTooLarge);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Put block boundaries")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobPutBlockBoundariesTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                string blockId = GetBlockIdList(1).First();

                byte[] buffer = new byte[0];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    TestHelper.ExpectedExceptionTask(
                        blob.PutBlockAsync(blockId, stream, null),
                        "Trying to upload a block with zero bytes should fail",
                        HttpStatusCode.BadRequest);
                }

                buffer = new byte[1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.PutBlockAsync(blockId, stream, null).Wait();
                }

                buffer = new byte[4 * 1024 * 1024];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    blob.PutBlockAsync(blockId, stream, null).Wait();
                }

                buffer = new byte[4 * 1024 * 1024 + 1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    TestHelper.ExpectedExceptionTask(
                        blob.PutBlockAsync(blockId, stream, null),
                        "Trying to upload a block with more than 4MB should fail",
                        HttpStatusCode.RequestEntityTooLarge);
                }
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Upload blocks and then verify the contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobPutBlock()
        {
            byte[] buffer = GetRandomBuffer(4 * 1024 * 1024);
            MD5 md5 = MD5.Create();
            string contentMD5 = Convert.ToBase64String(md5.ComputeHash(buffer));

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                List<string> blockList = GetBlockIdList(2);

                using (MemoryStream resultingData = new MemoryStream())
                {
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        blob.PutBlock(blockList[0], memoryStream, contentMD5);
                        resultingData.Write(buffer, 0, buffer.Length);

                        int offset = buffer.Length - 1024;
                        memoryStream.Seek(offset, SeekOrigin.Begin);
                        TestHelper.ExpectedException(
                            () => blob.PutBlock(blockList[1], memoryStream, contentMD5),
                            "Invalid MD5 should fail with mismatch",
                            HttpStatusCode.BadRequest,
                            "Md5Mismatch");

                        memoryStream.Seek(offset, SeekOrigin.Begin);
                        blob.PutBlock(blockList[1], memoryStream, null);
                        resultingData.Write(buffer, offset, buffer.Length - offset);
                    }

                    blob.PutBlockList(blockList);

                    using (MemoryStream blobData = new MemoryStream())
                    {
                        blob.DownloadToStream(blobData);
                        Assert.AreEqual(resultingData.Length, blobData.Length);

                        Assert.IsTrue(blobData.ToArray().SequenceEqual(resultingData.ToArray()));
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload blocks and then verify the contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobPutBlockAPM()
        {
            byte[] buffer = GetRandomBuffer(4 * 1024 * 1024);
            MD5 md5 = MD5.Create();
            string contentMD5 = Convert.ToBase64String(md5.ComputeHash(buffer));

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                List<string> blockList = GetBlockIdList(2);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result;

                    using (MemoryStream resultingData = new MemoryStream())
                    {
                        using (MemoryStream memoryStream = new MemoryStream(buffer))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            result = blob.BeginPutBlock(blockList[0], memoryStream, contentMD5,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndPutBlock(result);
                            resultingData.Write(buffer, 0, buffer.Length);

                            int offset = buffer.Length - 1024;
                            memoryStream.Seek(offset, SeekOrigin.Begin);
                            result = blob.BeginPutBlock(blockList[1], memoryStream, contentMD5,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            TestHelper.ExpectedException(
                                () => blob.EndPutBlock(result),
                                "Invalid MD5 should fail with mismatch",
                                HttpStatusCode.BadRequest,
                                "Md5Mismatch");

                            memoryStream.Seek(offset, SeekOrigin.Begin);
                            result = blob.BeginPutBlock(blockList[1], memoryStream, null,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            blob.EndPutBlock(result);
                            resultingData.Write(buffer, offset, buffer.Length - offset);
                        }

                        blob.PutBlockList(blockList);

                        using (MemoryStream blobData = new MemoryStream())
                        {
                            blob.DownloadToStream(blobData);
                            Assert.AreEqual(resultingData.Length, blobData.Length);

                            Assert.IsTrue(blobData.ToArray().SequenceEqual(resultingData.ToArray()));
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
        [Description("Test block blob methods on a page blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobMethodsOnPageBlob()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                List<string> blobs = CreateBlobs(container, 1, BlobType.PageBlob);
                CloudBlockBlob blob = container.GetBlockBlobReference(blobs.First());
                List<string> blockList = GetBlockIdList(1);

                byte[] buffer = new byte[1];
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    TestHelper.ExpectedException(
                        () => blob.PutBlock(blockList.First(), stream, null),
                        "Block operations should fail on page blobs",
                        HttpStatusCode.Conflict,
                        "InvalidBlobType");
                }

                TestHelper.ExpectedException(
                    () => blob.PutBlockList(blockList),
                    "Block operations should fail on page blobs",
                    HttpStatusCode.Conflict,
                    "InvalidBlobType");

                TestHelper.ExpectedException(
                    () => blob.DownloadBlockList(),
                    "Block operations should fail on page blobs",
                    HttpStatusCode.Conflict,
                    "InvalidBlobType");
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test block removal/addition/reordering in a block blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobBlockReordering()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                List<string> originalBlockIds = GetBlockIdList(10);
                List<string> blockIds = new List<string>(originalBlockIds);
                List<byte[]> blocks = new List<byte[]>();
                for (int i = 0; i < blockIds.Count; i++)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(i.ToString());
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        blob.PutBlock(blockIds[i], stream, null);
                    }
                    blocks.Add(buffer);
                }
                blob.PutBlockList(blockIds);
                Assert.AreEqual("0123456789", DownloadText(blob, Encoding.UTF8));

                blockIds.RemoveAt(0);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("123456789", DownloadText(blob, Encoding.UTF8));

                blockIds.RemoveAt(8);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("12345678", DownloadText(blob, Encoding.UTF8));

                blockIds.RemoveAt(3);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("1235678", DownloadText(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[9]))
                {
                    blob.PutBlock(originalBlockIds[9], stream, null);
                }
                blockIds.Insert(0, originalBlockIds[9]);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("91235678", DownloadText(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[0]))
                {
                    blob.PutBlock(originalBlockIds[0], stream, null);
                }
                blockIds.Add(originalBlockIds[0]);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("912356780", DownloadText(blob, Encoding.UTF8));

                using (MemoryStream stream = new MemoryStream(blocks[4]))
                {
                    blob.PutBlock(originalBlockIds[4], stream, null);
                }
                blockIds.Insert(2, originalBlockIds[4]);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("9142356780", DownloadText(blob, Encoding.UTF8));

                blockIds.Insert(0, originalBlockIds[0]);
                blob.PutBlockList(blockIds);
                Assert.AreEqual("09142356780", DownloadText(blob, Encoding.UTF8));
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload and download null/empty data")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadDownloadNoData()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob");
                TestHelper.ExpectedException<ArgumentNullException>(
                    () => blob.UploadFromStream(null),
                    "Uploading from a null stream should fail");

                using (MemoryStream stream = new MemoryStream())
                {
                    blob.UploadFromStream(stream);
                }

                TestHelper.ExpectedException<ArgumentNullException>(
                    () => blob.DownloadToStream(null),
                    "Downloading to a null stream should fail");

                using (MemoryStream stream = new MemoryStream())
                {
                    blob.DownloadToStream(stream);
                    Assert.AreEqual(0, stream.Length);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List committed and uncommitted blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobListUncommittedBlobs()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                List<string> committedBlobs = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    string name = "cblob" + i.ToString();
                    CloudBlockBlob committedBlob = container.GetBlockBlobReference(name);
                    CreateForTest(committedBlob, 2, 1024, false);
                    committedBlobs.Add(name);
                }

                List<string> uncommittedBlobs = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    string name = "ucblob" + i.ToString();
                    CloudBlockBlob uncommittedBlob = container.GetBlockBlobReference(name);
                    CreateForTest(uncommittedBlob, 2, 1024, false, false);
                    uncommittedBlobs.Add(name);
                }

                List<IListBlobItem> blobs = container.ListBlobs(null, true, BlobListingDetails.UncommittedBlobs).ToList();
                foreach (ICloudBlob blob in blobs)
                {
                    if (committedBlobs.Remove(blob.Name))
                    {
                        Assert.AreEqual(2 * 1024, blob.Properties.Length);
                    }
                    else if (uncommittedBlobs.Remove(blob.Name))
                    {
                        Assert.AreEqual(0, blob.Properties.Length);
                    }
                    else
                    {
                        Assert.Fail("Blob is not found in either committed or uncommitted list");
                    }
                }

                Assert.AreEqual(0, committedBlobs.Count);
                Assert.AreEqual(0, uncommittedBlobs.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Try operations with an invalid Sas and snapshot")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobInvalidSasAndSnapshot()
        {
            // Sas token creds.
            string token = "?sp=abcde&sig=1";
            StorageCredentials creds = new StorageCredentials(token);
            Assert.IsTrue(creds.IsSAS);

            // Client with shared key access.
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(GetRandomContainerName());
            try
            {
                container.Create();

                SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write,
                };
                string sasToken = container.GetSharedAccessSignature(policy);

                string blobUri = container.Uri.AbsoluteUri + "/blob1" + sasToken;
                TestHelper.ExpectedException<ArgumentException>(
                    () => new CloudBlockBlob(new Uri(blobUri), container.ServiceClient.Credentials),
                    "Try to use SAS creds in Uri on a shared key client");

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.UploadFromStream(new MemoryStream(GetRandomBuffer(10)));

                CloudBlockBlob snapshot = blob.CreateSnapshot();
                DateTimeOffset? wrongTime = snapshot.SnapshotTime.Value + TimeSpan.FromSeconds(10);

                string snapshotUri = snapshot.Uri + "?snapshot=" + wrongTime.Value.ToString();
                TestHelper.ExpectedException<ArgumentException>(
                    () => new CloudBlockBlob(new Uri(snapshotUri), snapshot.SnapshotTime, container.ServiceClient.Credentials),
                    "Snapshot in Uri does not match snapshot on blob");

            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload and download text")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadText()
        {
            this.DoTextUploadDownload("test", false, false);
            this.DoTextUploadDownload("char中文test", true, false);
            this.DoTextUploadDownload("", false, false);
        }

        [TestMethod]
        [Description("Upload and download text")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadTextAPM()
        {
            this.DoTextUploadDownload("test", false, true);
            this.DoTextUploadDownload("char中文test", true, true);
            this.DoTextUploadDownload("", false, true);
        }

#if TASK
        [TestMethod]
        [Description("Upload and download text")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobUploadTextTask()
        {
            this.DoTextUploadDownloadTask("test", false);
            this.DoTextUploadDownloadTask("char中文test", true);
            this.DoTextUploadDownloadTask("", false);
        }
#endif

        private void DoTextUploadDownload(string text, bool checkDifferentEncoding, bool isAsync)
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateIfNotExists();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                if (isAsync)
                {
                    IAsyncResult result;
                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        result = blob.BeginUploadText(text,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadText(result);
                        result = blob.BeginDownloadText(
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        Assert.AreEqual(text, blob.EndDownloadText(result));
                        if (checkDifferentEncoding)
                        {
                            result = blob.BeginDownloadText(Encoding.Unicode, null, null, null,
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            Assert.AreNotEqual(text, blob.EndDownloadText(result));
                        }

                        OperationContext context = new OperationContext();
                        result = blob.BeginUploadText(text, Encoding.Unicode, null, null, context,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        blob.EndUploadText(result);
                        Assert.AreEqual(1, context.RequestResults.Count);
                        result = blob.BeginDownloadText(Encoding.Unicode, null, null, context,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        Assert.AreEqual(text, blob.EndDownloadText(result));
                        Assert.AreEqual(2, context.RequestResults.Count);
                        if (checkDifferentEncoding)
                        {
                            result = blob.BeginDownloadText(
                                ar => waitHandle.Set(),
                                null);
                            waitHandle.WaitOne();
                            Assert.AreNotEqual(text, blob.EndDownloadText(result));
                        }
                    }
                }
                else
                {
                    blob.UploadText(text);
                    Assert.AreEqual(text, blob.DownloadText());
                    if (checkDifferentEncoding)
                    {
                        Assert.AreNotEqual(text, blob.DownloadText(Encoding.Unicode));
                    }

                    blob.UploadText(text, Encoding.Unicode);
                    Assert.AreEqual(text, blob.DownloadText(Encoding.Unicode));
                    if (checkDifferentEncoding)
                    {
                        Assert.AreNotEqual(text, blob.DownloadText());
                    }

                    OperationContext context = new OperationContext();
                    blob.UploadText(text, Encoding.Unicode, null, null, context);
                    Assert.AreEqual(1, context.RequestResults.Count);
                    blob.DownloadText(Encoding.Unicode, null, null, context);
                    Assert.AreEqual(2, context.RequestResults.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        private void DoTextUploadDownloadTask(string text, bool checkDifferentEncoding)
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateIfNotExistsAsync().Wait();
                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");

                blob.UploadTextAsync(text).Wait();
                Assert.AreEqual(text, blob.DownloadTextAsync().Result);
                if (checkDifferentEncoding)
                {
                    Assert.AreNotEqual(text, blob.DownloadTextAsync(Encoding.Unicode, null, null, null).Result);
                }

                blob.UploadTextAsync(text, Encoding.Unicode, null, null, null).Wait();
                Assert.AreEqual(text, blob.DownloadTextAsync(Encoding.Unicode, null, null, null).Result);
                if (checkDifferentEncoding)
                {
                    Assert.AreNotEqual(text, blob.DownloadTextAsync().Result);
                }

                OperationContext context = new OperationContext();
                blob.UploadTextAsync(text, Encoding.Unicode, null, null, context).Wait();
                Assert.AreEqual(1, context.RequestResults.Count);
                blob.DownloadTextAsync(Encoding.Unicode, null, null, context).Wait();
                Assert.AreEqual(2, context.RequestResults.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
#endif
    }
}
