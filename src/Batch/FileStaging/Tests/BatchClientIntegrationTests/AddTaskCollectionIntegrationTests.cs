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

extern alias fs;  // Temporary bridge until the Batch core NuGet without file staging is published

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using StagingStorageAccount = fs::Microsoft.Azure.Batch.FileStaging.StagingStorageAccount;  // Temporary bridge until the Batch core NuGet without file staging is published
    using FileToStage = fs::Microsoft.Azure.Batch.FileStaging.FileToStage;  // Temporary bridge until the Batch core NuGet without file staging is published
    using IntegrationTestUtilities;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class AddTaskCollectionIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(4);

        private readonly ITestOutputHelper testOutputHelper;

        public AddTaskCollectionIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanAddTasksWithFilesToStage(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchWithFilesToStage";
            const int taskCount = 499;
            List<string> localFilesToStage = new List<string>();

            localFilesToStage.Add("TestResources\\Data.txt");

            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> artifacts = new ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>>();

            List<int> legArtifactsCountList = new List<int>();
            using(CancellationTokenSource cts = new CancellationTokenSource())
            {
                //Spawn a thread to monitor the files to stage as we go - we should observe that
                Task t = Task.Factory.StartNew(() =>
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        legArtifactsCountList.Add(artifacts.Count);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                });

                await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    StagingStorageAccount storageCredentials = TestUtilities.GetStorageCredentialsFromEnvironment();
                    using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                    {
                        await this.AddTasksSimpleTestAsync(
                            batchCli,
                            testName,
                            taskCount,
                            parallelOptions: new BatchClientParallelOptions() { MaxDegreeOfParallelism = 2 },
                            resultHandlerFunc: null,
                            storageCredentials: storageCredentials,
                            localFilesToStage: localFilesToStage,
                            fileStagingArtifacts: artifacts,
                            useJobOperations: useJobOperations).ConfigureAwait(false);

                        cts.Cancel();

                        await t.ConfigureAwait(false); //Wait for the spawned thread to exit

                        this.testOutputHelper.WriteLine("File staging leg count: [");
                        foreach (int fileStagingArtifactsCount in legArtifactsCountList)
                        {
                            this.testOutputHelper.WriteLine(fileStagingArtifactsCount + ", ");
                        }
                        this.testOutputHelper.WriteLine("]");

                        const int expectedFinalFileStagingArtifactsCount = taskCount / 100 + 1;
                        const int expectedInitialFileStagingArtifactsCount = 0;

                        Assert.Equal(expectedInitialFileStagingArtifactsCount, legArtifactsCountList.First());
                        Assert.Equal(expectedFinalFileStagingArtifactsCount, legArtifactsCountList.Last());
                    }
                },
                TestTimeout);
            }
        }

        /// <summary>
        /// Ensures that the two lists of tasks contain CloudTasks with the same Ids
        /// </summary>
        /// <param name="expectedTaskList"></param>
        /// <param name="actualTaskList"></param>
        private static void EnsureTasksListsMatch(
            List<CloudTask> expectedTaskList,
            List<CloudTask> actualTaskList)
        {
            Assert.Equal(expectedTaskList.Count, actualTaskList.Count);

            foreach (CloudTask actualTask in actualTaskList)
            {
                CloudTask expectedTask = expectedTaskList.FirstOrDefault(item => item.Id.Equals(actualTask.Id));

                Assert.NotNull(expectedTask);

                IEnumerable<ResourceFile> expectedTaskResourceFiles = expectedTask.ResourceFiles;
                IEnumerable<ResourceFile> actualTaskResourceFiles = actualTask.ResourceFiles;
                if (expectedTaskResourceFiles != null)
                {
                    Assert.Equal(expectedTaskResourceFiles.Count(), actualTaskResourceFiles.Count());
                }
            }
        }

        /// <summary>
        /// Generates the specified number of task Ids
        /// </summary>
        /// <param name="taskCount"></param>
        /// <returns></returns>
        private static IEnumerable<string> GenerateTaskIds(int taskCount)
        {
            List<string> results = new List<string>();

            for (int i = 0; i < taskCount; i++)
            {
                results.Add("Task" + i);
            }
            return results;
        }

        /// <summary>
        /// Performs a simple AddTask test, adding the specified task count using the specified parallelOptions and resultHandlerFunc
        /// </summary>
        /// <returns></returns>
        private async System.Threading.Tasks.Task AddTasksSimpleTestAsync(
            BatchClient batchCli,
            string testName,
            int taskCount,
            BatchClientParallelOptions parallelOptions,
            Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandlerFunc,
            StagingStorageAccount storageCredentials,
            IEnumerable<string> localFilesToStage,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null,
            bool useJobOperations = true)
        {
            JobOperations jobOperations = batchCli.JobOperations;

            string jobId = "Bulk-" + TestUtilities.GetMyName() + "-" + testName + "-" + useJobOperations;

            try
            {
                CloudJob unboundJob = jobOperations.CreateJob();

                this.testOutputHelper.WriteLine("Initial job commit for job: {0}", jobId);
                unboundJob.PoolInformation = new PoolInformation()
                    {
                        PoolId = "DummyPool"
                    };
                unboundJob.Id = jobId;
                await unboundJob.CommitAsync().ConfigureAwait(false);

                CloudJob boundJob = await jobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                //
                // Add a simple set of tasks
                //
                IEnumerable<string> taskNames = GenerateTaskIds(taskCount);
                List<CloudTask> tasksToAdd = new List<CloudTask>();
                List<CloudTask> tasksToValidateWith = new List<CloudTask>();
                IList<IFileStagingProvider> lastFilesToStageList = null;
                foreach (string taskName in taskNames)
                {
                    CloudTask myTask = new CloudTask(taskName, "cmd /c echo hello world");
                    CloudTask duplicateReadableTask = new CloudTask(taskName, "cmd /c echo hello world");

                    if (localFilesToStage != null && storageCredentials != null)
                    {
                        myTask.FilesToStage = new List<IFileStagingProvider>();

                        lastFilesToStageList = myTask.FilesToStage;

                        duplicateReadableTask.FilesToStage = new List<IFileStagingProvider>();
                        foreach (string fileToStage in localFilesToStage)
                        {
                            duplicateReadableTask.FilesToStage.Add(new FileToStage(fileToStage, storageCredentials));
                            myTask.FilesToStage.Add(new FileToStage(fileToStage, storageCredentials));
                        }
                    }

                    tasksToAdd.Add(myTask);
                    tasksToValidateWith.Add(duplicateReadableTask);
                }

                List<BatchClientBehavior> behaviors = new List<BatchClientBehavior>();
                if (resultHandlerFunc != null)
                {
                    behaviors.Add(new AddTaskCollectionResultHandler(resultHandlerFunc));
                }

                //Add the tasks
                Stopwatch stopwatch = new Stopwatch();
                this.testOutputHelper.WriteLine("Starting task add");
                stopwatch.Start();

                if (useJobOperations)
                {
                    await jobOperations.AddTaskAsync(
                        jobId,
                        tasksToAdd,
                        parallelOptions: parallelOptions,
                        fileStagingArtifacts: fileStagingArtifacts,
                        timeout: timeout,
                        additionalBehaviors: behaviors).ConfigureAwait(continueOnCapturedContext: false);
                }
                else
                {
                    await boundJob.AddTaskAsync(
                        tasksToAdd,
                        parallelOptions: parallelOptions,
                        fileStagingArtifacts: fileStagingArtifacts,
                        timeout: timeout,
                        additionalBehaviors: behaviors).ConfigureAwait(continueOnCapturedContext: false);
                }

                stopwatch.Stop();
                this.testOutputHelper.WriteLine("Task add finished, took: {0}", stopwatch.Elapsed);

                if (lastFilesToStageList != null)
                {
                    TestUtilities.AssertThrows<InvalidOperationException>(() => lastFilesToStageList.Add(new FileToStage("test", null)));
                }

                //Ensure the task lists match
                List<CloudTask> tasksFromService = await jobOperations.ListTasks(jobId).ToListAsync().ConfigureAwait(false);
                EnsureTasksListsMatch(tasksToValidateWith, tasksFromService);
            }
            catch (Exception e)
            {
                this.testOutputHelper.WriteLine("Exception: {0}", e.ToString());
                throw;
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
            }
        }
    }
}
