// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class BatchJobIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchJobIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchJobIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchJobIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task JobOperations()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "JobOperations", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                // verify list jobs
                BatchJob job = null;
                await foreach (BatchJob item in client.GetJobsAsync())
                {
                    if (item.Id == jobID)
                    {
                        job = item;
                    }
                }

                Assert.IsNotNull(job);
                Assert.AreEqual(job.AllTasksCompleteMode, BatchAllTasksCompleteMode.NoAction);

                // verify update job
                job.AllTasksCompleteMode = BatchAllTasksCompleteMode.TerminateJob;
                response = await client.ReplaceJobAsync(jobID, job);
                job = await client.GetJobAsync(jobID);

                Assert.IsNotNull(job);
                Assert.AreEqual(job.AllTasksCompleteMode, BatchAllTasksCompleteMode.TerminateJob);

                // create a task
                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine);
                response = await client.CreateTaskAsync(jobID, taskCreateContent);
                Assert.IsFalse(response.IsError);

                // list task counts
                BatchTaskCountsResult batchTaskCountsResult = await client.GetJobTaskCountsAsync(jobID);
                Assert.IsNotNull(batchTaskCountsResult);
                // need to make a loop and ping GetJobTaskCountsAsync to get the status
                //Assert.AreEqual(batchTaskCountsResult.TaskCounts.Active, 1);

                // disable a job
                BatchJobDisableOptions content = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
                DisableJobOperation jobOperation = await client.DisableJobAsync(jobID, content);
                await jobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(jobOperation.HasCompleted);
                Assert.IsTrue(jobOperation.HasValue);
                Assert.AreEqual(jobOperation.Value.State, BatchJobState.Disabled);
                Assert.IsFalse(jobOperation.GetRawResponse().IsError);

                // enable a job
                EnableJobOperation enableJobOperation = await client.EnableJobAsync(jobID);
                await enableJobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(enableJobOperation.HasCompleted);
                Assert.IsTrue(enableJobOperation.HasValue);
                Assert.AreEqual(enableJobOperation.Value.State, BatchJobState.Active);
                Assert.IsFalse(enableJobOperation.GetRawResponse().IsError);

                await WaitForTasksToComplete(client, jobID, IsPlayBack());

                // get JobPreparationAndReleaseTaskStatuses
                int count = 0;
                await foreach (BatchJobPreparationAndReleaseTaskStatus item in client.GetJobPreparationAndReleaseTaskStatusesAsync(jobID))
                {
                    count++;
                }
                Assert.AreNotEqual(0, count);

                // job terminate
                BatchJobTerminateOptions parameters = new BatchJobTerminateOptions
                {
                    TerminationReason = "<terminateReason>",
                };
                TerminateJobOperation terminateJobOperation = await client.TerminateJobAsync(jobID, parameters, force: true);
                await terminateJobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(terminateJobOperation.HasCompleted);
                Assert.IsTrue(terminateJobOperation.HasValue);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
                await client.DeleteJobAsync(jobID, force: true);
            }
        }

        [RecordedTest]
        public async Task PatchJob()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PatchJob", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob2";
            string commandLine = "cmd /c echo Hello World";
            //string subnetID = "0.0.0.0";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);
                Assert.AreEqual(201, response.Status);

                // verify update job
                BatchJobUpdateOptions batchUpdateContent = new BatchJobUpdateOptions();
                batchUpdateContent.Metadata.Add(new BatchMetadataItem("name", "value"));

                // todo need to setup specific account for this to be set
                //batchUpdateContent.NetworkConfiguration = new BatchJobNetworkConfiguration(subnetID, false);

                response = await client.UpdateJobAsync(jobID, batchUpdateContent);
                Assert.AreEqual(200, response.Status);

                BatchJob job = await client.GetJobAsync(jobID);

                Assert.IsNotNull(job);
                Assert.AreEqual(job.Metadata.First().Value, "value");
                //Assert.AreEqual(job.NetworkConfiguration.SubnetId, subnetID);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
                await client.DeleteJobAsync(jobID);
            }
        }

        [RecordedTest]
        public async Task TerminateJob()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PatchJob", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "terminateJob";
            string commandLine = "cmd /c echo Hello World";
            //string subnetID = "0.0.0.0";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);
                Assert.AreEqual(201, response.Status);

                // get the job
                BatchJob job = await client.GetJobAsync(jobID);
                Assert.AreEqual(BatchJobState.Active, job.State);

                await client.TerminateJobAsync(jobID, force: true);

                job = await client.GetJobAsync(jobID);
                while (job.State != BatchJobState.Completed)
                {
                    TestSleep(10);
                    job = await client.GetJobAsync(jobID);
                }

                Assert.AreEqual("UserTerminate", job.ExecutionInfo.TerminationReason);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
                await client.DeleteJobAsync(jobID);
            }
        }

        [RecordedTest]
        public async Task DeleteJob()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "DeleteJob", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "deleteJob";
            string commandLine = "cmd /c echo Hello World";
            string taskID = "Task1";
            int taskCount = 20;
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(1);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);
                Assert.AreEqual(201, response.Status);

                List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
                for (int i = 0; i < taskCount; i++)
                {
                    tasks.Add(new BatchTaskCreateOptions($"{taskID}_{i}", commandLine));
                }
                CreateTasksOptions createTaskOptions = new CreateTasksOptions()
                {
                    MaxTimeBetweenCallsInSeconds = IsPlayBack() ? 0 : 30,
                    ReturnBatchTaskCreateResults = true,
                };

                CreateTasksResult taskResult = await client.CreateTasksAsync(jobID, tasks, createTaskOptions);
                Assert.IsNotNull(taskResult);
                Assert.AreEqual(taskCount, taskResult.BatchTaskCreateResults.Count);

                // get the job
                BatchJob job = await client.GetJobAsync(jobID);
                Assert.AreEqual(BatchJobState.Active, job.State);

                DeleteJobOperation operation = await client.DeleteJobAsync(jobID, force: true);

                Assert.IsNotNull(operation);

                await operation.WaitForCompletionAsync().ConfigureAwait(false);

                Assert.IsTrue(operation.HasCompleted);
                Assert.IsTrue(operation.HasValue);
                Assert.IsTrue(operation.Value);

                DeleteJobOperation operation2 = new DeleteJobOperation(client, operation.Id);
                await operation2.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.IsTrue(operation2.HasValue);
                Assert.IsTrue(operation2.HasCompleted);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
