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
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine)
                {
                    ContainerSettings = new BatchTaskContainerSettings("ubuntu")
                    {
                        ContainerHostBatchBindMounts = {
                            new ContainerHostBatchBindMountEntry{
                                Source = ContainerHostDataPath.Task,
                                IsReadOnly = true,
                            }
                        },
                    }
                };

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
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskGroup taskCollection = new BatchTaskGroup(new BatchTaskCreateOptions[]
                {
                    new BatchTaskCreateOptions(taskID, commandLine)
                });

                BatchCreateTaskCollectionResult batchTaskAddCollectionResult = await client.CreateTaskCollectionAsync(jobID, taskCollection);

                Assert.IsNotNull(batchTaskAddCollectionResult);
                BatchTaskCreateResult batchTaskAddResult = null;
                foreach (BatchTaskCreateResult item in batchTaskAddCollectionResult.Values)
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
        public async Task BulkAddTasks()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BulkAddTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            int taskCount = 10;
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
                for (int i = 0; i < taskCount; i++)
                {
                    tasks.Add(new BatchTaskCreateOptions($"{taskID}_{i}", commandLine));
                }

                CreateTasksResult taskResult = await client.CreateTasksAsync(jobID, tasks);
                Assert.IsNotNull(taskResult);
                Assert.AreEqual(taskCount, taskResult.PassCount);

                for (int i = 0; i < taskCount; i++)
                {
                    BatchTask task = await client.GetTaskAsync(jobID, $"{taskID}_{i}");
                    Assert.IsNotNull(task);
                    Assert.AreEqual(commandLine, task.CommandLine);
                }
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task BulkAddTasks_2000()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BulkAddTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            int taskCount = 2000;
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

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

                // verify sample set of tasks
                BatchTask task1 = await client.GetTaskAsync(jobID, $"{taskID}_0");
                BatchTask task2 = await client.GetTaskAsync(jobID, $"{taskID}_1000");
                BatchTask task3 = await client.GetTaskAsync(jobID, $"{taskID}_1999");
                Assert.IsNotNull(task1);
                Assert.AreEqual(commandLine, task1.CommandLine);
                Assert.IsNotNull(task2);
                Assert.AreEqual(commandLine, task2.CommandLine);
                Assert.IsNotNull(task3);
                Assert.AreEqual(commandLine, task3.CommandLine);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task BulkAddTasks_2000_Parallel_10()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BulkAddTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            int taskCount = 2000;
            int parallelCount = 10;
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
                for (int i = 0; i < taskCount; i++)
                {
                    tasks.Add(new BatchTaskCreateOptions($"{taskID}_{i}", commandLine));
                }
                CreateTasksOptions createTaskOptions = new CreateTasksOptions()
                {
                    MaxDegreeOfParallelism = parallelCount,
                    MaxTimeBetweenCallsInSeconds = IsPlayBack() ? 0 : 30,
                };

                CreateTasksResult taskResult = await client.CreateTasksAsync(jobID, tasks, createTaskOptions);
                Assert.IsNotNull(taskResult);
                Assert.AreEqual(taskCount, taskResult.PassCount);

                // verify sample set of tasks
                BatchTask task1 = await client.GetTaskAsync(jobID, $"{taskID}_0");
                BatchTask task2 = await client.GetTaskAsync(jobID, $"{taskID}_1000");
                BatchTask task3 = await client.GetTaskAsync(jobID, $"{taskID}_1999");
                Assert.IsNotNull(task1);
                Assert.AreEqual(commandLine, task1.CommandLine);
                Assert.IsNotNull(task2);
                Assert.AreEqual(commandLine, task2.CommandLine);
                Assert.IsNotNull(task3);
                Assert.AreEqual(commandLine, task3.CommandLine);

                //client.GetTasks
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [LiveOnly] // this test creates too large of a session recording
        [AsyncOnly]
        public async Task BulkAddTasks_1000000_Parallel_100()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BulkAddTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            int taskCount = 1000000;
            int parallelCount = 100;
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
                for (int i = 0; i < taskCount; i++)
                {
                    tasks.Add(new BatchTaskCreateOptions($"{taskID}_{i}", commandLine));
                }

                CreateTasksOptions createTaskOptions = new CreateTasksOptions()
                {
                    MaxDegreeOfParallelism = parallelCount,
                    MaxTimeBetweenCallsInSeconds = IsPlayBack() ? 0 : 30,
                    ReturnBatchTaskCreateResults = true,
                };
                // Measure memory usage before creating taskResult
                long memoryBefore = GC.GetTotalMemory(true);

                CreateTasksResult taskResult = await client.CreateTasksAsync(jobID, tasks, createTaskOptions);

                // Measure memory usage after creating taskResult
                long memoryAfter = GC.GetTotalMemory(true);

                // Calculate the size of taskResult in memory
                long taskResultSize = memoryAfter - memoryBefore;
                Console.WriteLine($"Size of taskResult in memory: {taskResultSize} bytes");

                Assert.IsNotNull(taskResult);
                Assert.AreEqual(taskCount, taskResult.BatchTaskCreateResults.Count);
                var failedTaskResults = taskResult.BatchTaskCreateResults
                    .Where(result => result.Status != BatchTaskAddStatus.Success)
                    .ToList();
                Assert.AreEqual(0, failedTaskResults.Count);

                // verify sample set of tasks
                BatchTask task1 = await client.GetTaskAsync(jobID, $"{taskID}_0");
                BatchTask task2 = await client.GetTaskAsync(jobID, $"{taskID}_500000");
                BatchTask task3 = await client.GetTaskAsync(jobID, $"{taskID}_999999");
                Assert.IsNotNull(task1);
                Assert.AreEqual(commandLine, task1.CommandLine);
                Assert.IsNotNull(task2);
                Assert.AreEqual(commandLine, task2.CommandLine);
                Assert.IsNotNull(task3);
                Assert.AreEqual(commandLine, task3.CommandLine);
            }
            finally
            {
                await client.DeleteJobAsync(jobID);
                await client.DeletePoolAsync(poolID);
            }
        }

        [LiveOnly] // test run too long even in playback
        public async Task BulkAddTasks_100000_Parallel_100()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "BulkAddTasks", IsPlayBack());
            string poolID = iaasWindowsPoolFixture.PoolId;
            string jobID = "batchJob1";
            string taskID = "Task1";
            int taskCount = 100000;
            int parallelCount = 100;
            string commandLine = "cmd /c echo Hello World";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
                for (int i = 0; i < taskCount; i++)
                {
                    tasks.Add(new BatchTaskCreateOptions($"{taskID}_{i}", commandLine));
                }

                CreateTasksOptions createTaskOptions = new CreateTasksOptions()
                {
                    MaxDegreeOfParallelism = parallelCount,
                    MaxTimeBetweenCallsInSeconds = IsPlayBack() ? 0 : 30,
                    ReturnBatchTaskCreateResults = true,
                };

                CreateTasksResult taskResult = await client.CreateTasksAsync(jobID, tasks, createTaskOptions);

                // verify all the tasks got processed
                Assert.IsNotNull(taskResult);
                Assert.AreEqual(taskCount, taskResult.BatchTaskCreateResults.Count);

                var failedTaskResults = taskResult.BatchTaskCreateResults
                    .Where(result => result.Status != BatchTaskAddStatus.Success)
                    .ToList();
                Assert.AreEqual(0, failedTaskResults.Count);

                // verify sample set of tasks
                BatchTask task1 = await client.GetTaskAsync(jobID, $"{taskID}_0");
                BatchTask task2 = await client.GetTaskAsync(jobID, $"{taskID}_50000");
                BatchTask task3 = await client.GetTaskAsync(jobID, $"{taskID}_99999");
                Assert.IsNotNull(task1);
                Assert.AreEqual(commandLine, task1.CommandLine);
                Assert.IsNotNull(task2);
                Assert.AreEqual(commandLine, task2.CommandLine);
                Assert.IsNotNull(task3);
                Assert.AreEqual(commandLine, task3.CommandLine);
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
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine);

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
                BatchPoolCreateOptions batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions();
                batchPoolCreateOptions.TargetDedicatedNodes = 3;
                batchPoolCreateOptions.TaskSlotsPerNode = 1;
                batchPoolCreateOptions.EnableInterNodeCommunication = true;
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool pool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, iaasWindowsPoolFixture.PoolId);

                BatchPoolInfo batchPoolInfo = new BatchPoolInfo()
                {
                    PoolId = pool.Id
                };
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine)
                {
                    RequiredSlots = 1,
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
                BatchJobCreateOptions batchTaskCreateOptions = new BatchJobCreateOptions(jobID, batchPoolInfo);
                Response response = await client.CreateJobAsync(batchTaskCreateOptions);

                var job = await client.GetJobAsync(jobID);
                Assert.IsNotNull(job);

                BatchTaskCreateOptions taskCreateContent = new BatchTaskCreateOptions(taskID, commandLine);
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
