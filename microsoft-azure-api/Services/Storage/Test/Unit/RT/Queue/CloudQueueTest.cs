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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using Microsoft.WindowsAzure.Storage.Auth;
using Windows.Globalization;

namespace Microsoft.WindowsAzure.Storage.Queue
{
    [TestClass]
    public class CloudQueueTest : TestBase
    {
        readonly CloudQueueClient DefalutQueueClient = new CloudQueueClient(new Uri(TestBase.TargetTenantConfig.QueueServiceEndpoint), TestBase.StorageCredentials);

        [TestMethod]
        /// [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueCreateAsync()
        {
            string name = TestHelper.GenerateNewQueueName();
            CloudQueue queue = DefalutQueueClient.GetQueueReference(name);

            await queue.CreateAsync();
            await queue.CreateAsync();
            await queue.DeleteAsync();
        }

        [TestMethod]
        /// [Description("Create and delete a queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueCreateAndDeleteAsync()
        {
            string name = TestHelper.GenerateNewQueueName();
            CloudQueue queue = DefalutQueueClient.GetQueueReference(name);
             
            await queue.CreateAsync();
            await queue.DeleteAsync();
        }

        [TestMethod]
        /// [Description("Try to create a queue after it is created")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueCreateIfNotExistsAsync()
        {
            string name = TestHelper.GenerateNewQueueName();
            CloudQueue queue = DefalutQueueClient.GetQueueReference(name);

            try
            {
                Assert.IsTrue(await queue.CreateIfNotExistsAsync());
                Assert.IsFalse(await queue.CreateIfNotExistsAsync());
            }
            finally
            {
                queue.DeleteIfExistsAsync().AsTask().Wait();
            }
        }

        [TestMethod]
        /// [Description("Try to delete a non-existing queue")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueDeleteIfExistsAsync()
        {
            string name = TestHelper.GenerateNewQueueName();
            CloudQueue queue = DefalutQueueClient.GetQueueReference(name);

            Assert.IsFalse(await queue.DeleteIfExistsAsync());
            await queue.CreateAsync();
            Assert.IsTrue(await queue.DeleteIfExistsAsync());
            Assert.IsFalse(await queue.DeleteIfExistsAsync());
        }

