// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.TestsCase
{
    public class AlertRuleCollectionTests : MonitorTestBase
    {
        public AlertRuleCollectionTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<AlertRuleCollection> GetAlertRuleCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAlertRules();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetAlertRuleCollectionAsync();
            var name = Recording.GenerateAssetName("testAlertRule");
            var input = ResourceDataHelper.GetBasicAlertRuleData("global");
            var lro = await container.CreateOrUpdateAsync(name, input);
            var alert = lro.Value;
            Assert.AreEqual(name, alert.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetAlertRuleCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testAlertRule");
            var input = ResourceDataHelper.GetBasicAlertRuleData("global");
            var lro = await collection.CreateOrUpdateAsync(actionGroupName, input);
            AlertRule alert1 = lro.Value;
            AlertRule alert2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertAlertRule(alert1.Data, alert2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetAlertRuleCollectionAsync();
            var input = ResourceDataHelper.GetBasicAlertRuleData("global");
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testAlertRule"), input);
            _ = await collection.CreateOrUpdateAsync(Recording.GenerateAssetName("testAlertRule"), input);
            int count = 0;
            await foreach (var alertRule in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
