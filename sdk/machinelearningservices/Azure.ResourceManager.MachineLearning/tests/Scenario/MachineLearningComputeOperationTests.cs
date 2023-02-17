// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using ManagedServiceIdentityType = Azure.ResourceManager.Models.ManagedServiceIdentityType;
using StorageAccountType = Azure.ResourceManager.Compute.Models.StorageAccountType;
using KeyVaultProperties = Azure.ResourceManager.KeyVault.Models.KeyVaultProperties;
using Azure.ResourceManager.KeyVault.Models;

namespace Azure.ResourceManager.MachineLearning.Tests
{
    public class MachineLearningComputeOperationTests : MachineLearningTestBase
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        public MachineLearningComputeOperationTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        { }

        [Ignore("Added this test to validate tagability.  Leaving the code in place since all the pre-requisite setup works and its useful for the rest of the tests when we get around to writing them.")]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            MachineLearningComputeResource mlCompute = await CreateMachineLearningComputeAsync();
            //MachineLearningComputeResource mlCompute2 = await mlCompute.AddTagAsync("key", "value");
            //Assert.AreEqual(1, mlCompute2.Data.Tags.Count);
            //Assert.AreEqual("value", mlCompute2.Data.Tags["key"]);

            //CompareAllButTags(mlCompute, mlCompute2);
        }

        private void CompareAllButTags(MachineLearningComputeResource mlCompute, MachineLearningComputeResource mlCompute2)
        {
            Assert.AreEqual(mlCompute.Data.Name, mlCompute2.Data.Name);
            Assert.AreEqual(mlCompute.Data.Id, mlCompute2.Data.Id);
            Assert.AreEqual(mlCompute.Data.Identity.ManagedServiceIdentityType, mlCompute2.Data.Identity.ManagedServiceIdentityType);
            Assert.AreEqual(mlCompute.Data.Identity.PrincipalId, mlCompute2.Data.Identity.PrincipalId);
            Assert.AreEqual(mlCompute.Data.Identity.UserAssignedIdentities.Count, mlCompute2.Data.Identity.UserAssignedIdentities.Count);
            Assert.AreEqual(mlCompute.Data.Location, mlCompute2.Data.Location);
            Assert.AreEqual(mlCompute.Data.ResourceType, mlCompute2.Data.ResourceType);
            Assert.AreEqual(mlCompute.Data.Sku.Name, mlCompute2.Data.Sku.Name);
            Assert.AreEqual(mlCompute.Data.Sku.Family, mlCompute2.Data.Sku.Family);
            Assert.AreEqual(mlCompute.Data.Sku.Capacity, mlCompute2.Data.Sku.Capacity);
            Assert.AreEqual(mlCompute.Data.Sku.Size, mlCompute2.Data.Sku.Size);
            Assert.AreEqual(mlCompute.Data.Sku.Tier, mlCompute2.Data.Sku.Tier);
        }

        private async Task<MachineLearningComputeResource> CreateMachineLearningComputeAsync()
        {
            SaveDebugRecordingsOnFailure = true;
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("rg-");
            var resourceGroup = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(DefaultLocation))).Value;
            string mlWorkspaceName = Recording.GenerateAssetName("mlWorkspace-");
            var mlWorkspaceData = new MachineLearningWorkspaceData(DefaultLocation);
            mlWorkspaceData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            mlWorkspaceData.KeyVault = await CreateKeyVaultIdAsync(resourceGroup);
            var mlWorkspace = (await resourceGroup.GetMachineLearningWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, mlWorkspaceName, mlWorkspaceData)).Value;
            string mlComputeName = Recording.GenerateAssetName("mlCompute-");
            var mlComputeData = new MachineLearningComputeData(DefaultLocation);
            mlComputeData.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var vm = await CreateVmAsync(resourceGroup);
            mlComputeData.Properties = new MachineLearningComputeInstance();
            mlComputeData.Properties.ComputeType = ComputeType.VirtualMachine;
            mlComputeData.Properties.ResourceId = vm.Id;
            return (await mlWorkspace.GetMachineLearningComputes().CreateOrUpdateAsync(WaitUntil.Completed, mlComputeName, mlComputeData)).Value;
        }

        private async Task<ResourceIdentifier> CreateKeyVaultIdAsync(ResourceGroupResource resourceGroup)
        {
            string keyVaultName = Recording.GenerateAssetName("kv-");
            var kvProperties = new KeyVaultProperties(Guid.Parse(TestEnvironment.TenantId), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
            var kv = (await resourceGroup.GetKeyVaults().CreateOrUpdateAsync(WaitUntil.Completed, keyVaultName, new KeyVaultCreateOrUpdateContent(DefaultLocation, kvProperties))).Value;
            return kv.Id;
        }

        private async Task<VirtualMachineResource> CreateVmAsync(ResourceGroupResource resourceGroup)
        {
            var collection = resourceGroup.GetVirtualMachines();
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync(resourceGroup);
            string vmName = Recording.GenerateAssetName("vm-");
            var input = GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            return lro.Value;
        }

        private async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineAsync(ResourceGroupResource resourceGroup)
        {
            var vnet = await CreateVirtualNetwork(resourceGroup);
            var ip = await CreatePublicIPAddress(resourceGroup);
            var nic = await CreateNetworkInterface(resourceGroup, GetSubnetId(vnet), ip.Id);
            return nic;
        }

        private async Task<PublicIPAddressResource> CreatePublicIPAddress(ResourceGroupResource resourceGroup)
        {
            var ipName = Recording.GenerateAssetName("ip-");
            var ipData = new PublicIPAddressData();
            ipData.Location = DefaultLocation;
            return (await resourceGroup.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, ipName, ipData)).Value;
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceGroupResource resourceGroup, ResourceIdentifier subnetId, ResourceIdentifier publicIpAddressId)
        {
            var nicName = Recording.GenerateAssetName("testNic-");
            ResourceIdentifier nicId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "ipConfigurations", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "name", "internal" },
                                { "properties", new Dictionary<string, object>()
                                    {
                                        { "subnet", new Dictionary<string, object>() { { "id", subnetId.ToString() } } },
                                        { "publicIPAddress", new Dictionary<string, object>() { { "id", publicIpAddressId.ToString() } } }
                                    }
                                }
                            }
                        }
                    }
                })
            };
            var operation = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, nicId, input);
            return operation.Value;
        }

        private ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties.ToObjectFromJson() as Dictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        protected async Task<GenericResource> CreateVirtualNetwork(ResourceGroupResource resourceGroup)
        {
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                })
            };
            var operation = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, vnetId, input);
            return operation.Value;
        }

        private static VirtualMachineData GetBasicLinuxVirtualMachineData(AzureLocation location, string computerName, ResourceIdentifier nicID, string adminUsername = "adminuser")
        {
            return new VirtualMachineData(location)
            {
                HardwareProfile = new()
                {
                    VmSize = VirtualMachineSizeType.StandardF2
                },
                OSProfile = new()
                {
                    AdminUsername = adminUsername,
                    ComputerName = computerName,
                    LinuxConfiguration = new()
                    {
                        DisablePasswordAuthentication = true,
                        SshPublicKeys =
                        {
                            new()
                            {
                                Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                KeyData = dummySSHKey,
                            }
                        }
                    }
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = nicID,
                            Primary = true,
                        }
                    },
                },
                StorageProfile = new()
                {
                    OSDisk = new(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Linux,
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs
                        }
                    },
                    ImageReference = new()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };
        }
    }
}
