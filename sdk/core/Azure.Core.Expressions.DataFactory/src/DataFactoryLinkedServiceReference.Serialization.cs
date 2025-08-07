// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactoryLinkedServiceReferenceConverter))]
    public partial class DataFactoryLinkedServiceReference : IUtf8JsonSerializable, IJsonModel<DataFactoryLinkedServiceReference>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(ReferenceKind.ToString());
            writer.WritePropertyName("referenceName"u8);
            writer.WriteStringValue(ReferenceName);
            if (Optional.IsCollectionDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
                writer.WriteStartObject();
                foreach (var item in Parameters)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        void IJsonModel<DataFactoryLinkedServiceReference>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryLinkedServiceReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryLinkedServiceReference)} does not support writing '{format}' format.");
            }

            ((IUtf8JsonSerializable)this).Write(writer);
        }

        DataFactoryLinkedServiceReference? IJsonModel<DataFactoryLinkedServiceReference>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryLinkedServiceReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryLinkedServiceReference)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataFactoryLinkedServiceReference(document.RootElement);
        }

        BinaryData IPersistableModel<DataFactoryLinkedServiceReference>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryLinkedServiceReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryLinkedServiceReference)} does not support writing '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
        }

        DataFactoryLinkedServiceReference? IPersistableModel<DataFactoryLinkedServiceReference>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryLinkedServiceReference>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryLinkedServiceReference)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            return DeserializeDataFactoryLinkedServiceReference(document.RootElement);
        }

        string IPersistableModel<DataFactoryLinkedServiceReference>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static DataFactoryLinkedServiceReference? DeserializeDataFactoryLinkedServiceReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataFactoryLinkedServiceReferenceKind kind = default;
            string? referenceName = default;
            Optional<IDictionary<string, BinaryData?>> parameters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    kind = new DataFactoryLinkedServiceReferenceKind(property.Value.GetString() ?? string.Empty);
                    continue;
                }
                if (property.NameEquals("referenceName"u8))
                {
                    referenceName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, BinaryData?> dictionary = new Dictionary<string, BinaryData?>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(property0.Name, BinaryData.FromString(property0.Value.GetRawText()));
                        }
                    }
                    parameters = dictionary;
                    continue;
                }
            }
            return new DataFactoryLinkedServiceReference(kind, referenceName, Optional.ToDictionary(parameters));
        }

        internal partial class DataFactoryLinkedServiceReferenceConverter : JsonConverter<DataFactoryLinkedServiceReference>
        {
            public override void Write(Utf8JsonWriter writer, DataFactoryLinkedServiceReference model, JsonSerializerOptions options)
            {
                (model as IUtf8JsonSerializable)?.Write(writer);
            }
            public override DataFactoryLinkedServiceReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDataFactoryLinkedServiceReference(document.RootElement);
            }
        }
    }
}
