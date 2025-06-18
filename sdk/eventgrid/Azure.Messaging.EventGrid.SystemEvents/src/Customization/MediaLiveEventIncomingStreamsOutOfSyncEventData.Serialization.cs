// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventIncomingStreamsOutOfSyncEventDataConverter))]
    public partial class MediaLiveEventIncomingStreamsOutOfSyncEventData
    {
        internal static MediaLiveEventIncomingStreamsOutOfSyncEventData DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string minLastTimestamp = default;
            string typeOfStreamWithMinLastTimestamp = default;
            string maxLastTimestamp = default;
            string typeOfStreamWithMaxLastTimestamp = default;
            string timescaleOfMinLastTimestamp = default;
            string timescaleOfMaxLastTimestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minLastTimestamp"u8))
                {
                    minLastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("typeOfStreamWithMinLastTimestamp"u8))
                {
                    typeOfStreamWithMinLastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxLastTimestamp"u8))
                {
                    maxLastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("typeOfStreamWithMaxLastTimestamp"u8))
                {
                    typeOfStreamWithMaxLastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescaleOfMinLastTimestamp"u8))
                {
                    timescaleOfMinLastTimestamp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timescaleOfMaxLastTimestamp"u8))
                {
                    timescaleOfMaxLastTimestamp = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventIncomingStreamsOutOfSyncEventData(
                minLastTimestamp,
                typeOfStreamWithMinLastTimestamp,
                maxLastTimestamp,
                typeOfStreamWithMaxLastTimestamp,
                timescaleOfMinLastTimestamp,
                timescaleOfMaxLastTimestamp);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventIncomingStreamsOutOfSyncEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData(document.RootElement);
        }

        internal partial class MediaLiveEventIncomingStreamsOutOfSyncEventDataConverter : JsonConverter<MediaLiveEventIncomingStreamsOutOfSyncEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventIncomingStreamsOutOfSyncEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventIncomingStreamsOutOfSyncEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData(document.RootElement);
            }
        }
    }
}
