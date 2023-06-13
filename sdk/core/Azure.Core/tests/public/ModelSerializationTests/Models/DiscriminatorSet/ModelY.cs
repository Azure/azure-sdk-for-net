// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Newtonsoft.Json.Linq;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class ModelY : BaseModel, IUtf8JsonSerializable, IModel
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

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModel)this).Serialize(writer, new ModelSerializerOptions());

        void IModel.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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

        protected override void CopyModel(BaseModel model)
        {
            var that = model as ModelY;
            this.Name = that.Name;
            this.Kind = that.Kind;
            this.YProperty = that.YProperty;
            this.RawData = that.RawData;
        }
    }
}
