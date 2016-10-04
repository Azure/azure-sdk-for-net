// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent.KeyVault;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.KeyVault.Models;
using System.Linq;
using Xunit;

namespace Fluent.Tests.KeyVault
{

    public class ManageKeyVault {

        /**
         * Main entry point.
         * @param args the parameters
         */
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void Test()
        {
            string vaultName1 = ResourceNamer.RandomResourceName("vault1", 20);
            string vaultName2 = ResourceNamer.RandomResourceName("vault2", 20);
            string rgName = ResourceNamer.RandomResourceName("rgNEMV", 24);

            IKeyVaultManager manager = this.CreateKeyVaultManager();

            try
            {
                IVault vault1 = manager.Vaults
                        .Define(vaultName1)
                        .WithRegion(Region.US_WEST)
                        .WithNewResourceGroup(rgName)
                        .WithEmptyAccessPolicy()
                        .Create();

                Assert.NotNull(vault1);
                Assert.Equal(vaultName1, vault1.Name);
                Assert.Equal(0, vault1.AccessPolicies.Count);

                vault1 = vault1.Update()
                        .DefineAccessPolicy()
                            .ForServicePrincipal(AzureCredentials.FromFile(@"C:\my.azureauth").ClientId)
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
                        .WithRegion(Region.US_EAST)
                        .WithExistingResourceGroup(rgName)
                        .DefineAccessPolicy()
                            .ForServicePrincipal(AzureCredentials.FromFile(@"C:\my.azureauth").ClientId)
                            .AllowKeyPermissions(KeyPermissions.Get)
                            .AllowKeyPermissions(KeyPermissions.List)
                            .AllowKeyPermissions(KeyPermissions.Decrypt)
                            .AllowSecretPermissions(SecretPermissions.Get)
                            .Attach()
                        .Create();

                Assert.Equal(1, vault2.AccessPolicies.Count);
                Assert.Equal(3, vault2.AccessPolicies[0].Permissions.Keys.Count);

                var vaults = manager.Vaults.ListByGroup(rgName);
                Assert.Equal(2, vaults.Count);

                manager.Vaults.Delete(vault1.Id);
                manager.Vaults.Delete(vault2.Id);

                vaults = manager.Vaults.ListByGroup(rgName);
                Assert.Equal(0, vaults.Count);
            }
            finally
            {
                TestHelper.CreateResourceManager().ResourceGroups.Delete(rgName);
            }
        }

        public IKeyVaultManager CreateKeyVaultManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            return KeyVaultManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }
    }
}