// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Utilities;
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

        private ProviderConstantsProvider? _providerConstants;
        internal ProviderConstantsProvider ProviderConstants => _providerConstants ??= new ProviderConstantsProvider();

        // TODO -- this is really a bad practice that this map is not built in one place, but we are building it while generating stuff and in the meantime we might read it.
        // but currently this is the best we could do right now.
        internal Dictionary<TypeProvider, string> PageableMethodScopes { get; } = new();

        private IReadOnlyDictionary<string, ResourceClientProvider>? _resourcesByIdDict;
        private IReadOnlyList<ResourceClientProvider>? _resources;
        private IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections;
        private IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableResourcesByScopeDict;
        private IReadOnlyList<MockableResourceProvider>? _mockableResources;
        private ExtensionProvider? _extensionProvider;

        internal IReadOnlyList<ResourceClientProvider> ResourceProviders => GetValue(ref _resources);
        internal IReadOnlyList<ResourceCollectionClientProvider> ResourceCollectionProviders => GetValue(ref _resourceCollections);
        internal IReadOnlyList<MockableResourceProvider> MockableResourceProviders => GetValue(ref _mockableResources);
        internal ExtensionProvider ExtensionProvider => GetValue(ref _extensionProvider);

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal ResourceClientProvider GetResourceById(string id) => GetValue(ref _resourcesByIdDict)[id];

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal MockableResourceProvider GetMockableResourceByScope(ResourceScope scope) => GetValue(ref _mockableResourcesByScopeDict)[scope];

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResourceClients(
                ref _resourcesByIdDict,
                ref _resources,
                ref _resourceCollections,
                ref _mockableResourcesByScopeDict,
                ref _mockableResources,
                ref _extensionProvider);

            return field!;
        }

        /// <summary>
        /// This method initializes the resource clients, collections, and mockable clients.
        /// We do all of these in the same method to ensure they are initialized together
        /// </summary>
        /// <param name="_resourcesByIdDict">Represent a map from resource id pattern to the <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_resources">The full list of <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_resourceCollections">The full list of <see cref="ResourceCollectionClientProvider"/>. </param>
        /// <param name="_mockableResourcesByScopeDict">Represent a dictionary from scope to the corresponding <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_mockableResources">The full list of <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_extensionProvider">The <see cref="T:ExtensionProvider"/>. </param>
        private static void InitializeResourceClients(
            ref IReadOnlyDictionary<string, ResourceClientProvider>? _resourcesByIdDict,
            ref IReadOnlyList<ResourceClientProvider>? _resources,
            ref IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections,
            ref IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableResourcesByScopeDict,
            ref IReadOnlyList<MockableResourceProvider>? _mockableResources,
            ref ExtensionProvider? _extensionProvider)
        {
            if (_resourcesByIdDict is not null ||
                _resources is not null ||
                _resourceCollections is not null ||
                _mockableResourcesByScopeDict is not null ||
                _mockableResources is not null ||
                _extensionProvider is not null)
            {
                return; // already initialized
            }

            var resourceMetadatas = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas;
            var resourceMethodCategories = new Dictionary<ResourceMetadata, ResourceMethodCategory>(resourceMetadatas.Count);

            // build resource methods per resource metadata
            var resourceDict = new Dictionary<ResourceMetadata, ResourceClientProvider>(resourceMetadatas.Count);
            var collections = new List<ResourceCollectionClientProvider>(resourceMetadatas.Count);
            foreach (var resourceMetadata in resourceMetadatas)
            {
                // categorize the resource methods
                var categorizedMethods = resourceMetadata.CategorizeMethods();
                // stores it because later in extensions we need it again
                resourceMethodCategories.Add(resourceMetadata, categorizedMethods);
                var resource = ResourceClientProvider.Create(resourceMetadata, categorizedMethods.MethodsInResource, categorizedMethods.MethodsInCollection);
                resourceDict.Add(resourceMetadata, resource);
                if (resource.ResourceCollection is not null)
                {
                    collections.Add(resource.ResourceCollection);
                }
            }

            // resources and collections are now initialized
            _resourcesByIdDict = resourceDict.ToDictionary(kv => kv.Key.ResourceIdPattern, kv => kv.Value);
            _resources = [.. resourceDict.Values];
            _resourceCollections = collections;

            // build mockable resources
            var resourcesAndMethodsPerScope = BuildResourcesAndNonResourceMethods(
                resourceDict,
                resourceMethodCategories,
                ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods);
            var mockableArmClientResource = new MockableArmClientProvider(_resources);
            var mockableResources = new Dictionary<ResourceScope, MockableResourceProvider>(resourcesAndMethodsPerScope.Count);
            foreach (var (scope, (resourcesInScope, resourceMethods, nonResourceMethods)) in resourcesAndMethodsPerScope)
            {
                if (scope != ResourceScope.Extension &&
                    (resourcesInScope.Count > 0 || resourceMethods.Count > 0 || nonResourceMethods.Count > 0))
                {
                    var mockableExtension = new MockableResourceProvider(scope, resourcesInScope, resourceMethods, nonResourceMethods);
                    mockableResources.Add(scope, mockableExtension);
                }
            }

            _mockableResourcesByScopeDict = mockableResources;
            _mockableResources = [mockableArmClientResource, ..mockableResources.Values];
            _extensionProvider = new ExtensionProvider(_mockableResources);

            static Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope> BuildResourcesAndNonResourceMethods(
                IReadOnlyDictionary<ResourceMetadata, ResourceClientProvider> resourceDict,
                IReadOnlyDictionary<ResourceMetadata, ResourceMethodCategory> resourceMethods,
                IEnumerable<NonResourceMethod> nonResourceMethods)
            {
                // walk through all resources to figure out their scopes
                var resourcesAndMethodsPerScope = new Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope>
                {
                    [ResourceScope.ResourceGroup] = new([], [], []),
                    [ResourceScope.Subscription] = new([], [], []),
                    [ResourceScope.Tenant] = new([], [], []),
                    [ResourceScope.ManagementGroup] = new([], [], []),
                    [ResourceScope.Extension] = new([], [], [])
                };
                foreach (var (metadata, resourceClient) in resourceDict)
                {
                    if (metadata.ParentResourceId is null)
                    {
                        resourcesAndMethodsPerScope[metadata.ResourceScope].ResourceClients.Add(resourceClient);
                    }
                }
                foreach (var (metadata, category) in resourceMethods)
                {
                    // find the resource
                    var resource = resourceDict[metadata];
                    // the resource methods
                    foreach (var resourceMethod in category.MethodsInExtension)
                    {
                        var resourcesAndMethodsInThisScope = resourcesAndMethodsPerScope[resourceMethod.OperationScope];
                        if (!resourcesAndMethodsInThisScope.ResourceMethods.TryGetValue(resource, out var methods))
                        {
                            methods = new List<ResourceMethod>();
                            resourcesAndMethodsInThisScope.ResourceMethods[resource] = methods;
                        }
                        // add this method into the list
                        ((List<ResourceMethod>)methods).Add(resourceMethod);
                    }
                }
                foreach (var nonResourceMethod in nonResourceMethods)
                {
                    resourcesAndMethodsPerScope[nonResourceMethod.OperationScope].NonResourceMethods.Add(nonResourceMethod);
                }
                return resourcesAndMethodsPerScope;
            }
        }

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

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // we need to add the clients (including resources, collections, mockable resources and extension static class)
            // to the types to keep
            // otherwise, they will be trimmed off or internalized by the post processor
            foreach (var resource in ResourceProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
            }
            foreach (var collection in ResourceCollectionProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(collection.Name);
            }
            foreach (var mockableResource in MockableResourceProviders)
            {
                ManagementClientGenerator.Instance.AddTypeToKeep(mockableResource.Name);
            }
            ManagementClientGenerator.Instance.AddTypeToKeep(ExtensionProvider.Name);

            return [
                .. base.BuildTypeProviders().Where(t => t is not InheritableSystemObjectModelProvider),
                ArmOperation,
                ArmOperationOfT,
                ProviderConstants,
                .. ResourceProviders,
                .. ResourceCollectionProviders,
                .. MockableResourceProviders,
                ExtensionProvider,
                PageableWrapper,
                AsyncPageableWrapper,
                .. ResourceProviders.Select(r => r.Source),
                .. ResourceProviders.SelectMany(r => r.SerializationProviders)];
        }

        internal bool IsResourceModelType(CSharpType type) => TryGetResourceClientProvider(type, out _);

        private IReadOnlyDictionary<CSharpType, ResourceClientProvider>? _resourceDataTypes;
        internal bool TryGetResourceClientProvider(CSharpType resourceDataType, [MaybeNullWhen(false)] out ResourceClientProvider resourceClientProvider)
        {
            _resourceDataTypes ??= ResourceProviders.ToDictionary(r => r.ResourceData.Type, r => r);
            return _resourceDataTypes.TryGetValue(resourceDataType, out resourceClientProvider);
        }

        private record ResourcesAndNonResourceMethodsInScope(
            List<ResourceClientProvider> ResourceClients,
            Dictionary<ResourceClientProvider, IReadOnlyList<ResourceMethod>> ResourceMethods,
            List<NonResourceMethod> NonResourceMethods);
    }
}
