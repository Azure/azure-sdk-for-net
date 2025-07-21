// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventIngestHeartbeatEventDataConverter))]
    public partial class MediaLiveEventIngestHeartbeatEventData
    {
        internal static MediaLiveEventIngestHeartbeatEventData DeserializeMediaLiveEventIngestHeartbeatEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string trackType = default;
            string trackName = default;
            string transcriptionLanguage = default;
            string transcriptionState = default;
            long? bitrate = default;
            long? incomingBitrate = default;
            string ingestDriftValue = default;
            DateTimeOffset? lastFragmentArrivalTime = default;
            string lastTimestamp = default;
            string timescale = default;
            long? overlapCount = default;
            long? discontinuityCount = default;
            long? nonincreasingCount = default;
            bool? unexpectedBitrate = default;
            string state = default;
            bool? healthy = default;
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
                if (property.NameEquals("transcriptionLanguage"u8))
                {
                    transcriptionLanguage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("transcriptionState"u8))
                {
                    transcriptionState = property.Value.GetString();
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
                if (property.NameEquals("incomingBitrate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    incomingBitrate = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("ingestDriftValue"u8))
                {
                    ingestDriftValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastFragmentArrivalTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastFragmentArrivalTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastTimestamp"u8))
                {
                    lastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescale"u8))
                {
                    timescale = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("overlapCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    overlapCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("discontinuityCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    discontinuityCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("nonincreasingCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonincreasingCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("unexpectedBitrate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    unexpectedBitrate = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    state = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("healthy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    healthy = property.Value.GetBoolean();
                    continue;
                }
            }
            return new MediaLiveEventIngestHeartbeatEventData(
                trackType,
                trackName,
                transcriptionLanguage,
                transcriptionState,
                bitrate,
                incomingBitrate,
                ingestDriftValue,
                lastFragmentArrivalTime,
                lastTimestamp,
                timescale,
                overlapCount,
                discontinuityCount,
                nonincreasingCount,
                unexpectedBitrate,
                state,
                healthy);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventIngestHeartbeatEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventIngestHeartbeatEventData(document.RootElement);
        }

        internal partial class MediaLiveEventIngestHeartbeatEventDataConverter : JsonConverter<MediaLiveEventIngestHeartbeatEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventIngestHeartbeatEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventIngestHeartbeatEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventIngestHeartbeatEventData(document.RootElement);
            }
        }
    }
}
