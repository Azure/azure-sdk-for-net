// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject = await CreateManagementLockObject(rg, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(true, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(true, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(true);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject = await CreateManagementLockObject(subscription, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().CreateOrUpdateAsync(true, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().CreateOrUpdateAsync(true, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(true);
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResource vn = await CreateGenericVirtualNetwork(subscription, rg, vnName);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject = await CreateManagementLockObject(vn, mgmtLockObjectName);
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(true, null, mgmtLockObject.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(true, mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync(true);
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-");
            ResourceGroup rg = await CreateResourceGroup(subscription, rgName);
            string mgmtLockObjectName1 = Recording.GenerateAssetName("mgmtLock-");
            string mgmtLockObjectName2 = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject1 = await CreateManagementLockObject(rg, mgmtLockObjectName1);
            ManagementLock mgmtLockObject2 = await CreateManagementLockObject(rg, mgmtLockObjectName2);
            int count = 0;
            await foreach (var mgmtLockObject in rg.GetManagementLocks().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
            await mgmtLockObject1.DeleteAsync(true);
            await mgmtLockObject2.DeleteAsync(true);
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-");
            ManagementLock mgmtLockObject = await CreateManagementLockObject(subscription, mgmtLockObjectName);
            ManagementLock getMgmtLockObject = await subscription.GetManagementLocks().GetAsync(mgmtLockObjectName);
            AssertValidManagementLockObject(mgmtLockObject, getMgmtLockObject);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetManagementLocks().GetAsync(null));
            await mgmtLockObject.DeleteAsync(true);
        }
        private void AssertValidManagementLockObject(ManagementLock model, ManagementLock getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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
