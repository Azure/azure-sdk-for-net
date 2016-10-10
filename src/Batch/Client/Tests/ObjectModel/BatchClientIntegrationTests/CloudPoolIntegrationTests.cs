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

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class CloudPoolIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(5);
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);

        public CloudPoolIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //Note -- this class does not and should not need a pool fixture
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task PoolPatch()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    string poolId = "TestPatchPool-" + TestUtilities.GetMyName();
                    const string metadataKey = "Foo";
                    const string metadataValue = "Bar";
                    const string startTaskCommandLine = "cmd /c dir";

                    try
                    {
                        CloudPool pool = batchCli.PoolOperations.CreatePool(
                            poolId,
                            PoolFixture.VMSize,
                            new CloudServiceConfiguration(PoolFixture.OSFamily),
                            targetDedicated: 0);

                        await pool.CommitAsync().ConfigureAwait(false);
                        await pool.RefreshAsync().ConfigureAwait(false);

                        pool.StartTask = new StartTask(startTaskCommandLine);
                        pool.Metadata = new List<MetadataItem>()
                            {
                                new MetadataItem(metadataKey, metadataValue)
                            };

                        await pool.CommitChangesAsync().ConfigureAwait(false);

                        await pool.RefreshAsync().ConfigureAwait(false);

                        Assert.Equal(startTaskCommandLine, pool.StartTask.CommandLine);
                        Assert.Equal(metadataKey, pool.Metadata.Single().Name);
                        Assert.Equal(metadataValue, pool.Metadata.Single().Value);
                    }
                    finally
                    {
                        await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1505248SupportMultipleTasksPerComputeNodeOnPoolAndPoolUserSpec()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    // create a pool with the two new props
                    string poolId = "Bug1505248SupportMultipleTasksPerComputeNode-pool-" + TestUtilities.GetMyName();
                    try
                    {
                        CloudPool newPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: 0);

                        newPool.MaxTasksPerComputeNode = 3;

                        newPool.TaskSchedulingPolicy =
                            new TaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

                        newPool.Commit();

                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        Assert.Equal(3, boundPool.MaxTasksPerComputeNode);
                        Assert.Equal(ComputeNodeFillType.Pack, boundPool.TaskSchedulingPolicy.ComputeNodeFillType);
                    }
                    finally
                    {
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }

                    string jobId = "Bug1505248SupportMultipleTasksPerComputeNode-Job-" + TestUtilities.GetMyName();
                    try
                    {
                        // create a job with new props set on pooluserspec
                        {
                            CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                            AutoPoolSpecification unboundAPS = new AutoPoolSpecification();
                            PoolSpecification unboundPS = new PoolSpecification();
                            unboundJob.PoolInformation.AutoPoolSpecification = unboundAPS;
                            unboundAPS.PoolSpecification = unboundPS;

                            unboundPS.MaxTasksPerComputeNode = 3;
                            unboundAPS.PoolSpecification.TargetDedicated = 0; // don't use up compute nodes for this test
                            unboundPS.TaskSchedulingPolicy = new TaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

                            // required but unrelated to test
                            unboundPS.VirtualMachineSize = PoolFixture.VMSize;

                            unboundPS.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);

                            unboundAPS.PoolLifetimeOption = Microsoft.Azure.Batch.Common.PoolLifetimeOption.Job;

                            unboundJob.Commit();
                        }

                        // confirm props were set

                        CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                        PoolInformation poolInformation = boundJob.PoolInformation;
                        AutoPoolSpecification boundAPS = poolInformation.AutoPoolSpecification;
                        PoolSpecification boundPUS = boundAPS.PoolSpecification;

                        Assert.Equal(3, boundPUS.MaxTasksPerComputeNode);
                        Assert.Equal(ComputeNodeFillType.Pack, boundPUS.TaskSchedulingPolicy.ComputeNodeFillType);

                        // change the props

                        //TODO: Possible change this test to use a JobSchedule here?
                        //boundPUS.MaxTasksPerComputeNode = 2;
                        //boundPUS.TaskSchedulingPolicy = new TaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);

                        //boundJob.Commit();
                        //boundJob.Refresh();

                        //boundAPS = boundJob.PoolInformation.AutoPoolSpecification;
                        //boundPUS = boundAPS.PoolSpecification;

                        //Debug.Assert(2 == boundPUS.MaxTasksPerComputeNode);
                        //Debug.Assert(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread == boundPUS.TaskSchedulingPolicy.ComputeNodeFillType);

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
        public void Bug1587303StartTaskResourceFilesNotPushedToServer()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "Bug1587303Pool-" + TestUtilities.GetMyName();

                    const string resourceFileSas = "http://azure.com";
                    const string resourceFileValue = "count0ResFiles.exe";

                    const string envSettingName = "envName";
                    const string envSettingValue = "envValue";

                    try
                    {
                        // create a pool with env-settings and ResFiles
                        {
                            CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: 0);

                            StartTask st = new StartTask("dir");

                            MakeResourceFiles(st, resourceFileSas, resourceFileValue);
                            AddEnviornmentSettingsToStartTask(st, envSettingName, envSettingValue);

                            // set the pool's start task so the collections get pushed
                            myPool.StartTask = st;

                            myPool.Commit();
                        }

                        // confirm pool has correct values
                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        CheckResourceFiles(boundPool.StartTask, resourceFileSas, resourceFileValue);
                        CheckEnvironmentSettingsOnStartTask(boundPool.StartTask, envSettingName, envSettingValue);

                        // clear the collections
                        boundPool.StartTask.EnvironmentSettings = null;
                        boundPool.StartTask.ResourceFiles = null;

                        boundPool.Commit();
                        boundPool.Refresh();

                        StartTask boundST = boundPool.StartTask;

                        // confirm the collections are cleared/null
                        Assert.Null(boundST.ResourceFiles);
                        Assert.Null(boundST.EnvironmentSettings);

                        // set the collections again
                        MakeResourceFiles(boundST, resourceFileSas, resourceFileValue);
                        AddEnviornmentSettingsToStartTask(boundST, envSettingName, envSettingValue);

                        boundPool.Commit();
                        boundPool.Refresh();

                        // confirm the collectsion are correctly re-established
                        CheckResourceFiles(boundPool.StartTask, resourceFileSas, resourceFileValue);
                        CheckEnvironmentSettingsOnStartTask(boundPool.StartTask, envSettingName, envSettingValue);

                        //set collections to empty-but-non-null collections
                        IList<ResourceFile> emptyResfiles = new List<ResourceFile>();
                        IList<EnvironmentSetting> emptyEnvSettings = new List<EnvironmentSetting>();

                        boundPool.StartTask.EnvironmentSettings = emptyEnvSettings;
                        boundPool.StartTask.ResourceFiles = emptyResfiles;

                        boundPool.Commit();
                        boundPool.Refresh();

                        boundST = boundPool.StartTask;

                        var count0ResFiles = boundPool.StartTask.ResourceFiles;
                        var count0EnvSettings = boundPool.StartTask.EnvironmentSettings;

                        // confirm that the collections are non-null and have count-0
                        Assert.NotNull(count0ResFiles);
                        Assert.NotNull(count0EnvSettings);
                        Assert.Equal(0, count0ResFiles.Count());
                        Assert.Equal(0, count0EnvSettings.Count());

                        //clean up
                        boundPool.Delete();

                        System.Threading.Thread.Sleep(5000); // wait for pool to be deleted

                        // check pool create with empty-but-non-null collections
                        {
                            CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: 0);

                            StartTask st = new StartTask("dir");
                            // use the empty collections from above
                            st.ResourceFiles = emptyResfiles;
                            st.EnvironmentSettings = emptyEnvSettings;

                            // set the pool's start task so the collections get pushed
                            myPool.StartTask = st;

                            myPool.Commit();
                        }

                        boundPool = batchCli.PoolOperations.GetPool(poolId);
                        boundST = boundPool.StartTask;

                        count0ResFiles = boundPool.StartTask.ResourceFiles;
                        count0EnvSettings = boundPool.StartTask.EnvironmentSettings;

                        // confirm that the collections are non-null and have count-0
                        Assert.NotNull(count0ResFiles);
                        Assert.NotNull(count0EnvSettings);
                        Assert.Equal(0, count0ResFiles.Count());
                        Assert.Equal(0, count0EnvSettings.Count());
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1433123PoolMissingResizeTimeout()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "Bug1433123PoolMissingResizeTimeout-" + TestUtilities.GetMyName();

                    try
                    {
                        TimeSpan referenceRST = TimeSpan.FromMinutes(5);

                        // create a pool with env-settings and ResFiles
                        {
                            CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: 0);

                            // set the reference value
                            myPool.ResizeTimeout = referenceRST;

                            myPool.Commit();
                        }

                        // confirm pool has correct values
                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        // confirm value is correct
                        Assert.Equal(referenceRST, boundPool.ResizeTimeout);

                        // confirm constraint does not allow changes to bound object

                        TestUtilities.AssertThrows<InvalidOperationException>(() => boundPool.ResizeTimeout = TimeSpan.FromMinutes(1));
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1656475PoolLifetimeOption()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jsId = "Bug1656475PoolLifetimeOption-" + TestUtilities.GetMyName();

                    try
                    {
                        {
                            CloudJobSchedule unboundJobSchedule = batchCli.JobScheduleOperations.CreateJobSchedule();
                            unboundJobSchedule.Schedule = new Schedule() { RecurrenceInterval = TimeSpan.FromMinutes(10) };
                            unboundJobSchedule.Id = jsId;

                            AutoPoolSpecification iaps = new AutoPoolSpecification();

                            // test that it can be read from unbound/unset object
                            PoolLifetimeOption defaultVal = iaps.PoolLifetimeOption;

                            // test it can be set on unbound and read back
                            iaps.PoolLifetimeOption = PoolLifetimeOption.JobSchedule;

                            // read it back and confirm value
                            Assert.Equal(PoolLifetimeOption.JobSchedule, iaps.PoolLifetimeOption);

                            unboundJobSchedule.JobSpecification = new JobSpecification(new PoolInformation() { AutoPoolSpecification = iaps });

                            // make ias viable for adding the wi
                            iaps.AutoPoolIdPrefix = Microsoft.Azure.Batch.Constants.DefaultConveniencePrefix + TestUtilities.GetMyName();

                            PoolSpecification ips = new PoolSpecification();

                            iaps.PoolSpecification = ips;

                            ips.TargetDedicated = 0;
                            ips.VirtualMachineSize = PoolFixture.VMSize;

                            ips.CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily);

                            unboundJobSchedule.Commit();
                        }

                        CloudJobSchedule boundJobSchedule = batchCli.JobScheduleOperations.GetJobSchedule(jsId);

                        // confirm the PLO is set correctly on bound WI
                        Assert.NotNull(boundJobSchedule);
                        Assert.NotNull(boundJobSchedule.JobSpecification);
                        Assert.NotNull(boundJobSchedule.JobSpecification.PoolInformation);
                        Assert.NotNull(boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification);

                        AutoPoolSpecification boundIAPS = boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification;

                        Assert.Equal(PoolLifetimeOption.JobSchedule, boundIAPS.PoolLifetimeOption);

                        // in phase 1 PLO is read-only on bound WI/APS so no tests to change it here
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeleteJobScheduleIfExistsAsync(batchCli, jsId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void Bug1432812SetAutoScaleMissingOnPoolPoolMgr()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "Bug1432812-" + TestUtilities.GetMyName();
                    const string poolASFormulaOrig = "$TargetDedicated = 1;";
                    const string poolASFormula2 = "$TargetDedicated=2;";
                    // craft exactly how it would be returned by Evaluate so indexof can work

                    try
                    {
                        // create a pool.. empty for now
                        {
                            CloudPool unboundPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));
                            
                            unboundPool.AutoScaleEnabled = true;
                            unboundPool.AutoScaleFormula = poolASFormulaOrig;

                            unboundPool.Commit();
                        }

                        // EvaluteAutoScale
                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        Assert.True(boundPool.AutoScaleEnabled.HasValue);
                        Assert.True(boundPool.AutoScaleEnabled.Value);
                        Assert.Equal(poolASFormulaOrig, boundPool.AutoScaleFormula);

                        AutoScaleRun eval = boundPool.EvaluateAutoScale(poolASFormula2);

                        Assert.Contains(poolASFormula2, eval.Results);

                        // DisableAutoScale
                        boundPool.DisableAutoScale();

                        boundPool.Refresh();

                        // autoscale should be disabled now
                        Assert.True(boundPool.AutoScaleEnabled.HasValue);
                        Assert.False(boundPool.AutoScaleEnabled.Value);

                        // EnableAutoScale

                        while (AllocationState.Steady != boundPool.AllocationState)
                        {
                            this.testOutputHelper.WriteLine("Bug1432812SetAutoScaleMissingOnPoolPoolMgr waiting for pool to be steady before EnableAutoScale call.");

                            System.Threading.Thread.Sleep(5000);

                            boundPool.Refresh();
                        }

                        boundPool.EnableAutoScale(poolASFormula2);

                        boundPool.Refresh();

                        // confirm is enabled and formula has correct value

                        Assert.True(boundPool.AutoScaleEnabled.HasValue);
                        Assert.True(boundPool.AutoScaleEnabled.Value);
                        Assert.Equal(poolASFormula2, boundPool.AutoScaleFormula);

                    }
                    finally
                    {
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1432819UpdateImplOnCloudPool()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "Bug1432819-" + TestUtilities.GetMyName();
                    try
                    {
                        CloudPool unboundPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: 0);
                        unboundPool.Commit();

                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);
                        IList<MetadataItem> changedMDI = new List<MetadataItem> { new MetadataItem("name", "value") };
                        boundPool.Metadata = changedMDI;
                        boundPool.Commit();

                        CloudPool boundPool2 = batchCli.PoolOperations.GetPool(poolId);

                        Assert.NotNull(boundPool2.Metadata);

                        // confirm the pool was updated
                        foreach (MetadataItem curMDI in boundPool2.Metadata)
                        {
                            Assert.Equal("name", curMDI.Name);
                            Assert.Equal("value", curMDI.Value);
                        }
                    }
                    finally
                    {
                        // cleanup
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestListPoolUsageMetrics()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    // test via faking data
                    const int dataEgressGiB = 5;
                    const int dataIngressGiB = 4;
                    DateTime endTime = DateTime.UtcNow.AddYears(-1);
                    DateTime startTime = DateTime.UtcNow;
                    const int totalCoreHours = 1;
                    const string virtualMachineSize = "really really big";

                    List<Protocol.Models.PoolUsageMetrics> pums = new List<Protocol.Models.PoolUsageMetrics>();

                    // create some data to return
                    for (int i = 0; i < 4; i++)
                    {
                        string id = "my fancy pool id " + i.ToString();
                        Protocol.Models.PoolUsageMetrics newPum = new Protocol.Models.PoolUsageMetrics()
                        {
                            PoolId = id,
                            DataEgressGiB = dataEgressGiB,
                            DataIngressGiB = dataIngressGiB,
                            EndTime = endTime,
                            StartTime = startTime,
                            TotalCoreHours = totalCoreHours,
                            VmSize = virtualMachineSize
                        };

                        pums.Add(newPum);
                    }

                    // our injector of fake data
                    TestListPoolUsageMetricsFakesYieldInjector injectsTheFakeData = new TestListPoolUsageMetricsFakesYieldInjector(pums);

                    // trigger the call and get our own data back to be tested
                    List<Microsoft.Azure.Batch.PoolUsageMetrics> clList = batchCli.PoolOperations.ListPoolUsageMetrics(additionalBehaviors: new[] { injectsTheFakeData }).ToList();

                    // test that our data are honored

                    for (int j = 0; j < 4; j++)
                    {
                        string id = "my fancy pool id " + j.ToString();
                        Assert.Equal(id, clList[j].PoolId);
                        Assert.Equal(dataEgressGiB, clList[j].DataEgressGiB);
                        Assert.Equal(dataIngressGiB, clList[j].DataIngressGiB);
                        Assert.Equal(endTime, clList[j].EndTime);
                        Assert.Equal(startTime, clList[j].StartTime);
                        Assert.Equal(totalCoreHours, clList[j].TotalCoreHours);
                        Assert.Equal(virtualMachineSize, clList[j].VirtualMachineSize);
                    }

                    List<PoolUsageMetrics> list = batchCli.PoolOperations.ListPoolUsageMetrics(DateTime.Now - TimeSpan.FromDays(1)).ToList();
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolObjectResizeStopResize()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "TestPoolObjectResizeStopResize" + TestUtilities.GetMyName();
                    const int targetDedicated = 0;
                    const int newTargetDedicated = 1;
                    try
                    {
                        //Create a pool
                        CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: targetDedicated);
                        pool.Commit();

                        this.testOutputHelper.WriteLine("Created pool {0}", poolId);


                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        //Resize the pool
                        boundPool.Resize(newTargetDedicated);

                        boundPool.Refresh();
                        Assert.Equal(AllocationState.Resizing, boundPool.AllocationState);

                        boundPool.StopResize();
                        boundPool.Refresh();

                        //The pool could be in stopping or steady state
                        Assert.True(boundPool.AllocationState == AllocationState.Steady || boundPool.AllocationState == AllocationState.Stopping);
                    }
                    finally
                    {
                        //Delete the pool
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestPoolAutoscaleVerbs()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "TestPoolAutoscaleVerbs" + TestUtilities.GetMyName();
                    const int targetDedicated = 0;
                    const string autoscaleFormula1 = "$TargetDedicated=0;$NodeDeallocationOption=requeue";
                    const string autoscaleFormula2 = "$TargetDedicated=0;$NodeDeallocationOption=terminate";

                    const string evaluateAutoscaleFormula = "myActiveSamples=$ActiveTasks.GetSample(5);";
                    TimeSpan enableAutoScaleMinimumDelay = TimeSpan.FromSeconds(30);  // compiler says can't be const

                    try
                    {
                        //Create a pool
                        CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated);
                        pool.Commit();

                        CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                        //Enable autoscale (via instance)
                        boundPool.EnableAutoScale(autoscaleFormula1);
                        DateTime utcEarliestCanCallEnableASAgain = DateTime.UtcNow + enableAutoScaleMinimumDelay;

                        boundPool.Refresh();
                        Assert.True(boundPool.AutoScaleEnabled);
                        Assert.Equal(autoscaleFormula1, boundPool.AutoScaleFormula);
                        Assert.NotNull(boundPool.AutoScaleRun);
                        Assert.NotNull(boundPool.AutoScaleRun.Results);
                        Assert.Contains(autoscaleFormula1, boundPool.AutoScaleRun.Results);

                        //Evaluate a different formula
                        AutoScaleRun evaluation = boundPool.EvaluateAutoScale(evaluateAutoscaleFormula);

                        this.testOutputHelper.WriteLine("Autoscale evaluate results: {0}", evaluation.Results);

                        Assert.NotNull(evaluation.Results);
                        Assert.Contains("myActiveSamples", evaluation.Results);

                        //Disable autoscale (via instance)
                        boundPool.DisableAutoScale();
                        boundPool.Refresh();

                        Assert.False(boundPool.AutoScaleEnabled);

                        //Wait for the pool to go to steady state
                        TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(2)).Wait();

                        // about to call EnableAutoScale again, must delay to avoid throttle exception
                        if (DateTime.UtcNow < utcEarliestCanCallEnableASAgain)
                        {
                            TimeSpan delayBeforeNextEnableASCall = utcEarliestCanCallEnableASAgain - DateTime.UtcNow;

                            Thread.Sleep(delayBeforeNextEnableASCall);
                        }

                        //Enable autoscale (via operations)
                        batchCli.PoolOperations.EnableAutoScale(poolId, autoscaleFormula2);
                        boundPool.Refresh();

                        Assert.True(boundPool.AutoScaleEnabled);
                        Assert.Equal(autoscaleFormula2, boundPool.AutoScaleFormula);
                        Assert.NotNull(boundPool.AutoScaleRun);
                        Assert.NotNull(boundPool.AutoScaleRun.Results);
                        Assert.Contains(autoscaleFormula2, boundPool.AutoScaleRun.Results);

                        evaluation = batchCli.PoolOperations.EvaluateAutoScale(poolId, evaluateAutoscaleFormula);

                        this.testOutputHelper.WriteLine("Autoscale evaluate results: {0}", evaluation.Results);

                        Assert.NotNull(evaluation);
                        Assert.Contains("myActiveSamples", evaluation.Results);

                        batchCli.PoolOperations.DisableAutoScale(poolId);
                        boundPool.Refresh();

                        Assert.False(boundPool.AutoScaleEnabled);
                    }
                    finally
                    {
                        //Delete the pool
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestServerRejectsNonExistantVNetWithCorrectError()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "TestPoolVNet" + TestUtilities.GetMyName();
                    const int targetDedicated = 0;
                    string dummySubnetId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ClassicNetwork/virtualNetworks/vnet1/subnets/subnet1",
                        TestCommon.Configuration.BatchSubscription,
                        TestCommon.Configuration.BatchAccountResourceGroup);
                    try
                    {
                        CloudPool pool = batchCli.PoolOperations.CreatePool(
                            poolId,
                            PoolFixture.VMSize,
                            new CloudServiceConfiguration(PoolFixture.OSFamily),
                            targetDedicated);

                        pool.NetworkConfiguration = new NetworkConfiguration()
                            {
                                SubnetId = dummySubnetId
                            };

                        BatchException exception = await TestUtilities.AssertThrowsAsync<BatchException>(async () => await pool.CommitAsync().ConfigureAwait(false)).ConfigureAwait(false);
                        Assert.Equal(BatchErrorCodeStrings.InvalidPropertyValue, exception.RequestInformation.BatchError.Code);
                        Assert.Equal("Either the specified VNet does not exist, or the Batch service does not have access to it", exception.RequestInformation.BatchError.Values.Single(value => value.Key == "Reason").Value);
                    }
                    finally
                    {
                        //Delete the pool
                        TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        #region Test helpers

        /// <summary>
        /// injects a fake response
        /// </summary>
        internal class TestListPoolUsageMetricsFakesYieldInjector : Protocol.RequestInterceptor
        {
            // the fake data to be returned
            internal IList<Protocol.Models.PoolUsageMetrics> _poolUsageMetricsList;

            // returns our response... the fake
            private Task<AzureOperationResponse<IPage<Protocol.Models.PoolUsageMetrics>, Protocol.Models.PoolListPoolUsageMetricsHeaders>> NewFunc(CancellationToken token)
            {
                var response = new AzureOperationResponse<IPage<Protocol.Models.PoolUsageMetrics>, Protocol.Models.PoolListPoolUsageMetricsHeaders>()
                    {

                        Body = new FakePage<Protocol.Models.PoolUsageMetrics>(_poolUsageMetricsList)
                    };

                return System.Threading.Tasks.Task.FromResult<AzureOperationResponse<IPage<Protocol.Models.PoolUsageMetrics>, Protocol.Models.PoolListPoolUsageMetricsHeaders>>(response);
            }

            // replaces the func with our own func
            private void RequestInterceptor(Protocol.IBatchRequest requestBase)
            {
                // mung the func
                ((PoolListPoolUsageMetricsBatchRequest)requestBase).ServiceRequestFunc = NewFunc;
            }

            private TestListPoolUsageMetricsFakesYieldInjector()
            {
            }

            internal TestListPoolUsageMetricsFakesYieldInjector(IList<Protocol.Models.PoolUsageMetrics> poolUsageMetricsList)
            {
                // here is our interceptor
                base.ModificationInterceptHandler = this.RequestInterceptor;

                // remember our fake data
                this._poolUsageMetricsList = poolUsageMetricsList;
            }
        }


        private static void AddEnviornmentSettingsToStartTask(StartTask start, string envSettingName, string envSettingValue)
        {
            List<EnvironmentSetting> settings = new List<EnvironmentSetting>();

            EnvironmentSetting newES = new EnvironmentSetting(envSettingName, envSettingValue);

            settings.Add(newES);

            start.EnvironmentSettings = settings;

            foreach (EnvironmentSetting curES in start.EnvironmentSettings)
            {
                Assert.Equal(envSettingName, curES.Name);
                Assert.Equal(envSettingValue, curES.Value);
            }
        }

        private static void CheckEnvironmentSettingsOnStartTask(StartTask start, string envSettingName, string envSettingValue)
        {
            foreach (EnvironmentSetting curES in start.EnvironmentSettings)
            {
                Assert.Equal(envSettingName, curES.Name);
                Assert.Equal(envSettingValue, curES.Value);
            }
        }

        private static void MakeResourceFiles(StartTask start, string resourceFileSas, string resourceFileValue)
        {
            List<ResourceFile> files = new List<ResourceFile>();

            ResourceFile newRR = new ResourceFile(resourceFileSas, resourceFileValue);

            files.Add(newRR);

            start.ResourceFiles = files;

            CheckResourceFiles(start, resourceFileSas, resourceFileValue);
        }


        /// <summary>
        ///  Asserts that the resource files in the StartTask exactly match
        ///  those created in MakeResourceFiles().
        /// </summary>
        /// <param name="st"></param>
        private static void CheckResourceFiles(StartTask st, string resourceFileSas, string resourceFileValue)
        {
            foreach (ResourceFile curRF in st.ResourceFiles)
            {
                Assert.Equal(curRF.BlobSource, resourceFileSas);
                Assert.Equal(curRF.FilePath, resourceFileValue);
            }
        }


        #endregion
    }

    /// <summary>
    /// This class exists because XUnit doesn't run tests in a single class in parallel.  To reduce test runtime,
    /// the longest running pool tests have been split out into multiple classes.
    /// </summary>
    public class IntegrationCloudPoolLongRunningTests01
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudPoolLongRunningTests01(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //Note -- this class does not and should not need a pool fixture
        }

        /// <summary>
        /// Now authoritative for bug 1447283 (ResizeError) as well (2014.09.sep.11)
        /// </summary>
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_Bug2251050_1447283_TestRemovePoolComputeNodesResizeTimeout()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "Bug2251050_TestRemoveComputeNodesResizeTimeout_LR" + TestUtilities.GetMyName();
                    string jobId = "Bug2251050Job-" + TestUtilities.GetMyName();
                    const int targetDedicated = 2;
                    TimeSpan computeNodeAllocationTimeout = TimeSpan.FromMinutes(5);
                    try
                    {
                        //Create a pool with 2 compute nodes
                        CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: targetDedicated);
                        pool.Commit();

                        this.testOutputHelper.WriteLine("Created pool {0}", poolId);

                        CloudPool refreshablePool = batchCli.PoolOperations.GetPool(poolId);
                        //Wait for compute node allocation
                        //TODO: Use a Utilities waiter
                        DateTime allocationWaitStartTime = DateTime.UtcNow;
                        DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(computeNodeAllocationTimeout);
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            this.testOutputHelper.WriteLine("Pool is in State: {0}", refreshablePool.AllocationState);
                            Assert.False(DateTime.UtcNow > timeoutAfterThisTimeUtc, "Timed out waiting for pool to reach steady state");
                        }
                        Assert.Equal(targetDedicated, refreshablePool.CurrentDedicated);

                        IEnumerable<ComputeNode> computeNodes = refreshablePool.ListComputeNodes();

                        Assert.Equal(targetDedicated, computeNodes.Count());

                        //
                        //Create a job on this pool with targetDedicated tasks which run for 10m each
                        //
                        CloudJob workflowJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolId });
                        workflowJob.Commit();

                        const int taskDurationSeconds = 600;
                        string taskCmdLine = string.Format("ping 127.0.0.1 -n {0}", taskDurationSeconds);

                        for (int i = 0; i < targetDedicated; i++)
                        {
                            string taskId = string.Format("T_{0}", i);
                            batchCli.JobOperations.AddTask(jobId, new CloudTask(taskId, taskCmdLine));
                        }

                        //
                        // Wait for tasks to both go to running
                        //
                        Utilities utilities = batchCli.Utilities;
                        TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            batchCli.JobOperations.ListTasks(jobId),
                            Microsoft.Azure.Batch.Common.TaskState.Running,
                            TimeSpan.FromMinutes(20));

                        //
                        // Remove pool compute nodes
                        //
                        TimeSpan resizeTimeout = TimeSpan.FromMinutes(5);
                        batchCli.PoolOperations.RemoveFromPool(poolId, computeNodes, ComputeNodeDeallocationOption.TaskCompletion, resizeTimeout);

                        //
                        // Wait for the resize to timeout
                        //
                        TimeSpan waitForSteadyTimeout = TimeSpan.FromMinutes(6);
                        //TODO: Use a Utilities waiter
                        refreshablePool.Refresh();

                        allocationWaitStartTime = DateTime.UtcNow;
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            this.testOutputHelper.WriteLine("Pool is in State: {0}", refreshablePool.AllocationState);

                            Assert.False(DateTime.UtcNow > allocationWaitStartTime.Add(waitForSteadyTimeout), "Timed out waiting for pool to reach steady state");
                        }
                        this.testOutputHelper.WriteLine("Resize error: {0}", refreshablePool.ResizeError == null ? null : refreshablePool.ResizeError.Message);
                        Assert.NotNull(refreshablePool.ResizeError);
                        
                    }
                    finally
                    {
                        //Delete the pool
                        batchCli.PoolOperations.DeletePool(poolId);

                        //Delete the job schedule
                        batchCli.JobOperations.DeleteJob(jobId);
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }
    }

    /// <summary>
    /// This class exists because XUnit doesn't run tests in a single class in parallel.  To reduce test runtime,
    /// the longest running pool tests have been split out into multiple classes.
    /// </summary>
    public class IntegrationCloudPoolLongRunningTests02
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudPoolLongRunningTests02(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //Note -- this class does not and should not need a pool fixture
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_TestRemovePoolComputeNodes()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string poolId = "TestRemovePoolComputeNodes_LongRunning" + TestUtilities.GetMyName();
                    const int targetDedicated = 3;
                    TimeSpan computeNodeAllocationTimeout = TimeSpan.FromMinutes(10);
                    try
                    {
                        //Create a pool
                        CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated: targetDedicated);

                        pool.Commit();

                        this.testOutputHelper.WriteLine("Created pool {0}", poolId);

                        CloudPool refreshablePool = batchCli.PoolOperations.GetPool(poolId);
                        //Wait for compute node allocation
                        //TODO: Use a Utilities waiter
                        DateTime allocationWaitStartTime = DateTime.UtcNow;
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            Assert.False(
                                DateTime.UtcNow > allocationWaitStartTime.Add(computeNodeAllocationTimeout),
                                "Timed out waiting for pool to reach steady state");
                        }
                        Assert.Equal(targetDedicated, refreshablePool.CurrentDedicated);

                        IEnumerable<ComputeNode> computeNodes = refreshablePool.ListComputeNodes();

                        Assert.Equal(targetDedicated, computeNodes.Count());

                        //
                        //Remove first compute node from the pool
                        //
                        ComputeNode computeNodeToRemove = computeNodes.First();

                        //For Bug234298 ensure start task property doesn't throw
                        Assert.Null(computeNodeToRemove.StartTask);

                        this.testOutputHelper.WriteLine("Will remove compute node: {0}", computeNodeToRemove.Id);

                        //Remove the compute node from the pool by instance
                        refreshablePool.RemoveFromPool(computeNodeToRemove);

                        //Wait for pool to got to steady state again
                        //TODO: Use a Utilities waiter
                        refreshablePool.Refresh();
                        allocationWaitStartTime = DateTime.UtcNow;
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            Assert.False(
                                DateTime.UtcNow > allocationWaitStartTime.Add(computeNodeAllocationTimeout),
                                "Timed out waiting for pool to reach steady state");
                        }

                        //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                        List<ComputeNode> computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();

                        Assert.Equal(targetDedicated - 1, computeNodesAfterRemove.Count);

                        List<string> remainingComputeNodeIds = computeNodesAfterRemove.Select(computeNode => computeNode.Id).ToList();
                        foreach (ComputeNode originalComputeNode in computeNodes)
                        {
                            Assert.Contains(originalComputeNode.Id, remainingComputeNodeIds);
                        }

                        this.testOutputHelper.WriteLine("Verified that the compute node was removed correctly");

                        //
                        //Remove a second compute node from the pool
                        //

                        ComputeNode secondComputeNodeToRemove = computeNodesAfterRemove.First();
                        string secondComputeNodeToRemoveId = secondComputeNodeToRemove.Id;

                        //Remove the IComputeNode from the pool by id
                        refreshablePool.RemoveFromPool(secondComputeNodeToRemoveId);

                        //Wait for pool to got to steady state again
                        //TODO: Use a Utilities waiter
                        refreshablePool.Refresh();
                        allocationWaitStartTime = DateTime.UtcNow;
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            Assert.False(DateTime.UtcNow > allocationWaitStartTime.Add(computeNodeAllocationTimeout), "Timed out waiting for pool to reach steady state");
                        }

                        //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                        computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();

                        Assert.Equal(targetDedicated - 2, computeNodesAfterRemove.Count);

                        this.testOutputHelper.WriteLine("Verified that the compute node was removed correctly");

                        //
                        //Remove a 3rd compute node from pool
                        //

                        ComputeNode thirdComputeNodeToRemove = computeNodesAfterRemove.First();
                        string thirdComputeNodeToRemoveId = thirdComputeNodeToRemove.Id;
                        this.testOutputHelper.WriteLine("Will remove compute node: {0}", thirdComputeNodeToRemoveId);

                        //Remove the IComputeNode from the pool using the ComputeNode object
                        thirdComputeNodeToRemove.RemoveFromPool();

                        //Wait for pool to got to steady state again
                        //TODO: Use a Utilities waiter
                        refreshablePool.Refresh();
                        allocationWaitStartTime = DateTime.UtcNow;
                        while (refreshablePool.AllocationState != AllocationState.Steady)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            refreshablePool.Refresh();
                            Assert.False(DateTime.UtcNow > allocationWaitStartTime.Add(computeNodeAllocationTimeout), "Timed out waiting for pool to reach steady state");
                        }

                        //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                        computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();
                        Assert.Equal(targetDedicated - 3, computeNodesAfterRemove.Count);

                        this.testOutputHelper.WriteLine("Verified that the ComputeNode was removed correctly");
                    }
                    finally
                    {
                        //Delete the pool
                        batchCli.PoolOperations.DeletePool(poolId);
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }
    }

    [Collection("SharedPoolCollection")]
    public class IntegrationCloudPoolTestsWithSharedPool
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudPoolTestsWithSharedPool(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_Bug1771277_1771278_RebootReimageComputeNode()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    string jobId = "LongRunning_Bug1771277_1771278_RebootReimageComputeNode" + TestUtilities.GetMyName();

                    try
                    {
                        //
                        // Get the pool and check its targets
                        //
                        CloudPool pool = batchCli.PoolOperations.GetPool(this.poolFixture.PoolId);

                        //
                        //Create a job on this pool with targetDedicated tasks which run for 2m each
                        //
                        const int taskDurationSeconds = 600;

                        CloudJob workflowJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = this.poolFixture.PoolId });
                        workflowJob.Commit();

                        CloudJob boundWorkflowJob = batchCli.JobOperations.GetJob(jobId);

                        string taskCmdLine = string.Format("ping 127.0.0.1 -n {0}", taskDurationSeconds);

                        for (int i = 0; i < pool.CurrentDedicated; i++)
                        {
                            string taskId = string.Format("T_{0}", i);
                            boundWorkflowJob.AddTask(new CloudTask(taskId, taskCmdLine));
                        }

                        //
                        // Wait for tasks to go to running
                        //
                        TaskStateMonitor taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            batchCli.JobOperations.ListTasks(jobId),
                            Microsoft.Azure.Batch.Common.TaskState.Running,
                            TimeSpan.FromMinutes(2));

                        //
                        // Reboot the compute nodes from the pool with requeue option and ensure tasks goes to Active again and compute node state goes to rebooting
                        //

                        IEnumerable<ComputeNode> computeNodes = pool.ListComputeNodes();

                        foreach (ComputeNode computeNode in computeNodes)
                        {
                            computeNode.Reboot(ComputeNodeRebootOption.Requeue);
                        }

                        //Ensure task goes to active state
                        taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            batchCli.JobOperations.ListTasks(jobId),
                            Microsoft.Azure.Batch.Common.TaskState.Active,
                            TimeSpan.FromMinutes(1));

                        //Ensure each compute node goes to rebooting state
                        IEnumerable<ComputeNode> rebootingComputeNodes = batchCli.PoolOperations.ListComputeNodes(this.poolFixture.PoolId);
                        foreach (ComputeNode computeNode in rebootingComputeNodes)
                        {
                            Assert.Equal(ComputeNodeState.Rebooting, computeNode.State);
                        }

                        //Wait for tasks to start to run again
                        taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            batchCli.JobOperations.ListTasks(jobId),
                            Microsoft.Azure.Batch.Common.TaskState.Running,
                            TimeSpan.FromMinutes(10));
                        //
                        // Reimage a compute node from the pool with terminate option and ensure task goes to completed and compute node state goes to reimaging
                        //
                        computeNodes = pool.ListComputeNodes();

                        foreach (ComputeNode computeNode in computeNodes)
                        {
                            computeNode.Reimage(ComputeNodeReimageOption.Terminate);
                        }

                        //Ensure task goes to completed state
                        taskStateMonitor = batchCli.Utilities.CreateTaskStateMonitor();
                        taskStateMonitor.WaitAll(
                            batchCli.JobOperations.ListTasks(jobId),
                            Microsoft.Azure.Batch.Common.TaskState.Completed,
                            TimeSpan.FromMinutes(1));

                        //Ensure each compute node goes to reimaging state
                        IEnumerable<ComputeNode> reimagingComputeNodes = batchCli.PoolOperations.ListComputeNodes(this.poolFixture.PoolId);
                        foreach (ComputeNode computeNode in reimagingComputeNodes)
                        {
                            Assert.Equal(ComputeNodeState.Reimaging, computeNode.State);
                        }
                    }
                    finally
                    {
                        //Delete the job
                        TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();

                        //Wait until the compute nodes are idle again
                        //TODO: Use a Utilities waiter
                        TimeSpan computeNodeSteadyTimeout = TimeSpan.FromMinutes(15);
                        DateTime allocationWaitStartTime = DateTime.UtcNow;
                        DateTime timeoutAfterThisTimeUtc = allocationWaitStartTime.Add(computeNodeSteadyTimeout);

                        IEnumerable<ComputeNode> computeNodes = batchCli.PoolOperations.ListComputeNodes(this.poolFixture.PoolId);

                        while (computeNodes.Any(computeNode => computeNode.State != ComputeNodeState.Idle))
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                            computeNodes = batchCli.PoolOperations.ListComputeNodes(this.poolFixture.PoolId).ToList();
                            Assert.False(DateTime.UtcNow > timeoutAfterThisTimeUtc, "Timed out waiting for compute nodes in pool to reach idle state");
                        }
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ListNodeAgentSkus()
        {
            Action test = () =>
            {
                using (BatchClient batchCli = TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment()).Result)
                {
                    var nas = batchCli.PoolOperations.ListNodeAgentSkus().ToList();

                    Assert.True(nas.Count > 0);

                    foreach (NodeAgentSku curNAS in nas)
                    {
                        this.testOutputHelper.WriteLine("NAS:");
                        this.testOutputHelper.WriteLine("   skuid: " + curNAS.Id);
                        this.testOutputHelper.WriteLine("   OSType: " + curNAS.OSType);

                        foreach (ImageReference verifiedImageReference in curNAS.VerifiedImageReferences)
                        {
                            this.testOutputHelper.WriteLine("   verifiedImageRefs publisher: " + verifiedImageReference.Publisher);
                            this.testOutputHelper.WriteLine("   verifiedImageRefs offer: " + verifiedImageReference.Offer);
                            this.testOutputHelper.WriteLine("   verifiedImageRefs sku: " + verifiedImageReference.Sku);
                            this.testOutputHelper.WriteLine("   verifiedImageRefs version: " + verifiedImageReference.Version);
                        }
                            
                    }
                }
            };

            SynchronizationContextHelper.RunTest(test, timeout: TimeSpan.FromSeconds(60));
        }
    }
}
