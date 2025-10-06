// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    public class BatchPoolIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchPoolIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchPoolIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPoolNodeCounts()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "GetPoolNodeCounts", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync();

                int count = 0;
                bool poolFound = false;
                await foreach (BatchPoolNodeCounts item in client.GetPoolNodeCountsAsync())
                {
                    count++;
                    poolFound |= pool.Id.Equals(item.PoolId, StringComparison.OrdinalIgnoreCase);
                }

                // verify we found at least one poolnode
                Assert.AreNotEqual(0, count);
                Assert.IsTrue(poolFound);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PoolExists()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PoolExists", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(0);
                bool poolExist = await client.PoolExistsAsync(poolID);

                var poolDoesntExist = await client.PoolExistsAsync("fakepool");

                // verify exists
                Assert.True(poolExist);
                Assert.False(poolDoesntExist);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PoolRemoveNodes()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PoolRemoveNodes", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool pool = await iaasWindowsPoolFixture.CreatePoolAsync(2);
                BatchPool orginalPool = await client.GetPoolAsync(poolID);

                string batchNodeID = "";
                int nodeCount = 0;
                await foreach (BatchNode item in client.GetNodesAsync(poolID))
                {
                    nodeCount++;
                    batchNodeID = item.Id;
                }

                Assert.AreEqual(2, nodeCount);

                BatchNodeRemoveOptions content = new BatchNodeRemoveOptions(new string[] { batchNodeID });
                RemoveNodesOperation operation = await client.RemoveNodesAsync(poolID, content);
                await operation.WaitForCompletionAsync();

                BatchPool modfiedPool = operation.Value;

                // verify that some usage exists, we can't predict what usage that might be at the time of the test
                Assert.NotNull(modfiedPool);
                Assert.AreNotEqual(AllocationState.Resizing, modfiedPool.AllocationState);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task AutoScale()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "AutoScale", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;
            string poolASFormulaOrig = "$TargetDedicated = 0;";
            string poolASFormulaNew = "$TargetDedicated = 1;";
            TimeSpan evalInterval = TimeSpan.FromMinutes(6);

            try
            {
                // create a pool to verify we have something to query for
                BatchPoolCreateOptions batchPoolCreateOptions = iaasWindowsPoolFixture.CreatePoolOptions();
                batchPoolCreateOptions.EnableAutoScale = true;
                batchPoolCreateOptions.AutoScaleEvaluationInterval = evalInterval;
                batchPoolCreateOptions.AutoScaleFormula = poolASFormulaOrig;
                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                BatchPool autoScalePool = await iaasWindowsPoolFixture.WaitForPoolAllocation(client, iaasWindowsPoolFixture.PoolId);

                // verify autoscale settings
                Assert.IsTrue(autoScalePool.EnableAutoScale);
                Assert.AreEqual(autoScalePool.AutoScaleFormula, poolASFormulaOrig);

                // evaluate autoscale formula
                BatchPoolEvaluateAutoScaleOptions batchPoolEvaluateAutoScaleContent = new BatchPoolEvaluateAutoScaleOptions(poolASFormulaNew);
                AutoScaleRun eval = await client.EvaluatePoolAutoScaleAsync(autoScalePool.Id, batchPoolEvaluateAutoScaleContent);
                Assert.Null(eval.Error);

                // change eval interval
                TimeSpan newEvalInterval = evalInterval + TimeSpan.FromMinutes(1);
                BatchPoolEnableAutoScaleOptions batchPoolEnableAutoScaleContent = new BatchPoolEnableAutoScaleOptions()
                {
                    AutoScaleEvaluationInterval = newEvalInterval,
                    AutoScaleFormula = poolASFormulaNew,
                };

                // verify
                response = await client.EnablePoolAutoScaleAsync(autoScalePool.Id, batchPoolEnableAutoScaleContent);
                Assert.AreEqual(200, response.Status);
                autoScalePool = await client.GetPoolAsync((autoScalePool.Id));
                Assert.AreEqual(autoScalePool.AutoScaleEvaluationInterval, newEvalInterval);
                Assert.AreEqual(autoScalePool.AutoScaleFormula, poolASFormulaNew);

                response = await client.DisablePoolAutoScaleAsync(autoScalePool.Id);
                Assert.AreEqual(200, response.Status);
            }
            finally
            {
                DeletePoolOperation deletePoolOperation = await client.DeletePoolAsync(poolID);
                await deletePoolOperation.WaitForCompletionAsync();
            }
        }

        [RecordedTest]
        public async Task PoolCreatedOsDiskSecurityProfile()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "SecurityProfilePool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;
            TimeSpan evalInterval = TimeSpan.FromMinutes(6);
            var VMSize = "STANDARD_D2S_V5";
            var targetDedicatedNodes = 1;

            try
            {
                // create a new pool
                BatchVmImageReference imageReference = new BatchVmImageReference()
                {
                    Publisher = "microsoftwindowsserver",
                    Offer = "windowsserver",
                    Sku = "2022-datacenter-g2",
                    Version = "latest"
                };

                VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64")
                {
                    SecurityProfile = new SecurityProfile()
                    {
                        SecurityType = SecurityTypes.ConfidentialVM,
                        EncryptionAtHost = false,
                        UefiSettings = new BatchUefiSettings()
                        {
                            SecureBootEnabled = true,
                            VTpmEnabled = true,
                        }
                    },
                    OsDisk = new BatchOsDisk()
                    {
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new ManagedDisk()
                        {
                            SecurityProfile = new BatchVmDiskSecurityProfile()
                            {
                                SecurityEncryptionType = SecurityEncryptionTypes.VMGuestStateOnly,
                            }
                        }
                    }
                };

                BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(poolID, VMSize)
                {
                    VirtualMachineConfiguration = virtualMachineConfiguration,
                    TargetDedicatedNodes = targetDedicatedNodes,
                };

                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                Assert.AreEqual(201, response.Status);

                BatchPool pool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(pool.VirtualMachineConfiguration.SecurityProfile.SecurityType, SecurityTypes.ConfidentialVM);
                Assert.AreEqual(pool.VirtualMachineConfiguration.SecurityProfile.EncryptionAtHost, false);
                Assert.AreEqual(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled, true);
                Assert.AreEqual(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.VTpmEnabled, true);
                Assert.AreEqual(pool.VirtualMachineConfiguration.OsDisk.Caching, CachingType.ReadWrite);
                Assert.AreEqual(pool.VirtualMachineConfiguration.OsDisk.ManagedDisk.SecurityProfile.SecurityEncryptionType, SecurityEncryptionTypes.VMGuestStateOnly);
            }catch (RequestFailedException e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task ResizePool()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ResizePool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool resizePool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // verify exists
                BatchPoolResizeOptions resizeContent = new BatchPoolResizeOptions()
                {
                    TargetDedicatedNodes = 1,
                    ResizeTimeout = TimeSpan.FromMinutes(10),
                };

                // resize pool
                await client.ResizePoolAsync(poolID, resizeContent);
                resizePool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(AllocationState.Resizing, resizePool.AllocationState);

                // stop resizing
                StopPoolResizeOperation operation = await client.StopPoolResizeAsync(poolID);
                await operation.WaitForCompletionAsync();
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task ReplacePool()
        {
            var client = CreateBatchClient();
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "ReplacePool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;

            try
            {
                // create a pool to verify we have something to query for
                BatchPool orginalPool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // replace pool
                BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
                    new BatchApplicationPackageReference("dotnotsdkbatchapplication1")
                    {
                        Version = "1"
                    }
                };

                BatchMetadataItem[] metadataIems = new BatchMetadataItem[] {
                    new BatchMetadataItem("name", "value")
                };

                BatchCertificateReference[] certificateReferences = new BatchCertificateReference[] { };

                BatchPoolReplaceOptions replaceContent = new BatchPoolReplaceOptions(certificateReferences, batchApplicationPackageReferences, metadataIems);
                Response response = await client.ReplacePoolPropertiesAsync(poolID, replaceContent);
                BatchPool replacePool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(replacePool.Metadata.First().Value, "value");
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PatchPool()
        {
            var client = CreateBatchClient();
            var startTaskCommandLine = "cmd /c echo hello";
            var displayName = "newDisplayName";
            WindowsPoolFixture iaasWindowsPoolFixture = new WindowsPoolFixture(client, "PatchPool", IsPlayBack());
            var poolID = iaasWindowsPoolFixture.PoolId;
            var nodeUserPassword = "Password1234!";
            try
            {
                // create a pool to verify we have something to query for
                BatchPool orginalPool = await iaasWindowsPoolFixture.CreatePoolAsync(0);

                // update pool

                BatchPoolUpdateOptions updateContent = new BatchPoolUpdateOptions();

                updateContent.VmSize = "STANDARD_D2S_V3";
                updateContent.TaskSlotsPerNode = 1;
                updateContent.EnableInterNodeCommunication = true;
                updateContent.NetworkConfiguration = new NetworkConfiguration()
                {
                    EndpointConfiguration = new BatchPoolEndpointConfiguration(
                        new List<BatchInboundNatPool>()
                        {
                            new BatchInboundNatPool("ruleName", InboundEndpointProtocol.Tcp, 3389, 15000, 15100)
                        }
                    )
                    // verify pool got updated
                };

                updateContent.Metadata.Add(new BatchMetadataItem("name", "value"));
                updateContent.ApplicationPackageReferences.Add(new BatchApplicationPackageReference("dotnotsdkbatchapplication1")
                {
                    Version = "1"
                });

                updateContent.StartTask = new BatchStartTask(startTaskCommandLine);
                updateContent.DisplayName = displayName;
                updateContent.VirtualMachineConfiguration = orginalPool.VirtualMachineConfiguration;
                updateContent.VirtualMachineConfiguration.NodePlacementConfiguration = new BatchNodePlacementConfiguration()
                {
                    Policy = BatchNodePlacementPolicyType.Zonal
                };
                updateContent.UpgradePolicy = new UpgradePolicy(UpgradeMode.Automatic)
                {
                    AutomaticOsUpgradePolicy = new AutomaticOsUpgradePolicy()
                    {
                        DisableAutomaticRollback = true,
                        EnableAutomaticOsUpgrade = true,
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
                updateContent.MountConfiguration.Add(new MountConfiguration()
                {
                    AzureBlobFileSystemConfiguration = new AzureBlobFileSystemConfiguration("accountName", "blobContainerName", "bfusepath")
                    {
                        AccountKey = "accountKey",
                    },
                }
                );

                updateContent.ResourceTags.Add("tag1", "value1");
                updateContent.ResourceTags.Add("tag2", "value2");

                updateContent.TaskSchedulingPolicy = new BatchTaskSchedulingPolicy(BatchNodeFillType.Pack);

                updateContent.UserAccounts.Add(new UserAccount("test1", nodeUserPassword));
                updateContent.UserAccounts.Add(new UserAccount("test2", nodeUserPassword) { ElevationLevel = ElevationLevel.NonAdmin });
                updateContent.UserAccounts.Add(new UserAccount("test3", nodeUserPassword) { ElevationLevel = ElevationLevel.Admin });
                updateContent.UserAccounts.Add(new UserAccount("test4", nodeUserPassword) { LinuxUserConfiguration = new LinuxUserConfiguration() { SshPrivateKey = "AAAA==" } });

                Response response = await client.UpdatePoolAsync(poolID, updateContent);
                BatchPool patchPool = await client.GetPoolAsync(poolID);
                Assert.AreEqual(patchPool.Metadata.First().Value, "value");

                Assert.AreEqual(startTaskCommandLine, patchPool.StartTask.CommandLine);
                Assert.AreEqual(updateContent.Metadata.Single().Name , patchPool.Metadata.Single().Name);
                Assert.AreEqual(updateContent.Metadata.Single().Value, patchPool.Metadata.Single().Value);
                Assert.AreEqual(displayName, patchPool.DisplayName);
                Assert.AreEqual(2, patchPool.ResourceTags.Count);
                Assert.AreEqual("value1", patchPool.ResourceTags["tag1"]);
                Assert.AreEqual(20, patchPool.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent);
                Assert.AreEqual(BatchNodeFillType.Pack, patchPool.TaskSchedulingPolicy.NodeFillType);
                Assert.AreEqual(4, patchPool.UserAccounts.Count);
                Assert.AreEqual("standard_d2s_v3", patchPool.VmSize);
                Assert.AreEqual(1, patchPool.TaskSlotsPerNode);
                Assert.IsTrue(patchPool.EnableInterNodeCommunication);
                Assert.AreEqual("ruleName", patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().Name);
                Assert.AreEqual(InboundEndpointProtocol.Tcp, patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().Protocol);
                Assert.AreEqual(3389, patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().BackendPort);
                Assert.AreEqual(15000, patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().FrontendPortRangeStart);
                Assert.AreEqual(15100, patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().FrontendPortRangeEnd);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
