// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="ResponseObject"/> that provide typed access
/// to BinaryData properties like <see cref="ResponseObject.ToolChoice"/> and
/// <see cref="ResponseObject.Instructions"/>.
/// </summary>
public static class ResponseExtensions
{
    /// <summary>
    /// Expands the <see cref="ResponseObject.ToolChoice"/> BinaryData into a typed
    /// <see cref="ToolChoiceParam"/>. String shorthands (<c>"auto"</c>, <c>"required"</c>)
    /// are expanded to <see cref="ToolChoiceAllowed"/> with the corresponding mode.
    /// <c>"none"</c> returns <c>null</c>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <returns>
    /// The typed tool choice, or <c>null</c> if the tool choice is <c>"none"</c> or unset.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="response"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The ToolChoice BinaryData contains an unrecognized value.
    /// </exception>
    public static ToolChoiceParam? GetToolChoiceExpanded(this ResponseObject response)
    {
        Argument.AssertNotNull(response, nameof(response));
        return BinaryDataExpansionHelpers.ExpandToolChoice(response.ToolChoice);
    }

    /// <summary>
    /// Sets the <see cref="ResponseObject.ToolChoice"/> property from a typed
    /// <see cref="ToolChoiceParam"/> object.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="toolChoice">The tool choice to set.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="response"/> or <paramref name="toolChoice"/> is <c>null</c>.
    /// </exception>
    public static void SetToolChoice(this ResponseObject response, ToolChoiceParam toolChoice)
    {
        Argument.AssertNotNull(response, nameof(response));
        Argument.AssertNotNull(toolChoice, nameof(toolChoice));
        response.ToolChoice = ModelReaderWriter.Write(toolChoice, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default);
    }

    /// <summary>
    /// Sets the <see cref="ResponseObject.ToolChoice"/> property from a
    /// <see cref="ToolChoiceOptions"/> enum value (string shorthand).
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="toolChoice">The tool choice option to set.</param>
    /// <exception cref="ArgumentNullException"><paramref name="response"/> is <c>null</c>.</exception>
    public static void SetToolChoice(this ResponseObject response, ToolChoiceOptions toolChoice)
    {
        Argument.AssertNotNull(response, nameof(response));
        response.ToolChoice = BinaryData.FromObjectAsJson(toolChoice.ToSerialString());
    }

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
        return BinaryDataExpansionHelpers.ExpandInstructions(response.Instructions);
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
        response.Instructions = BinaryData.FromObjectAsJson(instructions);
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

        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartArray();
            foreach (var item in items)
            {
                ((IJsonModel<Item>)item).Write(writer, ModelReaderWriterOptions.Json);
            }
            writer.WriteEndArray();
        }

        response.Instructions = BinaryData.FromBytes(stream.ToArray());
    }
}
