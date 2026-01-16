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
            Assert.That(mgmtLockObject.Data.Name, Is.EqualTo(mgmtLockObjectName));
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
            Assert.That(mgmtLockObject.Data.Name, Is.EqualTo(mgmtLockObjectName));
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
            Assert.That(mgmtLockObject.Data.Name, Is.EqualTo(mgmtLockObjectName));
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
            Assert.That(count, Is.EqualTo(2));
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
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Level, Is.EqualTo(model.Data.Level));
            Assert.That(getResult.Data.Notes, Is.EqualTo(model.Data.Notes));
            if(model.Data.Owners != null || getResult.Data.Owners != null)
            {
                Assert.That(model.Data.Owners, Is.Not.Null);
                Assert.That(getResult.Data.Owners, Is.Not.Null);
                Assert.That(getResult.Data.Owners.Count, Is.EqualTo(model.Data.Owners.Count));
                for(int i = 0; i < model.Data.Owners.Count; ++i)
                {
                    Assert.That(getResult.Data.Owners[i].ApplicationId, Is.EqualTo(model.Data.Owners[i].ApplicationId));
                }
            }
        }
    }
}
