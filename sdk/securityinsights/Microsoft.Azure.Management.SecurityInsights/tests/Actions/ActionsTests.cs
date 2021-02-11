// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;
using System;

namespace SecurityInsights.Tests
{
    public class ActionsTests : TestBase
    {
        #region Test setup

        private static string ResourceGroup = "ndicola-azsposh";
        private static string WorkspaceName = "azsposh";
        private static string ActionLAResourceID = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser";
        private static string ActionLATriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E";


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

        #region Actions

        [Fact]
        public void Actions_ListByAlertRule()
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
                var Actions = SecurityInsightsClient.Actions.ListByAlertRule(ResourceGroup, WorkspaceName, RuleId);
                ValidateActions(Actions);
                SecurityInsightsClient.AlertRules.Delete(ResourceGroup, WorkspaceName, RuleId);
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