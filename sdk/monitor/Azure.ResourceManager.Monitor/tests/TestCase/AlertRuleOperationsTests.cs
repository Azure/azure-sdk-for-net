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
    public class AlertRuleOperationsTests : MonitorTestBase
    {
        public AlertRuleOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        private async Task<AlertRuleResource> CreateAlertRuleAsync(string alertRuleName)
        {
            var collection = (await CreateResourceGroupAsync()).GetAlertRules();
            var input = ResourceDataHelper.GetBasicAlertRuleData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRuleName, input);
            return lro.Value;
        }

        [Ignore("Creating or editing classic alert rules based on this metric is no longer supported")]
        [RecordedTest]
        public async Task Delete()
        {
            var alertName = Recording.GenerateAssetName("testAlertRule-");
            var alert = await CreateAlertRuleAsync(alertName);
            await alert.DeleteAsync(WaitUntil.Completed);
        }

        [Ignore("Creating or editing classic alert rules based on this metric is no longer supported")]
        [RecordedTest]
        public async Task Get()
        {
            var alertName = Recording.GenerateAssetName("testAlertRule-");
            var alert = await CreateAlertRuleAsync(alertName);
            AlertRuleResource actionGroup2 = await alert.GetAsync();

            ResourceDataHelper.AssertAlertRule(alert.Data, actionGroup2.Data);
        }
    }
}
