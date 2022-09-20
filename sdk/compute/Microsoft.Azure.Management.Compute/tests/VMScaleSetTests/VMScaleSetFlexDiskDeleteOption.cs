// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetFlexDiskDeleteOptionTests : VMScaleSetTestsBase
    {
        [Fact]
        [Trait("Name", "TestVmssFlexDeleteOptionForDisks")]
        public void TestVmssFlexDeleteOptionForDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Hard code the location to "eastus2euap" while feature rolls out to all PROD regions
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                var dnsname = TestUtilities.GenerateName("dnsname");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vnetResponse = CreateVNETWithSubnets(rgName, 2);
                    var vmssSubnet = vnetResponse.Subnets[1];

                    var publicipConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration();
                    publicipConfiguration.Name = "pip1";
                    publicipConfiguration.IdleTimeoutInMinutes = 10;

                    VirtualMachineScaleSetOSDisk osDisk = new VirtualMachineScaleSetOSDisk
                    {
                        Caching = CachingTypes.None,
                        CreateOption = DiskCreateOptionTypes.FromImage,
                        DeleteOption = DiskDeleteOptionTypes.Detach,
                    };

                    VirtualMachineScaleSetDataDisk dataDisk = new VirtualMachineScaleSetDataDisk
                    {
                        Lun = 1,
                        CreateOption = DiskCreateOptionTypes.Empty,
                        DeleteOption = DiskDeleteOptionTypes.Detach,
                        DiskSizeGB = 128,
                    };

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: null,
                        imageRef: imageRef,
                        inputVMScaleSet: out inputVMScaleSet,
                        singlePlacementGroup: false,
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        subnet: vmssSubnet,
                        vmScaleSetCustomizer:
                            (virtualMachineScaleSet) => {
                                virtualMachineScaleSet.UpgradePolicy = null;
                                virtualMachineScaleSet.Overprovision = null;
                                virtualMachineScaleSet.PlatformFaultDomainCount = 1;
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkApiVersion = NetworkApiVersion.TwoZeroTwoZeroHyphenMinusOneOneHyphenMinusZeroOne;
                                virtualMachineScaleSet.VirtualMachineProfile.NetworkProfile
                                    .NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicipConfiguration;
                                virtualMachineScaleSet.OrchestrationMode = OrchestrationMode.Flexible.ToString();
                                virtualMachineScaleSet.VirtualMachineProfile.StorageProfile.OsDisk = osDisk;
                                virtualMachineScaleSet.VirtualMachineProfile.StorageProfile.DataDisks = new List<VirtualMachineScaleSetDataDisk> { dataDisk };
                                }
                            );

                    Assert.Equal(DiskDeleteOptionTypes.Detach, vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.DeleteOption);

                    foreach (VirtualMachineScaleSetDataDisk disk in vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks)
                    {
                        Assert.Equal(DiskDeleteOptionTypes.Detach, disk.DeleteOption);
                    }
                    passed = true;
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}
