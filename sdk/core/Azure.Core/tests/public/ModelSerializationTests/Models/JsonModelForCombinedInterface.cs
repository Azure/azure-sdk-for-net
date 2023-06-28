// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using NUnit.Framework;
using System.Text.Json;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class JsonModelForCombinedInterface : IUtf8JsonSerializable, IModelSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public JsonModelForCombinedInterface() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public JsonModelForCombinedInterface(string key, string value, string readOnlyProperty)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readOnlyProperty;
        }

        internal JsonModelForCombinedInterface(string key, string value, string readOnlyProperty, Dictionary<string, BinaryData> rawData)
        {
            Key = key;
            Value = value;
            ReadOnlyProperty = readOnlyProperty;
            RawData = rawData;
        }

        /// <summary> Gets or sets the key. </summary>
        public string Key { get; set; }
        /// <summary> Gets or sets the value. </summary>
        public string Value { get; set; }
        public string ReadOnlyProperty { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            BinaryData data = ((IModelSerializable)this).Serialize(new ModelSerializerOptions());
#if NET6_0_OR_GREATER
            writer.WriteRawValue(data);
#else
            JsonSerializer.Serialize(writer, JsonDocument.Parse(data.ToString()).RootElement);
#endif
        }

        internal static JsonModelForCombinedInterface DeserializeJsonModelForCombinedInterface(JsonElement element, ModelSerializerOptions options)
        {
            string key = default;
            string value = default;
            string readOnlyProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"u8))
                {
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readOnlyProperty"u8))
                {
                    readOnlyProperty = property.Value.GetString();
                    continue;
                }
                if (!options.IgnoreAdditionalProperties)
                {
                    //this means its an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new JsonModelForCombinedInterface(key, value, readOnlyProperty, rawData);
        }

        BinaryData IModelSerializable.Serialize(ModelSerializerOptions options)
        {
            MemoryStream stream = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            if (!options.IgnoreReadOnlyProperties)
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
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
            writer.Flush();
            stream.Position = 0;
            return new BinaryData(stream.ToArray());
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeJsonModelForCombinedInterface(JsonDocument.Parse(data.ToString()).RootElement, options);
        }
    }
}
