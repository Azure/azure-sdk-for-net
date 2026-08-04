// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using OpenAI.Responses;
using AgentMessageRole = OpenAI.Responses.MessageRole;
using AgentMessageStatus = OpenAI.Responses.MessageStatus;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

internal static class TestModels
{
    public static T FromJson<T>(object value)
        => ModelReaderWriter.Read<T>(BinaryData.FromObjectAsJson(value))!;

    public static T FromJsonString<T>(string json)
        => ModelReaderWriter.Read<T>(BinaryData.FromString(json))!;

    public static MessageResponseItem ItemMessage(AgentMessageRole role, BinaryData content)
        => Message("msg_test", role, AgentMessageStatus.Completed, content);

    public static MessageResponseItem ItemMessage(AgentMessageRole role, IEnumerable<MessageContent> content)
        => Message("msg_test", role, AgentMessageStatus.Completed, SerializeContent(content));

    public static MessageResponseItem OutputItemMessage(string id, AgentMessageStatus status, IEnumerable<MessageContent> content)
        => Message(id, AgentMessageRole.Assistant, status, SerializeContent(content));

    public static MessageResponseItem OutputItemMessage(string id, AgentMessageStatus status, AgentMessageRole role, IEnumerable<MessageContent> content)
        => Message(id, role, status, SerializeContent(content));

    public static StreamingResponseCreatedUpdate ResponseCreatedEvent(long sequenceNumber, ResponseResult response)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            Response = response,
        };

    public static StreamingResponseInProgressUpdate ResponseInProgressEvent(long sequenceNumber, ResponseResult response)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            Response = response,
        };

    public static StreamingResponseCompletedUpdate ResponseCompletedEvent(long sequenceNumber, ResponseResult response)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            Response = response,
        };

    public static StreamingResponseFailedUpdate ResponseFailedEvent(long sequenceNumber, ResponseResult response)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            Response = response,
        };

    public static StreamingResponseOutputItemAddedUpdate ResponseOutputItemAddedEvent(long sequenceNumber, int outputIndex, ResponseItem item)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            OutputIndex = outputIndex,
            Item = item,
        };

    public static StreamingResponseOutputItemDoneUpdate ResponseOutputItemDoneEvent(long sequenceNumber, int outputIndex, ResponseItem item)
        => new()
        {
            SequenceNumber = checked((int)sequenceNumber),
            OutputIndex = outputIndex,
            Item = item,
        };

    public static StreamingResponseOutputItemDoneUpdate ResponseOutputItemDoneEvent(int outputIndex, ResponseItem item)
        => ResponseOutputItemDoneEvent(0, outputIndex, item);

    public static ResponseTokenUsage ResponseUsage(
        int inputTokens,
        int cachedInputTokens,
        int outputTokens,
        int reasoningOutputTokens,
        int totalTokens)
        => new()
        {
            InputTokenCount = inputTokens,
            InputTokenDetails = new ResponseInputTokenUsageDetails { CachedTokenCount = cachedInputTokens },
            OutputTokenCount = outputTokens,
            OutputTokenDetails = new ResponseOutputTokenUsageDetails { ReasoningTokenCount = reasoningOutputTokens },
            TotalTokenCount = totalTokens,
        };

    public static ResponseIncompleteDetails ResponseIncompleteDetails(ResponseIncompleteDetailsReason reason)
        => ModelReaderWriter.Read<ResponseIncompleteDetails>(
            BinaryData.FromObjectAsJson(new { reason = reason.ToString().ToLowerInvariant() }))!;

    private static MessageResponseItem Message(string id, AgentMessageRole role, AgentMessageStatus status, BinaryData content)
    {
        using JsonDocument contentDocument = JsonDocument.Parse(content);
        BinaryData data = BinaryData.FromString($$"""
        {
            "id": {{JsonSerializer.Serialize(id)}},
            "type": "message",
            "status": {{JsonSerializer.Serialize(ToWireStatus(status))}},
            "role": {{JsonSerializer.Serialize(role.ToString().ToLowerInvariant())}},
            "content": {{ToWireContentJson(contentDocument.RootElement)}}
        }
        """);

        try
        {
            return ModelReaderWriter.Read<MessageResponseItem>(data)!;
        }
        catch (InvalidOperationException)
        {
            var message = (MessageResponseItem)RuntimeHelpers.GetUninitializedObject(typeof(MessageResponseItem));
            ItemMessageExtensions.RawMessageContentRegistry.Register(message, content);
            return message;
        }
    }

    private static string ToWireStatus(AgentMessageStatus status)
    {
        return status == AgentMessageStatus.InProgress ? "in_progress" : status.ToString().ToLowerInvariant();
    }

    private static string ToWireContentJson(JsonElement content)
    {
        if (content.ValueKind == JsonValueKind.String)
        {
            return $$"""[{ "type": "input_text", "text": {{JsonSerializer.Serialize(content.GetString())}} }]""";
        }

        return content.GetRawText();
    }

    private static BinaryData SerializeContent(IEnumerable<MessageContent> content)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteStartArray();
            foreach (MessageContent item in content)
            {
                ((IJsonModel<MessageContent>)item).Write(writer, ModelReaderWriterOptions.Json);
            }
            writer.WriteEndArray();
        }

        return BinaryData.FromBytes(stream.ToArray());
    }
}
