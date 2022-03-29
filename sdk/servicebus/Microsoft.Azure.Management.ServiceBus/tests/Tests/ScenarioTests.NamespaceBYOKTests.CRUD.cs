// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    using SkuName = Microsoft.Azure.Management.ServiceBus.Models.SkuName;
    using System.Threading;

    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceBYOKCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroupCluster = ServiceBusManagementHelper.ResourceGroupCluster;

                //var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                //if (string.IsNullOrWhiteSpace(resourceGroup))
                //{
                //    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                //    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                //}

                var keyVaultName = "SDKTestingKey1";
                var KeyName = "sdktestingkey11";

                // Create Namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                //Check namespace name available
                var checknamespaceavailable = ServiceBusManagementClient.Namespaces.CheckNameAvailabilityMethod(new CheckNameAvailability() { Name = namespaceName });

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Premium,
                            Tier = SkuTier.Premium
                        },
                        Tags = new Dictionary<string, string>()
                        {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                        },
                        Identity = new Identity() { Type = ManagedServiceIdentityType.SystemAssigned }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));

                // Create KeyVault
                Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters vaultparams = new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters();
                var accesPolicies = new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry()
                {
                    ObjectId = createNamespaceResponse.Identity.PrincipalId,
                    TenantId = Guid.Parse(createNamespaceResponse.Identity.TenantId),
                    Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions()
                    {
                        Keys = new List<string> { "get", "wrapKey", "unwrapKey" }
                    }
                };

                Vault getVaultRsponse = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);

                vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);

                vaultparams.Properties.AccessPolicies.Add(accesPolicies);

                var updateVault = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                                
                // Encrypt data in Event Hub namespace Customer managed key from keyvault

                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroupCluster, namespaceName);

                getNamespaceResponse.Encryption = new Encryption()
                {
                    KeySource = KeySource.MicrosoftKeyVault,
                    KeyVaultProperties = new[] {
                            new KeyVaultProperties()
                            {
                                KeyName = KeyName,
                                KeyVaultUri = updateVault.Properties.VaultUri,
                                KeyVersion = ""
                            }
                        }
                };

                var updateNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName, getNamespaceResponse);

                Vault getVaultRsponse1 = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);
                vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);
                vaultparams.Properties.AccessPolicies.Remove(accesPolicies);
                var updateVault1 = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);
                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                //Delete the namesapce within the cluster

                // Delete namespace
                ServiceBusManagementClient.Namespaces.DeleteWithHttpMessagesAsync(resourceGroupCluster, namespaceName, null, new CancellationToken()).ConfigureAwait(false);
            }
        }
    }
}