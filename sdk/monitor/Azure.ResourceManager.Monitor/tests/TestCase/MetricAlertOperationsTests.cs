// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.TestCase
{
    public class MetricAlertOperationsTests : MonitorTestBase
    {
        public MetricAlertOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<MetricAlert> CreateMetricAlertAsync(string alertName)
        {
            var collection = (await CreateResourceGroupAsync()).GetMetricAlerts();
            var input = ResourceDataHelper.GetBasicMetricAlertData("global", DefaultSubscription.Id);
            var lro = await collection.CreateOrUpdateAsync(true, alertName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            await alert.DeleteAsync(true);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            MetricAlert actionGroup2 = await alert.GetAsync();

            ResourceDataHelper.AssertMetricAlert(alert.Data, actionGroup2.Data);
        }
    }
}
