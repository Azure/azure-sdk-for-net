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
        var methodId = element.GetProperty("methodId").GetString() ?? throw new JsonException("methodId cannot be null");
        var operationScopeString = element.GetProperty("operationScope").GetString() ?? throw new JsonException("operationScope cannot be null");
        // find the method by its ID
        var method = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId) ?? throw new JsonException($"cannot find the method with crossLanguageDefinitionId {methodId}");
        var client = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(method) ?? throw new JsonException($"cannot find the client for method {methodId}");
        var operationScope = Enum.Parse<ResourceScope>(operationScopeString, true);
        return new NonResourceMethod(
            operationScope,
            method,
            client);
    }
}