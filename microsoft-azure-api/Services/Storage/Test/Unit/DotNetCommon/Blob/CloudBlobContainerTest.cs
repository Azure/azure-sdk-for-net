// -----------------------------------------------------------------------------------------
// <copyright file="CloudBlobContainerTest.cs" company="Microsoft">
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
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class CloudBlobContainerTest : BlobTestBase
    {
        [TestMethod]
        [Description("Create and delete a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerCreate()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();
            TestHelper.ExpectedException(
                () => container.Create(),
                "Creating already exists container should fail",
                HttpStatusCode.Conflict);
            container.Delete();
        }

        [TestMethod]
        [Description("Create and delete a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerCreateAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginCreate(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                container.EndCreate(result);
                result = container.BeginCreate(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                TestHelper.ExpectedException(
                    () => container.EndCreate(result),
                    "Creating already exists container should fail",
                    HttpStatusCode.Conflict);
            }
            container.Delete();
        }

        [TestMethod]
        [Description("Try to create a container after it is created")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerCreateIfNotExists()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                Assert.IsTrue(container.CreateIfNotExists());
                Assert.IsFalse(container.CreateIfNotExists());
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Try to create a container after it is created")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerCreateIfNotExistsAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = container.BeginCreateIfNotExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(container.EndCreateIfNotExists(result));
                    result = container.BeginCreateIfNotExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(container.EndCreateIfNotExists(result));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Try to delete a non-existing container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerDeleteIfExists()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            Assert.IsFalse(container.DeleteIfExists());
            container.Create();
            Assert.IsTrue(container.DeleteIfExists());
            Assert.IsFalse(container.DeleteIfExists());
        }

        [TestMethod]
        [Description("Try to delete a non-existing container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerDeleteIfExistsAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = container.BeginDeleteIfExists(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                Assert.IsFalse(container.EndDeleteIfExists(result));
                result = container.BeginCreate(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                container.EndCreate(result);
                result = container.BeginDeleteIfExists(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                Assert.IsTrue(container.EndDeleteIfExists(result));
                result = container.BeginDeleteIfExists(
                    ar => waitHandle.Set(),
                    null);
                waitHandle.WaitOne();
                Assert.IsFalse(container.EndDeleteIfExists(result));
            }
        }

        [TestMethod]
        [Description("Check a container's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerExists()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                Assert.IsFalse(container.Exists());
                container.Create();
                Assert.IsTrue(container.Exists());
            }
            finally
            {
                container.DeleteIfExists();
            }
            Assert.IsFalse(container.Exists());
        }

        [TestMethod]
        [Description("Check a container's existence")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerExistsAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = container.BeginExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(container.EndExists(result));
                    container.Create();
                    result = container.BeginExists(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(container.EndExists(result));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
            Assert.IsFalse(container.Exists());
        }

        [TestMethod]
        [Description("Set container permissions")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerSetPermissions()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                BlobContainerPermissions permissions = container.GetPermissions();
                Assert.AreEqual(BlobContainerPublicAccessType.Off, permissions.PublicAccess);
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                permissions.SharedAccessPolicies.Add("key1", new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessBlobPermissions.List,
                });
                container.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                permissions = container2.GetPermissions();
                Assert.AreEqual(BlobContainerPublicAccessType.Container, permissions.PublicAccess);
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.HasValue);
                Assert.AreEqual(start, permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.Value.UtcDateTime);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.HasValue);
                Assert.AreEqual(expiry, permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.Value.UtcDateTime);
                Assert.AreEqual(SharedAccessBlobPermissions.List, permissions.SharedAccessPolicies["key1"].Permissions);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerCreateWithMetadata()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Metadata.Add("key1", "value1");
                container.Create();

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                container2.FetchAttributes();
                Assert.AreEqual(1, container2.Metadata.Count);
                Assert.AreEqual("value1", container2.Metadata["key1"]);

                Assert.IsTrue(container2.Properties.LastModified.Value.AddHours(1) > DateTimeOffset.Now);
                Assert.IsNotNull(container2.Properties.ETag);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerSetMetadata()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                container2.FetchAttributes();
                Assert.AreEqual(0, container2.Metadata.Count);

                container.Metadata.Add("key1", "value1");
                container.SetMetadata();

                container2.FetchAttributes();
                Assert.AreEqual(1, container2.Metadata.Count);
                Assert.AreEqual("value1", container2.Metadata["key1"]);

                CloudBlobContainer container3 = container.ServiceClient.ListContainers(container.Name, ContainerListingDetails.Metadata).First();
                Assert.AreEqual(1, container3.Metadata.Count);
                Assert.AreEqual("value1", container3.Metadata["key1"]);

                container.Metadata.Clear();
                container.SetMetadata();

                container2.FetchAttributes();
                Assert.AreEqual(0, container2.Metadata.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Create a container with metadata")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerSetMetadataAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudBlobContainer container2 = container.ServiceClient.GetContainerReference(container.Name);
                    IAsyncResult result = container2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container2.EndFetchAttributes(result);
                    Assert.AreEqual(0, container2.Metadata.Count);

                    container.Metadata.Add("key1", "value1");
                    result = container.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container.EndSetMetadata(result);

                    result = container2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container2.EndFetchAttributes(result);
                    Assert.AreEqual(1, container2.Metadata.Count);
                    Assert.AreEqual("value1", container2.Metadata["key1"]);

                    result = container.ServiceClient.BeginListContainersSegmented(container.Name, ContainerListingDetails.Metadata, null, null, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    CloudBlobContainer container3 = container.ServiceClient.EndListContainersSegmented(result).Results.First();
                    Assert.AreEqual(1, container3.Metadata.Count);
                    Assert.AreEqual("value1", container3.Metadata["key1"]);

                    container.Metadata.Clear();
                    result = container.BeginSetMetadata(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container.EndSetMetadata(result);

                    result = container2.BeginFetchAttributes(
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    container2.EndFetchAttributes(result);
                    Assert.AreEqual(0, container2.Metadata.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerListBlobs()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                List<string> blobNames = CreateBlobs(container, 3, BlobType.PageBlob);

                IEnumerable<IListBlobItem> results = container.ListBlobs();
                Assert.AreEqual(blobNames.Count, results.Count());
                foreach (IListBlobItem blobItem in results)
                {
                    Assert.IsInstanceOfType(blobItem, typeof(CloudPageBlob));
                    Assert.IsTrue(blobNames.Remove(((CloudPageBlob)blobItem).Name));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerListBlobsSegmented()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                List<string> blobNames = CreateBlobs(container, 3, BlobType.PageBlob);

                BlobContinuationToken token = null;
                do
                {
                    BlobResultSegment results = container.ListBlobsSegmented(null, true, BlobListingDetails.None, 1, token, null, null);
                    int count = 0;
                    foreach (IListBlobItem blobItem in results.Results)
                    {
                        Assert.IsInstanceOfType(blobItem, typeof(CloudPageBlob));
                        Assert.IsTrue(blobNames.Remove(((CloudPageBlob)blobItem).Name));
                        count++;
                    }
                    Assert.IsTrue(count >= 1);
                    token = results.ContinuationToken;
                }
                while (token != null);
                Assert.AreEqual(0, blobNames.Count);
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("List blobs")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerListBlobsSegmentedAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                List<string> blobNames = CreateBlobs(container, 3, BlobType.PageBlob);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    BlobContinuationToken token = null;
                    do
                    {
                        IAsyncResult result = container.BeginListBlobsSegmented(null, true, BlobListingDetails.None, 1, token, null, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        BlobResultSegment results = container.EndListBlobsSegmented(result);
                        int count = 0;
                        foreach (IListBlobItem blobItem in results.Results)
                        {
                            Assert.IsInstanceOfType(blobItem, typeof(CloudPageBlob));
                            Assert.IsTrue(blobNames.Remove(((CloudPageBlob)blobItem).Name));
                            count++;
                        }
                        Assert.IsTrue(count >= 1);
                        token = results.ContinuationToken;
                    }
                    while (token != null);
                    Assert.AreEqual(0, blobNames.Count);
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Get a blob reference without knowing its type")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerGetBlobReferenceFromServer()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("bb");
                blockBlob.PutBlockList(new string[] {});

                CloudPageBlob pageBlob = container.GetPageBlobReference("pb");
                pageBlob.Create(0);

                ICloudBlob blob1 = container.GetBlobReferenceFromServer("bb");
                Assert.IsInstanceOfType(blob1, typeof(CloudBlockBlob));

                ICloudBlob blob2 = container.GetBlobReferenceFromServer("pb");
                Assert.IsInstanceOfType(blob2, typeof(CloudPageBlob));

                ICloudBlob blob3 = container.ServiceClient.GetBlobReferenceFromServer(blockBlob.Uri);
                Assert.IsInstanceOfType(blob3, typeof(CloudBlockBlob));

                ICloudBlob blob4 = container.ServiceClient.GetBlobReferenceFromServer(pageBlob.Uri);
                Assert.IsInstanceOfType(blob4, typeof(CloudPageBlob));
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Get a blob reference without knowing its type")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerGetBlobReferenceFromServerAPM()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("bb");
                blockBlob.PutBlockList(new string[] { });

                CloudPageBlob pageBlob = container.GetPageBlobReference("pb");
                pageBlob.Create(0);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = container.BeginGetBlobReferenceFromServer("bb",
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    ICloudBlob blob1 = container.EndGetBlobReferenceFromServer(result);
                    Assert.IsInstanceOfType(blob1, typeof(CloudBlockBlob));

                    result = container.BeginGetBlobReferenceFromServer("pb",
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    ICloudBlob blob2 = container.EndGetBlobReferenceFromServer(result);
                    Assert.IsInstanceOfType(blob2, typeof(CloudPageBlob));

                    result = container.ServiceClient.BeginGetBlobReferenceFromServer(blockBlob.Uri,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    ICloudBlob blob3 = container.ServiceClient.EndGetBlobReferenceFromServer(result);
                    Assert.IsInstanceOfType(blob3, typeof(CloudBlockBlob));

                    result = container.ServiceClient.BeginGetBlobReferenceFromServer(pageBlob.Uri,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    ICloudBlob blob4 = container.ServiceClient.EndGetBlobReferenceFromServer(result);
                    Assert.IsInstanceOfType(blob4, typeof(CloudPageBlob));
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test conditional access on a container")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudBlobContainerConditionalAccess()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();
                container.FetchAttributes();

                string currentETag = container.Properties.ETag;
                DateTimeOffset currentModifiedTime = container.Properties.LastModified.Value;

                // ETag conditional tests
                container.Metadata["ETagConditionalName"] = "ETagConditionalValue";
                container.SetMetadata();

                container.FetchAttributes();
                string newETag = container.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");

                // LastModifiedTime tests
                currentModifiedTime = container.Properties.LastModified.Value;

                container.Metadata["DateConditionalName"] = "DateConditionalValue";

                TestHelper.ExpectedException(
                    () => container.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(currentModifiedTime), null),
                    "IfModifiedSince conditional on current modified time should throw",
                    HttpStatusCode.PreconditionFailed,
                    "ConditionNotMet");

                container.Metadata["DateConditionalName"] = "DateConditionalValue2";
                currentETag = container.Properties.ETag;

                DateTimeOffset pastTime = currentModifiedTime.Subtract(TimeSpan.FromMinutes(5));
                container.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromHours(5));
                container.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                pastTime = currentModifiedTime.Subtract(TimeSpan.FromDays(5));
                container.SetMetadata(AccessCondition.GenerateIfModifiedSinceCondition(pastTime), null);

                container.FetchAttributes();
                newETag = container.Properties.ETag;
                Assert.AreNotEqual(newETag, currentETag, "ETage should be modified on write metadata");
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
