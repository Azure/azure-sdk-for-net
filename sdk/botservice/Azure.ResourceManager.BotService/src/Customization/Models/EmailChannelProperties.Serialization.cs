// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("EmailChannelProperties")]
namespace Azure.ResourceManager.BotService.Models
{
    public partial class EmailChannelProperties : IUtf8JsonSerializable, IJsonModel<EmailChannelProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<EmailChannelProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<EmailChannelProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmailChannelProperties>)this).GetFormatFromOptions(options) : options.Format;

            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(EmailChannelProperties)} does not support '{options.Format}' format.");
            }
            writer.WriteStartObject();
            writer.WritePropertyName("emailAddress"u8);
            writer.WriteStringValue(EmailAddress);
            if (Optional.IsDefined(AuthMethod))
            {
                writer.WritePropertyName("authMethod"u8);
                writer.WriteStringValue(AuthMethod.Value.ToString());
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password"u8);
                writer.WriteStringValue(Password);
            }
            if (Optional.IsDefined(MagicCode))
            {
                writer.WritePropertyName("magicCode"u8);
                writer.WriteStringValue(MagicCode);
            }
            writer.WritePropertyName("isEnabled"u8);
            writer.WriteBooleanValue(IsEnabled);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        EmailChannelProperties IJsonModel<EmailChannelProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmailChannelProperties>)this).GetFormatFromOptions(options) : options.Format;

            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(EmailChannelProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEmailChannelProperties(document.RootElement, options);
        }

        internal static EmailChannelProperties DeserializeEmailChannelProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string emailAddress = default;
            Optional<EmailChannelAuthMethod> authMethod = default;
            Optional<string> password = default;
            Optional<string> magicCode = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            bool isEnabled = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("emailAddress"u8))
                {
                    emailAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("authMethod"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    authMethod = property.Value.GetInt32().ToEmailChannelAuthMethod();
                    continue;
                }
                if (property.NameEquals("password"u8))
                {
                    password = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("magicCode"u8))
                {
                    magicCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isEnabled"u8))
                {
                    isEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new EmailChannelProperties(emailAddress, Optional.ToNullable(authMethod), password.Value, magicCode.Value, isEnabled, serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<EmailChannelProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmailChannelProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(EmailChannelProperties)} does not support '{options.Format}' format.");
            }
        }

        EmailChannelProperties IPersistableModel<EmailChannelProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmailChannelProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeEmailChannelProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(EmailChannelProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<EmailChannelProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
