// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    [JsonConverter(typeof(SubResourceConverter))]
    public partial class SubResource : IUtf8JsonSerializable, IJsonModel<SubResource>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SubResource>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<SubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubResource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SubResource)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WriteEndObject();
        }

        SubResource IJsonModel<SubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubResource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SubResource)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSubResource(document.RootElement, options);
        }

        internal static SubResource DeserializeSubResource(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
            }
            return new SubResource(id);
        }

        BinaryData IPersistableModel<SubResource>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubResource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(SubResource)} does not support '{options.Format}' format.");
            }
        }

        SubResource IPersistableModel<SubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SubResource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeSubResource(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SubResource)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<SubResource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class SubResourceConverter : JsonConverter<SubResource>
        {
            public override void Write(Utf8JsonWriter writer, SubResource model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override SubResource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSubResource(document.RootElement);
            }
        }
    }
}
