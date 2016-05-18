﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Test;
using SiteRecovery.Extensions;
using Xunit;
using System.Linq;


namespace SiteRecovery.Tests
{
    public class EndToEndTests : SiteRecoveryTestsBase
    {
        #region OLD TESTS
        //[Fact]
        //public void EndToEndE2ESingleVM()
        //{
        //    using (UndoContext context = UndoContext.Current)
        //    {
        //        context.Start();
        //        var client = GetSiteRecoveryClient(CustomHttpHandler);

        //        bool pairClouds = true;
        //        bool StorageClassificationMapping = true;
        //        bool enableDR = true;
        //        bool pfo = true;
        //        bool commit = true;
        //        bool tfo = true;
        //        bool pfoReverse = true;
        //        bool commitReverse = true;
        //        bool rr = true;
        //        bool rrReverse = true;
        //        bool disableDR = true;
        //        bool unpair = true;
        //        bool StorageClassificationUnmap = true;
        //        bool removePolicy = true;

        //        var fabrics = client.Fabrics.List(RequestHeaders);

        //        Fabric selectedFabric = null;

        //        foreach (var fabric in fabrics.Fabrics)
        //        {
        //            if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
        //            {
        //                selectedFabric = fabric;
        //            }
        //        }

        //        string priCld = string.Empty;
        //        string recCldGuid = string.Empty;
        //        string recCld = string.Empty;
        //        string policyName = "Hydra-EndToEndE2ESingleVM-" + (new Random()).Next();
        //        string mappingName = "Mapping-EndToEndE2ESingleVM-" + (new Random()).Next();
        //        string StorageClassificationMappingName = "StrgMapping-EndToEndE2ESingleVM-453834979";// "StrgMapping-EndToEndE2ESingleVM-" + (new Random()).Next();
        //        string replicationProtectedItemName = "PE" + (new Random()).Next();
        //        string enableDRVmName = string.Empty;
        //        Policy currentPolicy = null;

        //        var policies = client.Policies.List(RequestHeaders);

        //        if (string.IsNullOrEmpty(recCldGuid))
        //        {
        //            var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);
                    
        //            foreach (var container in containers.ProtectionContainers)
        //            {
        //                if (container.Properties.PairingStatus.Equals("NotPaired", StringComparison.InvariantCultureIgnoreCase))
        //                {
        //                    if (string.IsNullOrEmpty(priCld))
        //                    {
        //                        priCld = container.Name;
        //                    }
        //                    else if (string.IsNullOrEmpty(recCld) && priCld != container.Name)
        //                    {
        //                        recCld = container.Id;
        //                        recCldGuid = container.Name;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            recCld = client.ProtectionContainer.Get(selectedFabric.Name, recCldGuid, RequestHeaders).ProtectionContainer.Id;
        //        }

        //        StorageClassification selectedStorageClassification = null;
        //        if (StorageClassificationMapping)
        //        {
        //            IList<StorageClassification> StorageClassifications = client.StorageClassification.List(selectedFabric.Name, RequestHeaders).StorageClassifications;

        //            if (StorageClassifications.Count > 1)
        //            {
        //                StorageClassificationMappingInputProperties strgInputProps = new StorageClassificationMappingInputProperties()
        //                {
        //                    TargetStorageClassificationId = StorageClassifications[1].Id
        //                };

        //                StorageClassificationMappingInput strgInput = new StorageClassificationMappingInput()
        //                {
        //                    Properties = strgInputProps
        //                };

        //                var mapStorageClassifications = client.StorageClassificationMapping.PairStorageClassification(selectedFabric.Name, StorageClassifications[0].Name, StorageClassificationMappingName, strgInput, RequestHeaders);

        //                selectedStorageClassification = StorageClassifications[0];
        //            }
        //        }

        //        if (pairClouds)
        //        {
        //            HyperVReplica2012R2PolicyInput hvrProfileInput = new HyperVReplica2012R2PolicyInput()
        //            {
        //                ApplicationConsistentSnapshotFrequencyInHours = 0,
        //                AllowedAuthenticationType = 1,
        //                Compression = "Enable",
        //                InitialReplicationMethod = "OverNetwork",
        //                OnlineReplicationStartTime = null,
        //                RecoveryPoints = 0,
        //                ReplicaDeletion = "Required",
        //                ReplicationPort = 8083,
        //                ReplicationFrequencyInSeconds = 300
        //            };

        //            CreatePolicyInputProperties policyCreationProp = new CreatePolicyInputProperties()
        //            {
        //                ProviderSpecificInput = hvrProfileInput
        //            };

        //            CreatePolicyInput policyCreationInput = new CreatePolicyInput()
        //            {
        //                Properties = policyCreationProp
        //            };

        //            var policyCreateResp = client.Policies.Create(policyName, policyCreationInput, RequestHeaders);

        //            currentPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
        //            CreateProtectionContainerMappingInputProperties pairingProps = new CreateProtectionContainerMappingInputProperties()
        //            {
        //                PolicyId = currentPolicy.Id,
        //                TargetProtectionContainerId = recCld,
        //                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
        //            };

        //            CreateProtectionContainerMappingInput pairingInput = new CreateProtectionContainerMappingInput()
        //            {
        //                Properties = pairingProps
        //            };

        //            var pairingResponse = client.ProtectionContainerMapping.ConfigureProtection(
        //                selectedFabric.Name, 
        //                priCld, 
        //                mappingName, 
        //                pairingInput, 
        //                RequestHeaders);

        //            // Adding SP1 Profile too

        //            HyperVReplica2012PolicyInput hvrsp1ProfileInput = new HyperVReplica2012PolicyInput()
        //            {
        //                ApplicationConsistentSnapshotFrequencyInHours = 0,
        //                AllowedAuthenticationType = 1,
        //                Compression = "Enable",
        //                InitialReplicationMethod = "OverNetwork",
        //                OnlineReplicationStartTime = null,
        //                RecoveryPoints = 0,
        //                ReplicaDeletion = "Required",
        //                ReplicationPort = 8083
        //            };

        //            CreatePolicyInputProperties policySp1CreationProp = new CreatePolicyInputProperties()
        //            {
        //                ProviderSpecificInput = hvrsp1ProfileInput
        //            };

        //            CreatePolicyInput policySp1CreationInput = new CreatePolicyInput()
        //            {
        //                Properties = policySp1CreationProp
        //            };

        //            var policySp1CreateResp = client.Policies.Create(policyName + "SP1", policySp1CreationInput, RequestHeaders);

        //            var currentSp1Policy = client.Policies.Get(policyName + "SP1", RequestHeaders).Policy;
        //            CreateProtectionContainerMappingInputProperties pairingSp1Props = new CreateProtectionContainerMappingInputProperties()
        //            {
        //                PolicyId = currentSp1Policy.Id,
        //                TargetProtectionContainerId = recCld,
        //                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
        //            };

