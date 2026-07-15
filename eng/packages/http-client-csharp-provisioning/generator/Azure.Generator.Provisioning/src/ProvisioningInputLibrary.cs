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
        private readonly ManagementInputLibrary _managementInputLibrary;
        private IReadOnlyList<ProvisioningResourceProjection>? _resourceProjections;
        private Dictionary<InputModelType, bool>? _modelSettableUsage;
        private InputNamespace? _provisioningInputNamespace;
        private bool _isBuildingProvisioningInput;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningInputLibrary"/> class.
        /// </summary>
        /// <param name="configPath">The generator configuration path.</param>
        public ProvisioningInputLibrary(string configPath) : base(configPath)
        {
            _managementInputLibrary = new ManagementInputLibrary(configPath);
        }

        /// <inheritdoc/>
        public override ArmProviderSchema ArmProviderSchema => _managementInputLibrary.ArmProviderSchema;

        /// <inheritdoc/>
        public override InputNamespace InputNamespace
        {
            get
            {
                if (_provisioningInputNamespace != null)
                {
                    return _provisioningInputNamespace;
                }

                var inputNamespace = _managementInputLibrary.InputNamespace;
                if (_isBuildingProvisioningInput)
                {
                    // Resource method deserialization currently resolves methods and clients through
                    // the global generator input library. While the private management library builds
                    // its schema, expose its complete namespace through this provisioning library so
                    // those lookups use the same InputMethod and InputClient instances.
                    return inputNamespace;
                }

                try
                {
                    _isBuildingProvisioningInput = true;
                    var resourceProjections = _resourceProjections
                        ?? ProvisioningResourceProjection.Create(ArmProviderSchema.Resources);
                    var resourceProjectionsByModel = resourceProjections
                        .GroupBy(projection => projection.ResourceModel)
                        .ToDictionary(group => group.Key, group => group.ToList());
                    var (reachableModels, reachableEnums, modelSettableUsage) = CollectReachableTypes(resourceProjections, resourceProjectionsByModel);

                    _resourceProjections = resourceProjections;
                    _modelSettableUsage = modelSettableUsage;
                    _provisioningInputNamespace = new InputNamespace(
                        inputNamespace.Name,
                        inputNamespace.ApiVersions,
                        inputNamespace.Constants,
                        reachableEnums,
                        reachableModels,
                        inputNamespace.RootClients,
                        inputNamespace.Auth);
                    return _provisioningInputNamespace;
                }
                finally
                {
                    _isBuildingProvisioningInput = false;
                }
            }
        }

        internal IReadOnlyList<ProvisioningResourceProjection> ResourceProjections
        {
            get
            {
                _ = InputNamespace;
                return _resourceProjections!;
            }
        }

        internal bool IsModelSettable(InputModelType model)
        {
            _ = InputNamespace;
            if (_modelSettableUsage!.TryGetValue(model, out var isSettable))
            {
                return isSettable;
            }

            throw new KeyNotFoundException($"Model '{model.Namespace}.{model.Name}' ('{model.CrossLanguageDefinitionId}') was not present in provisioning settable analysis.");
        }

        internal bool IsModelReachable(InputModelType model)
        {
            _ = InputNamespace;
            return _modelSettableUsage!.ContainsKey(model);
        }

        /// <summary>
        /// Collects the input models and enums reachable from the resource models'
        /// property graphs. The same traversal dyes models reachable from settable
        /// resources through non-output properties as settable.
        /// Provisioning settable analysis is similar to TCGC usage analysis, but
        /// provisioning emits only a subset of operations, so TCGC usage cannot be
        /// used directly here.
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
                queue.Enqueue((resource.ResourceModel, resource.WritableScopes.Count > 0));
            }

            while (queue.Count > 0)
            {
                Visit(queue.Dequeue(), resourceProjectionsByModel, outputVisited, traversalVisited, models, enums, modelSettableUsage, queue);
            }

            return (models, enums, modelSettableUsage);
        }

        private static void EnqueueResourceProperties(ProvisioningResourceProjection resource, bool isSettable, Queue<(InputType Type, bool IsSettable)> queue)
        {
            foreach (var property in GetResourceProperties(resource))
            {
                queue.Enqueue((property.Type, isSettable && !property.IsReadOnly));
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
                        if (outputVisited.Add(model))
                        {
                            models.Add(model);
                        }
                        var isResourceSettable = resources.Any(r => r.WritableScopes.Count > 0);
                        var isSettable = item.IsSettable || isResourceSettable;
                        modelSettableUsage[model] = isSettable || (modelSettableUsage.TryGetValue(model, out var existingResourceUsage) && existingResourceUsage);
                        foreach (var resource in resources)
                        {
                            EnqueueResourceProperties(resource, isSettable, queue);
                        }
                        if (model.BaseModel != null)
                            queue.Enqueue((model.BaseModel, isSettable));
                        EnqueueDiscriminatorDerivedModels(model, isSettable, queue);
                        break;
                    }

                    if (outputVisited.Add(model))
                    {
                        models.Add(model);
                    }
                    modelSettableUsage[model] = item.IsSettable || (modelSettableUsage.TryGetValue(model, out var existing) && existing);
                    if (model.BaseModel != null)
                        queue.Enqueue((model.BaseModel, item.IsSettable));
                    EnqueueDiscriminatorDerivedModels(model, item.IsSettable, queue);
                    foreach (var property in model.Properties)
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

        private static void EnqueueDiscriminatorDerivedModels(InputModelType model, bool isSettable, Queue<(InputType Type, bool IsSettable)> queue)
        {
            foreach (var derived in model.DiscriminatedSubtypes.Values)
            {
                queue.Enqueue((derived, isSettable));
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
