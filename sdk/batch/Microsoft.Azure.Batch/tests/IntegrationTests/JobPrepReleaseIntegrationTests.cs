// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.FileStaging;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using TestResources;
    using IntegrationTestUtilities;
    using Microsoft.Rest.Azure;
    using Xunit.Abstractions;
    using Xunit;
    using Constants = Microsoft.Azure.Batch.Constants;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    [Collection("SharedPoolCollection")]
    public class JobPrepReleaseIntegrationTests
    {
        #region Test Constants

        private const string JobPrepCommandLine = @"cmd /c dir /s .. & echo JobPreparation Task!! & dir & type localwords.txt";
        private static readonly EnvironmentSetting JobPrepEnvSettingOM = new EnvironmentSetting(name: "JobPrepEnvSetting00", value: "JobPrepEnvSetting00Value");
        private const string JobPrepId = "AddJobPrepOM";
        private const bool JobPrepRerunOnComputeNodeRebootAfterSuccess = true;
        private static readonly AutoUserSpecification JobPrepUserSpec = new AutoUserSpecification(scope:AutoUserScope.Task, elevationLevel: ElevationLevel.Admin);
        private static readonly TaskConstraints JobPrepTaskConstraintsOM = new TaskConstraints(maxTaskRetryCount: 4, maxWallClockTime: TimeSpan.FromHours(1.0), retentionTime: TimeSpan.FromHours(2.0));
        private const bool JobPrepWaitForSuccessCreate = false;  // true is the default so try false even though its crazy
        private const bool JobPrepWaitForSuccessUpdate = false;  // we need WfS so we can test the exeinfo.state
        private const string JobReleaseTaskCommandLine = @"cmd /c dir /s .. & echo JobRelease Task!! & dir & type localwords.txt";
        private static readonly EnvironmentSetting JobRelEnvSettingOM = new EnvironmentSetting(name: "JobReleaseEnvSetting00Name", value: "JobReleaseEnvSetting00Value");
        private static readonly TimeSpan JobRelMaxWallClockTime = TimeSpan.FromMinutes(5.0);
        private const string JobRelId = "AddJobReleaseOM";
        private static readonly TimeSpan JobRelRetentionTime = TimeSpan.FromMinutes(10.0);
        private static readonly AutoUserSpecification JobRelUserSpec = new AutoUserSpecification(scope: AutoUserScope.Task, elevationLevel: ElevationLevel.Admin);
        private static readonly EnvironmentSetting JobCommonEnvSettingOM = new EnvironmentSetting(name: "JobCommenEnv00Name", value: "JobCommonEnv00Value");

        #endregion

        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(2);
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(10);
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;

        public JobPrepReleaseIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestOMJobSpecAndRelease()
        {
            void test()
            {
                StagingStorageAccount stagingCreds = TestUtilities.GetStorageCredentialsFromEnvironment();
                using BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jsId = "JobPrepAndRelease-" + /* "OM-static-c" */ "dynamic-" + CraftTimeString() + "-" + TestUtilities.GetMyName();

                try
                {
                    // increase request timeout interceptor
                    Protocol.RequestInterceptor increaseTimeoutInterceptor =
                        new Protocol.RequestInterceptor((x) =>
                        {
                            testOutputHelper.WriteLine("TestOMJobSpecAndRelease: setting request timeout.  Request type: " + x.GetType().ToString() + ", ClientRequestID: " + x.Options.ClientRequestId);
                            var timeoutOptions = x.Options as Protocol.Models.ITimeoutOptions;
                            timeoutOptions.Timeout = 5 * 60;
                        });

                    // lets use a timer too
                    CallTimerViaInterceptors timerInterceptor = new CallTimerViaInterceptors();

                    // seeing client side timeouts... so increase the durations on every call
                    client.CustomBehaviors.Add(increaseTimeoutInterceptor);
                    // add a call timer spammer/logger
                    client.CustomBehaviors.Add(timerInterceptor.ReqInterceptor);

                    // get some resource files to play with
                    IList<ResourceFile> resFiles = UploadFilesMakeResFiles(stagingCreds);

                    // create job schedule with prep/release
                    {
                        CloudJobSchedule unboundJobSchedule = client.JobScheduleOperations.CreateJobSchedule(jsId, null, null);
                        unboundJobSchedule.JobSpecification = new JobSpecification(new PoolInformation());
                        unboundJobSchedule.JobSpecification.PoolInformation.PoolId = poolFixture.PoolId;
                        unboundJobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(3) };

                        // add the jobPrep task to the job schedule
                        {
                            JobPreparationTask prep = new JobPreparationTask(JobPrepCommandLine);
                            unboundJobSchedule.JobSpecification.JobPreparationTask = prep;

                            List<EnvironmentSetting> prepEnvSettings = new List<EnvironmentSetting>
                            {
                                JobPrepEnvSettingOM
                            };
                            prep.EnvironmentSettings = prepEnvSettings;

                            prep.Id = JobPrepId;
                            prep.RerunOnComputeNodeRebootAfterSuccess = JobPrepRerunOnComputeNodeRebootAfterSuccess;

                            prep.ResourceFiles = resFiles; // bug: incorrect type this should be IList<>

                            /*
                                prep.ResourceFiles = new List<ResourceFile>();  // this is actually read into our concurrent iList thing

                                // why not, merge them in.  exersize the concurent  IList thing
                                foreach (ResourceFile curRF in resFiles)
                                {
                                    prep.ResourceFiles.Add(curRF);
                                }
                                */

                            prep.UserIdentity = new UserIdentity(JobPrepUserSpec);
                            prep.Constraints = JobPrepTaskConstraintsOM;
                            prep.WaitForSuccess = JobPrepWaitForSuccessCreate;
                        }

                        // add a jobRelease task to the job schedule
                        {
                            JobReleaseTask relTask = new JobReleaseTask(JobReleaseTaskCommandLine);
                            unboundJobSchedule.JobSpecification.JobReleaseTask = relTask;

                            List<EnvironmentSetting> relEnvSettings = new List<EnvironmentSetting>
                            {
                                JobRelEnvSettingOM
                            };
                            relTask.EnvironmentSettings = relEnvSettings;

                            relTask.MaxWallClockTime = JobRelMaxWallClockTime;

                            relTask.Id = JobRelId;

                            relTask.ResourceFiles = null;

                            relTask.ResourceFiles = new List<ResourceFile>();

                            // why not, merge them in.  work the concurrent  IList thing
                            foreach (ResourceFile curRF in resFiles)
                            {
                                relTask.ResourceFiles.Add(curRF);
                            }

                            relTask.RetentionTime = JobRelRetentionTime;
                            relTask.UserIdentity = new UserIdentity(JobRelUserSpec);
                        }

                        // set JobCommonEnvSettings
                        {
                            List<EnvironmentSetting> jobCommonES = new List<EnvironmentSetting>
                            {
                                JobCommonEnvSettingOM
                            };

                            unboundJobSchedule.JobSpecification.CommonEnvironmentSettings = jobCommonES;
                        }

                        // add the job schedule to the service
                        unboundJobSchedule.Commit();
                    }

                    // now we have a jobschedule with jobprep/release...now test the values on the jobschedule
                    {
                        CloudJobSchedule boundJobSchedule = client.JobScheduleOperations.GetJobSchedule(jsId);

                        Assert.NotNull(boundJobSchedule);
                        Assert.NotNull(boundJobSchedule.JobSpecification);
                        Assert.NotNull(boundJobSchedule.JobSpecification.JobPreparationTask);
                        Assert.NotNull(boundJobSchedule.JobSpecification.JobReleaseTask);
                        Assert.NotNull(boundJobSchedule.JobSpecification.CommonEnvironmentSettings);

                        AssertGoodCommonEnvSettingsOM(boundJobSchedule.JobSpecification.CommonEnvironmentSettings);
                        AssertGoodJobPrepTaskOM(boundJobSchedule.JobSpecification.JobPreparationTask);
                        AssertGoodJobReleaseTaskOM(boundJobSchedule.JobSpecification.JobReleaseTask);
                        AssertGoodResourceFiles(resFiles, boundJobSchedule.JobSpecification.JobPreparationTask.ResourceFiles);
                        AssertGoodResourceFiles(resFiles, boundJobSchedule.JobSpecification.JobReleaseTask.ResourceFiles);

                        //todo: test mutability
                    }

                    CloudJobSchedule boundJobScheduleWithJob; // set on job test

                    // test the values on the job
                    {
                        boundJobScheduleWithJob = TestUtilities.WaitForJobOnJobSchedule(client.JobScheduleOperations, jsId);
                        CloudJob bndJob = client.JobOperations.GetJob(boundJobScheduleWithJob.ExecutionInformation.RecentJob.Id);

                        Assert.NotNull(bndJob);
                        Assert.NotNull(bndJob.CommonEnvironmentSettings);
                        Assert.NotNull(bndJob.JobPreparationTask);
                        Assert.NotNull(bndJob.JobReleaseTask);

                        AssertGoodCommonEnvSettingsOM(bndJob.CommonEnvironmentSettings as IList<EnvironmentSetting>
                            /* we know it is our internal IList */);
                        AssertGoodJobPrepTaskOM(bndJob.JobPreparationTask);
                        AssertGoodJobReleaseTaskOM(bndJob.JobReleaseTask);
                        AssertGoodResourceFiles(resFiles, bndJob.JobPreparationTask.ResourceFiles);
                        AssertGoodResourceFiles(resFiles, bndJob.JobReleaseTask.ResourceFiles);

                        //TODO: test immutability
                    }

                    // used for on get-status test
                    CloudJobSchedule updatedJobSchedule;

                    // test update on the WI jobprep/jobrelease
                    {
                        // change props
                        boundJobScheduleWithJob.JobSpecification.JobPreparationTask.WaitForSuccess = JobPrepWaitForSuccessUpdate;

                        // commit changes
                        boundJobScheduleWithJob.Commit();

                        // get new values
                        updatedJobSchedule = client.JobScheduleOperations.GetJobSchedule(jsId);

                        // confirm values changed
                        Assert.Equal(JobPrepWaitForSuccessUpdate, updatedJobSchedule.JobSpecification.JobPreparationTask.WaitForSuccess);
                    }

                    TestGetPrepReleaseStatusCalls(client, updatedJobSchedule, poolFixture.PoolId, resFiles);
                }
                finally
                {
                    // cleanup
                    TestUtilities.DeleteJobScheduleIfExistsAsync(client, jsId).Wait();
                }

            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        /// <summary>
        ///  Test the english text returned when a status call is made on a compute node that has not run the JP/JR
        /// </summary>
        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestOMJobPrepReleaseRunOnNaiveComputeNode()
        {
            string jobId = "TestOMJobPrepReleaseRunOnNaiveComputeNode-" + TestUtilities.GetMyName();
            void test()
            {
                using BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                try
                {
                    // create job with prep/release
                    {
                        CloudJob unboundJob = client.JobOperations.CreateJob(jobId, null);
                        unboundJob.PoolInformation = new PoolInformation();
                        unboundJob.PoolInformation.PoolId = poolFixture.PoolId;

                        // add the jobPrep task to the job
                        {
                            JobPreparationTask prep = new JobPreparationTask("cmd /c echo JobPrep!!");
                            unboundJob.JobPreparationTask = prep;

                            prep.WaitForSuccess = true; // be explicit even though this is the default.  need JP/JP to not run
                        }


                        // add a jobRelease task to the job
                        {
                            JobReleaseTask relTask = new JobReleaseTask(JobReleaseTaskCommandLine);
                            unboundJob.JobReleaseTask = relTask;
                        }

                        // add the job to the service
                        unboundJob.Commit();
                    }

                    // the victim nodes.  pool should have size 1.
                    List<ComputeNode> computeNodes = client.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                    Assert.Single(computeNodes);
                    // now we have a job with zero tasks... lets call get-status methods

                    // call it
                    List<JobPreparationAndReleaseTaskExecutionInformation> jrStatusList =
                        client.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId).ToList();

                    JobPreparationAndReleaseTaskExecutionInformation prepAndReleaseStatus = jrStatusList.FirstOrDefault();

                    Assert.Null(prepAndReleaseStatus);
                }
                finally
                {
                    // cleanup
                    TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestOMJobPrepSchedulingError()
        {
            string jobId = "TestOMJobPrepSchedulingError-" + CraftTimeString() + "-" + TestUtilities.GetMyName();

            void test()
            {
                using BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                try
                {
                    // create job with prep that triggers prep scheduling error
                    {
                        CloudJob unboundJob = client.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                        // add the jobPrep task to the job
                        {
                            JobPreparationTask prep = new JobPreparationTask("cmd /c JobPrep Task");
                            unboundJob.JobPreparationTask = prep;

                            ResourceFile[] badResFiles = { ResourceFile.FromUrl("https://not.a.domain.invalid/file", "bob.txt") };

                            prep.ResourceFiles = badResFiles;

                            prep.WaitForSuccess = true; // be explicit even though this is the default.  need JP/ to not run
                        }

                        // add the job to the service
                        unboundJob.Commit();
                    }

                    CloudJob boundJob = client.JobOperations.GetJob(jobId);

                    // add a trivial task to force the JP
                    client.JobOperations.AddTask(boundJob.Id, new CloudTask("ForceJobPrep", "cmd /c echo TestOMJobPrepSchedulingError"));

                    // the victim compute node.  pool should have size 1.
                    List<ComputeNode> nodes = client.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                    Assert.Single(nodes);

                    // now we have a job that should be trying to run the JP
                    // poll for the JP to have been run, and it must have a scheduling error
                    bool prepNotCompleted = true;

                    // gotta poll to find out when the jp has been run
                    while (prepNotCompleted)
                    {
                        List<JobPreparationAndReleaseTaskExecutionInformation> jpStatsList =
                            client.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId).ToList();
                        JobPreparationAndReleaseTaskExecutionInformation jpStatus = jpStatsList.FirstOrDefault();

                        if (jpStatus == null)
                        {
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            if (JobPreparationTaskState.Completed == jpStatus.JobPreparationTaskExecutionInformation.State)
                            {
                                prepNotCompleted = false; // we see a JP has completed

                                Assert.NotNull(jpStatus.JobPreparationTaskExecutionInformation.FailureInformation);
                                Assert.Equal(TaskExecutionResult.Failure, jpStatus.JobPreparationTaskExecutionInformation.Result);

                                // spew the failure
                                OutputFailureInfo(jpStatus.JobPreparationTaskExecutionInformation.FailureInformation);
                            }

                            testOutputHelper.WriteLine("Job Prep is running (waiting for blob dl to timeout)");
                        }
                    }
                }
                finally
                {
                    // cleanup
                    client.JobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestOMJobReleaseSchedulingError()
        {
            string jobId = "TestOMJobReleaseSchedulingError-" + CraftTimeString() + "-" + TestUtilities.GetMyName();
            void test()
            {
                using BatchClient client = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                try
                {
                    // create job schedule with prep that succeeds and release the triggers scheduling error
                    {
                        PoolInformation poolInfo = new PoolInformation() { PoolId = poolFixture.PoolId };
                        CloudJob unboundJob = client.JobOperations.CreateJob(jobId, poolInfo);

                        // add the jobPrep task to the job
                        {
                            JobPreparationTask prep = new JobPreparationTask("cmd /c echo the quick job prep jumped over the...");
                            unboundJob.JobPreparationTask = prep;

                            prep.WaitForSuccess = false; // we don't really care but why not set this
                        }

                        // add a jobRelease task to the job
                        {
                            JobReleaseTask relTask = new JobReleaseTask("cmd /c echo Job Release Task");
                            unboundJob.JobReleaseTask = relTask;

                            ResourceFile[] badResFiles = { ResourceFile.FromUrl("https://not.a.domain.invalid/file", "bob.txt") };

                            relTask.ResourceFiles = badResFiles;

                            relTask.Id = "jobRelease";
                        }

                        // add the job to the service
                        unboundJob.Commit();
                    }

                    // add a trivial task to force the JP
                    client.JobOperations.AddTask(jobId, new CloudTask("ForceJobPrep", "cmd /c echo TestOMJobReleaseSchedulingError"));

                    // wait for the task to complete

                    TaskStateMonitor tsm = client.Utilities.CreateTaskStateMonitor();

                    tsm.WaitAll(
                        client.JobOperations.ListTasks(jobId),
                        TaskState.Completed,
                        TimeSpan.FromMinutes(10),
                        additionalBehaviors:
                            new[]
                            {
                                    // spam/logging interceptor
                                    new Protocol.RequestInterceptor((x) =>
                                        {
                                            testOutputHelper.WriteLine("Issuing request type: " + x.GetType().ToString());

                                            // print out the compute node states... we are actually waiting on the compute nodes
                                            List<ComputeNode> allComputeNodes = client.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                                            testOutputHelper.WriteLine("    #compute nodes: " + allComputeNodes.Count);

                                            allComputeNodes.ForEach((icn) =>
                                                {
                                                    testOutputHelper.WriteLine("  computeNode.id: " + icn.Id + ", state: " + icn.State);
                                                });
                                            testOutputHelper.WriteLine("");
                                        })
                            }
                        );

                    // ok terminate job to trigger job release
                    client.JobOperations.TerminateJob(jobId, "BUG: Server will throw 500 if I don't provide reason");

                    // the victim compute node.  pool should have size 1.
                    List<ComputeNode> computeNodes = client.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                    Assert.Single(computeNodes);

                    // now we have a job that should be trying to run the JP
                    // poll for the JP to have been run, and it must have a scheduling error
                    bool releaseNotCompleted = true;

                    // gotta poll to find out when the jp has been run
                    while (releaseNotCompleted)
                    {
                        List<JobPreparationAndReleaseTaskExecutionInformation> jrStatusList =
                            client.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId).ToList();

                        JobPreparationAndReleaseTaskExecutionInformation prepAndReleaseStatus = jrStatusList.FirstOrDefault();

                        if (prepAndReleaseStatus != null && null != prepAndReleaseStatus.JobReleaseTaskExecutionInformation)
                        {
                            if (JobReleaseTaskState.Completed == prepAndReleaseStatus.JobReleaseTaskExecutionInformation.State)
                            {
                                releaseNotCompleted = false; // we see a JP has been run

                                // now assert the failure info
                                Assert.NotNull(prepAndReleaseStatus);
                                Assert.NotNull(prepAndReleaseStatus.JobReleaseTaskExecutionInformation.FailureInformation);
                                Assert.Equal(TaskExecutionResult.Failure, prepAndReleaseStatus.JobReleaseTaskExecutionInformation.Result);

                                // spew the failure info
                                OutputFailureInfo(prepAndReleaseStatus.JobReleaseTaskExecutionInformation.FailureInformation);
                            }
                        }
                        Thread.Sleep(2000);
                        testOutputHelper.WriteLine("Job Release tasks still running (waiting for blob dl to timeout).");
                    }
                }
                finally
                {
                    client.JobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        #region Private helpers

        /// <summary>
        /// calls the two new get-status REST APIs and asserts their values
        ///
        /// 1: add a single quick task (quick because we don't need it to run very long)
        /// 2: this forces a victim compute node to run the JobPrep
        /// 3: poll for this compute node, ignore others (sharedPool.size probably > 1)
        /// 4: check status of JobPrep
        /// 4a: assert as many values as makes sense... this is not a retry test
        /// 5: JobPrep succeeds, task runs
        /// 6: poll for JobRelease.. it is long running
        /// 7: assert as many values as makes sense.
        /// </summary>
        /// <param name="batchCli"></param>
        private void TestGetPrepReleaseStatusCalls(BatchClient batchCli, CloudJobSchedule boundJobSchedule, string sharedPool, IEnumerable<ResourceFile> correctResFiles)
        {
            // need this often enough lets just pull it out
            string jobId = boundJobSchedule.ExecutionInformation.RecentJob.Id;

            PoolOperations poolOps = batchCli.PoolOperations;
            JobScheduleOperations jobScheduleOperations = batchCli.JobScheduleOperations;
            {
                DateTime beforeJobPrepRuns = DateTime.UtcNow;  // used to test start time

                // need a task to force JobPrep
                CloudTask sillyTask = new CloudTask("forceJobPrep", "cmd /c hostname");

                // add the task
                batchCli.JobOperations.AddTask(jobId, sillyTask);

                bool keepLooking = true;

                while (keepLooking)
                {
                    testOutputHelper.WriteLine("Waiting for task to be scheduled.");

                    foreach (CloudTask curTask in batchCli.JobOperations.GetJob(jobId).ListTasks())
                    {
                        if (curTask.State != TaskState.Active)
                        {
                            keepLooking = false;

                            break;
                        }
                    }

                    Thread.Sleep(1000);
                }

                List<JobPreparationAndReleaseTaskExecutionInformation> jobPrepStatusList = new List<JobPreparationAndReleaseTaskExecutionInformation>();
                while (jobPrepStatusList.Count == 0)
                {
                    jobPrepStatusList = batchCli.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId).ToList();
                }
                JobPreparationAndReleaseTaskExecutionInformation jptei = jobPrepStatusList.First();

                ComputeNode victimComputeNodeRunningPrepAndRelease = poolOps.GetComputeNode(sharedPool, jptei.ComputeNodeId);

                // job prep tests
                {
                    Assert.NotNull(jptei);
                    Assert.Equal(0, jptei.JobPreparationTaskExecutionInformation.RetryCount);
                    Assert.True(beforeJobPrepRuns < jptei.JobPreparationTaskExecutionInformation.StartTime + TimeSpan.FromSeconds(10));  // test that the start time is rational -- 10s of wiggle room
                    Assert.Null(jptei.JobPreparationTaskExecutionInformation.FailureInformation);

                    testOutputHelper.WriteLine("");
                    testOutputHelper.WriteLine("listing files for compute node: " + victimComputeNodeRunningPrepAndRelease.Id);

                    // fiter the list so reduce noise
                    List<NodeFile> filteredListJobPrep = new List<NodeFile>();

                    foreach (NodeFile curTF in victimComputeNodeRunningPrepAndRelease.ListNodeFiles(recursive: true))
                    {
                        // filter on the jsId since we only run one job per job in this test.
                        if (curTF.Path.IndexOf(boundJobSchedule.Id, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            testOutputHelper.WriteLine("    name:" + curTF.Path + ", size: " + ((curTF.IsDirectory.HasValue && curTF.IsDirectory.Value) ? "<dir>" : curTF.Properties.ContentLength.ToString()));

                            filteredListJobPrep.Add(curTF);
                        }
                    }

                    // confirm resource files made it
                    foreach (ResourceFile curCorrectRF in correctResFiles)
                    {
                        bool found = false;

                        foreach (NodeFile curTF in filteredListJobPrep)
                        {
                            // look for the resfile filepath in the taskfile name
                            found |= curTF.Path.IndexOf(curCorrectRF.FilePath, StringComparison.InvariantCultureIgnoreCase) >= 0;
                        }
                        Assert.True(found, "Looking for resourcefile: " + curCorrectRF.FilePath);
                    }

                    // poll for completion
                    while (JobPreparationTaskState.Completed != jptei.JobPreparationTaskExecutionInformation.State)
                    {
                        testOutputHelper.WriteLine("waiting for jopPrep to complete");
                        Thread.Sleep(2000);

                        // refresh the state info
                        ODATADetailLevel detailLevel = new ODATADetailLevel() { FilterClause = string.Format("nodeId eq '{0}'", victimComputeNodeRunningPrepAndRelease.Id) };
                        jobPrepStatusList = batchCli.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId, detailLevel: detailLevel).ToList();

                        jptei = jobPrepStatusList.First();
                    }

                    // need success
                    Assert.Equal(0, jptei.JobPreparationTaskExecutionInformation.ExitCode);

                    // check stdout to confirm prep ran

                    //Why do I have to use the hardcoded string job-1 here...?
                    string stdOutFileSpec = Path.Combine("workitems", boundJobSchedule.Id, "job-1", boundJobSchedule.JobSpecification.JobPreparationTask.Id, Constants.StandardOutFileName);
                    string stdOut = victimComputeNodeRunningPrepAndRelease.GetNodeFile(stdOutFileSpec).ReadAsString();

                    string stdErrFileSpec = Path.Combine("workitems", boundJobSchedule.Id, "job-1", boundJobSchedule.JobSpecification.JobPreparationTask.Id, Constants.StandardErrorFileName);

                    string stdErr = string.Empty;

                    try
                    {
                        stdErr = victimComputeNodeRunningPrepAndRelease.GetNodeFile(stdErrFileSpec).ReadAsString();
                    }
                    catch (Exception)
                    {
                        //Swallow any exceptions here since stderr may not exist
                    }

                    testOutputHelper.WriteLine(stdOut);
                    testOutputHelper.WriteLine(stdErr);

                    Assert.True(!string.IsNullOrWhiteSpace(stdOut));
                    Assert.Contains("jobpreparation", stdOut.ToLower());
                }

                // jobPrep tests completed.  let JobPrep complete and task run and wait for JobRelease

                TaskStateMonitor tsm = batchCli.Utilities.CreateTaskStateMonitor();

                // spam/logging interceptor
                Protocol.RequestInterceptor consoleSpammer =
                                                new Protocol.RequestInterceptor((x) =>
                                                {
                                                    testOutputHelper.WriteLine("TestGetPrepReleaseStatusCalls: waiting for JobPrep and task to complete");

                                                    ODATADetailLevel detailLevel = new ODATADetailLevel() { FilterClause = string.Format("nodeId eq '{0}'", victimComputeNodeRunningPrepAndRelease.Id) };
                                                    jobPrepStatusList = batchCli.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId, detailLevel: detailLevel).ToList();
                                                    JobPreparationAndReleaseTaskExecutionInformation jpteiInterceptor =
                                                        jobPrepStatusList.First();

                                                    testOutputHelper.WriteLine("    JobPrep.State: " + jpteiInterceptor.JobPreparationTaskExecutionInformation.State);

                                                    testOutputHelper.WriteLine("");
                                                });

                // waiting for the task to complete means so JobRelease is run.
                tsm.WaitAll(
                    batchCli.JobOperations.GetJob(jobId).ListTasks(additionalBehaviors: new[] { consoleSpammer }),
                    TaskState.Completed,
                    TimeSpan.FromSeconds(120),
                    additionalBehaviors: new[] { consoleSpammer });
                
                // trigger JobRelease
                batchCli.JobOperations.TerminateJob(jobId, terminateReason: "die! I want JobRelease to run!");

                // now that the task has competed, we are racing with the JobRelease... but it is sleeping so we can can catch it
                while (true)
                {
                    ODATADetailLevel detailLevel = new ODATADetailLevel() { FilterClause = string.Format("nodeId eq '{0}'", victimComputeNodeRunningPrepAndRelease.Id) };
                    jobPrepStatusList = batchCli.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId, detailLevel: detailLevel).ToList();
                    JobPreparationAndReleaseTaskExecutionInformation jrtei = jobPrepStatusList.FirstOrDefault();

                    if ((jrtei == null) || (null == jrtei.JobReleaseTaskExecutionInformation))
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Assert.NotNull(jrtei);
                        if (jrtei.JobReleaseTaskExecutionInformation.State != JobReleaseTaskState.Completed)
                        {
                            testOutputHelper.WriteLine("JobReleaseTask state is: " + jrtei.JobReleaseTaskExecutionInformation.State);

                            Thread.Sleep(5000);
                        }
                        else
                        {
                            testOutputHelper.WriteLine("JobRelease commpleted!");

                            // we are done
                            break;
                        }
                    }
                }
            }
        }

        private static void AssertGoodJobPrepTaskOM(JobPreparationTask jobPrep)
        {
            Assert.Equal(JobPrepCommandLine, jobPrep.CommandLine);

            Assert.NotNull(jobPrep.EnvironmentSettings);
            Assert.Equal(1, jobPrep.EnvironmentSettings.Count);
            Assert.Equal(JobPrepEnvSettingOM.Name, jobPrep.EnvironmentSettings[0].Name);
            Assert.Equal(JobPrepEnvSettingOM.Value, jobPrep.EnvironmentSettings[0].Value);

            Assert.Equal(JobPrepId, jobPrep.Id);
            Assert.Equal(JobPrepRerunOnComputeNodeRebootAfterSuccess, jobPrep.RerunOnComputeNodeRebootAfterSuccess);
            Assert.Equal(JobPrepUserSpec.ElevationLevel, jobPrep.UserIdentity.AutoUser.ElevationLevel);
            Assert.Equal(JobPrepUserSpec.Scope, jobPrep.UserIdentity.AutoUser.Scope);

            Assert.Equal(JobPrepTaskConstraintsOM.MaxTaskRetryCount, jobPrep.Constraints.MaxTaskRetryCount);
            Assert.Equal(JobPrepTaskConstraintsOM.MaxWallClockTime, jobPrep.Constraints.MaxWallClockTime);
            Assert.Equal(JobPrepTaskConstraintsOM.RetentionTime, jobPrep.Constraints.RetentionTime);

            Assert.Equal(JobPrepWaitForSuccessCreate, jobPrep.WaitForSuccess);

            // TODO:  assert on resourcefiles and contents therein
        }

        private static void AssertGoodJobReleaseTaskOM(JobReleaseTask jobRelease)
        {
            Assert.Equal(JobReleaseTaskCommandLine, jobRelease.CommandLine);

            Assert.NotNull(jobRelease.EnvironmentSettings);
            Assert.Equal(1, jobRelease.EnvironmentSettings.Count);
            Assert.Equal(JobRelEnvSettingOM.Name, jobRelease.EnvironmentSettings[0].Name);
            Assert.Equal(JobRelEnvSettingOM.Value, jobRelease.EnvironmentSettings[0].Value);

            Assert.Equal(JobRelMaxWallClockTime, jobRelease.MaxWallClockTime);
            Assert.Equal(JobRelId, jobRelease.Id);
            Assert.Equal(JobRelRetentionTime, jobRelease.RetentionTime);
            Assert.Equal(JobRelUserSpec.ElevationLevel, jobRelease.UserIdentity.AutoUser.ElevationLevel);
            Assert.Equal(JobRelUserSpec.Scope, jobRelease.UserIdentity.AutoUser.Scope);
        }

        private static void AssertGoodCommonEnvSettingsOM(IList<EnvironmentSetting> jobCommonEnvSettings)
        {
            Assert.Equal(1, jobCommonEnvSettings.Count);
            Assert.Equal(JobCommonEnvSettingOM.Name, jobCommonEnvSettings[0].Name);
            Assert.Equal(JobCommonEnvSettingOM.Value, jobCommonEnvSettings[0].Value);
        }

        private static void AssertGoodResourceFiles(IEnumerable<ResourceFile> correctValues, IEnumerable<ResourceFile> unknownValues)
        {
            Assert.NotNull(correctValues);
            Assert.NotNull(unknownValues);

            IList<ResourceFile> correctIList = correctValues.ToList();
            IList<ResourceFile> unknownIList = unknownValues.ToList();

            //Assert.Equal(correctValues, unknownValues);

            Assert.Equal(correctIList.Count, unknownIList.Count);

            for (int i = 0; i < correctIList.Count; i++)
            {
                Assert.Equal(correctIList[i].HttpUrl, unknownIList[i].HttpUrl);
                Assert.Equal(correctIList[i].FilePath, unknownIList[i].FilePath);
            }
        }

        private static string CraftTimeString()
        {
            string uniqueLetsHope = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fff");

            return uniqueLetsHope;
        }


        // an interceptor based call timer
        internal class CallTimerViaInterceptors
        {
            private readonly Stopwatch stopwatch = new Stopwatch();

            internal Protocol.RequestInterceptor ReqInterceptor;
            internal Protocol.ResponseInterceptor ResInterceptor;

            private void RequestInterceptHandler(Protocol.IBatchRequest request)
            {
                stopwatch.Reset();
                stopwatch.Start();
            }

            private Task<IAzureOperationResponse> ResponseInterceptHandler(IAzureOperationResponse response, Protocol.IBatchRequest request)
            {
                stopwatch.Stop();

                return Task.FromResult(response);
            }

            internal CallTimerViaInterceptors()
            {
                ReqInterceptor = new Protocol.RequestInterceptor(RequestInterceptHandler);
                ResInterceptor = new Protocol.ResponseInterceptor(ResponseInterceptHandler);
            }
        }

        private static IList<ResourceFile> UploadFilesMakeResFiles(StagingStorageAccount stagingCreds)
        {
            // use a dummy task to stage fsome files and generate resource files
            CloudTask myTask = new CloudTask(id: "CountWordsTask", commandline: @"cmd /c dir /s .. & dir & type localwords.txt");

            // first we have local files that we want pushed to the compute node before the commandline is invoked
            FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, stagingCreds);                // use "default" mapping to base name of local file

            // add in the files to stage
            myTask.FilesToStage = new List<IFileStagingProvider>
            {
                wordsDotText
            };

            // trigger file staging
            myTask.StageFiles();

            // return the resolved resource files
            return myTask.ResourceFiles;
        }

        private void OutputFailureInfo(TaskFailureInformation failureInfo)
        {
            testOutputHelper.WriteLine("JP Failure Info:");
            testOutputHelper.WriteLine("    category: " + failureInfo.Category);
            testOutputHelper.WriteLine("    code: " + failureInfo.Code);
            testOutputHelper.WriteLine("    details:" + (null == failureInfo.Details ? " <null>" : string.Empty));

            if (null != failureInfo.Details)
            {
                foreach (NameValuePair curDetail in failureInfo.Details)
                {
                    testOutputHelper.WriteLine("        name: " + curDetail.Name + ", value: " + curDetail.Value);
                }
            }

            testOutputHelper.WriteLine("    message: " + failureInfo.Message);
        }

        #endregion
    }
}
