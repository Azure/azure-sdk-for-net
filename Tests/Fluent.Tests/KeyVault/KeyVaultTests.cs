// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Fluent.Tests.KeyVault
{

    public class ManageKeyVault {

        /**
         * Main entry point.
         * @param args the parameters
         */
        [Fact]
        public void CanCRUDKeyVault()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string vaultName1 = TestUtilities.GenerateName("vault1");
                string vaultName2 = TestUtilities.GenerateName("vault2");
                string rgName = TestUtilities.GenerateName("rgNEMV");
                
                IKeyVaultManager manager = TestHelper.CreateKeyVaultManager();

                var spnCredentialsClientId = HttpMockServer.Variables[ConnectionStringKeys.ServicePrincipalKey];

                try
                {
                    IVault vault1 = manager.Vaults
                            .Define(vaultName1)
                            .WithRegion(Region.USWest)
                            .WithNewResourceGroup(rgName)
                            .WithEmptyAccessPolicy()
                            .Create();

                    Assert.NotNull(vault1);
                    Assert.Equal(vaultName1, vault1.Name);
                    Assert.Equal(0, vault1.AccessPolicies.Count);
                    vault1 = vault1.Update()
                            .DefineAccessPolicy()
                                .ForServicePrincipal(spnCredentialsClientId)
                                .AllowKeyAllPermissions()
                                .AllowSecretPermissions(SecretPermissions.Get)
                                .AllowSecretPermissions(SecretPermissions.List)
                                .Attach()
                            .Apply();

                    Assert.NotNull(vault1);
                    Assert.Equal(1, vault1.AccessPolicies.Count);
                    Assert.Equal(KeyPermissions.All.ToString(), vault1.AccessPolicies[0].Permissions.Keys[0]);
                    Assert.Equal(2, vault1.AccessPolicies[0].Permissions.Secrets.Count);

                    vault1 = vault1.Update()
                            .WithDeploymentEnabled()
                            .WithTemplateDeploymentEnabled()
                            .UpdateAccessPolicy(vault1.AccessPolicies.First().ObjectId)
                                .AllowSecretAllPermissions()
                                .Parent()
                            .Apply();

                    Assert.Equal(1, vault1.AccessPolicies.Count);
                    Assert.Equal(3, vault1.AccessPolicies[0].Permissions.Secrets.Count);

                    IVault vault2 = manager.Vaults
                            .Define(vaultName2)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(rgName)
                            .DefineAccessPolicy()
                                .ForServicePrincipal(spnCredentialsClientId)
                                .AllowKeyPermissions(KeyPermissions.Get)
                                .AllowKeyPermissions(KeyPermissions.List)
                                .AllowKeyPermissions(KeyPermissions.Decrypt)
                                .AllowSecretPermissions(SecretPermissions.Get)
                                .Attach()
                            .Create();

                    Assert.Equal(1, vault2.AccessPolicies.Count);
                    Assert.Equal(3, vault2.AccessPolicies[0].Permissions.Keys.Count);

                    var vaults = manager.Vaults.ListByResourceGroup(rgName);
                    Assert.Equal(2, vaults.Count());

                    manager.Vaults.DeleteById(vault1.Id);
                    manager.Vaults.DeleteById(vault2.Id);

                    vaults = manager.Vaults.ListByResourceGroup(rgName);
                    Assert.Equal(0, vaults.Count());
                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }

    }
}