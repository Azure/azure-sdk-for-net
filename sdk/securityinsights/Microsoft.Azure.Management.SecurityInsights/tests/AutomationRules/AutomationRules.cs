// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class AutomationRulesTests : TestBase
    {
        #region Test setup

        #endregion

        #region AutomationRules

        [Fact]
        public void AutomationRules_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AutomationRules = SecurityInsightsClient.AutomationRules.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateAutomationRules(AutomationRules);
            }
        }

        [Fact]
        public void AutomationRules_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleTriggeringLogic = new AutomationRuleTriggeringLogic()
                { 
                    IsEnabled = false
                };
                var ActionConfiguration = new AutomationRuleRunPlaybookActionActionConfiguration()
                { 
                    LogicAppResourceId = TestHelper.ActionLAResourceID,
                    TenantId = TestHelper.TestEnvironment.Tenant
                };
                var AutomationRuleAction = new AutomationRuleRunPlaybookAction()
                { 
                    Order = 1,
                    ActionConfiguration = ActionConfiguration
                };
                var AutomationRuleActions = new List<AutomationRuleAction>();
                AutomationRuleActions.Add(AutomationRuleAction);
                var AutomationRuleProperties = new AutomationRule()
                {
                    DisplayName = "SDK Test",
                    Order = 1,
                    TriggeringLogic = AutomationRuleTriggeringLogic,
                    Actions = AutomationRuleActions
                    
                };

                var AutomationRule = SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);
                ValidateAutomationRule(AutomationRule);
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);
            }
        }

        [Fact]
        public void AutomationRules_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleTriggeringLogic = new AutomationRuleTriggeringLogic()
                {
                    IsEnabled = false
                };
                var ActionConfiguration = new AutomationRuleRunPlaybookActionActionConfiguration()
                {
                    LogicAppResourceId = TestHelper.ActionLAResourceID,
                    TenantId = TestHelper.TestEnvironment.Tenant
                };
                var AutomationRuleAction = new AutomationRuleRunPlaybookAction()
                {
                    Order = 1,
                    ActionConfiguration = ActionConfiguration
                };
                var AutomationRuleActions = new List<AutomationRuleAction>();
                AutomationRuleActions.Add(AutomationRuleAction);
                var AutomationRuleProperties = new AutomationRule()
                {
                    DisplayName = "SDK Test",
                    Order = 1,
                    TriggeringLogic = AutomationRuleTriggeringLogic,
                    Actions = AutomationRuleActions

                };

                SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);
                var AutomationRule = SecurityInsightsClient.AutomationRules.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);
                ValidateAutomationRule(AutomationRule);
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);

            }
        }

        [Fact]
        public void AutomationRules_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleTriggeringLogic = new AutomationRuleTriggeringLogic()
                {
                    IsEnabled = false
                };
                var ActionConfiguration = new AutomationRuleRunPlaybookActionActionConfiguration()
                {
                    LogicAppResourceId = TestHelper.ActionLAResourceID,
                    TenantId = TestHelper.TestEnvironment.Tenant
                };
                var AutomationRuleAction = new AutomationRuleRunPlaybookAction()
                {
                    Order = 1,
                    ActionConfiguration = ActionConfiguration
                };
                var AutomationRuleActions = new List<AutomationRuleAction>();
                AutomationRuleActions.Add(AutomationRuleAction);
                var AutomationRuleProperties = new AutomationRule()
                {
                    DisplayName = "SDK Test",
                    Order = 1,
                    TriggeringLogic = AutomationRuleTriggeringLogic,
                    Actions = AutomationRuleActions

                };

                SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);
            }
        }

        #endregion

        #region Validations

        private void ValidateAutomationRules(IPage<AutomationRule> AutomationRulepage)
        {
            Assert.True(AutomationRulepage.IsAny());

            AutomationRulepage.ForEach(ValidateAutomationRule);
        }

        private void ValidateAutomationRule(AutomationRule AutomationRule)
        {
            Assert.NotNull(AutomationRule);
        }

        #endregion
    }
}
