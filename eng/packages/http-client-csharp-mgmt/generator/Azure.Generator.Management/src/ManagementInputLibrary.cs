// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
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
        private const string ArmProviderSchemaDecoratorName = "Azure.ClientGenerator.Core.@armProviderSchema";
        private const string FlattenPropertyDecoratorName = "Azure.ResourceManager.@flattenProperty";

        private IReadOnlyDictionary<string, InputServiceMethod>? _inputServiceMethodsByCrossLanguageDefinitionId;
        private IReadOnlyDictionary<InputServiceMethod, InputClient>? _intMethodClientMap;
        private HashSet<InputModelType>? _resourceModels;

        private IReadOnlyDictionary<InputModelType, string>? _resourceUpdateModelToResourceNameMap;

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
            var resourceModels = new HashSet<InputModelType>();

            // First, try to get resource models from the new unified decorator
            var rootClient = InputNamespace.RootClients.First();
            var armProviderDecorator = rootClient.Decorators.FirstOrDefault(d => d.Name == ArmProviderSchemaDecoratorName);

            if (armProviderDecorator?.Arguments != null && armProviderDecorator.Arguments.TryGetValue("resources", out var resourcesData))
            {
                using var document = JsonDocument.Parse(resourcesData);
                foreach (var item in document.RootElement.EnumerateArray())
                {
                    var resourceModelId = item.GetProperty("resourceModelId").GetString();
                    var model = InputNamespace.Models.FirstOrDefault(m => m.CrossLanguageDefinitionId == resourceModelId);
                    if (model != null)
                    {
                        resourceModels.Add(model);
                    }
                }
            }
            else
            {
                // Fall back to old decorator on individual models
                foreach (var model in InputNamespace.Models.Where(m => m.Decorators.Any(d => d.Name.Equals(ResourceMetadataDecoratorName))))
                {
                    resourceModels.Add(model);
                }
            }

            return resourceModels;
        }

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

        internal InputServiceMethod? GetMethodByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => InputMethodsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var method) ? method : null;

        internal InputClient? GetClientByMethod(InputServiceMethod method)
            => InputMethodClientMap.TryGetValue(method, out var client) ? client : null;

        internal bool IsResourceModel(InputModelType model) => ResourceModels.Contains(model);

        private IReadOnlyList<ResourceMetadata> DeserializeResourceMetadata()
        {
            var resourceMetadata = new List<ResourceMetadata>();
            var resourceChildren = new Dictionary<string, List<string>>();

            // First, try to get resources from the new unified @armProviderSchema decorator on root client
            var rootClient = InputNamespace.RootClients.First();
            var armProviderDecorator = rootClient.Decorators.FirstOrDefault(d => d.Name == ArmProviderSchemaDecoratorName);

            if (armProviderDecorator?.Arguments != null && armProviderDecorator.Arguments.TryGetValue("resources", out var resourcesData))
            {
                // Deserialize from the new unified decorator
                using var document = JsonDocument.Parse(resourcesData);
                foreach (var item in document.RootElement.EnumerateArray())
                {
                    var resourceModelId = item.GetProperty("resourceModelId").GetString();
                    var model = InputNamespace.Models.FirstOrDefault(m => m.CrossLanguageDefinitionId == resourceModelId);
                    if (model != null)
                    {
                        var children = new List<string>();
                        var metadata = ResourceMetadata.DeserializeResourceMetadataFromArmProviderSchema(item, model, children);
                        resourceMetadata.Add(metadata);
                        resourceChildren.Add(metadata.ResourceIdPattern, children);
                    }
                }
            }
            else
            {
                // Fall back to the old decorator on individual models for backward compatibility
                foreach (var model in InputNamespace.Models)
                {
                    var decorator = model.Decorators.FirstOrDefault(d => d.Name == ResourceMetadataDecoratorName);
                    if (decorator?.Arguments != null)
                    {
                        var children = new List<string>();
                        var metadata = ResourceMetadata.DeserializeResourceMetadata(decorator.Arguments, model, children);
                        resourceMetadata.Add(metadata);
                        resourceChildren.Add(metadata.ResourceIdPattern, children);
                    }
                }
            }

            // we go a second pass to fulfill the children list
            foreach (var resource in resourceMetadata)
            {
                // finds my parent
                if (resource.ParentResourceId is not null)
                {
                    // add the resource id to the parent's children list
                    resourceChildren[resource.ParentResourceId].Add(resource.ResourceIdPattern);
                }
            }
            return resourceMetadata;
        }

        private IReadOnlyList<NonResourceMethod> DeserializeNonResourceMethods()
        {
            var rootClient = InputNamespace.RootClients.First();

            // First, try to get non-resource methods from the new unified @armProviderSchema decorator
            var armProviderDecorator = rootClient.Decorators.FirstOrDefault(d => d.Name == ArmProviderSchemaDecoratorName);
            IReadOnlyDictionary<string, System.BinaryData>? args = null;

            if (armProviderDecorator?.Arguments != null)
            {
                args = armProviderDecorator.Arguments;
            }
            else
            {
                // Fall back to the old @nonResourceMethodSchema decorator for backward compatibility
                var decorator = rootClient.Decorators.FirstOrDefault(d => d.Name == NonResourceMethodMetadata);
                args = decorator?.Arguments;
            }

            if (args is null)
            {
                return [];
            }

            var nonResourceMethodMetadata = new List<NonResourceMethod>();
            // deserialize the decorator arguments
            if (args.TryGetValue("nonResourceMethods", out var nonResourceMethods))
            {
                using var document = JsonDocument.Parse(nonResourceMethods);
                foreach (var item in document.RootElement.EnumerateArray())
                {
                    var nonResourceMethod = NonResourceMethod.DeserializeNonResourceMethod(item);
                    if (_methodsToOmit.Contains(nonResourceMethod.InputMethod.CrossLanguageDefinitionId))
                    {
                        continue; // skip methods that we don't want to generate
                    }
                    nonResourceMethodMetadata.Add(nonResourceMethod);
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
