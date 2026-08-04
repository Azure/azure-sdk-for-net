// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for sequences of <see cref="Item"/> instances.
/// </summary>
public static class ItemExtensions
{
    /// <summary>
    /// Extracts all text content from a sequence of <see cref="Item"/> instances as a single string.
    /// Filters for <see cref="ItemMessage"/> items, expands their content via
    /// <see cref="ItemMessageExtensions.GetContentExpanded"/>, and joins all
    /// input text content values with newline separators.
    /// </summary>
    /// <param name="items">The input items to extract text from.</param>
    /// <returns>
    /// The combined text content, or an empty string if no text content is found.
    /// </returns>
    public static string GetInputText(this IEnumerable<Item> items)
    {
        Argument.AssertNotNull(items, nameof(items));

        var texts = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .Where(content => content.Kind == OpenAI.Responses.ResponseContentPartKind.InputText)
            .Select(content => content.Text);

        return string.Join("\n", texts);
    }
}
