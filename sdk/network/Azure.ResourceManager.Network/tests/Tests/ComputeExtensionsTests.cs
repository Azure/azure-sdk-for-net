// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class ComputeExtensionsTests : NetworkServiceClientTestBase
    {
        private const string _dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        public ComputeExtensionsTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task GetIPsForVmss()
        {
            var client = GetArmClient();
            var subscription = await client.GetDefaultSubscriptionAsync();
            var rg = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("rg-"), new ResourceGroupData(AzureLocation.WestUS));
            var collection = rg.Value.GetVirtualMachineScaleSets();
            var vmssName = Recording.GenerateAssetName("testVMSS-");
            var vnetData = new VirtualNetworkData();
            vnetData.AddressPrefixes.Add("10.0.0.0/16");
            vnetData.Location = AzureLocation.WestUS;
            var vnet = await rg.Value.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("vnet-"), vnetData);
            var subnetData = new SubnetData();
            subnetData.AddressPrefix = "10.0.2.0/24";
            subnetData.Name = Recording.GenerateAssetName("subnet-");
            var subnet = await vnet.Value.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetData.Name, subnetData);
            var input = GetBasicLinuxVirtualMachineScaleSetData(vmssName, subnet.Value.Id);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, vmssName, input);
            VirtualMachineScaleSetResource vmss = lro.Value;
            Assert.AreEqual(vmssName, vmss.Data.Name);

            VirtualMachineScaleSetExtensionResource vmssExtension = client.GetVirtualMachineScaleSetExtensionResource(vmss.Id);

            int count = 0;
            await foreach (var publicIPAddress in vmssExtension.GetAllPublicIPAddressesAsync())
            {
                count++;
            }
            Assert.Greater(count, 0);
        }

        public static VirtualMachineScaleSetData GetBasicLinuxVirtualMachineScaleSetData(string computerNamePrefix, ResourceIdentifier subnetId, int capacity = 2, string adminUsername = "adminuser")
        {
            var result = new VirtualMachineScaleSetData(AzureLocation.WestUS)
            {
                Sku = new ComputeSku()
                {
                    Name = "Standard_F2",
                    Capacity = capacity,
                    Tier = "Standard"
                },
                UpgradePolicy = new UpgradePolicy()
                {
                    Mode = UpgradeMode.Manual,
                },
                VirtualMachineProfile = new VirtualMachineScaleSetVmProfile()
                {
                    OSProfile = new VirtualMachineScaleSetOSProfile()
                    {
                        ComputerNamePrefix = computerNamePrefix,
                        AdminUsername = adminUsername,
                        LinuxConfiguration = new LinuxConfiguration()
                        {
                            DisablePasswordAuthentication = true,
                        }
                    },
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        OSDisk = new VirtualMachineScaleSetOSDisk(DiskCreateOptionTypes.FromImage)
                        {
                            Caching = CachingTypes.ReadWrite,
                            ManagedDisk = new VirtualMachineScaleSetManagedDiskParameters()
                            {
                                StorageAccountType = StorageAccountTypes.StandardLRS
                            }
                        },
                        ImageReference = new ImageReference()
                        {
                            Publisher = "Canonical",
                            Offer = "UbuntuServer",
                            Sku = "16.04-LTS",
                            Version = "latest"
                        }
                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile()
                    {
                        NetworkInterfaceConfigurations =
                        {
                            new VirtualMachineScaleSetNetworkConfiguration("example")
                            {
                                Primary = true,
                                IPConfigurations =
                                {
                                    new VirtualMachineScaleSetIPConfiguration("internal")
                                    {
                                        Primary = true,
                                        SubnetId = subnetId
                                    }
                                }
                            }
                        }
                    }
                }
            };
            result.VirtualMachineProfile.OSProfile.LinuxConfiguration.SshPublicKeys.Add(
                new SshPublicKeyInfo()
                {
                    Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                    KeyData = _dummySSHKey
                });
            return result;
        }
    }
}
