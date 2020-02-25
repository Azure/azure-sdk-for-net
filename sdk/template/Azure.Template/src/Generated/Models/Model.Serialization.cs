// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class Model : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("modelInfo");
            writer.WriteObjectValue(ModelInfo);
            if (Keys != null)
            {
                writer.WritePropertyName("keys");
                writer.WriteObjectValue(Keys);
            }
            if (TrainResult != null)
            {
                writer.WritePropertyName("trainResult");
                writer.WriteObjectValue(TrainResult);
            }
            writer.WriteEndObject();
        }
        internal static Model DeserializeModel(JsonElement element)
        {
            Model result = new Model();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("modelInfo"))
                {
                    result.ModelInfo = ModelInfo.DeserializeModelInfo(property.Value);
                    continue;
                }
                if (property.NameEquals("keys"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Keys = KeysResult.DeserializeKeysResult(property.Value);
                    continue;
                }
                if (property.NameEquals("trainResult"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.TrainResult = TrainResult.DeserializeTrainResult(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
