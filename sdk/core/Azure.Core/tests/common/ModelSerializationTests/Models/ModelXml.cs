// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    public class ModelXml : IXmlSerializable, IModelSerializable<ModelXml>, IModelJsonSerializable<ModelXml>, IUtf8JsonSerializable
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
            if (modelXml == null)
            {
                return null;
            }

            return RequestContent.Create((IModelSerializable<ModelXml>)modelXml, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelXml(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return DeserializeModelXml(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }

        public void Serialize(XmlWriter writer, string nameHint) => Serialize(writer, ModelSerializerOptions.DefaultWireOptions, nameHint);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, ModelSerializerOptions.DefaultWireOptions, nameHint);

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
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (options.Format == ModelSerializerFormat.Json)
            {
                return ModelSerializer.SerializeCore(this, options);
            }
            else
            {
                options ??= ModelSerializerOptions.DefaultWireOptions;
                using MemoryStream stream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(stream);
                Serialize(writer, options, null);
                writer.Flush();
                if (stream.Position > int.MaxValue)
                {
                    return BinaryData.FromStream(stream);
                }
                else
                {
                    return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                }
            }
        }

        internal static ModelXml DeserializeModelXml(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

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
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (options.Format == ModelSerializerFormat.Json)
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeModelXml(doc.RootElement, options);
            }
            else
            {
                return DeserializeModelXml(XElement.Load(data.ToStream()), options);
            }
        }

        void IModelJsonSerializable<ModelXml>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (options.Format != ModelSerializerFormat.Json)
                throw new InvalidOperationException($"Must use '{ModelSerializerFormat.Json}' format when calling the {nameof(IModelJsonSerializable<ModelXml>)} interface");
            Serialize(writer, options);
        }

        ModelXml IModelJsonSerializable<ModelXml>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (options.Format != ModelSerializerFormat.Json)
                throw new InvalidOperationException($"Must use '{ModelSerializerFormat.Json}' format when calling the {nameof(IModelJsonSerializable<ModelXml>)} interface");
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelXml(doc.RootElement, options);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => Serialize(writer, ModelSerializerOptions.DefaultWireOptions);
    }
}
