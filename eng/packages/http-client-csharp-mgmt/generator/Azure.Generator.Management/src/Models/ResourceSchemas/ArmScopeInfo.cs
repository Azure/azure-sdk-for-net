// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary>
/// Describes the ARM scope of a resource, including the scope kind and the scope's ID pattern.
/// </summary>
/// <param name="Kind"> The kind of scope (Tenant, Subscription, ResourceGroup, ManagementGroup, Extension). </param>
/// <param name="ScopeIdPattern"> The scope's ID pattern as a parsed request path. </param>
/// <param name="ScopeResourceType"> The ARM resource type of the scope (e.g., "Microsoft.Compute/virtualMachines"). Null when the scope is empty (tenant scope), or when the resource type contains variable segments. </param>
public record ArmScopeInfo(ResourceScope Kind, RequestPathPattern ScopeIdPattern, string? ScopeResourceType)
{
    internal static ArmScopeInfo Deserialize(JsonElement element)
    {
        ResourceScope? kind = null;
        string? resourceType = null;

        if (element.TryGetProperty("kind", out var kindElement))
        {
            var kindString = kindElement.GetString();
            if (kindString != null && Enum.TryParse<ResourceScope>(kindString, true, out var scope))
            {
                kind = scope;
            }
        }

        if (!element.TryGetProperty("scopeIdPattern", out var scopeIdPatternElement))
        {
            throw new JsonException("Required JSON property 'scopeIdPattern' was not found.");
        }
        var scopeIdPattern = scopeIdPatternElement.GetString();

        if (element.TryGetProperty("scopeResourceType", out var resourceTypeElement))
        {
            resourceType = resourceTypeElement.GetString();
        }

        return new(
            kind ?? throw new JsonException("Required JSON property 'kind' is missing or invalid."),
            new RequestPathPattern(scopeIdPattern ?? throw new JsonException("Required JSON property 'scopeIdPattern' cannot be null.")),
            resourceType);
    }
}
