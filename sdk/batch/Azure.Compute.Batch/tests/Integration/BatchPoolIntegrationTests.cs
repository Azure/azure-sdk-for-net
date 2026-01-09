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
using Azure.Core;
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

                Assert.Multiple(() =>
                {
                    // verify we found at least one poolnode
                    Assert.That(count, Is.Not.EqualTo(0));
                    Assert.That(poolFound, Is.True);
                });
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

                Assert.Multiple(() =>
                {
                    // verify exists
                    Assert.That(poolExist, Is.True);
                    Assert.That((bool)poolDoesntExist, Is.False);
                });
            }
            catch (RequestFailedException e)
            {
                Assert.That(new[] { "404", }, Does.Contain(e.Status.ToString()));
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

                Assert.That(nodeCount, Is.EqualTo(2));

                BatchNodeRemoveOptions content = new BatchNodeRemoveOptions(new string[] { batchNodeID });
                RemoveNodesOperation operation = await client.RemoveNodesAsync(poolID, content);
                await operation.WaitForCompletionAsync();

                BatchPool modfiedPool = operation.Value;

                // verify that some usage exists, we can't predict what usage that might be at the time of the test
                Assert.That(modfiedPool, Is.Not.Null);
                Assert.That(modfiedPool.AllocationState, Is.Not.EqualTo(AllocationState.Resizing));
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

                Assert.Multiple(() =>
                {
                    // verify autoscale settings
                    Assert.That(autoScalePool.EnableAutoScale, Is.True);
                    Assert.That(poolASFormulaOrig, Is.EqualTo(autoScalePool.AutoScaleFormula));
                });

                // evaluate autoscale formula
                BatchPoolEvaluateAutoScaleOptions batchPoolEvaluateAutoScaleContent = new BatchPoolEvaluateAutoScaleOptions(poolASFormulaNew);
                AutoScaleRun eval = await client.EvaluatePoolAutoScaleAsync(autoScalePool.Id, batchPoolEvaluateAutoScaleContent);
                Assert.That(eval.Error, Is.Null);

                // change eval interval
                TimeSpan newEvalInterval = evalInterval + TimeSpan.FromMinutes(1);
                BatchPoolEnableAutoScaleOptions batchPoolEnableAutoScaleContent = new BatchPoolEnableAutoScaleOptions()
                {
                    AutoScaleEvaluationInterval = newEvalInterval,
                    AutoScaleFormula = poolASFormulaNew,
                };

                // verify
                response = await client.EnablePoolAutoScaleAsync(autoScalePool.Id, batchPoolEnableAutoScaleContent);
                Assert.That(response.Status, Is.EqualTo(200));
                autoScalePool = await client.GetPoolAsync((autoScalePool.Id));
                Assert.Multiple(() =>
                {
                    Assert.That(newEvalInterval, Is.EqualTo(autoScalePool.AutoScaleEvaluationInterval));
                    Assert.That(poolASFormulaNew, Is.EqualTo(autoScalePool.AutoScaleFormula));
                });

                response = await client.DisablePoolAutoScaleAsync(autoScalePool.Id);
                Assert.That(response.Status, Is.EqualTo(200));
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
                        },
                        ProxyAgentSettings = new ProxyAgentSettings
                        {
                            Imds = new HostEndpointSettings
                            {
                                Mode = HostEndpointSettingsModeTypes.Audit,
                            },
                            Enabled = false,
                            //WireServer = new HostEndpointSettings
                            //{
                            //    InVmAccessControlProfileReferenceId = "id2",
                            //},
                        },
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
                Assert.That(response.Status, Is.EqualTo(201));

                BatchPool pool = await client.GetPoolAsync(poolID);
                Assert.Multiple(() =>
                {
                    Assert.That(SecurityTypes.ConfidentialVM, Is.EqualTo(pool.VirtualMachineConfiguration.SecurityProfile.SecurityType));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.EncryptionAtHost, Is.EqualTo(false));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled, Is.EqualTo(true));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.VTpmEnabled, Is.EqualTo(true));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.ProxyAgentSettings.Enabled, Is.EqualTo(false));
                    Assert.That(HostEndpointSettingsModeTypes.Audit, Is.EqualTo(pool.VirtualMachineConfiguration.SecurityProfile.ProxyAgentSettings.Imds.Mode));
                    Assert.That(CachingType.ReadWrite, Is.EqualTo(pool.VirtualMachineConfiguration.OsDisk.Caching));
                    Assert.That(SecurityEncryptionTypes.VMGuestStateOnly, Is.EqualTo(pool.VirtualMachineConfiguration.OsDisk.ManagedDisk.SecurityProfile.SecurityEncryptionType));
                });
            }
            catch (RequestFailedException e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }

        [RecordedTest]
        public async Task PoolCreatedOsDiskDiskEncryption()
        {
            var DiskEncryptionSetId = TestEnvironment.DiskEncryptionSetId;
            var client = CreateUserSubBatchClient();
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
                        },
                        ProxyAgentSettings = new ProxyAgentSettings
                        {
                            Imds = new HostEndpointSettings
                            {
                                Mode = HostEndpointSettingsModeTypes.Audit,
                            },
                            Enabled = false,
                            //WireServer = new HostEndpointSettings
                            //{
                            //    InVmAccessControlProfileReferenceId = "id2",
                            //},
                        },
                    },
                    OsDisk = new BatchOsDisk()
                    {
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new ManagedDisk()
                        {
                            SecurityProfile = new BatchVmDiskSecurityProfile()
                            {
                                SecurityEncryptionType = SecurityEncryptionTypes.VMGuestStateOnly,
                            },
                            DiskEncryptionSet = new DiskEncryptionSetParameters()
                            {
                                Id = new ResourceIdentifier(DiskEncryptionSetId)
                            }
                        }
                    },
                    DataDisks = {new DataDisk(0, 1024)
                    {
                        ManagedDisk = new ManagedDisk
                        {
                            DiskEncryptionSet = new DiskEncryptionSetParameters
                            {
                                Id = new ResourceIdentifier(DiskEncryptionSetId),
                            },
                            StorageAccountType = StorageAccountType.StandardLRS,
                        },
                    }},
                };

                BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(poolID, VMSize)
                {
                    VirtualMachineConfiguration = virtualMachineConfiguration,
                    TargetDedicatedNodes = targetDedicatedNodes,
                };

                Response response = await client.CreatePoolAsync(batchPoolCreateOptions);
                Assert.That(response.Status, Is.EqualTo(201));

                BatchPool pool = await client.GetPoolAsync(poolID);
                Assert.Multiple(() =>
                {
                    Assert.That(SecurityTypes.ConfidentialVM, Is.EqualTo(pool.VirtualMachineConfiguration.SecurityProfile.SecurityType));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.EncryptionAtHost, Is.EqualTo(false));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.SecureBootEnabled, Is.EqualTo(true));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.UefiSettings.VTpmEnabled, Is.EqualTo(true));
                    Assert.That(pool.VirtualMachineConfiguration.SecurityProfile.ProxyAgentSettings.Enabled, Is.EqualTo(false));
                    Assert.That(HostEndpointSettingsModeTypes.Audit, Is.EqualTo(pool.VirtualMachineConfiguration.SecurityProfile.ProxyAgentSettings.Imds.Mode));
                    Assert.That(CachingType.ReadWrite, Is.EqualTo(pool.VirtualMachineConfiguration.OsDisk.Caching));
                    Assert.That(SecurityEncryptionTypes.VMGuestStateOnly, Is.EqualTo(pool.VirtualMachineConfiguration.OsDisk.ManagedDisk.SecurityProfile.SecurityEncryptionType));
                    Assert.That(DiskEncryptionSetId, Is.EqualTo(pool.VirtualMachineConfiguration.OsDisk.ManagedDisk.DiskEncryptionSet.Id));
                });
            }
            catch (RequestFailedException e)
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
                Assert.That(resizePool.AllocationState, Is.EqualTo(AllocationState.Resizing));

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

                BatchPoolReplaceOptions replaceContent = new BatchPoolReplaceOptions(batchApplicationPackageReferences, metadataIems);
                Response response = await client.ReplacePoolPropertiesAsync(poolID, replaceContent);
                BatchPool replacePool = await client.GetPoolAsync(poolID);
                Assert.That(replacePool.Metadata.First().Value, Is.EqualTo("value"));
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

                updateContent.TaskSchedulingPolicy = new BatchTaskSchedulingPolicy(BatchNodeFillType.Pack)
                {
                    JobDefaultOrder = BatchJobDefaultOrder.CreationTime,
                };

                updateContent.UserAccounts.Add(new UserAccount("test1", nodeUserPassword));
                updateContent.UserAccounts.Add(new UserAccount("test2", nodeUserPassword) { ElevationLevel = ElevationLevel.NonAdmin });
                updateContent.UserAccounts.Add(new UserAccount("test3", nodeUserPassword) { ElevationLevel = ElevationLevel.Admin });
                updateContent.UserAccounts.Add(new UserAccount("test4", nodeUserPassword) { LinuxUserConfiguration = new LinuxUserConfiguration() { SshPrivateKey = "AAAA==" } });

                Response response = await client.UpdatePoolAsync(poolID, updateContent);
                BatchPool patchPool = await client.GetPoolAsync(poolID);
                Assert.Multiple(() =>
                {
                    Assert.That(patchPool.Metadata.First().Value, Is.EqualTo("value"));

                    Assert.That(patchPool.StartTask.CommandLine, Is.EqualTo(startTaskCommandLine));
                    Assert.That(patchPool.Metadata.Single().Name, Is.EqualTo(updateContent.Metadata.Single().Name));
                    Assert.That(patchPool.Metadata.Single().Value, Is.EqualTo(updateContent.Metadata.Single().Value));
                    Assert.That(patchPool.DisplayName, Is.EqualTo(displayName));
                    Assert.That(patchPool.UpgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent, Is.EqualTo(20));
                    Assert.That(patchPool.TaskSchedulingPolicy.NodeFillType, Is.EqualTo(BatchNodeFillType.Pack));
                    Assert.That(patchPool.TaskSchedulingPolicy.JobDefaultOrder, Is.EqualTo(BatchJobDefaultOrder.CreationTime));
                    Assert.That(patchPool.UserAccounts, Has.Count.EqualTo(4));
                    Assert.That(patchPool.VmSize, Is.EqualTo("standard_d2s_v3"));
                    Assert.That(patchPool.TaskSlotsPerNode, Is.EqualTo(1));
                    Assert.That(patchPool.EnableInterNodeCommunication, Is.True);
                    Assert.That(patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().Name, Is.EqualTo("ruleName"));
                    Assert.That(patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().Protocol, Is.EqualTo(InboundEndpointProtocol.Tcp));
                    Assert.That(patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().BackendPort, Is.EqualTo(3389));
                    Assert.That(patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().FrontendPortRangeStart, Is.EqualTo(15000));
                    Assert.That(patchPool.NetworkConfiguration.EndpointConfiguration.InboundNatPools.First().FrontendPortRangeEnd, Is.EqualTo(15100));
                });
            }
            finally
            {
                await client.DeletePoolAsync(poolID);
            }
        }
    }
}
