// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ArcVm.Models;
using Azure.ResourceManager.HybridCompute;
using Azure.ResourceManager.HybridCompute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ExtendedLocation = Azure.ResourceManager.ArcVm.Models.ExtendedLocation;
using ExtendedLocationType = Azure.ResourceManager.ArcVm.Models.ExtendedLocationType;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class ArcVmManagementTestBase : ManagementRecordedTestBase<ArcVmManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected string CustomLocationId { get; private set; }
        protected AzureLocation Location { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected ArcVmManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ArcVmManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            var rgPrefix = "hci-dotnet-test-rg-";
            Client = GetArmClient();
            Location = AzureLocation.EastUS;
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroup = await CreateResourceGroup(DefaultSubscription, rgPrefix);
            CustomLocationId = TestEnvironment.CustomLocationId;
        }

        public async Task<bool> RetryUntilSuccessOrTimeout(Func<Task<bool>> task, TimeSpan timeSpan)
        {
            bool success = false;
            int elapsed = 0;
            int frequency = 5000;
            while (!success && elapsed < timeSpan.TotalMilliseconds)
            {
                Thread.Sleep(frequency);
                elapsed += frequency;
                success = await task();
            }
            return success;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(Location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<GalleryImageResource> CreateGalleryImageAsync()
        {
            string galleryImageNamePrefix = "hci-dotnet-test-galleryimage-";
            string galleryImageName = Recording.GenerateAssetName(galleryImageNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            var data = new GalleryImageData(Location)
            {
                OSType = OperatingSystemType.Linux,
                ImagePath = "C:\\ClusterStorage\\Volume1\\test.vhdx",
                ExtendedLocation = extendedLocation,
            };
            var lro = await ResourceGroup.GetGalleryImages().CreateOrUpdateAsync(WaitUntil.Completed, galleryImageName, data);
            return lro.Value;
        }

        protected async Task<MarketplaceGalleryImageResource> CreateMarketplaceGalleryImageAsync()
        {
            string marketplaceGalleryImageNamePrefix = "hci-dotnet-test-marketplacegalleryimage-";
            string marketplaceGalleryImageName = Recording.GenerateAssetName(marketplaceGalleryImageNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            string publisher = "microsoftwindowsserver";
            string offer = "windowsserver";
            string sku = "2022-datacenter-azure-edition-core";
            string version = "20348.1850.230906";

            var data = new MarketplaceGalleryImageData(Location)
            {
                OSType = OperatingSystemType.Windows,
                ExtendedLocation = extendedLocation,
                Identifier = new GalleryImageIdentifier(publisher, offer, sku),
                Version = new GalleryImageVersion()
                {
                    Name = version,
                    StorageProfile = new GalleryImageVersionStorageProfile(),
                }
            };
            var lro = await ResourceGroup.GetMarketplaceGalleryImages().CreateOrUpdateAsync(WaitUntil.Completed, marketplaceGalleryImageName, data);
            return lro.Value;
        }

        protected async Task<LogicalNetworkResource> CreateLogicalNetworkAsync()
        {
            string logicalNetworkNamePrefix = "hci-dotnet-test-logicalnetwork-";
            string logicalNetworkName = Recording.GenerateAssetName(logicalNetworkNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            var data = new LogicalNetworkData(Location)
            {
                ExtendedLocation = extendedLocation,
                VmSwitchName = "testswitch"
            };

            var lro = await ResourceGroup.GetLogicalNetworks().CreateOrUpdateAsync(WaitUntil.Completed, logicalNetworkName, data);
            return lro.Value;
        }

        protected async Task<VirtualHardDiskResource> CreateVirtualHardDiskAsync()
        {
            string virtualHardDiskNamePrefix = "hci-dotnet-virtualharddisk-";
            string virtualHardDiskName = Recording.GenerateAssetName(virtualHardDiskNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            var data = new VirtualHardDiskData(Location)
            {
                ExtendedLocation = extendedLocation,
                DiskSizeGB = 2,
                Dynamic = true,
            };

            var lro = await ResourceGroup.GetVirtualHardDisks().CreateOrUpdateAsync(WaitUntil.Completed, virtualHardDiskName, data);
            return lro.Value;
        }

        protected async Task<NetworkInterfaceResource> CreateNetworkInterfaceAsync(string subnetId)
        {
            string networkInterfaceNamePrefix = "hci-dotnet-networkinterface-";
            string networkInterfaceName = Recording.GenerateAssetName(networkInterfaceNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            var data = new NetworkInterfaceData(Location)
            {
                ExtendedLocation = extendedLocation,
            };
            data.IPConfigurations.Add(new IPConfiguration()
            {
                Properties = new IPConfigurationProperties()
                {
                    SubnetId = new ResourceIdentifier(subnetId),
                }
            });

            var lro = await ResourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, data);
            return lro.Value;
        }

        protected async Task<StorageContainerResource> CreateStorageContainerAsync()
        {
            string storageContainerNamePrefix = "hci-dotnet-storagecontainer-";
            string storageContainerName = Recording.GenerateAssetName(storageContainerNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            var data = new StorageContainerData(Location)
            {
                ExtendedLocation = extendedLocation,
                Path = "C:\\ClusterStorage\\Volume1\\sc-dotnet-test",
            };

            var lro = await ResourceGroup.GetStorageContainers().CreateOrUpdateAsync(WaitUntil.Completed, storageContainerName, data);
            return lro.Value;
        }

        protected async Task<VirtualMachineInstanceResource> CreateVirtualMachineInstanceAsync()
        {
            string virtualMachineInstanceNamePrefix = "hci-dotnet-vm-";
            string virtualMachineInstanceName = Recording.GenerateAssetName(virtualMachineInstanceNamePrefix);
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            // creation of hybridcompute machine required as a prereq
            HybridComputeMachineData hcData = new HybridComputeMachineData(Location)
            {
                Identity = new ResourceManager.Models.ManagedServiceIdentity("SystemAssigned"),
                LocationData = new LocationData("Redmond"),
                VmId = Guid.NewGuid(),
                ClientPublicKey = "string",
            };

            await ResourceGroup.GetHybridComputeMachines().CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineInstanceName, hcData);

            // creation of nic, galleryimage, and storagepath as a prereq
            var lnet = await CreateLogicalNetworkAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(lnet), TimeSpan.FromSeconds(100));
            Assert.AreEqual(lnet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var nic = await CreateNetworkInterfaceAsync(lnet.Id);
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(nic), TimeSpan.FromSeconds(100));
            Assert.AreEqual(nic.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var image = await CreateMarketplaceGalleryImageAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(image), TimeSpan.FromSeconds(3000));
            Assert.AreEqual(image.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var sc = await CreateStorageContainerAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(sc), TimeSpan.FromSeconds(100));
            Assert.AreEqual(sc.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var data = new VirtualMachineInstanceData()
            {
                ExtendedLocation = extendedLocation,
                OSProfile = new VirtualMachineInstancePropertiesOSProfile()
                {
                    AdminPassword = "password",
                    AdminUsername = "localadmin",
                    ComputerName = "dotnetvm",
                },
                StorageProfile = new VirtualMachineInstancePropertiesStorageProfile()
                {
                    ImageReferenceId = image.Id,
                    VmConfigStoragePathId = sc.Id,
                },
                NetworkProfile = new VirtualMachineInstancePropertiesNetworkProfile(),
                HardwareProfile = new VirtualMachineInstancePropertiesHardwareProfile()
                {
                    VmSize = VmSizeEnum.Default,
                },
                SecurityProfile = new VirtualMachineInstancePropertiesSecurityProfile()
                {
                    EnableTPM = false,
                    SecureBootEnabled = false,
                },
            };
            data.NetworkProfile.NetworkInterfaces.Add(new WritableSubResource()
            {
                Id = nic.Id,
            });

            string resourceUri = $"/subscriptions/{DefaultSubscription}/resourceGroups/{ResourceGroup.Id}/Microsoft.HybridCompute/machines/{virtualMachineInstanceName}";
            ResourceIdentifier virtualMachineInstanceResourceId = VirtualMachineInstanceResource.CreateResourceIdentifier(resourceUri);
            VirtualMachineInstanceResource virtualMachineInstance = Client.GetVirtualMachineInstanceResource(virtualMachineInstanceResourceId);
            var lro = await virtualMachineInstance.CreateOrUpdateAsync(WaitUntil.Completed, data);
            return lro.Value;
        }

        public async Task<bool> ProvisioningStateSucceeded(GalleryImageResource galleryImage)
        {
            GalleryImageResource galleryImageFromGet = await galleryImage.GetAsync();
            if (galleryImageFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(MarketplaceGalleryImageResource marketplaceMarketplaceGalleryImage)
        {
            MarketplaceGalleryImageResource marketplaceMarketplaceGalleryImageFromGet = await marketplaceMarketplaceGalleryImage.GetAsync();
            if (marketplaceMarketplaceGalleryImageFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(NetworkInterfaceResource networkInterface)
        {
            NetworkInterfaceResource networkInterfaceFromGet = await networkInterface.GetAsync();
            if (networkInterfaceFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(LogicalNetworkResource logicalNetwork)
        {
            LogicalNetworkResource logicalNetworkFromGet = await logicalNetwork.GetAsync();
            if (logicalNetworkFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(VirtualHardDiskResource virtualHardDisk)
        {
            VirtualHardDiskResource virtualHardDiskFromGet = await virtualHardDisk.GetAsync();
            if (virtualHardDiskFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(StorageContainerResource storageContainer)
        {
            StorageContainerResource storageContainerFromGet = await storageContainer.GetAsync();
            if (storageContainerFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> ProvisioningStateSucceeded(VirtualMachineInstanceResource virtualMachineInstance)
        {
            VirtualMachineInstanceResource virtualMachineInstanceFromGet = await virtualMachineInstance.GetAsync();
            if (virtualMachineInstanceFromGet.Data.ProvisioningState == ProvisioningStateEnum.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
