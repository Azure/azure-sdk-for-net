//
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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Azure;


namespace SiteRecovery.Tests
{
    public class PairingTests : SiteRecoveryTestsBase
    {
        public void PairClouds()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string priCld = string.Empty;
                string recCldGuid = string.Empty;
                string recCld = string.Empty;
                string policyName = "Hydra" + (new Random()).Next();
                Fabric selectedFabric = null;
                Policy currentPolicy = null;

                var fabrics = client.Fabrics.List(RequestHeaders);

                foreach (var fabric in fabrics.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
                    {
                        selectedFabric = fabric;
                    }
                }

                var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

                foreach (var container in containers.ProtectionContainers)
                {
                    if (client.ProtectionContainerMapping.List(selectedFabric.Name, container.Name, RequestHeaders).ProtectionContainerMappings.Count == 0)
                    {
                        if (string.IsNullOrEmpty(priCld))
                        {
                            priCld = container.Name;
                        }
                        else if (string.IsNullOrEmpty(recCld))
                        {
                            recCld = container.Id;
                            recCldGuid = container.Name;
                        }
                    }
                }

                HyperVReplica2012R2PolicyInput hvrProfileInput = new HyperVReplica2012R2PolicyInput()
                {
                    ApplicationConsistentSnapshotFrequencyInHours = 0,
                    AllowedAuthenticationType = 1,
                    Compression = "Enable",
                    InitialReplicationMethod = "OverNetwork",
                    OnlineReplicationStartTime = null,
                    RecoveryPoints = 0,
                    ReplicaDeletion = "Required"
                };

                CreatePolicyInputProperties policyCreationProp = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = hvrProfileInput
                };

                CreatePolicyInput policyCreationInput = new CreatePolicyInput()
                {
                    Properties = policyCreationProp
                };

                var policyCreateResp = client.Policies.Create(policyName, policyCreationInput, RequestHeaders);

                currentPolicy = client.Policies.Get(policyName, RequestHeaders).Policy;

                CreateProtectionContainerMappingInputProperties pairingProps =
                    new CreateProtectionContainerMappingInputProperties()
                {
                    PolicyId = currentPolicy.Id,
                    ProviderSpecificInput = new ReplicationProviderContainerMappingInput(),
                    TargetProtectionContainerId = recCld
                };

                CreateProtectionContainerMappingInput pairingInput = new CreateProtectionContainerMappingInput()
                {
                    Properties = pairingProps
                };

