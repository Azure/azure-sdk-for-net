// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class AvsPureStoragePolicyTest : AvsManagementTestBase
    {
        public AvsPureStoragePolicyTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Create()
        {
            AvsPureStoragePolicyData data = new AvsPureStoragePolicyData
            {
                Properties = new AvsPureStoragePolicyProperties("storagePolicyDefinition1", "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group1/providers/PureStorage.Block/storagePools/storagePool1"),
            };
            ArmOperation<AvsPureStoragePolicyResource> lro = await getAvsPureStoragePolicyCollection().CreateOrUpdateAsync(WaitUntil.Completed, STORAGE_POLICY_NAME, data);
            AvsPureStoragePolicyResource result = lro.Value;
            Assert.AreEqual(result.Data.Name, STORAGE_POLICY_NAME);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get_Resource()
        {
            AvsPureStoragePolicyResource result = await getAvsPureStoragePolicyResource().GetAsync();
            Assert.AreEqual(result.Data.Name, STORAGE_POLICY_NAME);
        }
        [TestCase, Order(3)]
        [RecordedTest]
        public async Task Get_Collection()
        {
            AvsPureStoragePolicyResource result = await getAvsPureStoragePolicyCollection().GetAsync(STORAGE_POLICY_NAME);
            Assert.AreEqual(result.Data.Name, STORAGE_POLICY_NAME);
        }
        [TestCase, Order(4)]
        [RecordedTest]
        public async Task List()
        {
            AvsPureStoragePolicyCollection collection = getAvsPureStoragePolicyCollection();
            var policies = new List<AvsPureStoragePolicyResource>();

            await foreach (AvsPureStoragePolicyResource item in collection.GetAllAsync())
            {
                AvsPureStoragePolicyData resourceData = item.Data;
                policies.Add(item);
            }
            Assert.IsTrue(policies.Any());
            Assert.IsTrue(policies.Any(c => c.Data.Name == STORAGE_POLICY_NAME));
        }
        [TestCase, Order(5)]
        [RecordedTest]
        public async Task GetIfExists()
        {
            bool exists = await getAvsPureStoragePolicyCollection().ExistsAsync(STORAGE_POLICY_NAME);
            Assert.True(exists);
        }
        [TestCase, Order(6)]
        [RecordedTest]
        public async Task Delete()
        {
           ArmOperation lro =  await getAvsPureStoragePolicyResource().DeleteAsync(WaitUntil.Started);
        }
    }
}
