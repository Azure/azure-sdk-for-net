// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Input library for provisioning generator. Prepares resource projections,
    /// reachable input models/enums, and settable usage before output providers are created.
    /// </summary>
    public class ProvisioningInputLibrary : ManagementInputLibrary
    {
        private IReadOnlyList<ProvisioningResourceProjection>? _resourceProjections;
        private Dictionary<InputModelType, List<ProvisioningResourceProjection>>? _resourceProjectionsByModel;
        private IReadOnlyList<InputModelType>? _reachableModels;
        private IReadOnlyList<InputEnumType>? _reachableEnums;
        private Dictionary<InputModelType, bool>? _modelSettableUsage;
        private Dictionary<ProvisioningResourceProjection, bool>? _resourceSettableUsage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningInputLibrary"/> class.
        /// </summary>
        /// <param name="configPath">The generator configuration path.</param>
        public ProvisioningInputLibrary(string configPath) : base(configPath)
        {
        }

        internal IReadOnlyList<ProvisioningResourceProjection> ResourceProjections
        {
            get
            {
                EnsureProvisioningInput();
                return _resourceProjections!;
            }
        }

        internal IReadOnlyList<InputModelType> ReachableModels
        {
            get
            {
                EnsureProvisioningInput();
                return _reachableModels!;
            }
        }

        internal IReadOnlyList<InputEnumType> ReachableEnums
        {
            get
            {
                EnsureProvisioningInput();
                return _reachableEnums!;
            }
        }

        internal bool IsModelSettable(InputModelType model)
        {
            EnsureProvisioningInput();
            if (_modelSettableUsage!.TryGetValue(model, out var isSettable))
            {
                return isSettable;
            }

            throw new KeyNotFoundException($"Model '{model.Namespace}.{model.Name}' ('{model.CrossLanguageDefinitionId}') was not present in provisioning settable analysis.");
        }

        internal bool IsResourceSettable(ProvisioningResourceProjection resource)
        {
            EnsureProvisioningInput();
            return _resourceSettableUsage![resource];
        }

        internal bool IsModelReachable(InputModelType model)
        {
            EnsureProvisioningInput();
            return _modelSettableUsage!.ContainsKey(model);
        }

        private void EnsureProvisioningInput()
        {
            if (_resourceProjections != null && _modelSettableUsage != null && _resourceSettableUsage != null)
                return;

            var resourceProjections = _resourceProjections
                ?? ProvisioningResourceProjection.Create(ArmProviderSchema.Resources);
            var resourceProjectionsByModel = _resourceProjectionsByModel ?? resourceProjections
                .GroupBy(projection => projection.ResourceModel)
                .ToDictionary(group => group.Key, group => group.ToList());
            var (reachableModels, reachableEnums, modelSettableUsage, resourceSettableUsage) = CollectReachableTypes(resourceProjections, resourceProjectionsByModel);

            _resourceProjections = resourceProjections;
            _resourceProjectionsByModel = resourceProjectionsByModel;
            _reachableModels = reachableModels;
            _reachableEnums = reachableEnums;
            _modelSettableUsage = modelSettableUsage;
            _resourceSettableUsage = resourceSettableUsage;
        }

        /// <summary>
        /// Collects the input models and enums reachable from the resource models'
        /// property graphs. The same traversal dyes models reachable from settable
        /// resources through non-output properties as settable.
        /// Provisioning settable analysis is similar to TCGC usage analysis, but
        /// provisioning emits only a subset of operations, so TCGC usage cannot be
        /// used directly here.
        /// </summary>
        private static (IReadOnlyList<InputModelType> Models, IReadOnlyList<InputEnumType> Enums, Dictionary<InputModelType, bool> ModelSettableUsage, Dictionary<ProvisioningResourceProjection, bool> ResourceSettableUsage) CollectReachableTypes(
            IReadOnlyList<ProvisioningResourceProjection> resourceProjections,
            Dictionary<InputModelType, List<ProvisioningResourceProjection>> resourceProjectionsByModel)
        {
            var outputVisited = new HashSet<InputType>();
            // Visit settable and non-settable paths independently. A model may be reached
            // by a read-only resource first and by a writable resource later; the writable
            // path must still propagate so the final modelSettableUsage value can be dyed true.
            var traversalVisited = new HashSet<(InputType Type, bool IsSettable)>();
            var resourceVisited = new HashSet<(ProvisioningResourceProjection Resource, bool IsSettable)>();
            var models = new List<InputModelType>();
            var enums = new List<InputEnumType>();
            var modelSettableUsage = new Dictionary<InputModelType, bool>();
            var resourceSettableUsage = resourceProjections.ToDictionary(resource => resource, resource => resource.IsSettable);
            var queue = new Queue<(InputType? Type, ProvisioningResourceProjection? Resource, bool IsSettable)>();

            foreach (var resource in resourceProjections)
            {
                queue.Enqueue((null, resource, resource.IsSettable));
            }

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item.Resource is not null)
                {
                    VisitResource(item.Resource, item.IsSettable, resourceVisited, modelSettableUsage, resourceSettableUsage, queue);
                }
                else
                {
                    VisitType((item.Type!, item.IsSettable), resourceProjectionsByModel, outputVisited, traversalVisited, models, enums, modelSettableUsage, queue);
                }
            }

            return (models, enums, modelSettableUsage, resourceSettableUsage);
        }

        private static void VisitResource(
            ProvisioningResourceProjection resource,
            bool isSettable,
            HashSet<(ProvisioningResourceProjection Resource, bool IsSettable)> resourceVisited,
            Dictionary<InputModelType, bool> modelSettableUsage,
            Dictionary<ProvisioningResourceProjection, bool> resourceSettableUsage,
            Queue<(InputType? Type, ProvisioningResourceProjection? Resource, bool IsSettable)> queue)
        {
            if (!resourceVisited.Add((resource, isSettable)))
                return;

            resourceSettableUsage[resource] = isSettable || resourceSettableUsage[resource];
            modelSettableUsage[resource.ResourceModel] = isSettable || (modelSettableUsage.TryGetValue(resource.ResourceModel, out var existing) && existing);
            EnqueueResourceProperties(resource, isSettable, queue);
            if (resource.ResourceModel.BaseModel != null)
            {
                queue.Enqueue((resource.ResourceModel.BaseModel, null, isSettable));
            }
            foreach (var derived in resource.ResourceModel.DerivedModels)
            {
                queue.Enqueue((derived, null, isSettable));
            }
        }

        private static void EnqueueResourceProperties(ProvisioningResourceProjection resource, bool isSettable, Queue<(InputType? Type, ProvisioningResourceProjection? Resource, bool IsSettable)> queue)
        {
            foreach (var property in GetResourceProperties(resource))
            {
                queue.Enqueue((property.Type, null, isSettable && !property.IsReadOnly));
            }
        }

        private static void VisitType(
            (InputType Type, bool IsSettable) item,
            Dictionary<InputModelType, List<ProvisioningResourceProjection>> resourceProjectionInfosByModel,
            HashSet<InputType> outputVisited,
            HashSet<(InputType Type, bool IsSettable)> traversalVisited,
            List<InputModelType> models,
            List<InputEnumType> enums,
            Dictionary<InputModelType, bool> modelSettableUsage,
            Queue<(InputType? Type, ProvisioningResourceProjection? Resource, bool IsSettable)> queue)
        {
            if (!traversalVisited.Add(item))
                return;

            switch (item.Type)
            {
                case InputModelType model:
                    if (resourceProjectionInfosByModel.TryGetValue(model, out var resources))
                    {
                        foreach (var resource in resources)
                        {
                            queue.Enqueue((null, resource, item.IsSettable || resource.IsSettable));
                        }
                        break;
                    }

                    if (outputVisited.Add(model))
                    {
                        models.Add(model);
                    }
                    modelSettableUsage[model] = item.IsSettable || (modelSettableUsage.TryGetValue(model, out var existing) && existing);
                    if (model.BaseModel != null)
                        queue.Enqueue((model.BaseModel, null, item.IsSettable));
                    foreach (var derived in model.DerivedModels)
                        queue.Enqueue((derived, null, item.IsSettable));
                    foreach (var property in model.Properties)
                        queue.Enqueue((property.Type, null, item.IsSettable && !property.IsReadOnly));
                    if (model.AdditionalProperties != null)
                        queue.Enqueue((model.AdditionalProperties, null, item.IsSettable));
                    break;
                case InputArrayType arrayType:
                    queue.Enqueue((arrayType.ValueType, null, item.IsSettable));
                    break;
                case InputDictionaryType dictType:
                    queue.Enqueue((dictType.KeyType, null, item.IsSettable));
                    queue.Enqueue((dictType.ValueType, null, item.IsSettable));
                    break;
                case InputNullableType nullableType:
                    queue.Enqueue((nullableType.Type, null, item.IsSettable));
                    break;
                case InputLiteralType literalType:
                    queue.Enqueue((literalType.ValueType, null, item.IsSettable));
                    break;
                case InputUnionType unionType:
                    foreach (var variant in unionType.VariantTypes)
                        queue.Enqueue((variant, null, item.IsSettable));
                    break;
                case InputEnumType enumType:
                    if (outputVisited.Add(enumType))
                    {
                        enums.Add(enumType);
                    }
                    break;
            }
        }

        private static IEnumerable<InputModelProperty> GetResourceProperties(ProvisioningResourceProjection projection)
        {
            var chain = new Stack<InputModelType>();
            chain.Push(projection.ResourceModel);
            var baseModel = projection.ResourceModel.BaseModel;
            while (baseModel != null)
            {
                chain.Push(baseModel);
                baseModel = baseModel.BaseModel;
            }

            foreach (var model in chain)
            {
                foreach (var property in model.Properties)
                {
                    yield return property;
                }
            }
        }
    }
}
