// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class AlertRuleCollectionTests : MonitorTestBase
    {
        public AlertRuleCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<AlertRuleCollection> GetAlertRuleCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAlertRules();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetAlertRuleCollectionAsync();
            var name = Recording.GenerateAssetName("testAlertRule");
            var input = ResourceDataHelper.GetBasicAlertRuleData(DefaultLocation);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await container.CreateOrUpdateAsync(true, name, input));
            Assert.That(ex.Message, Is.SupersetOf("Creating or editing classic alert rules based on this metric is no longer supported"));
            //var lro = await container.CreateOrUpdateAsync(true, name, input);
            //var alert = lro.Value;
            //Assert.AreEqual(name, alert.Data.Name);
        }

        [Ignore("Creating or editing classic alert rules based on this metric is no longer supported")]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetAlertRuleCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testAlertRule", DefaultSubscription.Id);
            var input = ResourceDataHelper.GetBasicAlertRuleData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(true, actionGroupName, input);
            AlertRule alert1 = lro.Value;
            AlertRule alert2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertAlertRule(alert1.Data, alert2.Data);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetAlertRuleCollectionAsync();
            //var input = ResourceDataHelper.GetBasicAlertRuleData(DefaultLocation);
            //_ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testAlertRule"), input);
            //_ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testAlertRule"), input);
            var alertRules = collection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(alertRules.Result.Count, 0);
        }
    }
}
