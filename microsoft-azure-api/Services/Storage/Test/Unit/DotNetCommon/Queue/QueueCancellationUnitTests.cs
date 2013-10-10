// -----------------------------------------------------------------------------------------
// <copyright file="QueueCancellationUnitTests.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Test.Network;
using Microsoft.WindowsAzure.Test.Network.Behaviors;
using System;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class QueueCancellationUnitTests : QueueTestBase
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
        [Description("Test Set Queue ACL Cancellation")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueSetACLCancellation()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            QueuePermissions permissions = new QueuePermissions();
            permissions.SharedAccessPolicies.Add(Guid.NewGuid().ToString(), new SharedAccessQueuePolicy()
            {
                SharedAccessStartTime = DateTimeOffset.Now - TimeSpan.FromHours(1),
                SharedAccessExpiryTime = DateTimeOffset.Now + TimeSpan.FromHours(1),
                Permissions = SharedAccessQueuePermissions.Add | SharedAccessQueuePermissions.ProcessMessages | SharedAccessQueuePermissions.Read | SharedAccessQueuePermissions.Update
            });

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.QueueTraffic().IfHostNameContains(client.Credentials.AccountName)) },
                (options, opContext, callback, state) => queue.BeginSetPermissions(permissions, (QueueRequestOptions)options, opContext, callback, state),
                queue.EndSetPermissions);
        }

        [TestMethod]
        [Description("Test Get Queue ACL Cancellation")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueGetACLCancellation()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            TestHelper.ExecuteAPMMethodWithCancellation(4000,
                new[] { DelayBehaviors.DelayAllRequestsIf(4000 * 3, XStoreSelectors.QueueTraffic().IfHostNameContains(client.Credentials.AccountName)) },
                (options, opContext, callback, state) => queue.BeginGetPermissions((QueueRequestOptions)options, opContext, callback, state),
                (res) => queue.EndGetPermissions(res));
        }
    }
}
