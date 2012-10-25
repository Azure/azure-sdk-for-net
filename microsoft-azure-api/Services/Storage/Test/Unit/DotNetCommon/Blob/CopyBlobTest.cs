using System;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CopyBlobTest : BlobTestBase
    {
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
    }
}
