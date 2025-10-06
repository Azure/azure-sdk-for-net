// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventEncoderDisconnectedEventDataConverter))]
    public partial class MediaLiveEventEncoderDisconnectedEventData
    {
        internal static MediaLiveEventEncoderDisconnectedEventData DeserializeMediaLiveEventEncoderDisconnectedEventData(JsonElement element, ModelReaderWriterOptions options = null)
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
            return new MediaLiveEventEncoderDisconnectedEventData(ingestUrl, streamId, encoderIp, encoderPort, resultCode);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventEncoderDisconnectedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventEncoderDisconnectedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventEncoderDisconnectedEventDataConverter : JsonConverter<MediaLiveEventEncoderDisconnectedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventEncoderDisconnectedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventEncoderDisconnectedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventEncoderDisconnectedEventData(document.RootElement);
            }
        }
    }
}
