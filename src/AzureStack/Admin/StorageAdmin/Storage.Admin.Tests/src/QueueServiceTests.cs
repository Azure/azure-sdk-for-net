using System.Linq;
using Microsoft.AzureStack.Management.Storage.Admin;
using Microsoft.AzureStack.Management.Storage.Admin.Models;
using Xunit;

namespace Storage.Tests
{
    public class QueueServicesTests : StorageTestBase
    {

        private void ValidateQueueService(QueueService queueService)
        {
            Assert.NotNull(queueService);
            Assert.NotNull(queueService.FrontEndCallbackThreadsCount);
            Assert.NotNull(queueService.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.NotNull(queueService.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.NotNull(queueService.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.NotNull(queueService.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.NotNull(queueService.FrontEndHttpListenPort);
            Assert.NotNull(queueService.FrontEndHttpsListenPort);
            Assert.NotNull(queueService.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.NotNull(queueService.FrontEndMemoryThrottleThresholdSettings);
            Assert.NotNull(queueService.FrontEndMemoryThrottlingEnabled);
            Assert.NotNull(queueService.FrontEndMinThreadPoolThreads);
            Assert.NotNull(queueService.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.NotNull(queueService.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.NotNull(queueService.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.NotNull(queueService.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.NotNull(queueService.FrontEndUseSlaTimeInAvailability);
            //Assert.NotNull(queueService.HealthStatus);
            Assert.NotNull(queueService.Id);
            Assert.NotNull(queueService.Location);
            Assert.NotNull(queueService.Name);
            Assert.NotNull(queueService.Type);
            Assert.NotNull(queueService.Version);
        }

        [Fact]
        public void GetQueueService()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach(var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var retrieved = client.QueueServices.Get(ResourceGroupName, fName);
                    ValidateQueueService(retrieved);
                }
            });
        }

        [Fact]
        public void ListAllQueueServiceMetricDefinitions()
        {
            RunTest((client) => {
            var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.QueueServices.ListMetricDefinitions(ResourceGroupName,fName);
                    Common.WriteIEnumerableToFile(result, "ListAllQueueServiceMetricDefinitions.txt");
                }
            });
        }

        [Fact]
        public void ListAllQueueServiceMetrics()
        {
            RunTest((client) => {
                var farms = client.Farms.List(ResourceGroupName);
                foreach (var farm in farms)
                {
                    var fName = ExtractName(farm.Name);
                    var result = client.QueueServices.ListMetrics(ResourceGroupName, fName);
                    Common.WriteIEnumerableToFile(result, "ListAllQueueServiceMetrics.txt");
                }
            });
        }
    }
}
