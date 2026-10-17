// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

internal static class ManifestFixtures
{
    internal static JsonSerializerOptions JsonOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    internal static McpManifest Create() => new("Services",
    [
        new("Services.Secret.get", "Services", "get", "f5088334-e630-4df0-a5be-ac87787acad0",
            "keyvault secret get", "Get secret", new(), "Secret"),
        new("Services.Queue.remove", "Services", "remove", "a9ab33b5-d9b0-4cf4-b851-4e20925ade9b",
            "servicebus queue remove", "Remove queue", new(), "Queue")
    ]);
}
