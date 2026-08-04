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
        id = item.Id;
        return true;
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

            // Forward scan with Utf8JsonReader — avoids allocating a JsonDocument.
            var reader = new Utf8JsonReader(stream.GetBuffer().AsSpan(0, (int)stream.Length));
            if (reader.Read() && reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        break;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName && reader.ValueTextEquals("id"u8))
                    {
                        if (reader.Read())
                        {
                            id = reader.TokenType == JsonTokenType.Null ? null : reader.GetString();
                            return true;
                        }
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
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
