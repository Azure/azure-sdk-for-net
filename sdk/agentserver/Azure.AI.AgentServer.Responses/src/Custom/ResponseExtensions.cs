// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="ResponseObject"/> that provide typed access
/// to <see cref="ResponseObject.Instructions"/>.
/// </summary>
[Experimental("OPENAI001")]
public static class ResponseExtensions
{
    /// <summary>
    /// Expands the <see cref="ResponseObject.Instructions"/> BinaryData into a typed list of
    /// <see cref="Item"/> objects. A plain string is wrapped as a single <see cref="ItemMessage"/>
    /// with <see cref="MessageRole.Developer"/> role and the instruction text.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <returns>
    /// A list of instruction items, or an empty list if instructions is <c>null</c>.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="response"/> is <c>null</c>.</exception>
    public static List<Item> GetInstructionItems(this ResponseObject response)
    {
        Argument.AssertNotNull(response, nameof(response));
        return new List<Item>(response.Instructions);
    }

    /// <summary>
    /// Sets the <see cref="ResponseObject.Instructions"/> property from a plain text string.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="instructions">The instruction text.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="response"/> or <paramref name="instructions"/> is <c>null</c>.
    /// </exception>
    public static void SetInstructions(this ResponseObject response, string instructions)
    {
        Argument.AssertNotNull(response, nameof(response));
        Argument.AssertNotNull(instructions, nameof(instructions));
        response.Instructions.Clear();
        response.Instructions.Add(ResponseItem.CreateDeveloperMessageItem(instructions));
    }

    /// <summary>
    /// Sets the <see cref="ResponseObject.Instructions"/> property from a list of
    /// <see cref="Item"/> objects.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="items">The instruction items.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="response"/> or <paramref name="items"/> is <c>null</c>.
    /// </exception>
    public static void SetInstructions(this ResponseObject response, IList<Item> items)
    {
        Argument.AssertNotNull(response, nameof(response));
        Argument.AssertNotNull(items, nameof(items));

        response.Instructions.Clear();
        foreach (var item in items)
        {
            response.Instructions.Add(item);
        }
    }
}
