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

        private IReadOnlyDictionary<string, ResourceClientProvider>? _resourceClientsDict;
        private IReadOnlyList<ResourceClientProvider>? _resourceClients;
        private IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections;
        private IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableResourceProvidersDict;
        private IReadOnlyList<MockableResourceProvider>? _mockableResourceProviders;
        private ExtensionProvider? _extensionProvider;

        internal IReadOnlyList<ResourceClientProvider> ResourceProviders => GetValue(ref _resourceClients);
        internal IReadOnlyList<ResourceCollectionClientProvider> ResourceCollectionProviders => GetValue(ref _resourceCollections);
        internal IReadOnlyList<MockableResourceProvider> MockableResourceProviders => GetValue(ref _mockableResourceProviders);
        internal ExtensionProvider ExtensionProvider => GetValue(ref _extensionProvider);

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal ResourceClientProvider GetResourceById(string id) => GetValue(ref _resourceClientsDict)[id];

        // our initialization process should guarantee that here we never get a KeyNotFoundException
        internal MockableResourceProvider GetMockableResourceByScope(ResourceScope scope) => GetValue(ref _mockableResourceProvidersDict)[scope];

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResourceClients(
                ref _resourceClientsDict,
                ref _resourceClients,
                ref _resourceCollections,
                ref _mockableResourceProvidersDict,
                ref _mockableResourceProviders,
                ref _extensionProvider);

            return field!;
        }

        /// <summary>
        /// This method initializes the resource clients, collections, and mockable clients.
        /// We do all of these in the same method to ensure they are initialized together
        /// </summary>
        /// <param name="_resourceClientsDict">Represent a map from resource id pattern to the <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_resourceClients">The full list of <see cref="ResourceClientProvider"/>. </param>
        /// <param name="_collectionClients">The full list of <see cref="ResourceCollectionClientProvider"/>. </param>
        /// <param name="_mockableClientsDict">Represent a dictionary from scope to the corresponding <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_mockableClients">The full list of <see cref="MockableResourceProvider"/>. </param>
        /// <param name="_extensionProvider">The <see cref="T:ExtensionProvider"/>. </param>
        private static void InitializeResourceClients(
            ref IReadOnlyDictionary<string, ResourceClientProvider>? _resourceClientsDict,
            ref IReadOnlyList<ResourceClientProvider>? _resourceClients,
            ref IReadOnlyList<ResourceCollectionClientProvider>? _collectionClients,
            ref IReadOnlyDictionary<ResourceScope, MockableResourceProvider>? _mockableClientsDict,
            ref IReadOnlyList<MockableResourceProvider>? _mockableClients,
            ref ExtensionProvider? _extensionProvider)
        {
            if (_resourceClientsDict is not null ||
                _resourceClients is not null ||
                _collectionClients is not null ||
                _mockableClientsDict is not null ||
                _mockableClients is not null ||
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
            _resourceClientsDict = resourceDict.ToDictionary(kv => kv.Key.ResourceIdPattern, kv => kv.Value);
            _resourceClients = [.. resourceDict.Values];
            _collectionClients = collections;

            // build mockable resources
            var resourcesAndMethodsPerScope = BuildResourcesAndNonResourceMethods(
                resourceDict,
                resourceMethodCategories,
                ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods);
            var mockableArmClientResource = new MockableArmClientProvider(_resourceClients);
            var mockableResources = new Dictionary<ResourceScope, MockableResourceProvider>(resourcesAndMethodsPerScope.Count);
            foreach (var (scope, (resourcesInScope, resourceMethods, nonResourceMethods)) in resourcesAndMethodsPerScope)
            {
                if (resourcesInScope.Count > 0 || nonResourceMethods.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(scope, resourcesInScope, resourceMethods, nonResourceMethods);
                    mockableResources.Add(scope, mockableExtension);
                }
            }

            _mockableClientsDict = mockableResources;
            _mockableClients = [mockableArmClientResource, ..mockableResources.Values];
            _extensionProvider = new ExtensionProvider(_mockableClients);

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
                .. base.BuildTypeProviders().Where(t => t is not SystemObjectModelProvider),
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
