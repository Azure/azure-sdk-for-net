// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        using var doc = JsonDocument.Parse(toolChoice.ToMemory());
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
    internal static List<Item> ExpandInput(BinaryData? input)
    {
        if (input is null)
        {
            return new List<Item>();
        }

        try
        {
            using var doc = JsonDocument.Parse(input.ToMemory());
            var root = doc.RootElement;

            var items = root.ValueKind switch
            {
                JsonValueKind.String => new List<Item>
                {
                    CreateStringInputMessage(root.GetString()!),
                },
                JsonValueKind.Array => DeserializeItemArray(root),
                _ => throw new FormatException(
                    $"Expected a string or array for Input, but got {root.ValueKind}."),
            };

            NormalizeMessageContent(items);
            return items;
        }
        catch (FormatException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new FormatException("Failed to convert input items", ex);
        }
    }

    /// <summary>
    /// Expands a BinaryData Instructions into a typed list of <see cref="Item"/>.
    /// Uses <see cref="MessageRole.Developer"/> for string shorthand.
    /// </summary>
    internal static List<Item> ExpandInstructions(BinaryData? instructions)
    {
        if (instructions is null)
        {
            return new List<Item>();
        }

        using var doc = JsonDocument.Parse(instructions.ToMemory());
        var root = doc.RootElement;

        return root.ValueKind switch
        {
            JsonValueKind.String => new List<Item>
            {
                CreateStringInstructionMessage(root.GetString()!),
            },
            JsonValueKind.Array => DeserializeItemArray(root),
            _ => throw new FormatException(
                $"Expected a string or array for Instructions, but got {root.ValueKind}."),
        };
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

        using var doc = JsonDocument.Parse(conversation.ToMemory());
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
    internal static List<MessageContent> ExpandContent(BinaryData? content)
    {
        if (content is null)
        {
            return new List<MessageContent>();
        }

        using var doc = JsonDocument.Parse(content.ToMemory());
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

    private static ItemMessage CreateStringInputMessage(string text)
    {
        return new ItemMessage(MessageRole.User, new List<MessageContent>
        {
            new MessageContentInputTextContent(text),
        });
    }

    private static ItemMessage CreateStringInstructionMessage(string text)
    {
        return new ItemMessage(MessageRole.Developer, new List<MessageContent>
        {
            new MessageContentInputTextContent(text),
        });
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

    /// <summary>
    /// Normalizes <see cref="ItemMessage.Content"/> from JSON string shorthand to
    /// the canonical array form so that downstream consumers always see an array
    /// of <see cref="MessageContent"/> regardless of how the input was submitted.
    /// </summary>
    private static void NormalizeMessageContent(List<Item> items)
    {
        foreach (var item in items)
        {
            if (item is ItemMessage message && message.Content is not null)
            {
                using var doc = JsonDocument.Parse(message.Content.ToMemory());
                if (doc.RootElement.ValueKind == JsonValueKind.String)
                {
                    var expanded = ExpandContent(message.Content);
                    message.Content = SerializeContentArray(expanded);
                }
            }
        }
    }

    private static BinaryData SerializeContentArray(List<MessageContent> content)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartArray();
            foreach (var part in content)
            {
                ((IJsonModel<MessageContent>)part).Write(writer, ModelReaderWriterOptions.Json);
            }

            writer.WriteEndArray();
        }

        return BinaryData.FromBytes(stream.ToArray());
    }
}
