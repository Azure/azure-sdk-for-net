using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class FarmsTests : StorageTestBase
    {
        private void AssertAreEqual(Farm expected, Farm found)
        {
            if (expected == null)
            {
                Assert.NotNull(found);
            }
            else
            {
                ValidateFarm(found);
                Assert.Equal(expected.BandwidthThrottleIsEnabled, found.BandwidthThrottleIsEnabled);
                Assert.Equal(expected.CorsAllowedOriginsList, found.CorsAllowedOriginsList);
                Assert.Equal(expected.DataCenterUriHostSuffixes, found.DataCenterUriHostSuffixes);
                Assert.Equal(expected.DefaultEgressThresholdInGbps, found.DefaultEgressThresholdInGbps);
                Assert.Equal(expected.DefaultIngressThresholdInGbps, found.DefaultIngressThresholdInGbps);
                Assert.Equal(expected.DefaultIntranetEgressThresholdInGbps, found.DefaultIntranetEgressThresholdInGbps);
                Assert.Equal(expected.DefaultIntranetIngressThresholdInGbps, found.DefaultIntranetIngressThresholdInGbps);
                Assert.Equal(expected.DefaultRequestThresholdInTps, found.DefaultRequestThresholdInTps);
                Assert.Equal(expected.DefaultThrottleProbabilityDecayIntervalInSeconds, found.DefaultThrottleProbabilityDecayIntervalInSeconds);
                Assert.Equal(expected.DefaultTotalEgressThresholdInGbps, found.DefaultTotalEgressThresholdInGbps);
                Assert.Equal(expected.DefaultTotalIngressThresholdInGbps, found.DefaultTotalIngressThresholdInGbps);
                Assert.Equal(expected.FeedbackRefreshIntervalInSeconds, found.FeedbackRefreshIntervalInSeconds);
                Assert.Equal(expected.GracePeriodForFullThrottlingInRefreshIntervals, found.GracePeriodForFullThrottlingInRefreshIntervals);
                Assert.Equal(expected.GracePeriodMaxThrottleProbability, found.GracePeriodMaxThrottleProbability);
                Assert.Equal(expected.HostStyleHttpPort, found.HostStyleHttpPort);
                Assert.Equal(expected.HostStyleHttpsPort, found.HostStyleHttpsPort);
                Assert.Equal(expected.Id, found.Id);
                Assert.Equal(expected.Location, found.Location);
                Assert.Equal(expected.MinimumEgressThresholdInGbps, found.MinimumEgressThresholdInGbps);
                Assert.Equal(expected.MinimumIngressThresholdInGbps, found.MinimumIngressThresholdInGbps);
                Assert.Equal(expected.MinimumIntranetEgressThresholdInGbps, found.MinimumIntranetEgressThresholdInGbps);
                Assert.Equal(expected.MinimumIntranetIngressThresholdInGbps, found.MinimumIntranetIngressThresholdInGbps);
                Assert.Equal(expected.MinimumRequestThresholdInTps, found.MinimumRequestThresholdInTps);
                Assert.Equal(expected.MinimumTotalEgressThresholdInGbps, found.MinimumTotalEgressThresholdInGbps);
                Assert.Equal(expected.MinimumTotalIngressThresholdInGbps, found.MinimumTotalIngressThresholdInGbps);
                Assert.Equal(expected.Name, found.Name);
                Assert.Equal(expected.NumberOfAccountsToSync, found.NumberOfAccountsToSync);
                Assert.Equal(expected.OverallEgressThresholdInGbps, found.OverallEgressThresholdInGbps);
                Assert.Equal(expected.OverallIngressThresholdInGbps, found.OverallIngressThresholdInGbps);
                Assert.Equal(expected.OverallIntranetEgressThresholdInGbps, found.OverallIntranetEgressThresholdInGbps);
                Assert.Equal(expected.OverallIntranetIngressThresholdInGbps, found.OverallIntranetIngressThresholdInGbps);
                Assert.Equal(expected.OverallRequestThresholdInTps, found.OverallRequestThresholdInTps);
                Assert.Equal(expected.OverallTotalEgressThresholdInGbps, found.OverallTotalEgressThresholdInGbps);
                Assert.Equal(expected.OverallTotalIngressThresholdInGbps, found.OverallTotalIngressThresholdInGbps);
                Assert.Equal(expected.OverallIntranetEgressThresholdInGbps, found.OverallIntranetEgressThresholdInGbps);
                Assert.Equal(expected.RetentionPeriodForDeletedStorageAccountsInDays, found.RetentionPeriodForDeletedStorageAccountsInDays);
                Assert.Equal(expected.SettingsPollingIntervalInSecond, found.SettingsPollingIntervalInSecond);
                Assert.Equal(expected.SettingsStore, found.SettingsStore);
                if (expected.Tags == null)
                {
                    Assert.Null(found.Tags);
                }
                else
                {
                    Assert.NotNull(found.Tags);
                    foreach (var expectedTag in expected.Tags)
                    {
                        Assert.True(found.Tags.ContainsKey(expectedTag.Key));
                    }
                }
                Assert.Equal(expected.ToleranceFactorForEgress, found.ToleranceFactorForEgress);
                Assert.Equal(expected.ToleranceFactorForIngress, found.ToleranceFactorForIngress);
                Assert.Equal(expected.ToleranceFactorForIntranetEgress, found.ToleranceFactorForIntranetEgress);
                Assert.Equal(expected.ToleranceFactorForIntranetIngress, found.ToleranceFactorForIntranetIngress);
                Assert.Equal(expected.ToleranceFactorForTotalEgress, found.ToleranceFactorForTotalEgress);
                Assert.Equal(expected.ToleranceFactorForTotalIngress, found.ToleranceFactorForTotalIngress);
                Assert.Equal(expected.ToleranceFactorForTps, found.ToleranceFactorForTps);
                Assert.Equal(expected.Type, found.Type);
                Assert.Equal(expected.UsageCollectionIntervalInSeconds, found.UsageCollectionIntervalInSeconds);
            }
        }

        private void ValidateFarm(Farm farm)
        {
            Assert.NotNull(farm);
            Assert.NotNull(farm.BandwidthThrottleIsEnabled);
            Assert.NotNull(farm.CorsAllowedOriginsList);
            Assert.NotNull(farm.DataCenterUriHostSuffixes);
            Assert.NotNull(farm.DefaultEgressThresholdInGbps);
            Assert.NotNull(farm.DefaultIngressThresholdInGbps);
            Assert.NotNull(farm.DefaultIntranetEgressThresholdInGbps);
            Assert.NotNull(farm.DefaultIntranetIngressThresholdInGbps);
            Assert.NotNull(farm.DefaultRequestThresholdInTps);
            Assert.NotNull(farm.DefaultThrottleProbabilityDecayIntervalInSeconds);
            Assert.NotNull(farm.DefaultTotalEgressThresholdInGbps);
            Assert.NotNull(farm.DefaultTotalIngressThresholdInGbps);
            Assert.NotNull(farm.FeedbackRefreshIntervalInSeconds);
            Assert.NotNull(farm.GracePeriodForFullThrottlingInRefreshIntervals);
            Assert.NotNull(farm.GracePeriodMaxThrottleProbability);
            Assert.NotNull(farm.HostStyleHttpPort);
            Assert.NotNull(farm.HostStyleHttpsPort);
            Assert.NotNull(farm.Id);
            Assert.NotNull(farm.Location);
            Assert.NotNull(farm.MinimumEgressThresholdInGbps);
            Assert.NotNull(farm.MinimumIngressThresholdInGbps);
            Assert.NotNull(farm.MinimumIntranetEgressThresholdInGbps);
            Assert.NotNull(farm.MinimumIntranetIngressThresholdInGbps);
            Assert.NotNull(farm.MinimumRequestThresholdInTps);
            Assert.NotNull(farm.MinimumTotalEgressThresholdInGbps);
            Assert.NotNull(farm.MinimumTotalIngressThresholdInGbps);
            Assert.NotNull(farm.Name);
            Assert.NotNull(farm.NumberOfAccountsToSync);
            Assert.NotNull(farm.OverallEgressThresholdInGbps);
            Assert.NotNull(farm.OverallIngressThresholdInGbps);
            Assert.NotNull(farm.OverallIntranetEgressThresholdInGbps);
            Assert.NotNull(farm.OverallIntranetIngressThresholdInGbps);
            Assert.NotNull(farm.OverallRequestThresholdInTps);
            Assert.NotNull(farm.OverallTotalEgressThresholdInGbps);
            Assert.NotNull(farm.OverallTotalIngressThresholdInGbps);
            Assert.NotNull(farm.OverallIntranetEgressThresholdInGbps);
            Assert.NotNull(farm.RetentionPeriodForDeletedStorageAccountsInDays);
            Assert.NotNull(farm.SettingsPollingIntervalInSecond);
            Assert.NotNull(farm.SettingsStore);
            Assert.NotNull(farm.ToleranceFactorForEgress);
            Assert.NotNull(farm.ToleranceFactorForIngress);
            Assert.NotNull(farm.ToleranceFactorForIntranetEgress);
            Assert.NotNull(farm.ToleranceFactorForIntranetIngress);
            Assert.NotNull(farm.ToleranceFactorForTotalEgress);
            Assert.NotNull(farm.ToleranceFactorForTotalIngress);
            Assert.NotNull(farm.ToleranceFactorForTps);
            Assert.NotNull(farm.Type);
            Assert.NotNull(farm.UsageCollectionIntervalInSeconds);
        }

        [Fact]
        public void ListFarms()
        {
            RunTest((client) => {
                var result = client.Farms.List(ResourceGroupName);
                Common.WriteIEnumerableToFile(result, "ListAllStorageFarms.txt");
                result.ForEach(ValidateFarm);
            });
        }

        [Fact]
        public void GetFarm()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach(var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.Farms.Get(ResourceGroupName, fName);
                    AssertAreEqual(farm, result);
                    break;
                }
            });
        }

        [Fact]
        public void GetAllFarms()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.Farms.Get(ResourceGroupName, fName);
                    AssertAreEqual(farm, result);
                }
            });
        }

        [Fact(Skip="This is supposed to be removed from RP.")]
        public void CreateFarm()
        {
            RunTest((client) => {
                // This will return an error:
                // {"error":{"code":"LocationRequired","message":"The location property is required for this definition."}}
                client.Farms.Create(ResourceGroupName, "jeffsFarm");
            });
        }

        [Fact]
        public void ListAllFarmMetricDefinitions()
        {
            RunTest((client) => {
            var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.Farms.ListMetricDefinitions(ResourceGroupName, fName);
                    Common.WriteIEnumerableToFile(result, "ListAllFarmMetricDefinitions.txt");
                }
            });
        }

        [Fact]
        public void ListAllFarmMetrics()
        {
            RunTest((client) => {
            var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.Farms.ListMetrics(ResourceGroupName, fName);
                    Common.WriteIEnumerableToFile(result, "ListAllFarmMetricDefinitions.txt");
                }
            });
        }

        [Fact(Skip="Queue is empty error, need to re-record.")]
        public void ForAllFarmsStartGarbageCollection()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    client.Farms.StartGarbageCollection(ResourceGroupName, fName);
                }
            });
        }
    }
}
