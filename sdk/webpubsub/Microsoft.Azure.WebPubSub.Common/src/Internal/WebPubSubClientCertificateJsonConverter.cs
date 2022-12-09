// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class WebPubSubClientCertificateJsonConverter : JsonConverter<WebPubSubClientCertificate>
    {
        public override WebPubSubClientCertificate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            return new WebPubSubClientCertificate(
                element.ReadString(WebPubSubClientCertificate.ThumbprintProperty));
        }

        public override void Write(Utf8JsonWriter writer, WebPubSubClientCertificate value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(WebPubSubClientCertificate.ThumbprintProperty);
            JsonSerializer.Serialize(writer, value.Thumbprint, options);
            writer.WriteEndObject();
        }
    }
}
