﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementInputLibrary : InputLibrary
    {
        private const string ResourceMetadataDecoratorName = "Azure.ClientGenerator.Core.@resourceSchema";
        private const string NonResourceMethodMetadata = "Azure.ClientGenerator.Core.@nonResourceMethodSchema";
        private const string ResourceIdPattern = "resourceIdPattern";
        private const string ResourceType = "resourceType";
        private const string SingletonResourceName = "singletonResourceName";
        private const string ResourceScope = "resourceScope";
        private const string Methods = "methods";
        private const string ParentResourceId = "parentResourceId";
        private const string ResourceName = "resourceName";

        private IReadOnlyDictionary<string, InputServiceMethod>? _inputServiceMethodsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<InputServiceMethod, InputClient>? _intMethodClientMap;
        private HashSet<InputModelType>? _resourceModels;

        private IReadOnlyDictionary<InputModelType, string>? _resourceUpdateModelToResourceNameMap;

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
        }

        private static readonly HashSet<string> _methodsToOmit = new()
        {
            // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
            "Azure.ResourceManager.Operations.list"
        };

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

        private IReadOnlyList<ResourceMetadata>? _resourceMetadatas;
        internal IReadOnlyList<ResourceMetadata> ResourceMetadatas => _resourceMetadatas ??= DeserializeResourceMetadata();

        private IReadOnlyList<NonResourceMethod>? _nonResourceMethods;
        internal IReadOnlyList<NonResourceMethod> NonResourceMethods => _nonResourceMethods
            ??= DeserializeNonResourceMethods();

        private IReadOnlyDictionary<string, InputServiceMethod> InputMethodsByCrossLanguageDefinitionId => _inputServiceMethodsByCrossLanguageDefinitionId ??= InputNamespace.Clients.SelectMany(c => c.Methods).ToDictionary(m => m.CrossLanguageDefinitionId, m => m);

        private IReadOnlyDictionary<InputServiceMethod, InputClient> InputMethodClientMap => _intMethodClientMap ??= ConstructMethodClientMap();

        private IReadOnlyDictionary<InputModelType, string> ResourceUpdateModelToResourceNameMap => _resourceUpdateModelToResourceNameMap ??= BuildResourceUpdateModelToResourceNameMap();

        // If there're multiple API versions in the input namespace, use the last one as the default.
        internal string DefaultApiVersion => InputNamespace.ApiVersions.Last();

        private IReadOnlyDictionary<InputModelType, string> BuildResourceUpdateModelToResourceNameMap()
        {
            Dictionary<InputModelType, string> map = new();

            foreach (var metadata in ResourceMetadatas)
            {
                var inputMethod = metadata.Methods.Where(m => m.Kind == ResourceOperationKind.Update).FirstOrDefault()?.InputMethod;
                if (inputMethod is { Operation.HttpMethod: "PATCH" } patchMethod)
                {
                    foreach (var parameter in patchMethod.Parameters)
                    {
                        if (parameter.Location == InputRequestLocation.Body && parameter.Type is InputModelType updateModel && updateModel != metadata.ResourceModel)
                        {
                            map[updateModel] = metadata.ResourceModel.Name;
                            break;
                        }
                    }
                }
            }

            return map;
        }

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
            => InputMethodClientMap.TryGetValue(method, out var client) ? client : null;

        internal bool IsResourceModel(InputModelType model) => ResourceModels.Contains(model);

        private IReadOnlyList<ResourceMetadata> DeserializeResourceMetadata()
        {
            var resourceMetadata = new List<ResourceMetadata>();
            foreach (var model in InputNamespace.Models)
            {
                var decorator = model.Decorators.FirstOrDefault(d => d.Name == ResourceMetadataDecoratorName);
                if (decorator != null)
                {
                    var metadata = BuildResourceMetadata(decorator, model);
                    resourceMetadata.Add(metadata);
                }
            }
            return resourceMetadata;

            ResourceMetadata BuildResourceMetadata(InputDecoratorInfo decorator, InputModelType inputModel)
            {
                var args = decorator.Arguments ?? throw new InvalidOperationException();
                string? resourceIdPattern = null;
                string? resourceType = null;
                string? singletonResourceName = null;
                ResourceScope? resourceScope = null;
                var methods = new List<ResourceMethod>();
                string? parentResource = null;
                string? resourceName = null;
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
                        var inputMethod = GetMethodByCrossLanguageDefinitionId(id ?? throw new InvalidOperationException("id cannot be null"));
                        var inputClient = GetClientByMethod(inputMethod ?? throw new InvalidOperationException($"cannot find InputServiceMethod {id}"));
                        methods.Add(
                            new ResourceMethod(
                                operationKind ?? throw new InvalidOperationException("operationKind cannot be null"),
                                inputMethod,
                                inputClient ?? throw new InvalidOperationException($"cannot find method {inputMethod.CrossLanguageDefinitionId}'s client")));
                    }
                }

                if (args.TryGetValue(ParentResourceId, out var parentResourceData))
                {
                    parentResource = parentResourceData.ToObjectFromJson<string>();
                }

                if (args.TryGetValue(ResourceName, out var resourceNameData))
                {
                    resourceName = resourceNameData.ToObjectFromJson<string>();
                }

                // TODO -- I know we should never throw the exception, but here we just put it here and refine it later
                return new(
                    resourceIdPattern ?? throw new InvalidOperationException("resourceIdPattern cannot be null"),
                    resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
                    inputModel,
                    resourceScope ?? throw new InvalidOperationException("resourceScope cannot be null"),
                    methods,
                    singletonResourceName,
                    parentResource,
                    resourceName ?? throw new InvalidOperationException("resourceName cannot be null"));
            }
        }

        private IReadOnlyList<NonResourceMethod> DeserializeNonResourceMethods()
        {
            var rootClient = InputNamespace.RootClients.First();
            var decorator = rootClient.Decorators.FirstOrDefault(d => d.Name == NonResourceMethodMetadata);
            if (decorator is null)
            {
                return [];
            }

            var nonResourceMethodMetadata = new List<NonResourceMethod>();
            // deserialize the decorator arguments
            var args = decorator.Arguments ?? throw new InvalidOperationException();
            if (args.TryGetValue("nonResourceMethods", out var nonResourceMethods))
            {
                using var document = JsonDocument.Parse(nonResourceMethods);
                foreach (var item in document.RootElement.EnumerateArray())
                {
                    var methodId = item.GetProperty("methodId").GetString() ?? throw new JsonException("methodId cannot be null");
                    if (_methodsToOmit.Contains(methodId))
                    {
                        continue; // skip methods that are not needed
                    }
                    var operationScopeString = item.GetProperty("operationScope").GetString() ?? throw new JsonException("operationScope cannot be null");
                    // find the method by its ID
                    var method = GetMethodByCrossLanguageDefinitionId(methodId) ?? throw new JsonException($"cannot find the method with crossLanguageDefinitionId {methodId}");
                    var client = GetClientByMethod(method) ?? throw new JsonException($"cannot find the client for method {methodId}");
                    var operationScope = Enum.Parse<ResourceScope>(operationScopeString, true);
                    nonResourceMethodMetadata.Add(new NonResourceMethod(
                        operationScope,
                        method,
                        client));
                }
            }

            return nonResourceMethodMetadata;
        }

        internal bool TryFindEnclosingResourceNameForResourceUpdateModel(InputModelType model, [NotNullWhen(true)] out string? resourceName)
        {
            return ResourceUpdateModelToResourceNameMap.TryGetValue(model, out resourceName);
        }
    }
}
