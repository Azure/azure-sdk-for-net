// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class AlertRuleTemplates : TestBase
    {
        #region Test setup

        #endregion

        #region AlertRuleTemplates

        [Fact]
        public void AlertRuleTemplates_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AlertRuleTemplates = SecurityInsightsClient.AlertRuleTemplates.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateAlertRuleTemplates(AlertRuleTemplates);
            }
        }

        [Fact]
        public void AlertRuleTemplates_Get()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var AlertRuleTemplates = SecurityInsightsClient.AlertRuleTemplates.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                var AlertRuleTemplateId = AlertRuleTemplates.First().Name;
                var AlertRuleTemplate = SecurityInsightsClient.AlertRuleTemplates.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, AlertRuleTemplateId);
                ValidateAlertRuleTemplate(AlertRuleTemplate);
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