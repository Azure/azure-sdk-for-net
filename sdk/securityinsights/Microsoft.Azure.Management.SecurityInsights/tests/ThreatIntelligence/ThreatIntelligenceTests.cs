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
    public class ThreatIntelligenceTests : TestBase
    {
        #region Test setup

        #endregion

        #region ThreatIntelligence

        [Fact]
        public void ThreatIntelligence_ListIndicators()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();
                var ThreatIntelligence = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                var ThreatIntelligences = SecurityInsightsClient.ThreatIntelligenceIndicators.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateThreatIntelligences(ThreatIntelligences);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligence.Name);
            }
        }

        [Fact]
        public void ThreatIntelligence_CreateIndicator()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();

                var ThreatIntelligence = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                ValidateThreatIntelligence(ThreatIntelligence);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligence.Name);
            }
        }

        [Fact]
        public void ThreatIntelligence_GetIndicator()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();

                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                var ThreatIntelligence = SecurityInsightsClient.ThreatIntelligenceIndicator.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);
                ValidateThreatIntelligence(ThreatIntelligence);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);

            }
        }

        [Fact]
        public void ThreatIntelligence_DeleteIndicator()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();

                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);
            }
        }

        [Fact]
        public void ThreatIntelligence_QueryIndicators()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();
                var ThreatIntelligenceFilter = new ThreatIntelligenceFilteringCriteria()
                {
                    ThreatTypes = new List<string>() { "unknown" }
                };

                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                var ThreatIntelligences = SecurityInsightsClient.ThreatIntelligenceIndicator.QueryIndicators(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceFilter);
                ValidateThreatIntelligences(ThreatIntelligences);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);
            }
        }

        [Fact]
        public void ThreatIntelligence_GetMetrics()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();
                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                var ThreatIntelligenceMetrics = SecurityInsightsClient.ThreatIntelligenceIndicatorMetrics.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateThreatIntelligenceMetrics(ThreatIntelligenceMetrics);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);
            }
        }

        [Fact]
        public void ThreatIntelligence_AppendTag()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();

                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);

                IList<string> ThreatIntelligenceTags = new List<string>
                {
                    "sdktest"
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.AppendTags(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name, ThreatIntelligenceTags);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);

            }
        }

        [Fact]
        public void ThreatIntelligence_ReplaceTag()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceProperties = GetThreatIntelligenceIndicatorModel();

                var Indicator = SecurityInsightsClient.ThreatIntelligenceIndicator.CreateIndicator(TestHelper.ResourceGroup, TestHelper.WorkspaceName, ThreatIntelligenceProperties);
                SecurityInsightsClient.ThreatIntelligenceIndicator.ReplaceTags(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name, ThreatIntelligenceProperties);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, Indicator.Name);

            }
        }

        private static ThreatIntelligenceIndicatorModel GetThreatIntelligenceIndicatorModel() => new ThreatIntelligenceIndicatorModel()
        {
            DisplayName = "SDK Test",
            PatternType = "ipv4-addr",
            Pattern = "[ipv4-addr:value = '1.1.1.2']",
            ThreatTypes = new List<string>() { "unknown" },
            ValidFrom = DateTime.Now.ToString(),
            Source = "Azure Sentinel"
        };

        #endregion

        #region Validations

        private void ValidateThreatIntelligences(IPage<ThreatIntelligenceInformation> ThreatIntelligences)
        {
            Assert.True(ThreatIntelligences.IsAny());

            ThreatIntelligences.ForEach(ValidateThreatIntelligence);
        }

        private void ValidateThreatIntelligence(ThreatIntelligenceInformation ThreatIntelligence)
        {
            Assert.NotNull(ThreatIntelligence);
        }

        private void ValidateThreatIntelligenceMetrics(ThreatIntelligenceMetricsList ThreatIntelligenceMetrics)
        {
            Assert.True(ThreatIntelligenceMetrics.Value.IsAny());

            ThreatIntelligenceMetrics.Value.ForEach(ValidateThreatIntelligenceMetric);
        }

        private void ValidateThreatIntelligenceMetric(ThreatIntelligenceMetrics ThreatIntelligenceMetric)
        {
            Assert.NotNull(ThreatIntelligenceMetric);
        }

        #endregion
    }
}
