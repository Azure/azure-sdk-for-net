// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Common;
    using TestUtilities;

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
                IEnumerable<Protocol.Models.CloudTask> protocolTasks = taskIds.Select(CreateProtocolCloudTask);
                IEnumerable<CloudTask> taskList = protocolTasks.Select(protoTask => CreateBoundCloudTask(batchCli, dummyJobId, protoTask));

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

                    await Assert.ThrowsAsync<OperationCanceledException>(async () => await taskStateMonitor.WhenAll(
                        taskList,
                        TaskState.Running,
                        controlParams: controls,
                        cancellationToken: cancellationTokenSource.Token));
                    DateTime endTime = DateTime.UtcNow;
                    TimeSpan duration = endTime.Subtract(startTime);

                    Assert.True(Math.Abs(duration.TotalSeconds - duration.TotalSeconds) < TimeToleranceInSeconds,
                        string.Format("Expected timeout: {0}, Observed timeout: {1}", timeout, duration));
                }
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TaskStateMonitorTimedOut_ThrowsTimeoutException()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(0);
            const string dummyJobId = "Dummy";

            using (BatchClient batchCli = BatchClient.Open(ClientUnitTestCommon.CreateDummySharedKeyCredential()))
            {
                List<string> taskIds = new List<string>()
                    {
                        "task1",
                        "task2"
                    };

                //Create some tasks which are "bound"
                IEnumerable<Protocol.Models.CloudTask> protocolTasks = taskIds.Select(CreateProtocolCloudTask);
                IEnumerable<CloudTask> taskList = protocolTasks.Select(protoTask => CreateBoundCloudTask(batchCli, dummyJobId, protoTask));

                TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => await taskStateMonitor.WhenAll(
                    taskList,
                    TaskState.Completed,
                    timeout,
                    additionalBehaviors: InterceptorFactory.CreateListTasksRequestInterceptor(protocolTasks)));

                Assert.Contains(string.Format("waiting for resources after {0}", timeout), e.Message);
                Assert.IsType<OperationCanceledException>(e.InnerException);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TaskStateMonitorCancelled_ThrowsCancellationException()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(0);
            const string dummyJobId = "Dummy";

            using (BatchClient batchCli = BatchClient.Open(ClientUnitTestCommon.CreateDummySharedKeyCredential()))
            {
                List<string> taskIds = new List<string>()
                    {
                        "task1",
                        "task2"
                    };

                //Create some tasks which are "bound"
                IEnumerable<Protocol.Models.CloudTask> protocolTasks = taskIds.Select(CreateProtocolCloudTask);
                IEnumerable<CloudTask> taskList = protocolTasks.Select(protoTask => CreateBoundCloudTask(batchCli, dummyJobId, protoTask));

                TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                using (CancellationTokenSource cts = new CancellationTokenSource(timeout))
                {
                    await Assert.ThrowsAsync<OperationCanceledException>(async () => await taskStateMonitor.WhenAll(
                        taskList,
                        TaskState.Completed,
                        cts.Token,
                        additionalBehaviors: InterceptorFactory.CreateListTasksRequestInterceptor(protocolTasks)));
                }
            }
        }

        #region Private helpers

        private static Protocol.Models.CloudTask CreateProtocolCloudTask(string taskId)
        {
            return new Protocol.Models.CloudTask(taskId, "dummy");
        }

        private static CloudTask CreateBoundCloudTask(BatchClient batchClient, string parentJobId, Protocol.Models.CloudTask protoTask)
        {
            CloudTask cloudTask = new CloudTask(batchClient, parentJobId, protoTask, batchClient.CustomBehaviors);

            return cloudTask;
        }

        #endregion

    }
}
