// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaLiveEventChannelArchiveHeartbeatEventDataConverter))]
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData
    {
        internal static MediaLiveEventChannelArchiveHeartbeatEventData DeserializeMediaLiveEventChannelArchiveHeartbeatEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string channelLatencyMs = default;
            string latencyResultCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("channelLatencyMs"u8))
                {
                    channelLatencyMs = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("latencyResultCode"u8))
                {
                    latencyResultCode = property.Value.GetString();
                    continue;
                }
            }
            return new MediaLiveEventChannelArchiveHeartbeatEventData(channelLatencyMs, latencyResultCode);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static MediaLiveEventChannelArchiveHeartbeatEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaLiveEventChannelArchiveHeartbeatEventData(document.RootElement);
        }

        internal partial class MediaLiveEventChannelArchiveHeartbeatEventDataConverter : JsonConverter<MediaLiveEventChannelArchiveHeartbeatEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaLiveEventChannelArchiveHeartbeatEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaLiveEventChannelArchiveHeartbeatEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaLiveEventChannelArchiveHeartbeatEventData(document.RootElement);
            }
        }
    }
}
