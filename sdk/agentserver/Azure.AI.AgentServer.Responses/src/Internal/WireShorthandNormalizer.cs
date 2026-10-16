// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Expands the shorthand forms the Responses wire protocol allows into the canonical
/// shapes that <see cref="OpenAI.Responses.CreateResponseOptions"/> deserializes.
/// <para>
/// The OpenAI client only ever emits the canonical form, so its reader is strict.
/// This server accepts requests from arbitrary callers and must therefore normalize
/// <c>input</c>, message <c>content</c>, <c>conversation</c>, and <c>instructions</c>
/// before model binding.
/// </para>
/// </summary>
internal static class WireShorthandNormalizer
{
    /// <summary>Normalizes a create-response payload in place.</summary>
    /// <param name="root">The parsed request body.</param>
    public static void Normalize(JsonNode root)
    {
        if (root is not JsonObject obj)
        {
            return;
        }

        NormalizeItemCollection(obj, "input");
        NormalizeInstructions(obj);
        NormalizeConversation(obj);
    }

    /// <summary>
    /// Expands <c>"input": "text"</c> into a single user message item and normalizes
    /// the <c>content</c> of every message item in the collection.
    /// </summary>
    private static void NormalizeItemCollection(JsonObject obj, string propertyName)
    {
        if (!obj.TryGetPropertyValue(propertyName, out var node) || node is null)
        {
            return;
        }

        if (node is JsonValue value && value.TryGetValue<string>(out var text))
        {
            obj[propertyName] = new JsonArray(CreateMessage("user", "input_text", text));
            return;
        }

        if (node is JsonArray array)
        {
            foreach (var item in array)
            {
                NormalizeItem(item as JsonObject);
            }
        }
    }

    /// <summary>
    /// Normalizes a single input item: infers the omitted <c>type</c> discriminator and
    /// expands the shorthand shapes of the item's payload.
    /// </summary>
    private static void NormalizeItem(JsonObject? item)
    {
        if (item is null)
        {
            return;
        }

        InferItemType(item);
        NormalizeMessageContent(item);
        NormalizeFunctionCallOutput(item);
    }

    /// <summary>
    /// The <c>type</c> discriminator is optional on the wire; without it the OpenAI reader
    /// falls back to its unknown-item type. A <c>role</c> identifies a message item.
    /// </summary>
    private static void InferItemType(JsonObject item)
    {
        if (item.ContainsKey("type") || !item.ContainsKey("role"))
        {
            return;
        }

        item["type"] = "message";
    }

    /// <summary>
    /// A function call output may be sent as an array of content parts. The canonical shape
    /// is a plain string, so the text parts are flattened into one.
    /// </summary>
    private static void NormalizeFunctionCallOutput(JsonObject item)
    {
        if (item["output"] is not JsonArray parts)
        {
            return;
        }

        var texts = new List<string>();
        foreach (var part in parts)
        {
            if (part is JsonObject partObject && partObject["text"] is JsonValue partText &&
                partText.TryGetValue<string>(out var s))
            {
                texts.Add(s);
            }
        }

        item["output"] = string.Join("\n", texts);
    }

    /// <summary>
    /// <c>instructions</c> is a string on the canonical shape. Callers may send the
    /// item-array form, in which case the text parts are flattened into that string.
    /// </summary>
    private static void NormalizeInstructions(JsonObject obj)
    {
        if (!obj.TryGetPropertyValue("instructions", out var node) || node is not JsonArray array)
        {
            return;
        }

        var texts = new List<string>();
        foreach (var item in array)
        {
            NormalizeItem(item as JsonObject);
            if (item is not JsonObject message || message["content"] is not JsonArray parts)
            {
                continue;
            }

            foreach (var part in parts)
            {
                if (part is JsonObject partObject && partObject["text"] is JsonValue partText &&
                    partText.TryGetValue<string>(out var s))
                {
                    texts.Add(s);
                }
            }
        }

        obj["instructions"] = string.Join("\n", texts);
    }

    /// <summary>Expands <c>"conversation": "conv_id"</c> into <c>{ "id": "conv_id" }</c>.</summary>
    private static void NormalizeConversation(JsonObject obj)
    {
        if (obj.TryGetPropertyValue("conversation", out var node) &&
            node is JsonValue value && value.TryGetValue<string>(out var id))
        {
            obj["conversation"] = new JsonObject { ["id"] = id };
        }
    }

    /// <summary>Expands a message item's <c>"content": "text"</c> into a single content part.</summary>
    private static void NormalizeMessageContent(JsonObject? item)
    {
        if (item is null || item["content"] is not JsonValue value || !value.TryGetValue<string>(out var text))
        {
            return;
        }

        var role = item["role"] is JsonValue roleValue && roleValue.TryGetValue<string>(out var r) ? r : "user";
        item["content"] = new JsonArray(CreateContentPart(role, text));
    }

    private static JsonObject CreateMessage(string role, string partType, string text)
        => new()
        {
            ["type"] = "message",
            ["role"] = role,
            ["content"] = new JsonArray(new JsonObject { ["type"] = partType, ["text"] = text }),
        };

    private static JsonObject CreateContentPart(string role, string text)
        => new()
        {
            ["type"] = role == "assistant" ? "output_text" : "input_text",
            ["text"] = text,
        };
}
