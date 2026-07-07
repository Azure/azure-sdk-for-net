// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

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
        private Dictionary<InputModelType, bool>? _modelSettableUsage;
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
            var projections = ProvisioningResourceProjection.Create(allMetadata);
            foreach (var projection in projections)
            {
                var resource = new ProvisioningResourceProvider(projection);
                list.Add(resource);
                foreach (var resourceIdPattern in projection.ResourceIdPatterns)
                {
                    byIdPattern[resourceIdPattern.SerializedPath] = resource;
                }

                if (!byModel.TryGetValue(projection.ResourceModel, out var modelList))
                {
                    modelList = new List<ProvisioningResourceProvider>();
                    byModel[projection.ResourceModel] = modelList;
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
        internal ProvisioningResourceProvider? GetResourceByIdPattern(RequestPathPattern resourceIdPattern)
        {
            GetValue(ref _resourcesByIdPattern).TryGetValue(resourceIdPattern.SerializedPath, out var resource);
            return resource;
        }

        internal bool IsModelSettable(InputModelType model)
        {
            _modelSettableUsage ??= CollectReachableTypes().ModelSettableUsage;
            return !_modelSettableUsage.TryGetValue(model, out var isSettable) || isSettable;
        }

        /// <inheritdoc/>
        protected override IReadOnlyList<ModelProvider> ResolveFlattenTargetModels(InputModelType inputModel)
        {
            return TryGetResourcesByModel(inputModel, out var resources)
                ? resources
                : base.ResolveFlattenTargetModels(inputModel);
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
                ProvisioningGenerator.Instance.AddTypeToKeep(resource);
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
            var (reachableModels, reachableEnums, modelSettableUsage) = CollectReachableTypes();
            _modelSettableUsage = modelSettableUsage;

            foreach (var inputModel in reachableModels)
            {
                var model = ProvisioningGenerator.Instance.TypeFactory.CreateModel(inputModel);
                if (model is not null)
                {
                    providers.Add(model);
                    // CollectReachableTypes excludes models already backed by ArmProviderSchema.Resources,
                    // so this does not duplicate the pre-created resource providers added above.
                    // CreateModel can still return a resource provider here for discriminator-derived
                    // models whose base chain is a resource, and those providers must also be kept.
                    if (model is ProvisioningResourceProvider resource)
                    {
                        ProvisioningGenerator.Instance.AddTypeToKeep(resource);
                    }
                }
            }

            foreach (var inputEnum in reachableEnums)
            {
                var enumProvider = ProvisioningGenerator.Instance.TypeFactory.CreateEnum(inputEnum);
                if (enumProvider != null)
                {
                    // Provisioning manually builds the provider list instead of calling the base
                    // OutputLibrary.BuildTypeProviders(), so we must preserve the base pipeline's
                    // custom enum replacement behavior here. When a custom enum is decorated with
                    // [CodeGenType("GeneratedEnumName")], the generated enum provider still exists
                    // (often internalized), but C# cannot merge two enum declarations with the
                    // same name. Skipping the generated provider lets the custom enum fully replace
                    // it, matching the base/mgmt generator behavior.
                    if (enumProvider.CustomCodeView != null)
                    {
                        continue;
                    }
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
        private (IReadOnlyList<InputModelType> Models, IReadOnlyList<InputEnumType> Enums, Dictionary<InputModelType, bool> ModelSettableUsage) CollectReachableTypes()
        {
            var outputVisited = new HashSet<InputType>();
            var traversalVisited = new HashSet<(InputType Type, bool IsSettable)>();
            var models = new List<InputModelType>();
            var enums = new List<InputEnumType>();
            var modelSettableUsage = new Dictionary<InputModelType, bool>();
            var queue = new Queue<(InputType Type, bool IsSettable)>();

            foreach (var resource in Resources)
            {
                queue.Enqueue((resource.ResourceProjection!.ResourceModel, false));
            }

            while (queue.Count > 0)
            {
                Visit(queue.Dequeue(), outputVisited, traversalVisited, models, enums, modelSettableUsage, queue);
            }

            return (models, enums, modelSettableUsage);
        }

        private static void EnqueueResourceProperties(ProvisioningResourceProvider resource, Queue<(InputType Type, bool IsSettable)> queue)
        {
            foreach (var (property, isSettable) in resource.GetReachableProperties())
            {
                queue.Enqueue((property.Type, isSettable));
            }
        }

        private void Visit(
            (InputType Type, bool IsSettable) item,
            HashSet<InputType> outputVisited,
            HashSet<(InputType Type, bool IsSettable)> traversalVisited,
            List<InputModelType> models,
            List<InputEnumType> enums,
            Dictionary<InputModelType, bool> modelSettableUsage,
            Queue<(InputType Type, bool IsSettable)> queue)
        {
            if (!traversalVisited.Add(item))
                return;

            switch (item.Type)
            {
                case InputModelType model:
                    if (TryGetResourcesByModel(model, out var resources))
                    {
                        foreach (var resource in resources)
                        {
                            EnqueueResourceProperties(resource, queue);
                        }
                        if (model.BaseModel != null)
                            queue.Enqueue((model.BaseModel, item.IsSettable));
                        foreach (var derived in model.DerivedModels)
                            queue.Enqueue((derived, item.IsSettable));
                        break;
                    }

                    if (outputVisited.Add(model))
                    {
                        models.Add(model);
                    }
                    modelSettableUsage[model] = item.IsSettable || (modelSettableUsage.TryGetValue(model, out var existing) && existing);
                    if (model.BaseModel != null)
                        queue.Enqueue((model.BaseModel, item.IsSettable));
                    foreach (var derived in model.DerivedModels)
                        queue.Enqueue((derived, item.IsSettable));
                    foreach (var property in model.Properties.Where(p => !p.IsDiscriminator))
                        queue.Enqueue((property.Type, item.IsSettable && !property.IsReadOnly));
                    if (model.AdditionalProperties != null)
                        queue.Enqueue((model.AdditionalProperties, item.IsSettable));
                    break;
                case InputArrayType arrayType:
                    queue.Enqueue((arrayType.ValueType, item.IsSettable));
                    break;
                case InputDictionaryType dictType:
                    queue.Enqueue((dictType.KeyType, item.IsSettable));
                    queue.Enqueue((dictType.ValueType, item.IsSettable));
                    break;
                case InputNullableType nullableType:
                    queue.Enqueue((nullableType.Type, item.IsSettable));
                    break;
                case InputLiteralType literalType:
                    queue.Enqueue((literalType.ValueType, item.IsSettable));
                    break;
                case InputUnionType unionType:
                    foreach (var variant in unionType.VariantTypes)
                        queue.Enqueue((variant, item.IsSettable));
                    break;
                case InputEnumType enumType:
                    if (outputVisited.Add(enumType))
                    {
                        enums.Add(enumType);
                    }
                    break;
            }
        }
    }
}
