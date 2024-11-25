// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BatchTestCommon;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
using BatchClientIntegrationTests.Fixtures;
using BatchClientIntegrationTests.IntegrationTestUtilities;
using Microsoft.Azure.Batch.Protocol.BatchRequests;
using Microsoft.Rest.Azure;
using Xunit;
using Xunit.Abstractions;
using Protocol = Microsoft.Azure.Batch.Protocol;
using Azure.Storage.Blobs;
using Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities;

namespace BatchClientIntegrationTests
{
    /// <summary>
    /// Tests focused primarily on the <see cref="ComputeNode"/>.
    /// </summary>
    [Collection("SharedPoolCollection")]
    public class ComputeNodeIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(1);

        public ComputeNodeIntegrationTests(ITestOutputHelper testOutputHelper, PaasWindowsPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void BugComputeNodeMissingStartTaskInfo_RunAfterPoolIsUsed()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                CloudPool pool = batchCli.PoolOperations.GetPool(poolFixture.PoolId);

                // confirm start task info exists and has rational values

                foreach (ComputeNode curComputeNode in pool.ListComputeNodes())
                {
                    StartTaskInformation sti = curComputeNode.StartTaskInformation;

                    // set when pool was created
                    Assert.NotNull(sti);
                    Assert.True(StartTaskState.Running == sti.State || StartTaskState.Completed == sti.State);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug1771163TestGetComputeNode_RefreshComputeNode()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                PoolOperations poolOperations = batchCli.PoolOperations;

                List<ComputeNode> computeNodeList = poolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                ComputeNode computeNodeToGet = computeNodeList.First();
                string computeNodeId = computeNodeToGet.Id;
                //
                // Get compute node via the manager
                //

                ComputeNode computeNodeFromManager = poolOperations.GetComputeNode(poolFixture.PoolId, computeNodeId);
                CompareComputeNodeObjects(computeNodeToGet, computeNodeFromManager);

                //
                // Get compute node via the pool
                //
                CloudPool pool = poolOperations.GetPool(poolFixture.PoolId);

                ComputeNode computeNodeFromPool = pool.GetComputeNode(computeNodeId);
                CompareComputeNodeObjects(computeNodeToGet, computeNodeFromPool);
                //
                // Refresh compute node
                //

                //Refresh with a detail level
                computeNodeToGet.Refresh(new ODATADetailLevel() { SelectClause = "affinityId,id" });

                //Confirm we have the reduced detail level
                Assert.Equal(computeNodeToGet.AffinityId, computeNodeFromManager.AffinityId);
                Assert.Null(computeNodeToGet.IPAddress);
                Assert.Null(computeNodeToGet.LastBootTime);
                Assert.Null(computeNodeToGet.State);
                Assert.Null(computeNodeToGet.StartTaskInformation);

                //Refresh again with increased detail level
                computeNodeToGet.Refresh();
                CompareComputeNodeObjects(computeNodeToGet, computeNodeFromManager);
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }



        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task ComputeNode_Deallocate_Start_ComputeNode()
        {

            async Task test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                PoolOperations poolOperations = batchCli.PoolOperations;

                List<ComputeNode> computeNodeList = poolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                ComputeNode computeNodeToGet = computeNodeList.First();
                string computeNodeId = computeNodeToGet.Id;

                computeNodeToGet.Deallocate();

                while( computeNodeToGet.State != ComputeNodeState.Deallocated)
                {
                    await Task.Delay(1000).ConfigureAwait(false);

                    await computeNodeToGet.RefreshAsync().ConfigureAwait(false);
                }

                Assert.Equal(ComputeNodeState.Deallocated, computeNodeToGet.State);

                computeNodeToGet.Start();

                while (computeNodeToGet.State != ComputeNodeState.Starting)
                {
                    await Task.Delay(1000).ConfigureAwait(false);

                    await computeNodeToGet.RefreshAsync().ConfigureAwait(false);
                }

                Assert.Equal(ComputeNodeState.Starting, computeNodeToGet.State);

            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug2302907_TestComputeNodeDoesInheritBehaviors()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false);
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor();
                batchCli.PoolOperations.CustomBehaviors.Add(interceptor);

                List<ComputeNode> computeNodeList = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId).ToList();

