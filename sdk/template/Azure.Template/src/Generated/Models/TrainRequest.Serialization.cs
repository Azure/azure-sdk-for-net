// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("source");
            writer.WriteStringValue(Source);
            if (SourceFilter != null)
            {
                writer.WritePropertyName("sourceFilter");
                writer.WriteObjectValue(SourceFilter);
            }
            if (UseLabelFile != null)
            {
                writer.WritePropertyName("useLabelFile");
                writer.WriteBooleanValue(UseLabelFile.Value);
            }
            writer.WriteEndObject();
        }
        internal static TrainRequest DeserializeTrainRequest(JsonElement element)
        {
            TrainRequest result = new TrainRequest();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("source"))
                {
                    result.Source = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceFilter"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.SourceFilter = TrainSourceFilter.DeserializeTrainSourceFilter(property.Value);
                    continue;
                }
                if (property.NameEquals("useLabelFile"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.UseLabelFile = property.Value.GetBoolean();
                    continue;
                }
            }
            return result;
        }
    }
}
