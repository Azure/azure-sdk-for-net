// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExtendedLocation = Azure.ResourceManager.Hci.Models.ArcVmExtendedLocation;
using ExtendedLocationType = Azure.ResourceManager.Hci.Models.ArcVmExtendedLocationType;

namespace Azure.ResourceManager.Hci.Tests
{
    public class HciManagementTestBase : ManagementRecordedTestBase<HciManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected string CustomLocationId { get; private set; }

        protected AzureLocation Location { get; private set; }

        protected ResourceGroupResource ResourceGroup { get; private set; }

        protected HciManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HciManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            var rgPrefix = "hci-dotnet-test-rg-";
            Location = AzureLocation.EastUS;
            ResourceGroup = await CreateResourceGroupAsync(Subscription, rgPrefix, Location);
            CustomLocationId = TestEnvironment.CustomLocationId;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<HciClusterResource> CreateHciClusterAsync(ResourceGroupResource resourceGroup, string clusterName, AzureLocation? location = null)
        {
            var clusterData = new HciClusterData(location == null ? resourceGroup.Data.Location : location.Value)
            {
                AadClientId = new Guid(TestEnvironment.ClientId),
                AadTenantId = new Guid(TestEnvironment.TenantId),
                TypeIdentityType = HciManagedServiceIdentityType.None
            };
            var lro = await resourceGroup.GetHciClusters().CreateOrUpdateAsync(WaitUntil.Completed, clusterName, clusterData);
            return lro.Value;
        }

        protected async Task<ArcSettingResource> CreateArcSettingAsync(HciClusterResource cluster, string arcSettingName)
        {
            var arcSettingData = new ArcSettingData();
            var lro = await cluster.GetArcSettings().CreateOrUpdateAsync(WaitUntil.Completed, arcSettingName, arcSettingData);
            return lro.Value;
        }

        protected async Task<ArcExtensionResource> CreateArcExtensionAsync(ArcSettingResource arcSetting, string arcExtensionName)
        {
            var arcExtensionData = new ArcExtensionData()
            {
                ArcExtensionType = "MicrosoftMonitoringAgent",
                Publisher = "Microsoft",
                TypeHandlerVersion = "1.10",
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "workspaceId", "5dcf9bc1-c220-4ed6-84f3-6919c3a393b6" }
                }),
                ProtectedSettings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "workspaceKey", "5dcf9bc1-c220-4ed6-84f3-6919c3a393b6" }
                })
            };
            var lro = await arcSetting.GetArcExtensions().CreateOrUpdateAsync(WaitUntil.Completed, arcExtensionName, arcExtensionData);
            return lro.Value;
        }

        public async Task<bool> RetryUntilSuccessOrTimeout(Func<Task<bool>> task, TimeSpan timeSpan)
        {
            bool success = false;
            int elapsed = 0;
            int frequency = 5000;
            while (!success && elapsed < timeSpan.TotalMilliseconds)
            {
                await Delay(frequency, null);
                elapsed += frequency;
                success = await task();
            }
            return success;
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
                ImagePath = TestEnvironment.ImagePath,
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
            string version = "20348.2031.231006";

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
                Path = TestEnvironment.StoragePath,
            };

            var lro = await ResourceGroup.GetStorageContainers().CreateOrUpdateAsync(WaitUntil.Completed, storageContainerName, data);
            return lro.Value;
        }

        protected async Task<VirtualMachineInstanceResource> CreateVirtualMachineInstanceAsync()
        {
            var extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = ExtendedLocationType.CustomLocation,
            };

            // creation of hybridcompute machine assumed as a prereq since creation not allowed in sdk
            // as a result the vm will use the same rg as the hybridcompute machine
            // creation of nic and galleryimage as a prereq
            var lnet = await CreateLogicalNetworkAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(lnet), TimeSpan.FromSeconds(100));
            Assert.AreEqual(lnet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var nic = await CreateNetworkInterfaceAsync(lnet.Id);
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(nic), TimeSpan.FromSeconds(100));
            Assert.AreEqual(nic.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var image = await CreateMarketplaceGalleryImageAsync();
            await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(image), TimeSpan.FromSeconds(3000));
            Assert.AreEqual(image.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            var data = new VirtualMachineInstanceData()
            {
                ExtendedLocation = extendedLocation,
                OSProfile = new VirtualMachineInstancePropertiesOSProfile()
                {
                    AdminPassword = TestEnvironment.VmPass,
                    AdminUsername = TestEnvironment.VmUsername,
                    ComputerName = "dotnetvm",
                    WindowsConfiguration = new VirtualMachineInstancePropertiesOSProfileWindowsConfiguration()
                    {
                        ProvisionVmAgent = false,
                        EnableAutomaticUpdates = false,
                    },
                },
                StorageProfile = new VirtualMachineInstancePropertiesStorageProfile()
                {
                    ImageReferenceId = image.Id,
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
            data.NetworkProfile.NetworkInterfaces.Add(new Resources.Models.WritableSubResource()
            {
                Id = nic.Id,
            });
            string resourceUri = $"{Subscription.Id.ToString()}/resourceGroups/hci-dotnet-test-rg/providers/Microsoft.HybridCompute/machines/{TestEnvironment.MachineName}";

            // hybrid compute machine name distinguished depending on is async or not due to sdk not supporting machine creation at the moment.
            if (IsAsync)
            {
                resourceUri = $"{Subscription.Id.ToString()}/resourceGroups/hci-dotnet-test-rg/providers/Microsoft.HybridCompute/machines/{TestEnvironment.MachineNameAsync}";
            }
            ResourceIdentifier virtualMachineInstanceResourceId = VirtualMachineInstanceResource.CreateResourceIdentifier(resourceUri);
            VirtualMachineInstanceResource virtualMachineInstanceResource = Client.GetVirtualMachineInstanceResource(virtualMachineInstanceResourceId);
            var lro = await virtualMachineInstanceResource.CreateOrUpdateAsync(WaitUntil.Completed, data);
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
