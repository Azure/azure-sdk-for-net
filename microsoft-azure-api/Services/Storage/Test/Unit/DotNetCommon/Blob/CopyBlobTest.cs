// -----------------------------------------------------------------------------------------
// <copyright file="CopyBlobTest.cs" company="Microsoft">
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
using System.Net;
using System.Text;
using System.Threading;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CopyBlobTest : BlobTestBase
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
        [Description("CopyFromBlob with Unicode source blob")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CopyBlobUsingUnicodeBlobName()
        {
            string _unicodeBlobName = "繁体字14a6c";
            string _nonUnicodeBlobName = "sample_file";

            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                CloudBlockBlob blobUnicodeSource = container.GetBlockBlobReference(_unicodeBlobName);
                string data = "Test content";
                UploadText(blobUnicodeSource, data, Encoding.UTF8);
                CloudBlockBlob blobAsciiSource = container.GetBlockBlobReference(_nonUnicodeBlobName);
                UploadText(blobAsciiSource, data, Encoding.UTF8);
                
                //Copy blobs over
                CloudBlockBlob blobAsciiDest = container.GetBlockBlobReference(_nonUnicodeBlobName + "_copy");
                string copyId = blobAsciiDest.StartCopyFromBlob(TestHelper.Defiddler(blobAsciiSource));
                WaitForCopy(blobAsciiDest);

                CloudBlockBlob blobUnicodeDest = container.GetBlockBlobReference(_unicodeBlobName + "_copy");
                copyId = blobUnicodeDest.StartCopyFromBlob(TestHelper.Defiddler(blobUnicodeSource));
                WaitForCopy(blobUnicodeDest);

                Assert.AreEqual(CopyStatus.Success, blobUnicodeDest.CopyState.Status);
                Assert.AreEqual(blobUnicodeSource.Uri.AbsolutePath, blobUnicodeDest.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, blobUnicodeDest.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, blobUnicodeDest.CopyState.BytesCopied);
                Assert.AreEqual(copyId, blobUnicodeDest.CopyState.CopyId);
                Assert.IsTrue(blobUnicodeDest.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
        
        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                string copyId = copy.StartCopyFromBlob(TestHelper.Defiddler(source));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                TestHelper.ExpectedException(
                    () => copy.AbortCopy(copyId),
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                source.FetchAttributes();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyTestAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = copy.BeginStartCopyFromBlob(TestHelper.Defiddler(source),
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    string copyId = copy.EndStartCopyFromBlob(result);
                    WaitForCopy(copy);
                    Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                    Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                    Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                    Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                    Assert.AreEqual(copyId, copy.CopyState.CopyId);
                    Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                    result = copy.BeginAbortCopy(copyId,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => copy.EndAbortCopy(result),
                        "Aborting a copy operation after completion should fail",
                        HttpStatusCode.Conflict,
                        "NoPendingCopyOperation");
                }

                source.FetchAttributes();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyTestTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                UploadTextTask(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadataAsync().Wait();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                string copyId = copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source)).Result;
                WaitForCopyTask(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                TestHelper.ExpectedExceptionTask(
                    copy.AbortCopyAsync(copyId),
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                source.FetchAttributesAsync().Wait();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadTextTask(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributesAsync().Wait();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.DeleteAsync().Wait();
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyTestWithMetadataOverride()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob source = container.GetBlockBlobReference("source");

                string data = "String data";
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                copy.Metadata["Test2"] = "value2";
                string copyId = copy.StartCopyFromBlob(TestHelper.Defiddler(source));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                source.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value2", copy.Metadata["Test2"], false, "Copied metadata not same");
                Assert.IsFalse(copy.Metadata.ContainsKey("Test"), "Source Metadata should not appear in destination blob");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyFromSnapshotTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob source = container.GetBlockBlobReference("source");
                string data = "String data";
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudBlockBlob snapshot = source.CreateSnapshot();

                //Modify source
                string newData = "Hello";
                source.Metadata["Test"] = "newvalue";
                source.SetMetadata();
                source.Properties.ContentMD5 = null;
                UploadText(source, newData, Encoding.UTF8);

                Assert.AreEqual(newData, DownloadText(source, Encoding.UTF8), "Source is modified correctly");
                Assert.AreEqual(data, DownloadText(snapshot, Encoding.UTF8), "Modifying source blob should not modify snapshot");

                source.FetchAttributes();
                snapshot.FetchAttributes();
                Assert.AreNotEqual(source.Metadata["Test"], snapshot.Metadata["Test"], "Source and snapshot metadata should be independent");

                CloudBlockBlob copy = container.GetBlockBlobReference("copy");
                copy.StartCopyFromBlob(TestHelper.Defiddler(snapshot));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(data, DownloadText(copy, Encoding.UTF8), "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = snapshot.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                string copyId = copy.StartCopyFromBlob(TestHelper.Defiddler(source));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                TestHelper.ExpectedException(
                    () => copy.AbortCopy(copyId),
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                source.FetchAttributes();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyTestAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = copy.BeginStartCopyFromBlob(TestHelper.Defiddler(source),
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    string copyId = copy.EndStartCopyFromBlob(result);
                    WaitForCopy(copy);
                    Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                    Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                    Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                    Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                    Assert.AreEqual(copyId, copy.CopyState.CopyId);
                    Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                    result = copy.BeginAbortCopy(copyId,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => copy.EndAbortCopy(result),
                        "Aborting a copy operation after completion should fail",
                        HttpStatusCode.Conflict,
                        "NoPendingCopyOperation");
                }

                source.FetchAttributes();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Copy a blob and then verify its contents, properties, and metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyTestTask()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.CreateAsync().Wait();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                UploadTextTask(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadataAsync().Wait();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                string copyId = copy.StartCopyFromBlobAsync(TestHelper.Defiddler(source)).Result;
                WaitForCopyTask(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                TestHelper.ExpectedExceptionTask(
                    copy.AbortCopyAsync(copyId),
                    "Aborting a copy operation after completion should fail",
                    HttpStatusCode.Conflict,
                    "NoPendingCopyOperation");

                source.FetchAttributesAsync().Wait();
                Assert.IsNotNull(copy.Properties.ETag);
                Assert.AreNotEqual(source.Properties.ETag, copy.Properties.ETag);
                Assert.IsTrue(copy.Properties.LastModified > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadTextTask(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributesAsync().Wait();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.DeleteAsync().Wait();
            }
            finally
            {
                container.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyTestWithMetadataOverride()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob source = container.GetPageBlobReference("source");

                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                copy.Metadata["Test2"] = "value2";
                string copyId = copy.StartCopyFromBlob(TestHelper.Defiddler(source));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(source.Uri.AbsolutePath, copy.CopyState.Source.AbsolutePath);
                Assert.AreEqual(data.Length, copy.CopyState.TotalBytes);
                Assert.AreEqual(data.Length, copy.CopyState.BytesCopied);
                Assert.AreEqual(copyId, copy.CopyState.CopyId);
                Assert.IsTrue(copy.CopyState.CompletionTime > DateTimeOffset.UtcNow.Subtract(TimeSpan.FromMinutes(1)));

                string copyData = DownloadText(copy, Encoding.UTF8);
                Assert.AreEqual(data, copyData, "Data inside copy of blob not similar");

                copy.FetchAttributes();
                source.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = source.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value2", copy.Metadata["Test2"], false, "Copied metadata not same");
                Assert.IsFalse(copy.Metadata.ContainsKey("Test"), "Source Metadata should not appear in destination blob");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob and override metadata during copy")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyFromSnapshotTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob source = container.GetPageBlobReference("source");
                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);

                source.Metadata["Test"] = "value";
                source.SetMetadata();

                CloudPageBlob snapshot = source.CreateSnapshot();

                //Modify source
                string newData = new string('b', 512);
                source.Metadata["Test"] = "newvalue";
                source.SetMetadata();
                source.Properties.ContentMD5 = null;
                UploadText(source, newData, Encoding.UTF8);

                Assert.AreEqual(newData, DownloadText(source, Encoding.UTF8), "Source is modified correctly");
                Assert.AreEqual(data, DownloadText(snapshot, Encoding.UTF8), "Modifying source blob should not modify snapshot");

                source.FetchAttributes();
                snapshot.FetchAttributes();
                Assert.AreNotEqual(source.Metadata["Test"], snapshot.Metadata["Test"], "Source and snapshot metadata should be independent");

                CloudPageBlob copy = container.GetPageBlobReference("copy");
                copy.StartCopyFromBlob(TestHelper.Defiddler(snapshot));
                WaitForCopy(copy);
                Assert.AreEqual(CopyStatus.Success, copy.CopyState.Status);
                Assert.AreEqual(data, DownloadText(copy, Encoding.UTF8), "Data inside copy of blob not similar");

                copy.FetchAttributes();
                BlobProperties prop1 = copy.Properties;
                BlobProperties prop2 = snapshot.Properties;

                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);

                Assert.AreEqual("value", copy.Metadata["Test"], false, "Copied metadata not same");

                copy.Delete();
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob with source access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlockBlobCopyWithSourceAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob source = container.GetBlockBlobReference("source");
                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);
                string validLeaseId = Guid.NewGuid().ToString();
                string leaseId = source.AcquireLease(TimeSpan.FromSeconds(60), validLeaseId);
                string invalidLeaseId = Guid.NewGuid().ToString();

                source.FetchAttributes();
                AccessCondition sourceAccessCondition1 = AccessCondition.GenerateIfNotModifiedSinceCondition(source.Properties.LastModified.Value);
                CloudBlockBlob copy1 = container.GetBlockBlobReference("copy1");
                copy1.StartCopyFromBlob(TestHelper.Defiddler(source), sourceAccessCondition1);
                WaitForCopy(copy1);
                Assert.AreEqual(CopyStatus.Success, copy1.CopyState.Status);

                AccessCondition sourceAccessCondition2 = AccessCondition.GenerateLeaseCondition(invalidLeaseId);
                CloudBlockBlob copy2 = container.GetBlockBlobReference("copy2");
                TestHelper.ExpectedException<ArgumentException>(() => copy2.StartCopyFromBlob(TestHelper.Defiddler(source), sourceAccessCondition2), "A lease condition cannot be specified on the source of a copy.");          
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy a blob with source access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudPageBlobCopyWithSourceAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudPageBlob source = container.GetPageBlobReference("source");
                string data = new string('a', 512);
                UploadText(source, data, Encoding.UTF8);
                string validLeaseId = Guid.NewGuid().ToString();
                string leaseId = source.AcquireLease(TimeSpan.FromSeconds(60), validLeaseId);
                string invalidLeaseId = Guid.NewGuid().ToString();

                source.FetchAttributes();
                AccessCondition sourceAccessCondition1 = AccessCondition.GenerateIfNotModifiedSinceCondition(source.Properties.LastModified.Value);
                CloudPageBlob copy1 = container.GetPageBlobReference("copy1");
                copy1.StartCopyFromBlob(TestHelper.Defiddler(source), sourceAccessCondition1);
                WaitForCopy(copy1);
                Assert.AreEqual(CopyStatus.Success, copy1.CopyState.Status);

                AccessCondition sourceAccessCondition2 = AccessCondition.GenerateLeaseCondition(invalidLeaseId);
                CloudPageBlob copy2 = container.GetPageBlobReference("copy2");
                TestHelper.ExpectedException<ArgumentException>(() => copy2.StartCopyFromBlob(TestHelper.Defiddler(source), sourceAccessCondition2), "A lease condition cannot be specified on the source of a copy.");
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