                ComputeNode computeNode = computeNodeList.First();

                Assert.Equal(2, computeNode.CustomBehaviors.Count);
                Assert.Contains(interceptor, computeNode.CustomBehaviors);
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public void Bug2329884_ComputeNodeRecentTasksAndComputeNodeError()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                string jobId = "Bug2329884Job-" + TestUtilities.GetMyName();
                Protocol.RequestInterceptor interceptor = null;

                try
                {
                    const string taskId = "hiWorld";

                    //
                    // Create the job
                    //
                    CloudJob unboundJob = batchCli.JobOperations.CreateJob(jobId, new PoolInformation());
                    unboundJob.PoolInformation.PoolId = poolFixture.PoolId;

                    unboundJob.Commit();

                    CloudJob boundJob = batchCli.JobOperations.GetJob(jobId);
                    CloudTask myTask = new CloudTask(taskId, "cmd /c echo hello world");

                    boundJob.AddTask(myTask);

                    testOutputHelper.WriteLine("Initial job commit()");

                    //
                    // Wait for task to go to completion
                    //
                    Utilities utilities = batchCli.Utilities;
                    TaskStateMonitor taskStateMonitor = utilities.CreateTaskStateMonitor();

                    taskStateMonitor.WaitAll(
                        boundJob.ListTasks(),
                        Microsoft.Azure.Batch.Common.TaskState.Completed,
                        new TimeSpan(0, 3 /*min*/, 0));

                    CloudTask boundTask = boundJob.GetTask(taskId);

                    //Since the compute node name comes back as "Node:<computeNodeId>" we need to split on : to get the actual compute node name
                    string computeNodeId = boundTask.ComputeNodeInformation.AffinityId.Split(':')[1];

                    //
                    // Check recent tasks
                    //
                    ComputeNode computeNode = batchCli.PoolOperations.GetComputeNode(poolFixture.PoolId, computeNodeId);

                    testOutputHelper.WriteLine("Recent tasks:");

                    foreach (TaskInformation recentTask in computeNode.RecentTasks)
                    {
                        testOutputHelper.WriteLine("Compute node has recent task Job: {0}, Task: {1}, State: {2}, Subtask: {3}",
                            recentTask.JobId,
                            recentTask.TaskId,
                            recentTask.TaskState,
                            recentTask.SubtaskId);
                    }

                    TaskInformation myTaskInfo = computeNode.RecentTasks.First(taskInfo => taskInfo.JobId.Equals(
                        jobId, StringComparison.InvariantCultureIgnoreCase) &&
                        taskInfo.TaskId.Equals(taskId, StringComparison.InvariantCultureIgnoreCase));

                    Assert.Equal(TaskState.Completed, myTaskInfo.TaskState);
                    Assert.NotNull(myTaskInfo.ExecutionInformation);
                    Assert.Equal(0, myTaskInfo.ExecutionInformation.ExitCode);

                    //
                    // Check compute node Error
                    //
                    const string expectedErrorCode = "TestErrorCode";
                    const string expectedErrorMessage = "Test error message";
                    const string nvpValue = "Test";

                    //We use mocking to return a fake compute node object here to test Compute Node Error because we cannot force one easily
                    interceptor = new Protocol.RequestInterceptor((req =>
                    {
                        if (req is ComputeNodeGetBatchRequest)
                        {
                            var typedRequest = req as ComputeNodeGetBatchRequest;

                            typedRequest.ServiceRequestFunc = (token) =>
                            {
                                var response = new AzureOperationResponse<Protocol.Models.ComputeNode, Protocol.Models.ComputeNodeGetHeaders>();

                                List<Protocol.Models.ComputeNodeError> errors =
                                    new List<Protocol.Models.ComputeNodeError>();

                                //Generate first Compute Node Error
                                List<Protocol.Models.NameValuePair> nvps = new List<Protocol.Models.NameValuePair>
                                {
                                        new Protocol.Models.NameValuePair() { Name = nvpValue, Value = nvpValue }
                                };

                                Protocol.Models.ComputeNodeError error1 = new Protocol.Models.ComputeNodeError
                                {
                                    Code = expectedErrorCode,
                                    Message = expectedErrorMessage,
                                    ErrorDetails = nvps
                                };

                                errors.Add(error1);

                                //Generate second Compute Node Error
                                nvps = new List<Protocol.Models.NameValuePair>
                                {
                                    new Protocol.Models.NameValuePair() { Name = nvpValue, Value = nvpValue }
                                };

                                Protocol.Models.ComputeNodeError error2 = new Protocol.Models.ComputeNodeError
                                {
                                    Code = expectedErrorCode,
                                    Message = expectedErrorMessage,
                                    ErrorDetails = nvps
                                };

                                errors.Add(error2);

                                Protocol.Models.ComputeNode protoComputeNode = new Protocol.Models.ComputeNode
                                {
                                    Id = computeNodeId,
                                    State = Protocol.Models.ComputeNodeState.Idle,
                                    Errors = errors
                                };

                                response.Body = protoComputeNode;

                                return Task.FromResult(response);
                            };
                        }
                    }));

                    batchCli.PoolOperations.CustomBehaviors.Add(interceptor);

                    computeNode = batchCli.PoolOperations.GetComputeNode(poolFixture.PoolId, computeNodeId);

                    Assert.Equal(computeNodeId, computeNode.Id);
                    Assert.NotNull(computeNode.Errors);
                    Assert.Equal(2, computeNode.Errors.Count());

                    foreach (ComputeNodeError computeNodeError in computeNode.Errors)
                    {
                        Assert.Equal(expectedErrorCode, computeNodeError.Code);
                        Assert.Equal(expectedErrorMessage, computeNodeError.Message);
                        Assert.NotNull(computeNodeError.ErrorDetails);
                        Assert.Single(computeNodeError.ErrorDetails);
                        Assert.Contains(nvpValue, computeNodeError.ErrorDetails.First().Name);
                    }
                }
                finally
                {
                    batchCli.JobOperations.DeleteJob(jobId);
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void Bug2342986_StartTaskMissingOnComputeNode()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                CloudPool pool = batchCli.PoolOperations.GetPool(poolFixture.PoolId);

                testOutputHelper.WriteLine("Getting pool");
                StartTask poolStartTask = pool.StartTask;

                Assert.NotNull(poolStartTask);
                Assert.NotNull(poolStartTask.EnvironmentSettings);

                IEnumerable<ComputeNode> computeNodes = pool.ListComputeNodes();

                Assert.True(computeNodes.Any());

                testOutputHelper.WriteLine("Checking every compute nodes start task in the pool matches the pools start task");
                foreach (ComputeNode computeNode in computeNodes)
                {
                    testOutputHelper.WriteLine("Checking start task of compute node: {0}", computeNode.Id);

                    //Check that the property is correctly set on each compute node
                    Assert.NotNull(computeNode.StartTask);

                    Assert.Equal(poolStartTask.CommandLine, computeNode.StartTask.CommandLine);
                    Assert.Equal(poolStartTask.MaxTaskRetryCount, computeNode.StartTask.MaxTaskRetryCount);
                    Assert.Equal(AutoUserScope.Pool, poolStartTask.UserIdentity.AutoUser.Scope);
                    Assert.Equal(AutoUserScope.Pool, computeNode.StartTask.UserIdentity.AutoUser.Scope);
                    Assert.Equal(poolStartTask.WaitForSuccess, computeNode.StartTask.WaitForSuccess);

                    if (poolStartTask.EnvironmentSettings != null)
                    {
                        Assert.Equal(poolStartTask.EnvironmentSettings.Count, computeNode.StartTask.EnvironmentSettings.Count);
                        foreach (EnvironmentSetting environmentSetting in poolStartTask.EnvironmentSettings)
                        {
                            EnvironmentSetting matchingEnvSetting = computeNode.StartTask.EnvironmentSettings.FirstOrDefault(envSetting => envSetting.Name == environmentSetting.Name);

                            Assert.NotNull(matchingEnvSetting);
                            Assert.Equal(environmentSetting.Name, matchingEnvSetting.Name);
                            Assert.Equal(environmentSetting.Value, matchingEnvSetting.Value);
                        }
                    }

                    if (poolStartTask.ResourceFiles != null)
                    {
                        Assert.Equal(poolStartTask.ResourceFiles.Count, computeNode.StartTask.ResourceFiles.Count);

                        foreach (ResourceFile resourceFile in poolStartTask.ResourceFiles)
                        {
                            ResourceFile matchingResourceFile = computeNode.StartTask.ResourceFiles.FirstOrDefault(item => item.HttpUrl == resourceFile.HttpUrl);

                            Assert.NotNull(matchingResourceFile);
                            Assert.Equal(resourceFile.HttpUrl, matchingResourceFile.HttpUrl);
                            Assert.Equal(resourceFile.FilePath, matchingResourceFile.FilePath);
                        }
                    }

                    //Try to set some properties of the compute node's start task and ensure it fails

                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.CommandLine = "Test"; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.MaxTaskRetryCount = 5; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.UserIdentity = new UserIdentity("foo"); });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.WaitForSuccess = true; });
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.EnvironmentSettings = new List<EnvironmentSetting>(); });

                    if (computeNode.StartTask.EnvironmentSettings != null)
                    {
                        TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.EnvironmentSettings.Add(new EnvironmentSetting("test", "test")); });
                    }
                    TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.ResourceFiles = new List<ResourceFile>(); });
                    if (computeNode.StartTask.ResourceFiles != null)
                    {
                        TestUtilities.AssertThrows<InvalidOperationException>(() => { computeNode.StartTask.ResourceFiles.Add(ResourceFile.FromUrl("test", "test")); });
                    }
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task OnlineOfflineTest()
        {
            await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using BatchClient batchCli = await TestUtilities.OpenBatchClientFromEnvironmentAsync();
                    TimeSpan refreshPollingTimeout = TimeSpan.FromMinutes(3);
                    CloudPool pool = poolFixture.Pool;

                    List<ComputeNode> nodes = pool.ListComputeNodes().ToList();

                    Assert.True(nodes.Count > 0);

                    // pick a victim compute node.  cleanup code needs this set
                    ComputeNode victim = nodes[0];

                    try
                    {
                        Assert.True(victim.SchedulingState.HasValue && (SchedulingState.Enabled == victim.SchedulingState));
                        Assert.True(victim.State.HasValue && (ComputeNodeState.Idle == victim.State));

                        // PoolOperations methods
                        {
                            // disable task scheduling
                            batchCli.PoolOperations.DisableComputeNodeScheduling(pool.Id, victim.Id, DisableComputeNodeSchedulingOption.Terminate);

                            // Li says state change is not atomic so we will sleep
                            // asserted above this node is idle so no need to wait for task fussery
                            await TestUtilities.RefreshBasedPollingWithTimeoutAsync(
                                    refreshing: victim,
                                    condition: () => Task.FromResult(victim.SchedulingState.HasValue && (SchedulingState.Disabled == victim.SchedulingState)),
                                    timeout: refreshPollingTimeout).ConfigureAwait(false);

                            Assert.Equal(SchedulingState.Disabled, victim.SchedulingState);

                            // enable task scheduling
                            batchCli.PoolOperations.EnableComputeNodeScheduling(pool.Id, victim.Id);

                            await TestUtilities.RefreshBasedPollingWithTimeoutAsync(
                                    refreshing: victim,
                                    condition: () => Task.FromResult(victim.SchedulingState.HasValue && (SchedulingState.Enabled == victim.SchedulingState)),
                                    timeout: refreshPollingTimeout);

                            Assert.Equal(SchedulingState.Enabled, victim.SchedulingState);
                        }

                        // ComputeNode methods
                        {
                            // disable task scheduling

                            victim.DisableScheduling(DisableComputeNodeSchedulingOption.TaskCompletion);

                            await TestUtilities.RefreshBasedPollingWithTimeoutAsync(
                                    refreshing: victim,
                                    condition: () => Task.FromResult(victim.SchedulingState.HasValue && (SchedulingState.Disabled == victim.SchedulingState)),
                                    timeout: refreshPollingTimeout).ConfigureAwait(false);

                            Assert.Equal(SchedulingState.Disabled, victim.SchedulingState);

                            // enable task scheduling

                            victim.EnableScheduling();

                            await TestUtilities.RefreshBasedPollingWithTimeoutAsync(
                                    refreshing: victim,
                                    condition: () => Task.FromResult(victim.SchedulingState.HasValue && (SchedulingState.Enabled == victim.SchedulingState)),
                                    timeout: refreshPollingTimeout).ConfigureAwait(false);

                            Assert.Equal(SchedulingState.Enabled, victim.SchedulingState);

                            // now test azureerror code for: NodeAlreadyInTargetSchedulingState
                            bool gotCorrectException = false;

                            try
                            {
                                victim.EnableScheduling();  // it is already enabled so this should trigger exception
                            }
                            catch (Exception ex)
                            {
                                TestUtilities.AssertIsBatchExceptionAndHasCorrectAzureErrorCode(ex, Microsoft.Azure.Batch.Common.BatchErrorCodeStrings.NodeAlreadyInTargetSchedulingState, testOutputHelper);

                                gotCorrectException = true;
                            }

                            if (!gotCorrectException)
                            {
                                throw new Exception("OnlineOfflineTest: failed to see an exception for NodeAlreadyInTargetSchedulingState test");
                            }
                        }
                    }
                    finally // restore state of victim compute node
                    {
                        try
                        {
                            // do not pollute the shared pool with disabled scheduling
                            if (null != victim)
                            {
                                victim.EnableScheduling();
                            }
                        }
                        catch (Exception ex)
                        {
                            testOutputHelper.WriteLine(string.Format("OnlineOfflineTest: exception during exit trying to restore scheduling state: {0}", ex.ToString()));
                        }
                    }
                },
                TestTimeout);
        }

        #region Test helpers

        private static void CompareComputeNodeObjects(ComputeNode first, ComputeNode second)
        {
            Assert.Equal(first.AffinityId, second.AffinityId);
            Assert.Equal(first.IPAddress, second.IPAddress);
            Assert.Equal(first.LastBootTime, second.LastBootTime);
            Assert.Equal(first.Id, second.Id);
            Assert.Equal(first.StateTransitionTime, second.StateTransitionTime);
            Assert.Equal(first.Url, second.Url);
            Assert.Equal(first.AllocationTime, second.AllocationTime);
            Assert.Equal(first.VirtualMachineSize, second.VirtualMachineSize);
        }

        #endregion
    }

    [Collection("SharedLinuxPoolCollection")]
    public class IntegrationComputeNodeLinuxTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly PoolFixture poolFixture;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(3);

        public IntegrationComputeNodeLinuxTests(ITestOutputHelper testOutputHelper, IaasLinuxPoolFixture poolFixture)
        {
            this.testOutputHelper = testOutputHelper;
            this.poolFixture = poolFixture;
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestComputeNodeUserIaas()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                CloudPool sharedPool = poolFixture.Pool;
                List<string> cnuNamesToDelete = new List<string>();

                // pick a compute node to victimize with user accounts
                var nodes = sharedPool.ListComputeNodes().ToList();

                ComputeNode cn = nodes[0];

                try
                {
                    ComputeNodeUser bob = batchCli.PoolOperations.CreateComputeNodeUser(sharedPool.Id, cn.Id);

                    bob.Name = "bob";
                    bob.ExpiryTime = DateTime.UtcNow + TimeSpan.FromHours(25);
                    bob.Password = "password";
                    bob.SshPublicKey = "base64==";

                    cnuNamesToDelete.Add(bob.Name); // remember to clean this up

                    bob.Commit(ComputeNodeUserCommitSemantics.AddUser);

                    bob.SshPublicKey = "base65==";

                    bob.Commit(ComputeNodeUserCommitSemantics.UpdateUser);

                    // TODO:  need to close the loop on this somehow... move to unit/interceptor-based?
                    //        currently the server is timing out.

                }
                finally
                {
                    // clear any old accounts
                    try
                    {
                        foreach (string curCNUName in cnuNamesToDelete)
                        {
                            testOutputHelper.WriteLine("TestComputeNodeUserIAAS attempting to delete the following <nodeid,user>: <{0},{1}>", cn.Id, curCNUName);
                            cn.DeleteComputeNodeUser(curCNUName);
                        }
                    }
                    catch (Exception ex)
                    {
                        testOutputHelper.WriteLine("TestComputeNodeUserIAAS: exception deleting user account.  ex: " + ex.ToString());
                    }
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task ComputeNodeUploadLogs()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result;
                const string containerName = "computenodelogscontainer";

                // Generate a storage container URL
                StagingStorageAccount storageAccount = TestUtilities.GetStorageCredentialsFromEnvironment();
                BlobServiceClient blobClient = BlobUtilities.GetBlobServiceClient(storageAccount);
                BlobContainerClient containerClient = BlobUtilities.GetBlobContainerClient(containerName, blobClient, storageAccount);

                try
                {
                    containerClient.CreateIfNotExists();
                    string sasUri = BlobUtilities.GetWriteableSasUri(containerClient, storageAccount);

                    var blobs = containerClient.GetAllBlobs();

                    // Ensure that there are no items in the container to begin with
                    Assert.Empty(blobs);

                    var startTime = DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5));

                    var node = batchCli.PoolOperations.ListComputeNodes(poolFixture.PoolId).First();
                    var result = batchCli.PoolOperations.UploadComputeNodeBatchServiceLogs(
                        poolFixture.PoolId,
                        node.Id,
                        sasUri,
                        startTime);

                    Assert.NotEqual(0, result.NumberOfFilesUploaded);
                    Assert.NotEmpty(result.VirtualDirectoryName);

                    // Allow up to 2m for files to get uploaded
                    DateTime timeoutAt = DateTime.UtcNow.AddMinutes(2);
                    while (DateTime.UtcNow < timeoutAt)
                    {
                        blobs = containerClient.GetAllBlobs();
                        if (blobs.Any())
                        {
                            break;
                        }
                    }

                    Assert.NotEmpty(blobs);
                }
                finally
                {
                    containerClient.DeleteIfExists();
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public void TestGetRemoteLoginSettings()
        {
            void test()
            {
                using BatchClient batchCli = TestUtilities.OpenBatchClient(TestUtilities.GetCredentialsFromEnvironment());
                CloudPool sharedPool = poolFixture.Pool;

                try
                {
                    // get a compute node.
                    // get its RLS via PoolOps and via CN
                    // Assert there are values and that the values are equal

                    var nodes = sharedPool.ListComputeNodes().ToList();

                    Assert.Single(nodes);

                    ComputeNode cn = nodes[0];

                    // get the RLS via each object
                    RemoteLoginSettings rlsViaPoolOps = batchCli.PoolOperations.GetRemoteLoginSettings(sharedPool.Id, cn.Id);
                    RemoteLoginSettings rlsViaNode = cn.GetRemoteLoginSettings();

                    // they must have RLS
                    Assert.NotNull(rlsViaNode);
                    Assert.NotNull(rlsViaPoolOps);

                    // there must be an IP in each RLS
                    Assert.False(string.IsNullOrWhiteSpace(rlsViaPoolOps.IPAddress));
                    Assert.False(string.IsNullOrWhiteSpace(rlsViaNode.IPAddress));

                    // the ports must match
                    Assert.Equal(expected: rlsViaNode.Port, actual: rlsViaPoolOps.Port);
                }
                finally
                {
                    // cleanup goes here
                }
            }

            SynchronizationContextHelper.RunTest(test, TestTimeout);
        }
    }
}
