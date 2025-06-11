// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventConnectionRejectedEventDataConverter))]
    public partial class MediaLiveEventConnectionRejectedEventData
    {
        internal static MediaLiveEventConnectionRejectedEventData DeserializeMediaLiveEventConnectionRejectedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ingestUrl = default;
            string streamId = default;
            string encoderIp = default;
            string encoderPort = default;
            string resultCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ingestUrl"u8))
                {
                    ingestUrl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("streamId"u8))
                {
                    streamId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encoderIp"u8))
                {
                    encoderIp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("encoderPort"u8))
                {
                    encoderPort = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resultCode"u8))
                {
                    resultCode = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventConnectionRejectedEventData(ingestUrl, streamId, encoderIp, encoderPort, resultCode);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventConnectionRejectedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventConnectionRejectedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventConnectionRejectedEventDataConverter : JsonConverter<MediaLiveEventConnectionRejectedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventConnectionRejectedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventConnectionRejectedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventConnectionRejectedEventData(document.RootElement);
            }
        }
    }
}