        //            CreateProtectionContainerMappingInput pairingSp1Input = new CreateProtectionContainerMappingInput()
        //            {
        //                Properties = pairingSp1Props
        //            };

        //            var pairingSp1Response = client.ProtectionContainerMapping.ConfigureProtection(
        //                selectedFabric.Name,
        //                priCld,
        //                mappingName + "sp1",
        //                pairingSp1Input,
        //                RequestHeaders);
                    
        //        }
        //        else
        //        {
        //            currentPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
        //        }

        //        if (enableDR)
        //        {
        //            EnableProtectionInputProperties enableDRProp = new EnableProtectionInputProperties();
        //            if (string.IsNullOrEmpty(enableDRVmName))
        //            {
        //                var protectableItem = GetUnprotectedItem(client, selectedFabric.Name, priCld);

        //                enableDRProp = new EnableProtectionInputProperties()
        //                {
        //                    PolicyId = currentPolicy.Id,
        //                    ProtectableItemId = protectableItem.Id,
        //                    ProviderSpecificDetails = new EnableProtectionProviderSpecificInput()
        //                };
        //            }
        //            else
        //            {
        //                var item = client.ProtectableItem.Get(selectedFabric.Name, priCld, enableDRVmName, RequestHeaders);

        //                enableDRProp = new EnableProtectionInputProperties()
        //                {
        //                    PolicyId = currentPolicy.Id,
        //                    ProtectableItemId = item.ProtectableItem.Id,
        //                    ProviderSpecificDetails = new EnableProtectionProviderSpecificInput()
        //                };
        //            }

        //            EnableProtectionInput enableInput = new EnableProtectionInput()
        //            {
        //                Properties = enableDRProp
        //            };

        //            var enableDRStartTime = DateTime.Now;

        //            var enableDRresp = client.ReplicationProtectedItem.EnableProtection(
        //                selectedFabric.Name, 
        //                priCld, 
        //                replicationProtectedItemName, 
        //                enableInput, 
        //                RequestHeaders);

        //            MonitoringHelper.MonitorJobs(MonitoringHelper.SecondaryIrJobName, enableDRStartTime, client, RequestHeaders);
        //        }

        //        ///////////////////////////// PFO ////////////////////////////////
        //        PlannedFailoverInputProperties plannedFailoverProp = new PlannedFailoverInputProperties()
        //        {
        //            ProviderSpecificDetails = new ProviderSpecificFailoverInput()
        //        };

        //        PlannedFailoverInput plannedFailoverInput = new PlannedFailoverInput()
        //        {
        //            Properties = plannedFailoverProp
        //        };
        //        ////////////////////////////// RR ////////////////////////////////
        //        ReverseReplicationInputProperties rrProp = new ReverseReplicationInputProperties()
        //        {
        //            ProviderSpecificDetails = new ReverseReplicationProviderSpecificInput()
        //        };

        //        ReverseReplicationInput rrInput = new ReverseReplicationInput()
        //        {
        //            Properties = rrProp
        //        };
        //        ////////////////////////////////// UFO /////////////////////////////
        //        UnplannedFailoverInputProperties ufoProp = new UnplannedFailoverInputProperties()
        //        {
        //            ProviderSpecificDetails = new ProviderSpecificFailoverInput(),
        //            SourceSiteOperations = "NotRequired"
        //        };

        //        UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
        //        {
        //            Properties = ufoProp
        //        };
        //        /////////////////////////////////// TFO //////////////////////////////
        //        TestFailoverInputProperties tfoProp = new TestFailoverInputProperties()
        //        {
        //            ProviderSpecificDetails = new ProviderSpecificFailoverInput()
        //        };

        //        TestFailoverInput tfoInput = new TestFailoverInput()
        //        {
        //            Properties = tfoProp
        //        };
        //        /////////////////////////////////////
        //        if (pfo)
        //        {
        //            var protectedItem = client.ReplicationProtectedItem.Get(
        //                selectedFabric.Name,
        //                priCld,
        //                replicationProtectedItemName,
        //                RequestHeaders);

        //            var plannedfailover = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, priCld, replicationProtectedItemName, plannedFailoverInput, RequestHeaders);

        //            //var unplannedFailoverReverse = client.ReplicationProtectedItem.UnplannedFailover(
        //            //    selectedFabric.Name, 
        //            //    priCld, 
        //            //    replicationProtectedItemName, 
        //            //    ufoInput, 
        //            //    RequestHeaders);
        //        }

        //        if (commit)
        //        {
        //            var commitFailover = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, priCld, replicationProtectedItemName, RequestHeaders);
        //        }

        //        if (rr)
        //        {
        //            var rrOp = client.ReplicationProtectedItem.Reprotect(selectedFabric.Name, priCld, replicationProtectedItemName, rrInput, RequestHeaders);
        //        }

        //        if (pfoReverse)
        //        {
        //            //var unplannedFailoverReverse = client.ReplicationProtectedItem.UnplannedFailover(
        //            //    selectedFabric.Name, priCld, replicationProtectedItemName, ufoInput, RequestHeaders);

        //            var plannedFailoverReverse = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, priCld, replicationProtectedItemName, plannedFailoverInput, RequestHeaders);
        //        }

        //        if (commitReverse)
        //        {
        //            var commitFailoverReverse = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, priCld, replicationProtectedItemName, RequestHeaders);
        //        }

        //        if (rrReverse)
        //        {
        //            DateTime rrPostUfoStartTime = DateTime.UtcNow;
        //            var rrReverseOp = client.ReplicationProtectedItem.Reprotect(selectedFabric.Name, priCld, replicationProtectedItemName, rrInput, RequestHeaders);

        //            /*while (true)
        //            {
        //                Thread.Sleep(5000 * 60);
        //                Job ufoJob = MonitoringHelper.GetJobId(
        //                    MonitoringHelper.ReverseReplicationJobName, 
        //                    rrPostUfoStartTime, 
        //                    client, 
        //                    RequestHeaders);

        //                if (ufoJob.Properties.StateDescription.Equals(
        //                    "WaitingForFinalizeProtection", 
        //                    StringComparison.InvariantCultureIgnoreCase))
        //                {
        //                    break;
        //                }
        //            }

        //            MonitoringHelper.MonitorJobs(MonitoringHelper.PrimaryIrJobName, rrPostUfoStartTime, client, RequestHeaders);
        //            MonitoringHelper.MonitorJobs(MonitoringHelper.SecondaryIrJobName, rrPostUfoStartTime, client, RequestHeaders);*/
        //        }

        //        if (tfo)
        //        {
        //            DateTime startTFO = DateTime.UtcNow;

        //            var tfoOp = client.ReplicationProtectedItem.TestFailover(selectedFabric.Name, priCld, replicationProtectedItemName, tfoInput, RequestHeaders);

