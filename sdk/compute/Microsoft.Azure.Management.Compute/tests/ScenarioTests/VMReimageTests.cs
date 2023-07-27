using Compute.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Compute.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    public class VMReimageTests : VMTestBase
    {
        private static readonly string CustomData = Convert.ToBase64String(Encoding.UTF8.GetBytes("echo 'Hello World'"));

        [Fact]
        public void TestReimage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                EnsureClientsInitialized(context);

                string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                Action<VirtualMachine> enableCustomData = customizedVM =>
                {
                    var osProfile = customizedVM.OsProfile;
                    osProfile.CustomData = CustomData;
                };

                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                VirtualMachine inputVM;
                try
                {
                    StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachine vm = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, vmCustomizer: enableCustomData, hasManagedDisks: true);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                    m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, vm.Name, vm);

                    VirtualMachineReimageParameters vmReimageParameters = new VirtualMachineReimageParameters()
                    {
                        OsProfile = new OSProfileProvisioningData()
                        {
                            AdminPassword = VMTestBase.PLACEHOLDER,
                            CustomData = CustomData
                        }
                    };
                    m_CrpClient.VirtualMachines.Reimage(rgName, vm.Name, vmReimageParameters);

                    m_CrpClient.VirtualMachines.BeginDelete(rgName, vm.Name);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    if (m_ResourcesClient != null)
                    {
                        m_ResourcesClient.ResourceGroups.Delete(rgName);
                    }
                }
            }
        }
    }
}