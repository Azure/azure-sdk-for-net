// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.ManagedServiceIdentity.Models;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string userIdentityName = ComputeManagementTestUtilities.GenerateName("userid");
                VirtualMachine inputVM;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    // Creating User Assigned Managed Identity
                    Identity identityResponse = m_MsiClient.UserAssignedIdentities.CreateOrUpdate(rgName, userIdentityName, new Identity(location: ComputeManagementTestUtilities.DefaultLocation));
                    string identity = identityResponse.Id;

                    Action<VirtualMachine> addUserIdentity = vm =>
                    {
                        vm.Identity = new VirtualMachineIdentity();
                        vm.Identity.Type = ResourceIdentityType.SystemAssignedUserAssigned;
                        vm.Identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentitiesValue>()
                        {
                            { identity, new UserAssignedIdentitiesValue() }
                        };
                    };

                    var vmResult = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, addUserIdentity);
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
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}