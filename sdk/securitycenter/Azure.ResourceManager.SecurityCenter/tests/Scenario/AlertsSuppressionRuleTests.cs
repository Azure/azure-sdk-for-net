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
        private SecurityAlertsSuppressionRuleCollection _alertsSuppressionRuleCollection => DefaultSubscription.GetSecurityAlertsSuppressionRules();

        public AlertsSuppressionRuleTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _alertsSuppressionRuleCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SecurityAlertsSuppressionRuleResource> CreateAlertsSuppressionRule(string alertsSuppressionRuleName)
        {
            List<SuppressionAlertsScopeElement> allof = new List<SuppressionAlertsScopeElement>()
            {
                new SuppressionAlertsScopeElement()
                {
                    Field = "entities.ip.address",
                    AdditionalProperties  =
                    {
                        new KeyValuePair<string, BinaryData>("in",new BinaryData("[\"104.215.95.187\",\"52.164.206.56\"]"))
                    },
                },
            };
            var data = new SecurityAlertsSuppressionRuleData()
            {
                AlertType = "IpAnomaly",
                State = SecurityAlertsSuppressionRuleState.Enabled,
                Reason = "FalsePositive",
                Comment = "Test VM",
                SuppressionAlertsScope = new SuppressionAlertsScope(allof),
            };
            var alertSuppressionRule = await _alertsSuppressionRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, alertsSuppressionRuleName, data);
            return alertSuppressionRule.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdateUpdate()
        {
            string alertsSuppressionRuleName = Recording.GenerateAssetName("testrule");
            var alertSuppressionRule = await CreateAlertsSuppressionRule(alertsSuppressionRuleName);
            ValidateAlertsSuppressionRule(alertSuppressionRule, alertsSuppressionRuleName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string alertsSuppressionRuleName = Recording.GenerateAssetName("testrule");
            await CreateAlertsSuppressionRule(alertsSuppressionRuleName);
            bool flag = await _alertsSuppressionRuleCollection.ExistsAsync(alertsSuppressionRuleName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string alertsSuppressionRuleName = Recording.GenerateAssetName("testrule");
            await CreateAlertsSuppressionRule(alertsSuppressionRuleName);
            var alertSuppressionRule = await _alertsSuppressionRuleCollection.GetAsync(alertsSuppressionRuleName);
            ValidateAlertsSuppressionRule(alertSuppressionRule, alertsSuppressionRuleName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string alertsSuppressionRuleName = Recording.GenerateAssetName("testrule");
            await CreateAlertsSuppressionRule(alertsSuppressionRuleName);
            var list = await _alertsSuppressionRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAlertsSuppressionRule(list.First(item => item.Data.Name == alertsSuppressionRuleName), alertsSuppressionRuleName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string alertsSuppressionRuleName = Recording.GenerateAssetName("testrule");
            var alertSuppressionRule = await CreateAlertsSuppressionRule(alertsSuppressionRuleName);
            bool flag = await _alertsSuppressionRuleCollection.ExistsAsync(alertsSuppressionRuleName);
            Assert.IsTrue(flag);

            await alertSuppressionRule.DeleteAsync(WaitUntil.Completed);
            flag = await _alertsSuppressionRuleCollection.ExistsAsync(alertsSuppressionRuleName);
            Assert.IsFalse(flag);
        }

        private void ValidateAlertsSuppressionRule(SecurityAlertsSuppressionRuleResource alertSuppressionRule, string alertsSuppressionRuleName)
        {
            Assert.IsNotNull(alertSuppressionRule);
            Assert.IsNotNull(alertSuppressionRule.Data.Id);
            Assert.AreEqual(alertsSuppressionRuleName, alertSuppressionRule.Data.Name);
        }
    }
}
