// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ContainerRegistry.Tests
{
    public class ContainerRegistryTestUtilities
    {
        public const string ContainerRegistryNamespace = "Microsoft.ContainerRegistry";
        public const string ContainerRegistryResourceType = "registries";

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            { "key1","value1"},
            { "key2","value2"}
        };

        public static string GetDefaultRegistryLocation(ResourceManagementClient client)
        {
            Provider provider = client.Providers.Get(ContainerRegistryNamespace);
            ProviderResourceType resourceType = provider.ResourceTypes.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.ResourceType, ContainerRegistryResourceType));
            string location = resourceType.Locations.First();
            return NormalizeLocation(location);
        }

        public static string GetNonDefaultRegistryLocation(ResourceManagementClient client)
        {
            Provider provider = client.Providers.Get(ContainerRegistryNamespace);
            ProviderResourceType resourceType = provider.ResourceTypes.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.ResourceType, ContainerRegistryResourceType));
            string location = resourceType.Locations.ToArray()[1];
            return NormalizeLocation(location);
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            StorageManagementClient client = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            return client;
        }

        public static ContainerRegistryManagementClient GetContainerRegistryManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ContainerRegistryManagementClient client = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client)
        {
            var rgName = TestUtilities.GenerateName("acr_rg");

            return client.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup
            {
                Location = GetDefaultRegistryLocation(client)
            });
        }

        public static string CreateStorageAccount(StorageManagementClient client, ResourceGroup resourceGroup)
        {
            string storageName = TestUtilities.GenerateName("acrstorage");

            var createRequest = client.StorageAccounts.Create(resourceGroup.Name, storageName, new StorageAccountCreateParameters
            {
                Location = resourceGroup.Location,
                Sku = new Microsoft.Azure.Management.Storage.Models.Sku { Name = SkuName.StandardLRS },
                Kind = Kind.Storage
            });

            return storageName;
        }

        public static string CreateContainerRegistry(ContainerRegistryManagementClient client, ResourceGroup resourceGroup, string storageName, string storageKey)
        {
            string registryName = TestUtilities.GenerateName("acrregistry");
            RegistryCreateParameters parameters = GetDefaultRegistryCreateParameters(resourceGroup, storageName, storageKey);

            var createRequest = client.Registries.Create(resourceGroup.Name, registryName, parameters);

            return registryName;
        }

        public static RegistryCreateParameters GetDefaultRegistryCreateParameters(ResourceGroup resourceGroup, string storageName, string storageKey)
        {
            RegistryCreateParameters parameters = new RegistryCreateParameters
            {
                Location = resourceGroup.Location,
                Sku = new Microsoft.Azure.Management.ContainerRegistry.Models.Sku
                {
                    Name = "Basic"
                },
                StorageAccount = new StorageAccountParameters
                {
                    Name = storageName,
                    AccessKey = storageKey
                },
                Tags = DefaultTags
            };

            return parameters;
        }

        public static string GetStorageAccessKey(StorageManagementClient client, ResourceGroup resourceGroup, string storageName)
        {
            return client.StorageAccounts.ListKeys(resourceGroup.Name, storageName).Keys[0].Value;
        }

        public static void VerifyRegistryProperties(Registry registry, string storageName, bool useDefaults)
        {
            Assert.NotNull(registry);
            Assert.NotNull(registry.Id);
            Assert.NotNull(registry.Name);
            Assert.NotNull(registry.Location);
            Assert.NotNull(registry.Sku);
            Assert.Equal(registry.Sku.Name, "Basic");
            Assert.Equal(registry.Sku.Tier, Microsoft.Azure.Management.ContainerRegistry.Models.SkuTier.Basic);
            Assert.Equal(registry.ProvisioningState, Microsoft.Azure.Management.ContainerRegistry.Models.ProvisioningState.Succeeded);
            Assert.NotNull(registry.AdminUserEnabled);
            Assert.NotNull(registry.LoginServer);
            Assert.NotNull(registry.CreationDate);
            Assert.NotNull(registry.StorageAccount);
            Assert.NotNull(registry.StorageAccount.Name);

            Assert.Equal(registry.StorageAccount.Name, storageName);

            if (useDefaults)
            {
                Assert.Equal(registry.AdminUserEnabled, false);
                Assert.NotNull(registry.Tags);
                Assert.Equal(2, registry.Tags.Count);
                Assert.Equal(registry.Tags["key1"], "value1");
                Assert.Equal(registry.Tags["key2"], "value2");
            }
        }

        private static string NormalizeLocation(string location)
        {
            return location.Replace(" ", "").ToLower();
        }
    }
}
