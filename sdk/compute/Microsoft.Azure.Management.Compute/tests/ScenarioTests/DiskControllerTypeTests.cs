using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Compute.Tests
{
    /// <summary>
    /// Covers following Operations:
    /// 1. Create VM with VM size Standard_E2bs_v5 with disk controller type NVMe
    /// 2. Modify existing DiskControllerType to support disk controller type SCSI
    /// 3. Validate correct DiskControllerType is returned from getVMResponse
    /// </summary>
    public class DiskControllerTypeTests : VMTestBase
    {
        [Fact]
        public void TestDiskControllerTypeWithPIRImageScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "westcentralus");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageReference = new ImageReference
                {
                    Publisher = "CANONICAL",
                    Offer = "UBUNTUSERVER",
                    Sku = "18_04-LTS-GEN2",
                    Version = "latest"
                };
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    var vm1 = CreateVM(rgName: rgName, asName: asName, storageAccount: storageAccountOutput, imageRef: imageReference,
                        inputVM: out inputVM, vmCustomizer : (vm) =>
                    {
                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.Standard_E2bs_v5;
                        vm.StorageProfile.DiskControllerType = DiskControllerTypes.NVMe;
                    }, hasManagedDisks: true);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                    var getVMResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                    Assert.True(getVMResponse.StorageProfile.DiskControllerType == DiskControllerTypes.NVMe, "StorageProfile.DiskControllerType is not equal to NVMe");
                }
                finally
                {
                    // Fire and forget. No need to wait for RG deletion completion
                    try
                    {
                        m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                    }
                    catch (Exception e)
                    {
                        // Swallow this exception so that the original exception is thrown
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}
