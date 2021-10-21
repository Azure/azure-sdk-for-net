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
    /// 1. Create VM with UserData
    /// 2. Modify existing UserData on a VM
    /// 3. Validate UserData is returned when calling GET VM $expand=UserData
    /// </summary>
    public class UserDataTests : VMTestBase
    {
        [Fact]
        public void TestUserData()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    // Create Storage Account
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    // Create VM with UserData
                    CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, userData: DummyUserData1);

                    // Validate Get VM with $expand=UserData returns the UserData
                    VirtualMachine getResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.UserData);
                    Assert.Equal(DummyUserData1, getResponse.UserData);

                    inputVM.UserData = DummyUserData2;
                    // Update VM with new UserData
                    VirtualMachine lroResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
                    // Validate Get VM with $expand=UserData returns the updated UserData
                    getResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.UserData);
                    Assert.Equal(DummyUserData2, getResponse.UserData);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                catch (Exception e)
                {
                    Assert.Null(e);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
