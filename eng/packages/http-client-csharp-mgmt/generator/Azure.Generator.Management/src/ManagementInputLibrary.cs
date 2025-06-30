// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementInputLibrary : InputLibrary
    {
        private IReadOnlyDictionary<InputModelType, ResourceMetadata>? _resourceMetadata;
        private IReadOnlyDictionary<string, InputModelType>? _inputModelsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<string, InputClient>? _inputClientsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<string, InputServiceMethod>? _inputServiceMethodsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<InputServiceMethod, InputClient>? _intMethodClientMap;

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
        }

        private IReadOnlyDictionary<InputModelType, ResourceMetadata> ResourceMetadata => _resourceMetadata ??= DeserializeResourceMetadata();

        private IReadOnlyDictionary<string, InputModelType> InputModelsByCrossLanguageDefinitionId => _inputModelsByCrossLanguageDefinitionId ??= BuildModelCrossLanguageDefinitionIds();

        private IReadOnlyDictionary<string, InputClient> InputClientsByCrossLanguageDefinitionId => _inputClientsByCrossLanguageDefinitionId ??= InputNamespace.Clients.ToDictionary(c => c.CrossLanguageDefinitionId, c => c);

        private IReadOnlyDictionary<string, InputServiceMethod> InputMethodsByCrossLanguageDefinitionId => _inputServiceMethodsByCrossLanguageDefinitionId ??= InputNamespace.Clients.SelectMany(c => c.Methods).ToDictionary(m => m.CrossLanguageDefinitionId, m => m);

        private IReadOnlyDictionary<InputServiceMethod, InputClient> IntMethodClientMap => _intMethodClientMap ??= ConstructMethodClientMap();

        private IReadOnlyDictionary<InputServiceMethod, InputClient> ConstructMethodClientMap()
        {
            var map = new Dictionary<InputServiceMethod, InputClient>();
            foreach (var client in InputNamespace.Clients)
            {
                foreach (var method in client.Methods)
                {
                    map.Add(method, client);
                }
            }
            return map;
        }

        internal InputServiceMethod? GetMethodByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => InputMethodsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var method) ? method : null;

        internal InputClient? GetClientByMethod(InputServiceMethod method)
            => IntMethodClientMap.TryGetValue(method, out var client) ? client : null;

        internal ResourceMetadata? GetResourceMetadata(InputModelType model)
            => ResourceMetadata.TryGetValue(model, out var metadata) ? metadata : null;

        internal InputModelType? GetModelByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => InputModelsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var model) ? model : null;

        internal InputClient? GetClientByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => InputClientsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var client) ? client : null;

        internal bool IsResourceModel(InputModelType model)
            => model.Decorators.Any(d => d.Name.Equals(KnownDecorators.ResourceMetadata));

        private IReadOnlyDictionary<string, InputModelType> BuildModelCrossLanguageDefinitionIds()
        {
            // TODO -- we must have this because of a bug or a design issue in TCGC: https://github.com/Azure/typespec-azure/issues/1297
            // once this is solved, we could change this to the simple invocation of `ToDictionary`.
            var result = new Dictionary<string, InputModelType>();
            foreach (var model in InputNamespace.Models)
            {
                if (!result.ContainsKey(model.CrossLanguageDefinitionId))
                {
                    result.Add(model.CrossLanguageDefinitionId, model);
                }
            }
            return result;
        }

        private IReadOnlyDictionary<InputModelType, ResourceMetadata> DeserializeResourceMetadata()
        {
            var resourceMetadata = new Dictionary<InputModelType, ResourceMetadata>();
            foreach (var model in InputNamespace.Models)
            {
                var decorator = model.Decorators.FirstOrDefault(d => d.Name == KnownDecorators.ResourceMetadata);
                if (decorator != null)
                {
                    var metadata = BuildResourceMetadata(decorator);
                    resourceMetadata.Add(model, metadata);
                }
            }
            return resourceMetadata;

            ResourceMetadata BuildResourceMetadata(InputDecoratorInfo decorator)
            {
                var args = decorator.Arguments ?? throw new InvalidOperationException();
                string? resourceType = null;
                bool isSingleton = false;
                ResourceScope? resourceScope = null;
                var methods = new List<ResourceMethod>();
                string? parentResource = null;
                if (args.TryGetValue(KnownDecorators.ResourceType, out var resourceTypeData))
                {
                    resourceType = resourceTypeData.ToObjectFromJson<string>();
                }

                if (args.TryGetValue(KnownDecorators.IsSingleton, out var isSingletonData))
                {
                    isSingleton = isSingletonData.ToObjectFromJson<bool>();
                }

                if (args.TryGetValue(KnownDecorators.ResourceScope, out var scopeData))
                {
                    var scopeString = scopeData.ToObjectFromJson<string>();
                    if (Enum.TryParse<ResourceScope>(scopeString, true, out var scope))
                    {
                        resourceScope = scope;
                    }
                }

                if (args.TryGetValue(KnownDecorators.Methods, out var operationsData))
                {
                    using var document = JsonDocument.Parse(operationsData);
                    var element = document.RootElement;
                    if (element.ValueKind != JsonValueKind.Array)
                    {
                        throw new InvalidOperationException($"Expected an array for {KnownDecorators.Methods}, but got {element.ValueKind}.");
                    }
                    foreach (var item in element.EnumerateArray())
                    {
                        string? id = null;
                        OperationKind? operationKind = null;
                        if (item.ValueKind != JsonValueKind.Object)
                        {
                            throw new InvalidOperationException($"Expected an object in the array for {KnownDecorators.Methods}, but got {item.ValueKind}.");
                        }
                        if (item.TryGetProperty("id", out var idData))
                        {
                            id = idData.GetString();
                        }
                        if (item.TryGetProperty("kind", out var kindData) && kindData.GetString() is string kindString)
                        {
                            if (Enum.TryParse<OperationKind>(kindString, true, out var kind))
                            {
                                operationKind = kind;
                            }
                        }
                        methods.Add(new ResourceMethod(id ?? throw new InvalidOperationException("id cannot be null"), operationKind ?? throw new InvalidOperationException("operationKind cannot be null")));
                    }
                }

                if (args.TryGetValue(KnownDecorators.ParentResource, out var parentResourceData))
                {
                    parentResource = parentResourceData.ToObjectFromJson<string>();
                }

                // TODO -- I know we should never throw the exception, but here we just put it here and refine it later
                return new(
                    resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
                    isSingleton,
                    resourceScope ?? throw new InvalidOperationException("resourceScope cannot be null"),
                    methods,
                    parentResource);
            }
        }
    }
}
