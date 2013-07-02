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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    /// <summary>
    /// Summary description for CloudQueueClientTest
    /// </summary>
    [TestClass]
    public class CloudQueueClientTest : QueueTestBase
    {
        [TestMethod]
        [Description("A test checks basic function of CloudQueueClient.")]
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
        [Description("A test checks basic function of CloudQueueClient.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientConstructorInvalidParam()
        {
            TestHelper.ExpectedException<ArgumentNullException>(() => new CloudQueueClient(null, TestBase.StorageCredentials), "Pass null into CloudQueueClient");
        }

        [TestMethod]
        [Description("List queues")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientListQueuesBasic()
        {
            string prefix = "lib35queuetest" + Guid.NewGuid().ToString("N");
            List<string> queueNames = new List<string>();
            int count = 30;
            for(int i = 0; i < count ;i ++)
            {
                queueNames.Add(prefix+i);
            }

            List<CloudQueue> emptyResults = DefaultQueueClient.ListQueues(prefix, QueueListingDetails.All, null, null).ToList();
            Assert.AreEqual<int>(0, emptyResults.Count);

            foreach (string name in queueNames)
            {
                DefaultQueueClient.GetQueueReference(name).Create();
            }

            List<CloudQueue> results = DefaultQueueClient.ListQueues(prefix, QueueListingDetails.All, null, null).ToList();
            Assert.AreEqual<int>(results.Count, queueNames.Count);

            foreach (var queue in results)
            {
                if (queueNames.Remove(queue.Name))
                {
                    queue.Delete();
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.AreEqual<int>(0, queueNames.Count);
        }

        [TestMethod]
        [Description("Test Create Queue with Shared Key Lite")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClientCreateQueueSharedKeyLite()
        {
            CloudQueueClient queueClient = new CloudQueueClient(DefaultQueueClient.BaseUri, DefaultQueueClient.Credentials);
            queueClient.AuthenticationScheme = AuthenticationScheme.SharedKeyLite;

            string queueName = Guid.NewGuid().ToString("N");
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            queue.Create();

            bool exists = queue.Exists();
            Assert.IsTrue(exists);
        }
    }
}
