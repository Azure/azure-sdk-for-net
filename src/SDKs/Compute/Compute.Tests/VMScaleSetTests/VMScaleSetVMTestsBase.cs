// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetVMTestsBase : VMScaleSetTestsBase
    {
        protected void ValidateVMScaleSetVM(VirtualMachineScaleSetVM vmScaleSetVM, string skuName, VirtualMachineScaleSetVM vmScaleSetVMOut, bool hasManagedDisks = false)
        {
            Assert.True(!string.IsNullOrEmpty(vmScaleSetVMOut.ProvisioningState));

            Assert.True(skuName
                == vmScaleSetVMOut.Sku.Name);
            
            Assert.NotNull(vmScaleSetVMOut.StorageProfile.OsDisk);

            if (hasManagedDisks)
            {
                Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.ManagedDisk != null);
                Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.ManagedDisk.Id != null);
                if (vmScaleSetVM.StorageProfile.DataDisks != null)
                {
                    Assert.Equal(vmScaleSetVM.StorageProfile.DataDisks.Count,
                        vmScaleSetVMOut.StorageProfile.DataDisks.Count);

                    foreach (var dataDiskOut in vmScaleSetVM.StorageProfile.DataDisks)
                    {
                        var dataDisk =
                            vmScaleSetVM.StorageProfile.DataDisks.FirstOrDefault(d => d.Lun == dataDiskOut.Lun);
                        Assert.Equal(dataDisk.CreateOption, dataDiskOut.CreateOption);
                        Assert.Equal(dataDisk.DiskSizeGB, dataDiskOut.DiskSizeGB);
                    }
                }
            }
            else
            {
                if (vmScaleSetVM.StorageProfile.OsDisk.Image != null)
                {
                    Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.Image.Uri
                                == vmScaleSetVM.StorageProfile.OsDisk.Image.Uri);
                }

                Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.Caching
                         == vmScaleSetVM.StorageProfile.OsDisk.Caching);
            }

            if (vmScaleSetVM.OsProfile.Secrets != null &&
               vmScaleSetVM.OsProfile.Secrets.Any())
            {
                foreach (var secret in vmScaleSetVM.OsProfile.Secrets)
                {
                    Assert.NotNull(secret.VaultCertificates);
                    var secretOut = vmScaleSetVMOut.OsProfile.Secrets.FirstOrDefault(s => string.Equals(secret.SourceVault.Id, s.SourceVault.Id));
                    Assert.NotNull(secretOut);

                    // Disabling resharper null-ref check as it doesn't seem to understand the not-null assert above.
                    // ReSharper disable PossibleNullReferenceException

                    Assert.NotNull(secretOut.VaultCertificates);
                    var VaultCertComparer = new VaultCertComparer();
                    Assert.True(secretOut.VaultCertificates.SequenceEqual(secret.VaultCertificates, VaultCertComparer));

                    // ReSharper enable PossibleNullReferenceException
                }
            }
        }

        protected void ValidateVMScaleSetVMInstanceView(VirtualMachineScaleSetVMInstanceView vmScaleSetVMInstanceView, bool hasManagedDisks = false)
        {
            Assert.NotNull(vmScaleSetVMInstanceView);
            Assert.Contains(vmScaleSetVMInstanceView.Statuses, s => !string.IsNullOrEmpty(s.Code));

            if (!hasManagedDisks)
            {
                var instanceView = vmScaleSetVMInstanceView;
                Assert.NotNull(instanceView.Disks);
                Assert.True(instanceView.Disks.Any());

                DiskInstanceView diskInstanceView = instanceView.Disks.First();
                Assert.NotNull(diskInstanceView);
                Assert.NotNull(diskInstanceView.Statuses[0].DisplayStatus);
                Assert.NotNull(diskInstanceView.Statuses[0].Code);
                Assert.NotNull(diskInstanceView.Statuses[0].Level);
            }
        }

        /// <summary>
        /// Validate if encryption settings are populated in DiskInstanceView as part of VM instance view
        /// </summary>
        protected void ValidateEncryptionSettingsInVMScaleSetVMInstanceView(
            VirtualMachineScaleSetVMInstanceView vmScaleSetVMInstanceView,
            bool hasManagedDisks)
        {
            Assert.True(hasManagedDisks); // VMSS disk encryption is supported only with managed disks
            Assert.NotNull(vmScaleSetVMInstanceView);
            Assert.NotNull(vmScaleSetVMInstanceView.Disks);
            Assert.True(vmScaleSetVMInstanceView.Disks.Any());

            DiskInstanceView diskInstanceView = vmScaleSetVMInstanceView.Disks.First();
            Assert.NotNull(diskInstanceView.EncryptionSettings);
            Assert.True(diskInstanceView.EncryptionSettings.Any());

            DiskEncryptionSettings encryptionSettings = diskInstanceView.EncryptionSettings.First();
            Assert.NotNull(encryptionSettings.Enabled);
        }

        protected VirtualMachineScaleSetVM GenerateVMScaleSetVMModel(VirtualMachineScaleSet inputVMScaleSet, string instanceId, bool hasManagedDisks = false)
        {
            VirtualMachineScaleSetVM expectedVirtualMachineScaleSetVM = new VirtualMachineScaleSetVM()
            {
                /*InstanceId = instanceId,
                Sku = new Sku()
                {
                    Name = inputVMScaleSet.Sku.Name
                },*/
                OsProfile = new OSProfile()
                {
                    AdminPassword = inputVMScaleSet.VirtualMachineProfile.OsProfile.AdminPassword,
                    AdminUsername = inputVMScaleSet.VirtualMachineProfile.OsProfile.AdminUsername,
                    CustomData = inputVMScaleSet.VirtualMachineProfile.OsProfile.CustomData,
                    ComputerName = inputVMScaleSet.VirtualMachineProfile.OsProfile.ComputerNamePrefix + "-" + instanceId
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = inputVMScaleSet.VirtualMachineProfile.StorageProfile.ImageReference,
                    OsDisk = hasManagedDisks ? null : new OSDisk()
                    {
                        Name = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Name,
                        Caching = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Caching,
                        CreateOption = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption,
                        OsType = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.OsType,
                        Image = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image,
                    },
                },
            };

            if (hasManagedDisks && inputVMScaleSet.VirtualMachineProfile.StorageProfile.DataDisks != null)
            {
                expectedVirtualMachineScaleSetVM.StorageProfile.DataDisks = new List<DataDisk>();
                foreach (var dataDisk in inputVMScaleSet.VirtualMachineProfile.StorageProfile.DataDisks)
                {
                    expectedVirtualMachineScaleSetVM.StorageProfile.DataDisks.Add(new DataDisk()
                    {
                        Lun = dataDisk.Lun,
                        DiskSizeGB = dataDisk.DiskSizeGB,
                        CreateOption = dataDisk.CreateOption
                    });
                }
            }
            return expectedVirtualMachineScaleSetVM;
        }
    }
}
