// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("EmailChannelProperties")]
namespace Azure.ResourceManager.BotService.Models
{
    public partial class EmailChannelProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("emailAddress");
            writer.WriteStringValue(EmailAddress);
            if (Optional.IsDefined(AuthMethod))
            {
                writer.WritePropertyName("authMethod");
                writer.WriteStringValue(AuthMethod.Value.ToString());
            }
            if (Optional.IsDefined(Password))
            {
                writer.WritePropertyName("password");
                writer.WriteStringValue(Password);
            }
            if (Optional.IsDefined(MagicCode))
            {
                writer.WritePropertyName("magicCode");
                writer.WriteStringValue(MagicCode);
            }
            writer.WritePropertyName("isEnabled");
            writer.WriteBooleanValue(IsEnabled);
            writer.WriteEndObject();
        }

        internal static EmailChannelProperties DeserializeEmailChannelProperties(JsonElement element)
        {
            string emailAddress = default;
            Optional<EmailChannelAuthMethod> authMethod = default;
            Optional<string> password = default;
            Optional<string> magicCode = default;
            bool isEnabled = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("emailAddress"))
                {
                    emailAddress = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("authMethod"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    authMethod = property.Value.GetInt32().ToEmailChannelAuthMethod();
                    continue;
                }
                if (property.NameEquals("password"))
                {
                    password = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("magicCode"))
                {
                    magicCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("isEnabled"))
                {
                    isEnabled = property.Value.GetBoolean();
                    continue;
                }
            }
            return new EmailChannelProperties(emailAddress, Optional.ToNullable(authMethod), password.Value, magicCode.Value, isEnabled);
        }
    }
}
