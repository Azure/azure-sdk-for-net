// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common;

#nullable enable

internal class WebPubSubClientCertificateJsonConverter : JsonConverter<WebPubSubClientCertificate>
{
    public override WebPubSubClientCertificate? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? thumbprint = null;
        string? content = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case WebPubSubClientCertificate.ThumbprintProperty:
                        thumbprint = reader.GetString();
                        break;

                    case WebPubSubClientCertificate.ContentProperty:
                        content = reader.GetString();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        // Ensure that the required 'thumbprint' property is present
        if (thumbprint == null && content == null)
        {
            return null;
        }

        return new WebPubSubClientCertificate(thumbprint!, content);
    }

    public override void Write(Utf8JsonWriter writer, WebPubSubClientCertificate value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(WebPubSubClientCertificate.ThumbprintProperty);
        JsonSerializer.Serialize(writer, value.Thumbprint, options);
        if (value.Content != null)
        {
            writer.WritePropertyName(WebPubSubClientCertificate.ContentProperty);
            JsonSerializer.Serialize(writer, value.Content, options);
        }
        writer.WriteEndObject();
    }
}
