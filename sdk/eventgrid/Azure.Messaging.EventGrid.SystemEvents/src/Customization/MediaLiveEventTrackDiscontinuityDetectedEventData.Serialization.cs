// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventTrackDiscontinuityDetectedEventDataConverter))]
    public partial class MediaLiveEventTrackDiscontinuityDetectedEventData
    {
        internal static MediaLiveEventTrackDiscontinuityDetectedEventData DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string trackType = default;
            string trackName = default;
            long? bitrate = default;
            string previousTimestamp = default;
            string newTimestamp = default;
            string timescale = default;
            string discontinuityGap = default;
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("previousTimestamp"u8))
                {
                    previousTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("newTimestamp"u8))
                {
                    newTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescale"u8))
                {
                    timescale = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("discontinuityGap"u8))
                {
                    discontinuityGap = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventTrackDiscontinuityDetectedEventData(
                trackType,
                trackName,
                bitrate,
                previousTimestamp,
                newTimestamp,
                timescale,
                discontinuityGap);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventTrackDiscontinuityDetectedEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData(document.RootElement);
        }

        internal partial class MediaLiveEventTrackDiscontinuityDetectedEventDataConverter : JsonConverter<MediaLiveEventTrackDiscontinuityDetectedEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventTrackDiscontinuityDetectedEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventTrackDiscontinuityDetectedEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData(document.RootElement);
            }
        }
    }
}
