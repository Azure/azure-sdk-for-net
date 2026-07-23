// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.Extensions.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Internal helpers for expanding BinaryData union-typed properties
/// into their strongly-typed representations.
/// </summary>
internal static class BinaryDataExpansionHelpers
{
    /// <summary>
    /// Expands a BinaryData ToolChoice into a typed <see cref="ToolChoiceParam"/>.
    /// </summary>
    internal static ToolChoiceParam? ExpandToolChoice(BinaryData? toolChoice)
    {
        if (toolChoice is null)
        {
            return null;
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(toolChoice);
            return document.RootElement.ValueKind switch
            {
                JsonValueKind.String => ExpandToolChoiceFromString(document.RootElement.GetString() ?? string.Empty),
                JsonValueKind.Object => ModelReaderWriter.Read<ToolChoiceParam>(
                    toolChoice,
                    ModelReaderWriterOptions.Json,
                    AzureAIAgentServerResponsesContext.Default),
                JsonValueKind.Null => null,
                _ => throw new FormatException(
                    $"Expected string or object for ToolChoice, but got {document.RootElement.ValueKind}."),
            };
        }
        catch (JsonException ex)
        {
            throw new FormatException("Failed to convert tool choice", ex);
        }
    }

    private static ToolChoiceParam? ExpandToolChoiceFromString(string value)
    {
        return value switch
        {
            "auto" => new ToolChoiceAllowed(ToolChoiceAllowedMode.Auto, Array.Empty<IDictionary<string, BinaryData>>()),
            "required" => new ToolChoiceAllowed(ToolChoiceAllowedMode.Required, Array.Empty<IDictionary<string, BinaryData>>()),
            "none" => null,
            _ => throw new FormatException(
                $"Unrecognized ToolChoice string value: '{value}'. Expected 'auto', 'required', or 'none'."),
        };
    }

    /// <summary>
    /// Expands a BinaryData Input into a typed list of <see cref="Item"/>.
    /// </summary>
    internal static List<Item> ExpandInput(BinaryData? input)
    {
        return ExpandItems(input, MessageRole.User, "Input");
    }

    /// <summary>
    /// Expands a BinaryData Instructions into a typed list of <see cref="Item"/>.
    /// Uses <see cref="MessageRole.Developer"/> for string shorthand.
    /// </summary>
    internal static List<Item> ExpandInstructions(BinaryData? instructions)
    {
        return ExpandItems(instructions, MessageRole.Developer, "Instructions");
    }

    /// <summary>
    /// Expands a BinaryData Conversation into a typed <see cref="ConversationParam"/>.
    /// </summary>
    internal static ConversationParam? ExpandConversation(BinaryData? conversation)
    {
        if (conversation is null)
        {
            return null;
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(conversation);
            return document.RootElement.ValueKind switch
            {
                JsonValueKind.String when !string.IsNullOrEmpty(document.RootElement.GetString()) => new ConversationParam(document.RootElement.GetString()!),
                JsonValueKind.String => null,
                JsonValueKind.Object when document.RootElement.TryGetProperty("id", out JsonElement idElement)
                    && idElement.ValueKind == JsonValueKind.String
                    && !string.IsNullOrEmpty(idElement.GetString()) => new ConversationParam(idElement.GetString()!),
                JsonValueKind.Null => null,
                _ => throw new FormatException(
                    $"Expected string or object for Conversation, but got {document.RootElement.ValueKind}."),
            };
        }
        catch (JsonException ex)
        {
            throw new FormatException("Failed to convert conversation", ex);
        }
    }

    /// <summary>
    /// Expands a BinaryData Content into a typed list of <see cref="MessageContent"/>.
    /// </summary>
    internal static List<MessageContent> ExpandContent(BinaryData? content)
    {
        if (content is null)
        {
            return [];
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(content);
            return document.RootElement.ValueKind switch
            {
                JsonValueKind.String => [new MessageContentInputTextContent(document.RootElement.GetString() ?? string.Empty)],
                JsonValueKind.Object => [ReadMessageContent(document.RootElement)],
                JsonValueKind.Array => document.RootElement.EnumerateArray().Select(ReadMessageContent).ToList(),
                JsonValueKind.Null => [],
                _ => throw new FormatException("Expected JSON array, object, or string for item content"),
            };
        }
        catch (JsonException ex)
        {
            throw new FormatException("Failed to convert item content", ex);
        }
    }

