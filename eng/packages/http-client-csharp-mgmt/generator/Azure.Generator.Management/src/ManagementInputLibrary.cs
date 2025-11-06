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
            HashSet<InputModelType> duplicateUpdateModels = new();

            foreach (var metadata in ResourceMetadatas)
            {
                var inputMethod = metadata.Methods.Where(m => m.Kind == ResourceOperationKind.Update).FirstOrDefault()?.InputMethod;
                if (inputMethod is { Operation.HttpMethod: "PATCH" } patchMethod)
                {
                    foreach (var parameter in patchMethod.Parameters)
                    {
                        if (parameter.Location == InputRequestLocation.Body && parameter.Type is InputModelType updateModel && updateModel != metadata.ResourceModel)
                        {
                            if (map.ContainsKey(updateModel))
                            {
                                duplicateUpdateModels.Add(updateModel);
                            }
                            map[updateModel] = metadata.ResourceModel.Name;
                            break;
                        }
                    }
                }
            }

            // Remove update models that are used in more than one resource
            foreach (var duplicateModel in duplicateUpdateModels)
            {
                map.Remove(duplicateModel);
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
            var resourceChildren = new Dictionary<string, List<string>>();
            // we build the resource metadata instances first to ensure that we already have everything before we figure out the children
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
            var decorator = rootClient.Decorators.FirstOrDefault(d => d.Name == NonResourceMethodMetadata);
            var args = decorator?.Arguments;
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
