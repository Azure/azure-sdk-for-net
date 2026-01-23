// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementInputLibrary : InputLibrary
    {
        private const string ArmProviderSchemaDecoratorName = "Azure.ClientGenerator.Core.@armProviderSchema";
        private const string FlattenPropertyDecoratorName = "Azure.ResourceManager.@flattenProperty";

        private IReadOnlyDictionary<string, InputServiceMethod>? _inputServiceMethodsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<InputServiceMethod, InputClient>? _intMethodClientMap;
        private HashSet<InputModelType>? _resourceModels;
        private ArmProviderSchema? _providerSchema;
        private IReadOnlyDictionary<string, InputModelType>? _modelsByCrossLanguageDefinitionId;

        private IReadOnlyDictionary<InputModelType, string>? _resourceUpdateModelToResourceNameMap;

        internal IReadOnlyDictionary<string, InputModelType> ModelsByCrossLanguageDefinitionId => _modelsByCrossLanguageDefinitionId ??= BuildModelsByCrossLanguageDefinitionId();

        private IReadOnlyDictionary<string, InputModelType> BuildModelsByCrossLanguageDefinitionId()
        {
            var result = new Dictionary<string, InputModelType>();
            foreach (var model in InputNamespace.Models)
            {
                if (string.IsNullOrEmpty(model.CrossLanguageDefinitionId))
                {
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "general-warning",
                        $"Model '{model.Name}' has empty or null cross-language definition ID. This model will be skipped in the cache.",
                        targetCrossLanguageDefinitionId: model.Name);
                    continue;
                }

                if (result.ContainsKey(model.CrossLanguageDefinitionId))
                {
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "general-warning",
                        $"Duplicate cross-language definition ID found: '{model.CrossLanguageDefinitionId}' for model '{model.Name}'. This model will be skipped in the cache.",
                        targetCrossLanguageDefinitionId: model.CrossLanguageDefinitionId);
                    continue;
                }

                result[model.CrossLanguageDefinitionId] = model;
            }
            return result;
        }

        private IReadOnlyDictionary<InputModelType, IList<InputModelProperty>>? _flattenPropertyMap;
        internal IReadOnlyDictionary<InputModelType, IList<InputModelProperty>> FlattenPropertyMap => _flattenPropertyMap ??= BuildFlattenPropertyMap();
        private IReadOnlyDictionary<InputModelType, IList<InputModelProperty>> BuildFlattenPropertyMap()
        {
            var result = new Dictionary<InputModelType, IList<InputModelProperty>>();
            foreach (var model in InputNamespace.Models)
            {
                foreach (var property in model.Properties)
                {
                    if (property.Decorators.Any(d => d.Name == FlattenPropertyDecoratorName))
                    {
                        // skip discriminator property
                        if (property.IsDiscriminator)
                        {
                            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic("general-warning", "Discriminator property should not be flattened.", targetCrossLanguageDefinitionId: model.CrossLanguageDefinitionId);
                            continue;
                        }
                        if (!result.TryGetValue(model, out var properties))
                        {
                            properties = new List<InputModelProperty>();
                            result[model] = properties;
                        }
                        properties.Add(property);
                    }
                }
            }
            return result;
        }

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
        }

        private static readonly HashSet<string> _methodsToOmit = new()
        {
            // operations_list has been covered in Azure.ResourceManager already, we don't need to generate it in the client
            "Azure.ResourceManager.Operations.list",
            "Azure.ResourceManager.Legacy.Operations.list"
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

        private HashSet<InputModelType> ResourceModels => _resourceModels ??= BuildResourceModels();

        private HashSet<InputModelType> BuildResourceModels()
        {
            // Get resource models from ArmProviderSchema
            var resourceModels = new HashSet<InputModelType>();
            foreach (var resource in ArmProviderSchema.Resources)
            {
                if (resource.ResourceModel != null)
                {
                    resourceModels.Add(resource.ResourceModel);
                }
            }

            return resourceModels;
        }

        internal IReadOnlyList<ResourceMetadata> ResourceMetadatas => ArmProviderSchema.Resources;

        internal IReadOnlyList<NonResourceMethod> NonResourceMethods => ArmProviderSchema.NonResourceMethods;

        private IReadOnlyDictionary<string, InputServiceMethod> InputMethodsByCrossLanguageDefinitionId => _inputServiceMethodsByCrossLanguageDefinitionId ??= InputNamespace.Clients.SelectMany(c => c.Methods).ToDictionary(m => m.CrossLanguageDefinitionId, m => m);

        private IReadOnlyDictionary<InputServiceMethod, InputClient> InputMethodClientMap => _intMethodClientMap ??= ConstructMethodClientMap();

        private IReadOnlyDictionary<InputModelType, string> ResourceUpdateModelToResourceNameMap => _resourceUpdateModelToResourceNameMap ??= BuildResourceUpdateModelToResourceNameMap();

        internal ArmProviderSchema ArmProviderSchema => _providerSchema ??= BuildArmProviderSchema();

        // If there're multiple API versions in the input namespace, use the last one as the default.
        internal string DefaultApiVersion => InputNamespace.ApiVersions.Last();

        private IReadOnlyDictionary<InputModelType, string> BuildResourceUpdateModelToResourceNameMap()
        {
            Dictionary<InputModelType, (string ResourceName, int Count)> tempMap = new();

            foreach (var metadata in ResourceMetadatas)
            {
                var inputMethod = metadata.Methods.Where(m => m.Kind == ResourceOperationKind.Update).FirstOrDefault()?.InputMethod;
                if (inputMethod is { Operation.HttpMethod: "PATCH" } patchMethod)
                {
                    foreach (var parameter in patchMethod.Parameters)
                    {
                        if (parameter.Location == InputRequestLocation.Body && parameter.Type is InputModelType updateModel && updateModel != metadata.ResourceModel)
                        {
                            if (tempMap.TryGetValue(updateModel, out var existing))
                            {
                                tempMap[updateModel] = (existing.ResourceName, existing.Count + 1);
                            }
                            else
                            {
                                tempMap[updateModel] = (metadata.ResourceModel.Name, 1);
                            }
                            break;
                        }
                    }
                }
            }

            // Only keep update models that are used in exactly one resource (count == 1)
            return tempMap
                .Where(kvp => kvp.Value.Count == 1)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ResourceName);
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

        private ArmProviderSchema BuildArmProviderSchema()
        {
            var rootClient = InputNamespace.RootClients.FirstOrDefault();
            if (rootClient == null)
            {
                // Fallback to empty schema if no root client is available
                return new ArmProviderSchema(Array.Empty<ResourceMetadata>(), Array.Empty<NonResourceMethod>());
            }

            var armProviderDecorators = rootClient.Decorators
                .Where(d => d.Name == ArmProviderSchemaDecoratorName)
                .ToList();

            if (armProviderDecorators.Count == 0)
            {
                // Fallback to empty schema if decorator not found
                return new ArmProviderSchema(Array.Empty<ResourceMetadata>(), Array.Empty<NonResourceMethod>());
            }

            var resourcesByIdPattern = new Dictionary<string, ResourceMetadata>(StringComparer.OrdinalIgnoreCase);
            var nonResourceMethodsById = new Dictionary<string, NonResourceMethod>(StringComparer.OrdinalIgnoreCase);

            foreach (var decorator in armProviderDecorators)
            {
                if (decorator.Arguments == null)
                {
                    continue;
                }

                // Filter out methods that should be omitted during deserialization
                var schema = ArmProviderSchema.Deserialize(
                    decorator.Arguments,
                    this,
                    methodFilter: m => !_methodsToOmit.Contains(m.InputMethod.CrossLanguageDefinitionId));

                foreach (var resource in schema.Resources)
                {
                    resourcesByIdPattern.TryAdd(resource.ResourceIdPattern, resource);
                }

                foreach (var nonResourceMethod in schema.NonResourceMethods)
                {
                    nonResourceMethodsById.TryAdd(nonResourceMethod.InputMethod.CrossLanguageDefinitionId, nonResourceMethod);
                }
            }

            return new ArmProviderSchema(resourcesByIdPattern.Values.ToList(), nonResourceMethodsById.Values.ToList());
        }

        internal InputServiceMethod? GetMethodByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => InputMethodsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var method) ? method : null;

        internal InputClient? GetClientByMethod(InputServiceMethod method)
            => InputMethodClientMap.TryGetValue(method, out var client) ? client : null;

        internal bool IsResourceModel(InputModelType model) => ResourceModels.Contains(model);

        internal bool TryFindEnclosingResourceNameForResourceUpdateModel(InputModelType model, [NotNullWhen(true)] out string? resourceName)
        {
            return ResourceUpdateModelToResourceNameMap.TryGetValue(model, out resourceName);
        }
    }
}
