// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMScaleSetVMTestsBase : VMScaleSetTestsBase
    {
        public VMScaleSetVMTestsBase(bool isAsync)
        : base(isAsync)
        {
        }
        protected void ValidateVMScaleSetVM(VirtualMachineScaleSet vmScaleSet, string instanceId, VirtualMachineScaleSetVM vmScaleSetVMOut, bool hasManagedDisks = false)
        {
            VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId, hasManagedDisks);

            ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, vmScaleSetVMOut, hasManagedDisks);

            // Validate Zones.
            // The zone of the VM should be one of zones specified in the scaleset.
            if (vmScaleSet.Zones != null)
            {
                Assert.NotNull(vmScaleSetVMOut.Zones);
                Assert.AreEqual(1, vmScaleSetVMOut.Zones.Count);
                //Assert.Contains(vmScaleSet.Zones, vmssZone => vmssZone == vmScaleSetVMOut.Zones.First());
            }
        }

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
                    Assert.AreEqual(vmScaleSetVM.StorageProfile.DataDisks.Count,
                        vmScaleSetVMOut.StorageProfile.DataDisks.Count);

                    foreach (var dataDiskOut in vmScaleSetVM.StorageProfile.DataDisks)
                    {
                        var dataDisk =
                            vmScaleSetVM.StorageProfile.DataDisks.FirstOrDefault(d => d.Lun == dataDiskOut.Lun);
                        Assert.AreEqual(dataDisk.CreateOption, dataDiskOut.CreateOption);
                        Assert.AreEqual(dataDisk.DiskSizeGB, dataDiskOut.DiskSizeGB);
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
            //Assert.Contains(vmScaleSetVMInstanceView.Statuses, s => !string.IsNullOrEmpty(s.Code));

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
            var OsProfile = new OSProfile()
            {
                AdminPassword = inputVMScaleSet.VirtualMachineProfile.OsProfile.AdminPassword,
                AdminUsername = inputVMScaleSet.VirtualMachineProfile.OsProfile.AdminUsername,
                CustomData = inputVMScaleSet.VirtualMachineProfile.OsProfile.CustomData,
                ComputerName = inputVMScaleSet.VirtualMachineProfile.OsProfile.ComputerNamePrefix + "-" + instanceId
            };
            var StorageProfile = new StorageProfile()
            {
                ImageReference = inputVMScaleSet.VirtualMachineProfile.StorageProfile.ImageReference,
                OsDisk = hasManagedDisks ? null : new OSDisk(inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.OsType,null, inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Name, null, inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image, inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Caching, null, null, inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption, null,null)
            };
            VirtualMachineScaleSetVM expectedVirtualMachineScaleSetVM = new VirtualMachineScaleSetVM(null, null, null, null, null, null, null, null, null, null, null, null, null, null, StorageProfile, null, OsProfile, null, null, null, null, null, null, null ,null);
            {
                /*InstanceId = instanceId,
                Sku = new Sku()
                {
                    Name = inputVMScaleSet.Sku.Name
                },*/
            };

            if (hasManagedDisks && inputVMScaleSet.VirtualMachineProfile.StorageProfile.DataDisks != null)
            {
                expectedVirtualMachineScaleSetVM.StorageProfile.DataDisks = new List<DataDisk>();
                foreach (var dataDisk in inputVMScaleSet.VirtualMachineProfile.StorageProfile.DataDisks)
                {
                    expectedVirtualMachineScaleSetVM.StorageProfile.DataDisks.Add(new DataDisk(dataDisk.Lun, null, null, null, null, null, dataDisk.CreateOption, dataDisk.DiskSizeGB, null, null, null, null));
                }
            }
            return expectedVirtualMachineScaleSetVM;
        }
    }
}