        //            var jobs = MonitoringHelper.GetJobId(MonitoringHelper.TestFailoverJobName, startTFO, client, RequestHeaders);

        //            ResumeJobParamsProperties resProp = new ResumeJobParamsProperties()
        //            {
        //                Comments = "Res TFO"
        //            };

        //            ResumeJobParams resParam = new ResumeJobParams()
        //            {
        //                Properties = resProp
        //            };

        //            var resJob = client.Jobs.Resume(jobs.Name, resParam, RequestHeaders);
        //        }

        //        if (disableDR)
        //        {
        //            var disableDROperation = client.ReplicationProtectedItem.DisableProtection(selectedFabric.Name, priCld, replicationProtectedItemName, new DisableProtectionInput(), RequestHeaders);
        //        }

        //        if (unpair)
        //        {
        //            var unpaiClouds = client.ProtectionContainerMapping.UnconfigureProtection(
        //                selectedFabric.Name, 
        //                priCld,
        //                mappingName, 
        //                new RemoveProtectionContainerMappingInput(), 
        //                RequestHeaders);
        //        }

        //        if (StorageClassificationUnmap)
        //        {
        //            var unmapStorageClassifications = client.StorageClassificationMapping.UnpairStorageClassification(selectedFabric.Name, selectedStorageClassification.Name, StorageClassificationMappingName, RequestHeaders);
        //        }

        //        if (removePolicy)
        //        {
        //            var policyDeletion = client.Policies.Delete(currentPolicy.Name, RequestHeaders);
        //        }
        //    }
        //}

        //[Fact]
        //public void EndToEndE2ASingleVM()
        //{
        //    using (UndoContext context = UndoContext.Current)
        //    {
        //        context.Start();
        //        var client = GetSiteRecoveryClient(CustomHttpHandler);

        //        bool createPolicy = true;
        //        bool pairClouds = true;
        //        bool enableDR = true;
        //        bool pfo = true;
        //        bool commit = true;
        //        bool tfo = true;
        //        bool pfoReverse = true;
        //        bool commitReverse = true;
        //        bool reprotect = true;
        //        bool disableDR = true;
        //        bool unpair = true;
        //        bool removePolicy = true;

        //        // Process Variables
        //        string fabricName = string.Empty;
        //        string recCldName = "Microsoft Azure";
        //        string priCldName = string.Empty;
        //        string policyName = "Hydra-EndToEndE2ASingleVM-" + (new Random()).Next();
        //        string mappingName = "Mapping-EndToEndE2ASingleVM-" + (new Random()).Next();
        //        string enableDRName = string.Empty;
        //        string protectedItemName = "PE" + (new Random()).Next();

        //        // Data Variables
        //        Fabric selectedFabric = null;
        //        ProtectionContainer primaryCloud = null;
        //        Policy selectedPolicy = null;
        //        ProtectableItem protectableItem = null;
        //        ReplicationProtectedItem protectedItem = null;

        //        // Fetch VMMs
        //        if (string.IsNullOrEmpty(fabricName))
        //        {
        //            var fabrics = client.Fabrics.List(RequestHeaders);

        //            foreach (var fabric in fabrics.Fabrics)
        //            {
        //                if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
        //                {
        //                    selectedFabric = fabric;
        //                    fabricName = selectedFabric.Name;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            selectedFabric = client.Fabrics.Get(fabricName, RequestHeaders).Fabric;
        //        }

        //        // Fetch Cloud
        //        if (string.IsNullOrEmpty(priCldName))
        //        {
        //            var clouds = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

        //            foreach (var cloud in clouds.ProtectionContainers)
        //            {
        //                if (cloud.Properties.PairingStatus.Equals("NotPaired", StringComparison.InvariantCultureIgnoreCase))
        //                {
        //                    priCldName = cloud.Name;
        //                    primaryCloud = cloud;
        //                    break;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            primaryCloud = client.ProtectionContainer.Get(selectedFabric.Name, priCldName, RequestHeaders).ProtectionContainer;
        //        }

        //        if (createPolicy)
        //        {
        //            HyperVReplicaAzurePolicyInput hvrAPolicy = new HyperVReplicaAzurePolicyInput()
        //            {
        //                ApplicationConsistentSnapshotFrequencyInHours = 0,
        //                Encryption = "Disable",
        //                OnlineIrStartTime =  null,
        //                RecoveryPointHistoryDuration = 0,
        //                ReplicationInterval = 30,
        //                StorageAccounts = new List<string>() { "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc" }
        //            };

        //            CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
        //            {
        //                ProviderSpecificInput = hvrAPolicy
        //            };

        //            CreatePolicyInput policyInput = new CreatePolicyInput()
        //            {
        //                Properties = createInputProp
        //            };

        //            selectedPolicy = (client.Policies.Create(policyName, policyInput, RequestHeaders) as CreatePolicyOperationResponse).Policy;
        //        }
        //        else
        //        {
        //            selectedPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
        //        }

        //        if (pairClouds)
        //        {
        //            CreateProtectionContainerMappingInputProperties pairingProps = new CreateProtectionContainerMappingInputProperties()
        //            {
        //                PolicyId = selectedPolicy.Id,
        //                TargetProtectionContainerId = recCldName,
        //                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
        //            };

        //            CreateProtectionContainerMappingInput pairingInput = new CreateProtectionContainerMappingInput()
        //            {
        //                Properties = pairingProps
        //            };

        //            var pairingResponse = client.ProtectionContainerMapping.ConfigureProtection(
        //                selectedFabric.Name, 
        //                primaryCloud.Name, 
        //                mappingName, 
        //                pairingInput, 
        //                RequestHeaders);
                    
        //        }

        //        if (enableDR)
        //        {
        //            if (string.IsNullOrEmpty(enableDRName))
        //            {

        //                protectableItem = GetUnprotectedItem(client, selectedFabric.Name, primaryCloud.Name);
        //                enableDRName = protectableItem.Name;
        //            }
        //            else
        //            {
        //                protectableItem = client.ProtectableItem.Get(selectedFabric.Name, primaryCloud.Name, enableDRName, RequestHeaders).ProtectableItem;
        //            }

        //            HyperVReplicaAzureEnableProtectionInput hvrAEnableDRInput = new HyperVReplicaAzureEnableProtectionInput()
        //            {
        //                HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
        //                OSType = "Windows",
        //                VhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetailsList[0].VhdId,
        //                VmName = protectableItem.Properties.FriendlyName,
        //                TargetStorageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorageClassification/StorageClassificationAccounts/bvtmapped2storacc",
        //            };

        //            EnableProtectionInputProperties enableDRProp = new EnableProtectionInputProperties()
        //            {
        //                PolicyId  = selectedPolicy.Id,
        //                ProtectableItemId = protectableItem.Id,
        //                ProviderSpecificDetails = hvrAEnableDRInput
        //            };

