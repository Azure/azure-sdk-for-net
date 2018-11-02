// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests
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
        public async Task Bug1360227_AddTasksBatchSimple(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchSimple";

            await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                    {
                        await this.AddTasksSimpleTestAsync(batchCli, testName, 50, useJobOperations: useJobOperations).ConfigureAwait(false);
                    }
                },
                TestTimeout);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task Bug1360227_AddTasksBatchMultipleBatches(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchMultipleBatches";

            await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                    {
                        await this.AddTasksSimpleTestAsync(batchCli, testName, 550, useJobOperations: useJobOperations).ConfigureAwait(false);
                    }
                },
                TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task Bug1360227_AddTasksBatchHugeTaskCount()
        {
            const string testName = "Bug1360227_AddTasksBatchHugeTaskCount";

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                                                                 {
                                                                     MaxDegreeOfParallelism = 25
                                                                 };

                    await this.AddTasksSimpleTestAsync(batchCli, testName, 5025, parallelOptions).ConfigureAwait(false);
                }
            },
            LongTestTimeout);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task Bug1360227_AddTasksBatchFailure(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchFailure";
            int count = 0;
            const int countToFailAt = 102;
            const int taskCount = 407;
            HashSet<string> taskIdsExpectedToFail = new HashSet<string>();
            Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandlerFunc = (result, token) =>
            {
                this.testOutputHelper.WriteLine("Task: {0} got status code: {1}", result.TaskId, result.Status);
                ++count;

                if (taskIdsExpectedToFail.Contains(result.TaskId))
                {
                    return AddTaskResultStatus.Retry;
                }
                else
                {
                    if (count >= countToFailAt)
                    {
                        taskIdsExpectedToFail.Add(result.TaskId);

                        this.testOutputHelper.WriteLine("Forcing a failure");

                        //Throw an exception to cause a failure from the customers result handler -- this is a supported scenario which will
                        //terminate the add task operation
                        throw new HttpRequestException("Test");
                    }
                    else
                    {
                        return AddTaskResultStatus.Success;
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                    {
                        MaxDegreeOfParallelism = 2
                    };

                    var exception = await TestUtilities.AssertThrowsAsync<ParallelOperationsException>(
                        async () => await this.AddTasksSimpleTestAsync(
                            batchCli,
                            testName,
                            taskCount,
                            parallelOptions,
                            resultHandlerFunc,
                            useJobOperations: useJobOperations).ConfigureAwait(false)).ConfigureAwait(false);
                    Assert.IsType<HttpRequestException>(exception.InnerException);
                }
            },
            TestTimeout);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task Bug1360227_AddTasksBatchRetry(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchRetry";

            Random rand = new Random();
            object randLock = new object();

            int numberOfTasksWhichHitClientError = 0;
            int numberOfTasksWhichWereForcedToRetry = 0;

            Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandlerFunc = (result, token) =>
            {
                this.testOutputHelper.WriteLine("Task: {0} got status code: {1}", result.TaskId, result.Status);
                AddTaskResultStatus resultAction;

                if (result.Status == AddTaskStatus.ClientError)
                {
                    ++numberOfTasksWhichHitClientError;
                    return AddTaskResultStatus.Success; //Have to count client error as success
                }

                lock (randLock)
                {
                    double d = rand.NextDouble();

                    if (d > 0.8)
                    {
                        this.testOutputHelper.WriteLine("Forcing retry for task: {0}", result.TaskId);

                        resultAction = AddTaskResultStatus.Retry;
                        ++numberOfTasksWhichWereForcedToRetry;
                    }
                    else
                    {
                        resultAction = AddTaskResultStatus.Success;
                    }
                }

                return resultAction;
            };

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                StagingStorageAccount storageCredentials = TestUtilities.GetStorageCredentialsFromEnvironment();
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                    {
                        MaxDegreeOfParallelism = 2
                    };

                    await this.AddTasksSimpleTestAsync(
                        batchCli,
                        testName,
                        1281,
                        parallelOptions,
                        resultHandlerFunc,
                        storageCredentials,
                        new List<string> { "TestResources\\Data.txt" },
                        useJobOperations: useJobOperations).ConfigureAwait(false);
                }
            },
            LongTestTimeout);

            //Ensure that we forced some tasks to retry
            this.testOutputHelper.WriteLine("Forced a total of {0} tasks to retry", numberOfTasksWhichWereForcedToRetry);

            Assert.True(numberOfTasksWhichWereForcedToRetry > 0);
            Assert.Equal(numberOfTasksWhichWereForcedToRetry, numberOfTasksWhichHitClientError);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task Bug1360227_AddTasksBatchRequestFailure(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchRequestFailure";

            Random rand = new Random();
            object randLock = new object();

            BatchClientBehavior customBehavior = new Protocol.RequestInterceptor(request =>
            {
                var typedRequest = request as Protocol.BatchRequests.TaskAddCollectionBatchRequest;

                if (typedRequest != null)
                {
                    var originalServiceRequestFunction = typedRequest.ServiceRequestFunc;

                    typedRequest.ServiceRequestFunc = token =>
                        {
                            lock (randLock)
                            {
                                double d = rand.NextDouble();
                                if (d > 0.3)
                                {
                                    throw new HttpRequestException("Simulating a network problem");
                                }
                                else
                                {
                                    return originalServiceRequestFunction(token);
                                }
                            }
                        };
                }
            });

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                {
                    batchCli.JobOperations.CustomBehaviors.Add(customBehavior);

                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                    {
                        MaxDegreeOfParallelism = 2
                    };

                    var exception = await TestUtilities.AssertThrowsAsync<ParallelOperationsException>(async () => 
                        await this.AddTasksSimpleTestAsync(batchCli, testName, 397, parallelOptions, useJobOperations: useJobOperations).ConfigureAwait(false)
                        ).ConfigureAwait(false);

                    Assert.IsType<HttpRequestException>(exception.InnerException);
                }
            },
            TestTimeout);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task Bug1360227_AddTasksBatchCancelation(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchCancelation";

            const int taskCount = 322;

            await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                    {
                        using (CancellationTokenSource source = new CancellationTokenSource())
                        {
                            BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                                {
                                    MaxDegreeOfParallelism = 2,
                                    CancellationToken = source.Token
                                };

                            System.Threading.Tasks.Task t = this.AddTasksSimpleTestAsync(
                                batchCli,
                                testName,
                                taskCount,
                                parallelOptions,
                                useJobOperations: useJobOperations);
                            Thread.Sleep(TimeSpan.FromSeconds(.3)); //Wait till we get into the workflow
                            this.testOutputHelper.WriteLine("Canceling the work flow");

                            source.Cancel();

                            try
                            {
                                await t.ConfigureAwait(false);
                            }
                            catch (Exception e)
                            {
                                //This is expected to throw one of two possible exception types...
                                if (!(e is TaskCanceledException) && !(e is OperationCanceledException))
                                {
                                    throw new ThrowsException(typeof (TaskCanceledException), e);
                                }
                            }

                        }
                    }
                },
                TestTimeout);
        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task Bug1360227_AddTasksBatchWithFilesToStage(bool useJobOperations)
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

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task Bug1360227_AddTasksBatchConfirmResultHandlerTaskReadOnly()
        {
            const string testName = "Bug1360227_ConfirmResultHandlerTaskReadOnly";

            Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandlerFunc = (result, token) =>
            {
                //Count everything as a success
                AddTaskResultStatus resultAction = AddTaskResultStatus.Success;

                //Try to set a property of the cloud task
                InvalidOperationException e = TestUtilities.AssertThrows<InvalidOperationException>(() => 
                    result.Task.Constraints = new TaskConstraints(TimeSpan.FromSeconds(5), null, null));

                Assert.Contains("Write access is not allowed.", e.Message);

                //Try to call a method of a CloudTask
                //TODO: This should be blocked but isn't right now...
                //try
                //{
                //    result.Task.Terminate();
                //    Debug.Fail("Should not have gotten here");
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    //Swallow this exception as it is expected
                //}

                return resultAction;
            };

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                    {
                        MaxDegreeOfParallelism = 2
                    };

                    await this.AddTasksSimpleTestAsync(
                        batchCli,
                        testName,
                        55,
                        parallelOptions,
                        resultHandlerFunc).ConfigureAwait(false);
                }
            },
            TestTimeout);

        }

        [Theory, InlineData(false), InlineData(true)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task Bug1360227_AddTasksBatchTimeout(bool useJobOperations)
        {
            const string testName = "Bug1360227_AddTasksBatchTimeout";

            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    var exception = await TestUtilities.AssertThrowsAsync<ParallelOperationsException>(
                        async () => await this.AddTasksSimpleTestAsync(
                            batchCli,
                            testName,
                            311,
                            timeout: TimeSpan.FromSeconds(1),
                            useJobOperations: useJobOperations).ConfigureAwait(false)).ConfigureAwait(false);

                    Assert.IsType<TimeoutException>(exception.InnerException);
                }
            },
            TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task AddTasksFailIfPoisonTaskTooLarge()
        {
            const string testName = "AddTasksFailIfPoisonTaskTooLarge";
            List<ResourceFile> resourceFiles = new List<ResourceFile>();
            ResourceFile resourceFile;
            // If this test fails try increasing the size of the Task in case maximum size increase
            for (int i = 0; i < 10000; i++)
            {
                resourceFile = new ResourceFile("https://mystorageaccount.blob.core.windows.net/files/resourceFile" + i, "resourceFile" + i);
                resourceFiles.Add(resourceFile);
            }
            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    var exception = await TestUtilities.AssertThrowsAsync<ParallelOperationsException>(
                        async () => await this.AddTasksSimpleTestAsync(batchCli, testName, 1, resourceFiles:resourceFiles).ConfigureAwait(false)).ConfigureAwait(false);
                    var innerException = exception.InnerException;
                    Assert.IsType<BatchException>(innerException);
                    Assert.Equal(((BatchException) innerException).RequestInformation.BatchError.Code, BatchErrorCodeStrings.RequestBodyTooLarge);
                }
            },
            TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task AddTasksRequestEntityTooLarge_ReduceChunkSize()
        {
            const string testName = "AddTasksRequestEntityTooLarge_ReduceChunkSize";
            List<ResourceFile> resourceFiles = new List<ResourceFile>();
            ResourceFile resourceFile;
            int countChunksOf100 = 0;
            int numTasks = 176;
            int degreesOfParallelism = 2;
            BatchClientBehavior customBehavior = new Protocol.RequestInterceptor(request =>
            {
                var typedRequest = request as Protocol.BatchRequests.TaskAddCollectionBatchRequest;
                if (typedRequest != null)
                {
                    if(typedRequest.Parameters.Count > 50)
                    {
                        Interlocked.Increment(ref countChunksOf100);
                    }
                }
            });

            // If this test fails try increasing the size of the Task in case maximum size increase
            for (int i = 0; i < 100; i++)
            {
                resourceFile = new ResourceFile("https://mystorageaccount.blob.core.windows.net/files/resourceFile" + i, "resourceFile" + i);
                resourceFiles.Add(resourceFile);
            }
            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                {
                    batchCli.JobOperations.CustomBehaviors.Add(customBehavior);
                    BatchClientParallelOptions parallelOptions = new BatchClientParallelOptions()
                    {
                        MaxDegreeOfParallelism = degreesOfParallelism
                    };
                    await AddTasksSimpleTestAsync(batchCli, testName, numTasks, parallelOptions, resourceFiles: resourceFiles).ConfigureAwait(false);
                }
            },
            TestTimeout);
            Assert.True(countChunksOf100 <= Math.Min(Math.Ceiling(numTasks/100.0), degreesOfParallelism));
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
            BatchClientParallelOptions parallelOptions = null,
            Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandlerFunc = null,
            StagingStorageAccount storageCredentials = null,
            IEnumerable<string> localFilesToStage = null,
            ConcurrentBag<ConcurrentDictionary<Type, IFileStagingArtifact>> fileStagingArtifacts = null,
            TimeSpan? timeout = null,
            bool useJobOperations = true,
            List<ResourceFile> resourceFiles = null)
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
                    myTask.ResourceFiles = resourceFiles;
                    duplicateReadableTask.ResourceFiles = resourceFiles;

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
