﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementOutputLibrary : AzureOutputLibrary
    {
        private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        private (IReadOnlyList<ResourceClientProvider> Resources, IReadOnlyList<ResourceCollectionClientProvider> Collection) BuildResources()
        {
            var resources = new List<ResourceClientProvider>();
            var collections = new List<ResourceCollectionClientProvider>();
            foreach (var client in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                BuildResourceCore(resources, collections, client);
            }
            return (resources, collections);
        }

        private static void BuildResourceCore(List<ResourceClientProvider> resources, List<ResourceCollectionClientProvider> collections, Microsoft.TypeSpec.Generator.Input.InputClient client)
        {
            // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
            var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
            if (resourceMetadata is not null)
            {
                var resource = new ResourceClientProvider(client);
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
                resources.Add(resource);
                var isSingleton = resourceMetadata.Arguments?.TryGetValue("isSingleton", out var result) == true ? result.ToObjectFromJson<string>() == "true" : false;
                if (!isSingleton)
                {
                    var collection = new ResourceCollectionClientProvider(client, resource);
                    ManagementClientGenerator.Instance.AddTypeToKeep(collection.Name);
                    collections.Add(collection);
                }
            }

            foreach (var child in client.Children)
            {
                BuildResourceCore(resources, collections, child);
            }
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var (resources, collections) = BuildResources();
            return [.. base.BuildTypeProviders(), ArmOperation, GenericArmOperation, .. resources, .. collections, .. resources.Select(r => r.Source)];
        }
    }
}
