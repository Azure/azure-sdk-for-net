// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Newtonsoft.Json.Linq;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class ModelY : BaseModel, IUtf8JsonSerializable, IModelSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public ModelY()
        {
            Kind = "Y";
        }

        internal ModelY(string kind, string name, string yProperty, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            YProperty = yProperty;
            RawData = rawData;
        }

        public string YProperty { get; private set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            BinaryData data = ((IModelSerializable)this).Serialize(new ModelSerializerOptions());
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        BinaryData IModelSerializable.Serialize(ModelSerializerOptions options)
        {
            MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (!options.IgnoreReadOnlyProperties)
            {
                if (Optional.IsDefined(Name))
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
            }
            writer.WritePropertyName("yProperty"u8);
            writer.WriteStringValue(YProperty);
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
            writer.Flush();
            stream.Position = 0;
            return new BinaryData(stream.ToArray());
        }

        internal static ModelY DeserializeModelY(JsonElement element, ModelSerializerOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            Optional<string> name = default;
            Optional<string> yProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("yProperty"u8))
                {
                    yProperty = property.Value.GetString();
                    continue;
                }
                if (!options.IgnoreAdditionalProperties)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ModelY(kind, name, yProperty, rawData);
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeModelY(JsonDocument.Parse(data.ToString()).RootElement, options);
        }
    }
}
