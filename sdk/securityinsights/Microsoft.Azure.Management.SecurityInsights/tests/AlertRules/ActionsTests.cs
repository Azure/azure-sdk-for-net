// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class ActionsTests : TestBase
    {
        #region Test setup

        private static string ActionLAResourceID = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-pfsense/providers/Microsoft.Logic/workflows/aaduserinfo";
        private static string ActionLATriggerUri = "https://prod-100.westus.logic.azure.com:443/workflows/7730de943c5746e3b1f202de83be93d0/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=m3QgR_GOY29-AFc-2MaP987Nca_9zlfdXB8DEhrfLxA";

        #endregion

        #region Actions

        [Fact]
        public void Actions_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };
                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };
                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                var Actions = SecurityInsightsClient.Actions.ListByAlertRule(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId);
                ValidateActions(Actions);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_CreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                var alertRule = SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                var alertRuleAction = SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                ValidateAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                var alertRuleAction = SecurityInsightsClient.Actions.Get(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId);
                ValidateAction(alertRuleAction);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId);
            }
        }

        [Fact]
        public void Actions_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var RuleId = Guid.NewGuid().ToString();
                var Rule = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

                SecurityInsightsClient.AlertRules.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, Rule);
                var ActionId = Guid.NewGuid().ToString();
                var Action = new ActionRequest
                {
                    LogicAppResourceId = ActionLAResourceID,
                    TriggerUri = ActionLATriggerUri
                };

                SecurityInsightsClient.Actions.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId, Action);
                SecurityInsightsClient.Actions.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId, ActionId);
                SecurityInsightsClient.AlertRules.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, RuleId);
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