    private static List<Item> ExpandItems(BinaryData? data, MessageRole stringRole, string propertyName)
    {
        if (data is null)
        {
            return [];
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(data);
            JsonArray array = document.RootElement.ValueKind switch
            {
                JsonValueKind.String => new JsonArray(CreateMessageNode(stringRole, document.RootElement.GetString() ?? string.Empty)),
                JsonValueKind.Array => NormalizeItemArray(document.RootElement),
                JsonValueKind.Null => [],
                _ => throw new FormatException(
                    $"Expected a string or array for {propertyName}, but got {document.RootElement.ValueKind}."),
            };

            return array.Select(ReadResponseItem).ToList();
        }
        catch (JsonException ex)
        {
            throw new FormatException($"Failed to convert {propertyName.ToLowerInvariant()} items", ex);
        }
    }

    private static JsonArray NormalizeItemArray(JsonElement inputArray)
    {
        var normalized = new JsonArray();
        foreach (JsonElement element in inputArray.EnumerateArray())
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                throw new FormatException($"Expected object item in input array, but got {element.ValueKind}.");
            }

            JsonObject item = JsonNode.Parse(element.GetRawText())!.AsObject();
            if (!item.TryGetPropertyValue("type", out JsonNode? typeNode) && item.ContainsKey("role"))
            {
                item["type"] = "message";
                typeNode = JsonValue.Create("message");
            }

            if (typeNode is JsonValue typeValue
                && typeValue.TryGetValue<string>(out string? type)
                && type == "message"
                && item.TryGetPropertyValue("content", out JsonNode? contentNode))
            {
                item["content"] = NormalizeMessageContent(contentNode);
            }

            normalized.Add(item);
        }

        return normalized;
    }

    private static JsonNode? NormalizeMessageContent(JsonNode? contentNode)
    {
        if (contentNode is JsonValue contentValue
            && contentValue.TryGetValue<string>(out string? contentString))
        {
            return new JsonArray(CreateInputTextContentNode(contentString));
        }

        if (contentNode is JsonArray contentArray)
        {
            var normalized = new JsonArray();
            foreach (JsonNode? partNode in contentArray)
            {
                normalized.Add(NormalizeMessageContentPart(partNode));
            }

            return normalized;
        }

        return contentNode?.DeepClone();
    }

    private static JsonNode? NormalizeMessageContentPart(JsonNode? partNode)
    {
        if (partNode is not JsonObject partObject)
        {
            return partNode?.DeepClone();
        }

        JsonObject normalizedPart = (JsonObject)partObject.DeepClone();
        if (normalizedPart.TryGetPropertyValue("type", out JsonNode? typeNode)
            && typeNode is JsonValue typeValue
            && typeValue.TryGetValue<string>(out string? type)
            && type == "input_image"
            && !normalizedPart.ContainsKey("detail"))
        {
            normalizedPart["detail"] = "auto";
        }

        return normalizedPart;
    }

    private static Item ReadResponseItem(JsonNode? node)
    {
        if (node is null)
        {
            throw new FormatException("Input item cannot be null.");
        }

        return ModelReaderWriter.Read<Item>(
            BinaryData.FromString(node.ToJsonString()),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default)!;
    }

    private static MessageContent ReadMessageContent(JsonElement element)
    {
        return ModelReaderWriter.Read<MessageContent>(
            BinaryData.FromString(element.GetRawText()),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
    }

    private static JsonObject CreateMessageNode(MessageRole role, string content)
    {
        return new JsonObject
        {
            ["type"] = "message",
            ["role"] = role.ToString().ToLowerInvariant(),
            ["content"] = new JsonArray(CreateInputTextContentNode(content)),
        };
    }

    private static JsonObject CreateInputTextContentNode(string text)
    {
        return new JsonObject
        {
            ["type"] = "input_text",
            ["text"] = text,
        };
    }
}
