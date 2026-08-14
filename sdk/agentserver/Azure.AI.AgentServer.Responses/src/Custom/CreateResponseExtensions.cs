// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="CreateResponse"/>.
/// </summary>
public static class CreateResponseExtensions
{
    /// <summary>
    /// Extracts the conversation ID from the <see cref="CreateResponse.Conversation"/> field,
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

        if (request.Conversation is not null)
        {
            try
            {
                using var doc = JsonDocument.Parse(request.Conversation.ToMemory());
                var root = doc.RootElement;

                if (root.ValueKind == JsonValueKind.String)
                {
                    var conversationId = root.GetString();
                    if (!string.IsNullOrEmpty(conversationId))
                        return conversationId;
                }
                else if (root.ValueKind == JsonValueKind.Object &&
                         root.TryGetProperty("id", out var idProp) &&
                         idProp.ValueKind == JsonValueKind.String)
                {
                    var conversationId = idProp.GetString();
                    if (!string.IsNullOrEmpty(conversationId))
                        return conversationId;
                }
            }
            catch (JsonException)
            {
                // Swallow JSON parse errors — no conversation ID available
            }
        }

        return null;
    }

    /// <summary>
    /// Expands the <see cref="CreateResponse.ToolChoice"/> BinaryData into a typed
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
        return BinaryDataExpansionHelpers.ExpandToolChoice(request.ToolChoice);
    }

    /// <summary>
    /// Expands the <see cref="CreateResponse.Input"/> BinaryData into a typed list of
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
        return BinaryDataExpansionHelpers.ExpandInput(request.Input);
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
    /// Expands the <see cref="CreateResponse.Conversation"/> BinaryData into a typed
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
        return BinaryDataExpansionHelpers.ExpandConversation(request.Conversation);
    }

    /// <summary>
    /// Converts the <see cref="CreateResponse.Instructions"/> string into a
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
    /// or <c>null</c> if <see cref="CreateResponse.Instructions"/> is <c>null</c>.
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
