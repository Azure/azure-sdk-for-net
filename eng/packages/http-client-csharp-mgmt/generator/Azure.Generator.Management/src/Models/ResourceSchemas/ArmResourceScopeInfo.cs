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
public record ArmResourceScopeInfo(ResourceScope Kind, RequestPathPattern ScopeIdPattern)
{
    internal static ArmResourceScopeInfo Deserialize(JsonElement element)
    {
        ResourceScope? kind = null;
        string? scopeIdPattern = null;

        if (element.TryGetProperty("kind", out var kindElement))
        {
            var kindString = kindElement.GetString();
            if (kindString != null && Enum.TryParse<ResourceScope>(kindString, true, out var scope))
            {
                kind = scope;
            }
        }
        if (element.TryGetProperty("scopeIdPattern", out var scopeIdPatternElement))
        {
            scopeIdPattern = scopeIdPatternElement.GetString();
        }

        return new(
            kind ?? throw new InvalidOperationException("scope.kind cannot be null"),
            new RequestPathPattern(scopeIdPattern ?? string.Empty));
    }
}
