// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Threading;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;

namespace SecurityInsights.Tests
{
    public class AlertRulesTests : TestBase
    {
        #region Test setup

        private static string ResourceGroup = "ndicola-pfsense";
        private static string WorkspaceName = "ndicola-pfsense";
        private static string ActionLAResourceID = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-pfsense/providers/Microsoft.Logic/workflows/aaduserinfo";
        private static string ActionLATriggerUri = "https://prod-100.westus.logic.azure.com:443/workflows/7730de943c5746e3b1f202de83be93d0/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=m3QgR_GOY29-AFc-2MaP987Nca_9zlfdXB8DEhrfLxA";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsightsClient>(handlers: handler);

            return SecurityInsightsClient;
        }

        #endregion

        #region AlertRules

        [Fact]
        public void AlertRules_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var alertRules = SecurityInsightsClient.AlertRules.List(ResourceGroup, WorkspaceName);
                ValidateAlertRules(alertRules);
            }
        }

        [Fact]
        public void AlertRules_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                ValidateAlertRule(alertRule);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void AlertRules_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);

                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);

                var alertRule = SecurityInsightsClient.AlertRules.Get(ResourceGroup, WorkspaceName, RuleId);
                ValidateAlertRule(alertRule);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);

            }
        }

        [Fact]
        public void AlertRules_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void AlertRules_CreateorUpdateAction()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                var alertRuleAction = SecurityInsightsClient.Actions.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, ActionId, Action);
                ValidateAlertRuleAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void AlertRules_GetAction()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                SecurityInsightsClient.Actions.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, ActionId, Action);
                var alertRuleAction = SecurityInsightsClient.Actions.Get(ResourceGroup, WorkspaceName, RuleId, ActionId);
                ValidateAlertRuleAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void AlertRules_DeleteAction()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                SecurityInsightsClient.Actions.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, ActionId, Action);
                SecurityInsightsClient.Actions.Delete(ResourceGroup, WorkspaceName, RuleId, ActionId);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        #endregion

        #region Validations

        private void ValidateAlertRules(IPage<AlertRule> alertRulepage)
        {
            Assert.True(alertRulepage.IsAny());

            alertRulepage.ForEach(ValidateAlertRule);
        }

        private void ValidateAlertRule(AlertRule alertRule)
        {
            Assert.NotNull(alertRule);
        }

        private void ValidateAlertRuleAction(ActionResponse action)
        {
            Assert.NotNull(action);
        }

        #endregion
    }
}
