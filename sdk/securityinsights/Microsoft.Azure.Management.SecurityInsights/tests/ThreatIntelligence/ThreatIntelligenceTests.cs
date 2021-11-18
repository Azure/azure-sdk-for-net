// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
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
                var ThreatIntelligences = SecurityInsightsClient.ThreatIntelligenceIndicators.List(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName);
                ValidateThreatIntelligences(ThreatIntelligences);
            }
        }

        [Fact]
        public void ThreatIntelligence_CreateIndicator()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                { 
                   DisplayName = "SDK Test",
                   PatternType = "ipv4-addr",
                   Pattern = "[ipv4-addr:value = '1.1.1.2']",
                   ThreatTypes = ThreatTypes,
                   ValidFrom = DateTime.Now.ToString()
                };

                var ThreatIntelligence = SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                ValidateThreatIntelligence(ThreatIntelligence);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);
            }
        }

        [Fact]
        public void ThreatIntelligence_GetIndicator()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                var ThreatIntelligence = SecurityInsightsClient.ThreatIntelligenceIndicator.Get(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);
                ValidateThreatIntelligence(ThreatIntelligence);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);

            }
        }

        [Fact]
        public void ThreatIntelligence_DeleteIndicator()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);
            }
        }

        [Fact]
        public void ThreatIntelligence_QueryIndicators()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };
                var ThreatIntelligenceFilter = new ThreatIntelligenceFilteringCriteria()
                { 
                    ThreatTypes = ThreatTypes
                };


                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                var ThreatIntelligences = SecurityInsightsClient.ThreatIntelligenceIndicator.QueryIndicators(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceFilter);
                ValidateThreatIntelligences(ThreatIntelligences);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);
            }
        }

        [Fact]
        public void ThreatIntelligence_GetMetrics()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                var ThreatIntelligenceMetrics = SecurityInsightsClient.ThreatIntelligenceIndicatorMetrics.List(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName);
                ValidateThreatIntelligenceMetrics(ThreatIntelligenceMetrics);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);
            }
        }

        [Fact]
        public void ThreatIntelligence_AppendTag()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);

                IList<string> ThreatIntelligenceTags = new List<string>
                {
                    "sdktest"
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.AppendTags(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceTags);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);

            }
        }

        [Fact]
        public void ThreatIntelligence_ReplaceTag()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var ThreatIntelligenceId = Guid.NewGuid().ToString();
                var ThreatTypes = new List<string>();
                ThreatTypes.Add("unknown");
                var ThreatIntelligenceProperties = new ThreatIntelligenceIndicatorModelForRequestBody()
                {
                    DisplayName = "SDK Test",
                    PatternType = "ipv4-addr",
                    Pattern = "[ipv4-addr:value = '1.1.1.2']",
                    ThreatTypes = ThreatTypes,
                    ValidFrom = DateTime.Now.ToString()
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.Create(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);

                IList<string> ThreatIntelligenceTags = new List<string>
                {
                    "sdktest"
                };

                SecurityInsightsClient.ThreatIntelligenceIndicator.ReplaceTags(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId, ThreatIntelligenceProperties);
                SecurityInsightsClient.ThreatIntelligenceIndicator.Delete(TestHelper.ResourceGroup, TestHelper.OperationalInsightsResourceProvider, TestHelper.WorkspaceName, ThreatIntelligenceId);

            }
        }

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
