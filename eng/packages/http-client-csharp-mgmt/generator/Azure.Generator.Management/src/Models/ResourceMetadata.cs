// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Generator.Management.Models
{
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
        // the childResourceIds parameter will be populated by the caller of this method later
        internal static ResourceMetadata DeserializeResourceMetadata(IReadOnlyDictionary<string, BinaryData> args, InputModelType inputModel, IReadOnlyList<string> childResourceIds)
        {
            string? resourceIdPattern = null;
            string? resourceType = null;
            string? singletonResourceName = null;
            ResourceScope? resourceScope = null;
            var methods = new List<ResourceMethod>();
            string? parentResource = null;
            string? resourceName = null;
            if (args.TryGetValue("resourceIdPattern", out var resourceIdPatternData))
            {
                resourceIdPattern = resourceIdPatternData.ToObjectFromJson<string>();
            }
            if (args.TryGetValue("resourceType", out var resourceTypeData))
            {
                resourceType = resourceTypeData.ToObjectFromJson<string>();
            }

            if (args.TryGetValue("singletonResourceName", out var singletonResourceData))
            {
                singletonResourceName = singletonResourceData.ToObjectFromJson<string>();
            }

            if (args.TryGetValue("resourceScope", out var scopeData))
            {
                var scopeString = scopeData.ToObjectFromJson<string>();
                if (Enum.TryParse<ResourceScope>(scopeString, true, out var scope))
                {
                    resourceScope = scope;
                }

                //TODO: handle Extension resource in emitter
                if (resourceIdPattern is not null && (resourceIdPattern.StartsWith("/{resourceUri}/") || resourceIdPattern.StartsWith("/{scope}/")))
                {
                    resourceScope = ResourceScope.Extension;
                }
            }

            if (args.TryGetValue("methods", out var operationsData))
            {
                using var document = JsonDocument.Parse(operationsData);
                foreach (var item in document.RootElement.EnumerateArray())
                {
                    methods.Add(ResourceMethod.DeserializeResourceMethod(item));
                }
            }

            if (args.TryGetValue("parentResourceId", out var parentResourceData))
            {
                parentResource = parentResourceData.ToObjectFromJson<string>();
            }

            if (args.TryGetValue("resourceName", out var resourceNameData))
            {
                resourceName = resourceNameData.ToObjectFromJson<string>();
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
}
