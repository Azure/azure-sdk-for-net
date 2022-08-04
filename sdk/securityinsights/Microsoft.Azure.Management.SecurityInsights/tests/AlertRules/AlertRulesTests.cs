// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.AlertRules;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class AlertRulesTests : TestBase
    {
        #region Test setup

        #endregion

        #region AlertRules

        [Fact]
        public void AlertRules_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                var AlertRuleId = Guid.NewGuid().ToString();
                var AlertRuleProperties = AlertRulesUtils.GetDefaultAlertRuleProperties();
                var AlertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId, AlertRuleProperties);

                var AlertRules = SecurityInsightsClient.AlertRules.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);

                ValidateAlertRules(AlertRules);
            }
        }

        [Fact]
        public void AlertRules_CreateorUpdate()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AlertRuleId = Guid.NewGuid().ToString();
                var AlertRuleProperties = AlertRulesUtils.GetDefaultAlertRuleProperties();

                var AlertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId, AlertRuleProperties);
                ValidateAlertRule(AlertRule);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId);
            }
        }

        [Fact]
        public void AlertRules_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AlertRuleId = Guid.NewGuid().ToString();
                var AlertRuleProperties = AlertRulesUtils.GetDefaultAlertRuleProperties();

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId, AlertRuleProperties);
                var AlertRule = SecurityInsightsClient.AlertRules.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId);
                ValidateAlertRule(AlertRule);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId);
            }
        }

        [Fact]
        public void AlertRules_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AlertRuleId = Guid.NewGuid().ToString();
                var AlertRuleProperties = AlertRulesUtils.GetDefaultAlertRuleProperties();

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId, AlertRuleProperties);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleId);
            }
        }

        #endregion

        #region Validations

        private void ValidateAlertRules(IPage<AlertRule> AlertRulePage)
        {
            Assert.True(AlertRulePage.IsAny());

            AlertRulePage.ForEach(ValidateAlertRule);
        }

        private void ValidateAlertRule(AlertRule AlertRule)
        {
            Assert.NotNull(AlertRule);
        }
        #endregion
    }
}
