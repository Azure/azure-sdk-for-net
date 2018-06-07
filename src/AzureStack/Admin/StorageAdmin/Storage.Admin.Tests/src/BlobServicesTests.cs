using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class BlobServicesTests : StorageTestBase
    {

        private void ValidateBlobService(BlobService blobService)
        {
            Assert.NotNull(blobService);
            Assert.NotNull(blobService.BlobSvcContainerGcInterval);
            Assert.NotNull(blobService.BlobSvcShallowGcInterval);
            Assert.NotNull(blobService.BlobSvcStreamMapMinContainerOccupancyPercent);
            Assert.NotNull(blobService.FrontEndCallbackThreadsCount);
            Assert.NotNull(blobService.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.NotNull(blobService.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.NotNull(blobService.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.NotNull(blobService.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.NotNull(blobService.FrontEndHttpListenPort);
            Assert.NotNull(blobService.FrontEndHttpsListenPort);
            Assert.NotNull(blobService.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.NotNull(blobService.FrontEndMemoryThrottleThresholdSettings);
            Assert.NotNull(blobService.FrontEndMemoryThrottlingEnabled);
            Assert.NotNull(blobService.FrontEndMinThreadPoolThreads);
            Assert.NotNull(blobService.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.NotNull(blobService.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.NotNull(blobService.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.NotNull(blobService.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.NotNull(blobService.FrontEndUseSlaTimeInAvailability);
            Assert.NotNull(blobService.Id);
            Assert.NotNull(blobService.Location);
            Assert.NotNull(blobService.Name);
            Assert.NotNull(blobService.Type);
            Assert.NotNull(blobService.Version);
        }

        [Fact]
        public void GetBlobService()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var blobService = client.BlobServices.Get(ResourceGroupName, fName);
                    ValidateBlobService(blobService);
                }
            });
        }

        [Fact]
        public void ListBlobServiceMetricDefinitions()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var blobService = client.BlobServices.Get(ResourceGroupName, fName);
                    var metricDefinitions = client.BlobServices.ListMetricDefinitions(ResourceGroupName, fName);
                }
            });
        }

        [Fact]
        public void ListBlobServiceMetrics() {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var blobService = client.BlobServices.Get(ResourceGroupName, fName);
                    var metricDefinitions = client.BlobServices.ListMetrics(ResourceGroupName, fName);
                }
            });
        }
    }
}
