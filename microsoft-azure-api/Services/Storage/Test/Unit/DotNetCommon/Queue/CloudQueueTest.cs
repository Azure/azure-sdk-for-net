// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueueTest.cs" company="Microsoft">
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
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueTest : QueueTestBase
    {        
        [TestMethod]
        [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDelete()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);
            queue.Create();
            queue.Delete();
        }

        [TestMethod]
        [Description("Create a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateUsingDifferenctVersionHeader()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (obj, args) => args.Request.Headers[Constants.HeaderConstants.StorageVersionHeader] = "2011-08-18";

            queue.Create(null, opContext);
            Assert.AreEqual((int)HttpStatusCode.Created, opContext.LastResult.HttpStatusCode);

            queue.DeleteIfExists();
        }

        [TestMethod]
        [Description("Try to create a queue after it is created")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExists()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);

            try
            {
                Assert.IsTrue(queue.CreateIfNotExists());
                Assert.IsFalse(queue.CreateIfNotExists());
            }
            finally
            {
                queue.Delete();
            }
        }

        [TestMethod]
        [Description("Try to delete a non-existing queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExists()
        {
            string name = GenerateNewQueueName();
            CloudQueue queue = DefaultQueueClient.GetQueueReference(name);

            Assert.IsFalse(queue.DeleteIfExists());
            queue.Create();
            Assert.IsTrue(queue.DeleteIfExists());
            Assert.IsFalse(queue.DeleteIfExists());
        }

        [TestMethod]
        [Description("Set/get queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetSetPermissions()
        {
            CloudQueue queue = DefaultQueueClient.GetQueueReference(GenerateNewQueueName());
           
            try
            {
                queue.Create();
                QueuePermissions emptyPermission = queue.GetPermissions();
                Assert.AreEqual(emptyPermission.SharedAccessPolicies.Count, 0);
                string id = Guid.NewGuid().ToString();
                DateTime start = DateTime.UtcNow;
                DateTime expiry = start.AddMinutes(30);
                QueuePermissions permissions = new QueuePermissions();
                SharedAccessQueuePermissions queuePerm = SharedAccessQueuePermissions.Add|SharedAccessQueuePermissions.ProcessMessages|SharedAccessQueuePermissions.Read|SharedAccessQueuePermissions.Update;
                permissions.SharedAccessPolicies.Add(id, new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = queuePerm
                });

                queue.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                CloudQueue queueToRetrieve = DefaultQueueClient.GetQueueReference(queue.Name);
                QueuePermissions permissionsToRetrieve = queueToRetrieve.GetPermissions();

                Assert.AreEqual(permissions.SharedAccessPolicies.Count, permissionsToRetrieve.SharedAccessPolicies.Count);
                //Assert.AreEqual(start, permissionsToRetrieve.SharedAccessPolicies[id].SharedAccessStartTime.Value.UtcDateTime);
                //Assert.AreEqual(expiry, permissionsToRetrieve.SharedAccessPolicies[id].SharedAccessExpiryTime.Value.UtcDateTime);
                Assert.AreEqual(permissions.SharedAccessPolicies[id].Permissions, permissionsToRetrieve.SharedAccessPolicies[id].Permissions);
                
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Set/get a queue with metadata")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueSetGetMetadata()
        {
            CloudQueue queue = DefaultQueueClient.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();

                CloudQueue queueToRetrieve = DefaultQueueClient.GetQueueReference(queue.Name);
                queueToRetrieve.FetchAttributes();
                Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);

                queue.Metadata.Add("key1", "value1");
                queue.SetMetadata();

                queueToRetrieve.FetchAttributes();
                Assert.AreEqual(1, queueToRetrieve.Metadata.Count);
                Assert.AreEqual("value1", queueToRetrieve.Metadata["key1"]);

                queue.Metadata.Clear();
                queue.SetMetadata();

                queueToRetrieve.FetchAttributes();
                Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test queue sas")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueSASTest()
        {
            CloudQueue queue = DefaultQueueClient.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();
                string messageContent = Guid.NewGuid().ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);

                // Prepare SAS authentication with full permissions
                string id = Guid.NewGuid().ToString();
                DateTime start = DateTime.UtcNow;
                DateTime expiry = start.AddMinutes(30);
                QueuePermissions permissions = new QueuePermissions();
                SharedAccessQueuePermissions queuePerm = SharedAccessQueuePermissions.Add | SharedAccessQueuePermissions.ProcessMessages | SharedAccessQueuePermissions.Read | SharedAccessQueuePermissions.Update;
                permissions.SharedAccessPolicies.Add(id, new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = queuePerm
                });

                queue.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                string sasTokenFromId = queue.GetSharedAccessSignature(null, id);
                StorageCredentials sasCredsFromId = new StorageCredentials(sasTokenFromId);
                CloudQueue sasQueueFromId = new CloudQueue(queue.Uri, sasCredsFromId);
                CloudQueueMessage receivedMessage1 = sasQueueFromId.PeekMessage();
                Assert.AreEqual(messageContent, receivedMessage1.AsString);

                string sasTokenFromPolicy = queue.GetSharedAccessSignature(permissions.SharedAccessPolicies[id], null);
                StorageCredentials sasCredsFromPolicy = new StorageCredentials(sasTokenFromPolicy);
                CloudQueue sasQueueFromPolicy = new CloudQueue(queue.Uri, sasCredsFromPolicy);
                CloudQueueMessage receivedMessage2 = sasQueueFromPolicy.PeekMessage();
                Assert.AreEqual(messageContent, receivedMessage2.AsString);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Test queue listing")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ListQueuesSegmentedTest()
        {
            String prefix = "pagingqueuetest" + Guid.NewGuid();
            ///Create 20 queues
            for (int i = 1; i <= 20; i++)
            {
                CloudQueue myqueue = DefaultQueueClient.GetQueueReference( prefix + i  );
                myqueue.CreateIfNotExists();
            }

            ///Segmented listing of queues.
            ///Return a page of 10 queues beginning with the specified prefix.
            ///Check with options and context as NULL
            QueueResultSegment resultSegment = DefaultQueueClient.ListQueuesSegmented(prefix, QueueListingDetails.None, 10, null, null, null);

            IEnumerable<CloudQueue> list = resultSegment.Results;
            int count = 0;
            foreach (CloudQueue item in list)
            {
                count++;
                item.Delete();
            }
            Assert.AreEqual(10,count);
            Assert.IsNotNull(resultSegment.ContinuationToken);

            OperationContext context = new OperationContext();
            QueueRequestOptions options = new QueueRequestOptions();

            ///Check with options and context having some value

            QueueResultSegment resultSegment2 = DefaultQueueClient.ListQueuesSegmented(prefix, QueueListingDetails.None, 10, resultSegment.ContinuationToken, options, context);
            IEnumerable<CloudQueue> list2 = resultSegment2.Results;
            foreach (CloudQueue item in list2)
            {
                item.Delete();
            }
            Assert.IsNull(resultSegment2.ContinuationToken);
        }

        [TestMethod]
        [Description("Test empty headers")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueEmptyHeaderSigningTest()
        {
            CloudQueue queue = DefaultQueueClient.GetQueueReference(Guid.NewGuid().ToString("N"));
            OperationContext context = new OperationContext();
            try
            {
                context.UserHeaders = new Dictionary<string, string>();
                context.UserHeaders.Add("x-ms-foo", String.Empty);
                queue.Create(null, context);
                CloudQueueMessage message = new CloudQueueMessage("Hello Signing");
                queue.AddMessage(message, null, null, null, context);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }
    }
}
