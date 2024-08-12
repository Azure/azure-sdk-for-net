// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Azure.Storage.Blobs;
    using BatchTestCommon;
    using Fixtures;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using IntegrationTestCommon;
    using IntegrationTestUtilities;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities;

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
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task PoolPatch()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
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
                        targetDedicatedComputeNodes: 0);

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

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1505248SupportMultipleTasksPerComputeNodeOnPoolAndPoolUserSpec()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                // create a pool with the two new props
                string poolId = "Bug1505248SupportMultipleTasksPerComputeNode-pool-" + TestUtilities.GetMyName();
                try
                {
                    CloudPool newPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);

                    newPool.TaskSlotsPerNode = 3;

                    newPool.TaskSchedulingPolicy =
                        new TaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

                    newPool.Commit();

                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                    Assert.Equal(3, boundPool.TaskSlotsPerNode);
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

                        unboundPS.TaskSlotsPerNode = 3;
                        unboundAPS.PoolSpecification.TargetDedicatedComputeNodes = 0; // don't use up compute nodes for this test
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

                    Assert.Equal(3, boundPUS.TaskSlotsPerNode);
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

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1587303StartTaskResourceFilesNotPushedToServer()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "Bug1587303Pool-" + TestUtilities.GetMyName();

                const string resourceFileSas = "http://azure.com";
                const string resourceFileValue = "count0ResFiles.exe";

                const string envSettingName = "envName";
                const string envSettingValue = "envValue";

                try
                {
                    // create a pool with env-settings and ResFiles
                    {
                        CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);

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
                    Assert.Empty(count0ResFiles);
                    Assert.Empty(count0EnvSettings);

                    //clean up
                    boundPool.Delete();

                    System.Threading.Thread.Sleep(5000); // wait for pool to be deleted

                    // check pool create with empty-but-non-null collections
                    {
                        CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);

                        StartTask st = new StartTask("dir")
                        {
                            // use the empty collections from above
                            ResourceFiles = emptyResfiles,
                            EnvironmentSettings = emptyEnvSettings
                        };

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
                    Assert.Empty(count0ResFiles);
                    Assert.Empty(count0EnvSettings);
                }
                finally
                {
                    // cleanup
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug1433123PoolMissingResizeTimeout()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "Bug1433123PoolMissingResizeTimeout-" + TestUtilities.GetMyName();

                try
                {
                    TimeSpan referenceRST = TimeSpan.FromMinutes(5);

                    // create a pool with env-settings and ResFiles
                    {
                        CloudPool myPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);

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

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1656475PoolLifetimeOption()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
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

                        ips.TargetDedicatedComputeNodes = 0;
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

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void Bug1432812SetAutoScaleMissingOnPoolPoolMgr()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "Bug1432812-" + TestUtilities.GetMyName();
                const string poolASFormulaOrig = "$TargetDedicatedNodes=0;";
                const string poolASFormula2 = "$TargetDedicatedNodes=1;";
                // craft exactly how it would be returned by Evaluate so indexof can work

                try
                {
                    // create a pool.. empty for now
                    {
                        CloudPool unboundPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));

                        unboundPool.AutoScaleEnabled = true;
                        unboundPool.AutoScaleFormula = poolASFormulaOrig;

                        unboundPool.Commit();

                        TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromSeconds(20)).Wait();
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
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(5)).Wait();

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

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1432819UpdateImplOnCloudPool()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "Bug1432819-" + TestUtilities.GetMyName();
                try
                {
                    CloudPool unboundPool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: 0);
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

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestListPoolUsageMetrics()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                // test via faking data
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
                List<PoolUsageMetrics> clList = batchCli.PoolOperations.ListPoolUsageMetrics(additionalBehaviors: new[] { injectsTheFakeData }).ToList();

                // test that our data are honored

                for (int j = 0; j < 4; j++)
                {
                    string id = "my fancy pool id " + j.ToString();
                    Assert.Equal(id, clList[j].PoolId);
                    Assert.Equal(endTime, clList[j].EndTime);
                    Assert.Equal(startTime, clList[j].StartTime);
                    Assert.Equal(totalCoreHours, clList[j].TotalCoreHours);
                    Assert.Equal(virtualMachineSize, clList[j].VirtualMachineSize);
                }

                List<PoolUsageMetrics> list = batchCli.PoolOperations.ListPoolUsageMetrics(DateTime.Now - TimeSpan.FromDays(1)).ToList();
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolObjectResizeStopResize()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "TestPoolObjectResizeStopResize" + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                const int newTargetDedicated = 1;
                try
                {
                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: targetDedicated);
                    pool.Commit();

                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromSeconds(20)).Wait();

                    testOutputHelper.WriteLine($"Created pool {poolId}");

                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                    //Resize the pool
                    boundPool.Resize(newTargetDedicated, 0);

                    boundPool.Refresh();
                    Assert.Equal(AllocationState.Resizing, boundPool.AllocationState);

                    boundPool.StopResize();
                    boundPool.Refresh();

                    //The pool could be in stopping or steady state
                    testOutputHelper.WriteLine($"Pool allocation state: {boundPool.AllocationState}");
                    Assert.True(boundPool.AllocationState == AllocationState.Steady || boundPool.AllocationState == AllocationState.Stopping);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestPoolAutoscaleVerbs()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = TestUtilities.GenerateResourceId();
                const int targetDedicated = 0;
                const string autoscaleFormula1 = "$TargetDedicatedNodes=0;$TargetLowPriorityNodes=0;$NodeDeallocationOption=requeue";
                const string autoscaleFormula2 = "$TargetDedicatedNodes=0;$TargetLowPriorityNodes=0;$NodeDeallocationOption=terminate";

                const string evaluateAutoscaleFormula = "myActiveSamples=$ActiveTasks.GetSample(5);";
                TimeSpan enableAutoScaleMinimumDelay = TimeSpan.FromSeconds(30);  // compiler says can't be const

                try
                {
                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated);
                    pool.Commit();

                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromSeconds(20)).Wait();

                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                    //Enable autoscale (via instance)
                    boundPool.EnableAutoScale(autoscaleFormula1);
                    DateTime utcEarliestCanCallEnableASAgain = DateTime.UtcNow + enableAutoScaleMinimumDelay;

                    boundPool.Refresh();
                    Assert.True(boundPool.AutoScaleEnabled);
                    Assert.Equal(autoscaleFormula1, boundPool.AutoScaleFormula);
                    testOutputHelper.WriteLine($"Got the pool");

                    Assert.NotNull(boundPool.AutoScaleRun);
                    Assert.NotNull(boundPool.AutoScaleRun.Results);
                    Assert.Contains(autoscaleFormula1, boundPool.AutoScaleRun.Results);

                    //Evaluate a different formula
                    AutoScaleRun evaluation = boundPool.EvaluateAutoScale(evaluateAutoscaleFormula);

                    testOutputHelper.WriteLine("Autoscale evaluate results: {0}", evaluation.Results);

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

                    testOutputHelper.WriteLine("Autoscale evaluate results: {0}", evaluation.Results);

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

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestServerRejectsNonExistantVNetWithCorrectError()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
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

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolCreatedWithUserAccountsSucceeds()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = "TestPoolCreatedWithUserAccounts" + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var nodeUserPassword = TestUtilities.GenerateRandomPassword();
                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicated);
                    pool.UserAccounts = new List<UserAccount>()
                        {
                            new UserAccount("test1", nodeUserPassword),
                            new UserAccount("test2", nodeUserPassword, ElevationLevel.NonAdmin),
                            new UserAccount("test3", nodeUserPassword, ElevationLevel.Admin),
                            new UserAccount("test4", nodeUserPassword, linuxUserConfiguration: new LinuxUserConfiguration(sshPrivateKey: "AAAA==")),
                        };
                    pool.Commit();

                    CloudPool boundPool = batchCli.PoolOperations.GetPool(poolId);

                    Assert.Equal(pool.UserAccounts.Count, boundPool.UserAccounts.Count);
                    var results = pool.UserAccounts.Zip(boundPool.UserAccounts, (expected, actual) => new { Submitted = expected, Returned = actual });
                    foreach (var result in results)
                    {
                        Assert.Equal(result.Submitted.Name, result.Returned.Name);
                        Assert.Null(result.Returned.Password);
                        Assert.Equal(result.Submitted.ElevationLevel ?? ElevationLevel.NonAdmin, result.Returned.ElevationLevel);
                        Assert.Null(result.Returned.LinuxUserConfiguration?.SshPrivateKey);
                    }
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolCreatedOSDiskSucceeds()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = nameof(TestPoolCreatedOSDiskSucceeds) + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                        {
                            LicenseType = "Windows_Server"
                        },
                        targetDedicated);
                    pool.Commit();

                    pool.Refresh();

                    Assert.Equal("Windows_Server", pool.VirtualMachineConfiguration.LicenseType);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolCreatedDataDiskSucceeds()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = nameof(TestPoolCreatedDataDiskSucceeds) + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);
                    const int lun = 50;
                    const int diskSizeGB = 50;

                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                        {
                            DataDisks = new List<DataDisk>
                            {
                                new DataDisk(lun, diskSizeGB)
                            }
                        },
                        targetDedicated);
                    pool.Commit();
                    pool.Refresh();

                    Assert.Equal(lun, pool.VirtualMachineConfiguration.DataDisks.Single().Lun);
                    Assert.Equal(diskSizeGB, pool.VirtualMachineConfiguration.DataDisks.Single().DiskSizeGB);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestPoolCreatedCustomImageExpectedError()
        {
            void test()
            {
                static Task<string> tokenProvider() => IntegrationTestCommon.GetAuthenticationTokenAsync("https://batch.core.windows.net/");

                using var client = BatchClient.Open(new BatchTokenCredentials(TestCommon.Configuration.BatchAccountUrl, tokenProvider));
                string poolId = "TestPoolCreatedWithCustomImage" + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(client);

                    //Create a pool
                    CloudPool pool = client.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            new ImageReference(
                                $"/subscriptions/{TestCommon.Configuration.BatchSubscription}/resourceGroups/{TestCommon.Configuration.BatchAccountResourceGroup}/providers/Microsoft.Compute/galleries/FakeGallery/images/FakeImage/versions/FakeImageVersion"),
                            imageDetails.NodeAgentSkuId),
                        targetDedicated);
                    var exception = Assert.Throws<BatchException>(() => pool.Commit());

                    Assert.Equal("InsufficientPermissions", exception.RequestInformation.BatchError.Code);
                    Assert.Contains(
                        "The user identity used for this operation does not have the required privelege Microsoft.Compute/galleries/images/versions/read on the specified resource",
                        exception.RequestInformation.BatchError.Values.Single().Value);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(client, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestPoolCreatedTrustedLaunch()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = TestUtilities.GenerateResourceId();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuServerImageDetails(batchCli);

                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        "standard_d2s_v3",
                         new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                         {
                             SecurityProfile = new SecurityProfile()
                             {
                                 SecurityType = SecurityTypes.TrustedLaunch,
                                 EncryptionAtHost = true,
                                 UefiSettings = new UefiSettings()
                                 {
                                     SecureBootEnabled = true,
                                     VTpmEnabled = true
                                 }
                             }
                         }

                         );



                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.NotNull(pool.VirtualMachineConfiguration.SecurityProfile);
                    Assert.Equal(SecurityTypes.TrustedLaunch, pool.VirtualMachineConfiguration.SecurityProfile.SecurityType);
                    Assert.True(pool.VirtualMachineConfiguration.SecurityProfile.EncryptionAtHost);
                    Assert.True(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled);
                    Assert.True(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.VTpmEnabled);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }
            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }


        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestPoolCreatedOsDisk()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = TestUtilities.GenerateResourceId();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuServerImageDetails(batchCli);

                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        "standard_d2s_v3",
                         new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                         {
                             OSDisk = new OSDisk()
                             {
                                 Caching = CachingType.ReadOnly,
                                 ManagedDisk = new ManagedDisk()
                                 {
                                     StorageAccountType = StorageAccountType.PremiumLrs
                                 },
                                 DiskSizeGB = 10
                             }
                         }
                         );




                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.NotNull(pool.VirtualMachineConfiguration.OSDisk);
                    Assert.Equal(CachingType.ReadOnly, pool.VirtualMachineConfiguration.OSDisk.Caching);
                    Assert.Equal(10, pool.VirtualMachineConfiguration.OSDisk.DiskSizeGB);
                    Assert.Equal(StorageAccountType.PremiumLrs, pool.VirtualMachineConfiguration.OSDisk.ManagedDisk.StorageAccountType);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }
            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestPoolCreatedUpgradePolicy()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = TestUtilities.GenerateResourceId();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuServerImageDetails(batchCli);


                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        "standard_d2s_v3",
                         new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                         {
                             NodePlacementConfiguration = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal)
                         }
                         );
                   
                    pool.UpgradePolicy = new UpgradePolicy(UpgradeMode.Automatic)
                    {
                        AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                        {
                            DisableAutomaticRollback = true,
                            EnableAutomaticOSUpgrade = true,
                            UseRollingUpgradePolicy = true,
                            OsRollingUpgradeDeferral = true
                        },
                        RollingUpgradePolicy = new RollingUpgradePolicy()
                        {
                            EnableCrossZoneUpgrade = true,
                            MaxBatchInstancePercent = 20,
                            MaxUnhealthyInstancePercent = 20,
                            MaxUnhealthyUpgradedInstancePercent = 20,
                            PauseTimeBetweenBatches = TimeSpan.FromSeconds(5),
                            PrioritizeUnhealthyInstances = false,
                            RollbackFailedInstancesOnPolicyBreach = false
                        }
                    };

                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.NotNull(pool.UpgradePolicy);
                    Assert.Equal(UpgradeMode.Automatic, pool.UpgradePolicy.Mode);
                    Assert.NotNull(pool.UpgradePolicy.AutomaticOSUpgradePolicy);
                    Assert.Equal(true, pool.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback);
                    Assert.Equal(true, pool.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade);
                    Assert.NotNull(pool.UpgradePolicy.RollingUpgradePolicy);
                    Assert.Equal(true, pool.UpgradePolicy.RollingUpgradePolicy.EnableCrossZoneUpgrade);
                    Assert.Equal(20, pool.UpgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }
            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }


        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestPoolCreateResourceTags()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientServicePrincipal().ConfigureAwait(false);

                string poolId = TestUtilities.GenerateResourceId();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuServerImageDetails(batchCli);


                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        "standard_d2s_v3",
                         new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                         );
                    pool.ResourceTags = new Dictionary<string, string>()
                    {
                        {"TagName1","TagValue1"},
                        {"TagName2","TagValue2"},
                    };

                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.NotNull(pool.ResourceTags);
                    Assert.Equal("TagValue1", pool.ResourceTags["TagName1"]);
                    Assert.Equal("TagValue2", pool.ResourceTags["TagName2"]);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Theory]
        [LiveTest]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, null)]
        [InlineData(null, 1)]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task ResizePool_AcceptedByServer(int? targetDedicated, int? targetLowPriority)
        {
            async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = TestUtilities.GenerateResourceId();

                try
                {
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new CloudServiceConfiguration(PoolFixture.OSFamily));

                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    await TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(1));

                    await pool.ResizeAsync(
                        targetDedicatedComputeNodes: targetDedicated,
                        targetLowPriorityComputeNodes: targetLowPriority,
                        resizeTimeout: TimeSpan.FromMinutes(10)).ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.Equal(targetDedicated ?? 0, pool.TargetDedicatedComputeNodes);
                    Assert.Equal(targetLowPriority ?? 0, pool.TargetLowPriorityComputeNodes);
                    Assert.Equal(AllocationState.Resizing, pool.AllocationState);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }
            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void PoolStateCount_IsReturnedFromServer()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                var nodeCounts = batchCli.PoolOperations.ListPoolNodeCounts();

                Assert.NotEmpty(nodeCounts);
                var poolId = nodeCounts.First().PoolId;

                foreach (var poolNodeCount in nodeCounts)
                {
                    Assert.NotEmpty(poolNodeCount.PoolId);
                    Assert.NotNull(poolNodeCount.Dedicated);
                    Assert.NotNull(poolNodeCount.LowPriority);

                    // Check a few properties at random
                    Assert.Equal(0, poolNodeCount.LowPriority.Unusable);
                    Assert.Equal(0, poolNodeCount.LowPriority.Offline);
                }

                var filteredNodeCounts = batchCli.PoolOperations.ListPoolNodeCounts(new ODATADetailLevel(filterClause: $"poolId eq '{poolId}'")).ToList();
                Assert.Single(filteredNodeCounts);
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ListSupportedImages()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                var supportedImages = batchCli.PoolOperations.ListSupportedImages().ToList();

                Assert.True(supportedImages.Count > 0);

                foreach (ImageInformation imageInfo in supportedImages)
                {
                    testOutputHelper.WriteLine("ImageInformation:");
                    testOutputHelper.WriteLine("   skuid: " + imageInfo.NodeAgentSkuId);
                    testOutputHelper.WriteLine("   OSType: " + imageInfo.OSType);
                    testOutputHelper.WriteLine("   publisher: " + imageInfo.ImageReference.Publisher);
                    testOutputHelper.WriteLine("   offer: " + imageInfo.ImageReference.Offer);
                    testOutputHelper.WriteLine("   sku: " + imageInfo.ImageReference.Sku);
                    testOutputHelper.WriteLine("   version: " + imageInfo.ImageReference.Version);
                }
            }

            SynchronizationContextHelper.RunTest(test, timeout: TimeSpan.FromSeconds(60));
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task CreatePool_WithBlobFuseMountConfiguration()
        {
            static async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = TestUtilities.GenerateResourceId();

                const string containerName = "blobfusecontainer";

                StagingStorageAccount storageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();
                BlobContainerClient containerClient = BlobUtilities.GetBlobContainerClient(containerName, storageAccount);
                containerClient.CreateIfNotExists();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId));

                    pool.MountConfiguration = new List<MountConfiguration>
                        {
                            new MountConfiguration(
                                new AzureBlobFileSystemConfiguration(
                                    storageAccount.StorageAccount,
                                    containerName,
                                    "foo",
                                    AzureStorageAuthenticationKey.FromAccountKey(storageAccount.StorageAccountKey)))
                        };

                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.NotNull(pool.MountConfiguration);
                    Assert.NotEmpty(pool.MountConfiguration);
                    Assert.Equal(storageAccount.StorageAccount, pool.MountConfiguration.Single().AzureBlobFileSystemConfiguration.AccountName);
                    Assert.Equal(containerName, pool.MountConfiguration.Single().AzureBlobFileSystemConfiguration.ContainerName);
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }
            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestCreatePoolEncryptionEnabled()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = nameof(TestCreatePoolEncryptionEnabled) + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                        {
                            DiskEncryptionConfiguration = new DiskEncryptionConfiguration(new List<DiskEncryptionTarget> { DiskEncryptionTarget.TemporaryDisk })
                        },
                        targetDedicated);
                    pool.Commit();
                    pool.Refresh();

                    Assert.Single(pool.VirtualMachineConfiguration.DiskEncryptionConfiguration.Targets, DiskEncryptionTarget.TemporaryDisk);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task TestNodeCommunicationMode()
        {
            async Task test()
            {
                using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                string poolId = "TestNodeCommunicationMode-" + TestUtilities.GetMyName();

                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);
                    var targetDedicatedNodeNum = 1;
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                      poolId,
                      PoolFixture.VMSize,
                      new VirtualMachineConfiguration(
                          imageDetails.ImageReference,
                          imageDetails.NodeAgentSkuId),
                      targetDedicatedNodeNum);

                    //Set NodeCommunicationMode to Default
                    pool.TargetNodeCommunicationMode = NodeCommunicationMode.Default;
                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);
                    var allocationState = batchCli.PoolOperations.GetPool(poolId).AllocationState;
                    do
                    {
                        if (allocationState != AllocationState.Steady)
                        {
                            await Task.Delay(new TimeSpan(0, 0, 10));
                            testOutputHelper.WriteLine($"waiting for pool {poolId} to be steady...");
                            allocationState = batchCli.PoolOperations.GetPool(poolId).AllocationState;
                        }
                    }
                    while (allocationState != AllocationState.Steady);

                    if (allocationState == AllocationState.Steady)
                    {
                        await pool.RefreshAsync().ConfigureAwait(false);
                        testOutputHelper.WriteLine($"pool state is {pool.AllocationState}");
                        Assert.NotNull(pool.CurrentNodeCommunicationMode);
                        Assert.Equal(NodeCommunicationMode.Default, pool.TargetNodeCommunicationMode);

                        //Then to Simplified
                        pool.TargetNodeCommunicationMode = NodeCommunicationMode.Simplified;
                        await pool.CommitAsync().ConfigureAwait(false);
                        pool = batchCli.PoolOperations.GetPool(poolId);
                        Assert.NotNull(pool.CurrentNodeCommunicationMode);
                        Assert.Equal(NodeCommunicationMode.Simplified, pool.TargetNodeCommunicationMode);

                        //Then to Classic
                        pool.TargetNodeCommunicationMode = NodeCommunicationMode.Classic;
                        await pool.CommitChangesAsync().ConfigureAwait(false);
                        await pool.RefreshAsync().ConfigureAwait(false);
                        Assert.NotNull(pool.CurrentNodeCommunicationMode);
                        Assert.Equal(NodeCommunicationMode.Classic, pool.TargetNodeCommunicationMode);
                    }
                }
                finally
                {
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public void TestPoolCreatedAcceleratedNetworkingSucceeds()
        {
            static void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = nameof(TestPoolCreatedDataDiskSucceeds) + TestUtilities.GetMyName();
                const int targetDedicated = 0;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);

                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId),
                        targetDedicated);
                    pool.NetworkConfiguration = new NetworkConfiguration() { EnableAcceleratedNetworking = true };
                    pool.Commit();
                    pool.Refresh();

                    Assert.True(pool.NetworkConfiguration.EnableAcceleratedNetworking);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task TestPoolCreatedExtensionWithAutomaticUpgradeSucceeds()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                string poolId = nameof(TestPoolCreatedExtensionWithAutomaticUpgradeSucceeds) + TestUtilities.GetMyName();
                const int targetDedicated = 1;
                try
                {
                    var imageDetails = IaasLinuxPoolFixture.GetUbuntuImageDetails(batchCli);
                    var testExtension = new VMExtension("test", "Microsoft.Azure.KeyVault", "KeyVaultForLinux");
                    testExtension.EnableAutomaticUpgrade = true;
                    testExtension.TypeHandlerVersion = "2.0";

                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new VirtualMachineConfiguration(
                            imageDetails.ImageReference,
                            imageDetails.NodeAgentSkuId)
                        {
                            Extensions = new List<VMExtension>() { testExtension }
                        },
                        targetDedicated);
                    await pool.CommitAsync().ConfigureAwait(false);
                    await pool.RefreshAsync().ConfigureAwait(false);
                    var allocationState = batchCli.PoolOperations.GetPool(poolId).AllocationState;
                    do
                    {
                        if (allocationState != AllocationState.Steady)
                        {
                            await Task.Delay(new TimeSpan(0, 0, 10));
                            testOutputHelper.WriteLine($"waiting for pool {poolId} to be steady...");
                            allocationState = batchCli.PoolOperations.GetPool(poolId).AllocationState;
                        }
                    }
                    while (allocationState != AllocationState.Steady);

                    if (allocationState == AllocationState.Steady)
                    {
                        await pool.RefreshAsync().ConfigureAwait(false);
                        testOutputHelper.WriteLine($"pool state is {pool.AllocationState}");
                        var node = pool.ListComputeNodes().First();
                        testOutputHelper.WriteLine($"Try to get node {node.Id} extentions...");
                        var extensions = batchCli.PoolOperations.ListComputeNodeExtensions(poolId, node.Id);
                        testOutputHelper.WriteLine($"Extentions size is {extensions.Count()}...");
                        var keyvalutExtension = extensions.Single(extension => extension.VmExtension.Publisher.Contains("KeyVault"));
                        Assert.True(keyvalutExtension.VmExtension.EnableAutomaticUpgrade);
                    }
                }
                finally
                {
                    //Delete the pool
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
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
            private Task<AzureOperationResponse<IPage<Protocol.Models.PoolUsageMetrics>, Protocol.Models.PoolListUsageMetricsHeaders>> NewFunc(CancellationToken token)
            {
                var response = new AzureOperationResponse<IPage<Protocol.Models.PoolUsageMetrics>, Protocol.Models.PoolListUsageMetricsHeaders>()
                {

                    Body = new FakePage<Protocol.Models.PoolUsageMetrics>(_poolUsageMetricsList)
                };

                return Task.FromResult(response);
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
                base.ModificationInterceptHandler = RequestInterceptor;

                // remember our fake data
                _poolUsageMetricsList = poolUsageMetricsList;
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

            ResourceFile newRR = ResourceFile.FromUrl(resourceFileSas, resourceFileValue);

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
                Assert.Equal(curRF.HttpUrl, resourceFileSas);
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

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_RemovePoolComputeNodesResizeTimeout_ResizeErrorsPopulated()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "Bug2251050_TestRemoveComputeNodesResizeTimeout_LR" + TestUtilities.GetMyName();
                string jobId = "Bug2251050Job-" + TestUtilities.GetMyName();
                const int targetDedicated = 2;
                try
                {
                    //Create a pool with 2 compute nodes
                    CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: targetDedicated);
                    pool.Commit();

                    testOutputHelper.WriteLine("Created pool {0}", poolId);

                    CloudPool refreshablePool = batchCli.PoolOperations.GetPool(poolId);
                    //Wait for compute node allocation
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(5)).Wait();
                    refreshablePool.Refresh();
                    Assert.Equal(targetDedicated, refreshablePool.CurrentDedicatedComputeNodes);

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
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(6)).Wait();
                    refreshablePool.Refresh();

                    Assert.NotNull(refreshablePool.ResizeErrors);
                    Assert.Equal(1, refreshablePool.ResizeErrors.Count);

                    var resizeError = refreshablePool.ResizeErrors.Single();
                    Assert.Equal(PoolResizeErrorCodes.AllocationTimedOut, resizeError.Code);

                    testOutputHelper.WriteLine("Resize error: {0}", resizeError.Message);
                }
                finally
                {
                    //Delete the pool
                    TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).Wait();

                    //Delete the job schedule
                    TestUtilities.DeleteJobIfExistsAsync(batchCli, jobId).Wait();
                }
            }

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
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_TestRemovePoolComputeNodes()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "TestRemovePoolComputeNodes_LongRunning" + TestUtilities.GetMyName();
                const int targetDedicated = 3;
                try
                {
                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily), targetDedicatedComputeNodes: targetDedicated);

                    pool.Commit();

                    testOutputHelper.WriteLine("Created pool {0}", poolId);

                    CloudPool refreshablePool = batchCli.PoolOperations.GetPool(poolId);
                    //Wait for compute node allocation
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(10)).Wait();
                    refreshablePool.Refresh();
                    Assert.Equal(targetDedicated, refreshablePool.CurrentDedicatedComputeNodes);

                    IEnumerable<ComputeNode> computeNodes = refreshablePool.ListComputeNodes();

                    Assert.Equal(targetDedicated, computeNodes.Count());

                    //
                    //Remove first compute node from the pool
                    //
                    ComputeNode computeNodeToRemove = computeNodes.First();

                    //For Bug234298 ensure start task property doesn't throw
                    Assert.Null(computeNodeToRemove.StartTask);

                    testOutputHelper.WriteLine("Will remove compute node: {0}", computeNodeToRemove.Id);

                    //Remove the compute node from the pool by instance
                    refreshablePool.RemoveFromPool(computeNodeToRemove);

                    //Wait for pool to got to steady state again
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(10)).Wait();

                    refreshablePool.Refresh();
                    //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                    List<ComputeNode> computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();

                    Assert.Equal(targetDedicated - 1, computeNodesAfterRemove.Count);

                    List<string> remainingComputeNodeIds = computeNodesAfterRemove.Select(computeNode => computeNode.Id).ToList();
                    foreach (ComputeNode originalComputeNode in computeNodes)
                    {
                        Assert.Contains(originalComputeNode.Id, remainingComputeNodeIds);
                    }

                    testOutputHelper.WriteLine("Verified that the compute node was removed correctly");

                    //
                    //Remove a second compute node from the pool
                    //

                    ComputeNode secondComputeNodeToRemove = computeNodesAfterRemove.First();
                    string secondComputeNodeToRemoveId = secondComputeNodeToRemove.Id;

                    //Remove the IComputeNode from the pool by id
                    refreshablePool.RemoveFromPool(secondComputeNodeToRemoveId);

                    //Wait for pool to got to steady state again
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(10)).Wait();
                    refreshablePool.Refresh();

                    //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                    computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();

                    Assert.Single(computeNodesAfterRemove);

                    testOutputHelper.WriteLine("Verified that the compute node was removed correctly");

                    //
                    //Remove a 3rd compute node from pool
                    //

                    ComputeNode thirdComputeNodeToRemove = computeNodesAfterRemove.First();
                    string thirdComputeNodeToRemoveId = thirdComputeNodeToRemove.Id;
                    testOutputHelper.WriteLine("Will remove compute node: {0}", thirdComputeNodeToRemoveId);

                    //Remove the IComputeNode from the pool using the ComputeNode object
                    thirdComputeNodeToRemove.RemoveFromPool();

                    //Wait for pool to got to steady state again
                    TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(10)).Wait();

                    //Ensure that the other ComputeNodes were not impacted and we now have 1 less ComputeNode
                    computeNodesAfterRemove = refreshablePool.ListComputeNodes().ToList();
                    Assert.Empty(computeNodesAfterRemove);

                    testOutputHelper.WriteLine("Verified that the ComputeNode was removed correctly");
                }
                finally
                {
                    //Delete the pool
                    batchCli.PoolOperations.DeletePool(poolId);
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }
    }

    /// <summary>
    /// This class exists because XUnit doesn't run tests in a single class in parallel.  To reduce test runtime,
    /// the longest running pool tests have been split out into multiple classes.
    /// </summary>
    public class IntegrationCloudPoolLongRunningTests03
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudPoolLongRunningTests03(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            //Note -- this class does not and should not need a pool fixture
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public async Task LongRunning_LowPriorityComputeNodeAllocated_IsDedicatedFalse()
        {
            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string poolId = "TestLowPri_LongRunning" + TestUtilities.GetMyName();
                const int targetLowPriority = 1;
                try
                {
                    //Create a pool
                    CloudPool pool = batchCli.PoolOperations.CreatePool(
                        poolId,
                        PoolFixture.VMSize,
                        new CloudServiceConfiguration(PoolFixture.OSFamily),
                        targetLowPriorityComputeNodes: targetLowPriority);

                    await pool.CommitAsync().ConfigureAwait(false);

                    testOutputHelper.WriteLine("Created pool {0}", poolId);
                    await pool.RefreshAsync().ConfigureAwait(false);

                    //Wait for compute node allocation
                    await TestUtilities.WaitForPoolToReachStateAsync(batchCli, poolId, AllocationState.Steady, TimeSpan.FromMinutes(10)).ConfigureAwait(false);

                    //Refresh pool to get latest from server
                    await pool.RefreshAsync().ConfigureAwait(false);

                    Assert.Equal(targetLowPriority, pool.CurrentLowPriorityComputeNodes);

                    IEnumerable<ComputeNode> computeNodes = pool.ListComputeNodes();
                    Assert.Single(computeNodes);

                    ComputeNode node = computeNodes.Single();
                    Assert.False(node.IsDedicated);
                }
                finally
                {
                    //Delete the pool
                    await TestUtilities.DeletePoolIfExistsAsync(batchCli, poolId).ConfigureAwait(false);
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }
    }

    [Collection("SharedPoolCollection")]
    public class IntegrationCloudPoolTestsWithSharedPool
    {
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(20);

        public IntegrationCloudPoolTestsWithSharedPool(PaasWindowsPoolFixture poolFixture)
        {
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongLongDuration)]
        public void LongRunning_Bug1771277_1771278_RebootReimageComputeNode()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "LongRunning_Bug1771277_1771278_RebootReimageComputeNode" + TestUtilities.GetMyName();

                try
                {
                    //
                    // Get the pool and check its targets
                    //
                    CloudPool pool = batchCli.PoolOperations.GetPool(poolFixture.PoolId);

                    //
                    //Create a job on this pool with targetDedicated tasks which run for 2m each
                    //
                    const int taskDurationSeconds = 600;

                    CloudJob workflowJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation() { PoolId = poolFixture.PoolId });
                    workflowJob.Commit();

                    CloudJob boundWorkflowJob = batchCli.JobOperations.GetJob(jobId);

                    string taskCmdLine = string.Format("ping 127.0.0.1 -n {0}", taskDurationSeconds);

                    for (int i = 0; i < pool.CurrentDedicatedComputeNodes; i++)
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
                    IEnumerable<ComputeNode> rebootingComputeNodes = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId);
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
                    IEnumerable<ComputeNode> reimagingComputeNodes = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId);
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

                    IEnumerable<ComputeNode> computeNodes = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId);

                    while (computeNodes.Any(computeNode => computeNode.State != ComputeNodeState.Idle))
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(10));
                        computeNodes = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();
                        Assert.False(DateTime.UtcNow > timeoutAfterThisTimeUtc, "Timed out waiting for compute nodes in pool to reach idle state");
                    }
                }
            }

            SynchronizationContextHelper.RunTest(test, LongTestTimeout);
        }
    }
}
