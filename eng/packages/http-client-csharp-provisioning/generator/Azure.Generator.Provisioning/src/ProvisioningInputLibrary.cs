// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System;
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
            return !_modelSettableUsage!.TryGetValue(model, out var isSettable) || isSettable;
        }

        internal bool IsResourceSettable(InputModelType model)
        {
            EnsureProvisioningInput();
            var resourceProjectionsByModel = _resourceProjectionsByModel!;
            if (resourceProjectionsByModel.TryGetValue(model, out var resources))
            {
                return resources.Any(r => r.IsSettable);
            }

            var baseModel = model.BaseModel;
            while (baseModel != null)
            {
                if (resourceProjectionsByModel.TryGetValue(baseModel, out resources))
                {
                    return resources.Any(r => r.IsSettable);
                }
                baseModel = baseModel.BaseModel;
            }
            return false;
        }

        private void EnsureProvisioningInput()
        {
            if (_resourceProjections != null && _modelSettableUsage != null)
                return;

            var resourceProjections = _resourceProjections
                ?? ProvisioningResourceProjection.Create(ArmProviderSchema.Resources);
            var resourceProjectionsByModel = _resourceProjectionsByModel ?? resourceProjections
                .GroupBy(projection => projection.ResourceModel)
                .ToDictionary(group => group.Key, group => group.ToList());
            var (reachableModels, reachableEnums, modelSettableUsage) = CollectReachableTypes(resourceProjections, resourceProjectionsByModel);

            _resourceProjections = resourceProjections;
            _resourceProjectionsByModel = resourceProjectionsByModel;
            _reachableModels = reachableModels;
            _reachableEnums = reachableEnums;
            _modelSettableUsage = modelSettableUsage;
        }

        /// <summary>
        /// Collects the input models and enums reachable from the resource models'
        /// property graphs. The same traversal dyes models reachable from settable
        /// resources through non-output properties as settable.
        /// </summary>
        private static (IReadOnlyList<InputModelType> Models, IReadOnlyList<InputEnumType> Enums, Dictionary<InputModelType, bool> ModelSettableUsage) CollectReachableTypes(
            IReadOnlyList<ProvisioningResourceProjection> resourceProjections,
            Dictionary<InputModelType, List<ProvisioningResourceProjection>> resourceProjectionsByModel)
        {
            var outputVisited = new HashSet<InputType>();
            // Visit settable and non-settable paths independently. A model may be reached
            // by a read-only resource first and by a writable resource later; the writable
            // path must still propagate so the final modelSettableUsage value can be dyed true.
            var traversalVisited = new HashSet<(InputType Type, bool IsSettable)>();
            var models = new List<InputModelType>();
            var enums = new List<InputEnumType>();
            var modelSettableUsage = new Dictionary<InputModelType, bool>();
            var queue = new Queue<(InputType Type, bool IsSettable)>();

            foreach (var resource in resourceProjections)
            {
                queue.Enqueue((resource.ResourceModel, false));
            }

            while (queue.Count > 0)
            {
                Visit(queue.Dequeue(), resourceProjectionsByModel, outputVisited, traversalVisited, models, enums, modelSettableUsage, queue);
            }

            return (models, enums, modelSettableUsage);
        }

        private static void EnqueueResourceProperties(ProvisioningResourceProjection resource, Queue<(InputType Type, bool IsSettable)> queue)
        {
            foreach (var (property, isOutput) in GetResourceProperties(resource))
            {
                queue.Enqueue((property.Type, resource.IsSettable && !isOutput));
            }
        }

        private static void Visit(
            (InputType Type, bool IsSettable) item,
            Dictionary<InputModelType, List<ProvisioningResourceProjection>> resourceProjectionInfosByModel,
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
                    if (resourceProjectionInfosByModel.TryGetValue(model, out var resources))
                    {
                        foreach (var resource in resources)
                        {
                            EnqueueResourceProperties(resource, queue);
                        }
                        var isResourceSettable = resources.Any(r => r.IsSettable);
                        if (model.BaseModel != null)
                            queue.Enqueue((model.BaseModel, isResourceSettable));
                        foreach (var derived in model.DerivedModels)
                            queue.Enqueue((derived, isResourceSettable));
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

        private static IEnumerable<(InputModelProperty Property, bool IsOutput)> GetResourceProperties(ProvisioningResourceProjection projection)
        {
            var createBodyWritableProperties = BuildCreateBodyWritableProperties(projection);
            var chain = new Stack<InputModelType>();
            chain.Push(projection.ResourceModel);
            var baseModel = projection.ResourceModel.BaseModel;
            while (baseModel != null)
            {
                chain.Push(baseModel);
                baseModel = baseModel.BaseModel;
            }

            var seen = new HashSet<string>(StringComparer.Ordinal);
            foreach (var model in chain)
            {
                foreach (var property in model.Properties)
                {
                    if (property.IsDiscriminator)
                        continue;

                    var serializedName = property.SerializedName ?? property.Name;
                    if (!seen.Add(serializedName))
                        continue;

                    if (serializedName == "type"
                        || (projection.IsExtensionResource
                            && serializedName == "scope"))
                    {
                        continue;
                    }

                    var isResourceName = serializedName == "name";
                    var isOutput = (property.IsReadOnly && !isResourceName && !createBodyWritableProperties.Contains(serializedName))
                        || OutputOnlyResourceProperties.Contains(serializedName);

                    yield return (property, isOutput);
                }
            }
        }

        private static HashSet<string> BuildCreateBodyWritableProperties(ProvisioningResourceProjection projection)
        {
            var result = new HashSet<string>(StringComparer.Ordinal);
            var createMethod = projection.Methods
                .FirstOrDefault(m => m.Kind == ResourceOperationKind.Create)?.InputMethod;
            if (createMethod == null)
                return result;

            foreach (var parameter in createMethod.Parameters)
            {
                if (parameter.Location == InputRequestLocation.Body && parameter.Type is InputModelType bodyModel)
                {
                    CollectWritableProperties(bodyModel, result);
                }
            }

            return result;
        }

        private static void CollectWritableProperties(InputModelType model, HashSet<string> result)
        {
            var current = model;
            while (current != null)
            {
                foreach (var property in current.Properties)
                {
                    if (!property.IsReadOnly)
                    {
                        result.Add(property.SerializedName ?? property.Name);
                    }
                }
                current = current.BaseModel;
            }
        }

        private static readonly HashSet<string> OutputOnlyResourceProperties = new(StringComparer.Ordinal)
        {
            "id", "systemData", "type"
        };
    }
}
