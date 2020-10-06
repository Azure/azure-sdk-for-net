// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using TestResources;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Constants = Microsoft.Azure.Batch.Constants;

    [Collection("SharedPoolCollection")]
    public class EndToEndIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);
        
        public EndToEndIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        /// <summary>
        /// Uses an unbound Job to demonstrate
        ///     1: File Staging (local files are automatically stored in Blobs as part of Commit())
        ///     2: Use of already-existing-SAS  (when data are pre-staged into Blobs and a SAS is "known")
        /// </summary>
        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestSampleWithFilesAndPool()
        {
            Action test = () =>
            {
                StagingStorageAccount storageCreds = TestUtilities.GetStorageCredentialsFromEnvironment();

                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    string jobId = "SampleWithFilesJob-" + TestUtilities.GetMyName();


                    try
                    {
                        CloudJob quickJob = batchCli.JobOperations.CreateJob();
                        quickJob.Id = jobId;
                        quickJob.PoolInformation = new PoolInformation() { PoolId = this.poolFixture.PoolId };
                        quickJob.Commit();
                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        CloudTask myTask = new CloudTask(id: "CountWordsTask", commandline: @"cmd /c dir /s .. & dir & wc localwords.txt");

                        // first we have local files that we want pushed to the compute node before the commandline is invoked
                        FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, storageCreds);                // use "default" mapping to base name of local file

                        myTask.FilesToStage = new List<IFileStagingProvider>();

                        myTask.FilesToStage.Add(wordsDotText);

                        // add the task to the job
                        var artifacts = boundJob.AddTask(myTask);
                        var specificArtifact = artifacts[typeof(FileToStage)];
                        SequentialFileStagingArtifact sfsa = specificArtifact as SequentialFileStagingArtifact;

                        Assert.NotNull(sfsa);

                        // add a million more tasks...

                        // test to ensure the task is read only
                        TestUtilities.AssertThrows<InvalidOperationException>(() => myTask.FilesToStage = new List<IFileStagingProvider>());
                        
                        // Open the new Job as bound.
                        CloudPool boundPool = batchCli.PoolOperations.GetPool(boundJob.ExecutionInformation.PoolId);

                        // wait for the task to complete
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(10),
                            controlParams: null,
                            additionalBehaviors:
                                new[]
                        {
                            // spam/logging interceptor
                            new Microsoft.Azure.Batch.Protocol.RequestInterceptor((x) =>
                            {
                                this.testOutputHelper.WriteLine("Issuing request type: " + x.GetType().ToString());

                                try
                                {
                                    // print out the compute node states... we are actually waiting on the compute nodes
                                    List<ComputeNode> allComputeNodes = boundPool.ListComputeNodes().ToList();

                                    this.testOutputHelper.WriteLine("    #compute nodes: " + allComputeNodes.Count);

                                    allComputeNodes.ForEach(
                                        (icn) =>
                                        {
                                            this.testOutputHelper.WriteLine("  computeNode.id: " + icn.Id + ", state: " + icn.State);
                                        });
                                }
                                catch (Exception ex)
                                {
                                    // there is a race between the pool-life-job and the end of the job.. and the ListComputeNodes above
                                    Assert.True(false, "SampleWithFilesAndPool probably can ignore this if its pool not found: " + ex.ToString());
                                }
                            })
                        });
                        
                        List<CloudTask> tasks = boundJob.ListTasks(null).ToList();
                        CloudTask myCompletedTask = tasks[0];

                        foreach (CloudTask curTask in tasks)
                        {
                            this.testOutputHelper.WriteLine("Task Id: " + curTask.Id + ", state: " + curTask.State);
                        }

                        boundPool.Refresh();

                        this.testOutputHelper.WriteLine("Pool Id: " + boundPool.Id + ", state: " + boundPool.State);

                        string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                        string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                        this.testOutputHelper.WriteLine("StdOut: ");
                        this.testOutputHelper.WriteLine(stdOut);

                        this.testOutputHelper.WriteLine("StdErr: ");
                        this.testOutputHelper.WriteLine(stdErr);

                        this.testOutputHelper.WriteLine("Task Files:");

                        foreach (NodeFile curFile in myCompletedTask.ListNodeFiles(recursive: true))
                        {
                            this.testOutputHelper.WriteLine("    FilePath: " + curFile.Path);
                        }

                        // confirm the files are there
                        Assert.True(FoundFile("localwords.txt", myCompletedTask.ListNodeFiles(recursive: true)), "mising file: localwords.txt");

                        // test validation of StagingStorageAccount

                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: " ", storageAccountKey: "key", blobEndpoint: "blob"); });
                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: "account", storageAccountKey: " ", blobEndpoint: "blob"); });
                        TestUtilities.AssertThrows<ArgumentOutOfRangeException>(() => { new StagingStorageAccount(storageAccount: "account", storageAccountKey: "key", blobEndpoint: ""); });

                        if (null != sfsa)
                        {
                            // TODO: delete the container!
                        }
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void HelloWorld()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    TestUtilities.HelloWorld(batchCli, this.testOutputHelper, this.poolFixture.Pool, out string job, out string task);
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        #region Test helpers

        private static bool FoundFile(string fileName, IEnumerable<NodeFile> files)
        {
            // look to see if the file is in the list
            foreach (NodeFile curFile in files)
            {
                if (curFile.Path.IndexOf(fileName, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

    }

    public class IntegrationEndToEndTestsWithoutSharedPool
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public IntegrationEndToEndTestsWithoutSharedPool(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1965363_2384616_Wat7OSVersionFeatures()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    PoolOperations poolOperations = batchCli.PoolOperations;
                    try
                    {
                        this.testOutputHelper.WriteLine("Listing OS Versions:");

                        // create pool tests

                        // forget to set CloudServiceConfiguration on Create, get error
                        {
                            CloudPool noArgs = poolOperations.CreatePool("Bug1965363ButNoOSFamily-" + TestUtilities.GetMyName(), PoolFixture.VMSize, default(CloudServiceConfiguration), targetDedicatedComputeNodes: 0);

                            BatchException ex = TestUtilities.AssertThrows<BatchException>(() => noArgs.Commit());
                            string exStr = ex.ToString();

                            // we are expecting an exception, assert if the exception is not the correct one.
                            Assert.Contains("cloudServiceConfiguration", exStr);
                        }

                        // create a pool WITH an osFamily
                        {
                            string poolIdHOSF = "Bug1965363HasOSF-" + TestUtilities.GetMyName();
                            try
                            {
                                CloudPool hasOSF = poolOperations.CreatePool(poolIdHOSF, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);

                                hasOSF.Commit();
                            }
                            finally
                            {
                                poolOperations.DeletePool(poolIdHOSF);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // special case os version beacuse it is a common failure and requires human intervention/editing
                        // test for expired os version
                        Assert.DoesNotContain("The specified OS Version does not exists", ex.ToString());

                        throw;
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1771070_1771072_JobAndPoolLifetimeStats()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    JobStatistics jobStatistics = batchCli.JobOperations.GetAllLifetimeStatistics();
                    PoolStatistics poolStatistics = batchCli.PoolOperations.GetAllLifetimeStatistics();

                    Assert.NotNull(jobStatistics);
                    Assert.NotNull(poolStatistics);

                    //Since we cannot really validate that the stats returned by the service are correct, the best we can do is make sure we get some

                    //Dump a few properties from each stats bag to make sure they are populated
                    this.testOutputHelper.WriteLine("JobScheduleStatistics.StartTime: {0}", jobStatistics.StartTime);
                    this.testOutputHelper.WriteLine("JobScheduleStatistics.LastUpdateTime: {0}", jobStatistics.LastUpdateTime);
                    this.testOutputHelper.WriteLine("JobScheduleStatistics.NumSucceededTasks: {0}", jobStatistics.SucceededTaskCount);
                    this.testOutputHelper.WriteLine("JobScheduleStatistics.UserCpuTime: {0}", jobStatistics.UserCpuTime);

                    this.testOutputHelper.WriteLine("PoolStatistics.StartTime: {0}", poolStatistics.StartTime);
                    this.testOutputHelper.WriteLine("PoolStatistics.LastUpdateTime: {0}", poolStatistics.LastUpdateTime);
                    this.testOutputHelper.WriteLine("PoolStatistics.ResourceStatistics.AvgMemory: {0}", poolStatistics.ResourceStatistics.AverageMemoryGiB);
                    this.testOutputHelper.WriteLine("PoolStatistics.UsageStatistics.DedicatedCoreTime: {0}", poolStatistics.UsageStatistics.DedicatedCoreTime);
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void ReadClientRequestIdAndRequestIdFromResponse()
        {
            Action test = () =>
                {
                    using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                    {
                        string requestId = null;
                        //Set up an interceptor to read RequestId from all responses
                        Microsoft.Azure.Batch.Protocol.ResponseInterceptor responseInterceptor = new ResponseInterceptor(
                            (response, request) =>
                                {
                                    requestId = response.RequestId;
                                    return Task.FromResult(response);
                                });

                        batchCli.PoolOperations.ListPools(additionalBehaviors: new[] { responseInterceptor} ).ToList(); //Force an enumeration to go to the server

                        Assert.NotNull(requestId);
                    }
                };


            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void ReadClientRequestIdAndRequestIdFromException()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment()))
                {
                    Guid myClientRequestid = Guid.NewGuid();
                    Microsoft.Azure.Batch.Protocol.RequestInterceptor clientRequestIdGenerator = new ClientRequestIdProvider(
                        request => myClientRequestid);

                    Microsoft.Azure.Batch.Protocol.RequestInterceptor setReturnClientRequestId = new RequestInterceptor(
                        request =>
                            {
                                request.Options.ReturnClientRequestId = true;
                            });

                    BatchException batchException = TestUtilities.AssertThrowsAsync<BatchException>(async () =>
                        await batchCli.JobOperations.GetJobAsync("this-job-doesnt-exist", additionalBehaviors: new [] { clientRequestIdGenerator, setReturnClientRequestId })).Result;

                    Assert.NotNull(batchException.RequestInformation);
                    Assert.NotNull(batchException.RequestInformation.BatchError);
                    Assert.NotNull(batchException.RequestInformation.BatchError.Message);

                    Assert.Equal(BatchErrorCodeStrings.JobNotFound, batchException.RequestInformation.BatchError.Code);
                    Assert.Equal(HttpStatusCode.NotFound, batchException.RequestInformation.HttpStatusCode);
                    Assert.Contains("The specified job does not exist", batchException.RequestInformation.BatchError.Message.Value);

                    Assert.Equal(myClientRequestid, batchException.RequestInformation.ClientRequestId);
                    Assert.NotNull(batchException.RequestInformation.ServiceRequestId);
                    Assert.Equal("The specified job does not exist.", batchException.RequestInformation.HttpStatusMessage);
                }
            };


            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
