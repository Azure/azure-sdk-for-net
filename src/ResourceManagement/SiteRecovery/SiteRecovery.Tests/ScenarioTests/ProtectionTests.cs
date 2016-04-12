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
using System.Linq;
using System.Net;
using Xunit;
using System;
using Microsoft.Azure;
using System.Collections.Generic;


namespace SiteRecovery.Tests
{
    public class ProtectionTests : SiteRecoveryTestsBase
    {
        public void EnableDR()
        {
            
        }

        public void DisableDR()
        {
            
        }

        public void PurgeDR()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var fabrics = client.Fabrics.List(RequestHeaders);

                Fabric selectedFabric = null;
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
                    if (container.Properties.ProtectedItemCount > 0 
                        && container.Properties.Role.Equals("Primary"))
                    {
                        selectedContainer = container;
                        break;
                    }
                }

                if (selectedContainer != null)
                {
                    var protectedItem = client.ReplicationProtectedItem.List(
                        selectedFabric.Name, 
                        selectedContainer.Name, 
                        RequestHeaders).ReplicationProtectedItems[0];

                    var purgeResp = client.ReplicationProtectedItem.PurgeProtection(
                        selectedFabric.Name,
                        selectedContainer.Name,
                        protectedItem.Name,
                        RequestHeaders);
                }
                else
                {
                    throw new System.Exception("No protected item found");
                }
            }
        }

        public void UpdateProtection()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string replicationProtectedItemName = "PE1447651278";
                string fabricName = "Vmm;b6d8b350-2ee5-40c0-b777-2158a87c2aee";
                string containerName = "cloud_b6d8b350-2ee5-40c0-b777-2158a87c2aee";

                // Network vmNic = client.Network.List(fabricName, RequestHeaders).NetworksList[0];

                var protectedItem = client.ReplicationProtectedItem.Get(fabricName, containerName, replicationProtectedItemName, RequestHeaders);

                UpdateReplicationProtectedItemInputProperties inputProps = new UpdateReplicationProtectedItemInputProperties()
                {
                    RecoveryAzureVMSize = "Basic_A0",
                    RecoveryAzureVMName = "B2AVM4NewName",
                    //SelectedPrimaryNicId = (protectedItem.ReplicationProtectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails).VMNics[0].NicId,
                    SelectedRecoveryAzureNetworkId = "/subscriptions/19b823e2-d1f3-4805-93d7-401c5d8230d5/resourceGroups/Default-Networking/providers/Microsoft.ClassicNetwork/virtualNetworks/ramjsingNetwork1"
                };

                UpdateReplicationProtectedItemInput input = new UpdateReplicationProtectedItemInput()
                {
                    Properties = inputProps
                };

                var resp = client.ReplicationProtectedItem.UpdateProtection(fabricName, containerName, replicationProtectedItemName, input, RequestHeaders);
            }
        }

        public void UpdateProtectionOfInMageAzureV2ProtectedItem()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                string vmId = "7192c867-b38e-11e5-af2b-0050569e66ab";
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

                var protectedItemResponse = client.ReplicationProtectedItem.Get(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    vmId + "-Protected",
                    RequestHeaders);

                var replicationProtectedItem = protectedItemResponse.ReplicationProtectedItem;
                Assert.NotNull(replicationProtectedItem);

                var nics = new List<VMNicInputDetails>();
                nics.Add(
                    new VMNicInputDetails
                    {
                        NicId = "00:50:56:9E:3E:F2",
                        RecoveryVMSubnetName = "TenantSubnet",
                        SelectionType = "SelectedByUser",
                    });
                UpdateReplicationProtectedItemInputProperties inputProps = new UpdateReplicationProtectedItemInputProperties()
                {
                    RecoveryAzureVMName = replicationProtectedItem.Properties.FriendlyName,
                    VmNics = nics,
                    SelectedRecoveryAzureNetworkId = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/Default-Networking/providers/Microsoft.ClassicNetwork/virtualNetworks/ExpressRouteVNet-WUS-1"
                };

                UpdateReplicationProtectedItemInput input = new UpdateReplicationProtectedItemInput()
                {
                    Properties = inputProps
                };

                var updateResponse =
                    client.ReplicationProtectedItem.UpdateProtection(
                        vmWareFabric.Name,
                        containersResponse.ProtectionContainers[0].Name,
                        replicationProtectedItem.Name,
                        input,
                        RequestHeaders);

                Assert.NotNull(updateResponse);
                Assert.Equal(OperationStatus.Succeeded, updateResponse.Status);
            }
        }

        public void EnableProtectionForVMwareVM()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = this.GetSiteRecoveryClient(this.CustomHttpHandler);

                string vmId = "7192c867-b38e-11e5-af2b-0050569e66ab";
                string vmAccount = "vm";

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var vmWareDetails =
                   vmWareFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);

                var runAsAccount = vmWareDetails.RunAsAccounts.First(
                    account => account.AccountName.Equals(
                        vmAccount,
                        StringComparison.InvariantCultureIgnoreCase));
                Assert.NotNull(runAsAccount);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var protectableItemsResponse = client.ProtectableItem.Get(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    vmId,
                    RequestHeaders);
                Assert.NotNull(protectableItemsResponse);
                Assert.NotNull(protectableItemsResponse.ProtectableItem);

                var hikewalrProtectableItem =
                    protectableItemsResponse.ProtectableItem;

                var vmWareAzureV2Details = hikewalrProtectableItem.Properties.CustomDetails
                    as VMwareVirtualMachineDetails;
                Assert.NotNull(vmWareAzureV2Details);

                var policyResponse = client.Policies.List(RequestHeaders);
                Assert.NotNull(policyResponse);
                Assert.NotEmpty(policyResponse.Policies);

                var policy = policyResponse.Policies.First(
                    p => p.Properties.ProviderSpecificDetails.InstanceType == "InMageAzureV2");
                Assert.NotNull(policy);

                Random random = new Random(100);
                string storageAccountSubscriptionId = "c183865e-6077-46f2-a3b1-deb0f4f4650a";
                string storageAccountId = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/Default-Storage-WestUS/providers/Microsoft.ClassicStorage/storageAccounts/hikewalrstoragewestus";
                var response = client.ReplicationProtectedItem.EnableProtection(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    hikewalrProtectableItem.Name + "-Protected",
                    new EnableProtectionInput
                    {
                        Properties = new EnableProtectionInputProperties
                        {
                            PolicyId = policy.Id,
                            ProtectableItemId = hikewalrProtectableItem.Id,
                            ProviderSpecificDetails = new InMageAzureV2EnableProtectionInput
                            {
                                MultiVmGroupId = Guid.NewGuid().ToString(),
                                MultiVmGroupName = policy.Name + random.Next().ToString(),
                                ProcessServerId = vmWareDetails.ProcessServers[0].Id,
                                RunAsAccountId = runAsAccount.AccountId,
                                StorageAccountId = storageAccountId,
                                StorageSubscriptionId = storageAccountSubscriptionId,
                                MasterTargetId = vmWareDetails.MasterTargetServers[0].Id
                            }
                        }
                    },
                    RequestHeaders);

                Assert.NotNull(response);
                Assert.Equal(OperationStatus.Succeeded, response.Status);

                var enableResponse = response as ReplicationProtectedItemOperationResponse;
                Assert.NotNull(enableResponse);
                Assert.NotNull(enableResponse.ReplicationProtectedItem);
                Assert.NotNull(enableResponse.ReplicationProtectedItem.Properties);
                Assert.Equal(enableResponse.ReplicationProtectedItem.Name, hikewalrProtectableItem.Name + "-Protected");
            }
        }

        public void EnableProtectionForVMwareVMUsingInMageProvider()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = this.GetSiteRecoveryClient(this.CustomHttpHandler);

                string vmId = "1faecbb8-b47d-11e5-af2b-0050569e66ab";
                string vmAccount = "vm";

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var vmWareDetails =
                   vmWareFabric.Properties.CustomDetails as VMwareFabricDetails;
                Assert.NotNull(vmWareDetails);

                var runAsAccount = vmWareDetails.RunAsAccounts.First(
                    account => account.AccountName.Equals(
                        vmAccount,
                        StringComparison.InvariantCultureIgnoreCase));
                Assert.NotNull(runAsAccount);

                var processServer = vmWareDetails.ProcessServers.FirstOrDefault(
                    ps => ps.FriendlyName.Equals("hikewalr-psjan6"));
                Assert.NotNull(processServer);

                var masterTargetServer = vmWareDetails.MasterTargetServers.FirstOrDefault();
                Assert.NotNull(masterTargetServer);

                var containersResponse = client.ProtectionContainer.List(
                    vmWareFabric.Name,
                    RequestHeaders);
                Assert.NotNull(containersResponse);
                Assert.True(
                    containersResponse.ProtectionContainers.Count > 0,
                    "Containers count can't be less than 1.");

                var protectableItemsResponse = client.ProtectableItem.Get(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    vmId,
                    RequestHeaders);
                Assert.NotNull(protectableItemsResponse);
                Assert.NotNull(protectableItemsResponse.ProtectableItem);

                var hikewalrProtectableItem =
                    protectableItemsResponse.ProtectableItem;

                var vmWareAzureV2Details = hikewalrProtectableItem.Properties.CustomDetails
                    as VMwareVirtualMachineDetails;
                Assert.NotNull(vmWareAzureV2Details);

                var policyResponse = client.Policies.List(RequestHeaders);
                Assert.NotNull(policyResponse);
                Assert.NotEmpty(policyResponse.Policies);

                var policy = policyResponse.Policies.First(
                    p => p.Properties.ProviderSpecificDetails.InstanceType == "InMage");
                Assert.NotNull(policy);

                Random random = new Random(100);
                string dataStoreName = "datastore-local (1)";
                
                var response = client.ReplicationProtectedItem.EnableProtection(
                    vmWareFabric.Name,
                    containersResponse.ProtectionContainers[0].Name,
                    hikewalrProtectableItem.Name + "-Protected",
                    new EnableProtectionInput
                    {
                        Properties = new EnableProtectionInputProperties
                        {
                            PolicyId = policy.Id,
                            ProtectableItemId = hikewalrProtectableItem.Id,
                            ProviderSpecificDetails = new InMageEnableProtectionInput
                            {
                                DatastoreName = dataStoreName,
                                DiskExclusionInput = new InMageDiskExclusionInput(),
                                MasterTargetId = masterTargetServer.Id,
                                MultiVmGroupId = Guid.NewGuid().ToString(),
                                MultiVmGroupName = policy.Name + random.Next().ToString(),
                                ProcessServerId = processServer.Id,
                                RetentionDrive = masterTargetServer.RetentionVolumes[0].VolumeName,
                                RunAsAccountId = runAsAccount.AccountId,
                                VmFriendlyName = hikewalrProtectableItem.Properties.FriendlyName
                            }
                        }
                    },
                    RequestHeaders);

                Assert.NotNull(response);
                Assert.Equal(OperationStatus.Succeeded, response.Status);

                var enableResponse = response as ReplicationProtectedItemOperationResponse;
                Assert.NotNull(enableResponse);
                Assert.NotNull(enableResponse.ReplicationProtectedItem);
                Assert.NotNull(enableResponse.ReplicationProtectedItem.Properties);
                Assert.Equal(enableResponse.ReplicationProtectedItem.Name, hikewalrProtectableItem.Name + "-Protected");
            }
        }

        public void RefreshVMWareFabric()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = this.GetSiteRecoveryClient(this.CustomHttpHandler);

                var responseServers = client.Fabrics.List(RequestHeaders);

                Assert.True(
                    responseServers.Fabrics.Count > 0,
                    "Servers count can't be less than 1");

                var vmWareFabric = responseServers.Fabrics.First(
                    fabric => fabric.Properties.CustomDetails.InstanceType == "VMware");
                Assert.NotNull(vmWareFabric);

                var response = client.RecoveryServicesProvider.Refresh(
                    vmWareFabric.Name,
                    vmWareFabric.Name,
                    RequestHeaders);

                Assert.NotNull(response);
            }
        }

        public void DisableProtectionForVMwareVM()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var fabrics = client.Fabrics.List(RequestHeaders);

                Fabric selectedFabric = null;
                ProtectionContainer selectedContainer = null;

                foreach (var fabric in fabrics.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMware"))
                    {
                        selectedFabric = fabric;
                    }
                }

                var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

                foreach (var container in containers.ProtectionContainers)
                {
                    if (container.Properties.ProtectedItemCount > 0
                        && container.Properties.Role.Equals("Primary"))
                    {
                        selectedContainer = container;
                        break;
                    }
                }

                if (selectedContainer != null)
                {
                    var protectedItem = client.ReplicationProtectedItem.List(
                        selectedFabric.Name,
                        selectedContainer.Name,
                        RequestHeaders).ReplicationProtectedItems[0];

                    var response = client.ReplicationProtectedItem.DisableProtection(
                        selectedFabric.Name,
                        selectedContainer.Name,
                        protectedItem.Name,
                        new DisableProtectionInput()
                        {
                            Properties = new DisableProtectionInputProperties()
                            {
                                ProviderSettings = new DisableProtectionProviderSpecificInput()
                                {

                                }
                            }
                        },
                        RequestHeaders);

                    Assert.NotNull(response);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                }
                else
                {
                    throw new System.Exception("No protected item found");
                }
            }
        }

        public void PurgeProtectionForVMwareVM()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var fabrics = client.Fabrics.List(RequestHeaders);

                Fabric selectedFabric = null;
                ProtectionContainer selectedContainer = null;

                foreach (var fabric in fabrics.Fabrics)
                {
                    if (fabric.Properties.CustomDetails.InstanceType.Contains("VMware"))
                    {
                        selectedFabric = fabric;
                    }
                }

                var containers = client.ProtectionContainer.List(selectedFabric.Name, RequestHeaders);

                foreach (var container in containers.ProtectionContainers)
                {
                    if (container.Properties.ProtectedItemCount > 0
                        && container.Properties.Role.Equals("Primary"))
                    {
                        selectedContainer = container;
                        break;
                    }
                }

                if (selectedContainer != null)
                {
                    var protectedItem = client.ReplicationProtectedItem.List(
                        selectedFabric.Name,
                        selectedContainer.Name,
                        RequestHeaders).ReplicationProtectedItems[0];

                    var response = client.ReplicationProtectedItem.PurgeProtection(
                        selectedFabric.Name,
                        selectedContainer.Name,
                        protectedItem.Name,
                        RequestHeaders);

                    Assert.NotNull(response);
                    Assert.Equal(OperationStatus.Succeeded, response.Status);
                }
                else
                {
                    throw new System.Exception("No protected item found");
                }
            }
        }
    }
}
