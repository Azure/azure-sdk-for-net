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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if WINDOWS_DESKTOP
using System.Threading.Tasks;
#endif

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueTest : QueueTestBase
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
        [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDelete()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();
            queue.Delete();
        }

        [TestMethod]
        [Description("Create and delete a queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDeleteAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginCreate(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndCreate(result);

                result = queue.BeginExists(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsTrue(queue.EndExists(result));

                result = queue.BeginDelete(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDelete(result);
            }
        }

#if TASK
        [TestMethod]
        [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDeleteTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.CreateAsync().Wait();
            queue.ExistsAsync().Wait();
            queue.DeleteAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Create and delete a queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDeleteFullParameterAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginCreate(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndCreate(result);

                result = queue.BeginExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsTrue(queue.EndExists(result));

                result = queue.BeginDelete(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDelete(result);
            }
        }

#if TASK
        [TestMethod]
        [Description("Create and delete a queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateAndDeleteFullParameterTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            queue.CreateAsync(null, new OperationContext()).Wait();;

            Assert.IsTrue(queue.ExistsAsync(null, new OperationContext()).Result);

            queue.DeleteAsync(null, new OperationContext()).Wait();
        }
#endif

        [TestMethod]
        [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateFromUri()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);
            queue.Create();

            // Create cloud queue from constructor
            CloudQueue sameQueue = new CloudQueue(queue.Uri);

            // Test that queue is the same
            Assert.IsTrue(sameQueue.Name.Equals(queue.Name));
            Assert.IsTrue(sameQueue.Uri.Equals(queue.Uri));

            queue.Delete();
        }

        [TestMethod]
        [Description("Create a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateUsingDifferentVersionHeader()
        {
            string name = GenerateNewQueueName();

            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (obj, args) => args.Request.Headers[Constants.HeaderConstants.StorageVersionHeader] = "2011-08-18";

            queue.Create(null, opContext);
            Assert.AreEqual((int)HttpStatusCode.Created, opContext.LastResult.HttpStatusCode);

            queue.DeleteIfExists();
        }

        [TestMethod]
        [Description("Create a queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateUsingDifferentVersionHeaderAPM()
        {
            string name = GenerateNewQueueName();

            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (obj, args) => args.Request.Headers[Constants.HeaderConstants.StorageVersionHeader] = "2011-08-18";

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginCreate(null, opContext, ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndCreate(result);

                Assert.AreEqual((int)HttpStatusCode.Created, opContext.LastResult.HttpStatusCode);

                result = queue.BeginDeleteIfExists(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndDeleteIfExists(result);
            }
        }

#if TASK
        [TestMethod]
        [Description("Create a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateUsingDifferentVersionHeaderTask()
        {
            string name = GenerateNewQueueName();

            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            OperationContext opContext = new OperationContext();
            opContext.SendingRequest += (obj, args) => args.Request.Headers[Constants.HeaderConstants.StorageVersionHeader] = "2011-08-18";

            queue.CreateAsync(null, opContext).Wait();
            Assert.AreEqual((int)HttpStatusCode.Created, opContext.LastResult.HttpStatusCode);

            queue.DeleteIfExistsAsync().Wait();
        }
#endif

        [TestMethod]
        [Description("Try to create a queue after it is created")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExists()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

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
        [Description("Try to create a queue after it is created with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExistsAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            try
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = queue.BeginCreateIfNotExists(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(queue.EndCreateIfNotExists(result));

                    result = queue.BeginCreateIfNotExists(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(queue.EndCreateIfNotExists(result));
                }
            }
            finally
            {
                queue.Delete();
            }
        }

        [TestMethod]
        [Description("Try to create a queue after it is created with APM.")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExistsFullParameterAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            try
            {
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = queue.BeginCreateIfNotExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    Assert.IsTrue(queue.EndCreateIfNotExists(result));

                    result = queue.BeginCreateIfNotExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    Assert.IsFalse(queue.EndCreateIfNotExists(result));
                }
            }
            finally
            {
                queue.Delete();
            }
        }

#if TASK
        [TestMethod]
        [Description("Try to create a queue after it is created")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExistsTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            try
            {
                Assert.IsTrue(queue.CreateIfNotExistsAsync().Result);
                Assert.IsFalse(queue.CreateIfNotExistsAsync().Result);
            }
            finally
            {
                queue.DeleteAsync().Wait();
            }
        }

        [TestMethod]
        [Description("Try to create a queue after it is created")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCreateIfNotExistsFullParameterTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            try
            {
                Assert.IsTrue(queue.CreateIfNotExistsAsync(null, new OperationContext()).Result);
                Assert.IsFalse(queue.CreateIfNotExistsAsync(null, new OperationContext()).Result);
            }
            finally
            {
                queue.DeleteAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Try to delete a non-existing queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExists()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            Assert.IsFalse(queue.DeleteIfExists());
            queue.Create();
            Assert.IsTrue(queue.DeleteIfExists());
            Assert.IsFalse(queue.DeleteIfExists());
        }

        [TestMethod]
        [Description("Try to delete a non-existing queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExistsAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginDeleteIfExists(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsFalse(queue.EndDeleteIfExists(result));

                result = queue.BeginCreate(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndCreate(result);

                result = queue.BeginDeleteIfExists(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsTrue(queue.EndDeleteIfExists(result));

                result = queue.BeginDeleteIfExists(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsFalse(queue.EndDeleteIfExists(result));
            }
        }

        [TestMethod]
        [Description("Try to delete a non-existing queue with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExistsFullParameterAPM()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {
                IAsyncResult result = queue.BeginDeleteIfExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsFalse(queue.EndDeleteIfExists(result));

                result = queue.BeginCreate(ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                queue.EndCreate(result);

                result = queue.BeginDeleteIfExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsTrue(queue.EndDeleteIfExists(result));

                result = queue.BeginDeleteIfExists(null, new OperationContext(), ar => waitHandle.Set(), null);
                waitHandle.WaitOne();
                Assert.IsFalse(queue.EndDeleteIfExists(result));
            }
        }

#if TASK
        [TestMethod]
        [Description("Try to delete a non-existing queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExistsTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            Assert.IsFalse(queue.DeleteIfExistsAsync().Result);
            queue.CreateAsync().Wait();
            Assert.IsTrue(queue.DeleteIfExistsAsync().Result);
            Assert.IsFalse(queue.DeleteIfExistsAsync().Result);
        }

        [TestMethod]
        [Description("Try to delete a non-existing queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueDeleteIfExistsFullParametersTask()
        {
            string name = GenerateNewQueueName();
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(name);

            Assert.IsFalse(queue.DeleteIfExistsAsync(null, new OperationContext()).Result);
            queue.CreateAsync().Wait();
            Assert.IsTrue(queue.DeleteIfExistsAsync(null, new OperationContext()).Result);
            Assert.IsFalse(queue.DeleteIfExistsAsync(null, new OperationContext()).Result);
        }
#endif

        [TestMethod]
        [Description("Set/get queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetSetPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();
                QueuePermissions emptyPermission = queue.GetPermissions();
                Assert.AreEqual(emptyPermission.SharedAccessPolicies.Count, 0);
                string id = Guid.NewGuid().ToString();
                DateTime start = DateTime.UtcNow;
                DateTime expiry = start.AddMinutes(30);
                QueuePermissions permissions = new QueuePermissions();

                SharedAccessQueuePermissions queuePerm = SharedAccessQueuePermissions.Add
                                                         | SharedAccessQueuePermissions.ProcessMessages
                                                         | SharedAccessQueuePermissions.Read
                                                         | SharedAccessQueuePermissions.Update;
                permissions.SharedAccessPolicies.Add(
                    id,
                    new SharedAccessQueuePolicy()
                        {
                            SharedAccessStartTime = start,
                            SharedAccessExpiryTime = expiry,
                            Permissions = queuePerm
                        });

                queue.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);
                QueuePermissions permissionsToRetrieve = queueToRetrieve.GetPermissions();

                AssertPermissionsEqual(permissions, permissionsToRetrieve);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Set/get queue permissions with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetSetPermissionsAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();

                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = queue.BeginGetPermissions(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueuePermissions emptyPermission = queue.EndGetPermissions(result);

                    Assert.AreEqual(emptyPermission.SharedAccessPolicies.Count, 0);

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

                    result = queue.BeginSetPermissions(permissions, ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndSetPermissions(result);

                    Thread.Sleep(30 * 1000);

                    CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);

                    result = queueToRetrieve.BeginGetPermissions(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    QueuePermissions permissionsToRetrieve = queueToRetrieve.EndGetPermissions(result);

                    AssertPermissionsEqual(permissions, permissionsToRetrieve);
                }
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Set/get queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetSetPermissionsTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.CreateAsync().Wait();
                QueuePermissions emptyPermission = queue.GetPermissionsAsync().Result;
                Assert.AreEqual(emptyPermission.SharedAccessPolicies.Count, 0);
                string id = Guid.NewGuid().ToString();
                DateTime start = DateTime.UtcNow;
                DateTime expiry = start.AddMinutes(30);
                QueuePermissions permissions = new QueuePermissions();

                SharedAccessQueuePermissions queuePerm = SharedAccessQueuePermissions.Add
                                                         | SharedAccessQueuePermissions.ProcessMessages
                                                         | SharedAccessQueuePermissions.Read
                                                         | SharedAccessQueuePermissions.Update;
                permissions.SharedAccessPolicies.Add(
                    id,
                    new SharedAccessQueuePolicy()
                        {
                            SharedAccessStartTime = start,
                            SharedAccessExpiryTime = expiry,
                            Permissions = queuePerm
                        });

                queue.SetPermissionsAsync(permissions).Wait();
                Thread.Sleep(30 * 1000);

                CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);
                QueuePermissions permissionsToRetrieve = queueToRetrieve.GetPermissionsAsync(null, null).Result;

                AssertPermissionsEqual(permissions, permissionsToRetrieve);
            }
            finally
            {
                queue.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Set/get a queue with metadata")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueSetGetMetadata()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();

                CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);
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
        [Description("Set/get a queue with metadata with APM")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueSetGetMetadataAPM()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();
                CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);
                using (AutoResetEvent waitHandle = new AutoResetEvent(false))
                {
                    IAsyncResult result = queueToRetrieve.BeginFetchAttributes(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queueToRetrieve.EndFetchAttributes(result);

                    Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);

                    queue.Metadata.Add("key1", "value1");
                    result = queue.BeginSetMetadata(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndSetMetadata(result);

                    result = queueToRetrieve.BeginFetchAttributes(ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queueToRetrieve.EndFetchAttributes(result);
                    Assert.AreEqual(1, queueToRetrieve.Metadata.Count);
                    Assert.AreEqual("value1", queueToRetrieve.Metadata["key1"]);

                    queue.Metadata.Clear();
                    result = queue.BeginSetMetadata(null, new OperationContext(), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queue.EndSetMetadata(result);

                    result = queueToRetrieve.BeginFetchAttributes(null, new OperationContext(), ar => waitHandle.Set(), null);
                    waitHandle.WaitOne();
                    queueToRetrieve.EndFetchAttributes(result);
                    Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);
                }
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

#if TASK
        [TestMethod]
        [Description("Set/get a queue with metadata")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueSetGetMetadataTask()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.CreateAsync().Wait();

                CloudQueue queueToRetrieve = client.GetQueueReference(queue.Name);
                queueToRetrieve.FetchAttributesAsync().Wait();
                Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);

                queue.Metadata.Add("key1", "value1");
                queue.SetMetadataAsync().Wait();

                queueToRetrieve.FetchAttributesAsync().Wait();
                Assert.AreEqual(1, queueToRetrieve.Metadata.Count);
                Assert.AreEqual("value1", queueToRetrieve.Metadata["key1"]);

                queue.Metadata.Clear();
                queue.SetMetadataAsync(null, new OperationContext()).Wait();

                queueToRetrieve.FetchAttributesAsync(null, new OperationContext()).Wait();
                Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);
            }
            finally
            {
                queue.DeleteIfExistsAsync().Wait();
            }
        }
#endif

        [TestMethod]
        [Description("Test queue sas")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueSASTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

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
        [Description("Test queue sas with Italy regional settings")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void QueueRegionalSASTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("it-IT");

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
                Thread.CurrentThread.CurrentCulture = currentCulture;
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Set queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueSetPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();
                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                queue.SetPermissions(permissions);
                Thread.Sleep(30 * 1000);

                CloudQueue queue2 = queue.ServiceClient.GetQueueReference(queue.Name);
                permissions = queue2.GetPermissions();
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.HasValue);
                Assert.AreEqual(start, permissions.SharedAccessPolicies["key1"].SharedAccessStartTime.Value.UtcDateTime);
                Assert.IsTrue(permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.HasValue);
                Assert.AreEqual(expiry, permissions.SharedAccessPolicies["key1"].SharedAccessExpiryTime.Value.UtcDateTime);
                Assert.AreEqual(SharedAccessQueuePermissions.Read, permissions.SharedAccessPolicies["key1"].Permissions);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Clear queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueClearPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                queue.SetPermissions(permissions);
                Thread.Sleep(3 * 1000);
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);

                Assert.AreEqual(true, permissions.SharedAccessPolicies.Contains(sharedAccessPolicy));
                Assert.AreEqual(true, permissions.SharedAccessPolicies.ContainsKey("key1"));
                permissions.SharedAccessPolicies.Clear();
                queue.SetPermissions(permissions);
                Thread.Sleep(3 * 1000);
                permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Copy queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueCopyPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                DateTime start2 = DateTime.UtcNow;
                start2 = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry2 = start.AddMinutes(30);
                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy2 = new KeyValuePair<string, SharedAccessQueuePolicy>("key2", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start2,
                    SharedAccessExpiryTime = expiry2,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);

                KeyValuePair<String, SharedAccessQueuePolicy>[] sharedAccessPolicyArray = new KeyValuePair<string, SharedAccessQueuePolicy>[2];
                permissions.SharedAccessPolicies.CopyTo(sharedAccessPolicyArray, 0);
                Assert.AreEqual(2, sharedAccessPolicyArray.Length);
                Assert.AreEqual(sharedAccessPolicy, sharedAccessPolicyArray[0]);
                Assert.AreEqual(sharedAccessPolicy2, sharedAccessPolicyArray[1]);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Remove queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueRemovePermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                DateTime start2 = DateTime.UtcNow;
                start2 = new DateTime(start2.Year, start2.Month, start2.Day, start2.Hour, start2.Minute, start2.Second, DateTimeKind.Utc);
                DateTime expiry2 = start2.AddMinutes(30);
                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy2 = new KeyValuePair<string, SharedAccessQueuePolicy>("key2", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start2,
                    SharedAccessExpiryTime = expiry2,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);
                queue.SetPermissions(permissions);
                Assert.AreEqual(2, permissions.SharedAccessPolicies.Count);

                permissions.SharedAccessPolicies.Remove(sharedAccessPolicy2);
                queue.SetPermissions(permissions);
                Thread.Sleep(3 * 1000);

                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                permissions = queue.GetPermissions();
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                Assert.AreEqual(sharedAccessPolicy.Key, permissions.SharedAccessPolicies.ElementAt(0).Key);
                Assert.AreEqual(sharedAccessPolicy.Value.Permissions, permissions.SharedAccessPolicies.ElementAt(0).Value.Permissions);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessStartTime, permissions.SharedAccessPolicies.ElementAt(0).Value.SharedAccessStartTime);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessExpiryTime, permissions.SharedAccessPolicies.ElementAt(0).Value.SharedAccessExpiryTime);

                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);
                queue.SetPermissions(permissions);
                Assert.AreEqual(2, permissions.SharedAccessPolicies.Count);

                permissions.SharedAccessPolicies.Remove("key2");
                queue.SetPermissions(permissions);
                Thread.Sleep(3 * 1000);
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                permissions = queue.GetPermissions();
                Assert.AreEqual(1, permissions.SharedAccessPolicies.Count);
                Assert.AreEqual(sharedAccessPolicy.Key, permissions.SharedAccessPolicies.ElementAt(0).Key);
                Assert.AreEqual(sharedAccessPolicy.Value.Permissions, permissions.SharedAccessPolicies.ElementAt(0).Value.Permissions);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessStartTime, permissions.SharedAccessPolicies.ElementAt(0).Value.SharedAccessStartTime);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessExpiryTime, permissions.SharedAccessPolicies.ElementAt(0).Value.SharedAccessExpiryTime);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("TryGetValue for queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueTryGetValuePermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                DateTime start2 = DateTime.UtcNow;
                start2 = new DateTime(start2.Year, start2.Month, start2.Day, start2.Hour, start2.Minute, start2.Second, DateTimeKind.Utc);
                DateTime expiry2 = start2.AddMinutes(30);
                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy2 = new KeyValuePair<string, SharedAccessQueuePolicy>("key2", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start2,
                    SharedAccessExpiryTime = expiry2,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);
                queue.SetPermissions(permissions);
                Thread.Sleep(3 * 1000);
                Assert.AreEqual(2, permissions.SharedAccessPolicies.Count);

                permissions = queue.GetPermissions();
                SharedAccessQueuePolicy retrPolicy;
                permissions.SharedAccessPolicies.TryGetValue("key1", out retrPolicy);
                Assert.AreEqual(sharedAccessPolicy.Value.Permissions, retrPolicy.Permissions);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessStartTime, retrPolicy.SharedAccessStartTime);
                Assert.AreEqual(sharedAccessPolicy.Value.SharedAccessExpiryTime, retrPolicy.SharedAccessExpiryTime);

                SharedAccessQueuePolicy retrPolicy2;
                permissions.SharedAccessPolicies.TryGetValue("key2", out retrPolicy2);
                Assert.AreEqual(sharedAccessPolicy2.Value.Permissions, retrPolicy2.Permissions);
                Assert.AreEqual(sharedAccessPolicy2.Value.SharedAccessStartTime, retrPolicy2.SharedAccessStartTime);
                Assert.AreEqual(sharedAccessPolicy2.Value.SharedAccessExpiryTime, retrPolicy2.SharedAccessExpiryTime);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("GetEnumerator for queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetEnumeratorPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                DateTime start2 = DateTime.UtcNow;
                start2 = new DateTime(start2.Year, start2.Month, start2.Day, start2.Hour, start2.Minute, start2.Second, DateTimeKind.Utc);
                DateTime expiry2 = start2.AddMinutes(30);
                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy2 = new KeyValuePair<string, SharedAccessQueuePolicy>("key2", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start2,
                    SharedAccessExpiryTime = expiry2,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);
                Assert.AreEqual(2, permissions.SharedAccessPolicies.Count);

                IEnumerator<KeyValuePair<string, SharedAccessQueuePolicy>> policies = permissions.SharedAccessPolicies.GetEnumerator();
                policies.MoveNext();
                Assert.AreEqual(sharedAccessPolicy, policies.Current);
                policies.MoveNext();
                Assert.AreEqual(sharedAccessPolicy2, policies.Current);
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("GetValues for queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudQueueGetValuesPermissions()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());
            try
            {
                queue.Create();

                QueuePermissions permissions = queue.GetPermissions();
                Assert.AreEqual(0, permissions.SharedAccessPolicies.Count);

                // We do not have precision at milliseconds level. Hence, we need
                // to recreate the start DateTime to be able to compare it later.
                DateTime start = DateTime.UtcNow;
                start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second, DateTimeKind.Utc);
                DateTime expiry = start.AddMinutes(30);

                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy = new KeyValuePair<string, SharedAccessQueuePolicy>("key1", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start,
                    SharedAccessExpiryTime = expiry,
                    Permissions = SharedAccessQueuePermissions.Read,
                });

                DateTime start2 = DateTime.UtcNow;
                start2 = new DateTime(start2.Year, start2.Month, start2.Day, start2.Hour, start2.Minute, start2.Second, DateTimeKind.Utc);
                DateTime expiry2 = start2.AddMinutes(30);
                KeyValuePair<String, SharedAccessQueuePolicy> sharedAccessPolicy2 = new KeyValuePair<string, SharedAccessQueuePolicy>("key2", new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = start2,
                    SharedAccessExpiryTime = expiry2,
                    Permissions = SharedAccessQueuePermissions.Read,
                });
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy);
                permissions.SharedAccessPolicies.Add(sharedAccessPolicy2);
                Assert.AreEqual(2, permissions.SharedAccessPolicies.Count);

                ICollection<SharedAccessQueuePolicy> values = permissions.SharedAccessPolicies.Values;
                Assert.AreEqual(2, values.Count);
                Assert.AreEqual(sharedAccessPolicy.Value, values.ElementAt(0));
                Assert.AreEqual(sharedAccessPolicy2.Value, values.ElementAt(1));
            }
            finally
            {
                queue.DeleteIfExists();
            }
        }

        [TestMethod]
        [Description("Update queue sas")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void UpdateQueueSASTest()
        {
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(GenerateNewQueueName());

            try
            {
                queue.Create();
                string messageContent = Guid.NewGuid().ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                queue.AddMessage(message);
                SharedAccessQueuePolicy policy = new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = SharedAccessQueuePermissions.Add | SharedAccessQueuePermissions.ProcessMessages,
                };
                string id = Guid.NewGuid().ToString();
                string sasToken = queue.GetSharedAccessSignature(policy, null);

                StorageCredentials sasCreds = new StorageCredentials(sasToken);
                CloudQueue sasQueue = new CloudQueue(queue.Uri, sasCreds);

                TestHelper.ExpectedException(
                    () => sasQueue.PeekMessage(),
                    "Peek when Sas does not allow Read access on the queue",
                    HttpStatusCode.NotFound);

                sasQueue.AddMessage(message);

                SharedAccessQueuePolicy policy2 = new SharedAccessQueuePolicy()
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(30),
                    Permissions = SharedAccessQueuePermissions.Add | SharedAccessQueuePermissions.ProcessMessages | SharedAccessQueuePermissions.Read,
                };

                string sasToken2 = queue.GetSharedAccessSignature(policy2, null);
                sasCreds.UpdateSASToken(sasToken2);
                sasQueue = new CloudQueue(queue.Uri, sasCreds);

                sasQueue.PeekMessage();
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
            CloudQueueClient client = GenerateCloudQueueClient();
            ///Create 20 queues
            for (int i = 1; i <= 20; i++)
            {
                CloudQueue myqueue = client.GetQueueReference(prefix + i);
                myqueue.CreateIfNotExists();
            }

            ///Segmented listing of queues.
            ///Return a page of 10 queues beginning with the specified prefix.
            ///Check with options and context as NULL
            QueueResultSegment resultSegment = client.ListQueuesSegmented(prefix, QueueListingDetails.None, 10, null, null, null);

            IEnumerable<CloudQueue> list = resultSegment.Results;
            int count = 0;
            foreach (CloudQueue item in list)
            {
                count++;
                item.Delete();
            }
            Assert.AreEqual(10, count);
            Assert.IsNotNull(resultSegment.ContinuationToken);

            OperationContext context = new OperationContext();
            QueueRequestOptions options = new QueueRequestOptions();

            ///Check with options and context having some value

            QueueResultSegment resultSegment2 = client.ListQueuesSegmented(prefix, QueueListingDetails.None, 10, resultSegment.ContinuationToken, options, context);
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
            CloudQueueClient client = GenerateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(Guid.NewGuid().ToString("N"));
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

        #region Test Helpers
        internal static void AssertPermissionsEqual(QueuePermissions permissions1, QueuePermissions permissions2)
        {
            Assert.AreEqual(permissions1.SharedAccessPolicies.Count, permissions2.SharedAccessPolicies.Count);

            foreach (KeyValuePair<string, SharedAccessQueuePolicy> pair in permissions1.SharedAccessPolicies)
            {
                SharedAccessQueuePolicy policy1 = pair.Value;
                SharedAccessQueuePolicy policy2 = permissions2.SharedAccessPolicies[pair.Key];

                Assert.IsNotNull(policy1);
                Assert.IsNotNull(policy2);

                Assert.AreEqual(policy1.Permissions, policy2.Permissions);
                if (policy1.SharedAccessStartTime != null)
                {
                    Assert.IsTrue(Math.Floor((policy1.SharedAccessStartTime.Value - policy2.SharedAccessStartTime.Value).TotalSeconds) == 0);
                }

                if (policy1.SharedAccessExpiryTime != null)
                {
                    Assert.IsTrue(Math.Floor((policy1.SharedAccessExpiryTime.Value - policy2.SharedAccessExpiryTime.Value).TotalSeconds) == 0);
                }
            }
        }
        #endregion
    }
}
