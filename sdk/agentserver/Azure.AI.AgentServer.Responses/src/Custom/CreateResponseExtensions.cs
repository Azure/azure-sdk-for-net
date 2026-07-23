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
/// Extension methods for <see cref="CreateResponse"/>.
/// </summary>
public static class CreateResponseExtensions
{
    /// <summary>
    /// Extracts the conversation ID from the <see cref="OpenAI.Responses.CreateResponseOptions.ConversationOptions"/> field,
    /// which may be a plain string ID or a JSON object with an <c>id</c> property.
    /// Returns <c>null</c> if no conversation context is present.
    /// </summary>
    /// <param name="request">The create-response request to extract the conversation ID from.</param>
    /// <returns>
    /// The conversation ID if found; otherwise, <c>null</c>.
    /// </returns>
    public static string? GetConversationId(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));

        if (request.ConversationOptions?.ConversationId is string conversationId)
        {
            return conversationId;
        }

        if (request.Conversation is null)
        {
            return null;
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(request.Conversation);
            return document.RootElement.ValueKind switch
            {
                JsonValueKind.String when !string.IsNullOrEmpty(document.RootElement.GetString()) => document.RootElement.GetString(),
                JsonValueKind.Object when document.RootElement.TryGetProperty("id", out JsonElement idElement)
                    && idElement.ValueKind == JsonValueKind.String
                    && !string.IsNullOrEmpty(idElement.GetString()) => idElement.GetString(),
                _ => null,
            };
        }
        catch (JsonException)
        {
            return null;
        }
    }

    internal static string? GetAgentSessionId(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        return request.AgentSessionId;
    }

    internal static void SetAgentSessionId(this CreateResponse request, string? agentSessionId)
    {
        Argument.AssertNotNull(request, nameof(request));
        request.AgentSessionId = agentSessionId;
    }

    internal static AgentReference? GetAgentReference(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        return request.AgentReference;
    }

    /// <summary>
    /// Expands the <c>ToolChoice</c> BinaryData into a typed
    /// <see cref="ToolChoiceParam"/>. String shorthands (<c>"auto"</c>, <c>"required"</c>)
    /// are expanded to <see cref="ToolChoiceAllowed"/> with the corresponding mode.
    /// <c>"none"</c> returns <c>null</c>.
    /// </summary>
    /// <param name="request">The create-response request.</param>
    /// <returns>
    /// The typed tool choice, or <c>null</c> if the tool choice is <c>"none"</c> or unset.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The ToolChoice BinaryData contains a JSON value that is neither a recognized string
    /// nor a valid ToolChoiceParam object.
    /// </exception>
    public static ToolChoiceParam? GetToolChoiceExpanded(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        return request.ToolChoice?.Kind switch
        {
            ResponseToolChoiceKind.Auto => new ToolChoiceAllowed(ToolChoiceAllowedMode.Auto, Array.Empty<IDictionary<string, BinaryData>>()),
            ResponseToolChoiceKind.Required => new ToolChoiceAllowed(ToolChoiceAllowedMode.Required, Array.Empty<IDictionary<string, BinaryData>>()),
            ResponseToolChoiceKind.None => null,
            _ => request.ToolChoice is null
                ? null
                : ModelReaderWriter.Read<ToolChoiceParam>(
                    ModelReaderWriter.Write(request.ToolChoice, ModelReaderWriterOptions.Json, OpenAIContext.Default),
                    ModelReaderWriterOptions.Json,
                    AzureAIAgentServerResponsesContext.Default),
        };
    }

    /// <summary>
    /// Expands the <see cref="OpenAI.Responses.CreateResponseOptions.InputItems"/> collection into a typed list of
    /// <see cref="Item"/> objects. A plain string input is wrapped as a single
    /// <see cref="ItemMessage"/> with <see cref="MessageRole.User"/> role and text content.
    /// Array elements without a <c>"type"</c> discriminator default to
    /// <see cref="ItemMessage"/> deserialization.
    /// </summary>
    /// <param name="request">The create-response request.</param>
    /// <returns>
    /// A list of deserialized input items, or an empty list if input is <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The input data could not be parsed. The inner exception contains the parse error details.
    /// Message: <c>"Failed to convert input items"</c>.
    /// </exception>
    public static List<Item> GetInputExpanded(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        if (request.InputItems.Count > 0)
        {
            return request.InputItems.ToList();
        }

        if (request.Input is null)
        {
            return [];
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(request.Input);
            JsonArray array = document.RootElement.ValueKind switch
            {
                JsonValueKind.String => new JsonArray(CreateMessageNode("user", document.RootElement.GetString() ?? string.Empty)),
                JsonValueKind.Array => NormalizeInputArray(document.RootElement),
                JsonValueKind.Null => [],
                _ => throw new FormatException($"Expected a string or array for Input, but got {document.RootElement.ValueKind}."),
            };

            return array.Select(node => ModelReaderWriter.Read<Item>(
                    BinaryData.FromString(node!.ToJsonString()),
                    ModelReaderWriterOptions.Json,
                    OpenAIContext.Default)!)
                .ToList();
        }
        catch (JsonException ex)
        {
            throw new FormatException("Failed to convert input items", ex);
        }
    }

    /// <summary>
    /// Extracts all text content from the input items as a single string.
    /// Expands the input via <see cref="GetInputExpanded"/>, filters for
    /// <see cref="ItemMessage"/> items, expands their content via
    /// <see cref="ItemMessageExtensions.GetContentExpanded"/>, and joins all
    /// <see cref="MessageContentInputTextContent.Text"/> values with newline separators.
    /// </summary>
    /// <param name="request">The create-response request.</param>
    /// <returns>
    /// The combined text content, or an empty string if no text content is found.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The input data could not be parsed (propagated from <see cref="GetInputExpanded"/>).
    /// </exception>
    internal static string GetInputText(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));

        var items = request.GetInputExpanded();
        var texts = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputTextContent>()
            .Select(tc => tc.Text);

        return string.Join("\n", texts);
    }

    /// <summary>
    /// Expands the <see cref="OpenAI.Responses.CreateResponseOptions.ConversationOptions"/> value into a typed
    /// <see cref="ConversationParam"/>. A plain string is treated as the conversation ID.
    /// </summary>
    /// <param name="request">The create-response request.</param>
    /// <returns>
    /// The typed conversation parameter, or <c>null</c> if no conversation is set.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <c>null</c>.</exception>
    public static ConversationParam? GetConversationExpanded(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        if (request.Conversation is null)
        {
            return null;
        }

        try
        {
            using JsonDocument document = JsonDocument.Parse(request.Conversation);
            return document.RootElement.ValueKind switch
            {
                JsonValueKind.String when !string.IsNullOrEmpty(document.RootElement.GetString()) => new ConversationParam(document.RootElement.GetString()!),
                JsonValueKind.Object when document.RootElement.TryGetProperty("id", out JsonElement idElement)
                    && idElement.ValueKind == JsonValueKind.String
                    && !string.IsNullOrEmpty(idElement.GetString()) => new ConversationParam(idElement.GetString()!),
                JsonValueKind.Null => null,
                _ => throw new FormatException($"Expected a string or object for Conversation, but got {document.RootElement.ValueKind}."),
            };
        }
        catch (JsonException ex)
        {
            throw new FormatException("Failed to convert conversation", ex);
        }
    }

    private static JsonArray NormalizeInputArray(JsonElement inputArray)
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
                if (partNode is JsonObject partObject
                    && partObject.TryGetPropertyValue("type", out JsonNode? typeNode)
                    && typeNode is JsonValue typeValue
                    && typeValue.TryGetValue<string>(out string? type)
                    && type == "input_image"
                    && !partObject.ContainsKey("detail"))
                {
                    JsonObject clone = (JsonObject)partObject.DeepClone();
                    clone["detail"] = "auto";
                    normalized.Add(clone);
                }
                else
                {
                    normalized.Add(partNode?.DeepClone());
                }
            }

            return normalized;
        }

        return contentNode?.DeepClone();
    }

    private static JsonObject CreateMessageNode(string role, string content)
    {
        return new JsonObject
        {
            ["type"] = "message",
            ["role"] = role,
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

    /// <summary>
    /// Converts the <c>Instructions</c> string into a
    /// <see cref="BinaryData"/> suitable for assigning to <see cref="ResponseObject.Instructions"/>.
    /// <para>
    /// This method properly JSON-encodes the string so it can be round-tripped through
    /// <c>Utf8JsonWriter.WriteRawValue</c>. Use this instead of
    /// <see cref="BinaryData.FromString(string)"/>, which would produce invalid JSON.
    /// </para>
    /// </summary>
    /// <param name="request">The create-response request.</param>
    /// <returns>
    /// A <see cref="BinaryData"/> containing the JSON-encoded instructions string,
    /// or <c>null</c> if <c>Instructions</c> is <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/> is <c>null</c>.</exception>
    public static BinaryData? GetInstructionsBinaryData(this CreateResponse request)
    {
        Argument.AssertNotNull(request, nameof(request));
        return request.Instructions != null
            ? BinaryData.FromObjectAsJson(request.Instructions)
            : null;
    }
}
