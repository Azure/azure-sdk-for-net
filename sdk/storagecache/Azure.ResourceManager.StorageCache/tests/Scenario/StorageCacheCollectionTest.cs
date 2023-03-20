// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class StorageCacheCollectionTest : StorageCacheManagementTestBase
    {
        public StorageCacheCollectionTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string name = Recording.GenerateAssetName("testsc");
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache(name);

            Assert.AreEqual(scr.Id.Name, name);
            Assert.AreEqual(1, scr.Data.SecurityAccessPolicies.Count);

            string policyName = "newone";
            scr.Data.SecurityAccessPolicies.Add(
                new NfsAccessPolicy(
                    name: policyName,
                    accessRules: new NfsAccessRule[]
                    {
                        new NfsAccessRule(scope: NfsAccessRuleScope.Host, access: NfsAccessRuleAccess.ReadWrite)
                        {
                            AllowSubmountAccess = true,
                            AllowSuid = true,
                            EnableRootSquash = false,
                            Filter = @"10.99.3.145"
                        },
                        new NfsAccessRule(scope: NfsAccessRuleScope.Network, access: NfsAccessRuleAccess.ReadWrite)
                        {
                            AllowSubmountAccess = true,
                            AllowSuid = true,
                            EnableRootSquash = false,
                            Filter = @"10.99.1.0/24"
                        },
                        new NfsAccessRule(scope: NfsAccessRuleScope.Default, access: NfsAccessRuleAccess.No)
                        {
                            AllowSubmountAccess = true,
                            AllowSuid = false,
                            AnonymousGID = @"65534",
                            AnonymousUID = @"65534",
                            EnableRootSquash = true
                        },
                    }));
            ArmOperation <StorageCacheResource> lro = await this.DefaultResourceGroup.GetStorageCaches().CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                cacheName: scr.Id.Name,
                data: scr.Data);
            StorageCacheResource updated = lro.Value;

            Assert.AreEqual(updated.Id.Name, name);
            Assert.AreEqual(updated.Data.SecurityAccessPolicies.Count, 2);
            Assert.AreEqual(updated.Data.SecurityAccessPolicies[1].Name, policyName);
            Assert.AreEqual(updated.Data.SecurityAccessPolicies[1].AccessRules.Count, 3);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();

            StorageCacheCollection storageCacheCollectionVar = this.DefaultResourceGroup.GetStorageCaches();
            string cacheNameVar = scr.Id.Name;
            StorageCacheResource result = await storageCacheCollectionVar.GetAsync(cacheName: cacheNameVar);

            Assert.AreEqual(result.Id, scr.Id);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();

            StorageCacheCollection storageCacheCollectionVar = this.DefaultResourceGroup.GetStorageCaches();

            Assert.IsTrue(await storageCacheCollectionVar.ExistsAsync(cacheName: scr.Id.Name));
            Assert.IsFalse(await storageCacheCollectionVar.ExistsAsync(cacheName: scr.Id.Name + "1"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            int CREATE_COUNT = 2;
            List<StorageCacheResource> created = new List<StorageCacheResource>();
            Parallel.For(0, CREATE_COUNT, async (i) =>
            {
                created.Add(await this.CreateOrUpdateStorageCache());
            });

            StorageCacheCollection StorageCacheCollectionVar = this.DefaultResourceGroup.GetStorageCaches();
            AsyncPageable<StorageCacheResource> storageCacheResourceList = StorageCacheCollectionVar.GetAllAsync();

            int count = 0;
            await foreach (StorageCacheResource scr in storageCacheResourceList)
            {
                StorageCacheResource found = created.FirstOrDefault(cur => cur.Id == scr.Id);
                Assert.IsTrue(found != null);
                created.Remove(found);
                count++;
            }
            Assert.AreEqual(count, CREATE_COUNT);
        }
    }
}
