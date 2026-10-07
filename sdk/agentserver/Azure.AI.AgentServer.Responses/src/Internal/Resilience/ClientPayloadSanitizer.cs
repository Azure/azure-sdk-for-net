// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

internal static class ClientPayloadSanitizer
{
    public static JsonNode? SanitizeForClient<T>(T payload, JsonSerializerOptions options)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(payload, options);
        var node = JsonNode.Parse(bytes);
        return InternalMetadataEgress.Strip(node);
    }
}
