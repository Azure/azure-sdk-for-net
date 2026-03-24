// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary> Represents an RBAC role definition for a resource. </summary>
/// <param name="Name"> The role name (e.g., "KeyVaultContributor"). </param>
/// <param name="Value"> The role GUID (e.g., "f25e0fa2-a7c8-4377-a976-54943a77a395"). </param>
public record ArmResourceRbacRole(
    string Name,
    string Value)
{
    internal static ArmResourceRbacRole DeserializeRbacRole(JsonElement element)
    {
        string? name = null;
        string? value = null;

        if (element.TryGetProperty("name", out var nameElement))
        {
            name = nameElement.GetString();
        }
        if (element.TryGetProperty("value", out var valueElement))
        {
            value = valueElement.GetString();
        }

        return new(
            name ?? throw new System.InvalidOperationException("RBAC role name cannot be null"),
            value ?? throw new System.InvalidOperationException("RBAC role value cannot be null"));
    }
}
