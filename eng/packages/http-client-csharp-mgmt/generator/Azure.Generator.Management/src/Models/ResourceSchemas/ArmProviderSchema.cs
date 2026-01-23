// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Represents the unified ARM provider schema containing all resource metadata and non-resource methods.
/// This consolidates information previously scattered across @resourceSchema and @nonResourceMethodSchema decorators.
/// </summary>
internal class ArmProviderSchema
{
    public IReadOnlyList<ResourceMetadata> Resources { get; }
    public IReadOnlyList<NonResourceMethod> NonResourceMethods { get; }

    public ArmProviderSchema(IReadOnlyList<ResourceMetadata> resources, IReadOnlyList<NonResourceMethod> nonResourceMethods)
    {
        Resources = resources;
        NonResourceMethods = nonResourceMethods;
    }

    /// <summary>
    /// Deserializes the ArmProviderSchema from decorator arguments.
    /// </summary>
    /// <param name="arguments">The decorator arguments containing resources and nonResourceMethods data</param>
    /// <param name="library">The management input library containing models cache</param>
    /// <param name="methodFilter">Optional predicate to filter non-resource methods</param>
    /// <returns>A new ArmProviderSchema instance</returns>
    public static ArmProviderSchema Deserialize(IReadOnlyDictionary<string, BinaryData> arguments, ManagementInputLibrary library, Func<NonResourceMethod, bool>? methodFilter = null)
    {
        var resourceMetadata = new List<ResourceMetadata>();
        var resourceChildren = new Dictionary<string, List<string>>();

        // Deserialize resources
        if (arguments.TryGetValue("resources", out var resourcesData))
        {
            using var document = JsonDocument.Parse(resourcesData);
            foreach (var item in document.RootElement.EnumerateArray())
            {
                var resourceModelId = item.GetProperty("resourceModelId").GetString();
                if (string.IsNullOrEmpty(resourceModelId))
                {
                    continue;
                }

                if (!library.ModelsByCrossLanguageDefinitionId.TryGetValue(resourceModelId, out var model))
                {
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "general-warning",
                        $"Model with cross-language definition ID '{resourceModelId}' not found in namespace. This resource will be skipped.",
                        targetCrossLanguageDefinitionId: resourceModelId);
                    continue;
                }

                var children = new List<string>();
                var metadata = ResourceMetadata.DeserializeResourceMetadata(item, model, children);
                resourceMetadata.Add(metadata);
                resourceChildren.Add(metadata.ResourceIdPattern, children);
            }
        }

        // Second pass to fulfill the children list
        foreach (var resource in resourceMetadata)
        {
            if (resource.ParentResourceId is not null)
            {
                resourceChildren[resource.ParentResourceId].Add(resource.ResourceIdPattern);
            }
        }

        // Deserialize non-resource methods
        var nonResourceMethods = new List<NonResourceMethod>();
        if (arguments.TryGetValue("nonResourceMethods", out var nonResourceMethodsData))
        {
            using var document = JsonDocument.Parse(nonResourceMethodsData);
            foreach (var item in document.RootElement.EnumerateArray())
            {
                var nonResourceMethod = NonResourceMethod.DeserializeNonResourceMethod(item);

                // Apply filter if provided
                if (methodFilter == null || methodFilter(nonResourceMethod))
                {
                    nonResourceMethods.Add(nonResourceMethod);
                }
            }
        }

        return new ArmProviderSchema(resourceMetadata, nonResourceMethods);
    }
}
