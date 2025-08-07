// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventIncomingStreamReceivedEventDataConverter))]
    public partial class MediaLiveEventIncomingStreamReceivedEventData
    {
        internal static MediaLiveEventIncomingStreamReceivedEventData DeserializeMediaLiveEventIncomingStreamReceivedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string ingestUrl = default;
            string trackType = default;
            string trackName = default;
            long? bitrate = default;
            string encoderIp = default;
            string encoderPort = default;
            string timestamp = default;
            string duration = default;
            string timescale = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ingestUrl"u8))
                {
                    ingestUrl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("trackType"u8))
                {
                    trackType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("trackName"u8))
                {
                    trackName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bitrate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bitrate = property.Value.GetInt64();
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
                if (property.NameEquals("timestamp"u8))
                {
                    timestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("duration"u8))
                {
                    duration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescale"u8))
                {
                    timescale = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventIncomingStreamReceivedEventData(
                ingestUrl,
                trackType,
                trackName,
                bitrate,
                encoderIp,
                encoderPort,
                timestamp,
                duration,
                timescale);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventIncomingStreamReceivedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventIncomingStreamReceivedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventIncomingStreamReceivedEventDataConverter : JsonConverter<MediaLiveEventIncomingStreamReceivedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventIncomingStreamReceivedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventIncomingStreamReceivedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventIncomingStreamReceivedEventData(document.RootElement);
            }
        }
    }
}
