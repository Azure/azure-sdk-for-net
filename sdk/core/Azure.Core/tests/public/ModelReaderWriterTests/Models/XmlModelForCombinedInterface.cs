// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Azure.Core.Tests.Public.ModelReaderWriterTests.Models
{
    [XmlRoot("Tag")]
    internal class XmlModelForCombinedInterface : IXmlSerializable, IPersistableModel<XmlModelForCombinedInterface>, IJsonModel<XmlModelForCombinedInterface>, IUtf8JsonSerializable
    {
        public XmlModelForCombinedInterface() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public XmlModelForCombinedInterface(string key, string value, string readOnlyProperty)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readOnlyProperty;
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) =>
            Serialize(writer, ModelReaderWriterHelper.WireOptions, nameHint);

        internal static XmlModelForCombinedInterface DeserializeXmlModelForCombinedInterface(XElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            string key = default;
            string value = default;
            string readOnlyProperty = default;
            if (element.Element("Key") is XElement keyElement)
            {
                key = (string)keyElement;
            }
            if (element.Element("Value") is XElement valueElement)
            {
                value = (string)valueElement;
            }
            if (element.Element("ReadOnlyProperty") is XElement readOnlyPropertyElement)
            {
                readOnlyProperty = (string)readOnlyPropertyElement;
            }
            return new XmlModelForCombinedInterface(key, value, readOnlyProperty);
        }

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
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<XmlModelForCombinedInterface>.Write(ModelReaderWriterOptions options)
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

        internal static XmlModelForCombinedInterface DeserializeXmlModelForCombinedInterface(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

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
            return new XmlModelForCombinedInterface(key, value, readOnlyProperty);
        }

        XmlModelForCombinedInterface IPersistableModel<XmlModelForCombinedInterface>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format == "J")
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeXmlModelForCombinedInterface(doc.RootElement, options);
            }
            else
            {
                return DeserializeXmlModelForCombinedInterface(XElement.Load(data.ToStream()), options);
            }
        }

        void IJsonModel<XmlModelForCombinedInterface>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format != "J")
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<XmlModelForCombinedInterface>)} interface");

            Serialize(writer, options);
        }

        XmlModelForCombinedInterface IJsonModel<XmlModelForCombinedInterface>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            if (options.Format != "J")
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<XmlModelForCombinedInterface>)} interface");

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeXmlModelForCombinedInterface(doc.RootElement, options);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) =>
            Serialize(writer, ModelReaderWriterHelper.WireOptions);

        string IPersistableModel<XmlModelForCombinedInterface>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
