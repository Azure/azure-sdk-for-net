// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
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
    {
        private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        private PageableWrapperProvider? _pageableWrapper;
        internal PageableWrapperProvider PageableWrapper => _pageableWrapper ??= new PageableWrapperProvider(false);

        private PageableWrapperProvider? _asyncPageableWrapper;
        internal PageableWrapperProvider AsyncPageableWrapper => _asyncPageableWrapper ??= new PageableWrapperProvider(true);

        // TODO: replace this with CSharpType to TypeProvider mapping
        private HashSet<CSharpType>? _resourceTypes;
        private HashSet<CSharpType> ResourceTypes => _resourceTypes ??= BuildResourceModels();

        // TODO: replace this with CSharpType to TypeProvider mapping and move this logic to ModelFactoryVisitor
        private HashSet<CSharpType>? _modelFactoryModels;
        private HashSet<CSharpType> ModelFactoryModels => _modelFactoryModels ??= BuildModelFactoryModels();
        internal HashSet<CSharpType> BuildModelFactoryModels()
        {
            var result = new HashSet<CSharpType>();
            foreach (var inputModel in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models)
            {
                var model = ManagementClientGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null && IsModelFactoryModel(model))
                {
                    result.Add(model.Type);
                }
            }
            return result;
        }

        private static bool IsModelFactoryModel(ModelProvider model)
        {
            // A model is a model factory model if it is public and it has at least one public property without a setter.
            return model.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public) && EnumerateAllPublicProperties(model).Any(prop => !prop.Body.HasSetter);

            IEnumerable<PropertyProvider> EnumerateAllPublicProperties(ModelProvider current)
            {
                var currentModel = current;
                foreach (var property in currentModel.Properties)
                {
                    if (property.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                    {
                        yield return property;
                    }
                }

                while (currentModel.BaseModelProvider is not null)
                {
                    currentModel = currentModel.BaseModelProvider;
                    foreach (var property in currentModel.Properties)
                    {
                        if (property.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                        {
                            yield return property;
                        }
                    }
                }
            }
        }

        internal bool IsModelFactoryModelType(CSharpType type) => ModelFactoryModels.Contains(type);

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
            foreach (var resourceMetadata in ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas)
            {
                var resource = ResourceClientProvider.Create(resourceMetadata);
                resources.Add(resource);
            }
            return resources;
        }

        private static readonly IReadOnlyDictionary<ResourceScope, Type> _scopeToTypes = new Dictionary<ResourceScope, Type>
        {
            [ResourceScope.ResourceGroup] = typeof(ResourceGroupResource),
            [ResourceScope.Subscription] = typeof(SubscriptionResource),
            [ResourceScope.Tenant] = typeof(TenantResource),
            [ResourceScope.ManagementGroup] = typeof(ManagementGroupResource),
        };

        private IReadOnlyList<TypeProvider> BuildExtensions(IReadOnlyList<ResourceClientProvider> resources)
        {
            // walk through all resources to figure out their scopes
            var scopeCandidates = new Dictionary<ResourceScope, List<ResourceClientProvider>>
            {
                [ResourceScope.ResourceGroup] = [],
                [ResourceScope.Subscription] = [],
                [ResourceScope.Tenant] = [],
                [ResourceScope.ManagementGroup] = [],
            };
            foreach (var resource in resources)
            {
                if (resource.ParentResourceIdPattern is null)
                {
                    scopeCandidates[resource.ResourceScope].Add(resource);
                }
            }

            var mockableArmClientResource = new MockableArmClientProvider(typeof(ArmClient), resources);
            var mockableResources = new List<MockableResourceProvider>(scopeCandidates.Count)
            {
                // add the arm client mockable resource
                mockableArmClientResource
            };
            ManagementClientGenerator.Instance.AddTypeToKeep(mockableArmClientResource.Name);

            foreach (var (scope, candidates) in scopeCandidates)
            {
                if (candidates.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(_scopeToTypes[scope], candidates, []);
                    mockableResources.Add(mockableExtension);
                    ManagementClientGenerator.Instance.AddTypeToKeep(mockableExtension.Name);
                }
            }

            var extensionProvider = new ExtensionProvider(mockableResources);
            ManagementClientGenerator.Instance.AddTypeToKeep(extensionProvider.Name);

            return [.. mockableResources, extensionProvider];
        }

        //private static ManagementMethodMap BuildManagementMethodMap()
        //{
        //    // find all the resources
        //    var resources = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas;
        //    // iterate over all clients to gather all the methods
        //    var methods = new List<InputServiceMethod>();
        //    foreach (var client in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
        //    {
        //        methods.AddRange(client.Methods);
        //    }

        //    throw new NotImplementedException("ManagementMethodMap is not implemented yet. This should be implemented in the future to support non-resource operations on management clients.");
        //}

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            //var methodMap = BuildManagementMethodMap();
            _ = ManagementClientGenerator.Instance.InputLibrary.NonResourceMethodMetadatas; // Ensure models are loaded
            var resources = BuildResources();
            var collections = resources.Select(r => r.ResourceCollection).WhereNotNull();
            var extensions = BuildExtensions(resources);

            return [
                .. base.BuildTypeProviders().Where(t => t is not SystemObjectModelProvider),
                ArmOperation,
                GenericArmOperation,
                .. resources,
                .. collections,
                .. extensions,
                PageableWrapper,
                AsyncPageableWrapper,
                .. resources.Select(r => r.Source),
                .. resources.SelectMany(r => r.SerializationProviders)];
        }

        internal bool IsResourceModelType(CSharpType type) => ResourceTypes.Contains(type);
    }
}
