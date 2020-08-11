// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace InfrastructureInsights.Tests
{
    using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
    using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
    using Xunit;

    public class RegionHealthTests : InfrastructureInsightsTestBase
    {

        private void AssertRegionHealthsAreSame(RegionHealth expected, RegionHealth found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(InfrastructureInsightsCommon.ResourceAreSame(expected, found));
                Assert.Equal(expected.AlertSummary.CriticalAlertCount, found.AlertSummary.CriticalAlertCount);
                Assert.Equal(expected.AlertSummary.WarningAlertCount, found.AlertSummary.WarningAlertCount);

                Assert.Equal(expected.UsageMetrics.Count, found.UsageMetrics.Count);
            }
        }

        private void ValidateMetrics(Metrics metrics) {
            Assert.NotNull(metrics);
            Assert.NotNull(metrics.Name);
            Assert.NotNull(metrics.Unit);
            Assert.NotNull(metrics.Value);
        }

        private void ValidateUsageMetrics(UsageMetrics usageMetrics) {

            Assert.NotNull(usageMetrics);
            Assert.NotNull(usageMetrics.MetricsValue);
            Assert.NotNull(usageMetrics.Name);
            foreach (var metrics in usageMetrics.MetricsValue)
            {
                ValidateMetrics(metrics);
            }
        }

        private void ValidateRegionHealth(RegionHealth regionHealth) {
            InfrastructureInsightsCommon.ValidateResource(regionHealth);

            // Alert summary
            Assert.NotNull(regionHealth.AlertSummary);
            Assert.NotNull(regionHealth.AlertSummary.CriticalAlertCount);
            Assert.NotNull(regionHealth.AlertSummary.WarningAlertCount);

            // Not null and have values
            Assert.True(regionHealth.AlertSummary.CriticalAlertCount >= 0);
            Assert.True(regionHealth.AlertSummary.WarningAlertCount >= 0);

            // Usage metrics
            Assert.NotNull(regionHealth.UsageMetrics);
            foreach (var usageMetrics in regionHealth.UsageMetrics)
            {
                ValidateUsageMetrics(usageMetrics);
            }

        }

        [Fact]
        public void TestListRegionHealths() {
            RunTest((client) => {
                var list = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(list, client.RegionHealths.ListNext, ValidateRegionHealth);
                Common.WriteIPagesToFile(list, client.RegionHealths.ListNext, "ListAllRegionHealths.txt");
            });
        }

        [Fact]
        public void TestGetRegionHealth() {
            RunTest((client) => {
                var regionHealth = client.RegionHealths.List(ResourceGroupName).GetFirst();
                if (regionHealth != null)
                {
                    var regionName = ExtractName(regionHealth.Name);
                    var retrieved = client.RegionHealths.Get(ResourceGroupName, regionName);
                    AssertRegionHealthsAreSame(regionHealth, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllRegionHealths() {
            RunTest((client) => {
                var list = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(list, client.RegionHealths.ListNext, (regionHealth) => {
                    var regionName = ExtractName(regionHealth.Name);
                    var retrieved = client.RegionHealths.Get(ResourceGroupName, regionName);
                    AssertRegionHealthsAreSame(regionHealth, retrieved);
                });
            });
        }
    }
}
