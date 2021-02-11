﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class AlertRuleTemplates : TestBase
    {
        #region Test setup

        private static string ResourceGroup = "ndicola-azsposh";
        private static string WorkspaceName = "azsposh";

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

        #region AlertRuleTemplates

        [Fact]
        public void AlertRuleTemplates_ListByAlertRule()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var AlertRuleTemplates = SecurityInsightsClient.AlertRuleTemplates.List(ResourceGroup, WorkspaceName);
                ValidateAlertRuleTemplates(AlertRuleTemplates);
            }
        }

        #endregion

        #region Validations

        private void ValidateAlertRuleTemplates(IPage<AlertRuleTemplate> AlertRuleTemplate)
        {
            Assert.True(AlertRuleTemplate.IsAny());

            AlertRuleTemplate.ForEach(ValidateAlertRuleTemplate);
        }

        private void ValidateAlertRuleTemplate(AlertRuleTemplate AlertRuleTemplate)
        {
            Assert.NotNull(AlertRuleTemplate);
        }

        #endregion
    }
}