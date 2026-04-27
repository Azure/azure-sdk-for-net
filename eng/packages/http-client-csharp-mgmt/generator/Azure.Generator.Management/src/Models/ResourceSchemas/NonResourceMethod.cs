// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary> Represents a method that is not associated with a specific ARM resource. </summary>
/// <param name="Scope"> The scope information for this operation, including the scope kind, ID pattern, and resource type. </param>
/// <param name="InputMethod"> The input service method. </param>
/// <param name="InputClient"> The input client. </param>
public record NonResourceMethod(
    ArmScopeInfo Scope,
    InputServiceMethod InputMethod,
    InputClient InputClient)
{
    internal static NonResourceMethod DeserializeNonResourceMethod(JsonElement element)
    {
        string? methodId = null;
        ArmScopeInfo? scope = null;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("methodId"u8))
            {
                methodId = prop.Value.GetString();
            }
            if (prop.NameEquals("scope"u8) && prop.Value.ValueKind != JsonValueKind.Null)
            {
                scope = ArmScopeInfo.Deserialize(prop.Value);
            }
        }
        // find the method by its ID
        var method = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId ?? throw new JsonException("methodId cannot be null")) ?? throw new JsonException($"cannot find the method with crossLanguageDefinitionId {methodId}");
        var client = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(method) ?? throw new JsonException($"cannot find the client for method {methodId}");
        return new NonResourceMethod(
            scope ?? throw new JsonException("scope cannot be null"),
            method,
            client);
    }
}