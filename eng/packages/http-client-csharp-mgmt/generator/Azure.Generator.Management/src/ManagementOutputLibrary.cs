// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementOutputLibrary : AzureOutputLibrary
    {   private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        // TODO: replace this with CSharpType to TypeProvider mapping
        private HashSet<CSharpType>? _resourceTypes;
        private HashSet<CSharpType> ResourceTypes => _resourceTypes ??= BuildResourceModels();

        private HashSet<CSharpType> BuildResourceModels()
        {
            var resourceTypes = new HashSet<CSharpType>();

            foreach (var model in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models)
            {
                if (ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(model))
                {
                    var modelProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model);
                    if (modelProvider is not null)
                    {
                        resourceTypes.Add(modelProvider.Type);
                    }
                }
            }
            return resourceTypes;
        }

        private IReadOnlyList<ResourceClientProvider> BuildResources()
        {
            var resources = new List<ResourceClientProvider>();
            foreach (var client in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                var resource = BuildResource(client);
                if (resource is not null)
                {
                    resources.Add(resource);
                }
            }
            return resources;
        }

        private static readonly IReadOnlyDictionary<ResourceScope, Type> _scopeToTypes = new Dictionary<ResourceScope, Type>
        {
            [ResourceScope.ResourceGroup] = typeof(ResourceGroupResource),
            [ResourceScope.Subscription] = typeof(SubscriptionResource),
            [ResourceScope.Tenant] = typeof(TenantResource),
        };

        // TODO -- build extensions and their corresponding mockable resources
        private IReadOnlyList<TypeProvider> BuildExtensions(IReadOnlyList<ResourceClientProvider> resources)
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

            var mockableResources = new List<MockableResourceProvider>(scopeCandidates.Count)
            {
                // add the arm client mockable resource
                new MockableArmClientProvider(typeof(ArmClient), resources)
            };

            foreach (var (scope, candidates) in scopeCandidates)
            {
                if (candidates.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(_scopeToTypes[scope], candidates);
                    mockableResources.Add(mockableExtension);
                }
            }

            var extensionProvider = new ExtensionProvider(mockableResources);
            ManagementClientGenerator.Instance.AddTypeToKeep(extensionProvider.Name);

            return [.. mockableResources, extensionProvider];
        }

        // TODO -- in a near future we might need to change the input, because in real typespec, there is no guarantee that one client corresponds to one resource.
        private static ResourceClientProvider? BuildResource(InputClient client)
        {
            // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
            var resourceMetadata = ManagementClientGenerator.Instance.InputLibrary.GetResourceMetadata(client);
            return resourceMetadata is not null ?
                ResourceClientProvider.Create(client, resourceMetadata) :
                null;
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var resources = BuildResources();
            var collections = resources.Select(r => r.ResourceCollection).WhereNotNull();
            var extensions = BuildExtensions(resources);
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

        internal bool IsResourceModelType(CSharpType type) => ResourceTypes.Contains(type);
    }
}
