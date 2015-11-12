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
    public class VMScaleSetVMTestsBase : VMScaleSetTestsBase
    {
        protected void ValidateVMScaleSetVM(VirtualMachineScaleSetVM vmScaleSetVM, string skuName, VirtualMachineScaleSetVM vmScaleSetVMOut)
        {
            Assert.True(!string.IsNullOrEmpty(vmScaleSetVMOut.ProvisioningState));

            Assert.True(skuName
                == vmScaleSetVMOut.Sku.Name);
            
            Assert.NotNull(vmScaleSetVMOut.StorageProfile.OsDisk);

            if (vmScaleSetVM.StorageProfile.OsDisk.Image != null)
            {
                Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.Image.Uri
                            == vmScaleSetVM.StorageProfile.OsDisk.Image.Uri);
            }

            Assert.True(vmScaleSetVMOut.StorageProfile.OsDisk.Caching
                     == vmScaleSetVM.StorageProfile.OsDisk.Caching);

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

        protected void ValidateVMScaleSetVMInstanceView(VirtualMachineScaleSetVMInstanceView vmScaleSetVMInstanceView)
        {
            Assert.NotNull(vmScaleSetVMInstanceView);
            Assert.True(vmScaleSetVMInstanceView.Statuses.Any(s => !string.IsNullOrEmpty(s.Code)));

            var instanceView = vmScaleSetVMInstanceView;
            Assert.NotNull(instanceView.Disks);
            Assert.True(instanceView.Disks.Any());

            DiskInstanceView diskInstanceView = instanceView.Disks.First();
            Assert.NotNull(diskInstanceView);
            Assert.NotNull(diskInstanceView.Statuses[0].DisplayStatus);
            Assert.NotNull(diskInstanceView.Statuses[0].Code);
            Assert.NotNull(diskInstanceView.Statuses[0].Level);
        }

        protected VirtualMachineScaleSetVM GenerateVMScaleSetVMModel(VirtualMachineScaleSet inputVMScaleSet, string instanceId)
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
                    OsDisk = new OSDisk()
                    {
                        Name = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Name,
                        Caching = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Caching,
                        CreateOption = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.CreateOption,
                        OsType = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.OsType,
                        Image = inputVMScaleSet.VirtualMachineProfile.StorageProfile.OsDisk.Image,
                    }
                },
            };

            return expectedVirtualMachineScaleSetVM;
        }
    }
}
