// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for sequences of <see cref="Item"/> instances.
/// </summary>
[Experimental("OPENAI001")]
public static class ItemExtensions
{
    /// <summary>
    /// Extracts all text content from a sequence of <see cref="Item"/> instances as a single string.
    /// Filters for <see cref="ItemMessage"/> items and joins the text of all
    /// <see cref="ResponseContentPartKind.InputText"/> content parts with newline separators.
    /// </summary>
    /// <param name="items">The input items to extract text from.</param>
    /// <returns>
    /// The combined text content, or an empty string if no text content is found.
    /// </returns>
    public static string GetInputText(this IEnumerable<Item> items)
    {
        Argument.AssertNotNull(items, nameof(items));

        // Explicit loops instead of a LINQ chain: the generator's custom-code analyzer throws
        // ArgumentException on lambda chains over externalized OpenAI types, which breaks regeneration.
        var texts = new List<string>();
        foreach (Item item in items)
        {
            if (item is not ItemMessage msg)
            {
                continue;
            }

            foreach (ResponseContentPart part in msg.Content)
            {
                if (part.Kind == ResponseContentPartKind.InputText)
                {
                    texts.Add(part.Text);
                }
            }
        }

        return string.Join("\n", texts);
    }
}
