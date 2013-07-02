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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueClientTest : TestBase
    {
        readonly CloudQueueClient DefaultQueueClient = new CloudQueueClient(new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint), TestBase.StorageCredentials);

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
            string prefix = TestHelper.GenerateNewQueueName();
            List<string> queueNames = new List<string>();
            int count = 2;
            for (int i = 0; i < count; i++)
            {
                queueNames.Add(prefix + i);
            }

            QueueResultSegment emptyResults = await DefaultQueueClient.ListQueuesSegmentedAsync(prefix, QueueListingDetails.All, null, null, null);
            Assert.AreEqual<int>(0, emptyResults.Results.Count());

            foreach (string name in queueNames)
            {
                await DefaultQueueClient.GetQueueReference(name).CreateAsync();
            }

            QueueResultSegment results = await DefaultQueueClient.ListQueuesSegmentedAsync(prefix, QueueListingDetails.All, null, null, null);
            
            foreach (var queue in results.Results)
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
            CloudQueueClient queueClient = new CloudQueueClient(DefaultQueueClient.BaseUri, DefaultQueueClient.Credentials);
            queueClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string queueName = TestHelper.GenerateNewQueueName();
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            await queue.CreateAsync();

            bool exists = await queue.ExistsAsync();
            Assert.IsTrue(exists);
        }
    }
}
