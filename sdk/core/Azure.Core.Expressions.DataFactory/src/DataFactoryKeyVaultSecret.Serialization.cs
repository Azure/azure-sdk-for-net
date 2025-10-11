// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactoryKeyVaultSecretConverter))]
    public partial class DataFactoryKeyVaultSecret : IUtf8JsonSerializable, IJsonModel<DataFactoryKeyVaultSecret>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            var options = new ModelReaderWriterOptions("W");
            writer.WriteStartObject();
            writer.WritePropertyName("store"u8);
            ((IUtf8JsonSerializable)Store).Write(writer);
            writer.WritePropertyName("secretName"u8);
            ((IJsonModel<DataFactoryElement<string>>)SecretName).Write(writer, options);
            if (Optional.IsDefined(SecretVersion))
            {
                writer.WritePropertyName("secretVersion"u8);
                ((IJsonModel<DataFactoryElement<string>>)SecretVersion).Write(writer, options);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(SecretBaseType);
            writer.WriteEndObject();
        }

        void IJsonModel<DataFactoryKeyVaultSecret>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryKeyVaultSecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryKeyVaultSecret)} does not support writing '{format}' format.");
            }

            ((IUtf8JsonSerializable)this).Write(writer);
        }

        DataFactoryKeyVaultSecret? IJsonModel<DataFactoryKeyVaultSecret>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryKeyVaultSecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryKeyVaultSecret)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureKeyVaultSecretReference(document.RootElement);
        }

        BinaryData IPersistableModel<DataFactoryKeyVaultSecret>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryKeyVaultSecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryKeyVaultSecret)} does not support writing '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
        }

        DataFactoryKeyVaultSecret? IPersistableModel<DataFactoryKeyVaultSecret>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactoryKeyVaultSecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactoryKeyVaultSecret)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            return DeserializeAzureKeyVaultSecretReference(document.RootElement);
        }

        string IPersistableModel<DataFactoryKeyVaultSecret>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static DataFactoryKeyVaultSecret? DeserializeAzureKeyVaultSecretReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataFactoryLinkedServiceReference? store = default;
            DataFactoryElement<string>? secretName = default;
            DataFactoryElement<string>? secretVersion = default;
            string? type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("store"u8))
                {
                    store = DataFactoryLinkedServiceReference.DeserializeDataFactoryLinkedServiceReference(property.Value);
                    continue;
                }
                if (property.NameEquals("secretName"u8))
                {
#pragma warning disable IL2026 // Unsafe JSON serialization
#pragma warning disable IL3050 // Unsafe JSON serialization
                    secretName = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
#pragma warning restore IL2026 // Unsafe JSON serialization
#pragma warning restore IL3050 // Unsafe JSON serialization
                    continue;
                }
                if (property.NameEquals("secretVersion"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
#pragma warning disable IL2026 // Unsafe JSON serialization
#pragma warning disable IL3050 // Unsafe JSON serialization
                    secretVersion = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
#pragma warning restore IL2026 // Unsafe JSON serialization
#pragma warning restore IL3050 // Unsafe JSON serialization
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new DataFactoryKeyVaultSecret(type!, store!, secretName!, secretVersion!);
        }

        internal partial class DataFactoryKeyVaultSecretConverter : JsonConverter<DataFactoryKeyVaultSecret>
        {
            public override void Write(Utf8JsonWriter writer, DataFactoryKeyVaultSecret model, JsonSerializerOptions options)
            {
                (model as IUtf8JsonSerializable)?.Write(writer);
            }
            public override DataFactoryKeyVaultSecret? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeAzureKeyVaultSecretReference(document.RootElement);
            }
        }
    }
}
