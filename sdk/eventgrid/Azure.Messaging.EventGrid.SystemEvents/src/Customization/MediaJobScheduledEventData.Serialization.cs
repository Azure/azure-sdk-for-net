// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaJobScheduledEventDataConverter))]
    public partial class MediaJobScheduledEventData
    {
        internal static MediaJobScheduledEventData DeserializeMediaJobScheduledEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MediaJobState? previousState = default;
            MediaJobState? state = default;
            IReadOnlyDictionary<string, string> correlationData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("previousState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    previousState = property.Value.GetString().ToMediaJobState();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    state = property.Value.GetString().ToMediaJobState();
                    continue;
                }
                if (property.NameEquals("correlationData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    correlationData = dictionary;
                    continue;
                }
            }
            return new MediaJobScheduledEventData(previousState, state, correlationData ?? new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new MediaJobScheduledEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaJobScheduledEventData(document.RootElement);
        }

        internal partial class MediaJobScheduledEventDataConverter : JsonConverter<MediaJobScheduledEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaJobScheduledEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaJobScheduledEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaJobScheduledEventData(document.RootElement);
            }
        }
    }
}
