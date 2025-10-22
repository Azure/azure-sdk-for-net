// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.StandbyPool.Models;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    public class StandbyVirtualMachinePoolTestBase : StandbyPoolManagementTestBase
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        protected StandbyVirtualMachinePoolTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, AzureLocation.EastAsia)
        {
        }
        public StandbyVirtualMachinePoolTestBase(bool isAsync) : base(isAsync, AzureLocation.EastAsia)
        {
        }

        protected async Task<StandbyVirtualMachinePoolResource> CreateStandbyVirtualMachinePoolResource(ResourceGroupResource resourceGroup, string standbyVirtualMachinePoolName, long maxReadyCapacity, AzureLocation location, ResourceIdentifier vmssId, string virtualMachineState = "Running", long minReadyCapacity = 1)
        {
            StandbyVirtualMachinePoolProperties properties = new StandbyVirtualMachinePoolProperties()
            {
                VirtualMachineState = virtualMachineState,
                ElasticityProfile = new Models.StandbyVirtualMachinePoolElasticityProfile()
                {
                    MaxReadyCapacity = maxReadyCapacity,
                    MinReadyCapacity = minReadyCapacity
                },
                AttachedVirtualMachineScaleSetId = vmssId
            };

            StandbyVirtualMachinePoolData input = new StandbyVirtualMachinePoolData(location)
            {
                Location = location,
                Properties = properties
            };
            StandbyVirtualMachinePoolCollection collection = resourceGroup.GetStandbyVirtualMachinePools();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, standbyVirtualMachinePoolName, input);
            return lro.Value;
        }

        protected async Task<VirtualMachineScaleSetResource> CreateDependencyResourcs(ResourceGroupResource resourceGroup, GenericResourceCollection _genericResourceCollection, AzureLocation location)
        {
            var vnet = this.CreateVirtualNetwork(resourceGroup, _genericResourceCollection, location);
            ResourceIdentifier subnetId = GetSubnetId(vnet.Result);
            var networksSecurityGroup = this.CreateNetworkSecurityGroups(resourceGroup, _genericResourceCollection, location);
            return await this.CreateVirtualMachineScaleSet(resourceGroup, _genericResourceCollection, subnetId, networksSecurityGroup.Result.Id, location);
        }

        protected async Task<GenericResource> CreateNetworkSecurityGroups(ResourceGroupResource resourceGroup, GenericResourceCollection _genericResourceCollection, AzureLocation location)
        {
            var networkSecurityGroups = Recording.GenerateAssetName("testVNetSecurityGroups-");
            ResourceIdentifier networkSecurityGroupsId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroups}");
            var input = new GenericResourceData(location)
            {
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupsId, input);
            return operation.Value;
        }

        protected async Task<VirtualMachineScaleSetResource> CreateVirtualMachineScaleSet(ResourceGroupResource resourceGroup, GenericResourceCollection _genericResourceCollection, ResourceIdentifier subnetId, ResourceIdentifier networkSecurityGroupsId, AzureLocation location)
        {
            var vmssName = Recording.GenerateAssetName("testVMSS-");

            VirtualMachineScaleSetData data = new VirtualMachineScaleSetData(location)
            {
                Sku = new ComputeSku()
                {
                    Name = "Standard_DS1_v2",
                    Capacity = 0,
                },
                OrchestrationMode = OrchestrationMode.Flexible,
                VirtualMachineProfile = new VirtualMachineScaleSetVmProfile()
                {
                    OSProfile = new VirtualMachineScaleSetOSProfile()
                    {
                        ComputerNamePrefix = "testVMSS",
                        AdminUsername = "dummyAdmin",
                        AdminPassword = "DummyPassword123",
                        LinuxConfiguration = new LinuxConfiguration()
                        {
                            DisablePasswordAuthentication = false,
                            SshPublicKeys =
                            {
                                new SshPublicKeyConfiguration()
                                {
                                    Path = "/home/dummyAdmin/.ssh/authorized_keys",
                                    KeyData = dummySSHKey,
                                }
                            },
                        },
                    },
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        ImageReference = new ImageReference()
                        {
                            Publisher = "canonical",
                            Offer = "0001-com-ubuntu-server-focal",
                            Sku = "20_04-lts-gen2",
                            Version = "latest",
                        },
                        OSDisk = new VirtualMachineScaleSetOSDisk(DiskCreateOptionType.FromImage)
                        {
                            Caching = CachingType.ReadWrite,
                            ManagedDisk = new VirtualMachineScaleSetManagedDisk()
                            {
                                StorageAccountType = StorageAccountType.PremiumLrs,
                            },
                        },
                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile()
                    {
                        NetworkInterfaceConfigurations =
                        {
                            new VirtualMachineScaleSetNetworkConfiguration(vmssName)
                            {
                                Primary = true,
                                EnableAcceleratedNetworking = false,
                                NetworkSecurityGroupId = networkSecurityGroupsId,
                                IPConfigurations =
                                {
                                    new VirtualMachineScaleSetIPConfiguration(vmssName)
                                    {
                                        SubnetId = subnetId,
                                        PublicIPAddressConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration(vmssName)
                                        {
                                            IdleTimeoutInMinutes = 15,
                                        }
                                    }
                                },
                            }
                        },
                        NetworkApiVersion = "2020-11-01"
                    },
                    BootDiagnostics = new BootDiagnostics()
                    {
                        Enabled = true
                    }
                },
                PlatformFaultDomainCount = 1
            };

            var operation = await resourceGroup.GetVirtualMachineScaleSets().CreateOrUpdateAsync(WaitUntil.Completed, vmssName, data);
            return operation.Value;
        }
    }
}
