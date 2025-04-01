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
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchJobCreateContent);

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
                Assert.AreEqual(job.OnAllTasksComplete, OnAllBatchTasksComplete.NoAction);

                // verify update job
                job.OnAllTasksComplete = OnAllBatchTasksComplete.TerminateJob;
                response = await client.ReplaceJobAsync(jobID, job);
                job = await client.GetJobAsync(jobID);

                Assert.IsNotNull(job);
                Assert.AreEqual(job.OnAllTasksComplete, OnAllBatchTasksComplete.TerminateJob);

                // create a task
                BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent(taskID, commandLine);
                response = await client.CreateTaskAsync(jobID, taskCreateContent);
                Assert.IsFalse(response.IsError);

                // list task counts
                BatchTaskCountsResult batchTaskCountsResult = await client.GetJobTaskCountsAsync(jobID);
                Assert.IsNotNull(batchTaskCountsResult);
                // need to make a loop and ping GetJobTaskCountsAsync to get the status
                //Assert.AreEqual(batchTaskCountsResult.TaskCounts.Active, 1);

                // disable a job
                BatchJobDisableContent content = new BatchJobDisableContent(DisableBatchJobOption.Requeue);
                response = await client.DisableJobAsync(jobID, content);
                Assert.IsFalse(response.IsError);

                // enable a job
                response = await client.EnableJobAsync(jobID);
                Assert.IsFalse(response.IsError);

                await WaitForTasksToComplete(client, jobID, IsPlayBack());

                // get JobPreparationAndReleaseTaskStatuses
                int count = 0;
                await foreach (BatchJobPreparationAndReleaseTaskStatus item in client.GetJobPreparationAndReleaseTaskStatusesAsync(jobID))
                {
                    count++;
                }
                Assert.AreNotEqual(0, count);

                // job terminate
                BatchJobTerminateContent parameters = new BatchJobTerminateContent
                {
                    TerminationReason = "<terminateReason>",
                };
                response = await client.TerminateJobAsync(jobID, parameters, force: true);
                Assert.IsFalse(response.IsError);
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
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchJobCreateContent);
                Assert.AreEqual(201, response.Status);

                // verify update job
                BatchJobUpdateContent batchUpdateContent = new BatchJobUpdateContent();
                batchUpdateContent.Metadata.Add(new MetadataItem("name", "value"));

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
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo)
                {
                    JobPreparationTask = new BatchJobPreparationTask(commandLine),
                    JobReleaseTask = new BatchJobReleaseTask(commandLine),
                };
                Response response = await client.CreateJobAsync(batchJobCreateContent);
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
    }
}
