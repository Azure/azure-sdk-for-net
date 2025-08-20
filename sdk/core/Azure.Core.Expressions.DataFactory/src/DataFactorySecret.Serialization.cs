// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Core.Expressions.DataFactory
{
    [JsonConverter(typeof(DataFactorySecretBaseDefinitionConverter))]
    public partial class DataFactorySecret : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(SecretBaseType);
            writer.WriteEndObject();
        }

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

        internal partial class DataFactorySecretBaseDefinitionConverter : JsonConverter<DataFactorySecret?>
        {
            public override void Write(Utf8JsonWriter writer, DataFactorySecret? model, JsonSerializerOptions options)
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
