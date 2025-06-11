// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventEncoderConnectedEventDataConverter))]
    public partial class MediaLiveEventEncoderConnectedEventData
    {
        internal static MediaLiveEventEncoderConnectedEventData DeserializeMediaLiveEventEncoderConnectedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ingestUrl = default;
            string streamId = default;
            string encoderIp = default;
            string encoderPort = default;
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
            }
            return new MediaLiveEventEncoderConnectedEventData(ingestUrl, streamId, encoderIp, encoderPort);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventEncoderConnectedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventEncoderConnectedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventEncoderConnectedEventDataConverter : JsonConverter<MediaLiveEventEncoderConnectedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventEncoderConnectedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventEncoderConnectedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventEncoderConnectedEventData(document.RootElement);
            }
        }
    }
}
