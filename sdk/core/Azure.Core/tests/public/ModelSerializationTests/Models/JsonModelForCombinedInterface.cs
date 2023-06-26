// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using NUnit.Framework;
using System.Text.Json;
using System.IO;
using System.Xml;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class JsonModelForCombinedInterface : IUtf8JsonSerializable, IModelSerializable
    {
        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public JsonModelForCombinedInterface(string key, string value)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
        }

        /// <summary> Gets or sets the key. </summary>
        public string Key { get; set; }
        /// <summary> Gets or sets the value. </summary>
        public string Value { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(new ModelSerializerOptions());

        internal static JsonModelForCombinedInterface DeserializeJsonModelForCombinedInterface(JsonElement element, ModelSerializerOptions options)
        {
            string key = "";
            string value = "";

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
            }
            return new JsonModelForCombinedInterface(key, value);
        }

        internal static void VerifyModelJsonModelForCombinedInterface(JsonModelForCombinedInterface correctModelXml, JsonModelForCombinedInterface model2)
        {
            Assert.AreEqual(correctModelXml.Key, model2.Key);
            Assert.AreEqual(correctModelXml.Value, model2.Value);
        }

        Stream IModelSerializable.Serialize(ModelSerializerOptions options)
        {
            Stream s = new MemoryStream();
            Utf8JsonWriter writer = new Utf8JsonWriter(s);
            SerializeWithWriter(writer, options);
            //s.Position = 0;
            return s;
        }

        internal static JsonModelForCombinedInterface DeserializeJsonModelForCombinedInterface(Stream s, ModelSerializerOptions options)
        {
            var json = JsonDocument.Parse(s);
            return DeserializeJsonModelForCombinedInterface(json.RootElement, options);
        }

        private void SerializeWithWriter(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            writer.WriteEndObject();
        }
    }
}
