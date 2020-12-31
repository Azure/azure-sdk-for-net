// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
//using Newtonsoft.Json.Linq;
using CM = Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetTestsBase : VMTestBase
    {
        public VMScaleSetTestsBase(bool isAsync)
        : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        protected VirtualMachineScaleSetExtension GetTestVMSSVMExtension(
            string name = "vmssext01",
            string publisher = "Microsoft.Compute",
            string type = "VMAccessAgent",
            string version = "2.0")
        {
            var vmExtension = new VirtualMachineScaleSetExtension()
            {
                Name = name,
                Publisher = publisher,
                TypePropertiesType = type,
                TypeHandlerVersion = version,
                AutoUpgradeMinorVersion = true,
                Settings = "{}",
                ProtectedSettings = "{}"
            };
            return vmExtension;
        }

        protected VirtualMachineScaleSetExtension GetVmssServiceFabricExtension()
        {
            VirtualMachineScaleSetExtension sfExtension = new VirtualMachineScaleSetExtension(
                null, "vmsssfext01", "ServiceFabricNode", null, "Microsoft.Azure.ServiceFabric", null, "1.0", true, "{}", "{}", null, null);

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

            var vmExtension = new VirtualMachineScaleSetExtension(
                null, "adeext1", "ADETest", null, "Microsoft.Azure.Security", null, "2.0", null, "{ " + settings + " }", "{ " + protectedSettings + " }", null, null);
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
            int? osDiskSizeInGB = null,
            string machineSizeType = null,
            bool? enableUltraSSD = false,
            string diskEncryptionSetId = null,
            AutomaticRepairsPolicy automaticRepairsPolicy = null)
        {
            // Generate Container name to hold disk VHds
            string containerName = Recording.GenerateAssetName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vmssName = Recording.GenerateAssetName("vmss");
            bool createOSDisk = !hasManagedDisks || osDiskSizeInGB != null;

            string vmSize = zones == null ? VirtualMachineSizeTypes.StandardA0.ToString() : VirtualMachineSizeTypes.StandardA1V2.ToString();
            var test1 = Recording.GenerateAssetName("vmsstestnetconfig");
            var test2 = Recording.GenerateAssetName("vmsstestnetconfig");
            var virtualMachineScaleSetIpConfiguration = new VirtualMachineScaleSetIPConfiguration(test2)
            {
                Subnet = new Azure.ResourceManager.Compute.Models.ApiEntityReference()
                {
                    Id = subnetId
                }
            };

            virtualMachineScaleSetIpConfiguration.ApplicationGatewayBackendAddressPools.Clear();
            if (loadBalancerBackendPoolId != null)
            {
                virtualMachineScaleSetIpConfiguration.LoadBalancerBackendAddressPools.Add(new Models.SubResource(loadBalancerBackendPoolId));
            }

            var virtualMachineScaleSetOsDisk = !createOSDisk ? null : new VirtualMachineScaleSetOSDisk(DiskCreateOptionTypes.FromImage)
            {
                Caching = CachingTypes.None,
                Name = hasManagedDisks ? null : "test",
                DiskSizeGB = osDiskSizeInGB,
                ManagedDisk = diskEncryptionSetId == null ? null : new VirtualMachineScaleSetManagedDiskParameters()
                {
                    StorageAccountType = StorageAccountTypes.StandardLRS,
                    DiskEncryptionSet = new DiskEncryptionSetParameters()
                    {
                        Id = diskEncryptionSetId
                    }
                }
            };

            if (!hasManagedDisks)
            {
                virtualMachineScaleSetOsDisk?.VhdContainers.Add(vhdContainer);
            }

            var virtualMachineScaleSetStorageProfile = new VirtualMachineScaleSetStorageProfile()
            {
                ImageReference = imageRef,
                OsDisk = virtualMachineScaleSetOsDisk
            };

            if (hasManagedDisks)
            {
                virtualMachineScaleSetStorageProfile.DataDisks.Add(new VirtualMachineScaleSetDataDisk(1, DiskCreateOptionTypes.Empty)
                {
                    DiskSizeGB = 128,
                    ManagedDisk = diskEncryptionSetId == null
                        ? null
                        : new VirtualMachineScaleSetManagedDiskParameters()
                        {
                            StorageAccountType = StorageAccountTypes.StandardLRS,
                            DiskEncryptionSet = new DiskEncryptionSetParameters()
                            {
                                Id = diskEncryptionSetId
                            }
                        }
                });
            }

            var vmScaleSet = new VirtualMachineScaleSet(m_location)
            {
                Location = m_location,
                Tags = { { "RG", "rg" }, { "testTag", "1" } },
                Sku = new CM.Sku()
                {
                    Capacity = 2,
                    Name = machineSizeType == null ? vmSize : machineSizeType
                },
                Overprovision = false,
                UpgradePolicy = new UpgradePolicy()
                {
                    Mode = UpgradeMode.Automatic
                },
                VirtualMachineProfile = new VirtualMachineScaleSetVMProfile()
                {
                    StorageProfile = virtualMachineScaleSetStorageProfile,
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
                        NetworkInterfaceConfigurations = {
                            new VirtualMachineScaleSetNetworkConfiguration(test1)
                            {
                                Primary = true,
                                IpConfigurations = {
                                    virtualMachineScaleSetIpConfiguration
                                }
                            }
                        }
                    },
                    ExtensionProfile = new VirtualMachineScaleSetExtensionProfile(),
                },
                AutomaticRepairsPolicy = automaticRepairsPolicy
            };

            vmScaleSet.Zones.InitializeFrom(zones);
            if (enableUltraSSD == true)
            {
                vmScaleSet.AdditionalCapabilities = new AdditionalCapabilities
                {
                    UltraSSDEnabled = true
                };

                VirtualMachineScaleSetOSDisk osDisk = vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk;
                osDisk.ManagedDisk = osDisk.ManagedDisk ?? new VirtualMachineScaleSetManagedDiskParameters();
                osDisk.ManagedDisk.StorageAccountType = StorageAccountTypes.PremiumLRS;

                foreach (VirtualMachineScaleSetDataDisk dataDisk in vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks)
                {
                    dataDisk.ManagedDisk = dataDisk.ManagedDisk ?? new VirtualMachineScaleSetManagedDiskParameters();
                    dataDisk.ManagedDisk.StorageAccountType = StorageAccountTypes.UltraSSDLRS;
                }
            }

            return vmScaleSet;
        }

        public async Task<(VirtualMachineScaleSet, VirtualMachineScaleSet)> CreateVMScaleSet_NoAsyncTracking(
            string rgName,
            string vmssName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            VirtualMachineScaleSetExtensionProfile extensionProfile = null,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool createWithManagedDisks = false,
            bool hasDiffDisks = false,
            bool createWithHealthProbe = false,
            Subnet subnet = null,
            IList<string> zones = null,
            int? osDiskSizeInGB = null,
            string ppgId = null,
            string machineSizeType = null,
            bool? enableUltraSSD = false,
            string diskEncryptionSetId = null,
            AutomaticRepairsPolicy automaticRepairsPolicy = null)
        {
            try
            {
                var createOrUpdateResponse = await CreateVMScaleSetAndGetOperationResponse(rgName,
                                                                                     vmssName,
                                                                                     storageAccount,
                                                                                     imageRef,
                                                                                     extensionProfile,
                                                                                     vmScaleSetCustomizer,
                                                                                     createWithPublicIpAddress,
                                                                                     createWithManagedDisks,
                                                                                     hasDiffDisks,
                                                                                     createWithHealthProbe,
                                                                                     subnet,
                                                                                     zones,
                                                                                     osDiskSizeInGB,
                                                                                     ppgId: ppgId,
                                                                                     machineSizeType: machineSizeType,
                                                                                     enableUltraSSD: enableUltraSSD,
                                                                                     diskEncryptionSetId: diskEncryptionSetId,
                                                                                     automaticRepairsPolicy: automaticRepairsPolicy);

                var getResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
                return (getResponse, createOrUpdateResponse.Item2);
            }
            catch
            {
                throw;
            }
        }

        //not use in track one
        //protected async Task<VirtualMachineScaleSet> CreateVMScaleSet(
        //    string rgName,
        //    string vmssName,
        //    StorageAccount storageAccount,
        //    ImageReference imageRef,
        //    VirtualMachineScaleSetExtensionProfile extensionProfile = null,
        //    Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
        //    bool createWithPublicIpAddress = false,
        //    bool createWithManagedDisks = false)
        //{
        //    try
        //    {
        //        var createOrUpdateResponse = CreateVMScaleSetAndGetOperationResponse(
        //            rgName,
        //            vmssName,
        //            storageAccount,
        //            imageRef,
        //            extensionProfile,
        //            vmScaleSetCustomizer,
        //            createWithPublicIpAddress,
        //            createWithManagedDisks);

        //        var lroResponse = await VirtualMachineScaleSetsClient.StartCreateOrUpdateAsync(rgName, inputVMScaleSet.Name, inputVMScaleSet);

        //        var getResponse = await VirtualMachineScaleSetsClient.Get(rgName, inputVMScaleSet.Name);

        //        return getResponse;
        //    }
        //    catch
        //    {
        //        await ResourceGroupsClient.Delete(rgName);
        //        throw;
        //    }
        //}

        protected async Task UpdateVMScaleSet(string rgName, string vmssName, VirtualMachineScaleSet inputVMScaleSet)
        {
            var createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartCreateOrUpdateAsync(rgName, vmssName, inputVMScaleSet));
        }

        // This method is used to Update VM Scale Set but it internally calls PATCH verb instead of PUT.
        // PATCH verb is more relaxed and does not puts constraint to specify full parameters.
        protected async Task PatchVMScaleSet(string rgName, string vmssName, VirtualMachineScaleSetUpdate inputVMScaleSet)
        {
            var patchResponse = await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartUpdateAsync(rgName, vmssName, inputVMScaleSet));
        }

        private async Task<(VirtualMachineScaleSet, VirtualMachineScaleSet)> CreateVMScaleSetAndGetOperationResponse(
            string rgName,
            string vmssName,
            StorageAccount storageAccount,
            ImageReference imageRef,
            VirtualMachineScaleSetExtensionProfile extensionProfile = null,
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool createWithManagedDisks = false,
            bool hasDiffDisks = false,
            bool createWithHealthProbe = false,
            Subnet subnet = null,
            IList<string> zones = null,
            int? osDiskSizeInGB = null,
            string ppgId = null,
            string machineSizeType = null,
            bool? enableUltraSSD = false,
            string diskEncryptionSetId = null,
            AutomaticRepairsPolicy automaticRepairsPolicy = null)
        {
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location));

            var getPublicIpAddressResponse = createWithPublicIpAddress ? null : await CreatePublicIP(rgName);

            var subnetResponse = subnet ?? await CreateVNET(rgName);

            var nicResponse = await CreateNIC(
                rgName,
                subnetResponse,
                getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

            var loadBalancer = ((getPublicIpAddressResponse != null && createWithHealthProbe) ?
                (await CreatePublicLoadBalancerWithProbe(rgName, getPublicIpAddressResponse)) : null);

            Assert.True(createWithManagedDisks || storageAccount != null);
            var inputVMScaleSet = CreateDefaultVMScaleSetInput(rgName, storageAccount?.Name, imageRef, subnetResponse.Id, hasManagedDisks: createWithManagedDisks,
                healthProbeId: loadBalancer?.Probes?.FirstOrDefault()?.Id,
                loadBalancerBackendPoolId: loadBalancer?.BackendAddressPools?.FirstOrDefault()?.Id, zones: zones, osDiskSizeInGB: osDiskSizeInGB,
                machineSizeType: machineSizeType, enableUltraSSD: enableUltraSSD, diskEncryptionSetId: diskEncryptionSetId, automaticRepairsPolicy: automaticRepairsPolicy);
            if (vmScaleSetCustomizer != null)
            {
                vmScaleSetCustomizer(inputVMScaleSet);
            }

            if (hasDiffDisks)
            {
                VirtualMachineScaleSetOSDisk osDisk = new VirtualMachineScaleSetOSDisk(DiskCreateOptionTypes.FromImage);
                osDisk.Caching = CachingTypes.ReadOnly;
                osDisk.DiffDiskSettings = new DiffDiskSettings
                {
                    Option = "Local",
                    //TODO the value of "Placement" may not be given
                    //Placement = DiffDiskPlacement.CacheDisk
                };
                inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk = osDisk;
            }

            inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

            if (ppgId != null)
            {
                inputVMScaleSet.ProximityPlacementGroup = new Azure.ResourceManager.Compute.Models.SubResource() { Id = ppgId };
            }

            VirtualMachineScaleSet createOrUpdateResponse = null;

            try
            {
                createOrUpdateResponse = await WaitForCompletionAsync(await VirtualMachineScaleSetsOperations.StartCreateOrUpdateAsync(rgName, vmssName, inputVMScaleSet));

                Assert.True(createOrUpdateResponse.Name == vmssName);
                Assert.True(createOrUpdateResponse.Location.ToLower() == inputVMScaleSet.Location.ToLower().Replace(" ", ""));
            }
            catch (Exception e)
            {
                if (e.Message.Contains("the allotted time"))
                {
                    createOrUpdateResponse = await VirtualMachineScaleSetsOperations.GetAsync(rgName, vmssName);
                }
                else
                {
                    throw;
                }
            }

            ValidateVMScaleSet(inputVMScaleSet, createOrUpdateResponse, createWithManagedDisks, ppgId: ppgId);

            return (createOrUpdateResponse, inputVMScaleSet);
        }

        protected void ValidateVMScaleSetInstanceView(VirtualMachineScaleSet vmScaleSet,
            VirtualMachineScaleSetInstanceView vmScaleSetInstanceView)
        {
            Assert.NotNull(vmScaleSetInstanceView.Statuses);
            Assert.NotNull(vmScaleSetInstanceView);
            if (vmScaleSet.VirtualMachineProfile.ExtensionProfile != null)
            {
                Assert.NotNull(vmScaleSetInstanceView.Extensions);
                int instancesCount = vmScaleSetInstanceView.Extensions.First().StatusesSummary.Sum(t => t.Count.Value);
                Assert.True(instancesCount == vmScaleSet.Sku.Capacity);
            }
        }

        protected void ValidateVMScaleSet(VirtualMachineScaleSet vmScaleSet, VirtualMachineScaleSet vmScaleSetOut, bool hasManagedDisks = false, string ppgId = null)
        {
            Assert.True(!string.IsNullOrEmpty(vmScaleSetOut.ProvisioningState));

            Assert.True(vmScaleSetOut.Sku.Name
                     == vmScaleSet.Sku.Name);

            Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk);

            if (vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk?.DiskSizeGB != null)
            {
                Assert.NotNull(vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB);
                Assert.AreEqual(vmScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB, vmScaleSetOut.VirtualMachineProfile.StorageProfile.OsDisk.DiskSizeGB);
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

                    if (osDisk.DiffDiskSettings != null)
                    {
                        Assert.True(osDisk.DiffDiskSettings.Option == osDiskOut.DiffDiskSettings.Option);
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
                        Assert.AreEqual(osDiskOut.Name, osDisk.Name);
                    }

                    Assert.True(osDiskOut.CreateOption == DiskCreateOptionTypes.FromImage);
                }

                if (vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks != null
                    && vmScaleSet.VirtualMachineProfile.StorageProfile.DataDisks.Count > 0)
                {
                    Assert.AreEqual(
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
                            Assert.AreEqual(dataDisk.Name, matchingDataDisk.Name);
                        }
                        Assert.True(dataDisk.CreateOption == matchingDataDisk.CreateOption);
                    }
                }
            }

            if (vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy != null)
            {
                bool expectedDisableAutomaticRollbackValue = vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback ?? false;
                Assert.True(vmScaleSetOut.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback == expectedDisableAutomaticRollbackValue);

                bool expectedEnableAutomaticOSUpgradeValue = vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade ?? false;
                Assert.True(vmScaleSetOut.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade == expectedEnableAutomaticOSUpgradeValue);
            }

            if (vmScaleSet.AutomaticRepairsPolicy != null)
            {
                bool expectedAutomaticRepairsEnabledValue = vmScaleSet.AutomaticRepairsPolicy.Enabled ?? false;
                Assert.True(vmScaleSetOut.AutomaticRepairsPolicy.Enabled == expectedAutomaticRepairsEnabledValue);

                string expectedAutomaticRepairsGracePeriodValue = vmScaleSet.AutomaticRepairsPolicy.GracePeriod ?? "PT30M";
                Assert.AreEqual(vmScaleSetOut.AutomaticRepairsPolicy.GracePeriod, expectedAutomaticRepairsGracePeriodValue);
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
                    Assert.AreEqual(
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

            if (vmScaleSet.Zones.Count != 0)
            {
                Assert.True(vmScaleSet.Zones.SequenceEqual(vmScaleSetOut.Zones), "Zones don't match");
                if (vmScaleSet.ZoneBalance.HasValue)
                {
                    Assert.AreEqual(vmScaleSet.ZoneBalance, vmScaleSetOut.ZoneBalance);
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
                    Assert.AreEqual(vmScaleSet.PlatformFaultDomainCount, vmScaleSetOut.PlatformFaultDomainCount);
                }
                else
                {
                    Assert.True(vmScaleSetOut.PlatformFaultDomainCount.HasValue);
                }
            }
            else
            {
                Assert.IsEmpty(vmScaleSetOut.Zones);
                Assert.Null(vmScaleSetOut.ZoneBalance);
            }

            if (ppgId != null)
            {
                Assert.AreEqual(ppgId.ToLower(), vmScaleSetOut.ProximityPlacementGroup.Id.ToLower());
            }
        }

        protected void CompareVmssNicConfig(VirtualMachineScaleSetNetworkConfiguration nicconfig,
            VirtualMachineScaleSetNetworkConfiguration outnicconfig)
        {
            if (nicconfig.IpConfigurations != null && nicconfig.IpConfigurations.Count > 0)
            {
                Assert.NotNull(outnicconfig.IpConfigurations);

                Assert.AreEqual(nicconfig.IpConfigurations.Count, outnicconfig.IpConfigurations.Count);

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

                Assert.AreEqual(ipconfig.ApplicationGatewayBackendAddressPools.Count,
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
