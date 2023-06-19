// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal abstract class BaseModel : IUtf8JsonSerializable, IJsonSerializableModel
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public string Kind { get; internal set; }
        public string Name { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonSerializableModel)this).Serialize(writer, new ModelSerializerOptions());

        void IJsonSerializableModel.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (!options.IgnoreAdditionalProperties)
            {
                //write out the raw data
                foreach (var property in RawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(JsonElement element, ModelSerializerOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "X":
                        return ModelX.DeserializeModelX(element, options);
                    case "Y":
                        return ModelY.DeserializeModelY(element, options);
                }
            }
            return UnknownBaseModel.DeserializeUnknownBaseModel(element, options);
        }

        protected abstract void CopyModel(BaseModel model);
    }
}
