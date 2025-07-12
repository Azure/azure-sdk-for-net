// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactorySecretStringConverter))]
    public partial class DataFactorySecretString : IUtf8JsonSerializable, IJsonModel<DataFactorySecretString>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(SecretBaseType);
            writer.WriteEndObject();
        }

        void IJsonModel<DataFactorySecretString>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecretString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecretString)} does not support writing '{format}' format.");
            }

            ((IUtf8JsonSerializable)this).Write(writer);
        }

        DataFactorySecretString? IJsonModel<DataFactorySecretString>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecretString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecretString)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataFactorySecretString(document.RootElement);
        }

        BinaryData IPersistableModel<DataFactorySecretString>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecretString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecretString)} does not support writing '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
        }

        DataFactorySecretString? IPersistableModel<DataFactorySecretString>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecretString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecretString)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            return DeserializeDataFactorySecretString(document.RootElement);
        }

        string IPersistableModel<DataFactorySecretString>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static DataFactorySecretString? DeserializeDataFactorySecretString(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string? value = default;
            string? type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new DataFactorySecretString(type, value);
        }

        internal partial class DataFactorySecretStringConverter : JsonConverter<DataFactorySecretString>
        {
            public override void Write(Utf8JsonWriter writer, DataFactorySecretString model, JsonSerializerOptions options)
            {
                (model as IUtf8JsonSerializable)?.Write(writer);
            }
            public override DataFactorySecretString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDataFactorySecretString(document.RootElement);
            }
        }
    }
}
