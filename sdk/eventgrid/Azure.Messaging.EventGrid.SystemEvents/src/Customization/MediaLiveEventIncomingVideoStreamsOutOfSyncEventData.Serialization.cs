// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventIncomingVideoStreamsOutOfSyncEventDataConverter))]
    public partial class MediaLiveEventIncomingVideoStreamsOutOfSyncEventData
    {
        internal static MediaLiveEventIncomingVideoStreamsOutOfSyncEventData DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string firstTimestamp = default;
            string firstDuration = default;
            string secondTimestamp = default;
            string secondDuration = default;
            string timescale = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("firstTimestamp"u8))
                {
                    firstTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("firstDuration"u8))
                {
                    firstDuration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("secondTimestamp"u8))
                {
                    secondTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("secondDuration"u8))
                {
                    secondDuration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescale"u8))
                {
                    timescale = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventIncomingVideoStreamsOutOfSyncEventData(firstTimestamp, firstDuration, secondTimestamp, secondDuration, timescale);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventIncomingVideoStreamsOutOfSyncEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData(document.RootElement);
        }

        internal partial class MediaLiveEventIncomingVideoStreamsOutOfSyncEventDataConverter : JsonConverter<MediaLiveEventIncomingVideoStreamsOutOfSyncEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventIncomingVideoStreamsOutOfSyncEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventIncomingVideoStreamsOutOfSyncEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData(document.RootElement);
            }
        }
    }
}
