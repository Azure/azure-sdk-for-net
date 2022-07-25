// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_VirtualMachines_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
#endregion Snippet:Managing_VirtualMachines_Namespaces

namespace Azure.ResourceManager.Compute.Tests.Samples
{
    public class Sample2_ManagingVirtualMachines
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateVirtualMachine()
        {
            #region Snippet:Managing_VirtualMachines_CreateAVirtualMachine
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            // Use the same location as the resource group
            string vmName = "myVM";
            VirtualMachineData input = new VirtualMachineData(resourceGroup.Data.Location)
            {
                HardwareProfile = new VirtualMachineHardwareProfile()
                {
                    VmSize = VirtualMachineSizeType.StandardF2
                },
                OSProfile = new VirtualMachineOSProfile()
                {
                    AdminUsername = "adminUser",
                    ComputerName = "myVM",
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = true,
                        SshPublicKeys = {
                            new SshPublicKeyConfiguration()
                            {
                                Path = $"/home/adminUser/.ssh/authorized_keys",
                                KeyData = "<value of the public ssh key>",
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
                            Id = new ResourceIdentifier("/subscriptions/<subscriptionId>/resourceGroups/<rgName>/providers/Microsoft.Network/networkInterfaces/<nicName>"),
                            Primary = true,
                        }
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
            ArmOperation<VirtualMachineResource> lro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, input);
            VirtualMachineResource vm = lro.Value;
            #endregion Snippet:Managing_VirtualMachines_CreateAVirtualMachine
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllVirtualMachines()
        {
            #region Snippet:Managing_VirtualMachines_ListAllVirtualMachines
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            // With ListAsync(), we can get a list of the virtual machines
            AsyncPageable<VirtualMachineResource> response = vmCollection.GetAllAsync();
            await foreach (VirtualMachineResource vm in response)
            {
                Console.WriteLine(vm.Data.Name);
            }
            #endregion Snippet:Managing_VirtualMachines_ListAllVirtualMachines
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteVirtualMachine()
        {
            #region Snippet:Managing_VirtualMachines_DeleteVirtualMachine
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            string vmName = "myVM";
            VirtualMachineResource vm = await vmCollection.GetAsync(vmName);
            await vm.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_VirtualMachines_DeleteVirtualMachine
        }
    }
}
