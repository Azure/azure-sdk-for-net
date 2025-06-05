// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactoryKeyVaultSecretConverter))]
    public partial class DataFactoryKeyVaultSecret : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            var options = new ModelReaderWriterOptions("W");
            writer.WriteStartObject();
            writer.WritePropertyName("store"u8);
            writer.WriteObjectValue<DataFactoryLinkedServiceReference>(Store);
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
                    secretName = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("secretVersion"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    secretVersion = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new DataFactoryKeyVaultSecret(type, store, secretName, secretVersion);
        }

        internal partial class DataFactoryKeyVaultSecretConverter : JsonConverter<DataFactoryKeyVaultSecret?>
        {
            public override void Write(Utf8JsonWriter writer, DataFactoryKeyVaultSecret? model, JsonSerializerOptions options)
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
