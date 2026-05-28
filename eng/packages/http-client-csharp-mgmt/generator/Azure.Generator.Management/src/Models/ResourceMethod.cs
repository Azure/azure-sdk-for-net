// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Text.Json;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMethod(ResourceOperationKind Kind, InputServiceMethod InputMethod, string OperationPath, ResourceScope OperationScope, string? ResourceScope, InputClient InputClient)
    {
        internal static ResourceMethod DeserializeResourceMethod(JsonElement element)
        {
            string? methodId = null;
            ResourceOperationKind? operationKind = null;
            string? operationPath = null;
            ResourceScope? operationScope = null;
            string? resourceScope = null;
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
                    resourceScope = prop.Value.GetString();
                }
            }
            var inputMethod = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(methodId ?? throw new JsonException("id cannot be null"));
            var inputClient = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(inputMethod ?? throw new JsonException($"cannot find InputServiceMethod {methodId}"));

            return new ResourceMethod(
                operationKind ?? throw new JsonException("operationKind cannot be null"),
                inputMethod,
                operationPath ?? throw new JsonException("operationPath cannot be null"),
                operationScope ?? throw new JsonException("operationScope cannot be null"),
                resourceScope,
                inputClient ?? throw new JsonException($"cannot find method {inputMethod.CrossLanguageDefinitionId}'s client"));
        }
    }
}
