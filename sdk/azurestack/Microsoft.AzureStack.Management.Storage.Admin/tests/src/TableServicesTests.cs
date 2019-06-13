using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class TableServicesTests : StorageTestBase
    {

        private void ValidateTableService(TableService tableService)
        {
            Assert.NotNull(tableService);
            Assert.NotNull(tableService.FrontEndCallbackThreadsCount);
            Assert.NotNull(tableService.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.NotNull(tableService.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.NotNull(tableService.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.NotNull(tableService.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.NotNull(tableService.FrontEndHttpListenPort);
            Assert.NotNull(tableService.FrontEndHttpsListenPort);
            Assert.NotNull(tableService.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.NotNull(tableService.FrontEndMemoryThrottleThresholdSettings);
            Assert.NotNull(tableService.FrontEndMemoryThrottlingEnabled);
            Assert.NotNull(tableService.FrontEndMinThreadPoolThreads);
            Assert.NotNull(tableService.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.NotNull(tableService.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.NotNull(tableService.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.NotNull(tableService.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.NotNull(tableService.FrontEndUseSlaTimeInAvailability);
            Assert.NotNull(tableService.Location);
            Assert.NotNull(tableService.Name);
            Assert.NotNull(tableService.Type);
            Assert.NotNull(tableService.Version);
        }

        [Fact]
        public void GetTableService()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var retrieved = client.TableServices.Get(ResourceGroupName, fName);
                    ValidateTableService(retrieved);
                }
            });
        }

        [Fact]
        public void ListAllTableServiceMetricDefinitions()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.TableServices.ListMetricDefinitions(ResourceGroupName, fName);
                    Common.WriteIEnumerableToFile(result, "ListAllTableServiceMetricDefinitions.txt");
                }
            });
        }

        [Fact]
        public void ListAllTableServiceMetrics()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.TableServices.ListMetrics(ResourceGroupName, fName);
                    Common.WriteIEnumerableToFile(result, "ListAllTableServiceMetrics.txt");
                }
            });
        }
    }
}
