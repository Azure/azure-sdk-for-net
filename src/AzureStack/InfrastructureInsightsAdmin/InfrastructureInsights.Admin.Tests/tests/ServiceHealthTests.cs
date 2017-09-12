

using Xunit;

using Microsoft.AzureStack.TestFramework;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin;
using Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models;

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
                var list = client.ServiceHealths.List(Location);
                Common.MapOverIEnumerable(list, ValidateServiceHealth);
                Common.WriteIEnumerableToFile(list, "ListAllServiceHealths.txt", ResourceName);
            });
        }

        [Fact]
        public void TestGetServiceHealth() {
            RunTest((client) => {
                var service = client.ServiceHealths.List(Location).GetFirst();
                if (service != null)
                {
                    var retrieved = client.ServiceHealths.Get(Location, service.Name);
                    AssertServiceHealthsEqual(service, retrieved);
                }
            });
        }

        [Fact]
        public void TestGetAllServiceHealths() {
            RunTest((client) => {
                var list = client.ServiceHealths.List(Location);
                Common.MapOverIEnumerable(list, (service) => {
                    var retrieved = client.ServiceHealths.Get(Location, service.Name);
                    AssertServiceHealthsEqual(service, retrieved);
                });
            });
        }

    }
}
