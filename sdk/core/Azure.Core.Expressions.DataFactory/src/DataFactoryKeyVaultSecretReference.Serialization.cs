// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactoryKeyVaultSecretReferenceConverter))]
    public partial class DataFactoryKeyVaultSecretReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("store"u8);
            writer.WriteObjectValue(Store);
            writer.WritePropertyName("secretName"u8);
            JsonSerializer.Serialize(writer, SecretName);
            if (Optional.IsDefined(SecretVersion))
            {
                writer.WritePropertyName("secretVersion"u8);
                JsonSerializer.Serialize(writer, SecretVersion);
            }
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(SecretBaseType);
            writer.WriteEndObject();
        }

        internal static DataFactoryKeyVaultSecretReference? DeserializeAzureKeyVaultSecretReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataFactoryLinkedServiceReference? store = default;
            DataFactoryElement<string>? secretName = default;
            Optional<DataFactoryElement<string>> secretVersion = default;
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
            return new DataFactoryKeyVaultSecretReference(type, store, secretName, secretVersion.Value);
        }

        internal partial class DataFactoryKeyVaultSecretReferenceConverter : JsonConverter<DataFactoryKeyVaultSecretReference?>
        {
            public override void Write(Utf8JsonWriter writer, DataFactoryKeyVaultSecretReference? model, JsonSerializerOptions options)
            {
                (model as IUtf8JsonSerializable)?.Write(writer);
            }
            public override DataFactoryKeyVaultSecretReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeAzureKeyVaultSecretReference(document.RootElement);
            }
        }
    }
}