        //            EnableProtectionInput enableDRInput = new EnableProtectionInput()
        //            {
        //                Properties = enableDRProp
        //            };

        //            protectedItem = (
        //                client.ReplicationProtectedItem.EnableProtection(
        //                    selectedFabric.Name, 
        //                    primaryCloud.Name, 
        //                    protectedItemName,
        //                    enableDRInput, 
        //                    RequestHeaders) as ReplicationProtectedItemOperationResponse).ReplicationProtectedItem;
        //        }

        //        if (pfo || commit || tfo || pfoReverse || commitReverse || reprotect || disableDR)
        //        {
        //            protectableItem = client.ProtectableItem.Get(selectedFabric.Name, primaryCloud.Name, enableDRName, RequestHeaders).ProtectableItem;
        //            protectedItem = client.ReplicationProtectedItem.Get(selectedFabric.Name, primaryCloud.Name, protectedItemName, RequestHeaders).ReplicationProtectedItem;

        //            // Create Input for Operations
        //            ///////////////////////////// PFO /////////////////////////////////////
        //            HyperVReplicaAzureFailoverProviderInput hvrAFOInput = new HyperVReplicaAzureFailoverProviderInput()
        //            {
        //                VaultLocation = "West US",
        //            };
        //            PlannedFailoverInputProperties plannedFailoverProp = new PlannedFailoverInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrAFOInput
        //            };

        //            PlannedFailoverInput plannedFailoverInput = new PlannedFailoverInput()
        //            {
        //                Properties = plannedFailoverProp
        //            };

        //            HyperVReplicaAzureFailbackProviderInput hvrAFBInput = new HyperVReplicaAzureFailbackProviderInput()
        //            {
        //                RecoveryVmCreationOption = "NoAction",
        //                DataSyncOption = "ForSyncronization"
        //            };
        //            PlannedFailoverInputProperties plannedFailbackProp = new PlannedFailoverInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrAFBInput
        //            };

        //            PlannedFailoverInput plannedFailbackInput = new PlannedFailoverInput()
        //            {
        //                Properties = plannedFailbackProp
        //            };
        //            ////////////////////////////// Reprotect //////////////////////////////////////
        //            HyperVReplicaAzureReprotectInput hvrARRInput = new HyperVReplicaAzureReprotectInput()
        //            {
        //                HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
        //                OSType = "Windows",
        //                VHDId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetailsList[0].VhdId,
        //                VmName = protectableItem.Properties.FriendlyName,
        //                StorageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc",
        //            };

        //            ReverseReplicationInputProperties rrProp = new ReverseReplicationInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrARRInput
        //            };

        //            ReverseReplicationInput rrInput = new ReverseReplicationInput()
        //            {
        //                Properties = rrProp
        //            };

        //            ////////////////////////////////// UFO /////////////////////////////////////////
        //            UnplannedFailoverInputProperties ufoProp = new UnplannedFailoverInputProperties()
        //            {
        //                ProviderSpecificDetails = hvrAFOInput,
        //                SourceSiteOperations = "NotRequired"
        //            };

        //            UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
        //            {
        //                Properties = ufoProp
        //            };

        //            /////////////////////////////////// TFO /////////////////////////////////////////////
        //            TestFailoverInputProperties tfoProp = new TestFailoverInputProperties()
        //            {
        //                ProviderSpecificDetails = hvrAFOInput
        //            };

        //            TestFailoverInput tfoInput = new TestFailoverInput()
        //            {
        //                Properties = tfoProp
        //            };
        //            //////////////////////////////////////////////////////////////////////////////////////////

        //            if (pfo)
        //            {
        //                var plannedfailover = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, plannedFailoverInput, RequestHeaders);
        //            }

        //            if (commit)
        //            {
        //                var commitFailover = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, RequestHeaders);
        //            }

        //            if (pfoReverse)
        //            {
        //                //var unplannedFailoverReverse = client.ReplicationProtectedItem.UnplannedFailover(selectedFabric.Name, priCld, replicationProtectedItems.ReplicationProtectedItems[0].Name, ufoInput, RequestHeaders);

        //                var plannedFailoverReverse = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, plannedFailbackInput, RequestHeaders);
        //            }

        //            if (commitReverse)
        //            {
        //                var commitFailoverReverse = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, RequestHeaders);
        //            }

        //            if (reprotect)
        //            {
        //                var reprotectStartTime = DateTime.UtcNow;
        //                var rrReverseOp = client.ReplicationProtectedItem.Reprotect(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, rrInput, RequestHeaders);

        //                MonitoringHelper.MonitorJobs(MonitoringHelper.AzureIrJobName, reprotectStartTime, client, RequestHeaders);
        //            }

        //            if (tfo)
        //            {
        //                DateTime startTFO = DateTime.UtcNow;

        //                var tfoOp = client.ReplicationProtectedItem.TestFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, tfoInput, RequestHeaders);

        //                var jobs = MonitoringHelper.GetJobId(MonitoringHelper.TestFailoverJobName, startTFO, client, RequestHeaders);

        //                ResumeJobParamsProperties resProp = new ResumeJobParamsProperties()
        //                {
        //                    Comments = "Res TFO"
        //                };

        //                ResumeJobParams resParam = new ResumeJobParams()
        //                {
        //                    Properties = resProp
        //                };

        //                var resJob = client.Jobs.Resume(jobs.Name, resParam, RequestHeaders);
        //            }

        //            if (disableDR)
        //            {
        //                var disableDROperation = client.ReplicationProtectedItem.DisableProtection(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, new DisableProtectionInput(), RequestHeaders);
        //            }

        //            if (unpair)
        //            {
        //                if (unpair)
        //                {
        //                    var unpairClouds = client.ProtectionContainerMapping.UnconfigureProtection(
        //                        selectedFabric.Name,
        //                        primaryCloud.Name,
        //                        mappingName,
        //                        new RemoveProtectionContainerMappingInput(),
        //                        RequestHeaders);
        //                }
        //            }
        //        }

        //        if (removePolicy)
        //        {
        //            var policyDeletion = client.Policies.Delete(selectedPolicy.Name, RequestHeaders);
        //        }
        //    }
        //}

        //[Fact]
        //public void EndToEndB2ASingleVM()
        //{
        //    using (UndoContext context = UndoContext.Current)
        //    {
        //        context.Start();
        //        var client = GetSiteRecoveryClient(CustomHttpHandler);

        //        bool createPolicy = true;
        //        bool pairClouds = true;
        //        bool enableDR = true;
        //        bool pfo = true;
        //        bool commit = true;
        //        bool tfo = true;
        //        bool pfoReverse = true;
        //        bool commitReverse = true;
        //        bool reprotect = true;
        //        bool disableDR = true;
        //        bool unpair = true;
        //        bool removePolicy = true;

