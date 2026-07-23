// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

#pragma warning disable SCME0001

// Foundry conjures two Azure-only attribution fields onto every response output item via
// @@copyProperties: `agent_reference` (which agent produced the item) and `response_id` (which
// response it was created on). Because the items now derive from OpenAI's ResponseItem — whose
// generated per-type deserializer parses these fields but whose constructor does not model
// them — they would otherwise be dropped. This helper re-homes the parsed values into two bags,
// because the item's read and write paths do not share one:
//   * the base ResponseItem JsonPatch, which the AzureAIExtensions ResponseItem.AgentReference /
//     ResponseId extension members read (mirrors ResponseResult.Agent); and
//   * the subtype's _additionalBinaryDataProperties, which is the only bag the generated subtype
//     writer emits, so the values survive a write round trip.
internal static class AgentAttributionExtensions
{
    private const string AgentReferenceProperty = "agent_reference";
    private const string ResponseIdProperty = "response_id";

    internal static void ApplyAgentAttribution(
        this ResponseItem item,
        AgentReference agentReference,
        string responseId,
        IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        if (item is null)
        {
            return;
        }

        if (agentReference is not null)
        {
            BinaryData serialized = ModelReaderWriter.Write(agentReference, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
            item.Patch.Set("$.agent_reference"u8, serialized);
            if (additionalBinaryDataProperties is not null)
            {
                additionalBinaryDataProperties[AgentReferenceProperty] = serialized;
            }
        }

        if (responseId is not null)
        {
            item.Patch.SetOrClearEx("$.response_id"u8, "$.response_id"u8, responseId);
            if (additionalBinaryDataProperties is not null)
            {
                additionalBinaryDataProperties[ResponseIdProperty] = SerializeJsonString(responseId);
            }
        }
    }

    private static BinaryData SerializeJsonString(string value)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteStringValue(value);
        }
        return BinaryData.FromBytes(stream.ToArray());
    }
}
