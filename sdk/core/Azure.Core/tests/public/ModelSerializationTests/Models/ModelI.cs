// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Xml;
using Azure.Core.Serialization;
using NUnit.Framework;
using System.Xml.Serialization;
using System.IO;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    internal class ModelI : IXmlSerializable, IModelSerializable
    {
        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelI(string key, string value)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
        }

        /// <summary> Gets or sets the key. </summary>
        [XmlElement("Key")]
        public string Key { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("Value")]
        public string Value { get; set; }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => ((IModelSerializable)this).Serialize(writer, new ModelSerializerOptions() {NameHint = nameHint});

        internal static ModelXml DeserializeModelXml(XElement element, ModelSerializerOptions options = default)
        {
            string key = default;
            string value = default;
            if (element.Element("Key") is XElement keyElement)
            {
                key = (string)keyElement;
            }
            if (element.Element("Value") is XElement valueElement)
            {
                value = (string)valueElement;
            }
            return new ModelXml(key, value);
        }

        internal static void VerifyModelXml(ModelXml correctModelXml, ModelXml model2)
        {
            Assert.AreEqual(correctModelXml.Key, model2.Key);
            Assert.AreEqual(correctModelXml.Value, model2.Value);
        }

        Stream IModelSerializable.Serialize(ModelSerializerOptions options)
        {
            Stream s = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(s);
            SerializeWithWriter(writer, options);
            //s.Position = 0;
            return s;
        }

        private void SerializeWithWriter(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement(options.NameHint ?? "Tag");
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