        //        // Process Variables
        //        string fabricName = string.Empty;
        //        string recCldName = "Microsoft Azure";
        //        string priCldName = string.Empty;
        //        string policyName = "Hydra-EndToEndB2ASingleVM-" + (new Random()).Next();
        //        string mappingName = "Mapping-EndToEndB2ASingleVM-" + (new Random()).Next();
        //        string enableDRName = string.Empty;
        //        string protectedItemName = "PE" + (new Random()).Next();

        //        // Data Variables
        //        Fabric selectedFabric = null;
        //        ProtectionContainer primaryCloud = null;
        //        Policy selectedPolicy = null;
        //        ProtectableItem protectableItem = null;
        //        ReplicationProtectedItem protectedItem = null;

        //        // Fetch HyperV
        //        if (string.IsNullOrEmpty(fabricName))
        //        {
        //            var fabrics = client.Fabrics.List(RequestHeaders);

        //            foreach (var fabric in fabrics.Fabrics)
        //            {
        //                if (fabric.Properties.CustomDetails.InstanceType.Contains("HyperV"))
        //                {
        //                    selectedFabric = fabric;
        //                    fabricName = selectedFabric.Name;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            selectedFabric = client.Fabrics.Get(fabricName, RequestHeaders).Fabric;
        //        }

        //        // Fetch Cloud
        //        primaryCloud = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders).ProtectionContainers[0];
        //        priCldName = primaryCloud.Name;

        //        if (createPolicy)
        //        {
        //            HyperVReplicaAzurePolicyInput hvrAPolicy = new HyperVReplicaAzurePolicyInput()
        //            {
        //                ApplicationConsistentSnapshotFrequencyInHours = 0,
        //                Encryption = "Disable",
        //                OnlineIrStartTime = null,
        //                RecoveryPointHistoryDuration = 0,
        //                ReplicationInterval = 30,
        //                StorageAccounts = new List<string>() { "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc" }
        //            };

        //            CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
        //            {
        //                ProviderSpecificInput = hvrAPolicy
        //            };

        //            CreatePolicyInput policyInput = new CreatePolicyInput()
        //            {
        //                Properties = createInputProp
        //            };

        //            selectedPolicy = (client.Policies.Create(policyName, policyInput, RequestHeaders) as CreatePolicyOperationResponse).Policy;
        //        }
        //        else
        //        {
        //            selectedPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
        //        }

        //        if (pairClouds)
        //        {
        //            CreateProtectionContainerMappingInputProperties pairingProps = new CreateProtectionContainerMappingInputProperties()
        //            {
        //                PolicyId = selectedPolicy.Id,
        //                TargetProtectionContainerId = recCldName,
        //                ProviderSpecificInput = new ReplicationProviderContainerMappingInput()
        //            };

        //            CreateProtectionContainerMappingInput pairingInput = new CreateProtectionContainerMappingInput()
        //            {
        //                Properties = pairingProps
        //            };

        //            var pairingResponse = client.ProtectionContainerMapping.ConfigureProtection(
        //                selectedFabric.Name, 
        //                primaryCloud.Name, 
        //                mappingName, 
        //                pairingInput, 
        //                RequestHeaders);
        //        }

        //        if (enableDR)
        //        {
        //            if (string.IsNullOrEmpty(enableDRName))
        //            {
        //                protectableItem = GetUnprotectedItem(client, selectedFabric.Name, primaryCloud.Name);
        //                enableDRName = protectableItem.Name;
        //            }
        //            else
        //            {
        //                protectableItem = client.ProtectableItem.Get(selectedFabric.Name, primaryCloud.Name, enableDRName, RequestHeaders).ProtectableItem;
        //            }

        //            HyperVReplicaAzureEnableProtectionInput hvrAEnableDRInput = new HyperVReplicaAzureEnableProtectionInput()
        //            {
        //                HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
        //                OSType = "Windows",
        //                VhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetailsList[0].VhdId,
        //                VmName = protectableItem.Properties.FriendlyName,
        //                TargetStorageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc",
        //            };

        //            EnableProtectionInputProperties enableDRProp = new EnableProtectionInputProperties()
        //            {
        //                PolicyId = selectedPolicy.Id,
        //                ProtectableItemId = protectableItem.Id,
        //                ProviderSpecificDetails = hvrAEnableDRInput
        //            };

        //            EnableProtectionInput enableDRInput = new EnableProtectionInput()
        //            {
        //                Properties = enableDRProp
        //            };

        //            DateTime enablStartTime = DateTime.UtcNow;
        //            protectedItem = (
        //                client.ReplicationProtectedItem.EnableProtection(
        //                    selectedFabric.Name,
        //                    primaryCloud.Name,
        //                    protectedItemName,
        //                    enableDRInput,
        //                    RequestHeaders) as ReplicationProtectedItemOperationResponse).ReplicationProtectedItem;

        //            MonitoringHelper.MonitorJobs(MonitoringHelper.AzureIrJobName, enablStartTime, client, RequestHeaders);
        //        }

        //        if (pfo || commit || tfo || pfoReverse || commitReverse || reprotect || disableDR)
        //        {
        //            protectableItem = client.ProtectableItem.Get(selectedFabric.Name, primaryCloud.Name, enableDRName, RequestHeaders).ProtectableItem;
        //            protectedItem = client.ReplicationProtectedItem.Get(selectedFabric.Name, primaryCloud.Name, protectedItemName, RequestHeaders).ReplicationProtectedItem;

        //            // Create Input for Operations
        //            ///////////////////////////// PFO /////////////////////////////////////
        //            HyperVReplicaAzureFailoverProviderInput hvrAFOInput = new HyperVReplicaAzureFailoverProviderInput()
        //            {
        //                VaultLocation = "West US",
        //            };
        //            PlannedFailoverInputProperties plannedFailoverProp = new PlannedFailoverInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrAFOInput
        //            };

        //            PlannedFailoverInput plannedFailoverInput = new PlannedFailoverInput()
        //            {
        //                Properties = plannedFailoverProp
        //            };

        //            HyperVReplicaAzureFailbackProviderInput hvrAFBInput = new HyperVReplicaAzureFailbackProviderInput()
        //            {
        //                RecoveryVmCreationOption = "NoAction",
        //                DataSyncOption = "ForSyncronization"
        //            };
        //            PlannedFailoverInputProperties plannedFailbackProp = new PlannedFailoverInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrAFBInput
        //            };

