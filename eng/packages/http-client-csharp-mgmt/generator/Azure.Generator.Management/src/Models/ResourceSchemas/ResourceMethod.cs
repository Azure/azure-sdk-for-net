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
/// <param name="OperationScope"> The scope of the operation. </param>
/// <param name="ResourceScopeIdPattern"> The resource ID pattern specifying the scope, if applicable. </param>
/// <param name="InputClient"> The input client. </param>
public record ResourceMethod(
    ResourceOperationKind Kind,
    InputServiceMethod InputMethod,
    string OperationPath,
    ResourceScope OperationScope,
    string? ResourceScopeIdPattern,
    InputClient InputClient)
{
    internal static ResourceMethod DeserializeResourceMethod(JsonElement element)
    {
        string? methodId = null;
        ResourceOperationKind? operationKind = null;
        string? operationPath = null;
        ResourceScope? operationScope = null;
        string? resourceScopeIdPattern = null;
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
            if (prop.NameEquals("operationScope"u8))
            {
                operationScope = Enum.Parse<ResourceScope>(prop.Value.GetString() ?? throw new JsonException("operationScope cannot be null"), true);
            }
            if (prop.NameEquals("resourceScope"u8))
            {
                resourceScopeIdPattern = prop.Value.GetString();
            }
        }
        var inputMethod = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId ?? throw new JsonException("id cannot be null"));
        var inputClient = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(inputMethod ?? throw new JsonException($"cannot find InputServiceMethod {methodId}"));

        return new ResourceMethod(
            operationKind ?? throw new JsonException("operationKind cannot be null"),
            inputMethod,
            operationPath ?? throw new JsonException("operationPath cannot be null"),
            operationScope ?? throw new JsonException("operationScope cannot be null"),
            resourceScopeIdPattern,
            inputClient ?? throw new JsonException($"cannot find method {inputMethod.CrossLanguageDefinitionId}'s client"));
    }
}
