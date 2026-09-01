// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Internal helpers for projecting the OpenAI-typed request properties onto the
/// Azure-specific unions declared in this package's TypeSpec.
/// </summary>
/// <remarks>
/// The wire fields these cover (<c>tool_choice</c>, <c>input</c>, <c>instructions</c>,
/// <c>conversation</c> and message <c>content</c>) are unions whose Azure representation
/// still carries members that the OpenAI library does not model. The OpenAI value is
/// serialized and re-read as the Azure union so that both representations stay available
/// without duplicating the union logic.
/// </remarks>
[System.Diagnostics.CodeAnalysis.Experimental("AAIP002")]
internal static class BinaryDataExpansionHelpers
{
    /// <summary>
    /// Expands a BinaryData ToolChoice into a typed <see cref="ToolChoiceParam"/>.
    /// </summary>
    internal static ToolChoiceParam? ExpandToolChoice(ResponseToolChoice? toolChoice)
    {
        if (toolChoice is null)
        {
            return null;
        }

        using var doc = JsonDocument.Parse(Serialize(toolChoice).ToMemory());
        var root = doc.RootElement;

        return root.ValueKind switch
        {
            JsonValueKind.String => ExpandToolChoiceFromString(root.GetString()!),
            JsonValueKind.Object => ToolChoiceParam.DeserializeToolChoiceParam(root, ModelReaderWriterOptions.Json),
            _ => throw new FormatException(
                $"Expected a string or object for ToolChoice, but got {root.ValueKind}."),
        };
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
    internal static List<Item> ExpandInput(IList<Item>? input)
    {
        if (input is null)
        {
            return new List<Item>();
        }

        // Input items are already the OpenAI item type; the string shorthand and the
        // per-item content shorthand are normalized by the OpenAI reader on the way in.
        return new List<Item>(input);
    }

    /// <summary>
    /// Expands a BinaryData Instructions into a typed list of <see cref="Item"/>.
    /// Uses <see cref="MessageRole.Developer"/> for string shorthand.
    /// </summary>
    internal static List<Item> ExpandInstructions(string? instructions)
        => string.IsNullOrEmpty(instructions)
            ? new List<Item>()
            : new List<Item> { CreateStringInstructionMessage(instructions!) };

    /// <summary>
    /// Expands a BinaryData Conversation into a typed <see cref="ConversationParam"/>.
    /// </summary>
    internal static ConversationParam? ExpandConversation(ResponseConversationOptions? conversation)
    {
        if (conversation is null)
        {
            return null;
        }

        using var doc = JsonDocument.Parse(Serialize(conversation).ToMemory());
        var root = doc.RootElement;

        return root.ValueKind switch
        {
            JsonValueKind.String => new ConversationParam(root.GetString()!),
            JsonValueKind.Object => ConversationParam.DeserializeConversationParam(root, ModelReaderWriterOptions.Json),
            _ => throw new FormatException(
                $"Expected a string or object for Conversation, but got {root.ValueKind}."),
        };
    }

    /// <summary>
    /// Expands a BinaryData Content into a typed list of <see cref="MessageContent"/>.
    /// </summary>
    internal static List<MessageContent> ExpandContent(IList<ResponseContentPart>? content)
    {
        if (content is null)
        {
            return new List<MessageContent>();
        }

        using var doc = JsonDocument.Parse(SerializeParts(content).ToMemory());
        var root = doc.RootElement;

        return root.ValueKind switch
        {
            JsonValueKind.String => new List<MessageContent>
            {
                new MessageContentInputTextContent(root.GetString()!),
            },
            JsonValueKind.Array => DeserializeContentArray(root),
            JsonValueKind.Object => new List<MessageContent>
            {
                ModelReaderWriter.Read<MessageContent>(
                    BinaryData.FromString(root.GetRawText()), ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default)!,
            },
            _ => throw new FormatException("Expected JSON array, object, or string for item content"),
        };
    }

    private static ItemMessage CreateStringInstructionMessage(string text)
    {
        var message = new ItemMessage();
        message.Patch.Set("$.role"u8, "developer");
        message.Content.Add(ResponseContentPart.CreateInputTextPart(text));
        return message;
    }

    private static BinaryData Serialize<T>(T model)
        where T : notnull
        => ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);

    private static BinaryData SerializeParts(IList<ResponseContentPart> parts)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartArray();
            foreach (var part in parts)
            {
                ((IJsonModel<ResponseContentPart>)part).Write(writer, ModelReaderWriterOptions.Json);
            }

            writer.WriteEndArray();
        }

        return BinaryData.FromBytes(stream.ToArray());
    }

    private static List<Item> DeserializeItemArray(JsonElement root)
    {
        var items = new List<Item>();
        foreach (var element in root.EnumerateArray())
        {
            if (element.ValueKind != JsonValueKind.Object)
            {
                throw new FormatException(
                    $"Expected a JSON object in the item array, but got {element.ValueKind}.");
            }

            if (element.TryGetProperty("type", out _))
            {
                items.Add(Item.DeserializeItem(element, ModelReaderWriterOptions.Json));
            }
            else
            {
                items.Add(ItemMessage.DeserializeItemMessage(element, ModelReaderWriterOptions.Json));
            }
        }

        return items;
    }

    private static List<MessageContent> DeserializeContentArray(JsonElement root)
    {
        var items = new List<MessageContent>();
        foreach (var element in root.EnumerateArray())
        {
            items.Add(MessageContent.DeserializeMessageContent(element, ModelReaderWriterOptions.Json));
        }

        return items;
    }

}
