// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueClientTest.cs" company="Microsoft">
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

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueClientTest : QueueTestBase
    {
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (TestBase.QueueBufferManager != null)
            {
                TestBase.QueueBufferManager.OutstandingBufferCount = 0;
            }
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            if (TestBase.QueueBufferManager != null)
            {
                Assert.AreEqual(0, TestBase.QueueBufferManager.OutstandingBufferCount);
            }
        }

        [TestMethod]
        //[Description("A test checks basic function of CloudQueueClient.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientConstructor()
        {
            Uri baseAddressUri = new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint);
            CloudQueueClient queueClient = new CloudQueueClient(baseAddressUri, TestBase.StorageCredentials);
            Assert.IsTrue(queueClient.BaseUri.ToString().StartsWith(TestBase.TargetTenantConfig.QueueServiceEndpoint));
            Assert.AreEqual(TestBase.StorageCredentials, queueClient.Credentials);
            Assert.AreEqual(AuthenticationScheme.SharedKey, queueClient.AuthenticationScheme);
        }

        [TestMethod]
        // [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueClientListQueuesBasicAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = GenerateNewQueueName();
            List<string> queueNames = new List<string>();
            int count = 30;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueResultSegment emptyResults = await client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.All, null, null, null);
            Assert.AreEqual<int>(0, emptyResults.Results.Count());

            foreach (string name in queueNames)
            {
                await client.GetQueueReference(name).CreateAsync();
            }

            QueueResultSegment results = await client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.All, null, null, null);
            
            foreach (CloudQueue queue in results.Results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    await queue.DeleteAsync();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(count, results.Results.Count());
        }

        [TestMethod]
        // [Description("Test Create Queue with Shared Key Lite")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueClientCreateQueueSharedKeyLiteAsync()
        {
            CloudQueueClient queueClient = GenerateCloudQueueClient();
            queueClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string queueName = GenerateNewQueueName();
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            await queue.CreateAsync();

            bool exists = await queue.ExistsAsync();
            Assert.IsTrue(exists);
        }

        [TestMethod]
        // [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueClientListQueuesSegmentedAsync()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            string prefix = "rtqueuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 3;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueContinuationToken token = null;
            List<CloudQueue> results = new List<CloudQueue>();

            do
            {
                QueueResultSegment segment = await client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, null, token, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(0, results.Count);

            foreach (string name in queueNames)
            {
                await client.GetQueueReference(name).CreateAsync();
            }

            do
            {
                QueueResultSegment segment = await client.ListQueuesSegmentedAsync(prefix, QueueListingDetails.None, 10, token, null);
                token = segment.ContinuationToken;
                results.AddRange(segment.Results);
            }
            while (token != null);

            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (CloudQueue queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    await queue.DeleteAsync();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }
    }
}
