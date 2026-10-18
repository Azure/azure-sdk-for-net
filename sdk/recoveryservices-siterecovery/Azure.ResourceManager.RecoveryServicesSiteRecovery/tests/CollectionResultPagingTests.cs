// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Tests
{
    public class CollectionResultPagingTests
    {
        [TestCase("clusters", false)]
        [TestCase("clusters", true)]
        [TestCase("vaultMappings", false)]
        [TestCase("vaultMappings", true)]
        [TestCase("containerMappings", false)]
        [TestCase("containerMappings", true)]
        [TestCase("providers", false)]
        [TestCase("providers", true)]
        [TestCase("vaultStorageMappings", false)]
        [TestCase("vaultStorageMappings", true)]
        [TestCase("classificationMappings", false)]
        [TestCase("classificationMappings", true)]
        public async Task RenamedCollectionHelpersPreservePaging(string operation, bool async)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            string vaultPath = $"/subscriptions/{subscriptionId}/resourceGroups/rg/providers/Microsoft.RecoveryServices/vaults/vault";
            string suffix = operation switch
            {
                "clusters" => "/replicationProtectionClusters",
                "vaultMappings" => "/replicationProtectionContainerMappings",
                "containerMappings" => "/replicationFabrics/fabric/replicationProtectionContainers/container/replicationProtectionContainerMappings",
                "providers" => "/replicationRecoveryServicesProviders",
                "vaultStorageMappings" => "/replicationStorageClassificationMappings",
                "classificationMappings" => "/replicationFabrics/fabric/replicationStorageClassifications/classification/replicationStorageClassificationMappings",
                _ => throw new ArgumentException("Unknown operation", nameof(operation))
            };
            string path = vaultPath + suffix;
            // Vault-wide list operations return resources under their actual fabric/container parents.
            string itemPath = operation switch
            {
                "clusters" or "vaultMappings" => vaultPath + "/replicationFabrics/fabric/replicationProtectionContainers/container" + suffix,
                "providers" => vaultPath + "/replicationFabrics/fabric" + suffix,
                "vaultStorageMappings" => vaultPath + "/replicationFabrics/fabric/replicationStorageClassifications/classification" + suffix,
                _ => path
            };
            string nextLink = $"https://management.azure.com{path}?api-version=2026-02-01&$skiptoken=next";
            var transport = new MockTransport(
                new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{itemPath}/first\",\"name\":\"first\"}}],\"nextLink\":\"{nextLink}\"}}"),
                new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{itemPath}/second\",\"name\":\"second\"}}]}}"));
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            var resourceGroup = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId, "rg"));
            var container = client.GetSiteRecoveryProtectionContainerResource(
                SiteRecoveryProtectionContainerResource.CreateResourceIdentifier(subscriptionId, "rg", "vault", "fabric", "container"));
            var classification = client.GetStorageClassificationResource(
                StorageClassificationResource.CreateResourceIdentifier(subscriptionId, "rg", "vault", "fabric", "classification"));

            var ids = await (operation switch
            {
                "clusters" => GetIds(async, () => resourceGroup.GetSiteRecoveryReplicationProtectionClusterResources("vault"), () => resourceGroup.GetSiteRecoveryReplicationProtectionClusterResourcesAsync("vault")),
                "vaultMappings" => GetIds(async, () => resourceGroup.GetProtectionContainerMappings("vault"), () => resourceGroup.GetProtectionContainerMappingsAsync("vault")),
                "containerMappings" => GetIds(async, () => container.GetProtectionContainerMappings().GetAll(), () => container.GetProtectionContainerMappings().GetAllAsync()),
                "providers" => GetIds(async, () => resourceGroup.GetSiteRecoveryServicesProviders("vault"), () => resourceGroup.GetSiteRecoveryServicesProvidersAsync("vault")),
                "vaultStorageMappings" => GetIds(async, () => resourceGroup.GetStorageClassificationMappings("vault"), () => resourceGroup.GetStorageClassificationMappingsAsync("vault")),
                "classificationMappings" => GetIds(async, () => classification.GetStorageClassificationMappings().GetAll(), () => classification.GetStorageClassificationMappings().GetAllAsync()),
                _ => throw new ArgumentException("Unknown operation", nameof(operation))
            });

            Assert.That(ids, Is.EqualTo(new[] { itemPath + "/first", itemPath + "/second" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(path));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }

        private static async Task<List<string>> GetIds<T>(bool async, Func<Pageable<T>> syncPages, Func<AsyncPageable<T>> asyncPages) where T : ArmResource
        {
            var ids = new List<string>();
            if (async)
            {
                await foreach (var item in asyncPages())
                {
                    ids.Add(item.Id.ToString());
                }
            }
            else
            {
                foreach (var item in syncPages())
                {
                    ids.Add(item.Id.ToString());
                }
            }
            return ids;
        }
    }
}
