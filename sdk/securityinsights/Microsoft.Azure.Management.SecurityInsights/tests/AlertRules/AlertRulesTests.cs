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

        private static string SubscriptionId = "6b1ceacd-5731-4780-8f96-2078dd96fd96";
        private static string ResourceGroup = "CXP-Nicholas";
        private static string WorkspaceName = "SecureScoreData-t4ah4xsttcevs";
        private static string RuleId = Guid.NewGuid().ToString();

        private static string ActionRuleId = "6981fe5a-f84d-4569-b409-3f8e2e6eb334";
        private static string ActionId = Guid.NewGuid().ToString();
        private static string ActionLAResourceID = "/subscriptions/6b1ceacd-5731-4780-8f96-2078dd96fd96/resourceGroups/CXP-Nicholas/providers/Microsoft.Logic/workflows/Test";
        private static string ActionLATriggerUri = "https://prod-41.eastus.logic.azure.com:443/workflows/349d86e6a02242ea8f6e5d23b24db20e/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=EEBNwnVvkXlFTeaQ8KaKc1sTd8py0Yas_Dx2ipBg0_4";
        
        private static string ActionRuleId2 = "df84db5a-8c22-4c41-a384-bf03c350f63a";
        private static string ActionId2 = "78cf27ad-7678-442b-816c-d419d4e919e4";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                TestEnvironment.SubscriptionId = SubscriptionId;
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
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(ResourceGroup, WorkspaceName, RuleId, Rule);
                ValidateAlertRule(alertRule);
            }
        }

        [Fact]
        public void AlertRules_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);

                var alertRule = SecurityInsightsClient.AlertRules.Get(ResourceGroup, WorkspaceName, "BuiltInFusion");
                ValidateAlertRule(alertRule);

            }
        }

        [Fact]
        public void AlertRules_Delete()
        {
            Thread.Sleep(25000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void AlertRules_CreateorUpdateAction()
        {
            Thread.Sleep(10000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                var alertRuleAction = SecurityInsightsClient.AlertRules.CreateOrUpdateAction(ResourceGroup, WorkspaceName, RuleId, ActionId, Action);
                ValidateAlertRuleAction(alertRuleAction);
            }
        }

        [Fact]
        public void AlertRules_GetAction()
        {
            Thread.Sleep(15000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var alertRuleAction = SecurityInsightsClient.AlertRules.GetAction(ResourceGroup, WorkspaceName, ActionRuleId2, ActionId2);
                ValidateAlertRuleAction(alertRuleAction);
            }
        }

        [Fact]
        public void AlertRules_DeleteAction()
        {
            Thread.Sleep(20000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                SecurityInsightsClient.AlertRules.DeleteAction(ResourceGroup, WorkspaceName, ActionRuleId, ActionId);
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
