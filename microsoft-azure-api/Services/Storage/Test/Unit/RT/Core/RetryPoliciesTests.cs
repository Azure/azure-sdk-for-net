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
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class RetryPoliciesTests : TestBase
    {
        [TestMethod]
        /// [Description("Test to ensure that the time when we wait for a retry is cancellable")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task RetryDelayShouldBeCancellableAsync()
        {
            TaskCompletionSource<bool> responseTask = new TaskCompletionSource<bool>();
            BlobRequestOptions options = new BlobRequestOptions();
            options.RetryPolicy = new AlwaysRetry(TimeSpan.FromMinutes(1), 1);
            OperationContext context = new OperationContext();
            context.ResponseReceived += (sender, e) => responseTask.SetResult(true);

            CloudBlobClient blobClient = GenerateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("test" + DateTime.UtcNow.Ticks.ToString());
            CancellationTokenSource token = new CancellationTokenSource();
            Task task = container.FetchAttributesAsync(null, options, context).AsTask(token.Token);

            await responseTask.Task;
            await Task.Delay(10 * 1000);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                token.Cancel();
                await task;
            }
            catch (Exception)
            {
                // This is expected, because we went for an invalid domain name.
            }

            stopwatch.Stop();

            Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromSeconds(10), stopwatch.Elapsed.ToString());
            Assert.AreEqual(1, context.RequestResults.Count);
        }

        [TestMethod]
        /// [Description("Setting retry policy to null should not throw an exception")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task NullRetryPolicyTestAsync()
        {
            CloudBlobClient blobClient = TestBase.GenerateCloudBlobClient();
            blobClient.RetryPolicy = null;

            CloudBlobContainer container = blobClient.GetContainerReference("test");
            await container.ExistsAsync();
        }
    }
}
