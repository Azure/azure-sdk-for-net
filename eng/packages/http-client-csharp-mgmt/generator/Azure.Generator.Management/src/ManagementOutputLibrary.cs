// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System;
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
            foreach (var client in ManagementClientGenerator.Instance.InputLibrary.AllClients)
            {
                BuildResourceCore(resources, collections, client);
            }
            return (resources, collections);
        }

        private static readonly IReadOnlyDictionary<ResourceScope, Type> _scopeToTypes = new Dictionary<ResourceScope, Type>
        {
            [ResourceScope.ResourceGroup] = typeof(ResourceGroupResource),
            [ResourceScope.Subscription] = typeof(SubscriptionResource),
            [ResourceScope.Tenant] = typeof(TenantResource),
        };

        // TODO -- build extensions and their corresponding mockable resources
        private IReadOnlyList<MockableResourceProvider> BuildResourceExtensions(IEnumerable<ResourceClientProvider> resources)
        {
            // walk through all resources to figure out their scopes
            var scopeCandidates = new Dictionary<ResourceScope, List<ResourceClientProvider>>
            {
                [ResourceScope.ResourceGroup] = [],
                [ResourceScope.Subscription] = [],
                [ResourceScope.Tenant] = [],
            };
            foreach (var resource in resources)
            {
                scopeCandidates[resource.ResourceScope].Add(resource);
            }

            var mockableResources = new List<MockableResourceProvider>(scopeCandidates.Count);
            foreach (var (scope, candidates) in scopeCandidates)
            {
                if (candidates.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(_scopeToTypes[scope], candidates);
                    ManagementClientGenerator.Instance.AddTypeToKeep(mockableExtension.Name);
                    mockableResources.Add(mockableExtension);
                }
            }

            return mockableResources;
        }

        private static void BuildResourceCore(List<ResourceClientProvider> resources, List<ResourceCollectionClientProvider> collections, InputClient client)
        {
            // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
            var resourceMetadata = ManagementClientGenerator.Instance.InputLibrary.GetResourceMetadata(client);
            if (resourceMetadata is not null)
            {
                var resource = ResourceClientProvider.Create(client, resourceMetadata);
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
                resources.Add(resource);
                if (resource.ResourceCollection is not null)
                {
                    ManagementClientGenerator.Instance.AddTypeToKeep(resource.ResourceCollection.Name);
                    collections.Add(resource.ResourceCollection);
                }
            }
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var (resources, collections) = BuildResources();
            var extensions = BuildResourceExtensions(resources);
            return [
                .. base.BuildTypeProviders().Where(t => t is not InheritableSystemObjectModelProvider),
                ArmOperation,
                GenericArmOperation,
                .. resources,
                .. collections,
                .. extensions,
                .. resources.Select(r => r.Source),
                .. resources.SelectMany(r => r.SerializationProviders)];
        }
    }
}
