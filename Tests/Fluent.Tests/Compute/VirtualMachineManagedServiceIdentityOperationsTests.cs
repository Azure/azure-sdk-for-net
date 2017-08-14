// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fluent.Tests.Compute.VirtualMachine
{
    public class ManagedServiceIdentityOperations
    {
        [Fact]
        public void CanSetMSIOnNewOrExistingVMWithoutRoleAssignment()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var region = Region.USSouthCentral;
                var vmName = "javavm";

                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    // Create a virtual machine with just MSI enabled without role and scope.
                    //
                    IVirtualMachine virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithManagedServiceIdentity()
                            .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityTenantId);

                    // Ensure the MSI extension is set
                    //
                    var extensions = virtualMachine.ListExtensions();
                    IVirtualMachineExtension msiExtension = null;
                    foreach (var extension in extensions.Values)
                    {
                        if (extension.PublisherName.Equals("Microsoft.ManagedIdentity", StringComparison.OrdinalIgnoreCase)
                                && extension.TypeName.Equals("ManagedIdentityExtensionForLinux", StringComparison.OrdinalIgnoreCase))
                        {
                            msiExtension = extension;
                            break;
                        }
                    }
                    Assert.NotNull(msiExtension);

                    // Check the default token port
                    //
                    var publicSettings = msiExtension.PublicSettings;
                    Assert.NotNull(publicSettings);
                    Assert.True(publicSettings.ContainsKey("port"));
                    Object portObj = publicSettings["port"];
                    Assert.NotNull(portObj);
                    int? port = ObjectToInteger(portObj);
                    Assert.True(port.HasValue);
                    Assert.NotNull(port);
                    Assert.Equal(50342, port);

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();

                    // Ensure NO role assigned for resource group
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");

                    virtualMachine = virtualMachine.Update()
                        .WithManagedServiceIdentity(50343)
                        .Apply();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityTenantId);

                    extensions = virtualMachine.ListExtensions();
                    msiExtension = null;
                    foreach (var extension in extensions.Values)
                    {
                        if (extension.PublisherName.Equals("Microsoft.ManagedIdentity", StringComparison.OrdinalIgnoreCase)
                                && extension.TypeName.Equals("ManagedIdentityExtensionForLinux", StringComparison.OrdinalIgnoreCase))
                        {
                            msiExtension = extension;
                            break;
                        }
                    }
                    Assert.NotNull(msiExtension);
                    // Check the default token port
                    //
                    publicSettings = msiExtension.PublicSettings;
                    Assert.NotNull(publicSettings);
                    Assert.True(publicSettings.ContainsKey("port"));
                    portObj = publicSettings["port"];
                    Assert.NotNull(portObj);
                    port = ObjectToInteger(portObj);
                    Assert.True(port.HasValue);
                    Assert.NotNull(port);
                    Assert.Equal(50343, port);

                    rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }


        [Fact]
        public void CanSetMSIOnNewVMWithRoleAssignedToCurrentResourceGroup()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var region = Region.USSouthCentral;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();

                    IVirtualMachine virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithManagedServiceIdentity()
                        .WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityTenantId);


                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // Validate service created service principal
                    //
                    IServicePrincipal servicePrincipal = authenticatedClient
                            .ServicePrincipals
                            .GetById(virtualMachine.ManagedServiceIdentityPrincipalId);

                    Assert.NotNull(servicePrincipal);
                    Assert.NotNull(servicePrincipal.Inner);

                    // Ensure the MSI extension is set
                    //
                    var extensions = virtualMachine.ListExtensions();
                    bool extensionFound = false;
                    foreach (var extension in extensions.Values)
                    {
                        if (extension.PublisherName.Equals("Microsoft.ManagedIdentity", StringComparison.OrdinalIgnoreCase)
                                && extension.TypeName.Equals("ManagedIdentityExtensionForLinux", StringComparison.OrdinalIgnoreCase))
                        {
                            extensionFound = true;
                            break;
                        }
                    }
                    Assert.True(extensionFound);

                    // Ensure role assigned
                    //
                    IResourceGroup resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var roleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    bool found = false;
                    foreach (var roleAssignment in roleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanSetMSIOnNewVMWithMultipleRoleAssignments()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var storageAccountName = TestUtilities.GenerateName("ja");
                var region = Region.USSouthCentral;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    

                    IStorageAccount storageAccount = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(region)
                            .WithNewResourceGroup(groupName)
                            .Create();

                    var resourceGroup = azure.ResourceGroups.GetByName(storageAccount.ResourceGroupName);

                    IVirtualMachine virtualMachine = azure.VirtualMachines
                            .Define(vmName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(groupName)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                            .WithRootUsername("Foo12")
                            .WithRootPassword("abc!@#F0orL")
                            .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                            .WithOSDiskCaching(CachingTypes.ReadWrite)
                            .WithManagedServiceIdentity()
                            .WithRoleBasedAccessTo(resourceGroup.Id, BuiltInRole.Contributor)
                            .WithRoleBasedAccessTo(storageAccount.Id, BuiltInRole.Contributor)
                            .Create();

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // Validate service created service principal
                    //
                    IServicePrincipal servicePrincipal = authenticatedClient
                            .ServicePrincipals
                            .GetById(virtualMachine.ManagedServiceIdentityPrincipalId);

                    Assert.NotNull(servicePrincipal);
                    Assert.NotNull(servicePrincipal.Inner);

                    // Ensure the MSI extension is set
                    //
                    var extensions = virtualMachine.ListExtensions();
                    bool extensionFound = false;
                    foreach (var extension in extensions.Values)
                    {
                        if (extension.PublisherName.Equals("Microsoft.ManagedIdentity", StringComparison.OrdinalIgnoreCase)
                                && extension.TypeName.Equals("ManagedIdentityExtensionForLinux", StringComparison.OrdinalIgnoreCase))
                        {
                            extensionFound = true;
                            break;
                        }
                    }
                    Assert.True(extensionFound);

                    
                    // Ensure role assigned for resource group
                    //

                    var rgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");

                    // Ensure role assigned for storage account
                    //
                    var stgRoleAssignments = authenticatedClient.RoleAssignments.ListByScope(storageAccount.Id);
                    Assert.NotNull(stgRoleAssignments);
                    found = false;
                    foreach (var roleAssignment in stgRoleAssignments)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Storage account should have a role assignment with virtual machine MSI principal");
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact]
        public void CanSetMSIOnExistingVMWithRoleAssignments()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var groupName = TestUtilities.GenerateName("rgmsi");
                var storageAccountName = TestUtilities.GenerateName("ja");
                var region = Region.USSouthCentral;
                var vmName = "javavm";
                IAzure azure = null;
                try
                {
                    azure = TestHelper.CreateRollupClient();
                    IVirtualMachine virtualMachine = azure.VirtualMachines
                        .Define(vmName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("Foo12")
                        .WithRootPassword("abc!@#F0orL")
                        .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                        .WithOSDiskCaching(CachingTypes.ReadWrite)
                        .WithManagedServiceIdentity()
                        .Create();

                    Assert.NotNull(virtualMachine);
                    Assert.NotNull(virtualMachine.Inner);
                    Assert.True(virtualMachine.IsManagedServiceIdentityEnabled);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityPrincipalId);
                    Assert.NotNull(virtualMachine.ManagedServiceIdentityTenantId);

                    // Ensure the MSI extension is set
                    //
                    var extensions = virtualMachine.ListExtensions();
                    bool extensionFound = false;
                    foreach (var extension in extensions.Values)
                    {
                        if (extension.PublisherName.Equals("Microsoft.ManagedIdentity", StringComparison.OrdinalIgnoreCase)
                                && extension.TypeName.Equals("ManagedIdentityExtensionForLinux", StringComparison.OrdinalIgnoreCase))
                        {
                            extensionFound = true;
                            break;
                        }
                    }
                    Assert.True(extensionFound);

                    var authenticatedClient = TestHelper.CreateAuthenticatedClient();
                    // Ensure NO role assigned for resource group
                    //
                    var resourceGroup = azure.ResourceGroups.GetByName(virtualMachine.ResourceGroupName);
                    var rgRoleAssignments1 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(rgRoleAssignments1);
                    bool found = false;
                    foreach (var roleAssignment in rgRoleAssignments1)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.False(found, "Resource group should not have a role assignment with virtual machine MSI principal");

                    virtualMachine.Update()
                            .WithManagedServiceIdentity()
                            .WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                            .Apply();

                    // Ensure role assigned for resource group
                    //
                    var roleAssignments2 = authenticatedClient.RoleAssignments.ListByScope(resourceGroup.Id);
                    Assert.NotNull(roleAssignments2);
                    foreach (var roleAssignment in roleAssignments2)
                    {
                        if (roleAssignment.PrincipalId != null && roleAssignment.PrincipalId.Equals(virtualMachine.ManagedServiceIdentityPrincipalId, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    Assert.True(found, "Resource group should have a role assignment with virtual machine MSI principal");

                    // Try adding the same role again, implementation should handle 'RoleAlreadyExists' error code and resume
                    //
                    virtualMachine.Update()
                        .WithManagedServiceIdentity()
                        .WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole.Contributor)
                        .Apply();
                }
                finally
                {
                    try
                    {
                        if (azure != null)
                        {
                            azure.ResourceGroups.BeginDeleteByName(groupName);
                        }
                    }
                    catch { }
                }
            }
        }

        private static int? ObjectToInteger(object obj)
        {
            int? result = null;
            if (obj != null)
            {
                if (obj is Int16)
                {
                    result = (int)((Int16)obj);
                }
                else if (obj is Int32)
                {
                    result = (int)obj;
                }
                else if (obj is Int64)
                {
                    result = (int)((Int64)obj);
                }
                else
                {
                    result = int.Parse((string)obj);
                }
            }
            return result;
        }
    }
}
