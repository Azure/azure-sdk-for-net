// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Resource = Microsoft.Azure.Management.ContainerRegistry.Models.Resource;
using Sku = Microsoft.Azure.Management.ContainerRegistry.Models.Sku;
using SkuName = Microsoft.Azure.Management.ContainerRegistry.Models.SkuName;


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
        public static Dictionary<string, string> DefaultNewTags = new Dictionary<string, string>
        {
            { "key2","value2"},
            { "key3","value3"},
            { "key4","value4"}
        };

        public static string DefaultWebhookServiceUri = "http://www.microsoft.com";
        public static string DefaultWebhookScope = "hello-world";

        public static string GetDefaultRegistryLocation(ResourceManagementClient client)
        {
            Provider provider = client.Providers.Get(ContainerRegistryNamespace);
            ProviderResourceType resourceType = provider.ResourceTypes.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.ResourceType, ContainerRegistryResourceType));
            return resourceType.Locations.First();
        }

        public static string GetNonDefaultRegistryLocation(ResourceManagementClient client, string defaultLocation)
        {
            Provider provider = client.Providers.Get(ContainerRegistryNamespace);
            ProviderResourceType resourceType = provider.ResourceTypes.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.ResourceType, ContainerRegistryResourceType));
            return resourceType.Locations.First(l => !NormalizeLocation(l).Equals(defaultLocation));
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
            return client.ResourceGroups.CreateOrUpdate(
                TestUtilities.GenerateName("acr_rg"),
                new ResourceGroup
                {
                    Location = GetDefaultRegistryLocation(client)
                });
        }

        public static StorageAccount CreateStorageAccount(StorageManagementClient client, ResourceGroup resourceGroup)
        {
            return client.StorageAccounts.Create(
                resourceGroup.Name,
                TestUtilities.GenerateName("acrstorage"),
                new StorageAccountCreateParameters
                {
                    Location = resourceGroup.Location,
                    Sku = new Microsoft.Azure.Management.Storage.Models.Sku
                    {
                        Name = Microsoft.Azure.Management.Storage.Models.SkuName.StandardLRS
                    },
                    Kind = Kind.Storage
                });
        }

        public static Registry CreateClassicContainerRegistry(ContainerRegistryManagementClient client, ResourceGroup resourceGroup, StorageAccount storageAccount)
        {
            return client.Registries.Create(
                resourceGroup.Name,
                TestUtilities.GenerateName("acrregistry"),
                new Registry
                {
                    Location = resourceGroup.Location,
                    Sku = new Sku
                    {
                        Name = SkuName.Classic
                    },
                    StorageAccount = new StorageAccountProperties
                    {
                        Id = storageAccount.Id
                    },
                    Tags = DefaultTags
                });
        }

        public static Registry CreateManagedContainerRegistry(ContainerRegistryManagementClient client, string resourceGroupName, string location)
        {
            return client.Registries.Create(
                resourceGroupName,
                TestUtilities.GenerateName("acrregistry"),
                new Registry
                {
                    Location = location,
                    Sku = new Sku
                    {
                        Name = SkuName.Premium
                    },
                    Tags = DefaultTags
                });
        }

        public static Webhook CreatedContainerRegistryWebhook(ContainerRegistryManagementClient client, string resourceGroupName, string registryName, string location)
        {
            return client.Webhooks.Create(
                resourceGroupName,
                registryName,
                TestUtilities.GenerateName("acrwebhook"),
                new WebhookCreateParameters
                {
                    Location = location,
                    ServiceUri = DefaultWebhookServiceUri,
                    Actions = new List<string>() { WebhookAction.Push },
                    Tags = DefaultTags
                });
        }

        public static Replication CreatedContainerRegistryReplication(ContainerRegistryManagementClient client, string resourceGroupName, string registryName, string location)
        {
            return client.Replications.Create(
                resourceGroupName,
                registryName,
                NormalizeLocation(location),
                new Replication
                {
                    Location = location,
                    Tags = DefaultTags
                });
        }

        public static void ValidateResourceDefaultTags(Resource resource)
        {
            ValidateResource(resource);
            Assert.NotNull(resource.Tags);
            Assert.Equal(2, resource.Tags.Count);
            Assert.Equal("value1", resource.Tags["key1"]);
            Assert.Equal("value2", resource.Tags["key2"]);
        }

        public static void ValidateResourceDefaultNewTags(Resource resource)
        {
            ValidateResource(resource);
            Assert.NotNull(resource.Tags);
            Assert.Equal(3, resource.Tags.Count);
            Assert.Equal("value2", resource.Tags["key2"]);
            Assert.Equal("value3", resource.Tags["key3"]);
            Assert.Equal("value4", resource.Tags["key4"]);
        }

        private static void ValidateResource(Resource resource)
        {
            Assert.NotNull(resource);
            Assert.NotNull(resource.Id);
            Assert.NotNull(resource.Name);
            Assert.NotNull(resource.Type);
            Assert.NotNull(resource.Location);
        }

        private static string NormalizeLocation(string location)
        {
            return location.Replace(" ", "").ToLower();
        }
    }
}
