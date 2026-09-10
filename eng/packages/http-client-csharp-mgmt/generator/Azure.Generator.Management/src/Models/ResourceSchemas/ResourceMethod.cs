// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary> Represents a method associated with an ARM resource. </summary>
/// <param name="Kind"> The kind of resource operation. </param>
/// <param name="InputMethod"> The input service method. </param>
/// <param name="OperationPath"> The operation path. </param>
/// <param name="Scope"> The scope information for this operation, including the scope kind, ID pattern, and resource type. </param>
/// <param name="InputClient"> The input client. </param>
public record ResourceMethod(
    ResourceOperationKind Kind,
    InputServiceMethod InputMethod,
    RequestPathPattern OperationPath,
    ArmScopeInfo Scope,
    InputClient InputClient)
{
    internal static ResourceMethod DeserializeResourceMethod(JsonElement element)
    {
        string? methodId = null;
        ResourceOperationKind? operationKind = null;
        string? operationPath = null;
        ArmScopeInfo? scope = null;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("methodId"u8))
            {
                methodId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("kind"u8))
            {
                operationKind = Enum.Parse<ResourceOperationKind>(prop.Value.GetString() ?? throw new JsonException("kind cannot be null"), true);
            }
            if (prop.NameEquals("operationPath"u8))
            {
                operationPath = prop.Value.GetString();
            }
            if (prop.NameEquals("scope"u8))
            {
                scope = ArmScopeInfo.Deserialize(prop.Value);
            }
        }
        var inputMethod = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId ?? throw new JsonException("id cannot be null"));
        var inputClient = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(inputMethod ?? throw new JsonException($"cannot find InputServiceMethod {methodId}"));

        return new ResourceMethod(
            operationKind ?? throw new JsonException("operationKind cannot be null"),
            inputMethod,
            new RequestPathPattern(operationPath ?? throw new JsonException("operationPath cannot be null")),
            scope ?? throw new JsonException("scope cannot be null"),
            inputClient ?? throw new JsonException($"cannot find method {inputMethod.CrossLanguageDefinitionId}'s client"));
    }
}
