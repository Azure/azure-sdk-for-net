// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    // The TypeSpec writer's .NET Standard fallback reparses unknown JSON at depth 64.
    // Use the same depth limit as the reader until the generator preserves it.
    [CodeGenSuppress(nameof(JsonModelWriteCore), typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ResourcesHistoryContent
    {
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ResourcesHistoryContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ResourcesHistoryContent)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(Subscriptions))
            {
                writer.WritePropertyName("subscriptions"u8);
                writer.WriteStartArray();
                foreach (string subscription in Subscriptions)
                {
                    writer.WriteStringValue(subscription);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Query))
            {
                writer.WriteString("query"u8, Query);
            }
            if (Optional.IsDefined(Options))
            {
                writer.WritePropertyName("options"u8);
                writer.WriteObjectValue(Options, options);
            }
            if (Optional.IsCollectionDefined(ManagementGroups))
            {
                writer.WritePropertyName("managementGroups"u8);
                writer.WriteStartArray();
                foreach (string managementGroup in ManagementGroups)
                {
                    writer.WriteStringValue(managementGroup);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions);
                    JsonSerializer.Serialize(writer, document.RootElement);
#endif
                }
            }
        }
    }
}
