// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementOutputLibrary : AzureOutputLibrary
    {
        private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider ArmOperationOfT => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        private PageableWrapperProvider? _pageableWrapper;
        internal PageableWrapperProvider PageableWrapper => _pageableWrapper ??= new PageableWrapperProvider(false);

        private PageableWrapperProvider? _asyncPageableWrapper;
        internal PageableWrapperProvider AsyncPageableWrapper => _asyncPageableWrapper ??= new PageableWrapperProvider(true);

        private IReadOnlyList<ResourceClientProvider>? _resourceClients;
        internal IReadOnlyList<ResourceClientProvider> ResourceClients => _resourceClients ??= BuildResources();

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

        private record ResourcesAndNonResourceMethodsInScope(
            List<ResourceClientProvider> ResourceClients,
            List<NonResourceMethod> NonResourceMethods);

        private IReadOnlyList<TypeProvider> BuildExtensions()
        {
            // walk through all resources to figure out their scopes
            var resourcesAndMethodsPerScope = new Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope>
            {
                [ResourceScope.ResourceGroup] = new([], []),
                [ResourceScope.Subscription] = new([], []),
                [ResourceScope.Tenant] = new([], []),
                [ResourceScope.ManagementGroup] = new([], []),
            };
            foreach (var resource in ResourceClients)
            {
                if (resource.ParentResourceIdPattern is null)
                {
                    resourcesAndMethodsPerScope[resource.ResourceScope].ResourceClients.Add(resource);
                }
            }
            foreach (var nonResourceMethod in ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods)
            {
                if (nonResourceMethod.CarrierResource == null) // this has no been picked up by a resource
                {
                    resourcesAndMethodsPerScope[nonResourceMethod.OperationScope].NonResourceMethods.Add(nonResourceMethod);
                }
            }

            var mockableArmClientResource = new MockableArmClientProvider(ResourceClients);
            var mockableResources = new List<MockableResourceProvider>(resourcesAndMethodsPerScope.Count)
            {
                // add the arm client mockable resource
                mockableArmClientResource
            };
            ManagementClientGenerator.Instance.AddTypeToKeep(mockableArmClientResource.Name);

            foreach (var (scope, (resources, nonResourceMethods)) in resourcesAndMethodsPerScope)
            {
                if (resources.Count > 0 || nonResourceMethods.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(scope, resources, nonResourceMethods);
                    mockableResources.Add(mockableExtension);
                    ManagementClientGenerator.Instance.AddTypeToKeep(mockableExtension.Name);
                }
            }

            var extensionProvider = new ExtensionProvider(mockableResources);
            ManagementClientGenerator.Instance.AddTypeToKeep(extensionProvider.Name);

            return [.. mockableResources, extensionProvider];
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            var resources = ResourceClients;
            var collections = resources.Select(r => r.ResourceCollection).WhereNotNull();
            var extensions = BuildExtensions();

            return [
                .. base.BuildTypeProviders().Where(t => t is not SystemObjectModelProvider),
                ArmOperation,
                ArmOperationOfT,
                .. resources,
                .. collections,
                .. extensions,
                PageableWrapper,
                AsyncPageableWrapper,
                .. resources.Select(r => r.Source),
                .. resources.SelectMany(r => r.SerializationProviders)];
        }

        internal bool IsResourceModelType(CSharpType type) => TryGetResourceClientProvider(type, out _);

        private IReadOnlyDictionary<CSharpType, ResourceClientProvider>? _resourceDataTypes;
        internal bool TryGetResourceClientProvider(CSharpType resourceDataType, [MaybeNullWhen(false)] out ResourceClientProvider resourceClientProvider)
        {
            _resourceDataTypes ??= ResourceClients.ToDictionary(r => r.ResourceData.Type, r => r);
            return _resourceDataTypes.TryGetValue(resourceDataType, out resourceClientProvider);
        }
    }
}
