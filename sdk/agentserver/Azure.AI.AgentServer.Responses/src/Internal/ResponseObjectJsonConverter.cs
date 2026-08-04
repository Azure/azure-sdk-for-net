// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.AI.AgentServer.Responses.Models;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Internal;

internal sealed class ResponseObjectJsonConverter : JsonConverter<ResponseObject>
{
    public override ResponseObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        BinaryData data = BinaryData.FromString(document.RootElement.GetRawText());
        ResponseResult openAIResponse = ModelReaderWriter.Read<ResponseResult>(data, ModelReaderWriterOptions.Json, OpenAIContext.Default)!;
        ResponseObject response = openAIResponse.Snapshot();

        if (document.RootElement.TryGetProperty("completed_at", out JsonElement completedAtElement)
            && completedAtElement.ValueKind == JsonValueKind.Number
            && completedAtElement.TryGetInt64(out long completedAt))
        {
            response.CompletedAt = DateTimeOffset.FromUnixTimeSeconds(completedAt);
        }

        if (document.RootElement.TryGetProperty("agent_reference", out JsonElement agentReferenceElement)
            && agentReferenceElement.ValueKind != JsonValueKind.Null)
        {
            response.AgentReference = JsonSerializer.Deserialize<AgentReference>(
                agentReferenceElement.GetRawText(), options);
        }

        if (document.RootElement.TryGetProperty("agent_session_id", out JsonElement agentSessionIdElement)
            && agentSessionIdElement.ValueKind == JsonValueKind.String)
        {
            response.AgentSessionId = agentSessionIdElement.GetString();
        }

        if (document.RootElement.TryGetProperty("conversation", out JsonElement conversationElement)
            && conversationElement.ValueKind != JsonValueKind.Null)
        {
            response.Conversation = conversationElement.ValueKind == JsonValueKind.String
                ? new ConversationParam(conversationElement.GetString()!)
                : JsonSerializer.Deserialize<ConversationParam>(conversationElement.GetRawText(), options);
        }

        if (document.RootElement.TryGetProperty("instructions", out JsonElement instructionsElement)
            && instructionsElement.ValueKind != JsonValueKind.Null)
        {
            response.Instructions = BinaryData.FromString(instructionsElement.GetRawText());
        }

        if (document.RootElement.TryGetProperty("tool_choice", out JsonElement toolChoiceElement)
            && toolChoiceElement.ValueKind != JsonValueKind.Null)
        {
            response.ToolChoice = BinaryData.FromString(toolChoiceElement.GetRawText());
        }

        return response;
    }

    public override void Write(Utf8JsonWriter writer, ResponseObject value, JsonSerializerOptions options)
    {
        BinaryData baseData = ModelReaderWriter.Write((ResponseResult)value, ModelReaderWriterOptions.Json, OpenAIContext.Default);
        using JsonDocument document = JsonDocument.Parse(baseData);

        writer.WriteStartObject();
        foreach (JsonProperty property in document.RootElement.EnumerateObject())
        {
            if (property.NameEquals("metadata"u8)
                || property.NameEquals("instructions"u8)
                || property.NameEquals("tool_choice"u8))
            {
                continue;
            }

            property.WriteTo(writer);
        }

        writer.WritePropertyName("metadata"u8);
        JsonSerializer.Serialize<IDictionary<string, string>>(writer, value.Metadata, options);

        if (value.CompletedAt.HasValue)
        {
            writer.WriteNumber("completed_at"u8, value.CompletedAt.Value.ToUnixTimeSeconds());
        }

        if (value.AgentReference is not null)
        {
            writer.WritePropertyName("agent_reference"u8);
            JsonSerializer.Serialize(writer, value.AgentReference, options);
        }

        if (value.AgentSessionId is not null)
        {
            writer.WriteString("agent_session_id"u8, value.AgentSessionId);
        }

        if (value.Conversation is not null)
        {
            writer.WritePropertyName("conversation"u8);
            JsonSerializer.Serialize(writer, value.Conversation, options);
        }

        if (value.Instructions is not null)
        {
            writer.WritePropertyName("instructions"u8);
            writer.WriteRawValue(value.Instructions);
        }

        if (value.ToolChoice is not null)
        {
            writer.WritePropertyName("tool_choice"u8);
            writer.WriteRawValue(value.ToolChoice);
        }

        writer.WriteEndObject();
    }
}
