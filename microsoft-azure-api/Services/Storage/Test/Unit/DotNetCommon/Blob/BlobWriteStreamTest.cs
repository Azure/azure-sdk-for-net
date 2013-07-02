// -----------------------------------------------------------------------------------------
// <copyright file="BlobWriteStreamTest.cs" company="Microsoft">
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
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Storage.Blob
{
    [TestClass]
    public class BlobWriteStreamTest : BlobTestBase
    {
        [TestMethod]
        [Description("Create blobs using blob stream")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlobWriteStreamOpenAndClose()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob1");
                using (Stream blobStream = blockBlob.OpenWrite())
                {
                }

                CloudBlockBlob blockBlob2 = container.GetBlockBlobReference("blob1");
                blockBlob2.FetchAttributes();
                Assert.AreEqual(0, blockBlob2.Properties.Length);
                Assert.AreEqual(BlobType.BlockBlob, blockBlob2.Properties.BlobType);

                CloudPageBlob pageBlob = container.GetPageBlobReference("blob2");
                TestHelper.ExpectedException(
                    () => pageBlob.OpenWrite(null),
                    "Opening a page blob stream with no size should fail on a blob that does not exist",
                    HttpStatusCode.NotFound);
                using (Stream blobStream = pageBlob.OpenWrite(1024))
                {
                }
                using (Stream blobStream = pageBlob.OpenWrite(null))
                {
                }

                CloudPageBlob pageBlob2 = container.GetPageBlobReference("blob2");
                pageBlob2.FetchAttributes();
                Assert.AreEqual(1024, pageBlob2.Properties.Length);
                Assert.AreEqual(BlobType.PageBlob, pageBlob2.Properties.BlobType);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamOpenWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob existingBlob = container.GetBlockBlobReference("blob");
                existingBlob.PutBlockList(new List<string>());

                CloudBlockBlob blob = container.GetBlockBlobReference("blob2");
                AccessCondition accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => blob.OpenWrite(accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.NotFound);

                blob = container.GetBlockBlobReference("blob3");
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                Stream blobStream = blob.OpenWrite(accessCondition);
                blobStream.Dispose();

                blob = container.GetBlockBlobReference("blob4");
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                blobStream = blob.OpenWrite(accessCondition);
                blobStream.Dispose();

                blob = container.GetBlockBlobReference("blob5");
                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                blobStream = blob.OpenWrite(accessCondition);
                blobStream.Dispose();

                blob = container.GetBlockBlobReference("blob6");
                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                blobStream = blob.OpenWrite(accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                blobStream = existingBlob.OpenWrite(accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                blobStream = existingBlob.OpenWrite(accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.NotModified);

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                blobStream = existingBlob.OpenWrite(accessCondition);
                TestHelper.ExpectedException(
                    () => blobStream.Dispose(),
                    "BlobWriteStream.Dispose with a non-met condition should fail",
                    HttpStatusCode.Conflict);

                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                blobStream = existingBlob.OpenWrite(accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.NotModified);

                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                blobStream = existingBlob.OpenWrite(accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                blobStream = existingBlob.OpenWrite(accessCondition);
                existingBlob.SetProperties();
                TestHelper.ExpectedException(
                    () => blobStream.Dispose(),
                    "BlobWriteStream.Dispose with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                blob = container.GetBlockBlobReference("blob7");
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                blobStream = blob.OpenWrite(accessCondition);
                blob.PutBlockList(new List<string>());
                TestHelper.ExpectedException(
                    () => blobStream.Dispose(),
                    "BlobWriteStream.Dispose with a non-met condition should fail",
                    HttpStatusCode.Conflict);

                blob = container.GetBlockBlobReference("blob8");
                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value);
                blobStream = existingBlob.OpenWrite(accessCondition);

                // Wait 1 second so that the last modified time of the blob is in the past
                Thread.Sleep(TimeSpan.FromSeconds(1));

                existingBlob.SetProperties();
                TestHelper.ExpectedException(
                    () => blobStream.Dispose(),
                    "BlobWriteStream.Dispose with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamOpenAPMWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob existingBlob = container.GetBlockBlobReference("blob");
                existingBlob.PutBlockList(new List<string>());

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference("blob2");
                    AccessCondition accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                    IAsyncResult result = blob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => blob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.NotFound);

                    blob = container.GetBlockBlobReference("blob3");
                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                    result = blob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Stream blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetBlockBlobReference("blob4");
                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                    result = blob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetBlockBlobReference("blob5");
                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = blob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetBlockBlobReference("blob6");
                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = blob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.NotModified);

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    TestHelper.ExpectedException(
                        () => blobStream.Dispose(),
                        "BlobWriteStream.Dispose with a non-met condition should fail",
                        HttpStatusCode.Conflict);

                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.NotModified);

                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    existingBlob.SetProperties();
                    TestHelper.ExpectedException(
                        () => blobStream.Dispose(),
                        "BlobWriteStream.Dispose with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    blob = container.GetBlockBlobReference("blob7");
                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blob.PutBlockList(new List<string>());
                    TestHelper.ExpectedException(
                        () => blobStream.Dispose(),
                        "BlobWriteStream.Dispose with a non-met condition should fail",
                        HttpStatusCode.Conflict);

                    blob = container.GetBlockBlobReference("blob8");
                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value);
                    result = existingBlob.BeginOpenWrite(accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);

                    // Wait 1 second so that the last modified time of the blob is in the past
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    existingBlob.SetProperties();
                    TestHelper.ExpectedException(
                        () => blobStream.Dispose(),
                        "BlobWriteStream.Dispose with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamOpenWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudPageBlob existingBlob = container.GetPageBlobReference("blob");
                existingBlob.Create(1024);

                CloudPageBlob blob = container.GetPageBlobReference("blob2");
                AccessCondition accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => blob.OpenWrite(1024, accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                blob = container.GetPageBlobReference("blob3");
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                Stream blobStream = blob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                blob = container.GetPageBlobReference("blob4");
                accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                blobStream = blob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                blob = container.GetPageBlobReference("blob5");
                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                blobStream = blob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                blob = container.GetPageBlobReference("blob6");
                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                blobStream = blob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                blobStream = existingBlob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(1024, accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                blobStream = existingBlob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(1024, accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(1024, accessCondition),
                    "BlobWriteStream.Dispose with a non-met condition should fail",
                    HttpStatusCode.Conflict);

                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                blobStream = existingBlob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(1024, accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);

                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                blobStream = existingBlob.OpenWrite(1024, accessCondition);
                blobStream.Dispose();

                accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                TestHelper.ExpectedException(
                    () => existingBlob.OpenWrite(1024, accessCondition),
                    "OpenWrite with a non-met condition should fail",
                    HttpStatusCode.PreconditionFailed);
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamOpenAPMWithAccessCondition()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            container.Create();

            try
            {
                CloudPageBlob existingBlob = container.GetPageBlobReference("blob");
                existingBlob.Create(1024);

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    CloudPageBlob blob = container.GetPageBlobReference("blob2");
                    AccessCondition accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                    IAsyncResult result = blob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => blob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    blob = container.GetPageBlobReference("blob3");
                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                    result = blob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    Stream blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetPageBlobReference("blob4");
                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                    result = blob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetPageBlobReference("blob5");
                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = blob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    blob = container.GetPageBlobReference("blob6");
                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = blob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = blob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfMatchCondition(existingBlob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfMatchCondition(blob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(blob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition(existingBlob.Properties.ETag);
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    accessCondition = AccessCondition.GenerateIfNoneMatchCondition("*");
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "BlobWriteStream.Dispose with a non-met condition should fail",
                        HttpStatusCode.Conflict);

                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);

                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(1));
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    blobStream = existingBlob.EndOpenWrite(result);
                    blobStream.Dispose();

                    accessCondition = AccessCondition.GenerateIfNotModifiedSinceCondition(existingBlob.Properties.LastModified.Value.AddMinutes(-1));
                    result = existingBlob.BeginOpenWrite(1024, accessCondition, null, null,
                        ar => waitHandle.Set(),
                        null);
                    waitHandle.WaitOne();
                    TestHelper.ExpectedException(
                        () => existingBlob.EndOpenWrite(result),
                        "OpenWrite with a non-met condition should fail",
                        HttpStatusCode.PreconditionFailed);
                }
            }
            finally
            {
                container.Delete();
            }
        }

        [TestMethod]
        [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamBasicTest()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);

            MD5 hasher = MD5.Create();
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    using (Stream blobStream = blob.OpenWrite(null, options))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            blobStream.Write(buffer, 0, buffer.Length);
                            wholeBlob.Write(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamOneByteTest()
        {
            byte buffer = 127;

            MD5 hasher = MD5.Create();
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamWriteSizeInBytes = 16 * 1024;
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    using (Stream blobStream = blob.OpenWrite(null, options))
                    {
                        for (int i = 0; i < 1 * 1024 * 1024; i++)
                        {
                            blobStream.WriteByte(buffer);
                            wholeBlob.WriteByte(buffer);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamBasicTestAPM()
        {
            byte[] buffer = GetRandomBuffer(1024 * 1024);

            MD5 hasher = MD5.Create();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.ParallelOperationThreadCount = 4;
            string name = GetRandomContainerName();
            CloudBlobContainer container = blobClient.GetContainerReference(name);
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                blob.StreamWriteSizeInBytes = buffer.Length;
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };
                    using (Stream blobStream = blob.OpenWrite(null, options))
                    {
                        IAsyncResult[] results = new IAsyncResult[blobClient.ParallelOperationThreadCount * 2];
                        for (int i = 0; i < results.Length; i++)
                        {
                            results[i] = blobStream.BeginWrite(buffer, 0, buffer.Length, null, null);
                            wholeBlob.Write(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }
                        for (int i = 0; i < blobClient.ParallelOperationThreadCount; i++)
                        {
                            Assert.IsTrue(results[i].IsCompleted);
                        }
                        for (int i = blobClient.ParallelOperationThreadCount; i < results.Length; i++)
                        {
                            Assert.IsFalse(results[i].IsCompleted);
                        }
                        for (int i = 0; i < results.Length; i++)
                        {
                            blobStream.EndWrite(results[i]);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a block blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void BlockBlobWriteStreamSeekTest()
        {
            CloudBlobContainer container = GetRandomContainerReference();
            try
            {
                container.Create();

                CloudBlockBlob blob = container.GetBlockBlobReference("blob1");
                using (Stream blobStream = blob.OpenWrite())
                {
                    TestHelper.ExpectedException<NotSupportedException>(
                        () => blobStream.Seek(1, SeekOrigin.Begin),
                        "Block blob write stream should not be seekable");
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamBasicTest()
        {
            byte[] buffer = GetRandomBuffer(6 * 512);

            MD5 hasher = MD5.Create();
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;

            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamWriteSizeInBytes = 8 * 512;

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };

                    using (Stream blobStream = blob.OpenWrite(buffer.Length * 3, null, options))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            blobStream.Write(buffer, 0, buffer.Length);
                            wholeBlob.Write(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }

                    TestHelper.ExpectedException<ArgumentException>(
                        () => blob.OpenWrite(null, null, options),
                        "OpenWrite with StoreBlobContentMD5 on an existing page blob should fail");

                    using (Stream blobStream = blob.OpenWrite(null))
                    {
                        blobStream.Seek(buffer.Length / 2, SeekOrigin.Begin);
                        wholeBlob.Seek(buffer.Length / 2, SeekOrigin.Begin);

                        for (int i = 0; i < 2; i++)
                        {
                            blobStream.Write(buffer, 0, buffer.Length);
                            wholeBlob.Write(buffer, 0, buffer.Length);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }

                        wholeBlob.Seek(0, SeekOrigin.End);
                    }

                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        options.DisableContentMD5Validation = true;
                        blob.DownloadToStream(downloadedBlob, null, options);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamOneByteTest()
        {
            byte buffer = 127;

            MD5 hasher = MD5.Create();
            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;

            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamWriteSizeInBytes = 16 * 1024;

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };

                    using (Stream blobStream = blob.OpenWrite(1 * 1024 * 1024, null, options))
                    {
                        for (int i = 0; i < 1 * 1024 * 1024; i++)
                        {
                            blobStream.WriteByte(buffer);
                            wholeBlob.WriteByte(buffer);
                            Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamBasicTestAPM()
        {
            byte[] buffer = GetRandomBuffer(2 * 1024 * 1024);

            MD5 hasher = MD5.Create();
            CloudBlobClient blobClient = GenerateCloudBlobClient();
            blobClient.ParallelOperationThreadCount = 4;
            string name = GetRandomContainerName();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                blob.StreamWriteSizeInBytes = buffer.Length;

                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    BlobRequestOptions options = new BlobRequestOptions()
                    {
                        StoreBlobContentMD5 = true,
                    };

                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        IAsyncResult result = blob.BeginOpenWrite(blobClient.ParallelOperationThreadCount * 2 * buffer.Length, null, options, null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        using (Stream blobStream = blob.EndOpenWrite(result))
                        {
                            IAsyncResult[] results = new IAsyncResult[blobClient.ParallelOperationThreadCount * 2];
                            for (int i = 0; i < results.Length; i++)
                            {
                                results[i] = blobStream.BeginWrite(buffer, 0, buffer.Length, null, null);
                                wholeBlob.Write(buffer, 0, buffer.Length);
                                Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                            }

                            for (int i = 0; i < blobClient.ParallelOperationThreadCount; i++)
                            {
                                Assert.IsTrue(results[i].IsCompleted);
                            }

                            for (int i = blobClient.ParallelOperationThreadCount; i < results.Length; i++)
                            {
                                Assert.IsFalse(results[i].IsCompleted);
                            }

                            for (int i = 0; i < results.Length; i++)
                            {
                                blobStream.EndWrite(results[i]);
                            }
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.Begin);
                    string md5 = Convert.ToBase64String(hasher.ComputeHash(wholeBlob));
                    blob.FetchAttributes();
                    Assert.AreEqual(md5, blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }

                    blobClient.ParallelOperationThreadCount = 2;

                    TestHelper.ExpectedException<ArgumentException>(
                        () => blob.BeginOpenWrite(null, null, options, null, null, null),
                        "BeginOpenWrite with StoreBlobContentMD5 on an existing page blob should fail");

                    using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                    {
                        IAsyncResult result = blob.BeginOpenWrite(null,
                            ar => waitHandle.Set(),
                            null);
                        waitHandle.WaitOne();
                        using (Stream blobStream = blob.EndOpenWrite(result))
                        {
                            blobStream.Seek(buffer.Length / 2, SeekOrigin.Begin);
                            wholeBlob.Seek(buffer.Length / 2, SeekOrigin.Begin);

                            IAsyncResult[] results = new IAsyncResult[blobClient.ParallelOperationThreadCount * 2];
                            for (int i = 0; i < results.Length; i++)
                            {
                                results[i] = blobStream.BeginWrite(buffer, 0, buffer.Length, null, null);
                                wholeBlob.Write(buffer, 0, buffer.Length);
                                Assert.AreEqual(wholeBlob.Position, blobStream.Position);
                            }

                            for (int i = 0; i < blobClient.ParallelOperationThreadCount; i++)
                            {
                                Assert.IsTrue(results[i].IsCompleted);
                            }

                            for (int i = blobClient.ParallelOperationThreadCount; i < results.Length; i++)
                            {
                                Assert.IsFalse(results[i].IsCompleted);
                            }

                            for (int i = 0; i < results.Length; i++)
                            {
                                blobStream.EndWrite(results[i]);
                            }

                            wholeBlob.Seek(0, SeekOrigin.End);
                        }

                        blob.FetchAttributes();
                        Assert.AreEqual(md5, blob.Properties.ContentMD5);

                        using (MemoryStream downloadedBlob = new MemoryStream())
                        {
                            options.DisableContentMD5Validation = true;
                            blob.DownloadToStream(downloadedBlob, null, options);
                            TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
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
        [Description("Upload a page blob using blob stream and verify contents")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.FuntionalTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void PageBlobWriteStreamRandomSeekTest()
        {
            byte[] buffer = GetRandomBuffer(3 * 1024 * 1024);

            CloudBlobContainer container = GetRandomContainerReference();
            container.ServiceClient.ParallelOperationThreadCount = 2;
            try
            {
                container.Create();

                CloudPageBlob blob = container.GetPageBlobReference("blob1");
                using (MemoryStream wholeBlob = new MemoryStream())
                {
                    using (Stream blobStream = blob.OpenWrite(buffer.Length))
                    {
                        TestHelper.ExpectedException<ArgumentOutOfRangeException>(
                            () => blobStream.Seek(1, SeekOrigin.Begin),
                            "Page blob stream should not allow unaligned seeks");

                        blobStream.Write(buffer, 0, buffer.Length);
                        wholeBlob.Write(buffer, 0, buffer.Length);
                        Random random = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            int offset = random.Next(buffer.Length / 512) * 512;
                            SeekRandomly(blobStream, offset);
                            blobStream.Write(buffer, 0, buffer.Length - offset);
                            wholeBlob.Seek(offset, SeekOrigin.Begin);
                            wholeBlob.Write(buffer, 0, buffer.Length - offset);
                        }
                    }

                    wholeBlob.Seek(0, SeekOrigin.End);
                    blob.FetchAttributes();
                    Assert.IsNull(blob.Properties.ContentMD5);

                    using (MemoryStream downloadedBlob = new MemoryStream())
                    {
                        blob.DownloadToStream(downloadedBlob);
                        TestHelper.AssertStreamsAreEqual(wholeBlob, downloadedBlob);
                    }
                }
            }
            finally
            {
                container.DeleteIfExists();
            }
        }
    }
}