        [TestMethod]
        //[Description("Set/get queue permissions")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueGetSetPermissionsAsync()
        {
            CloudQueue queue = DefalutQueueClient.GetQueueReference(TestHelper.GenerateNewQueueName());

            await queue.CreateAsync();
            QueuePermissions emptyPermission = await queue.GetPermissionsAsync();
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

            await queue.SetPermissionsAsync(permissions);
            await Task.Delay(30 * 1000);

            await queue.FetchAttributesAsync();

            CloudQueue queueToRetrieve = DefalutQueueClient.GetQueueReference(queue.Name);
            QueuePermissions permissionsToRetrieve = await queueToRetrieve.GetPermissionsAsync();

            Assert.AreEqual(permissions.SharedAccessPolicies.Count, permissionsToRetrieve.SharedAccessPolicies.Count);
            //Assert.AreEqual(start, permissionsToRetrieve.SharedAccessPolicies[id].SharedAccessStartTime.Value.UtcDateTime);
            //Assert.AreEqual(expiry, permissionsToRetrieve.SharedAccessPolicies[id].SharedAccessExpiryTime.Value.UtcDateTime);
            Assert.AreEqual(permissions.SharedAccessPolicies[id].Permissions, permissionsToRetrieve.SharedAccessPolicies[id].Permissions);

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Set/get a queue with metadata")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task CloudQueueSetGetMetadataAsync()
        {
            CloudQueue queue = DefalutQueueClient.GetQueueReference(TestHelper.GenerateNewQueueName());

            await queue.CreateAsync();

            CloudQueue queueToRetrieve = DefalutQueueClient.GetQueueReference(queue.Name);
            await queueToRetrieve.FetchAttributesAsync();
            Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);

            queue.Metadata.Add("key1", "value1");
            await queue.SetMetadataAsync();

            await queueToRetrieve.FetchAttributesAsync();
            Assert.AreEqual(1, queueToRetrieve.Metadata.Count);
            Assert.AreEqual("value1", queueToRetrieve.Metadata["key1"]);

            queue.Metadata.Clear();
            await queue.SetMetadataAsync();

            await queueToRetrieve.FetchAttributesAsync();
            Assert.AreEqual<int>(0, queueToRetrieve.Metadata.Count);

            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test queue sas")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task QueueSASTestAsync()
        {
            CloudQueue queue = DefalutQueueClient.GetQueueReference(TestHelper.GenerateNewQueueName());
            await queue.CreateAsync();
            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await queue.AddMessageAsync(message);

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

            await queue.SetPermissionsAsync(permissions);
            await Task.Delay(30 * 1000);

            string sasTokenFromId = queue.GetSharedAccessSignature(null, id);
            StorageCredentials sasCredsFromId = new StorageCredentials(sasTokenFromId);
            CloudQueue sasQueueFromId = new CloudQueue(queue.Uri, sasCredsFromId);
            CloudQueueMessage receivedMessage1 = await sasQueueFromId.PeekMessageAsync();
            Assert.AreEqual(messageContent, receivedMessage1.AsString);

            string sasTokenFromPolicy = queue.GetSharedAccessSignature(permissions.SharedAccessPolicies[id], null);
            StorageCredentials sasCredsFromPolicy = new StorageCredentials(sasTokenFromPolicy);
            CloudQueue sasQueueFromPolicy = new CloudQueue(queue.Uri, sasCredsFromPolicy);
            CloudQueueMessage receivedMessage2 = await sasQueueFromPolicy.PeekMessageAsync();
            Assert.AreEqual(messageContent, receivedMessage2.AsString);
            await queue.DeleteAsync();
        }

        [TestMethod]
        //[Description("Test queue sas")]
        [TestCategory(ComponentCategory.Queue)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public async Task QueueRegionalSASTestAsync()
        {
            string currentPrimaryLanguage = ApplicationLanguages.PrimaryLanguageOverride;
            ApplicationLanguages.PrimaryLanguageOverride = "it";

            CloudQueue queue = DefalutQueueClient.GetQueueReference(TestHelper.GenerateNewQueueName());

            try
            {
                await queue.CreateAsync();
                string messageContent = Guid.NewGuid().ToString();
                CloudQueueMessage message = new CloudQueueMessage(messageContent);
                await queue.AddMessageAsync(message);

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

                await queue.SetPermissionsAsync(permissions);
                await Task.Delay(30 * 1000);

                string sasTokenFromId = queue.GetSharedAccessSignature(null, id);
                StorageCredentials sasCredsFromId = new StorageCredentials(sasTokenFromId);
                CloudQueue sasQueueFromId = new CloudQueue(queue.Uri, sasCredsFromId);
                CloudQueueMessage receivedMessage1 = await sasQueueFromId.PeekMessageAsync();
                Assert.AreEqual(messageContent, receivedMessage1.AsString);

                string sasTokenFromPolicy = queue.GetSharedAccessSignature(permissions.SharedAccessPolicies[id], null);
                StorageCredentials sasCredsFromPolicy = new StorageCredentials(sasTokenFromPolicy);
                CloudQueue sasQueueFromPolicy = new CloudQueue(queue.Uri, sasCredsFromPolicy);
                CloudQueueMessage receivedMessage2 = await sasQueueFromPolicy.PeekMessageAsync();
                Assert.AreEqual(messageContent, receivedMessage2.AsString);
            }
            finally
            {
                ApplicationLanguages.PrimaryLanguageOverride = currentPrimaryLanguage;
                queue.DeleteAsync().AsTask().Wait();
            }
        }
    }
}
