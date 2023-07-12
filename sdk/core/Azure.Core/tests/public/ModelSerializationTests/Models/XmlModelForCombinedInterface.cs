// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Xml;
using Azure.Core.Serialization;
using NUnit.Framework;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    internal class XmlModelForCombinedInterface : IXmlSerializable, IXmlModelSerializable
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => ((IXmlModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureSerivceDefault);

        internal static XmlModelForCombinedInterface DeserializeXmlModelForCombinedInterface(XElement element, ModelSerializerOptions options = default)
        {
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

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            if (!options.IgnoreReadOnlyProperties)
            {
                writer.WriteStartElement("ReadOnlyProperty");
                writer.WriteValue(ReadOnlyProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options) => DeserializeXmlModelForCombinedInterface(XElement.Load(data.ToStream()), options);
    }
}
