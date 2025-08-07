// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventIncomingDataChunkDroppedEventDataConverter))]
    public partial class MediaLiveEventIncomingDataChunkDroppedEventData
    {
        internal static MediaLiveEventIncomingDataChunkDroppedEventData DeserializeMediaLiveEventIncomingDataChunkDroppedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string timestamp = default;
            string trackType = default;
            long? bitrate = default;
            string timescale = default;
            string resultCode = default;
            string trackName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timestamp"u8))
                {
                    timestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("trackType"u8))
                {
                    trackType = property.Value.GetString();
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
                if (property.NameEquals("timescale"u8))
                {
                    timescale = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resultCode"u8))
                {
                    resultCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("trackName"u8))
                {
                    trackName = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventIncomingDataChunkDroppedEventData(
                timestamp,
                trackType,
                bitrate,
                timescale,
                resultCode,
                trackName);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventIncomingDataChunkDroppedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventIncomingDataChunkDroppedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventIncomingDataChunkDroppedEventDataConverter : JsonConverter<MediaLiveEventIncomingDataChunkDroppedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventIncomingDataChunkDroppedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventIncomingDataChunkDroppedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventIncomingDataChunkDroppedEventData(document.RootElement);
            }
        }
    }
}
