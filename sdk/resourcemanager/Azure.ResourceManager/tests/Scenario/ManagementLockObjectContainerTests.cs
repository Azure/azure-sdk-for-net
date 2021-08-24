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
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Tests
{
    public class ManagementLockObjectContainerTests : ResourceManagerTestBase
    {
        public ManagementLockObjectContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResourceGroup()
        {
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-C-");
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await rg.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, mgmtLockObjectData)).Value;
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(null, mgmtLockObjectData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtSubscription()
        {
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-C-");
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await Client.DefaultSubscription.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, mgmtLockObjectData)).Value;
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetManagementLocks().CreateOrUpdateAsync(null, mgmtLockObjectData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateAtResource()
        {
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string vnName = Recording.GenerateAssetName("testVn-");
            GenericResourceData vnData = ConstructGenericVirtualNetwork();
            ResourceIdentifier vnId = rg.Id.AppendProviderResource("Microsoft.Network", "virtualNetworks", vnName);
            GenericResource vn = await Client.DefaultSubscription.GetGenericResources().CreateOrUpdateAsync(vnId, vnData);
            string mgmtLockObjectName = Recording.GenerateAssetName("mgmtLock-C-");
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await vn.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, mgmtLockObjectData)).Value;
            Assert.AreEqual(mgmtLockObjectName, mgmtLockObject.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(null, mgmtLockObjectData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await vn.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, null));
            await mgmtLockObject.DeleteAsync();
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(rgName);
            string mgmtLockObjectName1 = Recording.GenerateAssetName("mgmtLock-L-");
            string mgmtLockObjectName2 = Recording.GenerateAssetName("mgmtLock-L-");
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject1 = (await rg.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName1, mgmtLockObjectData)).Value;
            ManagementLockObject mgmtLockObject2 = (await rg.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName2, mgmtLockObjectData)).Value;
            int count = 0;
            await foreach (var mgmtLockObject in rg.GetManagementLocks().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2);
            await mgmtLockObject1.DeleteAsync();
            await mgmtLockObject2.DeleteAsync();
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            string mgmtLockObjectName = Recording.GenerateAssetName("testRg-4-");
            ManagementLockObjectData mgmtLockObjectData = new ManagementLockObjectData(new LockLevel("CanNotDelete"));
            ManagementLockObject mgmtLockObject = (await Client.DefaultSubscription.GetManagementLocks().CreateOrUpdateAsync(mgmtLockObjectName, mgmtLockObjectData)).Value;
            ManagementLockObject getMgmtLockObject = await Client.DefaultSubscription.GetManagementLocks().GetAsync(mgmtLockObjectName);
            AssertValidManagementLockObject(mgmtLockObject, getMgmtLockObject);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await Client.DefaultSubscription.GetManagementLocks().GetAsync(null));
            await mgmtLockObject.DeleteAsync();
        }
        private GenericResourceData ConstructGenericVirtualNetwork()
        {
            var virtualNetwork = new GenericResourceData(Location.WestUS2)
            {
                Properties = new JsonObject()
                {
                    {"addressSpace", new JsonObject()
                        {
                            {"addressPrefixes", new List<string>(){"10.0.0.0/16" } }
                        }
                    }
                }
            };
            return virtualNetwork;
        }
        private void AssertValidManagementLockObject(ManagementLockObject model, ManagementLockObject getResult)
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