        //            PlannedFailoverInput plannedFailbackInput = new PlannedFailoverInput()
        //            {
        //                Properties = plannedFailbackProp
        //            };
        //            ////////////////////////////// Reprotect //////////////////////////////////////
        //            HyperVReplicaAzureReprotectInput hvrARRInput = new HyperVReplicaAzureReprotectInput()
        //            {
        //                HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
        //                OSType = "Windows",
        //                VHDId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetailsList[0].VhdId,
        //                VmName = protectableItem.Properties.FriendlyName,
        //                StorageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc",
        //            };

        //            ReverseReplicationInputProperties rrProp = new ReverseReplicationInputProperties()
        //            {
        //                FailoverDirection = "",
        //                ProviderSpecificDetails = hvrARRInput
        //            };

        //            ReverseReplicationInput rrInput = new ReverseReplicationInput()
        //            {
        //                Properties = rrProp
        //            };

        //            ////////////////////////////////// UFO /////////////////////////////////////////
        //            UnplannedFailoverInputProperties ufoProp = new UnplannedFailoverInputProperties()
        //            {
        //                ProviderSpecificDetails = hvrAFOInput,
        //                SourceSiteOperations = "NotRequired"
        //            };

        //            UnplannedFailoverInput ufoInput = new UnplannedFailoverInput()
        //            {
        //                Properties = ufoProp
        //            };

        //            /////////////////////////////////// TFO /////////////////////////////////////////////
        //            TestFailoverInputProperties tfoProp = new TestFailoverInputProperties()
        //            {
        //                ProviderSpecificDetails = hvrAFOInput
        //            };

        //            TestFailoverInput tfoInput = new TestFailoverInput()
        //            {
        //                Properties = tfoProp
        //            };
        //            //////////////////////////////////////////////////////////////////////////////////////////

        //            if (pfo)
        //            {
        //                var plannedfailover = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, plannedFailoverInput, RequestHeaders);
        //            }

        //            if (commit)
        //            {
        //                var commitFailover = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, RequestHeaders);
        //            }

        //            if (pfoReverse)
        //            {
        //                //var unplannedFailoverReverse = client.ReplicationProtectedItem.UnplannedFailover(selectedFabric.Name, priCld, replicationProtectedItems.ReplicationProtectedItems[0].Name, ufoInput, RequestHeaders);

        //                var plannedFailoverReverse = client.ReplicationProtectedItem.PlannedFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, plannedFailbackInput, RequestHeaders);
        //            }

        //            if (commitReverse)
        //            {
        //                var commitFailoverReverse = client.ReplicationProtectedItem.CommitFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, RequestHeaders);
        //            }

        //            if (reprotect)
        //            {
        //                var reprotectStartTime = DateTime.UtcNow;
        //                var rrReverseOp = client.ReplicationProtectedItem.Reprotect(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, rrInput, RequestHeaders);

        //                MonitoringHelper.MonitorJobs(MonitoringHelper.AzureIrJobName,reprotectStartTime, client, RequestHeaders);
        //            }

        //            if (tfo)
        //            {
        //                DateTime startTFO = DateTime.UtcNow;

        //                var tfoOp = client.ReplicationProtectedItem.TestFailover(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, tfoInput, RequestHeaders);

        //                var jobs = MonitoringHelper.GetJobId(MonitoringHelper.TestFailoverJobName, startTFO, client, RequestHeaders);

        //                ResumeJobParamsProperties resProp = new ResumeJobParamsProperties()
        //                {
        //                    Comments = "Res TFO"
        //                };

        //                ResumeJobParams resParam = new ResumeJobParams()
        //                {
        //                    Properties = resProp
        //                };

        //                var resJob = client.Jobs.Resume(jobs.Name, resParam, RequestHeaders);
        //            }

        //            if (disableDR)
        //            {
        //                var disableDROperation = client.ReplicationProtectedItem.DisableProtection(selectedFabric.Name, primaryCloud.Name, protectedItem.Name, new DisableProtectionInput(), RequestHeaders);
        //            }

        //            if (unpair)
        //            {
        //                var unpairClouds = client.ProtectionContainerMapping.UnconfigureProtection(
        //                    selectedFabric.Name, 
        //                    primaryCloud.Name, 
        //                    mappingName, 
        //                    new RemoveProtectionContainerMappingInput(), 
        //                    RequestHeaders);
        //            }
        //        }

        //        if (removePolicy)
        //        {
        //            var policyDeletion = client.Policies.Delete(selectedPolicy.Name, RequestHeaders);
        //        }
        //    }
        //}

#endregion

        /// <summary>
        /// Returns an unprotected item.
        /// </summary>
        /// <param name="client">Site Recovery management client.</param>
        /// <param name="fabricId">Fabric Id.</param>
        /// <param name="containerId">Container Id.</param>
        /// <returns>Unprotected VM.</returns>
        private ProtectableItem GetUnprotectedItem(SiteRecoveryManagementClient client, string fabricId, string containerId)
        {
            List<ProtectableItem> protectableItemList = new List<ProtectableItem>();
            ProtectableItemListResponse protectableItemListResponse = client.ProtectableItem.List(fabricId, containerId, "Unprotected", null, "1000", RequestHeaders);
            protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            while (protectableItemListResponse.NextLink != null)
            {
                protectableItemListResponse = client.ProtectableItem.ListNext(protectableItemListResponse.NextLink, RequestHeaders);
                protectableItemList.AddRange(protectableItemListResponse.ProtectableItems);
            }

            return protectableItemList[0];
        }

        public void EndToEndSingleVME2E()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                bool createPolicy = true;
                bool pairClouds = true;
                bool StorageClassificationMapping = true;
                bool enableDR = true;
                bool pfo = true;
                bool commit = true;
                bool tfo = true;
                bool pfoReverse = true;
                bool commitReverse = true;
                bool rr = true;
                bool rrReverse = true;
                bool disableDR = true;
                bool unpair = true;
                bool StorageClassificationUnmap = true;
                bool removePolicy = true;

                string fabricName = "";
                string primaryCloudName = "";
                string recoveryCloudName = "";
                string VMName = "";

                DateTime testStart = DateTime.Now;

                string containerMappingName = "ContainerMapping-E2E-" + testStart.ToBinary();
                string containerMappingNameSp1 = "ContainerMapping-E2E-" + testStart.ToBinary() + "-SP1";
                string storageMappingName = "StorageMapping-E2E-" + testStart.ToBinary();
                string protectedItemName = "ProtectedItem-E2E-" + testStart.ToBinary();
                string policyName = "Policy-E2E-" + testStart.ToBinary();
                string policyNameSp1 = policyName + "-SP1";

                Fabric selectedFabric = null;
                Policy selectedPolicyR2 = null;
                Policy selectedPolicySP1 = null;
                ProtectionContainer primaryCloud = null;
                ProtectionContainer recoveryCloud = null;
                StorageClassification primaryClassification = null;
                StorageClassification recoveryClassification = null;
                ProtectableItem protectableItem = null;
                ReplicationProtectedItem protectedItem = null;

