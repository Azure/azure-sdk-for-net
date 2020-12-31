// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace EventHub.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading;    
    using Microsoft.Azure.Management.EventHub;
    using Microsoft.Azure.Management.EventHub.Models;
    using Microsoft.Azure.Management.KeyVault;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests
    {
        [Fact]
        public void NamespaceBYOKCreateGetUpdateDelete()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                InitializeClients(context);

                var location = "West US";

                var resourceGroup = string.Empty;

                var resourceGroupCluster = EventHubManagementHelper.ResourceGroupCluster;

                var testClusterName = EventHubManagementHelper.TestClusterName;

                var keyVaultName = "SDKTestingKey";
                var KeyName = "sdktestingkey1";

                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(EventHubManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                var namespaceName = TestUtilities.GenerateName(EventHubManagementHelper.NamespacePrefix);

                try
                {

                    Cluster getClusterResponse = EventHubManagementClient.Clusters.Get(resourceGroupCluster, testClusterName);

                    var checkNameAvailable = EventHubManagementClient.Namespaces.CheckNameAvailability(new CheckNameAvailabilityParameter() { Name = namespaceName });                    

                    var createNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName,
                        new EHNamespace()
                        {
                            Location = location,
                            Sku = new Microsoft.Azure.Management.EventHub.Models.Sku
                            {
                                Name = Microsoft.Azure.Management.EventHub.Models.SkuName.Standard,
                                Tier = SkuTier.Standard
                            },
                            Tags = new Dictionary<string, string>()
                            {
                            {"tag1", "value1"},
                            {"tag2", "value2"}
                            },
                            IsAutoInflateEnabled = false,
                            MaximumThroughputUnits = 0,
                            ClusterArmId = getClusterResponse.Id,
                            Identity = new Identity() { Type = IdentityType.SystemAssigned}
                        });
                    
                    Assert.NotNull(createNamespaceResponse);
                    Assert.Equal(namespaceName, createNamespaceResponse.Name);
                    Assert.Equal(getClusterResponse.Id, createNamespaceResponse.ClusterArmId);
                    Assert.False(createNamespaceResponse.IsAutoInflateEnabled);
                    Assert.Equal(0, createNamespaceResponse.MaximumThroughputUnits);

                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Create KeyVault
                    Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters vaultparams = new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters();
                    var accesPolicies = new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry()
                    {
                        ObjectId = createNamespaceResponse.Identity.PrincipalId,
                        TenantId = Guid.Parse(createNamespaceResponse.Identity.TenantId),
                        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions()
                        {
                            Keys = new List<string> { "get", "wrapKey", "unwrapKey"}
                        }
                    };                   


                    Vault getVaultRsponse = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);

                    vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);

                    vaultparams.Properties.AccessPolicies.Add(accesPolicies);

                    var updateVault = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);
                    
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                    // Encrypt data in Event Hub namespace Customer managed key from keyvault

                    var getNamespaceResponse = EventHubManagementClient.Namespaces.Get(resourceGroupCluster, namespaceName);

                    getNamespaceResponse.Encryption = new Encryption() {
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

                    var updateNamespaceResponse = this.EventHubManagementClient.Namespaces.CreateOrUpdate(resourceGroupCluster, namespaceName, getNamespaceResponse);

                    Vault getVaultRsponse1 = KeyVaultManagementClient.Vaults.Get(resourceGroupCluster, keyVaultName);
                    vaultparams = new VaultCreateOrUpdateParameters(getVaultRsponse.Location, getVaultRsponse.Properties);
                    vaultparams.Properties.AccessPolicies.Remove(accesPolicies);
                    var updateVault1 = KeyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroupCluster, keyVaultName, vaultparams);
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                    //Delete the namesapce within the cluster
                }
                finally
                {
                    //Delete Resource Group
                    this.EventHubManagementClient.Namespaces.DeleteAsync(resourceGroupCluster, namespaceName, default(CancellationToken)).ConfigureAwait(false);
                    Console.WriteLine("End of EH2018 Namespace CRUD IPFilter Rules test");
                }

            }
        }
    }
}
