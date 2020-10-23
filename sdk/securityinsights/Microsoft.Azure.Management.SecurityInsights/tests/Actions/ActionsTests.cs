// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;

namespace SecurityInsights.Tests
{
    public class ActionsTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "6b1ceacd-5731-4780-8f96-2078dd96fd96";
        private static string ResourceGroup = "CXP-Nicholas";
        private static string WorkspaceName = "SecureScoreData-t4ah4xsttcevs";
        private static string RuleId = "cd087883-80ae-4d22-befc-82da6330619b";

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

        #region Actions

        [Fact]
        public void Actions_ListByAlertRule()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var Actions = SecurityInsightsClient.Actions.ListByAlertRule(ResourceGroup, WorkspaceName, RuleId);
                ValidateActions(Actions);
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