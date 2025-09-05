// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    [JsonConverter(typeof(MediaJobOutputScheduledEventDataConverter))]
    public partial class MediaJobOutputScheduledEventData
    {
        internal static MediaJobOutputScheduledEventData DeserializeMediaJobOutputScheduledEventData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MediaJobState? previousState = default;
            MediaJobOutput output = default;
            IReadOnlyDictionary<string, string> jobCorrelationData = default;
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
                if (property.NameEquals("output"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    output = MediaJobOutput.DeserializeMediaJobOutput(property.Value);
                    continue;
                }
                if (property.NameEquals("jobCorrelationData"u8))
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
                    jobCorrelationData = dictionary;
                    continue;
                }
            }
            return new MediaJobOutputScheduledEventData(previousState, output, jobCorrelationData ?? new ChangeTrackingDictionary<string, string>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new MediaJobOutputScheduledEventData FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeMediaJobOutputScheduledEventData(document.RootElement);
        }

        internal partial class MediaJobOutputScheduledEventDataConverter : JsonConverter<MediaJobOutputScheduledEventData>
        {
            public override void Write(Utf8JsonWriter writer, MediaJobOutputScheduledEventData model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            public override MediaJobOutputScheduledEventData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMediaJobOutputScheduledEventData(document.RootElement);
            }
        }
    }
}
