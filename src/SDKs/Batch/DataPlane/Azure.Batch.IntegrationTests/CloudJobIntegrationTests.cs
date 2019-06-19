// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestUtilities;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using Xunit;
    using Xunit.Abstractions;

    [Collection("SharedPoolCollection")]
    public class CloudJobIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public CloudJobIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void Bug1665834TaskStateMonitor()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1665834Job-" + TestUtilities.GetMyName();

                    try
                    {
                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        unboundJob.PoolInformation.PoolId = this.poolFixture.PoolId;
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        // add some noise tasks
                        for (int j = 0; j < 5; j++)
                        {
                            CloudTask unboundTaskQuick = new CloudTask((10 + j).ToString(), "cmd /c hostname");

                            boundJob.AddTask(unboundTaskQuick);
                        }

                        System.Threading.Thread.Sleep(5000);

                        // wait for fast tasks to complete
                        {
                            bool repeat = true;

                            while (repeat)
                            {
                                CloudPool boundPool = batchCli.PoolOperations.GetPool(this.poolFixture.PoolId);

                                repeat = false;

                                foreach (CloudTask curTask in boundJob.ListTasks())
                                {
                                    if (curTask.State != Microsoft.Azure.Batch.Common.TaskState.Completed)
                                    {
                                        repeat = true;

                                        this.testOutputHelper.WriteLine("Manual Wait Task Id: " + curTask.Id + ", state = " + curTask.State);
                                        this.testOutputHelper.WriteLine("   poolstate: " + boundPool.State + ", currentdedicated: " + boundPool.CurrentDedicatedComputeNodes);
                                        this.testOutputHelper.WriteLine("      compute nodes:");

                                        foreach (ComputeNode curComputeNode in boundPool.ListComputeNodes())
                                        {
                                            this.testOutputHelper.WriteLine("           computeNode.Id: " + curComputeNode.Id + ", state: " + curComputeNode.State);
                                        }
                                    }
                                }
                            }
                        }

                        // add some longer running tasks

                        this.testOutputHelper.WriteLine("Adding longer running tasks");

                        for (int i = 0; i < 15; i++)
                        {
                            CloudTask unboundTask = new CloudTask(i.ToString() + "_a234567890a234567890a234567890a234567890a234567890a234567890", "cmd /c ping 127.0.0.1 -n 4");

                            boundJob.AddTask(unboundTask);
                        }

                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor tsm = utilities.CreateTaskStateMonitor();

                        IPagedEnumerable<CloudTask> taskList = boundJob.ListTasks();
                        ODATAMonitorControl odmc = new ODATAMonitorControl();

                        // try to set really low delay
                        odmc.DelayBetweenDataFetch = new TimeSpan(0);

                        // confirm the floor is enforced
                        Assert.Equal(500, odmc.DelayBetweenDataFetch.Milliseconds);

                        this.testOutputHelper.WriteLine("Calling TaskStateMonitor.WaitAll().  This will take a while.");

                        TimeSpan timeToWait = TimeSpan.FromMinutes(5);
                        Task whenAll = tsm.WhenAll(taskList, Microsoft.Azure.Batch.Common.TaskState.Completed, timeToWait, controlParams: odmc);

                        //This could throw, if it does the test will fail, which is what we want
                        whenAll.Wait();

                        foreach (CloudTask curTask in boundJob.ListTasks())
                        {
                            Assert.Equal(TaskState.Completed, curTask.State);
                        }
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestBoundJobVerbs()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    //Create a job

                    string jobId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-TestBoundJobVerbs";

                    try
                    {
                        CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        cloudJob.PoolInformation = new PoolInformation()
                        {
                            PoolId = this.poolFixture.PoolId
                        };
                        cloudJob.Commit();

                        //Get the bound job
                        CloudJob job = batchCli.JobOperations.GetJob(jobId);

                        //Disable the job (via instance)
                        job.Disable(DisableJobOption.Terminate);

                        //Check the job state

                        CloudJob disabledJob = batchCli.JobOperations.GetJob(jobId);
                        this.testOutputHelper.WriteLine("DisabledJob State: {0}", disabledJob.State);
                        Assert.True(disabledJob.State == JobState.Disabled || disabledJob.State == JobState.Disabling);

                        //Enable the job (via instance)
                        job.Enable();

                        //Check the job state
                        CloudJob enabledJob = batchCli.JobOperations.GetJob(jobId);
                        this.testOutputHelper.WriteLine("EnabledJob state: {0}", enabledJob.State);
                        Assert.Equal(JobState.Active, JobState.Active);

                        //Disable the job (via operations)
                        batchCli.JobOperations.DisableJob(jobId, DisableJobOption.Terminate);

                        disabledJob = batchCli.JobOperations.GetJob(jobId);
                        this.testOutputHelper.WriteLine("DisabledJob State: {0}", disabledJob.State);
                        Assert.True(disabledJob.State == JobState.Disabled || disabledJob.State == JobState.Disabling);

                        //Enable the job (via operations)
                        batchCli.JobOperations.EnableJob(jobId);

                        //Check the job state
                        enabledJob = batchCli.JobOperations.GetJob(jobId);
                        this.testOutputHelper.WriteLine("EnabledJob state: {0}", enabledJob.State);
                        Assert.Equal(JobState.Active, JobState.Active);

                        //Terminate the job
                        job.Terminate("need some reason");

                        //Check the job state
                        CloudJob terminatedJob = batchCli.JobOperations.GetJob(jobId);
                        this.testOutputHelper.WriteLine("TerminatedJob state: {0}", terminatedJob.State);
                        Assert.True(terminatedJob.State == JobState.Terminating || terminatedJob.State == JobState.Completed);

                        if (terminatedJob.State == JobState.Terminating)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(5)); //Sleep and wait for the job to finish terminating before we issue a delete
                        }

                        //Delete the job
                        job.Delete();

                        //Check that the job doesn't exist anymore

                        try
                        {
                            this.testOutputHelper.WriteLine("Expected Exception: testing that job does NOT exist.");

                            CloudJob deletedJob = batchCli.JobOperations.GetJob(jobId);
                            Assert.Equal(JobState.Deleting, deletedJob.State);
                        }
                        catch (Exception e)
                        {
                            Assert.IsAssignableFrom<BatchException>(e);
                            BatchException be = e as BatchException;
                            Assert.NotNull(be.RequestInformation);
                            Assert.NotNull(be.RequestInformation.BatchError);
                            Assert.Equal(BatchErrorCodeStrings.JobNotFound, be.RequestInformation.BatchError.Code);

                            this.testOutputHelper.WriteLine("Job was deleted successfully");
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
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1433069TestBoundJobCommit()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-TestBoundJobCommit";
                    try
                    {
                        //
                        // Create the job
                        //
                        CloudJob cloudJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                        cloudJob.PoolInformation = new PoolInformation()
                        {
                            PoolId = this.poolFixture.PoolId
                        };

                        this.testOutputHelper.WriteLine("Initial job schedule commit()");
                        cloudJob.Commit();

                        //Get the job
                        CloudJob refreshableJob = batchCli.JobOperations.GetJob(jobId);

                        //Update the bound job priority
                        const int newJobPriority = 5;
                        OnAllTasksComplete newOnAllTasksComplete = OnAllTasksComplete.NoAction;

                        this.testOutputHelper.WriteLine("Job priority is: {0}", refreshableJob.Priority);
                        refreshableJob.Priority = newJobPriority;
                        refreshableJob.OnAllTasksComplete = newOnAllTasksComplete;
                        refreshableJob.Commit();

                        AssertJobCorrectness(batchCli.JobOperations, jobId, ref refreshableJob, this.poolFixture.PoolId, newJobPriority, null);

                        //Update the bound job pool name
                        //Must disable the job first before updating its pool
                        refreshableJob.Disable(DisableJobOption.Terminate);

                        //Wait for job to reach disabled state (could go to Disabling for a bit)
                        //TODO: Use a uBtilities wait helper here
                        DateTime jobDisabledStateWaitStartTime = DateTime.UtcNow;
                        TimeSpan jobDisabledTimeout = TimeSpan.FromSeconds(120);
                        while (refreshableJob.State != JobState.Disabled)
                        {
                            this.testOutputHelper.WriteLine("Bug1433069TestBoundJobCommit: sleeping for (refreshableJob.State != JobState.Disabled)");
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshableJob = batchCli.JobOperations.GetJob(jobId);

                            if (DateTime.UtcNow > jobDisabledStateWaitStartTime.Add(jobDisabledTimeout))
                            {
                                Assert.False(true, "Timed out waiting for job to go to disabled state");
                            }
                        }

                        const string newPoolId = "testPool";
                        refreshableJob.PoolInformation.PoolId = newPoolId;
                        refreshableJob.Commit();

                        AssertJobCorrectness(batchCli.JobOperations, jobId, ref refreshableJob, newPoolId, newJobPriority, null);

                        //Enable the job again
                        refreshableJob.Enable();

                        //Update the bound job constraints
                        JobConstraints newJobConstraints = new JobConstraints(TimeSpan.FromSeconds(200), 19);
                        refreshableJob.Constraints = newJobConstraints;
                        refreshableJob.Commit();

                        AssertJobCorrectness(batchCli.JobOperations, jobId, ref refreshableJob, newPoolId, newJobPriority, newJobConstraints);
                    }
                    finally
                    {
                        batchCli.JobOperations.DeleteJob(jobId);
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1996130_JobTaskVerbsFailAfterDoubleRefresh()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1996130Job-" + TestUtilities.GetMyName();

                    try
                    {
                        // get a job/task to test. use workflow
                        CloudJob boundJob = null;
                        {
                            // need a bound job/task for the tests so set one up
                            CloudJob tsh = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                            tsh.PoolInformation.PoolId = this.poolFixture.PoolId;
                            tsh.Commit();

                            boundJob = batchCli.JobOperations.GetJob(jobId);

                            boundJob.AddTask(new CloudTask("Bug1996130_task", "cmd /c hostname"));
                        }

                        // test task double refresh
                        {
                            // get the task
                            CloudTask boundTask = batchCli.JobOperations.ListTasks(jobId).First();

                            // double refresh
                            boundTask.Refresh();
                            boundTask.Refresh(); // this branch of the bug actually fixed in the other doublerefesh checkin by matthchr

                            // do verbs
                            boundTask.Refresh();
                            boundTask.Delete();

                            Thread.Sleep(5000);  // give server time to do its deed

                            List<CloudTask> tasks = batchCli.JobOperations.ListTasks(jobId).ToList();

                            // confirm delete suceeded
                            Assert.Equal(0, tasks.Count);
                        }

                        // test job double refresh and verbs
                        {
                            boundJob = batchCli.JobOperations.GetJob(jobId);

                            // double refresh to taint the instance... lost path variable
                            boundJob.Refresh();
                            boundJob.Refresh();  // this used to fail/throw

                            boundJob.Refresh();  // this should fail but does not
                            boundJob.Delete();   // yet another verb that suceeds

                            CloudJob job = batchCli.JobOperations.ListJobs().ToList().FirstOrDefault(j => j.Id == jobId);

                            // confirm job delete suceeded
                            Assert.True(job == null || (JobState.Deleting == job.State));
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
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestJobCompletesWhenAllItsTasksComplete()
        {
            Action test = () =>
            {
                using (BatchClient client = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    //Create a job
                    string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-TestJobCompletesWhenAllItsTasksComplete";
                    string taskIdPrefix = "task-id";

                    try
                    {
                        CloudJob boundJob = CreateBoundJob(client, jobId);

                        var cloudTasks = new List<CloudTask>();
                        for (var i = 0; i < 4; i++)
                        {
                            cloudTasks.Add(new CloudTask(taskIdPrefix + "-" + i, "cmd /c ping 127.0.0.1"));
                        }

                        boundJob.AddTask(cloudTasks);

                        boundJob.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
                        boundJob.Commit();

                        boundJob.Refresh();

                        TestUtilities.WaitForJobStateAsync(boundJob, TimeSpan.FromMinutes(2), JobState.Completed).Wait();

                        Assert.Equal(JobState.Completed, boundJob.State);
                        Assert.Equal("AllTasksCompleted", boundJob.ExecutionInformation.TerminateReason);
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void IfJobSetsOnTaskFailed_JobCompletesWhenAnyTaskFails()
        {
            Action test = () =>
            {
                using (BatchClient client = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    //Create a job
                    string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-IfJobSetsOnTaskFailedJobCompletesWhenAnyTaskFail";
                    string taskId = "task-id-1";

                    try
                    {
                        CloudJob boundJob = null;
                        {
                            // need a bound job/task for the tests so set one up
                            boundJob = CreateBoundJob(client, jobId, j => { j.OnTaskFailure = OnTaskFailure.PerformExitOptionsJobAction; });

                            Assert.Equal(OnTaskFailure.PerformExitOptionsJobAction, boundJob.OnTaskFailure);

                            CloudTask cloudTask = new CloudTask(taskId, "cmd /c exit 3");

                            cloudTask.ExitConditions = new ExitConditions
                            {
                                ExitCodeRanges = new List<ExitCodeRangeMapping>
                                {
                                    new ExitCodeRangeMapping(2, 4, new ExitOptions { JobAction = JobAction.Terminate})
                                }
                            };

                            boundJob.AddTask(cloudTask);
                            boundJob.Refresh();

                            TestUtilities.WaitForJobStateAsync(boundJob, TimeSpan.FromMinutes(2), JobState.Completed).Wait();
                            Assert.Equal(JobState.Completed, boundJob.State);
                            Assert.Equal("TaskFailed", boundJob.ExecutionInformation.TerminateReason);
                        }
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestExitConditionsAreBeingRoundTrippedCorrectly()
        {
            Action test = () => 
            { 
                using (BatchClient client = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    //Create a job
                    string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-TestExitConditionsAreBeingRoundTrippedCorrectly";
                    string taskId = "task-id-1";
                    try
                    {
                        CloudJob boundJob = null;
                        {
                            // need a bound job/task for the tests so set one up
                            boundJob = CreateBoundJob(client, jobId, j => { j.OnTaskFailure = OnTaskFailure.PerformExitOptionsJobAction; });
                            CloudTask cloudTask = new CloudTask(taskId, "cmd /c exit 2");

                            cloudTask.ExitConditions = new ExitConditions
                            {
                                ExitCodes = new List<ExitCodeMapping> { new ExitCodeMapping(1, new ExitOptions { JobAction = JobAction.None }) },
                                ExitCodeRanges = new List<ExitCodeRangeMapping>
                                {
                                    new ExitCodeRangeMapping(2, 4, new ExitOptions { JobAction = JobAction.Disable })
                                },
                                PreProcessingError = new ExitOptions { JobAction = JobAction.Terminate },
                                FileUploadError = new ExitOptions { JobAction = JobAction.Terminate },
                                Default = new ExitOptions { JobAction = JobAction.Terminate },
                            };

                            boundJob.AddTask(cloudTask);
                            boundJob.Refresh();

                            Assert.Equal(boundJob.OnTaskFailure, OnTaskFailure.PerformExitOptionsJobAction);
                            CloudTask boundTask = client.JobOperations.GetTask(jobId, taskId);

                            Assert.Equal(JobAction.None, boundTask.ExitConditions.ExitCodes.First().ExitOptions.JobAction);
                            Assert.Equal(1, boundTask.ExitConditions.ExitCodes.First().Code);

                            var exitCodeRangeMappings = boundTask.ExitConditions.ExitCodeRanges;
                            Assert.Equal(2, exitCodeRangeMappings.First().Start);
                            Assert.Equal(4, exitCodeRangeMappings.First().End);
                            Assert.Equal(JobAction.Disable, exitCodeRangeMappings.First().ExitOptions.JobAction);
                            Assert.Equal(JobAction.Terminate, boundTask.ExitConditions.PreProcessingError.JobAction);
                            Assert.Equal(JobAction.Terminate, boundTask.ExitConditions.FileUploadError.JobAction);
                            Assert.Equal(JobAction.Terminate, boundTask.ExitConditions.Default.JobAction);
                        }
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        #region Test helpers

        private static void AssertJobCorrectness(
            JobOperations jobOperations,
            string jobId,
            ref CloudJob boundJob,
            string expectedPoolId,
            int expectedPriority,
            JobConstraints expectedJobConstraints)
        {
            //boundJob.Refresh();
            boundJob = jobOperations.GetJob(jobId); //TODO: Have to do this due to parent prop item loss on commit
            Assert.Equal(expectedPriority, boundJob.Priority);
            Assert.Equal(expectedPoolId, boundJob.ExecutionInformation.PoolId);

            if (expectedJobConstraints != null)
            {
                Assert.NotNull(boundJob.Constraints);
                Assert.Equal(expectedJobConstraints.MaxTaskRetryCount, boundJob.Constraints.MaxTaskRetryCount);
                Assert.Equal(expectedJobConstraints.MaxWallClockTime, boundJob.Constraints.MaxWallClockTime);
            }
        }

        private CloudJob CreateBoundJob(BatchClient client, string jobId, Action<CloudJob> jobSetup = null)
        {
            CloudJob cloudJob = client.JobOperations.CreateJob(jobId, new PoolInformation());
            cloudJob.PoolInformation.PoolId = this.poolFixture.PoolId;
            jobSetup?.Invoke(cloudJob);
            cloudJob.Commit();

            return client.JobOperations.GetJob(jobId);
        }

        #endregion

    }

    public class IntegrationCloudJobTestsWithoutSharedPool
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudJobTestsWithoutSharedPool(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task JobPatch()
        {
            string jobId = "TestPatchJob-" + TestUtilities.GetMyName();
            await SynchronizationContextHelper.RunTestAsync(() => MutateJobAsync(jobId, jobAction: job => job.CommitAsync()), TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task JobUpdate()
        {
            string jobId = "TestUpdateJob-" + TestUtilities.GetMyName();
            await SynchronizationContextHelper.RunTestAsync(() => MutateJobAsync(jobId, jobAction: job => job.CommitChangesAsync()), TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestJobUpdateWithAndWithoutPoolInfo()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    const string testName = "TestJobUpdateWithAndWithoutPoolInfo";

                    // Create a job
                    string jobId = testName + "_" + TestUtilities.GetMyName();
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob();
                    unboundJob.Id = jobId;

                    // Use an auto pool with the job, since PoolInformation can't be updated otherwise.
                    PoolSpecification poolSpec = new PoolSpecification();
                    
                    poolSpec.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily, "*");

                    poolSpec.TargetDedicatedComputeNodes = 0;
                    poolSpec.VirtualMachineSize = PoolFixture.VMSize;
                    AutoPoolSpecification autoPoolSpec = new AutoPoolSpecification();
                    string autoPoolPrefix = "UpdPIAuto_" + TestUtilities.GetMyName();
                    autoPoolSpec.AutoPoolIdPrefix = autoPoolPrefix;
                    const bool originalKeepAlive = false;
                    autoPoolSpec.KeepAlive = originalKeepAlive;
                    autoPoolSpec.PoolLifetimeOption = PoolLifetimeOption.Job;
                    autoPoolSpec.PoolSpecification = poolSpec;
                    PoolInformation poolInfo = new PoolInformation();
                    poolInfo.AutoPoolSpecification = autoPoolSpec;
                    unboundJob.PoolInformation = poolInfo;

                    const int originalPriority = 0;
                    unboundJob.Priority = originalPriority;
                    List<MetadataItem> originalMetadata = new List<MetadataItem>();
                    originalMetadata.Add(new MetadataItem("meta1", "value1"));
                    originalMetadata.Add(new MetadataItem("meta2", "value2"));
                    unboundJob.Metadata = originalMetadata;

                    this.testOutputHelper.WriteLine("Creating job {0}", jobId);
                    unboundJob.Commit();

                    try
                    {
                        // Get bound job
                        CloudJob createdJob = batchCli.JobOperations.GetJob(jobId);

                        // Verify that we can update something besides PoolInformation without getting an error for not being in the Disabled state.
                        Assert.NotEqual(JobState.Disabled, createdJob.State);

                        int updatedPriority = originalPriority + 1;
                        List<MetadataItem> updatedMetadata = new List<MetadataItem>();
                        updatedMetadata.Add(new MetadataItem("updatedMeta1", "value1"));
                        createdJob.Priority = updatedPriority;
                        createdJob.Metadata = updatedMetadata;

                        this.testOutputHelper.WriteLine("Updating job {0} without altering PoolInformation", jobId);

                        createdJob.Commit();

                        // Verify update occurred
                        CloudJob updatedJob = batchCli.JobOperations.GetJob(jobId);

                        Assert.Equal(updatedPriority, updatedJob.Priority);
                        Assert.Equal(updatedJob.Metadata.Count, updatedJob.Priority);
                        Assert.Equal(updatedJob.Metadata[0].Name, updatedMetadata[0].Name);
                        Assert.Equal(updatedJob.Metadata[0].Value, updatedMetadata[0].Value);

                        // Verify that updating the PoolInformation works.
                        // PoolInformation can only be changed in the Disabled state.
                        this.testOutputHelper.WriteLine("Disabling job {0}", jobId);
                        updatedJob.Disable(DisableJobOption.Terminate);
                        while (updatedJob.State != JobState.Disabled)
                        {
                            Thread.Sleep(500);
                            updatedJob.Refresh();
                        }

                        Assert.Equal(JobState.Disabled, updatedJob.State);

                        bool updatedKeepAlive = !originalKeepAlive;
                        updatedJob.PoolInformation.AutoPoolSpecification.KeepAlive = updatedKeepAlive;
                        int updatedAgainPriority = updatedPriority + 1;
                        updatedJob.Priority = updatedAgainPriority;
                        this.testOutputHelper.WriteLine("Updating job {0} properties, including PoolInformation", jobId);
                        updatedJob.Commit();

                        CloudJob updatedPoolInfoJob = batchCli.JobOperations.GetJob(jobId);

                        Assert.Equal(updatedKeepAlive, updatedPoolInfoJob.PoolInformation.AutoPoolSpecification.KeepAlive);
                        Assert.Equal(updatedAgainPriority, updatedPoolInfoJob.Priority);
                    }
                    finally
                    {
                        this.testOutputHelper.WriteLine("Deleting job {0}", jobId);
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();

                        // Explicitly delete auto pool
                        foreach (CloudPool pool in batchCli.PoolOperations.ListPools(new ODATADetailLevel(filterClause: string.Format("startswith(id,'{0}')", autoPoolPrefix))))
                        {
                            this.testOutputHelper.WriteLine("Deleting pool {0}", pool.Id);
                            TestUtilities.DeletePoolIfExistsAsync(batchCli, pool.Id).Wait();
                        }
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_Bug1965363Wat7OSVersionFeaturesQuickJobWithAutoPool()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "Bug1965363Job-" + TestUtilities.GetMyName();
                    try
                    {

                        PoolInformation poolInfo = new PoolInformation()
                        {
                            AutoPoolSpecification = new AutoPoolSpecification()
                            {
                                PoolLifetimeOption = PoolLifetimeOption.Job,
                                PoolSpecification = new PoolSpecification()
                                {
                                    CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                                    VirtualMachineSize = PoolFixture.VMSize,
                                    TargetDedicatedComputeNodes = 1
                                }
                            }
                        };

                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInfo);

                        this.testOutputHelper.WriteLine("Commiting quickjob");
                        unboundJob.Commit();

                        CloudTask task = new CloudTask("Bug1965363Wat7OSVersionFeaturesQuickJobWithAutoPoolTask", "cmd /c echo Bug1965363");
                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                        boundJob.AddTask(task);

                        this.testOutputHelper.WriteLine("Getting pool name: {0}", boundJob.ExecutionInformation.PoolId);

                        CloudPool boundPool = batchCli.PoolOperations.GetPool(boundJob.ExecutionInformation.PoolId);
                        TaskStateMonitor tsm = batchCli.Utilities.CreateTaskStateMonitor();
                        ODATAMonitorControl odControl = new ODATAMonitorControl();

                        // we know that the autopool compute nodes will take a long time to become scheduleable so we slow down polling/spam
                        odControl.DelayBetweenDataFetch = TimeSpan.FromSeconds(5);

                        this.testOutputHelper.WriteLine("Invoking TaskStateMonitor");

                        tsm.WaitAll(
                            boundJob.ListTasks(),
                            TaskState.Completed,
                            TimeSpan.FromMinutes(15),
                            odControl,
                            new[] {
                                // spam/logging interceptor
                                new Microsoft.Azure.Batch.Protocol.RequestInterceptor((x) =>
                                {
                                    this.testOutputHelper.WriteLine("Issuing request type: " + x.GetType().ToString());

                                    // print out the compute node states... we are actually waiting on the compute nodes
                                    List<ComputeNode> allComputeNodes = boundPool.ListComputeNodes().ToList();
                                    this.testOutputHelper.WriteLine("    #comnpute nodes: " + allComputeNodes.Count);

                                    allComputeNodes.ForEach((icn) => { this.testOutputHelper.WriteLine("  computeNode.id: " + icn.Id + ", state: " + icn.State); });
                                    this.testOutputHelper.WriteLine("");
                                })
                            });

                        // confirm the task ran by inspecting the stdOut
                        string stdOut = boundJob.ListTasks().ToList()[0].GetNodeFile(Constants.StandardOutFileName).ReadAsString();

                        Assert.Contains("Bug1965363", stdOut);
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void SetUpdateJobConditionalHeader()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result)
                {
                    string jobId = "JobConditionalHeaders-" + TestUtilities.GetMyName();
                    try
                    {
                        PoolInformation poolInfo = new PoolInformation()
                            {
                                PoolId = "Fake"
                            };

                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInfo);
                        unboundJob.Commit();

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);

                        string capturedEtag1 = boundJob.ETag;
                        this.testOutputHelper.WriteLine("Etag is: {0}", capturedEtag1);
                        Assert.NotNull(capturedEtag1);

                        boundJob.Constraints = new JobConstraints(TimeSpan.FromMinutes(60), 0);

                        BatchClientBehavior updateInterceptor = new Protocol.RequestInterceptor(
                            (req) =>
                                {
                                    var typedParams = req.Options as Protocol.Models.JobUpdateOptions;
                                    if (typedParams != null)
                                    {
                                        typedParams.IfMatch = capturedEtag1;
                                    }
                                });

                        //Update bound job with if-match header, it should succeed
                        boundJob.Commit(additionalBehaviors: new[] { updateInterceptor });

                        boundJob = batchCli.JobOperations.GetJob(jobId);

                        boundJob.Constraints = new JobConstraints(TimeSpan.FromMinutes(30), 1);

                        //Update bound job with if-match header, it should fail
                        Exception e = TestUtilities.AssertThrows<BatchException>(() => boundJob.Commit(additionalBehaviors: new[] { updateInterceptor }));
                        TestUtilities.AssertIsBatchExceptionAndHasCorrectAzureErrorCode(e, BatchErrorCodeStrings.ConditionNotMet, this.testOutputHelper);
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task Job_CanAddJobWithJobManagerAndAllowLowPriorityTrue()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    string jobId = "TestJobWithLowPriJobManager-" + TestUtilities.GetMyName();
                    try
                    {
                        PoolInformation poolInfo = new PoolInformation()
                        {
                            PoolId = "Fake"
                        };

                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInfo);
                        unboundJob.JobManagerTask = new JobManagerTask("foo", "cmd /c echo hi")
                        {
                            AllowLowPriorityNode = true
                        };
                        await unboundJob.CommitAsync().ConfigureAwait(false);
                        await unboundJob.RefreshAsync().ConfigureAwait(false);

                        Assert.True(unboundJob.JobManagerTask.AllowLowPriorityNode);
                    }
                    finally
                    {
                        await TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId);
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task Job_GetTaskCounts_ReturnsCorrectCount()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    string jobId = "TestJobGetTaskCounts-" + TestUtilities.GetMyName();
                    try
                    {
                        PoolInformation poolInfo = new PoolInformation()
                        {
                            PoolId = "Fake"
                        };

                        CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, poolInfo);
                        await unboundJob.CommitAsync().ConfigureAwait(false);
                        await unboundJob.RefreshAsync().ConfigureAwait(false);

                        CloudTask t1 = new CloudTask("t1", "cmd /c dir");
                        CloudTask t2 = new CloudTask("t2", "cmd /c ping 127.0.0.1 -n 4");

                        await unboundJob.AddTaskAsync(new[] {t1, t2}).ConfigureAwait(false);

                        await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false); // Give the service some time to get the counts

                        var counts = await unboundJob.GetTaskCountsAsync().ConfigureAwait(false);

                        Assert.Equal(2, counts.Active);
                    }
                    finally
                    {
                        await TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId);
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        private static async Task MutateJobAsync(string jobId, Func<CloudJob, Task> jobAction)
        {
            using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
            {
                const string newPoolId = "Bar";
                const string metadataKey = "Foo";
                const string metadataValue = "Bar";
                TimeSpan newMaxWallClockTime = TimeSpan.FromDays(1);
                try
                {
                    CloudJob job = batchCli.JobOperations.CreateJob(
                        jobId,
                        new PoolInformation()
                        {
                            PoolId = "Temp"
                        });

                    await job.CommitAsync().ConfigureAwait(false);
                    await job.RefreshAsync().ConfigureAwait(false);

                    //Disable the job so that we can update the pool info
                    await job.DisableAsync(DisableJobOption.Requeue).ConfigureAwait(false);

                    await TestUtilities.WaitForJobStateAsync(job, TimeSpan.FromMinutes(1), JobState.Disabled).ConfigureAwait(false);

                    job.Constraints = new JobConstraints(maxWallClockTime: newMaxWallClockTime);
                    job.Metadata = new List<MetadataItem>()
                            {
                                new MetadataItem(metadataKey, metadataValue)
                            };
                    job.PoolInformation.PoolId = newPoolId;

                    await jobAction(job).ConfigureAwait(false);

                    await job.RefreshAsync().ConfigureAwait(false);

                    Assert.Equal(newMaxWallClockTime, job.Constraints.MaxWallClockTime);
                    Assert.Equal(newPoolId, job.PoolInformation.PoolId);
                    Assert.Equal(metadataKey, job.Metadata.Single().Name);
                    Assert.Equal(metadataValue, job.Metadata.Single().Value);
                }
                finally
                {
                    await TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).ConfigureAwait(false);
                }
            }
        }
    }
}
