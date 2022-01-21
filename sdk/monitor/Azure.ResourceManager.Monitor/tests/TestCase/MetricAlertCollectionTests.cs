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
    public class MetricAlertCollectionTests : MonitorTestBase
    {
        public MetricAlertCollectionTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<MetricAlertCollection> GetMetricAlertCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetMetricAlerts();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetMetricAlertCollectionAsync();
            var name = Recording.GenerateAssetName("testMetricAlert");
            var input = ResourceDataHelper.GetBasicMetricAlertData("global",DefaultSubscription.Id);
            var lro = await container.CreateOrUpdateAsync(true, name, input);
            var alert = lro.Value;
            Assert.AreEqual(name, alert.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetMetricAlertCollectionAsync();
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var input = ResourceDataHelper.GetBasicMetricAlertData("global",DefaultSubscription.Id);
            var lro = await collection.CreateOrUpdateAsync(true, alertName, input);
            MetricAlert alert1 = lro.Value;
            MetricAlert alert2 = await collection.GetAsync(alertName);
            ResourceDataHelper.AssertMetricAlert(alert1.Data, alert2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetMetricAlertCollectionAsync();
            var input = ResourceDataHelper.GetBasicMetricAlertData("global", DefaultSubscription.Id);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testMetricAlert-"), input);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testMetricAlert-"), input);
            int count = 0;
            await foreach (var alert in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