                // Get Fabric
                if (string.IsNullOrEmpty(fabricName))
                {
                    selectedFabric = client.GetVMMs()
                        .First(item => client.GetUnpairedContainers(item).Count >= 2);
                }
                else
                {
                    selectedFabric = client.GetVMMs()
                        .First(item => 
                            item.Properties.FriendlyName.Equals(fabricName, StringComparison.InvariantCultureIgnoreCase));
                }

                // Get Clouds
                if (string.IsNullOrEmpty(primaryCloudName) && string.IsNullOrEmpty(recoveryCloudName))
                {
                    List<ProtectionContainer> unpairedClouds = client.GetUnpairedContainers(selectedFabric);

                    Assert.True(unpairedClouds.Count >= 2, "Not enuough clouds!");

                    primaryCloud = unpairedClouds[0];
                    recoveryCloud = unpairedClouds[1];
                }
                else
                {
                    List<ProtectionContainer> cloudsInFabric = 
                        client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders).ProtectionContainers.ToList();

                    if (string.IsNullOrEmpty(primaryCloudName))
                    {
                        primaryCloud = cloudsInFabric.First(item => item.Properties.PairingStatus == "NotPaired");
                    }
                    else
                    {
                        primaryCloud = cloudsInFabric.First(item => 
                            item.Properties.FriendlyName.Equals(primaryCloudName, StringComparison.InvariantCultureIgnoreCase));
                    }

                    if (string.IsNullOrEmpty(recoveryCloudName))
                    {
                        recoveryCloud = cloudsInFabric.First(item => 
                            item.Properties.PairingStatus == "NotPaired" && 
                            item.Properties.FriendlyName != primaryCloud.Properties.FriendlyName);
                    }
                    else
                    {
                        recoveryCloud = cloudsInFabric.First(item =>
                            item.Properties.FriendlyName.Equals(recoveryCloudName, StringComparison.InvariantCultureIgnoreCase));
                    }
                }

                // Get Storage Classifications
                List<StorageClassification> storageClassifications =
                    client.StorageClassification.List(selectedFabric.Name, RequestHeaders).StorageClassifications.ToList();

                if (storageClassifications.Count > 1)
                {
                    primaryClassification = storageClassifications[0];
                    recoveryClassification = storageClassifications[1];
                }
                else
                {
                    primaryClassification = storageClassifications[0];
                    recoveryClassification = storageClassifications[0];
                }

                // Begin Operations
                if (createPolicy)
                {
                    selectedPolicyR2 = client.CreateHyperV2012R2Policy(policyName).Policy;
                    selectedPolicySP1 = client.CreateHyperV2012Policy(policyNameSp1).Policy;
                }
                else
                {
                    selectedPolicyR2 = client.Policies.Get(policyName, RequestHeaders).Policy;
                    selectedPolicySP1 = client.Policies.Get(policyNameSp1, RequestHeaders).Policy;
                }
                
                if (pairClouds)
                {
                    client.PairClouds(
                        selectedFabric,
                        primaryCloud,
                        recoveryCloud,
                        selectedPolicyR2,
                        containerMappingName);

                    client.PairClouds(
                        selectedFabric,
                        primaryCloud,
                        recoveryCloud,
                        selectedPolicySP1,
                        containerMappingNameSp1);
                }

                if (StorageClassificationMapping)
                {
                    client.PairStorageClassification(
                        selectedFabric,
                        primaryClassification,
                        recoveryClassification,
                        storageMappingName);
                }

