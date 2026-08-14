// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Emitter customization for <see cref="AgentsPagedResultOutputItem"/> that
/// replaces the generated <c>JsonModelWriteCore</c> to always write
/// <c>"object": "list"</c> in serialized JSON.
/// The upstream TypeSpec defines <c>AgentsPagedResult&lt;T&gt;</c> in a shared
/// read-only layer without an <c>object</c> property, so we inject it here.
/// </summary>
[CodeGenSuppress("JsonModelWriteCore", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class AgentsPagedResultOutputItem
{
    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<AgentsPagedResultOutputItem>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(AgentsPagedResultOutputItem)} does not support writing '{format}' format.");
        }

        writer.WritePropertyName("object"u8);
        writer.WriteStringValue("list");

        writer.WritePropertyName("data"u8);
        writer.WriteStartArray();
        foreach (OutputItem item in Data)
        {
            writer.WriteObjectValue(item, options);
        }
        writer.WriteEndArray();
        if (Optional.IsDefined(FirstId))
        {
            writer.WritePropertyName("first_id"u8);
            writer.WriteStringValue(FirstId);
        }
        if (Optional.IsDefined(LastId))
        {
            writer.WritePropertyName("last_id"u8);
            writer.WriteStringValue(LastId);
        }
        writer.WritePropertyName("has_more"u8);
        writer.WriteBooleanValue(HasMore);
        if (options.Format != "W" && _additionalBinaryDataProperties != null)
        {
            foreach (var item in _additionalBinaryDataProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using (JsonDocument document = JsonDocument.Parse(item.Value))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
        }
    }
}
