// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

internal record ResourceMetadata(
    string ResourceIdPattern,
    string ResourceName,
    string ResourceType,
    InputModelType ResourceModel,
    ResourceScope ResourceScope,
    IReadOnlyList<ResourceMethod> Methods,
    string? SingletonResourceName,
    string? ParentResourceId,
    IReadOnlyList<string> ChildResourceIds)
{
    // ChildResourceIds is currently unpopulated and passed in as an empty array
    internal static ResourceMetadata DeserializeResourceMetadata(JsonElement element, InputModelType inputModel, IReadOnlyList<string> childResourceIds)
    {
        string? resourceIdPattern = null;
        string? resourceType = null;
        string? singletonResourceName = null;
        ResourceScope? resourceScope = null;
        var methods = new List<ResourceMethod>();
        string? parentResource = null;
        string? resourceName = null;

        if (element.TryGetProperty("resourceIdPattern", out var resourceIdPatternElement))
        {
            resourceIdPattern = resourceIdPatternElement.GetString();
        }
        if (element.TryGetProperty("resourceType", out var resourceTypeElement))
        {
            resourceType = resourceTypeElement.GetString();
        }
        if (element.TryGetProperty("singletonResourceName", out var singletonResourceElement))
        {
            singletonResourceName = singletonResourceElement.GetString();
        }
        if (element.TryGetProperty("resourceScope", out var scopeElement))
        {
            var scopeString = scopeElement.GetString();
            if (scopeString != null && Enum.TryParse<ResourceScope>(scopeString, true, out var scope))
            {
                resourceScope = scope;
            }

            //TODO: handle Extension resource in emitter
            if (resourceIdPattern is not null && (resourceIdPattern.StartsWith("/{resourceUri}/") || resourceIdPattern.StartsWith("/{scope}/")))
            {
                resourceScope = ResourceScope.Extension;
            }
        }
        if (element.TryGetProperty("methods", out var methodsElement))
        {
            foreach (var item in methodsElement.EnumerateArray())
            {
                methods.Add(ResourceMethod.DeserializeResourceMethod(item));
            }
        }
        if (element.TryGetProperty("parentResourceId", out var parentResourceElement))
        {
            parentResource = parentResourceElement.GetString();
        }
        if (element.TryGetProperty("resourceName", out var resourceNameElement))
        {
            resourceName = resourceNameElement.GetString();
        }

        return new(
            resourceIdPattern ?? throw new InvalidOperationException("resourceIdPattern cannot be null"),
            resourceName ?? throw new InvalidOperationException("resourceName cannot be null"),
            resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
            inputModel,
            resourceScope ?? throw new InvalidOperationException("resourceScope cannot be null"),
            methods,
            singletonResourceName,
            parentResource,
            childResourceIds);
    }
}
