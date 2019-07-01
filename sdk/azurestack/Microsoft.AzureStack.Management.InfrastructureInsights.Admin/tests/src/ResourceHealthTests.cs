// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
using Xunit;

namespace InfrastructureInsights.Tests
{
    public class ResourceHealthTests : InfrastructureInsightsTestBase
    {


        private void ValidateResourceHealth(ResourceHealth resource) {

            Assert.NotNull(resource);
            Assert.True(InfrastructureInsightsCommon.ValidateResource(resource));

            Assert.NotNull(resource.AlertSummary);
            Assert.NotNull(resource.HealthState);
            Assert.NotNull(resource.NamespaceProperty);
            Assert.NotNull(resource.RegistrationId);
            Assert.NotNull(resource.RoutePrefix);
            Assert.NotNull(resource.ResourceDisplayName);
            Assert.NotNull(resource.ResourceLocation);
            Assert.NotNull(resource.ResourceName);
            Assert.NotNull(resource.ResourceType);
            Assert.NotNull(resource.ResourceURI);
            Assert.NotNull(resource.RpRegistrationId);
            Assert.NotNull(resource.ResourceName);
            Assert.NotNull(resource.UsageMetrics);
        }

        private void AssertAreSameValidateResourceHealths(ResourceHealth expected, ResourceHealth found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {

                Assert.True(InfrastructureInsightsCommon.ResourceAreSame(expected, found));
                if (expected.AlertSummary == null)
                {
                    Assert.Null(found.AlertSummary);
                }
                else
                {
                    Assert.NotNull(found.AlertSummary);
                    Assert.Equal(expected.AlertSummary.CriticalAlertCount, found.AlertSummary.CriticalAlertCount);
                    Assert.Equal(expected.AlertSummary.WarningAlertCount, found.AlertSummary.WarningAlertCount);
                }

                Assert.Equal(found.HealthState, expected.HealthState);
                Assert.Equal(found.NamespaceProperty, expected.NamespaceProperty);
                Assert.Equal(found.RegistrationId, expected.RegistrationId);
                Assert.Equal(found.RoutePrefix, expected.RoutePrefix);

                Assert.Equal(found.ResourceDisplayName, expected.ResourceDisplayName);
                Assert.Equal(found.ResourceLocation, expected.ResourceLocation);
                Assert.Equal(found.ResourceName, expected.ResourceName);
                Assert.Equal(found.ResourceType, expected.ResourceType);
                Assert.Equal(found.ResourceURI, expected.ResourceURI);
                Assert.Equal(found.RpRegistrationId, expected.RpRegistrationId);

                if (found.UsageMetrics == null)
                {
                    Assert.Null(found.UsageMetrics);
                }
                else
                {
                    Assert.NotNull(found.UsageMetrics);
                    Assert.Equal(found.UsageMetrics.Count, expected.UsageMetrics.Count);
                }

            }
        }

        [Fact]
        public void TestListResourceHealths() {
            RunTest((client) => {
                var regionHealths = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(regionHealths, client.RegionHealths.ListNext, (regionHealth) => {
                    var rName = ExtractName(regionHealth.Name);

                    var serviceHealths = client.ServiceHealths.List(ResourceGroupName, rName);
                    Common.MapOverIPage(serviceHealths, client.ServiceHealths.ListNext, (serviceHealth) => {
                        var sName = ExtractName(serviceHealth.Name);

                        var resourceHealths = client.ResourceHealths.List(ResourceGroupName, rName, sName);
                        Common.MapOverIPage(resourceHealths, client.ResourceHealths.ListNext, ValidateResourceHealth);
                        Common.WriteIPagesToFile(resourceHealths, client.ResourceHealths.ListNext, "ListResourceHealths.txt", ResourceName);
                    });
                });
            });
        }
        [Fact]
        public void TestGetResourceHealth() {
            RunTest((client) => {
                var regionHealth = client.RegionHealths.List(ResourceGroupName).GetFirst();
                if (regionHealth != null)
                {
                    var regionName = ExtractName(regionHealth.Name);
                    var serviceHealth = client.ServiceHealths.List(ResourceGroupName, regionName).GetFirst();
                    if (serviceHealth != null)
                    {
                        var serviceName = ExtractName(serviceHealth.Name);
                        var resourceHealth = client.ResourceHealths.List(ResourceGroupName, regionName, serviceName).GetFirst();
                        if (resourceHealth != null)
                        {
                            var resourceName = ExtractName(resourceHealth.Name);
                            var retrieved = client.ResourceHealths.Get(ResourceGroupName, regionName, serviceName, resourceName);
                            AssertAreSameValidateResourceHealths(resourceHealth, retrieved);
                        }
                    }
                }


            });
        }
        [Fact]
        public void TestGetAllResourceHealths() {
            RunTest((client) => {
                var regionHealths = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(regionHealths, client.RegionHealths.ListNext, (regionHealth) => {
                    var regionName = ExtractName(regionHealth.Name);

                    var serviceHealths = client.ServiceHealths.List(ResourceGroupName, regionName);
                    Common.MapOverIPage(serviceHealths, client.ServiceHealths.ListNext, (serviceHealth) => {
                        var serviceName = ExtractName(serviceHealth.Name);

                        var resourceHealths = client.ResourceHealths.List(ResourceGroupName, regionName, serviceName);
                        Common.MapOverIPage(resourceHealths, client.ResourceHealths.ListNext, (resourceHealth) => {
                            var resourceName = ExtractName(resourceHealth.Name);

                            var retrieved = client.ResourceHealths.Get(ResourceGroupName, regionName, serviceName, resourceName);
                            AssertAreSameValidateResourceHealths(resourceHealth, retrieved);
                        });
                    });
                });
            });
        }
    }
}
