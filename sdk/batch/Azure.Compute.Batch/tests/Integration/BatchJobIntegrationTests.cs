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

                Assert.Multiple(() =>
                {
                    Assert.That(job, Is.Not.Null);
                    Assert.That(BatchAllTasksCompleteMode.NoAction, Is.EqualTo(job.AllTasksCompleteMode));
                });

                // verify update job
                job.AllTasksCompleteMode = BatchAllTasksCompleteMode.TerminateJob;
                response = await client.ReplaceJobAsync(jobID, job);
                job = await client.GetJobAsync(jobID);

                Assert.Multiple(() =>
                {
                    Assert.That(job, Is.Not.Null);
                    Assert.That(BatchAllTasksCompleteMode.TerminateJob, Is.EqualTo(job.AllTasksCompleteMode));
                });

                // create a task
                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine);
                response = await client.CreateTaskAsync(jobID, taskCreateContent);
                Assert.That(response.IsError, Is.False);

                // list task counts
                BatchTaskCountsResult batchTaskCountsResult = await client.GetJobTaskCountsAsync(jobID);
                Assert.That(batchTaskCountsResult, Is.Not.Null);
                // need to make a loop and ping GetJobTaskCountsAsync to get the status
                //Assert.AreEqual(batchTaskCountsResult.TaskCounts.Active, 1);

                // disable a job
                BatchJobDisableOptions content = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
                DisableJobOperation jobOperation = await client.DisableJobAsync(jobID, content);
                await jobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.Multiple(() =>
                {
                    Assert.That(jobOperation.HasCompleted, Is.True);
                    Assert.That(jobOperation.HasValue, Is.True);
                    Assert.That(BatchJobState.Disabled, Is.EqualTo(jobOperation.Value.State));
                    Assert.That(jobOperation.GetRawResponse().IsError, Is.False);
                });

                // enable a job
                EnableJobOperation enableJobOperation = await client.EnableJobAsync(jobID);
                await enableJobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.Multiple(() =>
                {
                    Assert.That(enableJobOperation.HasCompleted, Is.True);
                    Assert.That(enableJobOperation.HasValue, Is.True);
                    Assert.That(BatchJobState.Active, Is.EqualTo(enableJobOperation.Value.State));
                    Assert.That(enableJobOperation.GetRawResponse().IsError, Is.False);
                });

                await WaitForTasksToComplete(client, jobID, IsPlayBack());

                // get JobPreparationAndReleaseTaskStatuses
                int count = 0;
                await foreach (BatchJobPreparationAndReleaseTaskStatus item in client.GetJobPreparationAndReleaseTaskStatusesAsync(jobID))
                {
                    count++;
                }
                Assert.That(count, Is.Not.EqualTo(0));

                // job terminate
                BatchJobTerminateOptions parameters = new BatchJobTerminateOptions
                {
                    TerminationReason = "<terminateReason>",
                };
                TerminateJobOperation terminateJobOperation = await client.TerminateJobAsync(jobID, parameters, force: true);
                await terminateJobOperation.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.Multiple(() =>
                {
                    Assert.That(terminateJobOperation.HasCompleted, Is.True);
                    Assert.That(terminateJobOperation.HasValue, Is.True);
                });
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
                Assert.That(response.Status, Is.EqualTo(201));

                // verify update job
                BatchJobUpdateOptions batchUpdateContent = new BatchJobUpdateOptions();
                batchUpdateContent.Metadata.Add(new BatchMetadataItem("name", "value"));

                // todo need to setup specific account for this to be set
                //batchUpdateContent.NetworkConfiguration = new BatchJobNetworkConfiguration(subnetID, false);

                response = await client.UpdateJobAsync(jobID, batchUpdateContent);
                Assert.That(response.Status, Is.EqualTo(200));

                BatchJob job = await client.GetJobAsync(jobID);

                Assert.That(job, Is.Not.Null);
                Assert.That(job.Metadata.First().Value, Is.EqualTo("value"));
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
                Assert.That(response.Status, Is.EqualTo(201));

                // get the job
                BatchJob job = await client.GetJobAsync(jobID);
                Assert.That(job.State, Is.EqualTo(BatchJobState.Active));

                await client.TerminateJobAsync(jobID, force: true);

                job = await client.GetJobAsync(jobID);
                while (job.State != BatchJobState.Completed)
                {
                    TestSleep(10);
                    job = await client.GetJobAsync(jobID);
                }

                Assert.That(job.ExecutionInfo.TerminationReason, Is.EqualTo("UserTerminate"));
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
                Assert.That(response.Status, Is.EqualTo(201));

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
                Assert.That(taskResult, Is.Not.Null);
                Assert.That(taskResult.BatchTaskCreateResults, Has.Count.EqualTo(taskCount));

                // get the job
                BatchJob job = await client.GetJobAsync(jobID);
                Assert.That(job.State, Is.EqualTo(BatchJobState.Active));

                DeleteJobOperation operation = await client.DeleteJobAsync(jobID, force: true);

                Assert.That(operation, Is.Not.Null);

                await operation.WaitForCompletionAsync().ConfigureAwait(false);

                Assert.Multiple(() =>
                {
                    Assert.That(operation.HasCompleted, Is.True);
                    Assert.That(operation.HasValue, Is.True);
                    Assert.That(operation.Value, Is.True);
                });

                DeleteJobOperation operation2 = new DeleteJobOperation(client, operation.Id);
                await operation2.WaitForCompletionAsync().ConfigureAwait(false);
                Assert.Multiple(() =>
                {
                    Assert.That(operation2.HasValue, Is.True);
                    Assert.That(operation2.HasCompleted, Is.True);
                });
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
