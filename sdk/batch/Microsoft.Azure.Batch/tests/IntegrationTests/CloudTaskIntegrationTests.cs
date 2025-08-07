// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using TestResources;
    using IntegrationTestUtilities;
    using Xunit;
    using Xunit.Abstractions;
    using Constants = Microsoft.Azure.Batch.Constants;
    using System.Threading;
    using System.Diagnostics;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public class IntegrationMultiInstanceCloudTaskTests : IDisposable
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);
        private readonly string poolId;

        private CloudPool CreatePool(BatchClient batchClient, string poolToCreateId)
        {
            PoolOperations poolOp = batchClient.PoolOperations;

            // reuse existing pool if it exists
            List<CloudPool> pools = new List<CloudPool>(poolOp.ListPools());

            foreach (CloudPool curPool in pools)
            {
                if (curPool.Id.Equals(poolToCreateId))
                {
                    return curPool;
                }
            }

            var ubuntuImageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchClient);

            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(
                ubuntuImageDetails.ImageReference,
                nodeAgentSkuId: ubuntuImageDetails.NodeAgentSkuId);

            // gotta create a new pool
            CloudPool newPool = poolOp.CreatePool(
                poolId,
                PoolFixture.VMSize,
                virtualMachineConfiguration,
                targetDedicatedComputeNodes: 3);

            newPool.InterComputeNodeCommunicationEnabled = true;

            StartTask st = new StartTask("cmd /c set & MSMpiSetup.exe -unattend -force");

            // used for tests of StartTask(info)
            st.ResourceFiles = new List<ResourceFile> { ResourceFile.FromUrl("https://manoj123.blob.core.windows.net/mpi/MSMpiSetup.exe", "MSMpiSetup.exe") };  // TODO: remove the dependency on magic blob.  bring this into project and use filestaging or something
            st.UserIdentity = new UserIdentity(new AutoUserSpecification(elevationLevel: ElevationLevel.Admin));
            st.WaitForSuccess = true;
            newPool.StartTask = st;

            newPool.Commit();

            CloudPool thePool = poolOp.GetPool(poolToCreateId);

            //Wait for pool to be in a usable state
            TimeSpan computeNodeAllocationTimeout = TimeSpan.FromMinutes(10);

            TestUtilities.WaitForPoolToReachStateAsync(batchClient, poolToCreateId, AllocationState.Steady, computeNodeAllocationTimeout).Wait();

            //Wait for the compute nodes in the pool to be in a usable state
            //TODO: Use a Utilities waiter
            TimeSpan computeNodeSteadyTimeout = TimeSpan.FromMinutes(10);
            DateTime allocationWaitStartTime = DateTime.UtcNow;
            DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(computeNodeSteadyTimeout);

            IEnumerable<ComputeNode> computeNodes = thePool.ListComputeNodes();

            while (computeNodes.Any(computeNode => computeNode.State != ComputeNodeState.Idle))
            {
                //Console.WriteLine("At least one compute node is not idle...");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                computeNodes = thePool.ListComputeNodes().ToList();
                if (DateTime.UtcNow > timeoutAfterThisTimeUtc)
                {
                    throw new Exception("Timed out waiting for compute nodes in pool to reach idle state");
                }
            }

            return thePool;
        }

        public IntegrationMultiInstanceCloudTaskTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            poolId = TestUtilities.GetMyName() + "-poolmulti";
            using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
            CreatePool(batchCli, poolId); //TODO: If this is failed to construct then the dispose is not called
        }

        public void Dispose()
        {
            using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
            // the original shared pool is not deleted and we leave this one too to speed debugging and re-run
            //TestUtilities.DeletePoolIfExistsAsync(batchCli, this.poolId).Wait();
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void BasicMultiInstanceTasks()
        {
            TimeSpan checkSubtasksStateTimeout = TimeSpan.FromMinutes(1);

            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string jobId = "MultiInstance-" + TestUtilities.GetMyName();

                try
                {
                    // here we show how to use an unbound Job + Commit() to run a simple "Hello World" task
                    // get an empty unbound Job
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolId });
                    unboundJob.Commit();

                    // Open the new Job as bound.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    // get an empty unbound Task
                    CloudTask hwTask = new CloudTask(id: "multi1", commandline: "hostname");
                    hwTask.MultiInstanceSettings = new MultiInstanceSettings("cmd /c set", numberOfInstances: 3);

                    // add Task to Job
                    boundJob.AddTask(hwTask);

                    {
                        // wait for the task to complete
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(3));

                        CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks())[0];

                        Assert.Equal(TaskState.Completed, myCompletedTask.State);

                        Assert.NotNull(myCompletedTask.MultiInstanceSettings);
                        Assert.Equal(3, myCompletedTask.MultiInstanceSettings.NumberOfInstances);
                        Assert.Equal("cmd /c set", myCompletedTask.MultiInstanceSettings.CoordinationCommandLine);

                        string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                        string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                        testOutputHelper.WriteLine("StdOut: ");
                        testOutputHelper.WriteLine("");
                        testOutputHelper.WriteLine(stdOut);
                        testOutputHelper.WriteLine("");

                        testOutputHelper.WriteLine("StdErr: ");
                        testOutputHelper.WriteLine(stdErr);
                        testOutputHelper.WriteLine("");


                        List<SubtaskInformation> subtasks;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        do
                        {
                            IPagedEnumerable<SubtaskInformation> results = myCompletedTask.ListSubtasks();

                            subtasks = results.ToList();
                            if (subtasks.All(t => t.State == SubtaskState.Completed))
                            {
                                break;
                            }
                            Thread.Sleep(500);
                        } while (sw.Elapsed <= checkSubtasksStateTimeout);

                        Assert.True(sw.Elapsed <= checkSubtasksStateTimeout, string.Format("The subtasks state is not set to Complete after {0} seconds", checkSubtasksStateTimeout.TotalSeconds));
                        Assert.Equal(2, subtasks.Count);
                        Assert.Equal(0, subtasks[0].ExitCode);
                        Assert.Null(subtasks[0].FailureInformation);
                        Assert.Equal(0, subtasks[1].ExitCode);
                        Assert.Null(subtasks[1].FailureInformation);
                        // Shouldnot assume the subtasks have order.
                        Assert.True((subtasks[0].Id == 1 && subtasks[1].Id == 2) || (subtasks[0].Id == 2 && subtasks[1].Id == 1));

                        testOutputHelper.WriteLine("Multi-instance test complete");
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void RealMpiTasks()
        {
            TimeSpan checkSubtasksStateTimeout = TimeSpan.FromMinutes(1);

            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string jobId = "MPI-" + TestUtilities.GetMyName();

                try
                {
                    // here we show how to use an unbound Job + Commit() to run a simple "Hello World" task
                    // get an empty unbound Job
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolId });
                    unboundJob.Commit();

                    // Open the new Job as bound.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    // get an empty unbound Task
                    CloudTask hwTask = new CloudTask(id: "mpi", commandline: @"cmd /c ""%MSMPI_BIN%\mpiexec.exe"" -p 6050 -wdir %AZ_BATCH_TASK_SHARED_DIR%\ Sieve.exe 1000");
                    hwTask.MultiInstanceSettings = new MultiInstanceSettings(@"cmd /c start cmd /c ""%MSMPI_BIN%\smpd.exe"" -d 3 -p 6050", 3);
                    hwTask.MultiInstanceSettings.CommonResourceFiles = new List<ResourceFile>
                        {
                            ResourceFile.FromUrl("https://manoj123.blob.core.windows.net/mpi/Sieve.exe", "Sieve.exe")
                        };

                    // add Task to Job
                    boundJob.AddTask(hwTask);

                    {
                        // wait for the task to complete
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(3));

                        CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks()).Single();

                        string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                        string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                        testOutputHelper.WriteLine("StdOut: ");
                        testOutputHelper.WriteLine("");
                        testOutputHelper.WriteLine(stdOut);
                        testOutputHelper.WriteLine("");

                        testOutputHelper.WriteLine("StdErr: ");
                        testOutputHelper.WriteLine(stdErr);
                        testOutputHelper.WriteLine("");

                        Assert.Contains("There are 168 primes less than or equal to 1000", stdOut);

                        List<SubtaskInformation> subtasks;
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        do
                        {
                            IPagedEnumerable<SubtaskInformation> results = batchCli.JobOperations.ListSubtasks(jobId, myCompletedTask.Id);

                            subtasks = results.ToList();
                            if (subtasks.All(t => t.State == SubtaskState.Completed))
                            {
                                break;
                            }
                            Thread.Sleep(500);
                        } while (sw.Elapsed <= checkSubtasksStateTimeout);

                        Assert.True(sw.Elapsed <= checkSubtasksStateTimeout, string.Format("The subtasks state is not set to Complete after {0} seconds", checkSubtasksStateTimeout.TotalSeconds));

                        testOutputHelper.WriteLine("MPI test complete");
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }

    [Collection("SharedPoolCollection")]
    public class CloudTaskIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public CloudTaskIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1432830TaskEnvSettings()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1432830Job-" + TestUtilities.GetMyName();

                try
                {
                    // remember how many env settings we create
                    int numEnvSettings = 0;

                    // here we show how to use an unbound Job + Commit() to run a simple "Hello World" task
                    // get an empty unbound Job
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    unboundJob.Commit();

                    // Open the new Job as bound.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    // get an empty unbound Task
                    CloudTask hwTask = new CloudTask(id: "dwsHelloWorldTask", commandline: "cmd /c echo Hello World");

                    // get settings off of unbound task to confirm null
                    IEnumerable<EnvironmentSetting> envSettings = hwTask.EnvironmentSettings;

                    // unbound task should have null for env settings
                    Assert.Null(envSettings);

                    // construct sample settings to test feature
                    List<EnvironmentSetting> newEnvSettings = new List<EnvironmentSetting>();
                    EnvironmentSetting myES = new EnvironmentSetting("bug1432830EnvName", "bug1432830EnvValue");

                    newEnvSettings.Add(myES);

                    // remember how many we create
                    numEnvSettings = newEnvSettings.Count;

                    // set the env settings
                    hwTask.EnvironmentSettings = newEnvSettings;

                    // add Task to Job
                    boundJob.AddTask(hwTask);

                    {
                        // wait for the task to complete
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                        taskStateMonitor.WaitAll(
                            boundJob.ListTasks(),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(3));

                        CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks())[0];

                        string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                        string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                        testOutputHelper.WriteLine("StdOut: ");
                        testOutputHelper.WriteLine("");
                        testOutputHelper.WriteLine(stdOut);
                        testOutputHelper.WriteLine("");

                        testOutputHelper.WriteLine("StdErr: ");
                        testOutputHelper.WriteLine(stdErr);
                        testOutputHelper.WriteLine("");

                        // get env settings
                        IEnumerable<EnvironmentSetting> boundSettings = myCompletedTask.EnvironmentSettings;

                        // we set above so there should be a collection
                        Assert.NotNull(boundSettings);

                        List<EnvironmentSetting> compEnvSettings = new List<EnvironmentSetting>(boundSettings);

                        // confirm #
                        Assert.Equal(numEnvSettings, compEnvSettings.Count);

                        testOutputHelper.WriteLine("Environement Settings: ");

                        foreach (EnvironmentSetting curEnvSetting in boundSettings)
                        {
                            testOutputHelper.WriteLine("    Name: " + curEnvSetting.Name + ", Value: " + curEnvSetting.Value);
                        }

                        testOutputHelper.WriteLine("Env Setting test complete");
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1432973TaskAffinityInfoMissing()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1432973Job-" + TestUtilities.GetMyName();

                try
                {
                    CloudJob createJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    createJob.CommitAsync().Wait();

                    const string unboundTaskId = "bug1432973AffinityInfo";
                    CloudTask unboundTask = new CloudTask(unboundTaskId, "hostname");

                    const string referenceAffinityId = "bug1432973AffinityInfoHintHint";
                    AffinityInformation aff = new AffinityInformation(referenceAffinityId);

                    // confirm aff is settable on unbound
                    unboundTask.AffinityInformation = aff;

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    boundJob.AddTask(unboundTask);

                    CloudTask boundTask = batchCli.JobOperations.GetTask(jobId, unboundTaskId);

                    Assert.Equal(referenceAffinityId, boundTask.AffinityInformation.AffinityId);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1447214TaskMissingExeInfoStatsAndConstraints()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1447214Job-" + TestUtilities.GetMyName();

                try
                {
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    unboundJob.Commit();

                    // Open the new Job as bound.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    CloudTask myTask = new CloudTask(id: "Bug1447214Task", commandline: @"hostname");

                    TaskConstraints ts = new TaskConstraints(maxWallClockTime: TimeSpan.FromHours(1), retentionTime: TimeSpan.FromHours(1), maxTaskRetryCount: 99);

                    myTask.Constraints = ts;

                    // add the task to the job
                    boundJob.AddTask(myTask);

                    // wait for the task to complete
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(3));

                    CloudTask myCompletedTask = new List<CloudTask>(boundJob.ListTasks(null))[0];

                    string stdOut = myCompletedTask.GetNodeFile(Constants.StandardOutFileName).ReadAsString();
                    string stdErr = myCompletedTask.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                    testOutputHelper.WriteLine("TaskId: " + myCompletedTask.Id);
                    testOutputHelper.WriteLine("StdOut: ");
                    testOutputHelper.WriteLine(stdOut);
                    testOutputHelper.WriteLine("");

                    testOutputHelper.WriteLine("StdErr: ");
                    testOutputHelper.WriteLine(stdErr);
                    testOutputHelper.WriteLine("");

                    testOutputHelper.WriteLine("TaskConstraints:");

                    TaskConstraints compTC = myCompletedTask.Constraints;

                    Assert.NotNull(compTC);

                    if (null == compTC)
                    {
                        testOutputHelper.WriteLine("<null>");
                    }
                    else
                    {
                        testOutputHelper.WriteLine("");
                        testOutputHelper.WriteLine("    maxWallClockTime: " + (compTC.MaxWallClockTime.HasValue ? compTC.MaxWallClockTime.ToString() : "<null>"));
                        testOutputHelper.WriteLine("    retentionTime: " + (compTC.RetentionTime.HasValue ? compTC.RetentionTime.Value.ToString() : "<null>"));
                        testOutputHelper.WriteLine("    maxTaskRetryCount: " + (compTC.MaxTaskRetryCount.HasValue ? compTC.MaxTaskRetryCount.Value.ToString() : "<null>"));

                        Assert.True(compTC.MaxTaskRetryCount.HasValue);
                        Assert.Equal(99, compTC.MaxTaskRetryCount.Value);
                    }

                    testOutputHelper.WriteLine("TaskExecutionInfo: ");

                    TaskExecutionInformation tei = myCompletedTask.ExecutionInformation;

                    Assert.NotNull(tei);

                    if (null == tei)
                    {
                        testOutputHelper.WriteLine("<null>");
                    }
                    else
                    {
                        testOutputHelper.WriteLine("");
                        testOutputHelper.WriteLine("    StartTime: " + (tei.StartTime.HasValue ? tei.StartTime.Value.ToString() : "<null>"));
                        testOutputHelper.WriteLine("    LastUpdateTime:   " + (tei.EndTime.HasValue ? tei.EndTime.Value.ToString() : "<null>"));
                        testOutputHelper.WriteLine("    ExitCode:  " + (tei.ExitCode.HasValue ? tei.ExitCode.Value.ToString() : "<null>"));
                    }

                    testOutputHelper.WriteLine("Stats: ");

                    TaskStatistics compTS = myCompletedTask.Statistics;

                    if (null == compTS)
                    {
                        testOutputHelper.WriteLine("<null>");
                    }
                    else
                    {
                        testOutputHelper.WriteLine("Url: " + compTS.Url);
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1535329JobOperationsMissingAddTaskMethods()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                StagingStorageAccount stagingStorageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();

                string jobId = "Bug1535329Job-" + TestUtilities.GetMyName();

                try
                {
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    unboundJob.Commit();

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                    CloudTask unboundTask = new CloudTask(id: "bug1535329Task0", commandline: "hostname");

                    boundJob.AddTask(unboundTask);

                    CloudTask newTaskToAdd = new CloudTask(id: "bug1535329NewTask", commandline: "hostname");

                    // add some files to confirm file staging is working
                    FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, stagingStorageAccount);

                    newTaskToAdd.FilesToStage = new List<IFileStagingProvider> { wordsDotText };

                    batchCli.JobOperations.AddTask(jobId, newTaskToAdd);

                    bool foundLocalWords = false;

                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(5));

                    foreach (CloudTask curTask in boundJob.ListTasks())
                    {
                        testOutputHelper.WriteLine("TaskId: " + curTask.Id);

                        foreach (NodeFile curFile in curTask.ListNodeFiles(recursive: true))
                        {
                            testOutputHelper.WriteLine("    filename: " + curFile.Path);

                            if (curFile.Path.IndexOf("localWords.txt", StringComparison.InvariantCultureIgnoreCase) >= 0)
                            {
                                Assert.False(foundLocalWords);
                                foundLocalWords = true;
                            }
                        }
                    }

                    Assert.True(foundLocalWords);
                }
                finally
                {
                    // clean up
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1611592ComputeNodeInfoMissingOnTask()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug1611592Job-" + TestUtilities.GetMyName();
                try
                {
                    CloudJob unJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    unJob.Commit();

                    CloudTask unTask = new CloudTask("Bug1611592", "hostname");
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { var f = unTask.ComputeNodeInformation; });

                    CloudJob bndJob = batchCli.JobOperations.GetJob(jobId);

                    bndJob.AddTask(unTask);

                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        bndJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        TimeSpan.FromMinutes(5));

                    foreach (CloudTask curTask in bndJob.ListTasks())
                    {
                        ComputeNodeInformation computeNodeInfo = curTask.ComputeNodeInformation;

                        Assert.NotNull(computeNodeInfo);

                        testOutputHelper.WriteLine("Task: " + curTask.Id);
                        testOutputHelper.WriteLine("ComputeNodeInfo:");

                        testOutputHelper.WriteLine("    PoolId: " + computeNodeInfo.PoolId);
                        testOutputHelper.WriteLine("    ComputeNodeId: " + computeNodeInfo.ComputeNodeId);
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestBoundTaskTerminateAndDelete()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-TestBoundTaskTerminateAndDelete";

                try
                {
                    //Create the job
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    cloudJob.PoolInformation = new PoolInformation()
                    {
                        PoolId = poolFixture.PoolId
                    };
                    testOutputHelper.WriteLine("Creating job: {0}", jobId);
                    cloudJob.Commit();

                    {
                        //Create a task
                        const string taskId = "T1";
                        CloudTask taskToAdd = new CloudTask(taskId, "ping 127.0.0.1 -n 60"); //Task which runs for 60s

                        //Add the task
                        testOutputHelper.WriteLine("Adding task: {0}", taskId);
                        batchCli.JobOperations.AddTask(jobId, taskToAdd);

                        //Wait for the task to go to running state
                        List<CloudTask> tasks = batchCli.JobOperations.ListTasks(jobId).ToList();

                        Assert.Single(tasks);

                        //Check that the task is running
                        TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();

                        //Wait for the task state to be running
                        taskStateMonitor.WaitAll(
                            tasks,
                            TaskState.Running,
                            TimeSpan.FromSeconds(30),
                            new ODATAMonitorControl { DelayBetweenDataFetch = TimeSpan.FromSeconds(5) });

                        //Terminate the running task
                        testOutputHelper.WriteLine("Terminating task {0}", taskId);
                        CloudTask runningTask = batchCli.JobOperations.GetTask(jobId, taskId);
                        runningTask.Terminate();

                        //Check task state
                        runningTask.Refresh();

                        Assert.Equal(TaskState.Completed, runningTask.State);

                        runningTask.Refresh();

                        //Delete the task
                        testOutputHelper.WriteLine("Deleting task {0}", taskId);
                        runningTask.Delete();

                        List<CloudTask> taskListAfterDelete = batchCli.JobOperations.ListTasks(jobId).ToList();

                        Assert.Empty(taskListAfterDelete);
                    }

                    {
                        //Create a task
                        const string taskId = "T2";
                        CloudTask taskToAdd = new CloudTask(taskId, "ping 127.0.0.1 -n 60"); //Task which runs for 60s

                        //Add the task
                        testOutputHelper.WriteLine("Adding task: {0}", taskId);
                        batchCli.JobOperations.AddTask(jobId, taskToAdd);

                        //Wait for the task to go to running state
                        List<CloudTask> tasks = batchCli.JobOperations.ListTasks(jobId).ToList();

                        Assert.Single(tasks);

                        //Check that the task is running
                        TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();

                        //Wait for the task state to be running

                        taskStateMonitor.WaitAll(
                            tasks,
                            TaskState.Running,
                            TimeSpan.FromSeconds(30),
                            new ODATAMonitorControl { DelayBetweenDataFetch = TimeSpan.FromSeconds(5) });

                        //Terminate the running task
                        testOutputHelper.WriteLine("Terminating task {0}", taskId);
                        CloudTask runningTask = batchCli.JobOperations.GetTask(jobId, taskId);
                        batchCli.JobOperations.TerminateTask(jobId, taskId);

                        //Check task state
                        runningTask.Refresh();

                        Assert.Equal(TaskState.Completed, runningTask.State);

                        runningTask.Refresh();

                        //Delete the task
                        testOutputHelper.WriteLine("Deleting task {0}", taskId);
                        runningTask.Delete();

                        List<CloudTask> taskListAfterDelete = batchCli.JobOperations.ListTasks(jobId).ToList();

                        Assert.Empty(taskListAfterDelete);
                    }
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void FailedTaskCanBeReactivated()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + Guid.NewGuid();

                try
                {
                    //Create the job
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    cloudJob.PoolInformation = new PoolInformation() { PoolId = poolFixture.PoolId };
                    testOutputHelper.WriteLine("Creating job: {0}", jobId);
                    cloudJob.Commit();

                    //Create a task
                    const string taskId = "T1";
                    CloudTask taskToAdd = new CloudTask(taskId, "cmd /c \"ping 127.0.0.1 -n 20 > nul && exit /b 3\"");

                    //Add the task
                    testOutputHelper.WriteLine("Adding task: {0}", taskId);
                    batchCli.JobOperations.AddTask(jobId, taskToAdd);

                    CloudTask task = batchCli.JobOperations.GetTask(jobId, taskId);
                    TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();

                    //Wait for the task state to complete 
                    taskStateMonitor.WaitAll(new[] { task }, TaskState.Completed, TimeSpan.FromMinutes(2));

                    task.Refresh();
                    Assert.Equal(3, task.ExecutionInformation.ExitCode);

                    // If you disable the job the tasks stay in the active state.
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    boundJob.Disable(DisableJobOption.Requeue);

                    //Reactivate failed task
                    task.Reactivate();
                    task.Refresh();
                    Assert.Equal(TaskState.Active, task.State);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void DependencyActionIsRoundTripped()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + Guid.NewGuid();

                try
                {
                    //Create the job
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    cloudJob.OnTaskFailure = OnTaskFailure.PerformExitOptionsJobAction;

                    cloudJob.UsesTaskDependencies = true;
                    cloudJob.Commit();

                    //Create a task
                    const string taskId = "T1";
                    CloudTask taskToAdd = new CloudTask(taskId, "cmd /c \"ping 127.0.0.1 \"");

                    //Add the task
                    testOutputHelper.WriteLine("Adding task: {0}", taskId);
                    taskToAdd.ExitConditions = new ExitConditions { Default = new ExitOptions { JobAction = JobAction.Terminate, DependencyAction = DependencyAction.Satisfy } };
                    batchCli.JobOperations.AddTask(jobId, taskToAdd);

                    CloudTask task = batchCli.JobOperations.GetTask(jobId, taskId);
                    TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();

                    //Wait for the task state to complete 
                    taskStateMonitor.WaitAll(new[] { task }, TaskState.Completed, TimeSpan.FromMinutes(2));

                    task.Refresh();
                    Assert.Equal(DependencyAction.Satisfy, task.ExitConditions.Default.DependencyAction);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }
            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void AccessScopeCanBeRoundTripped()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + Guid.NewGuid();
                try
                {
                    //Create the job
                    CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    cloudJob.PoolInformation = new PoolInformation { PoolId = poolFixture.PoolId };
                    testOutputHelper.WriteLine("Creating job: {0}", jobId);
                    cloudJob.Commit();

                    //Create a task
                    const string taskId = "T1";

                    CloudTask taskToAdd = new CloudTask(taskId, "cmd /c \"set\"")
                    {
                        DisplayName = "name",
                        AuthenticationTokenSettings = new AuthenticationTokenSettings { Access = AccessScope.Job }
                    };

                    batchCli.JobOperations.AddTask(jobId, taskToAdd);

                    CloudTask task = batchCli.JobOperations.GetTask(jobId, taskId);

                    Assert.Equal(AccessScope.Job, task.AuthenticationTokenSettings.Access);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1432996GetTaskOnJobOperationsAndJob()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = null;

                try
                {
                    TestUtilities.HelloWorld(batchCli, testOutputHelper, poolFixture.Pool, out jobId, out string taskId, false);

                    CloudJob job = batchCli.JobOperations.GetJob(jobId);

                    CloudTask viajobScheduleOperations = batchCli.JobOperations.GetTask(jobId, taskId);
                    CloudTask viaJob = job.GetTask(taskId);

                    Assert.Equal(viajobScheduleOperations.Id, viaJob.Id);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TaskRunsOnSharedUserAccount()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + Guid.NewGuid();
                const string adminTaskId = "adminTask";
                const string nonAdminTaskId = "nonAdminTask";
                try
                {
                    CloudJob job = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    job.Commit();

                    static CloudTask createTask(string taskId, string userName)
                    {
                        //The magic command below will succeed on an admin account but fail for a non-admin account
                        CloudTask task = new CloudTask(taskId, "cmd /c net session >nul 2>&1")
                        {
                            UserIdentity = new UserIdentity(userName)
                        };
                        return task;
                    }

                    var adminTask = createTask(adminTaskId, PoolFixture.AdminUserAccountName);
                    var nonAdminTask = createTask(nonAdminTaskId, PoolFixture.NonAdminUserAccountName);
                    batchCli.JobOperations.AddTask(jobId, new List<CloudTask> { adminTask, nonAdminTask });

                    var tasks = batchCli.JobOperations.ListTasks(jobId);

                    batchCli.Utilities.CreateTaskStateMonitor().WaitAll(tasks, TaskState.Completed, TimeSpan.FromMinutes(1));

                    var boundAdminTask = batchCli.JobOperations.GetTask(jobId, adminTaskId);
                    var boundNonAdminTask = batchCli.JobOperations.GetTask(jobId, nonAdminTaskId);

                    Assert.Equal(0, boundAdminTask.ExecutionInformation.ExitCode);
                    Assert.NotEqual(0, boundNonAdminTask.ExecutionInformation.ExitCode);

                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }

    public class IntegrationCloudTaskTestsWithoutSharedPool
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);

        public IntegrationCloudTaskTestsWithoutSharedPool(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void UpdateTask_TaskIsUpdatedAsExpected()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string taskId = "task1";

                string jobId = TestUtilities.GenerateResourceId();
                TaskConstraints defaultConstraints = new TaskConstraints(TimeSpan.MaxValue, TimeSpan.FromDays(7), 0);
                try
                {
                    //
                    // Create the job
                    //
                    CloudJob jobSchedule = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    jobSchedule.PoolInformation = new PoolInformation()
                    {
                        PoolId = "PoolWhoDoesntExist"
                    };

                    testOutputHelper.WriteLine("Initial job schedule commit()");
                    jobSchedule.Commit();

                    //Get the job
                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                    //Add the task
                    testOutputHelper.WriteLine("Adding task: {0}", taskId);
                    boundJob.AddTask(myTask);

                    //Get the task and check the constraints
                    CloudTask boundTask = batchCli.JobOperations.GetTask(jobId, taskId);

                    Assert.Equal(defaultConstraints.MaxTaskRetryCount, boundTask.Constraints.MaxTaskRetryCount);
                    Assert.Equal(defaultConstraints.MaxWallClockTime, boundTask.Constraints.MaxWallClockTime);
                    Assert.Equal(defaultConstraints.RetentionTime, boundTask.Constraints.RetentionTime);

                    TimeSpan maxWallClockTime = TimeSpan.FromHours(1);
                    TimeSpan dataRetentionTime = TimeSpan.FromHours(2);
                    const int maxRetryCount = 1;
                    boundTask.Constraints = new TaskConstraints(maxWallClockTime, dataRetentionTime, maxRetryCount);

                    testOutputHelper.WriteLine("Updating task constraints");

                    boundTask.Commit();

                    //Ensure the commit worked
                    boundTask.Refresh();

                    Assert.Equal(maxRetryCount, boundTask.Constraints.MaxTaskRetryCount);
                    Assert.Equal(maxWallClockTime, boundTask.Constraints.MaxWallClockTime);
                    Assert.Equal(dataRetentionTime, boundTask.Constraints.RetentionTime);

                    CloudTask freshTask = batchCli.JobOperations.GetTask(jobId, taskId);

                    Assert.Equal(maxRetryCount, freshTask.Constraints.MaxTaskRetryCount);
                    Assert.Equal(maxWallClockTime, freshTask.Constraints.MaxWallClockTime);
                    Assert.Equal(dataRetentionTime, freshTask.Constraints.RetentionTime);

                    //Update the task constraints to be null again
                    freshTask.Constraints = null;
                    freshTask.Commit();

                    freshTask.Refresh();

                    //Ensure the commit worked
                    Assert.Equal(defaultConstraints.MaxTaskRetryCount, freshTask.Constraints.MaxTaskRetryCount);
                    Assert.Equal(defaultConstraints.MaxWallClockTime, freshTask.Constraints.MaxWallClockTime);
                    Assert.Equal(defaultConstraints.RetentionTime, freshTask.Constraints.RetentionTime);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void SetTaskConditionalHeaders()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string jobId = "TaskConditionalHeaders-" + TestUtilities.GetMyName();
                try
                {
                    PoolInformation poolInfo = new PoolInformation()
                    {
                        PoolId = "Fake"
                    };

                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInfo);
                    unboundJob.Commit();

                    const string taskId = "T1";

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    boundJob.AddTask(new CloudTask(taskId, "cmd /c dir"));

                    CloudTask boundTask = batchCli.JobOperations.GetTask(jobId, taskId);
                    string capturedEtag1 = boundTask.ETag;

                    boundTask.Constraints = new TaskConstraints(null, null, 5);

                    BatchClientBehavior interceptor = new Protocol.RequestInterceptor(
                        (req) =>
                        {
                            if (req.Options is Protocol.Models.TaskUpdateOptions typedParams)
                            {
                                typedParams.IfMatch = capturedEtag1;
                            }
                        });

                    //Update bound task with if-match header, it should succeed
                    boundTask.Commit(additionalBehaviors: new[] { interceptor });

                    boundTask = batchCli.JobOperations.GetTask(jobId, taskId);

                    interceptor = new Protocol.RequestInterceptor(
                        (req) =>
                        {
                            if (req.Options is Protocol.Models.TaskTerminateOptions typedParams)
                            {
                                typedParams.IfMatch = capturedEtag1;
                            }
                        });

                    //Terminate bound task with if-match header, it should fail
                    Exception e = TestUtilities.AssertThrows<BatchException>(() => boundTask.Terminate(additionalBehaviors: new[] { interceptor }));
                    TestUtilities.AssertIsBatchExceptionAndHasCorrectAzureErrorCode(e, BatchErrorCodeStrings.ConditionNotMet, testOutputHelper);
                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact(Skip="Containers take custom images right now")]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void AddTaskOnContainerPool_TaskIsExecuted()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                const string taskId = "t1";
                const string poolId = nameof(AddTaskOnContainerPool_TaskIsExecuted);
                string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-" + nameof(AddTaskOnContainerPool_TaskIsExecuted);
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                        {
                            ContainerConfiguration = new ContainerConfiguration()
                            {
                                ContainerImageNames = new List<string> { "busybox" }
                            }
                        });
                    pool.Commit();

                    pool = PoolFixture.WaitForPoolAllocation(batchCli, poolId);

                    CloudJob job = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolId });
                    job.Commit();

                    var task = new CloudTask(taskId, "echo hello");
                    batchCli.JobOperations.AddTask(jobId, task);
                }
                finally
                {
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
