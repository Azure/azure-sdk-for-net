// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    internal class JoinedGroupEventRequestJsonConverter : JsonConverter<JoinedGroupEventRequest>
    {
        public override JoinedGroupEventRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            var element = jsonDocument.RootElement;

            return new JoinedGroupEventRequest(
                null,
                element.GetProperty(JoinedGroupEventRequest.GroupProperty).GetString());
        }

        public override void Write(Utf8JsonWriter writer, JoinedGroupEventRequest value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(JoinedGroupEventRequest.GroupProperty, value.Group);

            if (value.ConnectionContext != null)
            {
                writer.WritePropertyName(WebPubSubEventRequest.ConnectionContextProperty);
                JsonSerializationHelpers.WriteConnectionContext(writer, value.ConnectionContext);
            }

            writer.WriteEndObject();
        }
    }
}
