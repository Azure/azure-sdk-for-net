// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Generator.Management;
using Azure.Generator.Provisioning.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Output library for provisioning generator. Pre-creates all resource providers
    /// from ArmProviderSchema.Resources and builds model/enum providers from input types.
    /// </summary>
    public class ProvisioningOutputLibrary : ManagementOutputLibrary
    {
        private IReadOnlyList<ProvisioningResourceProvider>? _resources;
        private Dictionary<string, ProvisioningResourceProvider>? _resourcesByIdPattern;
        private Dictionary<InputModelType, List<ProvisioningResourceProvider>>? _resourcesByModel;
        private BuiltInRoleProvider? _builtInRole;

        /// <summary>
        /// Gets the BuiltInRole type provider if any resources define RBAC roles.
        /// </summary>
        internal BuiltInRoleProvider? BuiltInRole => GetNullableValue(ref _builtInRole);

        private T GetValue<T>(ref T? field) where T : class
        {
            InitializeResources(ref _resources, ref _resourcesByIdPattern, ref _resourcesByModel, ref _builtInRole);
            return field!;
        }

        private T? GetNullableValue<T>(ref T? field) where T : class
        {
            InitializeResources(ref _resources, ref _resourcesByIdPattern, ref _resourcesByModel, ref _builtInRole);
            return field;
        }

        /// <summary>
        /// Gets all provisioning resource providers.
        /// </summary>
        internal IReadOnlyList<ProvisioningResourceProvider> Resources => GetValue(ref _resources);

        private void InitializeResources(
            ref IReadOnlyList<ProvisioningResourceProvider>? resources,
            ref Dictionary<string, ProvisioningResourceProvider>? resourcesByIdPattern,
            ref Dictionary<InputModelType, List<ProvisioningResourceProvider>>? resourcesByModel,
            ref BuiltInRoleProvider? builtInRole)
        {
            if (resources != null)
                return;

            var list = new List<ProvisioningResourceProvider>();
            var byIdPattern = new Dictionary<string, ProvisioningResourceProvider>();
            var byModel = new Dictionary<InputModelType, List<ProvisioningResourceProvider>>();

            var allMetadata = ProvisioningGenerator.Instance.InputLibrary.ArmProviderSchema.Resources;
            foreach (var metadata in allMetadata)
            {
                if (metadata.ResourceModel == null)
                    continue;

                var resource = new ProvisioningResourceProvider(metadata.ResourceModel, metadata);
                list.Add(resource);
                byIdPattern[metadata.ResourceIdPattern] = resource;

                if (!byModel.TryGetValue(metadata.ResourceModel, out var modelList))
                {
                    modelList = new List<ProvisioningResourceProvider>();
                    byModel[metadata.ResourceModel] = modelList;
                }
                modelList.Add(resource);
            }

            // Initialize BuiltInRole from input metadata — this is safe to do here since
            // it's constructed purely from input values, and must be available before any
            // resource provider's methods are materialized.
            var serviceName = ProvisioningGenerator.Instance.TypeFactory.ResourceProviderName;
            builtInRole = BuiltInRoleProvider.TryCreate(serviceName, allMetadata);

            resources = list;
            resourcesByIdPattern = byIdPattern;
            resourcesByModel = byModel;
        }

        /// <summary>
        /// Tries to get the resource provider(s) for a given InputModelType.
        /// Returns false if the model is not a resource model.
        /// </summary>
        internal bool TryGetResourcesByModel(InputModelType model, out IReadOnlyList<ProvisioningResourceProvider> resources)
        {
            if (GetValue(ref _resourcesByModel).TryGetValue(model, out var list))
            {
                resources = list;
                return true;
            }
            resources = [];
            return false;
        }

        /// <summary>
        /// Gets a resource provider by its ARM resource ID pattern.
        /// Returns null if not found.
        /// </summary>
        internal ProvisioningResourceProvider? GetResourceByIdPattern(string resourceIdPattern)
        {
            GetValue(ref _resourcesByIdPattern).TryGetValue(resourceIdPattern, out var resource);
            return resource;
        }

        /// <inheritdoc/>
        protected override TypeProvider[] BuildTypeProviders()
        {
            // TODO: Ideally we should call base.BuildTypeProviders() and filter the results
            // to keep only models, enums, and CodeGen attributes. However, ManagementOutputLibrary
            // eagerly initializes mgmt-specific client types (ResourceClientProvider,
            // ResourceCollectionClientProvider, etc.) whose BuildMethods() crashes because
            // our provisioning models don't have paging properties like 'nextLink'.
            // Until ManagementOutputLibrary is refactored to support lazy initialization or
            // allows skipping client type construction, we build the provider list manually.

            var providers = new List<TypeProvider>();

            // Add resource providers and mark them to survive post-processing.
            foreach (var resource in Resources)
            {
                providers.Add(resource);
                ProvisioningGenerator.Instance.AddTypeToKeep(resource.Name);
            }

            // Add BuiltInRole struct if any resources have RBAC roles defined.
            if (BuiltInRole != null)
            {
                providers.Add(BuiltInRole);
            }

            // Build models and enums via TypeFactory — our overridden CreateModel/CreateEnum
            // return ProvisioningModelProvider/ProvisioningResourceProvider/EnumProvider.
            // Only emit models/enums reachable from resource models' property graphs. This
            // avoids emitting dead types like list-result envelopes, patch/request wrappers,
            // and error models that have no place in a Provisioning library.
            var (reachableModels, reachableEnums) = CollectReachableTypes();

            foreach (var inputModel in reachableModels)
            {
                var model = ProvisioningGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null && model is not ProvisioningResourceProvider)
                {
                    providers.Add(model);
                }
            }

            foreach (var inputEnum in reachableEnums)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    providers.Add(enumProvider);
                }
            }

            // TODO: CodeGen* attribute definitions (CodeGenType, CodeGenMember, etc.) are
            // included in base OutputLibrary.BuildTypeProviders() via the internal property
            // CodeModelGenerator.CustomCodeAttributeProviders. Since we can't call base and
            // the property is inaccessible, we discover them by convention using reflection.
            // This should be replaced by a base.BuildTypeProviders() call once the above
            // ManagementOutputLibrary issue is resolved.
            foreach (var type in typeof(TypeProvider).Assembly.GetTypes())
            {
                if (typeof(TypeProvider).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && type.Name.EndsWith("AttributeDefinition"))
                {
                    if (Activator.CreateInstance(type) is TypeProvider attrProvider)
                    {
                        providers.Add(attrProvider);
                    }
                }
            }

            return [.. providers];
        }

        /// <summary>
        /// Collects the input models and enums reachable from the resource models'
        /// property graphs (including base models, discriminator subtypes, and elements of
        /// arrays/dictionaries/nullable/union types). Resource models themselves are
        /// excluded — they are emitted separately as ProvisioningResourceProvider.
        ///
        /// Visited types are tracked in a HashSet (for O(1) dedup) but returned in
        /// traversal/insertion order via parallel lists, so the emitted output is
        /// deterministic across runs without relying on HashSet enumeration order.
        /// </summary>
        private (IReadOnlyList<InputModelType> Models, IReadOnlyList<InputEnumType> Enums) CollectReachableTypes()
        {
            var visited = new HashSet<InputType>();
            var models = new List<InputModelType>();
            var enums = new List<InputEnumType>();
            var queue = new Queue<InputType>();

            foreach (var metadata in ProvisioningGenerator.Instance.InputLibrary.ArmProviderSchema.Resources)
            {
                if (metadata.ResourceModel != null)
                {
                    queue.Enqueue(metadata.ResourceModel);
                }
            }

            while (queue.Count > 0)
            {
                Visit(queue.Dequeue(), visited, models, enums, queue);
            }

            return (models, enums);
        }

        private void Visit(InputType type, HashSet<InputType> visited, List<InputModelType> models, List<InputEnumType> enums, Queue<InputType> queue)
        {
            if (!visited.Add(type))
                return;

            switch (type)
            {
                case InputModelType model:
                    // Resource models are emitted separately as ProvisioningResourceProvider,
                    // so don't include them in the plain-model output list. We still walk
                    // their base/derived/property graphs to reach nested types.
                    if (!TryGetResourcesByModel(model, out _))
                    {
                        models.Add(model);
                    }
                    if (model.BaseModel != null)
                        queue.Enqueue(model.BaseModel);
                    foreach (var derived in model.DerivedModels)
                        queue.Enqueue(derived);
                    foreach (var property in model.Properties)
                        queue.Enqueue(property.Type);
                    if (model.AdditionalProperties != null)
                        queue.Enqueue(model.AdditionalProperties);
                    break;
                case InputEnumType enumType:
                    enums.Add(enumType);
                    break;
                case InputArrayType arrayType:
                    queue.Enqueue(arrayType.ValueType);
                    break;
                case InputDictionaryType dictType:
                    queue.Enqueue(dictType.KeyType);
                    queue.Enqueue(dictType.ValueType);
                    break;
                case InputNullableType nullableType:
                    queue.Enqueue(nullableType.Type);
                    break;
                case InputLiteralType literalType:
                    queue.Enqueue(literalType.ValueType);
                    break;
                case InputUnionType unionType:
                    foreach (var variant in unionType.VariantTypes)
                        queue.Enqueue(variant);
                    break;
            }
        }
    }
}
