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

extern alias fs;

﻿namespace BatchClientIntegrationTests
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
    using StagingStorageAccount = fs::Microsoft.Azure.Batch.FileStaging.StagingStorageAccount;  // Temporary bridge until the Batch core NuGet without file staging is published
    using FileToStage = fs::Microsoft.Azure.Batch.FileStaging.FileToStage;  // Temporary bridge until the Batch core NuGet without file staging is published
    using Microsoft.Rest;
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
        private const bool JobPrepRunElevated = true;
        private static readonly TaskConstraints JobPrepTaskConstraintsOM = new TaskConstraints(maxTaskRetryCount: 4, maxWallClockTime: TimeSpan.FromHours(1.0), retentionTime: TimeSpan.FromHours(2.0));
        private const bool JobPrepWaitForSuccessCreate = false;  // true is the default so try false even though its crazy
        private const bool JobPrepWaitForSuccessUpdate = false;  // we need WfS so we can test the exeinfo.state
        private const string JobReleaseTaskCommandLine = @"cmd /c dir /s .. & echo JobRelease Task!! & dir & type localwords.txt";
        private static readonly EnvironmentSetting JobRelEnvSettingOM = new EnvironmentSetting(name: "JobReleaseEnvSetting00Name", value: "JobReleaseEnvSetting00Value");
        private static readonly TimeSpan JobRelMaxWallClockTime = TimeSpan.FromMinutes(5.0);
        private const string JobRelId = "AddJobReleaseOM";
        private static readonly TimeSpan JobRelRetentionTime = TimeSpan.FromMinutes(10.0);
        private const bool JobRelRunElevated = true;
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
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void TestOMJobSpecAndRelease()
        {
            Action test = () =>
            {
                StagingStorageAccount stagingCreds = TestUtilities.GetStorageCredentialsFromEnvironment();
                using (BatchClient client = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jsId = "JobPrepAndRelease-" + /* "OM-static-c" */ "dynamic-" + CraftTimeString() + "-" + TestUtilities.GetMyName();

                    try
                    {
                        // increase request timeout interceptor
                        Protocol.RequestInterceptor increaseTimeoutInterceptor =
                            new Protocol.RequestInterceptor((x) =>
                            {
                                this.testOutputHelper.WriteLine("TestOMJobSpecAndRelease: setting request timeout.  Request type: " + x.GetType().ToString() + ", ClientRequestID: " + x.Options.ClientRequestId);
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
                            unboundJobSchedule.JobSpecification.PoolInformation.PoolId = this.poolFixture.PoolId;
                            unboundJobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(3) };

                            // add the jobPrep task to the job schedule
                            {
                                JobPreparationTask prep = new JobPreparationTask(JobPrepCommandLine);
                                unboundJobSchedule.JobSpecification.JobPreparationTask = prep;

                                List<EnvironmentSetting> prepEnvSettings = new List<EnvironmentSetting>();
                                prepEnvSettings.Add(JobPrepEnvSettingOM);
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

                                prep.RunElevated = JobPrepRunElevated;
                                prep.Constraints = JobPrepTaskConstraintsOM;
                                prep.WaitForSuccess = JobPrepWaitForSuccessCreate;
                            }

                            // add a jobRelease task to the job schedule
                            {
                                JobReleaseTask relTask = new JobReleaseTask(JobReleaseTaskCommandLine);
                                unboundJobSchedule.JobSpecification.JobReleaseTask = relTask;
                                
                                List<EnvironmentSetting> relEnvSettings = new List<EnvironmentSetting>();
                                relEnvSettings.Add(JobRelEnvSettingOM);
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
                                relTask.RunElevated = JobRelRunElevated;
                            }

                            // set JobCommonEnvSettings
                            {
                                List<EnvironmentSetting> jobCommonES = new List<EnvironmentSetting>();

                                jobCommonES.Add(JobCommonEnvSettingOM);

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

                        TestGetPrepReleaseStatusCalls(client, updatedJobSchedule, this.poolFixture.PoolId, resFiles);
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeleteJobScheduleIfExistsAsync(client, jsId).Wait();
                    }
                }

            };

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
                    this.testOutputHelper.WriteLine("Waiting for task to be scheduled.");

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
                    Assert.Null(jptei.JobPreparationTaskExecutionInformation.SchedulingError);

                    this.testOutputHelper.WriteLine("");
                    this.testOutputHelper.WriteLine("listing files for compute node: " + victimComputeNodeRunningPrepAndRelease.Id);

                    // fiter the list so reduce noise
                    List<NodeFile> filteredListJobPrep = new List<NodeFile>();

                    foreach (NodeFile curTF in victimComputeNodeRunningPrepAndRelease.ListNodeFiles(recursive: true))
                    {
                        // filter on the jsId since we only run one job per job in this test.
                        if (curTF.Name.IndexOf(boundJobSchedule.Id, StringComparison.InvariantCultureIgnoreCase) >= 0)
                        {
                            this.testOutputHelper.WriteLine("    name:" + curTF.Name + ", size: " + ((curTF.IsDirectory.HasValue && curTF.IsDirectory.Value) ? "<dir>" : curTF.Properties.ContentLength.ToString()));

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
                            found |= curTF.Name.IndexOf(curCorrectRF.FilePath, StringComparison.InvariantCultureIgnoreCase) >= 0;
                        }
                        Assert.True(found, "Looking for resourcefile: " + curCorrectRF.FilePath);
                    }

                    // poll for completion
                    while (JobPreparationTaskState.Completed != jptei.JobPreparationTaskExecutionInformation.State)
                    {
                        this.testOutputHelper.WriteLine("waiting for jopPrep to complete");
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

                    this.testOutputHelper.WriteLine(stdOut);
                    this.testOutputHelper.WriteLine(stdErr);

                    Assert.True(!string.IsNullOrWhiteSpace(stdOut));
                    Assert.Contains("jobpreparation", stdOut.ToLower());
                }

                // jobPrep tests completed.  let JobPrep complete and task run and wait for JobRelease

                TaskStateMonitor tsm = batchCli.Utilities.CreateTaskStateMonitor();

                // spam/logging interceptor
                Protocol.RequestInterceptor consoleSpammer =
                                                new Protocol.RequestInterceptor((x) =>
                                                {
                                                    this.testOutputHelper.WriteLine("TestGetPrepReleaseStatusCalls: waiting for JobPrep and task to complete");

                                                    ODATADetailLevel detailLevel = new ODATADetailLevel() { FilterClause = string.Format("nodeId eq '{0}'", victimComputeNodeRunningPrepAndRelease.Id) };
                                                    jobPrepStatusList = batchCli.JobOperations.ListJobPreparationAndReleaseTaskStatus(jobId, detailLevel: detailLevel).ToList();
                                                    JobPreparationAndReleaseTaskExecutionInformation jpteiInterceptor =
                                                        jobPrepStatusList.First();

                                                    this.testOutputHelper.WriteLine("    JobPrep.State: " + jpteiInterceptor.JobPreparationTaskExecutionInformation.State);

                                                    this.testOutputHelper.WriteLine("");
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
                            this.testOutputHelper.WriteLine("JobReleaseTask state is: " + jrtei.JobReleaseTaskExecutionInformation.State);

                            Thread.Sleep(5000);
                        }
                        else
                        {
                            this.testOutputHelper.WriteLine("JobRelease commpleted!");

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
            Assert.Equal(JobPrepRunElevated, jobPrep.RunElevated);

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
            Assert.Equal(JobRelRunElevated, jobRelease.RunElevated);
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
                Assert.Equal(correctIList[i].BlobSource, unknownIList[i].BlobSource);
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
                this.stopwatch.Reset();
                this.stopwatch.Start();
            }

            private Task<IAzureOperationResponse> ResponseInterceptHandler(IAzureOperationResponse response, Protocol.IBatchRequest request)
            {
                this.stopwatch.Stop();

                return Task.FromResult(response);
            }

            internal CallTimerViaInterceptors()
            {
                this.ReqInterceptor = new Protocol.RequestInterceptor(this.RequestInterceptHandler);
                this.ResInterceptor = new Protocol.ResponseInterceptor(this.ResponseInterceptHandler);
            }
        }

        private static IList<ResourceFile> UploadFilesMakeResFiles(StagingStorageAccount stagingCreds)
        {
            // use a dummy task to stage fsome files and generate resource files
            CloudTask myTask = new CloudTask(id: "CountWordsTask", commandline: @"cmd /c dir /s .. & dir & type localwords.txt");

            // first we have local files that we want pushed to the compute node before the commandline is invoked
            FileToStage wordsDotText = new FileToStage(Resources.LocalWordsDotText, stagingCreds);                // use "default" mapping to base name of local file

            // add in the files to stage
            myTask.FilesToStage = new List<IFileStagingProvider>();
            myTask.FilesToStage.Add(wordsDotText);

            // trigger file staging
            myTask.StageFiles();

            // return the resolved resource files
            return myTask.ResourceFiles;
        }

        #endregion
    }
}
