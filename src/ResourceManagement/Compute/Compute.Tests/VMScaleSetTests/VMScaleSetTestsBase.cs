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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetTestsBase : VMTestBase
    {
        protected VirtualMachineScaleSetExtension GetTestVMSSVMExtension()
        {
            var vmExtension = new VirtualMachineScaleSetExtension
            {
                Name = "vmssext01",
                Publisher = "Microsoft.Compute",
                Type = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                Settings = "{}",
                ProtectedSettings = "{}"
            };

            return vmExtension;
        }
        protected VirtualMachineScaleSet CreateDefaultVMScaleSetInput(string rgName, string storageAccountName, ImageReference imageRef, string subnetId)
        {
            // Generate Container name to hold disk VHds
            string containerName = TestUtilities.GenerateName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vmssName = TestUtilities.GenerateName("vmss");

            return new VirtualMachineScaleSet()
            {
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                Sku = new Sku()
                {
                    Capacity = 2,
                    Name = VirtualMachineSizeTypes.StandardA0,
                },
                OverProvision = false,
                UpgradePolicy = new UpgradePolicy()
                {
                    Mode = UpgradeMode.Automatic
                },
                VirtualMachineProfile = new VirtualMachineScaleSetVMProfile()
                {
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        ImageReference = imageRef,
                        OsDisk = new VirtualMachineScaleSetOSDisk
                        {
                            Caching = CachingTypes.None,
                            CreateOption = DiskCreateOptionTypes.FromImage,
                            Name = "test",
                            VhdContainers = new List<string> { vhdContainer }
                        },
                    },
                    OsProfile = new VirtualMachineScaleSetOSProfile()
                    {
                        ComputerNamePrefix = "test",
                        AdminUsername = "Foo12",
                        AdminPassword = "BaR@123" + rgName,
                        CustomData = Convert.ToBase64String(Encoding.UTF8.GetBytes("Custom data"))
                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile()
                    {
                        NetworkInterfaceConfigurations = new List<VirtualMachineScaleSetNetworkConfiguration>()
                        {
                            new VirtualMachineScaleSetNetworkConfiguration()
                            {
                                Name = TestUtilities.GenerateName("vmsstestnetconfig"),
                                Primary = true,
                                IpConfigurations = new List<VirtualMachineScaleSetIPConfiguration>
                                {
                                    new VirtualMachineScaleSetIPConfiguration()
                                    {
                                        Name = TestUtilities.GenerateName("vmsstestnetconfig"),
                                        Subnet = new Microsoft.Azure.Management.Compute.Models.ApiEntityReference()
                                        {
                                            Id = subnetId
                                        },
                                        ApplicationGatewayBackendAddressPools = new List<Microsoft.Azure.Management.Compute.Models.SubResource>(),
                                    }
                                }
                            }
                        }
                    },
                    ExtensionProfile = new VirtualMachineScaleSetExtensionProfile(),
                }
            };
        }

        protected VirtualMachineScaleSet CreateVMScaleSet_NoAsyncTracking(
            string rgName,
            string vmssName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            out VirtualMachineScaleSet inputVMScaleSet,
            VirtualMachineScaleSetExtensionProfile extensionProfile = null,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
            bool createWithPublicIpAddress = false,
            Subnet subnet = null)
        {
            try
            {
                var createOrUpdateResponse = CreateVMScaleSetAndGetOperationResponse(rgName,
                                                                                     vmssName,
                                                                                     storageAccount,
                                                                                     imageRef,
                                                                                     out inputVMScaleSet,
                                                                                     extensionProfile,
                                                                                     vmScaleSetCustomizer,
                                                                                     createWithPublicIpAddress,
                                                                                     subnet);

                var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);

                return getResponse;
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(rgName);
                throw;
            }
        }

        protected VirtualMachineScaleSet CreateVMScaleSet(
            string rgName,
            string vmssName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            out VirtualMachineScaleSet inputVMScaleSet,
            VirtualMachineScaleSetExtensionProfile extensionProfile = null,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
            bool createWithPublicIpAddress = false)
        {
            try
            {
                var createOrUpdateResponse = CreateVMScaleSetAndGetOperationResponse(
                    rgName, vmssName, storageAccount, imageRef, out inputVMScaleSet, extensionProfile, vmScaleSetCustomizer);

                var lroResponse = m_CrpClient.VirtualMachineScaleSets.CreateOrUpdate(rgName, inputVMScaleSet.Name, inputVMScaleSet);

                var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, inputVMScaleSet.Name);

                return getResponse;
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(rgName);
                throw;
            }
        }

        protected void UpdateVMScaleSet(string rgName, string vmssName, VirtualMachineScaleSet inputVMScaleSet)
        {
            var createOrUpdateResponse = m_CrpClient.VirtualMachineScaleSets.CreateOrUpdate(rgName, vmssName, inputVMScaleSet);
        }

        private VirtualMachineScaleSet CreateVMScaleSetAndGetOperationResponse(
            string rgName,
            string vmssName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            out VirtualMachineScaleSet inputVMScaleSet,
            VirtualMachineScaleSetExtensionProfile extensionProfile = null,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
            bool createWithPublicIpAddress = false,
            Subnet subnet = null)
        {
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = m_location
                });

            var getPublicIpAddressResponse = createWithPublicIpAddress ? null : CreatePublicIP(rgName);

            var subnetResponse = subnet ?? CreateVNET(rgName);

            var nicResponse = CreateNIC(
                rgName,
                subnetResponse,
                getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

            inputVMScaleSet = CreateDefaultVMScaleSetInput(rgName, storageAccount.Name, imageRef, subnetResponse.Id);
            if (vmScaleSetCustomizer != null)
            {
                vmScaleSetCustomizer(inputVMScaleSet);
            }

            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

            var createOrUpdateResponse = m_CrpClient.VirtualMachineScaleSets.CreateOrUpdate(rgName, vmssName, inputVMScaleSet);

            Assert.True(createOrUpdateResponse.Name == vmssName);
            Assert.True(createOrUpdateResponse.Location.ToLower() == inputVMScaleSet.Location.ToLower().Replace(" ", ""));

            ValidateVMScaleSet(inputVMScaleSet, createOrUpdateResponse);

            return createOrUpdateResponse;
        }


        protected void ValidateVMScaleSetInstanceView(VirtualMachineScaleSet vmScaleSet,
            VirtualMachineScaleSetInstanceView vmScaleSetInstanceView)
        {
            Assert.NotNull(vmScaleSetInstanceView.Statuses);
            Assert.NotNull(vmScaleSetInstanceView);
            // TODO: AutoRest
            Assert.NotNull(vmScaleSetInstanceView.Extensions);
            int instancesCount = vmScaleSetInstanceView.Extensions.Sum(statusSummary => statusSummary.StatusesSummary.Sum(t => t.Count.Value));
            Assert.True(instancesCount >= vmScaleSet.Sku.Capacity);
        }

        protected void ValidateVMScaleSet(VirtualMachineScaleSet vmScaleSet, VirtualMachineScaleSet vmScaleSetOut)
        {
            Assert.True(!string.IsNullOrEmpty(vmScaleSetOut.ProvisioningState));

            Assert.True(vmScaleSetOut.Sku.Name
                     == vmScaleSet.Sku.Name);

            Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk);

            Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Name
                     == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Name);

            if (vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image != null)
            {
                Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Image.Uri
                            == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image.Uri);
            }

            Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Caching
                     == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Caching);

            if (vmScaleSet.VirtualMachineProfile.OsProfile.Secrets != null &&
               vmScaleSet.VirtualMachineProfile.OsProfile.Secrets.Any())
            {
                foreach (var secret in vmScaleSet.VirtualMachineProfile.OsProfile.Secrets)
                {
                    Assert.NotNull(secret.VaultCertificates);
                    var secretOut = vmScaleSetOut.VirtualMachineProfile.OsProfile.Secrets.FirstOrDefault(s => string.Equals(secret.SourceVault.Id, s.SourceVault.Id));
                    Assert.NotNull(secretOut);

                    // Disabling resharper null-ref check as it doesn't seem to understand the not-null assert above.
                    // ReSharper disable PossibleNullReferenceException

                    Assert.NotNull(secretOut.VaultCertificates);
                    var VaultCertComparer = new VaultCertComparer();
                    Assert.True(secretOut.VaultCertificates.SequenceEqual(secret.VaultCertificates, VaultCertComparer));

                    // ReSharper enable PossibleNullReferenceException
                }
            }

            if (vmScaleSet.VirtualMachineProfile.ExtensionProfile != null &&
                vmScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions.Any())
            {
                foreach (var vmExtension in vmScaleSet.VirtualMachineProfile.ExtensionProfile.Extensions)
                {
                    var vmExt = vmScaleSetOut.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(s => String.Compare(s.Name, vmExtension.Name, StringComparison.OrdinalIgnoreCase) == 0);
                    Assert.NotNull(vmExt);
                }
            }

            if (vmScaleSet.VirtualMachineProfile.NetworkProfile != null)
            {
                if (vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations != null && vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Count > 0)
                {
                    Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations);
                    Assert.Equal(
                        vmScaleSetOut.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Count,
                        vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Count);

                    foreach (var nicconfig in vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations)
                    {
                        var outnicconfig =
                            vmScaleSetOut.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.First(
                                nc => string.Equals(nc.Name, nicconfig.Name, StringComparison.OrdinalIgnoreCase));
                        Assert.NotNull(outnicconfig);
                        CompareVmssNicConfig(nicconfig, outnicconfig);
                    }
                }
            }
            else
            {
                Assert.True((vmScaleSetOut.VirtualMachineProfile.NetworkProfile == null) || (vmScaleSetOut.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Count == 0));
            }
        }

        protected void CompareVmssNicConfig(VirtualMachineScaleSetNetworkConfiguration nicconfig,
            VirtualMachineScaleSetNetworkConfiguration outnicconfig)
        {
            if (nicconfig.IpConfigurations != null && nicconfig.IpConfigurations.Count > 0)
            {
                Assert.NotNull(outnicconfig.IpConfigurations);

                Assert.Equal(nicconfig.IpConfigurations.Count, outnicconfig.IpConfigurations.Count);

                foreach (var ipconfig in nicconfig.IpConfigurations)
                {
                    var outipconfig =
                        outnicconfig.IpConfigurations.First(
                            ic => string.Equals(ic.Name, ipconfig.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(outipconfig);
                    CompareIpConfigApplicationGatewayPools(ipconfig, outipconfig);
                }
            }
            else
            {
                Assert.True((outnicconfig.IpConfigurations == null) || (outnicconfig.IpConfigurations.Count == 0));
            }
        }

        protected void CompareIpConfigApplicationGatewayPools(VirtualMachineScaleSetIPConfiguration ipconfig, VirtualMachineScaleSetIPConfiguration outipconfig)
        {
            if (ipconfig.ApplicationGatewayBackendAddressPools != null && ipconfig.ApplicationGatewayBackendAddressPools.Count > 0)
            {
                Assert.NotNull(outipconfig.ApplicationGatewayBackendAddressPools);

                Assert.Equal(ipconfig.ApplicationGatewayBackendAddressPools.Count,
                    outipconfig.ApplicationGatewayBackendAddressPools.Count);

                foreach (var pool in ipconfig.ApplicationGatewayBackendAddressPools)
                {
                    var outPool =
                        outipconfig.ApplicationGatewayBackendAddressPools.First(
                            p => string.Equals(p.Id, pool.Id, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(outPool);
                }
            }
            else
            {
                Assert.True((outipconfig.ApplicationGatewayBackendAddressPools == null) || (outipconfig.ApplicationGatewayBackendAddressPools.Count == 0));
            }
        }
    }
}
