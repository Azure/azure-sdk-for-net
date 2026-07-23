// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI.Internal;

namespace Azure.AI.Extensions.OpenAI;

internal static class ResponseItemAttribution
{
    public static IDictionary<string, BinaryData> AddToAdditionalProperties(
        IDictionary<string, BinaryData> additionalBinaryDataProperties,
        AgentReference agentReference,
        string responseId)
    {
        additionalBinaryDataProperties ??= new ChangeTrackingDictionary<string, BinaryData>();
        if (agentReference is not null)
        {
            additionalBinaryDataProperties["agent_reference"] = ModelReaderWriter.Write(
                agentReference,
                ModelReaderWriterOptions.Json,
                AzureAIExtensionsOpenAIContext.Default);
        }
        if (responseId is not null)
        {
            using MemoryStream stream = new();
            using (Utf8JsonWriter writer = new(stream))
            {
                writer.WriteStringValue(responseId);
            }
            additionalBinaryDataProperties["response_id"] = BinaryData.FromBytes(stream.ToArray());
        }
        return additionalBinaryDataProperties;
    }
}

public partial class A2AToolCall
{
    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; internal set; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; internal set; }
}

public partial class AgentStructuredOutputsResponseItem
{
    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; internal set; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; internal set; }
}

public partial class AzureAISearchToolCall
{
    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; internal set; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; internal set; }
}

public partial class BingGroundingToolCall
{
    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; internal set; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; internal set; }
}

public partial class BingGroundingToolCallOutput
{
    /// <summary> The agent that created the item. </summary>
    public AgentReference AgentReference { get; internal set; }

    /// <summary> The response on which the item is created. </summary>
    public string ResponseId { get; internal set; }
}
