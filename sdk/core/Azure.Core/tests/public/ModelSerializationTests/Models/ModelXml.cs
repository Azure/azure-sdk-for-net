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
    internal class ModelXml : IXmlSerializable, IXmlModelSerializable
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) =>
            Serialize(writer, ModelSerializerOptions.AzureServiceDefault, nameHint);

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
            => Serialize(writer, options, null);

        private void Serialize(XmlWriter writer, ModelSerializerOptions options, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Tag");
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            if (options.Format == ModelSerializerFormat.Data)
            {
                writer.WriteStartElement("ReadOnlyProperty");
                writer.WriteValue(ReadOnlyProperty);
                writer.WriteEndElement();
            }
            writer.WriteObjectValue(RenamedChildModelXml, "RenamedChildModelXml");
            writer.WriteEndElement();
        }

        internal static ModelXml DeserializeModelXml(XElement element, ModelSerializerOptions options = default)
        {
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

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeModelXml(XElement.Load(data.ToStream()), options);
        }
    }
}
