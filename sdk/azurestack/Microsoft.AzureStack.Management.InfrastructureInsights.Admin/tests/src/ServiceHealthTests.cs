// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;
using Xunit;

namespace InfrastructureInsights.Tests
{

    public class ServiceHealthTests : InfrastructureInsightsTestBase
    {

        private void AssertServiceHealthsEqual(ServiceHealth expected, ServiceHealth found) {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(InfrastructureInsightsCommon.ResourceAreSame(expected, found));
            }
        }

        private void ValidateServiceHealth(ServiceHealth serviceHealth) {
            Assert.NotNull(serviceHealth);

            Assert.NotNull(serviceHealth.AlertSummary);
            Assert.True(serviceHealth.AlertSummary.WarningAlertCount >= 0);
            Assert.True(serviceHealth.AlertSummary.CriticalAlertCount >= 0);

            Assert.NotNull(serviceHealth.HealthState);
            Assert.NotNull(serviceHealth.InfraURI);
            Assert.NotNull(serviceHealth.NamespaceProperty);
            Assert.NotNull(serviceHealth.RegistrationId);
            Assert.NotNull(serviceHealth.RoutePrefix);
            Assert.NotNull(serviceHealth.ServiceLocation);
        }

        [Fact]
        public void TestListServiceHealths() {
            RunTest((client) => {
                var regionHealths = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(regionHealths, client.RegionHealths.ListNext, (regionHealth) => {
                    var regionName = ExtractName(regionHealth.Name);
                    var list = client.ServiceHealths.List(ResourceGroupName, regionName);
                    list.ForEach(ValidateServiceHealth);
                    Common.WriteIEnumerableToFile(list, "ListAllServiceHealths.txt", ResourceName);
                });
            });
        }

        [Fact]
        public void TestGetServiceHealth() {
            RunTest((client) => {
                var region = client.RegionHealths.List(ResourceGroupName).GetFirst();
                var regionName = ExtractName(region.Name);
                var service = client.ServiceHealths.List(ResourceGroupName, regionName).GetFirst();
                if (service != null)
                {
                    var serviceName = ExtractName(service.Name);
                    var retrieved = client.ServiceHealths.Get(ResourceGroupName, regionName, serviceName);
                    AssertServiceHealthsEqual(service, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllServiceHealths() {
            RunTest((client) => {
                var regionHealths = client.RegionHealths.List(ResourceGroupName);
                Common.MapOverIPage(regionHealths, client.RegionHealths.ListNext, (regionHealth) => {
                    var regionName = ExtractName(regionHealth.Name);

                    var serviceHealths = client.ServiceHealths.List(ResourceGroupName, regionName);
                    Common.MapOverIPage(serviceHealths, client.ServiceHealths.ListNext, (service) => {
                        var serviceName = ExtractName(service.Name);

                        var retrieved = client.ServiceHealths.Get(ResourceGroupName, regionName, serviceName);
                        AssertServiceHealthsEqual(service, retrieved);
                    });
                });
            });
        }

    }
}
