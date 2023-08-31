// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("ChildTag")]
    public class ChildModelXmlOnly : IXmlSerializable, IModelSerializable<ChildModelXmlOnly>
    {
        internal ChildModelXmlOnly() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ChildModelXmlOnly(string value, string readonlyProperty)
        {
            Argument.AssertNotNull(value, nameof(value));

            ChildValue = value;
            ChildReadOnlyProperty = readonlyProperty;
        }

        /// <summary> Gets or sets the value. </summary>
        [XmlElement("ChildValue")]
        public string ChildValue { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("ChildReadOnlyProperty")]
        public string ChildReadOnlyProperty { get; }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) =>
            Serialize(writer, ModelSerializerOptions.DefaultWireOptions, nameHint);

        private void Serialize(XmlWriter writer, ModelSerializerOptions options, string nameHint)
        {
            if (options.Format != ModelSerializerFormat.Wire)
                throw new NotSupportedException($"{nameof(ChildModelXmlOnly)} does not support '{options.Format}' format");

            writer.WriteStartElement(nameHint ?? "ChildTag");
            writer.WriteStartElement("ChildValue");
            writer.WriteValue(ChildValue);
            writer.WriteEndElement();
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WriteStartElement("ChildReadOnlyProperty");
                writer.WriteValue(ChildReadOnlyProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ChildModelXmlOnly DeserializeChildModelXmlOnly(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (options.Format != ModelSerializerFormat.Wire)
                throw new NotSupportedException($"{nameof(ChildModelXmlOnly)} does not support '{options.Format}' format");

            string value = default;
            string readonlyProperty = default;
            if (element.Element("ChildValue") is XElement valueElement)
            {
                value = (string)valueElement;
            }
            if (element.Element("ChildReadOnlyProperty") is XElement readonlyPropertyElement)
            {
                readonlyProperty = (string)readonlyPropertyElement;
            }
            return new ChildModelXmlOnly(value, readonlyProperty);
        }

        ChildModelXmlOnly IModelSerializable<ChildModelXmlOnly>.Deserialize(BinaryData data, ModelSerializerOptions options)
            => DeserializeChildModelXmlOnly(XElement.Load(data.ToStream()), options);

        BinaryData IModelSerializable<ChildModelXmlOnly>.Serialize(ModelSerializerOptions options)
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
}
