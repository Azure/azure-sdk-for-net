// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Tests.ModelReaderWriterTests.Models;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests.Models
{
    [XmlRoot("Tag")]
    public class ModelXmlCrossLibrary : IXmlSerializable, IJsonModel<ModelXmlCrossLibrary>, IUtf8JsonSerializable
    {
        internal ModelXmlCrossLibrary() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelXmlCrossLibrary(string key, string value, string readonlyProperty, ChildModelXml childModelXml)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readonlyProperty;
            ChildModelXml = childModelXml;
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
        [XmlElement("ChildTag")]
        public ChildModelXml ChildModelXml { get; set; }

        public void Serialize(XmlWriter writer, string nameHint) => Serialize(writer, ModelReaderWriterHelper.WireOptions, nameHint);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, ModelReaderWriterHelper.WireOptions, nameHint);

        private void Serialize(XmlWriter writer, ModelReaderWriterOptions options, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Tag");
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            if (options.Format == "J")
            {
                writer.WriteStartElement("ReadOnlyProperty");
                writer.WriteValue(ReadOnlyProperty);
                writer.WriteEndElement();
            }
            var childModelXml = ModelReaderWriter.Write(ChildModelXml, options);
            var bytes = childModelXml.ToArray();
            int start = bytes.AsSpan(1).IndexOf((byte)'>') + 2;
            var chars = Encoding.UTF8.GetChars(bytes, start, bytes.Length - start);
            writer.WriteRaw(chars, 0, chars.Length);
            writer.WriteEndElement();
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            if (options.Format == "J")
            {
                writer.WritePropertyName("readOnlyProperty"u8);
                writer.WriteStringValue(ReadOnlyProperty);
            }
            writer.WritePropertyName("childTag"u8);
            ((IJsonModel<ChildModelXml>)ChildModelXml).Write(writer, options);
            writer.WriteEndObject();
        }

        public static ModelXmlCrossLibrary DeserializeModelXmlCrossLibrary(XElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

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
            if (element.Element("ChildTag") is XElement renamedChildModelXmlElement)
            {
                using MemoryStream stream = new MemoryStream();
                renamedChildModelXmlElement.Save(stream);
                BinaryData data = stream.Position > int.MaxValue
                    ? BinaryData.FromStream(stream)
                    : new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                childModelXml = ModelReaderWriter.Read<ChildModelXml>(data, options);
            }
            return new ModelXmlCrossLibrary(key, value, readonlyProperty, childModelXml);
        }

        BinaryData IPersistableModel<ModelXmlCrossLibrary>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format == "J")
            {
                return ModelReaderWriter.Write(this, options);
            }
            else
            {
                options ??= ModelReaderWriterHelper.WireOptions;
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

        internal static ModelXmlCrossLibrary DeserializeModelXmlCrossLibrary(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

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
                if (property.NameEquals("childTag"u8))
                {
                    childModelXml = ModelReaderWriter.Read<ChildModelXml>(BinaryData.FromString(property.Value.GetRawText()), options);// ChildModelXml.DeserializeChildModelXml(property.Value, options);
                    continue;
                }
            }
            return new ModelXmlCrossLibrary(key, value, readOnlyProperty, childModelXml);
        }

        ModelXmlCrossLibrary IPersistableModel<ModelXmlCrossLibrary>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format == "J")
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeModelXmlCrossLibrary(doc.RootElement, options);
            }
            else
            {
                return DeserializeModelXmlCrossLibrary(XElement.Load(data.ToStream()), options);
            }
        }

        void IJsonModel<ModelXmlCrossLibrary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format != "J")
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelXmlCrossLibrary>)} interface");
            Serialize(writer, options);
        }

        ModelXmlCrossLibrary IJsonModel<ModelXmlCrossLibrary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format != "J")
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelXmlCrossLibrary>)} interface");
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelXmlCrossLibrary(doc.RootElement, options);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => Serialize(writer, ModelReaderWriterHelper.WireOptions);

        string IPersistableModel<ModelXmlCrossLibrary>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
