// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class MetricAlertOperationsTests : MonitorTestBase
    {
        public MetricAlertOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<MetricAlertResource> CreateMetricAlertAsync(string alertName)
        {
            var resourceGroup = await CreateResourceGroupAsync().ConfigureAwait(false);
            var metricAlertCollection = resourceGroup.GetMetricAlerts();
            var actionGroupCollection = resourceGroup.GetActionGroups();

            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroupData = ResourceDataHelper.GetBasicActionGroupData("Global");
            var actionGroup = (await actionGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, actionGroupData).ConfigureAwait(false)).Value;
            var metricAlertData = ResourceDataHelper.GetBasicMetricAlertData("global", actionGroup);
            var metricAlert = await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, alertName, metricAlertData);
            return metricAlert.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            await alert.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            MetricAlertResource actionGroup2 = await alert.GetAsync();

            ResourceDataHelper.AssertMetricAlert(alert.Data, actionGroup2.Data);
        }
    }
}
