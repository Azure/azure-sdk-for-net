// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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

                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleProperties = GetDefaultAutomationRuleProperties();
                var AutomationRule = SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);

                var AutomationRules = SecurityInsightsClient.AutomationRules.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateAutomationRules(AutomationRules);
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);
            }
        }

        [Fact]
        public void AutomationRules_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AutomationRuleId = Guid.NewGuid().ToString();

                var AutomationRuleProperties = GetDefaultAutomationRuleProperties();

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
                // Get client
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                // Set rule
                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleProperties = GetDefaultAutomationRuleProperties();
                SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);

                // Act
                var AutomationRule = SecurityInsightsClient.AutomationRules.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);

                //Validate
                ValidateAutomationRule(AutomationRule);
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);

            }
        }

        [Fact]
        public void AutomationRules_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                // Get client
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);

                // Set rule
                var AutomationRuleId = Guid.NewGuid().ToString();
                var AutomationRuleProperties = GetDefaultAutomationRuleProperties();
                SecurityInsightsClient.AutomationRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId, AutomationRuleProperties);

                // Act
                SecurityInsightsClient.AutomationRules.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AutomationRuleId);
            }
        }
        
        private static AutomationRule GetDefaultAutomationRuleProperties()
        {
            var AutomationRuleTriggeringLogic = new AutomationRuleTriggeringLogic()
            {
                IsEnabled = false
            };
            var ActionConfiguration = new PlaybookActionProperties()
            {
                LogicAppResourceId = TestHelper.ActionLAResourceID,
                TenantId = Guid.Parse(TestHelper.TestEnvironment.Tenant)
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

            return AutomationRuleProperties;
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
