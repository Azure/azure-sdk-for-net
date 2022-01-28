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

        private async Task<AlertRule> CreateAlertRuleAsync(string alertRuleName)
        {
            var collection = (await CreateResourceGroupAsync()).GetAlertRules();
            var input = ResourceDataHelper.GetBasicAlertRuleData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(true, alertRuleName, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var alertName = Recording.GenerateAssetName("testAlertRule-");
            var alert = await CreateAlertRuleAsync(alertName);
            await alert.DeleteAsync(true);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var alertName = Recording.GenerateAssetName("testAlertRule-");
            var alert = await CreateAlertRuleAsync(alertName);
            AlertRule actionGroup2 = await alert.GetAsync();

            ResourceDataHelper.AssertAlertRule(alert.Data, actionGroup2.Data);
        }
    }
}
