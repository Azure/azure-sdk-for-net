// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ManagementLockObjectCollectionTests : ResourceManagerTestBase
    {
        public ManagementLockObjectCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockResource mgmtLockObject = await CreateManagementLockObject(rg, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockResource mgmtLockObject = await CreateManagementLockObject(subscription, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResource vn = await CreateGenericVirtualNetwork(subscription, rg, vnName);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockResource mgmtLockObject = await CreateManagementLockObject(vn, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(WaitUntil.Completed, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(WaitUntil.Completed);
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName);
            string mgmtLockObjectName1 = Recording.GenerateAssetName("mgmtLock-");
            string mgmtLockObjectName2 = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockResource mgmtLockObject1 = await CreateManagementLockObject(rg, mgmtLockObjectName1);
            ManagementLockResource mgmtLockObject2 = await CreateManagementLockObject(rg, mgmtLockObjectName2);
            int count = 0;
            await foreach (var mgmtLockObject in rg.GetManagementLocks().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
            await mgmtLockObject1.DeleteAsync(WaitUntil.Completed);
            await mgmtLockObject2.DeleteAsync(WaitUntil.Completed);
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLockResource mgmtLockObject = await CreateManagementLockObject(subscription, mgmtLockObjectName);
            ManagementLockResource getMgmtLockObject = await subscription.GetManagementLocks().GetAsync(mgmtLockObjectName);
            AssertValidManagementLockObject(mgmtLockObject, getMgmtLockObject);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().GetAsync(null));
            await mgmtLockObject.DeleteAsync(WaitUntil.Completed);
        }
        private void AssertValidManagementLockObject(ManagementLockResource model, ManagementLockResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Level, getResult.Data.Level);
            Assert.AreEqual(model.Data.Notes, getResult.Data.Notes);
            if(model.Data.Owners != null || getResult.Data.Owners != null)
            {
                Assert.NotNull(model.Data.Owners);
                Assert.NotNull(getResult.Data.Owners);
                Assert.AreEqual(model.Data.Owners.Count, getResult.Data.Owners.Count);
                for(int i = 0; i < model.Data.Owners.Count; ++i)
                {
                    Assert.AreEqual(model.Data.Owners[i].ApplicationId, getResult.Data.Owners[i].ApplicationId);
                }
            }
        }
    }
}
