// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Text.Json;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMethod(ResourceOperationKind Kind, InputServiceMethod InputMethod, InputClient InputClient)
    {
        internal static ResourceMethod DeserializeResourceMethod(JsonElement element)
        {
            string? id = null;
            ResourceOperationKind? operationKind = null;
            if (element.TryGetProperty("methodId", out var idData))
            {
                id = idData.GetString();
            }
            if (element.TryGetProperty("kind", out var kindData) && kindData.GetString() is string kindString)
            {
                if (Enum.TryParse<ResourceOperationKind>(kindString, true, out var kind))
                {
                    operationKind = kind;
                }
            }
            var inputMethod = ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(id ?? throw new InvalidOperationException("id cannot be null"));
            var inputClient = ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(inputMethod ?? throw new InvalidOperationException($"cannot find InputServiceMethod {id}"));

            return new ResourceMethod(
                operationKind ?? throw new InvalidOperationException("operationKind cannot be null"),
                inputMethod,
                inputClient ?? throw new InvalidOperationException($"cannot find method {inputMethod.CrossLanguageDefinitionId}'s client"));
        }
    }
}
