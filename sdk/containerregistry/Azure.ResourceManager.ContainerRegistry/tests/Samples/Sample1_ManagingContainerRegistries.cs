// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Managing_ContainerRegistries_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerRegistry.Tests.Samples
{
    public class Sample1_ManagingContainerRegistries
    {
        private ResourceGroupResource _resourceGroup;
        private ContainerRegistryResource _registry;

        [SetUp]
        public async Task CreateResourceGroup()
        {
            #region Snippet:Managing_ContainerRegistries_AuthClient
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Managing_ContainerRegistries_CreateResourceGroup
            string rgName = "myContainerRegistryRG";
            AzureLocation location = AzureLocation.WestUS;
            ArmOperation<ResourceGroupResource> rgOperation = await subscription.GetResourceGroups()
                .CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = rgOperation.Value;
            #endregion

            _resourceGroup = resourceGroup;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateRegistryAsync()
        {
            #region Snippet:Managing_ContainerRegistries_CreateRegistry
            // Create a container registry with Premium SKU
            string registryName = "myContainerRegistry";
            ContainerRegistryData registryData = new ContainerRegistryData(
                AzureLocation.WestUS,
                new ContainerRegistrySku(ContainerRegistrySkuName.Premium))
            {
                IsAdminUserEnabled = true,
                Tags = { ["environment"] = "production" }
            };

            ArmOperation<ContainerRegistryResource> lro = await _resourceGroup.GetContainerRegistries()
                .CreateOrUpdateAsync(WaitUntil.Completed, registryName, registryData);
            ContainerRegistryResource registry = lro.Value;
            Console.WriteLine($"Created registry: {registry.Data.LoginServer}");
            #endregion

            _registry = registry;
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListRegistriesAsync()
        {
            #region Snippet:Managing_ContainerRegistries_ListRegistries
            ContainerRegistryCollection registries = _resourceGroup.GetContainerRegistries();
            await foreach (ContainerRegistryResource registry in registries.GetAllAsync())
            {
                Console.WriteLine($"Registry: {registry.Data.Name}, SKU: {registry.Data.Sku.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetRegistryAsync()
        {
            #region Snippet:Managing_ContainerRegistries_GetRegistry
            ContainerRegistryResource registry = await _resourceGroup.GetContainerRegistries()
                .GetAsync("myContainerRegistry");
            Console.WriteLine($"Registry login server: {registry.Data.LoginServer}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateRegistryAsync()
        {
            #region Snippet:Managing_ContainerRegistries_UpdateRegistry
            ContainerRegistryPatch patch = new ContainerRegistryPatch()
            {
                Tags = { ["environment"] = "staging" },
                Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Standard)
            };
            ArmOperation<ContainerRegistryResource> updateLro = await _registry.UpdateAsync(WaitUntil.Completed, patch);
            ContainerRegistryResource updatedRegistry = updateLro.Value;
            Console.WriteLine($"Updated registry SKU: {updatedRegistry.Data.Sku.Name}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteRegistryAsync()
        {
            #region Snippet:Managing_ContainerRegistries_DeleteRegistry
            await _registry.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine("Registry deleted.");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageWebhooksAsync()
        {
            #region Snippet:Managing_ContainerRegistries_CreateWebhook
            string webhookName = "myWebhook";
            ContainerRegistryWebhookCreateOrUpdateContent webhookContent = new ContainerRegistryWebhookCreateOrUpdateContent(
                _registry.Data.Location)
            {
                ServiceUri = new Uri("https://myapp.example.com/webhook"),
                Actions = { ContainerRegistryWebhookAction.Push, ContainerRegistryWebhookAction.Delete },
                Tags = { ["purpose"] = "ci-cd" }
            };

            ArmOperation<ContainerRegistryWebhookResource> webhookLro = await _registry.GetContainerRegistryWebhooks()
                .CreateOrUpdateAsync(WaitUntil.Completed, webhookName, webhookContent);
            ContainerRegistryWebhookResource webhook = webhookLro.Value;
            Console.WriteLine($"Created webhook: {webhook.Data.Name}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageReplicationsAsync()
        {
            #region Snippet:Managing_ContainerRegistries_CreateReplication
            // Replicate the registry to East US for geo-redundancy
            string replicationName = AzureLocation.EastUS.ToString();
            ArmOperation<ContainerRegistryReplicationResource> replicationLro =
                await _registry.GetContainerRegistryReplications()
                    .CreateOrUpdateAsync(WaitUntil.Completed, replicationName,
                        new ContainerRegistryReplicationData(AzureLocation.EastUS));
            ContainerRegistryReplicationResource replication = replicationLro.Value;
            Console.WriteLine($"Created replication: {replication.Data.Name}, Status: {replication.Data.Status?.DisplayStatus}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ManageScopeMapsAndTokensAsync()
        {
            #region Snippet:Managing_ContainerRegistries_CreateScopeMap
            // Create a scope map granting read/write access to a repository
            string repositoryName = "hello-world";
            ScopeMapData scopeMapData = new ScopeMapData()
            {
                Description = "Read/write access to hello-world repository",
                Actions =
                {
                    $"repositories/{repositoryName}/content/read",
                    $"repositories/{repositoryName}/content/write",
                    $"repositories/{repositoryName}/metadata/read"
                }
            };

            ArmOperation<ScopeMapResource> scopeMapLro = await _registry.GetScopeMaps()
                .CreateOrUpdateAsync(WaitUntil.Completed, "myScopeMap", scopeMapData);
            ScopeMapResource scopeMap = scopeMapLro.Value;
            Console.WriteLine($"Created scope map: {scopeMap.Data.Name}");
            #endregion

            #region Snippet:Managing_ContainerRegistries_CreateToken
            // Create a token associated with the scope map
            ContainerRegistryTokenData tokenData = new ContainerRegistryTokenData()
            {
                ScopeMapId = scopeMap.Id
            };

            ArmOperation<ContainerRegistryTokenResource> tokenLro = await _registry.GetContainerRegistryTokens()
                .CreateOrUpdateAsync(WaitUntil.Completed, "myRegistryToken", tokenData);
            ContainerRegistryTokenResource token = tokenLro.Value;
            Console.WriteLine($"Created token: {token.Data.Name}, Status: {token.Data.Status}");
            #endregion
        }
    }
}
