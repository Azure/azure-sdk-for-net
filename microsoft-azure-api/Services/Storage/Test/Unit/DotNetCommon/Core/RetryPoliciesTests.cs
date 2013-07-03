// -----------------------------------------------------------------------------------------
// <copyright file="RetryPoliciesTests.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading;

    [TestClass]
    public class RetryPoliciesTests : TableTestBase
    {
        [TestMethod]
        [Description("Test to ensure that the time when we wait for a retry is cancellable")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void RetryDelayShouldBeCancellable()
        {
            using (ManualResetEvent responseWaitHandle = new ManualResetEvent(false),
                callbackWaitHandle = new ManualResetEvent(false))
            {
                BlobRequestOptions options = new BlobRequestOptions();
                options.RetryPolicy = new AlwaysRetry(TimeSpan.FromMinutes(1), 1);
                OperationContext context = new OperationContext();
                context.ResponseReceived += (sender, e) => responseWaitHandle.Set();

                CloudBlobClient blobClient = GenerateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("test" + DateTime.UtcNow.Ticks.ToString());
                ICancellableAsyncResult asyncResult = container.BeginFetchAttributes(null, options, context,
                    ar =>
                    {
                        try
                        {
                            container.EndFetchAttributes(ar);
                        }
                        catch (Exception)
                        {
                            // This is expected, because we went for an invalid domain name.
                        }

                        callbackWaitHandle.Set();
                    },
                    null);

                responseWaitHandle.WaitOne();
                Thread.Sleep(10 * 1000);

                Stopwatch stopwatch = Stopwatch.StartNew();
                
                asyncResult.Cancel();
                callbackWaitHandle.WaitOne();
                
                stopwatch.Stop();

                Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromSeconds(10), stopwatch.Elapsed.ToString());
                Assert.AreEqual(1, context.RequestResults.Count);
            }
        }

        [TestMethod]
        [Description("Test to ensure that the backoff time is set correctly in LinearRetry")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void VerifyLinearRetryBackOffTime()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            tableClient.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(10), 4);

            OperationContext opContext = new OperationContext();
            TimeSpan retryInterval;
            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(0, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(10), retryInterval);

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(1, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(10), retryInterval);

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(2, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(10), retryInterval);

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(3, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(10), retryInterval);

            Assert.IsFalse(tableClient.RetryPolicy.ShouldRetry(4, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(10), retryInterval);

            tableClient.RetryPolicy = new LinearRetry();

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(0, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(30), retryInterval);

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(1, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(30), retryInterval);

            Assert.IsTrue(tableClient.RetryPolicy.ShouldRetry(2, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(30), retryInterval);

            Assert.IsFalse(tableClient.RetryPolicy.ShouldRetry(3, 503, new Exception(), out retryInterval, opContext));
            Assert.AreEqual(TimeSpan.FromSeconds(30), retryInterval);
        }

        [TestMethod]
        [Description("Setting retry policy to null should not throw an exception")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void NullRetryPolicyTest()
        {
            CloudBlobClient blobClient = TestBase.GenerateCloudBlobClient();
            blobClient.RetryPolicy = null;

            CloudBlobContainer container = blobClient.GetContainerReference("test");
            container.Exists();
        }


        [TestMethod]
        [Description("Create a blob using blob stream by specifying an access condition")]
        [TestCategory(ComponentCategory.Blob)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void RetryPolicyEnsure304IsNotRetried()
        {
            CloudBlobContainer container = BlobTestBase.GetRandomContainerReference();
            container.Create();

            try
            {
                CloudBlockBlob blob = container.GetBlockBlobReference("blob");
                blob.UploadFromStream(new MemoryStream(new byte[50]));

                AccessCondition accessCondition = AccessCondition.GenerateIfModifiedSinceCondition(blob.Properties.LastModified.Value.AddMinutes(10));
                OperationContext context = new OperationContext();

                TestHelper.ExpectedException(
                    () => blob.FetchAttributes(accessCondition, new BlobRequestOptions() { RetryPolicy = new ExponentialRetry() }, context),
                    "FetchAttributes with invalid modified condition should return NotModified",
                    HttpStatusCode.NotModified);

                TestHelper.AssertNAttempts(context, 1);


                context = new OperationContext();

                TestHelper.ExpectedException(
                    () => blob.FetchAttributes(accessCondition, new BlobRequestOptions() { RetryPolicy = new LinearRetry() }, context),
                    "FetchAttributes with invalid modified condition should return NotModified",
                    HttpStatusCode.NotModified);

                TestHelper.AssertNAttempts(context, 1);
            }
            finally
            {
                container.Delete();
            }
        }
    }
}
