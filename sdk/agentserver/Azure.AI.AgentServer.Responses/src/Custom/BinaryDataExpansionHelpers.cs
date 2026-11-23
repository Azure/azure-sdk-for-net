// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Internal helpers for projecting the OpenAI-typed request properties.
/// </summary>
[Experimental("OPENAI001")]
internal static class BinaryDataExpansionHelpers
{
    /// <summary>
    /// Returns the OpenAI input items as a list of <see cref="Item"/>.
    /// </summary>
    internal static List<Item> ExpandInput(IList<Item>? input)
    {
        if (input is null)
        {
            return new List<Item>();
        }

        // Input items are already the OpenAI item type. The string shorthand and the per-item
        // content shorthand were expanded by WireShorthandNormalizer before the request was bound.
        return new List<Item>(input);
    }
}
