namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using CloudTask = Microsoft.Azure.Batch.CloudTask;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using TaskState = Microsoft.Azure.Batch.Common.TaskState;

    public class UtilitiesUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private const double TimeToleranceInSeconds = 0.1;

        public UtilitiesUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TaskStateMonitorCancellation()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(.5);
            const string dummyJobId = "Dummy";
            using (BatchClient batchCli = BatchClient.Open(ClientUnitTestCommon.CreateDummySharedKeyCredential()))
            {
                List<string> taskIds = new List<string>()
                    {
                        "task1",
                        "task2"
                    };

                //Set up a request interceptor to handle all list task requests
                batchCli.CustomBehaviors.Add(new Protocol.RequestInterceptor(req =>
                {
                    var typedRequest =
                        (Protocol.BatchRequest<
                        Protocol.Models.TaskListOptions,
                        AzureOperationResponse<IPage<Protocol.Models.CloudTask>, Protocol.Models.TaskListHeaders>>)req;

                    typedRequest.ServiceRequestFunc = token =>
                    {
                        List<Protocol.Models.CloudTask> protoTaskList = new List<Protocol.Models.CloudTask>();
                        foreach (string taskId in taskIds)
                        {
                            protoTaskList.Add(new Protocol.Models.CloudTask(taskId, "dummy"));
                        }

                        var response = new AzureOperationResponse<IPage<Protocol.Models.CloudTask>, Protocol.Models.TaskListHeaders>()
                            {
                                Body = new FakePage<Protocol.Models.CloudTask>(protoTaskList)
                            };

                        return Task.FromResult(response);
                    };
                }));

                //Create some tasks which are "bound"
                List<CloudTask> taskList = new List<CloudTask>();
                foreach (string taskId in taskIds)
                {
                    taskList.Add(CreateBoundCloudTask(batchCli, dummyJobId, taskId));
                }

                TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();

                DateTime startTime = DateTime.UtcNow;

                //Set up the cancellation token
                using (CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeout))
                {
                    //ODataMonitor Controls specify wait between calls as 0
                    ODATAMonitorControl controls = new ODATAMonitorControl()
                        {
                            DelayBetweenDataFetch = TimeSpan.FromSeconds(0)
                        };

                    await Assert.ThrowsAsync<OperationCanceledException>(async () => await taskStateMonitor.WhenAllAsync(
                        taskList,
                        TaskState.Running,
                        TimeSpan.FromHours(1), //Set a long timeout that won't be hit
                        controlParams: controls,
                        cancellationToken: cancellationTokenSource.Token));
                    DateTime endTime = DateTime.UtcNow;
                    TimeSpan duration = endTime.Subtract(startTime);

                    Assert.True(Math.Abs(duration.TotalSeconds - duration.TotalSeconds) < TimeToleranceInSeconds,
                        string.Format("Expected timeout: {0}, Observed timeout: {1}", timeout, duration));
                }
            }
        }

        #region Private helpers

        private static CloudTask CreateBoundCloudTask(BatchClient batchClient, string parentJobId, string taskId)
        {
            Protocol.Models.CloudTask protoTask = new Protocol.Models.CloudTask(taskId, "dummy");
            CloudTask cloudTask = new CloudTask(batchClient, parentJobId, protoTask, batchClient.CustomBehaviors);

            return cloudTask;
        }

        #endregion

    }
}
