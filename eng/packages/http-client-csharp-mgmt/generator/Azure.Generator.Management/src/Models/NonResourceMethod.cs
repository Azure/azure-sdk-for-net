// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Text.Json;

namespace Azure.Generator.Management.Models;

internal record NonResourceMethod(
    ResourceScope OperationScope,
    InputServiceMethod InputMethod,
    InputClient InputClient)
{
    internal static NonResourceMethod DeserializeNonResourceMethod(JsonElement element)
    {
        string? methodId = null;
        ResourceScope operationScope = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("methodId"u8))
            {
                methodId = prop.Value.GetString();
            }
            if (prop.NameEquals("operationScope"u8))
            {
                operationScope = Enum.Parse<ResourceScope>(prop.Value.GetString() ?? throw new JsonException("operationScope cannot be null"), true);
            }
        }
        // find the method by its ID
        var method = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId ?? throw new JsonException("methodId cannot be null")) ?? throw new JsonException($"cannot find the method with crossLanguageDefinitionId {methodId}");
        var client = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(method) ?? throw new JsonException($"cannot find the client for method {methodId}");
        return new NonResourceMethod(
            operationScope,
            method,
            client);
    }
}