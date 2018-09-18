// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;
using CM = Microsoft.Azure.Management.Compute.Models;

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

        protected VirtualMachineScaleSetExtension GetVmssServiceFabricExtension()
        {
            VirtualMachineScaleSetExtension sfExtension = new VirtualMachineScaleSetExtension
            {
                Name = "vmsssfext01",
                Publisher = "Microsoft.Azure.ServiceFabric",
                Type = "ServiceFabricNode",
                TypeHandlerVersion = "1.0",
                AutoUpgradeMinorVersion = true,
                Settings = "{}",
                ProtectedSettings = "{}"
            };

            return sfExtension;
        }

        protected VirtualMachineScaleSetExtension GetAzureDiskEncryptionExtension()
        {
            // NOTE: Replace dummy values for AAD credentials and KeyVault urls below by running DiskEncryptionPreRequisites.ps1.
            // There is no ARM client implemented for key-vault in swagger test framework yet. These changes need to go sooner to
            // unblock powershell cmdlets/API for disk encryption on scale set. So recorded this test by creating required resources
            // in prod and replaced them with dummy value before check-in.
            //
            // Follow below steps to run this test again:
            //   Step 1: Execute DiskEncryptionPreRequisites.ps1. Use same subscription and region as you are running test in.
            //   Step 2: Replace aadClientId, aadClientSecret, keyVaultUrl, and keyVaultId values below with the values returned
            //           by above PS script
            //   Step 3: Run test and record session
            //   Step 4: Delete KeyVault, AAD app created by above PS script
            //   Step 5: Replace values for AAD credentials and KeyVault urls by dummy values before check-in
            string aadClientId = Guid.NewGuid().ToString();
            string aadClientSecret = Guid.NewGuid().ToString();
            string keyVaultUrl = "https://adetestkv1.vault.azure.net/";
            string keyVaultId =
                "/subscriptions/d0d8594d-65c5-481c-9a58-fea6f203f1e2/resourceGroups/adetest/providers/Microsoft.KeyVault/vaults/adetestkv1";

            string settings =
                string.Format("\"AADClientID\": \"{0}\", \"KeyVaultURL\": \"{1}\", \"KeyEncryptionKeyURL\": \"\", \"KeyVaultResourceId\":\"{2}\", \"KekVaultResourceId\": \"\", \"KeyEncryptionAlgorithm\": \"{3}\", \"VolumeType\": \"{4}\", \"EncryptionOperation\": \"{5}\"",
                                aadClientId, keyVaultUrl, keyVaultId, "", "All", "DisableEncryption");

            string protectedSettings = string.Format("\"AADClientSecret\": \"{0}\"", aadClientSecret);

            var vmExtension = new VirtualMachineScaleSetExtension
            {
                Name = "adeext1",
                Publisher = "Microsoft.Azure.Security",
                Type = "ADETest",
                TypeHandlerVersion = "2.0",
                Settings = new JRaw("{ " + settings + " }"),
                ProtectedSettings = new JRaw("{ " + protectedSettings + " }")
            };

            return vmExtension;
        }

        protected VirtualMachineScaleSet CreateDefaultVMScaleSetInput(
            string rgName,
            string storageAccountName,
            ImageReference imageRef,
            string subnetId,
            bool hasManagedDisks = false,
            string healthProbeId = null,
            string loadBalancerBackendPoolId = null,
            IList<string> zones = null,
            int? osDiskSizeInGB = null)
        {
            // Generate Container name to hold disk VHds
            string containerName = TestUtilities.GenerateName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vmssName = TestUtilities.GenerateName("vmss");
            bool createOSDisk = !hasManagedDisks || osDiskSizeInGB != null;

            return new VirtualMachineScaleSet()
            {
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                Sku = new CM.Sku()
                {
                    Capacity = 2,
                    Name = zones == null ? VirtualMachineSizeTypes.StandardA0 : VirtualMachineSizeTypes.StandardA1V2,
                },
                Zones = zones,
                Overprovision = false,
                UpgradePolicy = new UpgradePolicy()
                {
                    Mode = UpgradeMode.Automatic
                },
                VirtualMachineProfile = new VirtualMachineScaleSetVMProfile()
                {
                    StorageProfile = new VirtualMachineScaleSetStorageProfile()
                    {
                        ImageReference = imageRef,
                        OsDisk = !createOSDisk ? null : new VirtualMachineScaleSetOSDisk
                        {
                            Caching = CachingTypes.None,
                            CreateOption = DiskCreateOptionTypes.FromImage,
                            Name = hasManagedDisks ? null : "test",
                            VhdContainers = hasManagedDisks ? null : new List<string>{ vhdContainer },
                            DiskSizeGB = osDiskSizeInGB
                        },
                        DataDisks = !hasManagedDisks ? null : new List<VirtualMachineScaleSetDataDisk>
                        {
                            new VirtualMachineScaleSetDataDisk
                            {
                                Lun = 1,
                                CreateOption = DiskCreateOptionTypes.Empty,
                                DiskSizeGB = 128
                            }
                        }
                    },
                    OsProfile = new VirtualMachineScaleSetOSProfile()
                    {
                        ComputerNamePrefix = "test",
                        AdminUsername = "Foo12",
                        AdminPassword = PLACEHOLDER,
                        CustomData = Convert.ToBase64String(Encoding.UTF8.GetBytes("Custom data"))
                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile()
                    {
                        HealthProbe = healthProbeId == null ? null : new ApiEntityReference
                        {
                            Id = healthProbeId
                        },
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
                                        LoadBalancerBackendAddressPools = (loadBalancerBackendPoolId != null) ? 
                                            new List<Microsoft.Azure.Management.Compute.Models.SubResource> {
                                                new Microsoft.Azure.Management.Compute.Models.SubResource(loadBalancerBackendPoolId)
                                            } : null,
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
            bool createWithManagedDisks = false,
            bool createWithHealthProbe = false,
            Subnet subnet = null,
            IList<string> zones = null,
            int? osDiskSizeInGB = null)
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
                                                                                     createWithManagedDisks,
                                                                                     createWithHealthProbe,
                                                                                     subnet,
                                                                                     zones,
                                                                                     osDiskSizeInGB);

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
            bool createWithPublicIpAddress = false,
            bool createWithManagedDisks = false)
        {
            try
            {
                var createOrUpdateResponse = CreateVMScaleSetAndGetOperationResponse(
                    rgName,
                    vmssName,
                    storageAccount,
                    imageRef,
                    out inputVMScaleSet,
                    extensionProfile,
                    vmScaleSetCustomizer,
                    createWithPublicIpAddress,
                    createWithManagedDisks);

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

        // This method is used to Update VM Scale Set but it internally calls PATCH verb instead of PUT.
        // PATCH verb is more relaxed and does not puts constraint to specify full parameters.
        protected void PatchVMScaleSet(string rgName, string vmssName, VirtualMachineScaleSetUpdate inputVMScaleSet)
        {
            var patchResponse = m_CrpClient.VirtualMachineScaleSets.Update(rgName, vmssName, inputVMScaleSet);
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
            bool createWithManagedDisks = false,
            bool createWithHealthProbe = false,
            Subnet subnet = null,
            IList<string> zones = null,
            int? osDiskSizeInGB = null)
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

            var loadBalancer = (getPublicIpAddressResponse != null && createWithHealthProbe) ?
                CreatePublicLoadBalancerWithProbe(rgName, getPublicIpAddressResponse) : null;

            inputVMScaleSet = CreateDefaultVMScaleSetInput(rgName, storageAccount.Name, imageRef, subnetResponse.Id, hasManagedDisks:createWithManagedDisks,
                healthProbeId: loadBalancer?.Probes?.FirstOrDefault()?.Id,
                loadBalancerBackendPoolId: loadBalancer?.BackendAddressPools?.FirstOrDefault()?.Id, zones: zones, osDiskSizeInGB: osDiskSizeInGB);
            if (vmScaleSetCustomizer != null)
            {
                vmScaleSetCustomizer(inputVMScaleSet);
            }

            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

            var createOrUpdateResponse = m_CrpClient.VirtualMachineScaleSets.CreateOrUpdate(rgName, vmssName, inputVMScaleSet);

            Assert.True(createOrUpdateResponse.Name == vmssName);
            Assert.True(createOrUpdateResponse.Location.ToLower() == inputVMScaleSet.Location.ToLower().Replace(" ", ""));

            ValidateVMScaleSet(inputVMScaleSet, createOrUpdateResponse, createWithManagedDisks);

            return createOrUpdateResponse;
        }


        protected void ValidateVMScaleSetInstanceView(VirtualMachineScaleSet vmScaleSet,
            VirtualMachineScaleSetInstanceView vmScaleSetInstanceView)
        {
            Assert.NotNull(vmScaleSetInstanceView.Statuses);
            Assert.NotNull(vmScaleSetInstanceView);
            if (vmScaleSet.VirtualMachineProfile.ExtensionProfile != null)
            {
                Assert.NotNull(vmScaleSetInstanceView.Extensions);
                int instancesCount = vmScaleSetInstanceView.Extensions.Sum(statusSummary => statusSummary.StatusesSummary.Sum(t => t.Count.Value));
                Assert.True(instancesCount == vmScaleSet.Sku.Capacity);
            }
        }

        protected void ValidateVMScaleSet(VirtualMachineScaleSet vmScaleSet, VirtualMachineScaleSet vmScaleSetOut, bool hasManagedDisks = false)
        {
            Assert.True(!string.IsNullOrEmpty(vmScaleSetOut.ProvisioningState));

            Assert.True(vmScaleSetOut.Sku.Name
                     == vmScaleSet.Sku.Name);

            Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk);

            if (vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk?.DiskSizeGB != null)
            {
                Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB);
                Assert.Equal(vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB, vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB);
            }

            if (!hasManagedDisks)
            {
                Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Name
                            == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Name);

                if (vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image != null)
                {
                    Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Image.Uri
                                == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image.Uri);
                }

                Assert.True(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.Caching
                            == vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Caching);
            }
            else
            {
                Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk);

                if (vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk != null)
                {
                    VirtualMachineScaleSetOSDisk osDisk = vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk;
                    VirtualMachineScaleSetOSDisk osDiskOut =
                        vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk;

                    if (osDisk.Caching != null)
                    {
                        Assert.True(osDisk.Caching == osDiskOut.Caching);
                    }
                    else
                    {
                        Assert.NotNull(osDiskOut.Caching);
                    }

                    Assert.NotNull(osDiskOut.ManagedDisk);
                    if (osDisk.ManagedDisk != null && osDisk.ManagedDisk.StorageAccountType != null)
                    {
                        Assert.True(osDisk.ManagedDisk.StorageAccountType == osDiskOut.ManagedDisk.StorageAccountType);
                    }
                    else
                    {
                        Assert.NotNull(osDiskOut.ManagedDisk.StorageAccountType);
                    }

                    if (osDisk.Name != null)
                    {
                        Assert.Equal(osDiskOut.Name, osDisk.Name);
                    }

                    Assert.True(osDiskOut.CreateOption == DiskCreateOptionTypes.FromImage);
                }

                if (vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks != null
                    && vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.Count > 0)
                {
                    Assert.Equal(
                        vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.Count,
                        vmScaleSetOut.VirtualMachineProfile.StorageProfile.DataDisks.Count);

                    foreach (VirtualMachineScaleSetDataDisk dataDisk in vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks)
                    {
                        VirtualMachineScaleSetDataDisk matchingDataDisk
                            = vmScaleSetOut.VirtualMachineProfile.StorageProfile.DataDisks.FirstOrDefault(disk => disk.Lun == dataDisk.Lun);
                        Assert.NotNull(matchingDataDisk);

                        if (dataDisk.Caching != null)
                        {
                            Assert.True(dataDisk.Caching == matchingDataDisk.Caching);
                        }
                        else
                        {
                            Assert.NotNull(matchingDataDisk.Caching);
                        }

                        if (dataDisk.ManagedDisk != null && dataDisk.ManagedDisk.StorageAccountType != null)
                        {
                            Assert.True(dataDisk.ManagedDisk.StorageAccountType == matchingDataDisk.ManagedDisk.StorageAccountType);
                        }
                        else
                        {
                            Assert.NotNull(matchingDataDisk.ManagedDisk.StorageAccountType);
                        }

                        if (dataDisk.Name != null)
                        {
                            Assert.Equal(dataDisk.Name, matchingDataDisk.Name);
                        }
                        Assert.True(dataDisk.CreateOption == matchingDataDisk.CreateOption);
                    }
                }
            }

            if(vmScaleSet.UpgradePolicy.AutoOSUpgradePolicy!=null)
            {
                Assert.True(vmScaleSetOut.UpgradePolicy.AutoOSUpgradePolicy.DisableAutoRollback == 
                    vmScaleSet.UpgradePolicy.AutoOSUpgradePolicy.DisableAutoRollback);
            }

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

            if(vmScaleSet.Zones != null)
            {
                Assert.True(vmScaleSet.Zones.SequenceEqual(vmScaleSetOut.Zones), "Zones don't match");
                if(vmScaleSet.ZoneBalance.HasValue)
                {
                    Assert.Equal(vmScaleSet.ZoneBalance, vmScaleSetOut.ZoneBalance);
                }
                else
                {
                    if (vmScaleSet.Zones.Count > 1)
                    {
                        Assert.True(vmScaleSetOut.ZoneBalance.HasValue);
                    }
                    else
                    {
                        Assert.False(vmScaleSetOut.ZoneBalance.HasValue);
                    }    
                }

                if (vmScaleSet.PlatformFaultDomainCount.HasValue)
                {
                    Assert.Equal(vmScaleSet.PlatformFaultDomainCount, vmScaleSetOut.PlatformFaultDomainCount);
                }
                else
                {
                    Assert.True(vmScaleSetOut.PlatformFaultDomainCount.HasValue);
                }
            }
            else
            {
                Assert.Null(vmScaleSetOut.Zones);
                Assert.Null(vmScaleSetOut.ZoneBalance);
                Assert.Null(vmScaleSetOut.PlatformFaultDomainCount);
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
