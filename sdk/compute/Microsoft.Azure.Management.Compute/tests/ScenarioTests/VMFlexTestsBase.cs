using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMFlexTestsBase : VMScaleSetTestsBase
    {
        protected VirtualMachine CreateFlexVM(
            string rgName, string vmssName, string storageAccountName, ImageReference imageRef,
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool waitForCompletion = true,
            string vmSize = VirtualMachineSizeTypes.StandardA0,
            string osDiskStorageAccountType = "Standard_LRS",
            string dataDiskStorageAccountType = "Standard_LRS",
            IList<string> zones = null)
        {
            try
            {
                // Create the resource Group, it might have been already created during StorageAccount creation.
                m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgName,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                    });

                PublicIPAddress getPublicIpAddressResponse = CreatePublicIP(rgName);

                // Do not add Dns server for managed disks, as they cannot resolve managed disk url ( https://md-xyz ) without
                // explicitly setting up the rules for resolution. The VMs upon booting would need to contact the
                // DNS server to access the VMStatus agent blob. Without proper Dns resolution, The VMs cannot access the
                // VMStatus agent blob and there by fail to boot.
                Subnet subnetResponse = CreateVNET(rgName, addDnsServer: false);

                NetworkInterface nicResponse = CreateNIC(
                    rgName,
                    subnetResponse,
                    getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

                CreateFlexVmss(rgName, vmssName, out VirtualMachineScaleSet flexVmss);

                inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId: null, nicResponse.Id, hasManagedDisks : true, vmSize, osDiskStorageAccountType,
                    dataDiskStorageAccountType);

                // Default Input VM will have AvSet populated. Need to switch with VMSS instead.
                inputVM.AvailabilitySet = null;
                inputVM.VirtualMachineScaleSet = new Microsoft.Azure.Management.Compute.Models.SubResource() { Id = flexVmss.Id };

                if (zones != null)
                {
                    // If no vmSize is provided and we are using the default value, change the default value for VMs with Zones.
                    if (vmSize == VirtualMachineSizeTypes.StandardA0)
                    {
                        vmSize = VirtualMachineSizeTypes.StandardA1V2;
                    }
                    inputVM.HardwareProfile.VmSize = vmSize;
                    inputVM.Zones = zones;
                }

                if (vmCustomizer != null)
                {
                    vmCustomizer(inputVM);
                }

                string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                VirtualMachine createOrUpdateResponse = null;
                if (waitForCompletion)
                {
                    // CreateOrUpdate polls for the operation completion and returns once the operation reaches a terminal state
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
                }
                else
                {
                    // BeginCreateOrUpdate returns immediately after the request is accepted by CRP
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.BeginCreateOrUpdate(rgName, inputVM.Name, inputVM);
                }

                Assert.True(createOrUpdateResponse.Name == inputVM.Name);
                Assert.True(createOrUpdateResponse.Location == inputVM.Location.ToLower().Replace(" ", "") ||
                    createOrUpdateResponse.Location.ToLower() == inputVM.Location.ToLower());

                Assert.True(createOrUpdateResponse.VirtualMachineScaleSet.Id.ToLowerInvariant() == flexVmss.Id.ToLowerInvariant());

                if (zones != null)
                {
                    Assert.True(createOrUpdateResponse.Zones.Count == 1);
                    Assert.True(createOrUpdateResponse.Zones.FirstOrDefault() == zones.FirstOrDefault());
                }

                // The intent here is to validate that the GET response is as expected.
                var createdVM = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                ValidateFlexVM(inputVM, createdVM, expectedVMReferenceId);

                return createdVM;
            }
            catch
            {
                // Just trigger DeleteRG, rest would be taken care of by ARM
                m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                throw;
            }
        }

        protected VirtualMachineScaleSet CreateFlexVmss(
            string rgName,
            string vmssName,
            out VirtualMachineScaleSet createdFlexVmss)
        {
            VirtualMachineScaleSet inputVMScaleSet = CreateDefaultFlexVmssInput(rgName, vmssName);

            try
            {
                createdFlexVmss = m_CrpClient.VirtualMachineScaleSets.CreateOrUpdate(rgName, vmssName, inputVMScaleSet);

                Assert.True(createdFlexVmss.Name == vmssName);
                Assert.True(createdFlexVmss.Location.ToLower() == inputVMScaleSet.Location.ToLower().Replace(" ", ""));
            }
            catch (CloudException e)
            {
                if (e.Message.Contains("the allotted time"))
                {
                    createdFlexVmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                }
                else
                {
                    throw;
                }
            }

            ValidateFlexVmss(inputVMScaleSet, createdFlexVmss);

            return createdFlexVmss;
        }

        protected VirtualMachineScaleSet CreateDefaultFlexVmssInput(string rgName, string vmssName, IList<string> zones = null, int? faultDomainCount = 2)
        {
            var flexVmss = new VirtualMachineScaleSet()
            {
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", rgName }, { "testTag", "1" } },
                Zones = zones,
                PlatformFaultDomainCount = faultDomainCount
            };

            return flexVmss;
        }

        protected void ValidateFlexVmss(VirtualMachineScaleSet inputFlexVmss, VirtualMachineScaleSet createdFlexVmss)
        {
            Assert.True(!string.IsNullOrEmpty(createdFlexVmss.ProvisioningState));
            Assert.Null(createdFlexVmss.VirtualMachineProfile);

            if (inputFlexVmss.PlatformFaultDomainCount.HasValue)
            {
                Assert.Equal(inputFlexVmss.PlatformFaultDomainCount, createdFlexVmss.PlatformFaultDomainCount);
            }
            else
            {
                Assert.True(createdFlexVmss.PlatformFaultDomainCount.HasValue);
            }

            if (inputFlexVmss.Zones != null)
            {
                Assert.True(inputFlexVmss.Zones.SequenceEqual(createdFlexVmss.Zones), "Zones don't match");
                if (inputFlexVmss.ZoneBalance.HasValue)
                {
                    Assert.Equal(inputFlexVmss.ZoneBalance, createdFlexVmss.ZoneBalance);
                }
                else
                {
                    if (inputFlexVmss.Zones.Count > 1)
                    {
                        Assert.True(createdFlexVmss.ZoneBalance.HasValue);
                    }
                    else
                    {
                        Assert.False(createdFlexVmss.ZoneBalance.HasValue);
                    }
                }
            }
            else
            {
                Assert.Null(createdFlexVmss.Zones);
                Assert.Null(createdFlexVmss.ZoneBalance);
            }
        }

        protected void ValidateFlexVM(VirtualMachine inputFlexVM, VirtualMachine createdFlexVM, string expectedVMReferenceId)
        {
            ValidateVM(inputFlexVM, createdFlexVM, expectedVMReferenceId, hasManagedDisks: true, hasUserDefinedAS: false);
            Assert.Null(createdFlexVM.AvailabilitySet);
            Assert.NotNull(createdFlexVM.VirtualMachineScaleSet.Id);
            Assert.Equal(inputFlexVM.VirtualMachineScaleSet.Id, createdFlexVM.VirtualMachineScaleSet.Id);
        }
    }
}
