using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Compute.Tests
{
    /// <summary>
    /// Covers following Operations:
    /// 1. Create VM with VM size StandardD4V3
    /// 2. Modify existing VMSizeProperties
    /// 3. Validate correct VMSizeProperties are returned from getVMResponse
    /// </summary>
    public class VMCustomizationTests : VMTestBase
    {
        [Fact]
        public void TestDisablingHyperthreadingAndConstrainedvCPUsScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                var image = m_CrpClient.VirtualMachineImages.Get(
                    this.m_location, imageRef.Publisher, imageRef.Offer, imageRef.Sku, imageRef.Version);
                Assert.True(image != null);
                Assert.NotNull(image.Disallowed.VmDiskType);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                

                try
                {                    
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, (vm) =>
                    {
                        vm.StorageProfile.OsDisk.DiskSizeGB = 150;
                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardD4V3;
                        vm.HardwareProfile.VmSizeProperties = new VMSizeProperties
                        {
                            VCPUsAvailable = 1,
                            VCPUsPerCore = 1
                        };
                    });

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                    ValidateVM(inputVM, getVMResponse, Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));
                    Assert.True(getVMResponse.HardwareProfile.VmSizeProperties.VCPUsAvailable == 1, "HardwareProfile.VmSizeProperties.VCPUsAvailable is not equal to 1");
                    Assert.True(getVMResponse.HardwareProfile.VmSizeProperties.VCPUsPerCore == 1, "HardwareProfile.VmSizeProperties.VCPUsPerCore is not equal to 1");
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }
    }
}
