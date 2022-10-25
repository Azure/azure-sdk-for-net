// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AlertsSuppressionRuleTests : SecurityCenterManagementTestBase
    {
        private AlertsSuppressionRuleCollection _alertsSuppressionRuleCollection => DefaultSubscription.GetAlertsSuppressionRules();

        public AlertsSuppressionRuleTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void TestSetUp()
        {
        }

        [RecordedTest]
        [Ignore("The SDK doesn't support create a AlertsSuppressionRule")]
        public async Task Update()
        {
            var data = new AlertsSuppressionRuleData()
            {
                AlertType = "VM_EICAR",
                State = AlertsSuppressionRuleState.Enabled,
                Reason = "test",
            };
            var alertSuppressionRule = await _alertsSuppressionRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, "JustForTest", data);

            // Delete
            await alertSuppressionRule.Value.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _alertsSuppressionRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
