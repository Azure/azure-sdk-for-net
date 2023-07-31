// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    public class ModelXml : IXmlSerializable, IModelXmlSerializable<ModelXml>
    {
        internal ModelXml() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelXml(string key, string value, string readonlyProperty, ChildModelXml childModel)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readonlyProperty;
            RenamedChildModelXml = childModel;
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
        [XmlElement("RenamedChildModelXml")]
        public ChildModelXml RenamedChildModelXml { get; set; }

        public static implicit operator RequestContent(ModelXml modelXml)
        {
            return new Utf8XmlDelayedRequestContent(modelXml, new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        public static explicit operator ModelXml(Response response)
        {
            return DeserializeModelXml(XElement.Load(response.ContentStream), new ModelSerializerOptions(ModelSerializerFormat.Wire));
        }

        public void Serialize(XmlWriter writer, string nameHint) => Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire), nameHint);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire), nameHint);

        void IModelXmlSerializable<ModelXml>.Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            if (options.Format != ModelSerializerFormat.Wire)
                throw new InvalidOperationException($"Must use '{ModelSerializerFormat.Wire}' format when calling the {nameof(IModelXmlSerializable<ModelXml>)} interface");

            Serialize(writer, options, null);
        }

        private void Serialize(XmlWriter writer, ModelSerializerOptions options, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Tag");
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
            writer.WriteObjectValue(RenamedChildModelXml, "RenamedChildModelXml");
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
            writer.WritePropertyName("renamedChildModelXml"u8);
            writer.WriteObjectValue(RenamedChildModelXml);
            writer.WriteEndObject();
        }

        public static ModelXml DeserializeModelXml(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            string key = default;
            string value = default;
            string readonlyProperty = default;
            ChildModelXml childModelXml = default;
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
            if (element.Element("RenamedChildModelXml") is XElement renamedChildModelXmlElement)
            {
                childModelXml = ChildModelXml.DeserializeChildModelXml(renamedChildModelXmlElement, options);
            }
            return new ModelXml(key, value, readonlyProperty, childModelXml);
        }

        BinaryData IModelSerializable<ModelXml>.Serialize(ModelSerializerOptions options)
        {
            if (options.Format == ModelSerializerFormat.Json)
            {
                return ModelSerializerHelper.SerializeToBinaryData((writer) => { Serialize(writer, options); });
            }
            if (options.Format == ModelSerializerFormat.Wire)
            {
                return ModelSerializerHelper.SerializeToBinaryData((writer) => { Serialize(writer, options, null); });
            }
            throw new InvalidOperationException($"Unsupported format '{options.Format}' request for '{GetType().Name}'");
        }

        internal static ModelXml DeserializeModelXml(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultServiceOptions;

            string key = default;
            string value = default;
            string readOnlyProperty = default;
            ChildModelXml childModelXml = default;

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
                if (property.NameEquals("renamedChildModelXml"u8))
                {
                    childModelXml = ChildModelXml.DeserializeChildModelXml(property.Value, options);
                    continue;
                }
            }
            return new ModelXml(key, value, readOnlyProperty, childModelXml);
        }

        ModelXml IModelSerializable<ModelXml>.Deserialize(BinaryData data, ModelSerializerOptions options)
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

        ModelXml IModelXmlSerializable<ModelXml>.Deserialize(XElement root, ModelSerializerOptions options) => DeserializeModelXml(root, options);
    }
}
