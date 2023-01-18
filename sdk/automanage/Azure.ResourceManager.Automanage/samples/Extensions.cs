using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Automanage;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace AutoManageTest
{
    public static class Extensions
    {
        public static async Task<VirtualMachineResource> CreateVM(this SubscriptionResource sub, string resourceGroup, string computerName)
        {
            var rgCollection = sub.GetResourceGroups();
            ResourceGroupResource targetGroup;

            try
            {
                targetGroup = await rgCollection.GetAsync(resourceGroup);
                Console.WriteLine($"[ResourceGroup-Creation]--Found previous RG, {resourceGroup}");
            }
            catch (Exception ex)
            {
                AzureLocation location = AzureLocation.WestUS2;
                var l = rgCollection.CreateOrUpdate(WaitUntil.Completed, resourceGroup, new ResourceGroupData(location));
                Console.WriteLine("[ResourceGroup-Creation]--Need to create ResourceGroup");
            }
            finally
            {
                targetGroup = await rgCollection.GetAsync(resourceGroup);
                Console.WriteLine("[ResourceGroup-Creation]--Created");
            }

            var vmCollection = targetGroup.GetVirtualMachines();

            try
            {
                var vm2 = await vmCollection.GetAsync(computerName);
                Console.WriteLine("[VirtualMachine-Creation]--VM Already existed, no need to create one for this run");
                return vm2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[VirtualMachine-Creation]--Need to create VM");
            }

            var nic = await targetGroup.CreateNicIfNotExistsAsync(computerName);

            // Use the same location as the resource group
            VirtualMachineData input = new VirtualMachineData(targetGroup.Data.Location)
            {
                HardwareProfile = new VirtualMachineHardwareProfile()
                {
                    VmSize = VirtualMachineSizeType.StandardF2
                },
                OSProfile = new VirtualMachineOSProfile()
                {
                    AdminUsername = "adminUser",
                    AdminPassword = "@pPAaaW@220rd!",
                    ComputerName = computerName,
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = false,
                    }
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                      nic
                    }
                },
                StorageProfile = new VirtualMachineStorageProfile()
                {
                    OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Linux,
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new VirtualMachineManagedDisk()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs
                        }
                    },
                    ImageReference = new ImageReference()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };

            ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, computerName, input);
            VirtualMachineResource vm = lro.Value;

            Console.WriteLine("[VirtualMachine-Creation]--CreationCompleted");

            return vm;
        }

        public static async Task<VirtualMachineNetworkInterfaceReference> CreateNicIfNotExistsAsync(this ResourceGroupResource resourceGroup, string virtualMachineName)
        {
            var networkInterfaceName = virtualMachineName + "_nic";

            NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();

            try
            {
                var l = await networkInterfaces.GetAsync(networkInterfaceName);
                Console.WriteLine("[VirtualMachine-NICCreation]--Found previous NIC, reusing");
                return l.Value.ToVmNicReference(); ;
            }
            catch
            {
                Console.WriteLine("[VirtualMachine-NICCreation]--Need to create NIC, continuing");
            }

            var networkGroup = await resourceGroup.CreateVirtualNetworksIfNotExistsAsync(virtualMachineName);
            var subnet = networkGroup.GetSubnets().FirstOrDefault().Id;

            NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new SubnetData() { Id = subnet },
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
            };

            NetworkInterfaceData nicData = new NetworkInterfaceData();
            nicData.Location = AzureLocation.WestUS2;
            nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
            var networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);

            return networkInterfaceOperation.Value.ToVmNicReference();
        }

        public static async Task<VirtualNetworkResource> CreateVirtualNetworksIfNotExistsAsync(this ResourceGroupResource resourceGroup, string virtualMachineName)
        {
            var networkGroups = resourceGroup.GetVirtualNetworks();
            var targetName = $"{virtualMachineName}_netwrk";

            if (networkGroups.Count() != 0)
            {
                Console.Write("[NetworkGroup--Creation]--Network groups exist, using the first one");
                return networkGroups.FirstOrDefault();
            }

            Console.WriteLine("[NetworkGroup--Creation]--Need to create a virtual network");
            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
            {
                Location = AzureLocation.WestUS2,
                Subnets =
            {
                new SubnetData()
                {
                    Name = targetName,
                    AddressPrefix = "10.0.0.0/24"
                }
            }
            };

            virtualNetworkData.AddressPrefixes.Add("10.0.0.0/16");
            var virtualNetworkOperation = await networkGroups.CreateOrUpdateAsync(WaitUntil.Completed, targetName, virtualNetworkData);
            var virtualNetwork = virtualNetworkOperation.Value;

            return virtualNetwork;
        }

        public static VirtualMachineNetworkInterfaceReference ToVmNicReference(this NetworkInterfaceResource networkInterfaceResource)
        {
            var vmNicReference = new VirtualMachineNetworkInterfaceReference()
            {
                Id = networkInterfaceResource.Id
            };

            return vmNicReference;
        }

        public static async Task<ConfigurationProfileAssignmentResource> CreateAssignment(this ArmClient client, ResourceIdentifier vmId, string profileId)
        {
            Console.WriteLine($"[AutoManage-Onboarding]--Onboarding with profile, {profileId}");

            var collection = client.GetConfigurationProfileAssignments(vmId);

            var data = new ConfigurationProfileAssignmentData();
            data.Properties = new ConfigurationProfileAssignmentProperties() { ConfigurationProfile = profileId };

            var assignment = await collection.CreateOrUpdateAsync(WaitUntil.Completed, "default", data);

            return assignment.Value;
        }

        public static async Task<ConfigurationProfileAssignmentResource> WaitAssignmentCompleted(this ArmClient client, ResourceIdentifier vmId)
        {
            var assignmentName = string.Concat(vmId, "/providers/Microsoft.Automanage/configurationProfileAssignments/default");
            var shouldWaitStates = new[] { "InProgress", "New" };

            Console.WriteLine($"[AutoManage-Onboarding]--Waiting for completed onboarding with profile, {vmId}");

            var collection = client.GetConfigurationProfileAssignments(vmId.Parent);
            var thisAssignment = collection.FirstOrDefault(x => x.Data.Id.ToString() == assignmentName);

            while (shouldWaitStates.Contains(thisAssignment.GetStatus()))
            {
                Console.WriteLine($"--Status was {thisAssignment.GetStatus()}, waiting for completed status");
                await Task.Delay(TimeSpan.FromSeconds(25));

                collection = client.GetConfigurationProfileAssignments(vmId.Parent);
                thisAssignment = collection.FirstOrDefault(x => x.Data.Id.ToString() == assignmentName);
            }

            Console.WriteLine($"[AutoManage-Onboarding]--Final assignment status for this VM was {thisAssignment.GetStatus()}");

            return thisAssignment;
        }

        public static string GetStatus(this ConfigurationProfileAssignmentResource resource) => resource.Data.Properties.Status;
    }
}