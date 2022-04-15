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
    public class ActionsTests : TestBase
    {
        #region Test setup

        

        #endregion

        #region Actions

        [Fact]
        public void Actions_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = AlertRulesUtils.GetDefaultAlertRuleProperties();
                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = AlertRulesUtils.GetDefaultAlertRuleActionProperties();
                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId, Action);

                var Actions = SecurityInsightsClient.Actions.ListByAlertRule(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId);
                ValidateActions(Actions);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = AlertRulesUtils.GetDefaultAlertRuleProperties();

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = AlertRulesUtils.GetDefaultAlertRuleActionProperties();

                var alertRuleAction = SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                ValidateAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = AlertRulesUtils.GetDefaultAlertRuleProperties();

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = AlertRulesUtils.GetDefaultAlertRuleActionProperties();

                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                var alertRuleAction = SecurityInsightsClient.Actions.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId);
                ValidateAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = AlertRulesUtils.GetDefaultAlertRuleProperties();

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = AlertRulesUtils.GetDefaultAlertRuleActionProperties();

                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                SecurityInsightsClient.Actions.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId, ActionId);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, RuleId);
            }
        }



        #endregion

        #region Validations

        private void ValidateActions(IPage<ActionResponse> actionResponses)
        {
            Assert.True(actionResponses.IsAny());

            actionResponses.ForEach(ValidateAction);
        }

        private void ValidateAction(ActionResponse actionResponse)
        {
            Assert.NotNull(actionResponse);
        }

        #endregion
    }
}