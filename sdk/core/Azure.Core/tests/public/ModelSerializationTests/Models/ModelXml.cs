// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Xml;
using Azure.Core.Serialization;
using NUnit.Framework;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    internal class ModelXml : IXmlSerializable, IModelSerializable
    {
        internal ModelXml() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelXml(string key, string value, string readonlyProperty)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readonlyProperty;
        }

        /// <summary> Gets or sets the key. </summary>
        [XmlElement("Key")]
        public string Key { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("Value")]
        public string Value { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("ReadOnlyProperty")]
        public string ReadOnlyProperty { get; }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, new ModelSerializerOptions());

        private void Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement("Tag");
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WriteStartElement("ReadOnlyProperty");
                writer.WriteValue(ReadOnlyProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
            }
            writer.WriteEndObject();
        }

        internal static ModelXml DeserializeModelXml(XElement element, ModelSerializerOptions options = default)
        {
            string key = default;
            string value = default;
            string readonlyProperty = default;
            if (element.Element("Key") is XElement keyElement)
            {
                key = (string)keyElement;
            }
            if (element.Element("Value") is XElement valueElement)
            {
                value = (string)valueElement;
            }
            if (element.Element("ReadOnlyProperty") is XElement readonlyPropertyElement)
            {
                readonlyProperty = (string)readonlyPropertyElement;
            }
            return new ModelXml(key, value, readonlyProperty);
        }

        BinaryData IModelSerializable.Serialize(ModelSerializerOptions options)
        {
            if (options.Format == ModelSerializerFormat.Json)
            {
                MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
                Serialize(writer, options);
                writer.Flush();
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            if (options.Format == ModelSerializerFormat.Wire)
            {
                MemoryStream stream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(stream);
                Serialize(writer, options);
                writer.Flush();
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            throw new InvalidOperationException($"Unsupported format '{options.Format}' request for '{GetType().Name}'");
        }

        internal static ModelXml DeserializeModelXml(JsonElement element, ModelSerializerOptions options)
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
            }
            return new ModelXml(key, value, readOnlyProperty);
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            if (options.Format == ModelSerializerFormat.Json)
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeModelXml(doc.RootElement, options);
            }
            if (options.Format == ModelSerializerFormat.Wire)
            {
                return DeserializeModelXml(XElement.Load(data.ToStream()), options);
            }
            throw new InvalidOperationException($"Unsupported format '{options.Format}' request for '{GetType().Name}'");
        }
    }
}
