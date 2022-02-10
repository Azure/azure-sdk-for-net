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
                var AlertRuleProperties = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

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
                var AlertRuleProperties = new MicrosoftSecurityIncidentCreationAlertRule()
                {
                    ProductFilter = "Microsoft Cloud App Security",
                    Enabled = true,
                    DisplayName = "SDKTest"
                };

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
                    var AlertRuleProperties = new MicrosoftSecurityIncidentCreationAlertRule()
                    {
                        ProductFilter = "Microsoft Cloud App Security",
                        Enabled = true,
                        DisplayName = "SDKTest"
                    };

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