                // Fetch protectable Item
                if (string.IsNullOrEmpty(VMName))
                {
                    protectableItem = client.GetUnprotectedItems(
                        selectedFabric,
                        primaryCloud).First();
                }
                else
                {
                    var protectableItems = client.ProtectableItem.List(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        "All",
                        null,
                        "1000",
                        RequestHeaders).ProtectableItems;

                    protectableItem = protectableItems.First(item => 
                        item.Properties.FriendlyName.Equals(VMName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (enableDR)
                {
                    protectedItem = client.EnableDR(
                        selectedFabric,
                        primaryCloud,
                        selectedPolicyR2,
                        protectableItem,
                        protectedItemName).ReplicationProtectedItem;
                }
                else
                {
                    protectedItem = client.ReplicationProtectedItem.Get(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        protectedItemName,
                        RequestHeaders).ReplicationProtectedItem;
                }

                if (tfo)
                {
                    client.TestFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem);
                }

                if (pfo)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commit)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (rr)
                {
                    protectedItem = client.ReverseReplication(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (pfoReverse)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commitReverse)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (rrReverse)
                {
                    protectedItem = client.ReverseReplication(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (disableDR)
                {
                    client.DisableDR(
                        selectedFabric,
                        primaryCloud,
                        protectedItemName);
                }

                if (unpair)
                {
                    client.UnpairClouds(
                        selectedFabric,
                        primaryCloud,
                        containerMappingName);
                }

                if (StorageClassificationUnmap)
                {
                    client.UnpairStorageClassification(
                        selectedFabric,
                        primaryClassification,
                        storageMappingName);
                }

                if (removePolicy)
                {
                    client.RemovePolicy(policyName);
                    client.RemovePolicy(policyNameSp1);
                }
            }
        }

        public void EndToEndSingleVME2A()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                bool createPolicy = true;
                bool pairClouds = true;
                bool enableDR = true;
                bool pfo = true;
                bool commit = true;
                bool tfo = true;
                bool pfoReverse = true;
                bool commitReverse = true;
                bool rrReverse = true;
                bool disableDR = true;
                bool unpair = true;
                bool removePolicy = true;

                string fabricName = "ramjsing-VMMR2";
                string primaryCloudName = "E2ACLD1";
                string VMName = "";
                string storageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc";
                DateTime testStart = DateTime.Now;

                string containerMappingName = "ContainerMapping-E2A-" + testStart.ToBinary();
                string protectedItemName = "ProtectedItem-E2A-" + testStart.ToBinary();
                string policyName = "Policy-E2A-" + testStart.ToBinary();

                Fabric selectedFabric = null;
                Policy selectedPolicy = null;
                ProtectionContainer primaryCloud = null;
                ProtectableItem protectableItem = null;
                ReplicationProtectedItem protectedItem = null;

                // Get Fabric
                if (string.IsNullOrEmpty(fabricName))
                {
                    selectedFabric = client.GetVMMs()
                        .First(item => client.GetUnpairedContainers(item).Count >= 1);
                }
                else
                {
                    selectedFabric = client.GetVMMs()
                        .First(item =>
                            item.Properties.FriendlyName.Contains(fabricName));
                }

                // Get Clouds
                if (string.IsNullOrEmpty(primaryCloudName))
                {
                    Assert.True(pairClouds, "Provide cloud name if pairing is not to be performed");

                    List<ProtectionContainer> unpairedClouds = client.GetUnpairedContainers(selectedFabric);

                    Assert.True(unpairedClouds.Count >= 1, "Not enuough clouds!");

                    primaryCloud = unpairedClouds[0];
                }
                else
                {
                    List<ProtectionContainer> cloudsInFabric =
                        client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders).ProtectionContainers.ToList();

                    primaryCloud = cloudsInFabric.First(item =>
                        item.Properties.FriendlyName.Equals(primaryCloudName, StringComparison.InvariantCultureIgnoreCase));
                }

                // Begin Operations
                if (createPolicy)
                {
                    selectedPolicy = client.CreateHyperVReplicaAzurePolicy(policyName, storageAccountId).Policy;
                }
                else
                {
                    selectedPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
                }

                if (pairClouds)
                {
                    client.PairCloudToAzure(
                        selectedFabric,
                        primaryCloud,
                        selectedPolicy,
                        containerMappingName);
                }

                // Fetch protectable Item
                if (string.IsNullOrEmpty(VMName))
                {
                    protectableItem = client.GetUnprotectedItems(
                        selectedFabric,
                        primaryCloud).First();
                }
                else
                {
                    var protectableItems = client.ProtectableItem.List(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        "All",
                        null,
                        "1000",
                        RequestHeaders).ProtectableItems;

                    protectableItem = protectableItems.First(item =>
                        item.Properties.FriendlyName.Equals(VMName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (enableDR)
                {
                    protectedItem = client.EnableDR(
                        selectedFabric,
                        primaryCloud,
                        selectedPolicy,
                        protectableItem,
                        protectedItemName).ReplicationProtectedItem;
                }
                else
                {
                    protectedItem = client.ReplicationProtectedItem.Get(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        protectedItemName,
                        RequestHeaders).ReplicationProtectedItem;
                }

                if (tfo)
                {
                    client.TestFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem);
                }

                if (pfo)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commit)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (pfoReverse)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commitReverse)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (rrReverse)
                {
                    protectedItem = client.ReverseReplication(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (disableDR)
                {
                    client.DisableDR(
                        selectedFabric,
                        primaryCloud,
                        protectedItemName);
                }

                if (unpair)
                {
                    client.UnpairClouds(
                        selectedFabric,
                        primaryCloud,
                        containerMappingName);
                }

                if (removePolicy)
                {
                    client.RemovePolicy(policyName);
                }
            }
        }

        public void EndToEndSingleVMB2A()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                bool createPolicy = true;
                bool pairClouds = true;
                bool enableDR = true;
                bool pfo = true;
                bool commit = true;
                bool tfo = true;
                bool pfoReverse = true;
                bool commitReverse = true;
                bool rrReverse = true;
                bool disableDR = true;
                bool unpair = true;
                bool removePolicy = true;

                string fabricName = "";
                string primaryCloudName = "";
                string VMName = "";
                string storageAccountId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/StorageAccounts/bvtmapped2storacc";
                DateTime testStart = DateTime.Now;

                string containerMappingName = "ContainerMapping-B2A-" + testStart.ToBinary();
                string protectedItemName = "ProtectedItem-B2A-" + testStart.ToBinary();
                string policyName = "Policy-B2A-" + testStart.ToBinary();

                Fabric selectedFabric = null;
                Policy selectedPolicy = null;
                ProtectionContainer primaryCloud = null;
                ProtectableItem protectableItem = null;
                ReplicationProtectedItem protectedItem = null;

                // Get Fabric
                if (string.IsNullOrEmpty(fabricName))
                {
                    selectedFabric = client.GetHyperVSites()
                        .First(item => client.GetUnpairedContainers(item).Count >= 1);
                }
                else
                {
                    selectedFabric = client.GetHyperVSites()
                        .First(item =>
                            item.Properties.FriendlyName.Equals(fabricName, StringComparison.InvariantCultureIgnoreCase));
                }

                // Get Clouds
                if (string.IsNullOrEmpty(primaryCloudName))
                {
                    Assert.True(pairClouds, "Provide cloud name if pairing is not to be performed");

                    List<ProtectionContainer> unpairedClouds = client.GetUnpairedContainers(selectedFabric);

                    Assert.True(unpairedClouds.Count >= 1, "Not enuough clouds!");

                    primaryCloud = unpairedClouds[0];
                }
                else
                {
                    List<ProtectionContainer> cloudsInFabric =
                        client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders).ProtectionContainers.ToList();

                    primaryCloud = cloudsInFabric.First(item =>
                        item.Properties.FriendlyName.Equals(primaryCloudName, StringComparison.InvariantCultureIgnoreCase));
                }

                // Begin Operations
                if (createPolicy)
                {
                    selectedPolicy = client.CreateHyperVReplicaAzurePolicy(policyName, storageAccountId).Policy;
                }
                else
                {
                    selectedPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;
                }

                if (pairClouds)
                {
                    client.PairCloudToAzure(
                        selectedFabric,
                        primaryCloud,
                        selectedPolicy,
                        containerMappingName);
                }

                // Fetch protectable Item
                if (string.IsNullOrEmpty(VMName))
                {
                    protectableItem = client.GetUnprotectedItems(
                        selectedFabric,
                        primaryCloud).First();
                }
                else
                {
                    var protectableItems = client.ProtectableItem.List(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        "All",
                        null,
                        "1000",
                        RequestHeaders).ProtectableItems;

                    protectableItem = protectableItems.First(item =>
                        item.Properties.FriendlyName.Equals(VMName, StringComparison.InvariantCultureIgnoreCase));
                }

                if (enableDR)
                {
                    protectedItem = client.EnableDR(
                        selectedFabric,
                        primaryCloud,
                        selectedPolicy,
                        protectableItem,
                        protectedItemName).ReplicationProtectedItem;
                }
                else
                {
                    protectedItem = client.ReplicationProtectedItem.Get(
                        selectedFabric.Name,
                        primaryCloud.Name,
                        protectedItemName,
                        RequestHeaders).ReplicationProtectedItem;
                }

                if (tfo)
                {
                    client.TestFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem);
                }

                if (pfo)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commit)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (pfoReverse)
                {
                    protectedItem = client.PlannedFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (commitReverse)
                {
                    protectedItem = client.CommitFailover(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (rrReverse)
                {
                    protectedItem = client.ReverseReplication(
                        selectedFabric,
                        primaryCloud,
                        protectedItem).ReplicationProtectedItem;
                }

                if (disableDR)
                {
                    client.DisableDR(
                        selectedFabric,
                        primaryCloud,
                        protectedItemName);
                }

                if (unpair)
                {
                    client.UnpairClouds(
                        selectedFabric,
                        primaryCloud,
                        containerMappingName);
                }

                if (removePolicy)
                {
                    client.RemovePolicy(policyName);
                }
            }
        }
    }
}
