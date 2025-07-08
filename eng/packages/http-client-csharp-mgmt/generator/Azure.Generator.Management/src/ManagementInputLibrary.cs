// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
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
        private const string ResourceMetadataDecoratorName = "Azure.ClientGenerator.Core.@resourceSchema";
        private const string ResourceIdPattern = "resourceIdPattern";
        private const string ResourceType = "resourceType";
        private const string SingletonResourceName = "singletonResourceName";
        private const string ResourceScope = "resourceScope";
        private const string Methods = "methods";
        private const string ParentResource = "parentResource";

        private IReadOnlyDictionary<InputModelType, ResourceMetadata>? _resourceMetadata;
        private IReadOnlyDictionary<string, InputServiceMethod>? _inputServiceMethodsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<InputServiceMethod, InputClient>? _intMethodClientMap;
        private HashSet<InputModelType>? _resourceModels;

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
        }

        private InputNamespace? _inputNamespace;
        /// <inheritdoc/>
        public override InputNamespace InputNamespace => _inputNamespace ??= BuildInputNamespaceInternal();

        private InputNamespace BuildInputNamespaceInternal()
        {
            // For MPG, we always generate convenience methods for all operations.
            foreach (var client in base.InputNamespace.Clients)
            {
                foreach (var method in client.Methods)
                {
                    method.Operation.Update(generateConvenienceMethod: true);
                }
            }

            return base.InputNamespace;
        }

        private HashSet<InputModelType> ResourceModels => _resourceModels ??= [.. InputNamespace.Models.Where(m => m.Decorators.Any(d => d.Name.Equals(ResourceMetadataDecoratorName)))];

        private IReadOnlyDictionary<InputModelType, ResourceMetadata> ResourceMetadata => _resourceMetadata ??= DeserializeResourceMetadata();

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

        internal bool IsResourceModel(InputModelType model) => ResourceModels.Contains(model);

        private IReadOnlyDictionary<InputModelType, ResourceMetadata> DeserializeResourceMetadata()
        {
            var resourceMetadata = new Dictionary<InputModelType, ResourceMetadata>();
            foreach (var model in InputNamespace.Models)
            {
                var decorator = model.Decorators.FirstOrDefault(d => d.Name == ResourceMetadataDecoratorName);
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
                string? resourceIdPattern = null;
                string? resourceType = null;
                string? singletonResourceName = null;
                ResourceScope? resourceScope = null;
                var methods = new List<ResourceMethod>();
                string? parentResource = null;
                if (args.TryGetValue(ResourceIdPattern, out var resourceIdPatternData))
                {
                    resourceIdPattern = resourceIdPatternData.ToObjectFromJson<string>();
                }
                if (args.TryGetValue(ResourceType, out var resourceTypeData))
                {
                    resourceType = resourceTypeData.ToObjectFromJson<string>();
                }

                if (args.TryGetValue(SingletonResourceName, out var singletonResourceData))
                {
                    singletonResourceName = singletonResourceData.ToObjectFromJson<string>();
                }

                if (args.TryGetValue(ResourceScope, out var scopeData))
                {
                    var scopeString = scopeData.ToObjectFromJson<string>();
                    if (Enum.TryParse<ResourceScope>(scopeString, true, out var scope))
                    {
                        resourceScope = scope;
                    }
                }

                if (args.TryGetValue(Methods, out var operationsData))
                {
                    using var document = JsonDocument.Parse(operationsData);
                    var element = document.RootElement;
                    if (element.ValueKind != JsonValueKind.Array)
                    {
                        throw new InvalidOperationException($"Expected an array for {Methods}, but got {element.ValueKind}.");
                    }
                    foreach (var item in element.EnumerateArray())
                    {
                        string? id = null;
                        ResourceOperationKind? operationKind = null;
                        if (item.ValueKind != JsonValueKind.Object)
                        {
                            throw new InvalidOperationException($"Expected an object in the array for {Methods}, but got {item.ValueKind}.");
                        }
                        if (item.TryGetProperty("id", out var idData))
                        {
                            id = idData.GetString();
                        }
                        if (item.TryGetProperty("kind", out var kindData) && kindData.GetString() is string kindString)
                        {
                            if (Enum.TryParse<ResourceOperationKind>(kindString, true, out var kind))
                            {
                                operationKind = kind;
                            }
                        }
                        methods.Add(new ResourceMethod(id ?? throw new InvalidOperationException("id cannot be null"), operationKind ?? throw new InvalidOperationException("operationKind cannot be null")));
                    }
                }

                if (args.TryGetValue(ParentResource, out var parentResourceData))
                {
                    parentResource = parentResourceData.ToObjectFromJson<string>();
                }

                // TODO -- I know we should never throw the exception, but here we just put it here and refine it later
                return new(
                    resourceIdPattern ?? throw new InvalidOperationException("resourceIdPattern cannot be null"),
                    resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
                    resourceScope ?? throw new InvalidOperationException("resourceScope cannot be null"),
                    methods,
                    singletonResourceName,
                    parentResource);
            }
        }
    }
}
