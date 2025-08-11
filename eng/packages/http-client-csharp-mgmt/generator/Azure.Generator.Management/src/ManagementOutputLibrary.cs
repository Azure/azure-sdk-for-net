// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers;
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

        private IReadOnlyList<ResourceClientProvider>? _resourceClients;
        private IReadOnlyList<ResourceCollectionClientProvider>? _resourceCollections;
        private IReadOnlyList<MockableResourceProvider>? _mockableResourceProviders;
        private ExtensionProvider? _extensionProvider;

        internal IReadOnlyList<ResourceClientProvider> ResourceProviders => GetValue(ref _resourceClients);
        internal IReadOnlyList<ResourceCollectionClientProvider> ResourceCollectionProviders => GetValue(ref _resourceCollections);
        internal IReadOnlyList<MockableResourceProvider> MockableResourceProviders => GetValue(ref _mockableResourceProviders);
        internal ExtensionProvider ExtensionProvider => GetValue(ref _extensionProvider);

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResourceClients(
                ref _resourceClients,
                ref _resourceCollections,
                ref _mockableResourceProviders,
                ref _extensionProvider);

            return field!;
        }

        /// <summary>
        /// This method initializes the resource clients, collections, and mockable clients.
        /// We do all of these in the same method to ensure they are initialized together
        /// </summary>
        /// <param name="_resourceClients"></param>
        /// <param name="_collectionClients"></param>
        /// <param name="_mockableClients"></param>
        /// <param name="_extensionProvider"></param>
        private static void InitializeResourceClients(
            ref IReadOnlyList<ResourceClientProvider>? _resourceClients,
            ref IReadOnlyList<ResourceCollectionClientProvider>? _collectionClients,
            ref IReadOnlyList<MockableResourceProvider>? _mockableClients,
            ref ExtensionProvider? _extensionProvider)
        {
            if (_resourceClients is not null ||
                _collectionClients is not null ||
                _mockableClients is not null ||
                _extensionProvider is not null)
            {
                return; // already initialized
            }

            var resourceMetadatas = ManagementClientGenerator.Instance.InputLibrary.ResourceMetadatas;
            var resourceMethodCategories = new Dictionary<ResourceMetadata, ResourceMethodCategory>(resourceMetadatas.Count);
            // categorize the resource methods
            foreach (var resourceMetadata in resourceMetadatas)
            {
                var methodsInResource = new List<ResourceMethod>();
                var methodsInCollection = new List<ResourceMethod>();
                var methodsInExtension = new List<ResourceMethod>();
                foreach (var method in resourceMetadata.Methods)
                {
                    var isSingleton = resourceMetadata.SingletonResourceName is not null;
                    switch (method.Kind)
                    {
                        case ResourceOperationKind.Create:
                            // create method will go to the collection, or to resource when it is singleton
                            if (isSingleton)
                            {
                                methodsInResource.Add(method);
                            }
                            else
                            {
                                methodsInCollection.Add(method);
                            }
                            break;
                        case ResourceOperationKind.Get:
                            // both resource and collection should have get method
                            methodsInResource.Add(method);
                            methodsInCollection.Add(method);
                            break;
                        case ResourceOperationKind.Update:
                        case ResourceOperationKind.Delete:
                            // only resource have get
                            methodsInResource.Add(method);
                            break;
                        case ResourceOperationKind.Action:
                            // actions should all go to the resource
                            methodsInResource.Add(method);
                            break;
                        case ResourceOperationKind.List:
                            // list methods might go to the collection or the extension
                            // when the resource has a parent
                            if (resourceMetadata.ParentResourceId is not null)
                            {
                                if (method.ResourceScope == resourceMetadata.ParentResourceId)
                                {
                                    methodsInCollection.Add(method);
                                }
                                else
                                {
                                    methodsInExtension.Add(method);
                                }
                            }
                            else
                            {
                                if (method.OperationScope == resourceMetadata.ResourceScope)
                                {
                                    // if the operation scope is the resource scope, it is a collection method
                                    methodsInCollection.Add(method);
                                }
                                else
                                {
                                    // otherwise, it is an extension method
                                    methodsInExtension.Add(method);
                                }
                            }
                            break;
                        default:
                            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                                "general-warning",
                                $"Unknown resource operation kind '{method.Kind}' for method '{method.OperationPath}' in resource '{resourceMetadata.ResourceIdPattern}'.");
                            break;
                    }
                }
                resourceMethodCategories.Add(resourceMetadata, new ResourceMethodCategory(methodsInResource, methodsInCollection, methodsInExtension));
            }

            // build resource methods per resource metadata
            var resourceDict = new Dictionary<ResourceMetadata, ResourceClientProvider>(resourceMetadatas.Count);
            var collections = new List<ResourceCollectionClientProvider>(resourceMetadatas.Count);
            foreach (var resourceMetadata in resourceMetadatas)
            {
                var resourceMethods = resourceMethodCategories[resourceMetadata];
                var resource = ResourceClientProvider.Create(resourceMetadata, resourceMethods.MethodsInResource, resourceMethods.MethodsInCollection);
                resourceDict.Add(resourceMetadata, resource);
                if (resource.ResourceCollection is not null)
                {
                    collections.Add(resource.ResourceCollection);
                }
            }

            // resources and collections are now initialized
            _resourceClients = [.. resourceDict.Values];
            _collectionClients = collections;

            // build mockable resources
            var resourcesAndMethodsPerScope = BuildResourcesAndNonResourceMethods(
                resourceDict,
                resourceMethodCategories.Values.SelectMany(c => c.MethodsInExtension),
                ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods);
            var mockableArmClientResource = new MockableArmClientProvider(_resourceClients);
            var mockableResources = new List<MockableResourceProvider>(resourcesAndMethodsPerScope.Count)
            {
                // add the arm client mockable resource
                mockableArmClientResource
            };
            foreach (var (scope, (resourcesInScope, resourceMethods, nonResourceMethods)) in resourcesAndMethodsPerScope)
            {
                if (resourcesInScope.Count > 0 || nonResourceMethods.Count > 0)
                {
                    var mockableExtension = new MockableResourceProvider(scope, resourcesInScope, resourceMethods, nonResourceMethods);
                    mockableResources.Add(mockableExtension);
                }
            }

            _mockableClients = mockableResources;
            _extensionProvider = new ExtensionProvider(mockableResources);

            static Dictionary<ResourceScope, ResourcesAndNonResourceMethodsInScope> BuildResourcesAndNonResourceMethods(
                IReadOnlyDictionary<ResourceMetadata, ResourceClientProvider> resourceDict,
                IEnumerable<ResourceMethod> resourceMethods,
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
                foreach (var resourceMethod in resourceMethods)
                {
                    resourcesAndMethodsPerScope[resourceMethod.OperationScope].ResourceMethods.Add(resourceMethod);
                }
                foreach (var nonResourceMethod in ManagementClientGenerator.Instance.InputLibrary.NonResourceMethods)
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

        private record ResourceMethodCategory(
            List<ResourceMethod> MethodsInResource,
            List<ResourceMethod> MethodsInCollection,
            List<ResourceMethod> MethodsInExtension);

        private record ResourcesAndNonResourceMethodsInScope(
            List<ResourceClientProvider> ResourceClients,
            List<ResourceMethod> ResourceMethods,
            List<NonResourceMethod> NonResourceMethods);
    }
}
