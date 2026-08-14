// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="ItemMessage"/> that provide typed access
/// to the <see cref="ItemMessage.Content"/> BinaryData property.
/// </summary>
public static class ItemMessageExtensions
{
    /// <summary>
    /// Expands the <see cref="ItemMessage.Content"/> BinaryData into a typed list of
    /// <see cref="MessageContent"/> objects. A plain JSON string is wrapped as a
    /// <see cref="MessageContentInputTextContent"/>. A JSON array is deserialized
    /// element-by-element via <see cref="MessageContent"/> polymorphic deserialization.
    /// </summary>
    /// <param name="message">The item message to expand content from.</param>
    /// <returns>
    /// A list of deserialized content parts, or an empty list if content is <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="message"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The content BinaryData contains a JSON value that is neither a string nor an array.
    /// Message: <c>"Expected JSON array or string for item content"</c>.
    /// </exception>
    public static List<MessageContent> GetContentExpanded(this ItemMessage message)
    {
        Argument.AssertNotNull(message, nameof(message));
        return BinaryDataExpansionHelpers.ExpandContent(message.Content);
    }
}
