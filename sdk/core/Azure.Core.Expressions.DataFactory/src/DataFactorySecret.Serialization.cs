// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactorySecretBaseDefinitionConverter))]
    [PersistableModelProxy(typeof(UnknownSecret))]
    public partial class DataFactorySecret : IUtf8JsonSerializable, IJsonModel<DataFactorySecret>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(SecretBaseType);
            writer.WriteEndObject();
        }

        void IJsonModel<DataFactorySecret>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecret)} does not support writing '{format}' format.");
            }

            ((IUtf8JsonSerializable)this).Write(writer);
        }

        DataFactorySecret? IJsonModel<DataFactorySecret>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecret)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataFactorySecretBaseDefinition(document.RootElement);
        }

        BinaryData IPersistableModel<DataFactorySecret>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecret)} does not support writing '{format}' format.");
            }

            return ModelReaderWriter.Write(this, options, DataFactoryContext.Default);
        }

        DataFactorySecret? IPersistableModel<DataFactorySecret>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataFactorySecret>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataFactorySecret)} does not support reading '{format}' format.");
            }

            using var document = JsonDocument.Parse(data);
            return DeserializeDataFactorySecretBaseDefinition(document.RootElement);
        }

        string IPersistableModel<DataFactorySecret>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static DataFactorySecret? DeserializeDataFactorySecretBaseDefinition(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "SecureString": return DataFactorySecretString.DeserializeDataFactorySecretString(element);
                    case "AzureKeyVaultSecret": return DataFactoryKeyVaultSecret.DeserializeAzureKeyVaultSecretReference(element);
                }
            }
            return UnknownSecret.DeserializeUnknownSecretBase(element);
        }

        internal partial class DataFactorySecretBaseDefinitionConverter : JsonConverter<DataFactorySecret>
        {
            public override void Write(Utf8JsonWriter writer, DataFactorySecret model, JsonSerializerOptions options)
            {
                (model as IUtf8JsonSerializable)?.Write(writer);
            }
            public override DataFactorySecret? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeDataFactorySecretBaseDefinition(document.RootElement);
            }
        }
    }
}
