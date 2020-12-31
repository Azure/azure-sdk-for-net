// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMIdentityTests : VMTestBase
    {
        [Fact]
        public void TestVMIdentitySystemAssignedUserAssigned()
        {
            //
            // Prerequisite: in order to record this test, first create a user identity in resource group 'identitytest' and set the value of identity here.
            // 
            const string rgName = "identitytest";
            const string identity = "/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/resourcegroups/identitytest/providers/Microsoft.ManagedIdentity/userAssignedIdentities/userid";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imgageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                bool passed = false;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    Action<VirtualMachine> addUserIdentity = vm =>
                    {
                        vm.Identity = new VirtualMachineIdentity();
                        vm.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
                        vm.Identity.UserAssignedIdentities = new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>()
                        {
                            { identity, new VirtualMachineIdentityUserAssignedIdentitiesValue() }
                        };
                    };

                    var vmResult = CreateVM(rgName, asName, storageAccountOutput, imgageRef, out inputVM, addUserIdentity);
                    Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, vmResult.Identity.Type);
                    Assert.NotNull(vmResult.Identity.PrincipalId);
                    Assert.NotNull(vmResult.Identity.TenantId);
                    Assert.True(vmResult.Identity.UserAssignedIdentities.Keys.Contains(identity));
                    Assert.NotNull(vmResult.Identity.UserAssignedIdentities[identity].PrincipalId);
                    Assert.NotNull(vmResult.Identity.UserAssignedIdentities[identity].ClientId);

                    var getVM = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                    Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, getVM.Identity.Type);
                    Assert.NotNull(getVM.Identity.PrincipalId);
                    Assert.NotNull(getVM.Identity.TenantId);
                    Assert.True(getVM.Identity.UserAssignedIdentities.Keys.Contains(identity));
                    Assert.NotNull(getVM.Identity.UserAssignedIdentities[identity].PrincipalId);
                    Assert.NotNull(getVM.Identity.UserAssignedIdentities[identity].ClientId);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);

                    passed = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    Assert.True(passed);
                }
            }
        }
    }
}

