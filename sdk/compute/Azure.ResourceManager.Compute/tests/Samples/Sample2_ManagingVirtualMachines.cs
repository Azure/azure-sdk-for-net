// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_VirtualMachines_Namespaces
using System;
using System.Threading.Tasks;
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
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            // Use the same location as the resource group
            string vmName = "myVM";
            var input = new VirtualMachineData(resourceGroup.Data.Location)
            {
                HardwareProfile = new HardwareProfile()
                {
                    VmSize = VirtualMachineSizeTypes.StandardF2
                },
                OsProfile = new OSProfile()
                {
                    AdminUsername = "adminUser",
                    ComputerName = "myVM",
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = true,
                        Ssh = new SshConfiguration()
                        {
                            PublicKeys = {
                    new SshPublicKeyInfo()
                    {
                        Path = $"/home/adminUser/.ssh/authorized_keys",
                        KeyData = "<value of the public ssh key>",
                    }
                }
                        }
                    }
                },
                NetworkProfile = new NetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new NetworkInterfaceReference()
                        {
                            Id = "/subscriptions/<subscriptionId>/resourceGroups/<rgName>/providers/Microsoft.Network/networkInterfaces/<nicName>",
                            Primary = true,
                        }
                    }
                },
                StorageProfile = new StorageProfile()
                {
                    OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                    {
                        OsType = OperatingSystemTypes.Linux,
                        Caching = CachingTypes.ReadWrite,
                        ManagedDisk = new ManagedDiskParameters()
                        {
                            StorageAccountType = StorageAccountTypes.StandardLRS
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
            VirtualMachineCreateOrUpdateOperation lro = await vmCollection.CreateOrUpdateAsync(vmName, input);
            VirtualMachine vm = lro.Value;
            #endregion Snippet:Managing_VirtualMachines_CreateAVirtualMachine
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListAllVirtualMachines()
        {
            #region Snippet:Managing_VirtualMachines_ListAllVirtualMachines
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            // With ListAsync(), we can get a list of the virtual machines
            AsyncPageable<VirtualMachine> response = vmCollection.GetAllAsync();
            await foreach (VirtualMachine vm in response)
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
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            // first we need to get the resource group
            string rgName = "myRgName";
            ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);
            // Now we get the virtual machine collection from the resource group
            VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
            string vmName = "myVM";
            VirtualMachine vm = await vmCollection.GetAsync(vmName);
            await vm.DeleteAsync();
            #endregion Snippet:Managing_VirtualMachines_DeleteVirtualMachine
        }
    }
}
