// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaJobCanceledEventDataConverter))]
    public partial class MediaJobCanceledEventData
    {
        internal static MediaJobCanceledEventData DeserializeMediaJobCanceledEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<MediaJobOutput> outputs = default;
            MediaJobState? previousState = default;
            MediaJobState? state = default;
            IReadOnlyDictionary<string, string> correlationData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("outputs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MediaJobOutput> array = new List<MediaJobOutput>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MediaJobOutput.DeserializeMediaJobOutput(item));
                    }
                    outputs = array;
                    continue;
                }
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
            return new MediaJobCanceledEventData(previousState, state, correlationData ?? new ChangeTrackingDictionary<string, string>(), outputs ?? new ChangeTrackingList<MediaJobOutput>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new MediaJobCanceledEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaJobCanceledEventData(document.RootElement);
        }

        internal partial class MediaJobCanceledEventDataConverter : JsonConverter<MediaJobCanceledEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaJobCanceledEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaJobCanceledEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaJobCanceledEventData(document.RootElement);
            }
        }
    }
}
