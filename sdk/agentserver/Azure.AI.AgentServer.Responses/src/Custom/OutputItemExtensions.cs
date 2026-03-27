// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Extension methods for <see cref="OutputItem"/> that provide efficient
/// access to the <c>Id</c> property without reflection.
/// </summary>
public static class OutputItemExtensions
{
    /// <summary>
    /// Gets the <c>Id</c> property from an <see cref="OutputItem"/>.
    /// Uses direct type checks for known subclasses; falls back to JSON serialization
    /// for unrecognized types.
    /// </summary>
    /// <param name="item">The output item to extract the ID from.</param>
    /// <returns>The item's ID.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the item's <c>Id</c> property is <c>null</c> or the item type
    /// does not expose an <c>id</c> property.
    /// </exception>
    public static string GetId(this OutputItem item)
    {
        Argument.AssertNotNull(item, nameof(item));

        if (TryGetIdCore(item, out var id) && id is not null)
        {
            return id;
        }

        throw new InvalidOperationException(
            $"OutputItem of type '{item.GetType().Name}' does not have a valid Id. " +
            "Ensure the Id property is set before accessing it.");
    }

    private static bool TryGetIdCore(OutputItem item, out string? id)
    {
        // Fast path: pattern match on known subclass types that have an Id property.
        switch (item)
        {
            case OutputItemOutputMessage m:
                id = m.Id;
                return true;
            case OutputItemMessage m:
                id = m.Id;
                return true;
            case OutputItemFunctionToolCall m:
                id = m.Id;
                return true;
            case OutputItemWebSearchToolCall m:
                id = m.Id;
                return true;
            case OutputItemFileSearchToolCall m:
                id = m.Id;
                return true;
            case OutputItemCodeInterpreterToolCall m:
                id = m.Id;
                return true;
            case OutputItemImageGenToolCall m:
                id = m.Id;
                return true;
            case OutputItemComputerToolCall m:
                id = m.Id;
                return true;
            case OutputItemCustomToolCall m:
                id = m.Id;
                return true;
            case OutputItemMcpToolCall m:
                id = m.Id;
                return true;
            case OutputItemMcpListTools m:
                id = m.Id;
                return true;
            case OutputItemMcpApprovalRequest m:
                id = m.Id;
                return true;
            case OutputItemMcpApprovalResponseResource m:
                id = m.Id;
                return true;
            case OutputItemReasoningItem m:
                id = m.Id;
                return true;
            case OutputItemCompactionBody m:
                id = m.Id;
                return true;
            case OutputItemLocalShellToolCall m:
                id = m.Id;
                return true;
            case OutputItemLocalShellToolCallOutput m:
                id = m.Id;
                return true;
            case OutputItemFunctionShellCall m:
                id = m.Id;
                return true;
            case OutputItemFunctionShellCallOutput m:
                id = m.Id;
                return true;
            case OutputItemApplyPatchToolCall m:
                id = m.Id;
                return true;
            case OutputItemApplyPatchToolCallOutput m:
                id = m.Id;
                return true;
            case OutputItemComputerToolCallOutputResource m:
                id = m.Id;
                return true;
            case OutputItemCustomToolCallOutput m:
                id = m.Id;
                return true;
            case FunctionToolCallOutputResource m:
                id = m.Id;
                return true;
            case OAuthConsentRequestOutputItem m:
                id = m.Id;
                return true;
        }

        // Slow path: serialize to JSON and look for an "id" property.
        // This covers any future OutputItem subclasses added by code generation.
        return TryGetIdFromJson(item, out id);
    }

    private static bool TryGetIdFromJson(OutputItem item, out string? id)
    {
        id = null;

        try
        {
            var jsonModel = (IJsonModel<OutputItem>)item;
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                jsonModel.Write(writer, ModelReaderWriterOptions.Json);
            }

            using var doc = JsonDocument.Parse(stream.ToArray());
            if (doc.RootElement.TryGetProperty("id", out var idElement))
            {
                id = idElement.ValueKind == JsonValueKind.Null ? null : idElement.GetString();
                return true;
            }

            return false;
        }
        catch (InvalidCastException)
        {
            // Item does not implement IJsonModel<OutputItem> or cast failed.
            return false;
        }
        catch (JsonException)
        {
            // JSON serialization or parsing failed.
            return false;
        }
        catch (InvalidOperationException)
        {
            // Invalid operation during JSON writing/parsing.
            return false;
        }
    }
}