                var pairingResp = client.ProtectionContainerMapping.ConfigureProtection(selectedFabric.Name, priCld, "Mapping01", pairingInput, RequestHeaders);
            }
        }

        public void UnpairClouds()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                Fabric selectedFabric = null;

                string fabricName = "Vmm;6adf9420-b02f-4377-8ab7-ff384e6d792f";
                string mappingName = "Mapping01";
                string cloudName = "4f94127d-2eb3-449d-a708-250752e93cb4";

                selectedFabric = client.Fabrics.Get(fabricName, RequestHeaders).Fabric;

                var mapping = client.ProtectionContainerMapping.Get(fabricName, cloudName, mappingName, RequestHeaders);
                var unpairResp = client.ProtectionContainerMapping.UnconfigureProtection(fabricName, cloudName, mappingName, new RemoveProtectionContainerMappingInput(), RequestHeaders);
            }
        }

        public void CreateHyperVAzureProfile()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                string policyName = "Hydra-Profile-HyperVAzure";
                HyperVReplicaAzurePolicyInput hvrAPolicy = new HyperVReplicaAzurePolicyInput()
                {
                    ApplicationConsistentSnapshotFrequencyInHours = 0,
                    Encryption = "Disable",
                    OnlineIrStartTime = null,
                    RecoveryPointHistoryDuration = 0,
                    ReplicationInterval = 30,
                    StorageAccounts = new List<string>() { "/subscriptions/c89695cf-3a29-4ff0-86da-2696d2c5322b/resourceGroups/Default-Storage-SoutheastAsia/providers/Microsoft.ClassicStorage/storageAccounts/sa03sub10v1sea" }
                };

                CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = hvrAPolicy
                };

                CreatePolicyInput policyInput = new CreatePolicyInput()
                {
                    Properties = createInputProp
                };

                var policy = client.Policies.Create(policyName, policyInput, RequestHeaders);

                //var selectedPolicy = (client.Policies.Create(policyName, policyInput, RequestHeaders) as CreatePolicyOperationResponse).Policy;
            }
        }

        public void DeleteProfile()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                string policyName = "Hydra-Profile-HyperVAzure";
                var deleteResponse = client.Policies.Delete(policyName, RequestHeaders);
            }
        }

        public void CreateHyperV2012Profile()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                string policyName = "Hydra-Profile-HyperV-2012-" + new Random().Next();
                HyperVReplica2012PolicyInput hvrProfileInput = new HyperVReplica2012PolicyInput()
                {
                    ApplicationConsistentSnapshotFrequencyInHours = 0,
                    AllowedAuthenticationType = 1,
                    Compression = "Enable",
                    InitialReplicationMethod = "OverNetwork",
                    OnlineReplicationStartTime = null,
                    RecoveryPoints = 0,
                    ReplicaDeletion = "Required",
                    ReplicationPort = 8083
                };

                CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = hvrProfileInput
                };

                CreatePolicyInput policyInput = new CreatePolicyInput()
                {
                    Properties = createInputProp
                };

                var response = client.Policies.Create(policyName, policyInput, RequestHeaders);
                Assert.NotNull(response);
                Assert.Equal(response.Status, OperationStatus.Succeeded);

                var policyResponse = response as CreatePolicyOperationResponse;
                Assert.NotNull(policyResponse);
                Assert.NotNull(policyResponse.Policy);
                Assert.Equal(policyResponse.Policy.Name, policyName);
            }
        }

        public void CreateHyperV2012R2Profile()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                string policyName = "Hydra-Profile-HyperV-2012-R2-" + new Random().Next();
                HyperVReplica2012R2PolicyInput hvrProfileInput = new HyperVReplica2012R2PolicyInput()
                {
                    ApplicationConsistentSnapshotFrequencyInHours = 0,
                    AllowedAuthenticationType = 1,
                    Compression = "Enable",
                    InitialReplicationMethod = "OverNetwork",
                    OnlineReplicationStartTime = null,
                    RecoveryPoints = 0,
                    ReplicaDeletion = "Required",
                    ReplicationPort = 8083,
                    ReplicationFrequencyInSeconds = 300
                };

                CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = hvrProfileInput
                };

                CreatePolicyInput policyInput = new CreatePolicyInput()
                {
                    Properties = createInputProp
                };

                var response = client.Policies.Create(policyName, policyInput, RequestHeaders);
                Assert.NotNull(response);
                Assert.Equal(response.Status, OperationStatus.Succeeded);

                var policyResponse = response as CreatePolicyOperationResponse;
                Assert.NotNull(policyResponse);
                Assert.NotNull(policyResponse.Policy);
                Assert.Equal(policyResponse.Policy.Name, policyName);
            }
        }

        public void CreateVMwareAzureV2Profile()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                string policyName = "Hitesh-VMwareAzureV2-Profile";
                var input = new InMageAzureV2PolicyInput
                {
                    AppConsistentFrequencyInMinutes = 15,
                    CrashConsistentFrequencyInMinutes = 15,
                    MultiVmSyncStatus = "Disable",
                    RecoveryPointHistory = 15,
                    RecoveryPointThresholdInMinutes = 30
                };

                CreatePolicyInputProperties createInputProp = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = input
                };

                CreatePolicyInput policyInput = new CreatePolicyInput()
                {
                    Properties = createInputProp
                };

                var response = client.Policies.Create(policyName, policyInput, RequestHeaders);
                Assert.NotNull(response);
                Assert.Equal(response.Status, OperationStatus.Succeeded);

                var policyResponse = response as CreatePolicyOperationResponse;
                Assert.NotNull(policyResponse);
                Assert.NotNull(policyResponse.Policy);
                Assert.Equal(policyResponse.Policy.Name, policyName);
            }
        }

        public void PairNetworks()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                const string primaryNetworkName = "718b68df-ac22-412e-9312-91135cc4451f";
                const string networkMappingName = "Test";
                CreateNetworkMappingInput input = new CreateNetworkMappingInput()
                {
                    //RecoveryFabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7",
                    //RecoveryNetworkId = "/Subscriptions/fa7fd0da-bfa7-41b1-9877-8664fc43d59f/resourceGroups/Default-Storage-WestUS/providers/Microsoft.SiteRecovery/SiteRecoveryVault/testVault/replicationFabrics/Vmm;f0632449-effd-4858-a210-4ea15756e4b7/replicationNetworks/15e1a665-e184-4da0-8e9d-0de72a7d8fa9"
                    RecoveryFabricName = "Microsoft Azure",
                    RecoveryNetworkId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Networking/providers/Microsoft.ClassicNetwork/virtualNetworks/BvtMapped1Network1"
                };

                var response = client.NetworkMapping.Create(
                    fabricName,
                    primaryNetworkName,
                    networkMappingName,
                    input,
                    RequestHeaders);
            }
        }

        public void UnPairNetworks()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                const string fabricName = "Vmm;f0632449-effd-4858-a210-4ea15756e4b7";
                const string primaryNetworkName = "718b68df-ac22-412e-9312-91135cc4451f";
                const string networkMappingName = "Test";

                var response = client.NetworkMapping.Delete(
                    fabricName,
                    primaryNetworkName,
                    networkMappingName,
                    RequestHeaders);
            }
        }

        public void PurgeCloudPair()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                Fabric selectedFabric = null;

                var fabrics = client.Fabrics.List(RequestHeaders);

                ProtectionContainer selectedContainer = null;

                foreach (var fabric in fabrics.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMM"))
                    {
                        selectedFabric = fabric;
                    }
                }

                var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

                foreach (var container in containers.ProtectionContainers)
                {
                    if (container.Properties.ProtectedItemCount == 0
                        && container.Properties.Role.Equals("Primary"))
                    {
                        selectedContainer = container;
                        break;
                    }
                }

                var pairs = client.ProtectionContainerMapping.List(selectedFabric.Name, selectedContainer.Name, RequestHeaders);

                var purgePairing = client.ProtectionContainerMapping.PurgeProtection(
                    selectedFabric.Name,
                    selectedContainer.Name,
                    pairs.ProtectionContainerMappings[0].Name,
                    RequestHeaders);
            }
        }

        public void CreateVMwareAzureV2Mapping()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var policyResponse = client.Policies.List(RequestHeaders);
                Assert.NotNull(policyResponse);
                Assert.NotEmpty(policyResponse.Policies);

                var policy = policyResponse.Policies.First(
                    p => p.Properties.ProviderSpecificDetails.InstanceType == "VMwareAzureV2");
                Assert.NotNull(policy);

                var response = client.ProtectionContainerMapping.ConfigureProtection(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    "Hitesh-VMwareAzureV2-Mapping",
                    new CreateProtectionContainerMappingInput
                    {
                        Properties = new CreateProtectionContainerMappingInputProperties
                        {
                            PolicyId = policy.Id,
                            ProviderSpecificInput = new ReplicationProviderContainerMappingInput(),
                            TargetProtectionContainerId = "Microsoft Azure"
                        }
                    },
                    RequestHeaders);

                Assert.NotNull(response);
                Assert.Equal(OperationStatus.Succeeded, response.Status);

                var mappingCreationResponse = response as MappingOperationResponse;
                Assert.NotNull(mappingCreationResponse);
            }
        }

        public void PairUnpairStorageClassifications()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricListResponse responseServers = client.Fabrics.List(RequestHeaders);

                foreach (Fabric fabric in responseServers.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType == "VMM")
                    {
                        var storageClassifications = client.StorageClassification.List(fabric.Name, RequestHeaders);

                        if (storageClassifications.StorageClassifications.Count > 1)
                        {
                            StorageClassificationMappingInputProperties mapProps = new StorageClassificationMappingInputProperties()
                            {
                                TargetStorageClassificationId = storageClassifications.StorageClassifications[1].Id
                            };

                            StorageClassificationMappingInput mapInput = new StorageClassificationMappingInput()
                            {
                                Properties = mapProps
                            };

                            string mappingName = "StorageClassificationMapping-" + (new Random()).Next();

                            var pairResp = client.StorageClassificationMapping.PairStorageClassification(
                                fabric.Name,
                                storageClassifications.StorageClassifications[0].Name,
                                mappingName,
                                mapInput,
                                RequestHeaders);

                            var mappings = client.StorageClassificationMapping.List(
                                fabric.Name,
                                storageClassifications.StorageClassifications[0].Name,
                                RequestHeaders);

                            var mapping = client.StorageClassificationMapping.Get(
                                fabric.Name,
                                storageClassifications.StorageClassifications[0].Name,
                                mappings.StorageClassificationMappings[0].Name,
                                RequestHeaders);

                            var unpairResp = client.StorageClassificationMapping.UnpairStorageClassification(
                                fabric.Name,
                                storageClassifications.StorageClassifications[0].Name,
                                mappingName,
                                RequestHeaders);
                        }
                    }
                }
            }
        }
    }
}
