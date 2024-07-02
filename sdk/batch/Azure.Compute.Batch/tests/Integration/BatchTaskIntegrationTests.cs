// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class BatchTaskIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchTaskIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchTaskIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task AddTask()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "AddTask", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent(taskID, commandLine);
                response = await client.CreateTaskAsync(jobID, taskCreateContent);

                BatchTask task = await client.GetTaskAsync(jobID, taskID);
                Assert.IsNotNull(task);
                Assert.AreEqual(commandLine, task.CommandLine);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task AddTaskCollection()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "AddTaskCollection", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskGroup taskCollection = new BatchTaskGroup(new BatchTaskCreateContent[]
                {
                    new BatchTaskCreateContent(taskID, commandLine)
                });

                BatchTaskAddCollectionResult batchTaskAddCollectionResult = await client.CreateTaskCollectionAsync(jobID, taskCollection);

                Assert.IsNotNull(batchTaskAddCollectionResult);
                BatchTaskAddResult batchTaskAddResult = null;
                foreach (BatchTaskAddResult item in batchTaskAddCollectionResult.Value)
                {
                    batchTaskAddResult = item;
                }

                Assert.IsNotNull(batchTaskAddResult);
                Assert.AreEqual(batchTaskAddResult.TaskId, taskID);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task TaskUpdate()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "TaskUpdate", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent(taskID, commandLine);

                response = await client.CreateTaskAsync(jobID, taskCreateContent);
                Assert.AreEqual(201, response.Status);

                // get task via lists tasks
                BatchTask task = null;
                await foreach (BatchTask item in client.GetTasksAsync(jobID))
                {
                    task = item;
                }

                Assert.IsNotNull(task);
                Assert.AreEqual(commandLine, task.CommandLine);

                // update task constraints
                BatchTaskConstraints batchTaskConstraints = new BatchTaskConstraints()
                {
                    MaxTaskRetryCount = 3,
                };

                task.Constraints = batchTaskConstraints;
                response = await client.ReplaceTaskAsync(jobID, taskID, task);
                Assert.AreEqual(200, response.Status);

                // verify task got updated
                BatchTask updatedTask = await client.GetTaskAsync(jobID, taskID);
                Assert.IsNotNull(updatedTask);
                Assert.AreEqual(3, updatedTask.Constraints.MaxTaskRetryCount);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task TaskListSubTasks()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "TaskListSubTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPoolCreateContent batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions();
                batchPoolCreateOptions.TargetDedicatedNodes = 3;
                batchPoolCreateOptions.TaskSlotsPerNode = 1;
                batchPoolCreateOptions.EnableInterNodeCommunication = true;
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool pool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, iaasWindowsPoolFixture.PoolId);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent(taskID, commandLine)
                {
                    RequiredSlots =1,
                    MultiInstanceSettings = new MultiInstanceSettings(commandLine)
                    {
                        NumberOfInstances = 1,
                    },
                };

                response = await client.CreateTaskAsync(jobID, taskCreateContent);
                Assert.AreEqual(201, response.Status);

                // list subtasks
                int count = 0;
                await foreach (BatchSubtask item in client.GetSubTasksAsync(jobID, taskID))
                {
                    count++;
                }
                Assert.AreEqual(0, count);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task TaskReactive()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "TaskReactive", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateContent batchJobCreateContent = new BatchJobCreateContent(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchJobCreateContent);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent(taskID, commandLine);
                response = await client.CreateTaskAsync(jobID, taskCreateContent);

                BatchTask task = await client.GetTaskAsync(jobID, taskID);
                Assert.IsNotNull(task);
                Assert.AreEqual(commandLine, task.CommandLine);

                response = await client.TerminateTaskAsync(jobID, taskID);
                Assert.AreEqual(204, response.Status);

                response = await client.ReactivateTaskAsync(jobID, taskID);
                Assert.AreEqual(204, response.Status);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
