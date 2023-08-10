﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Azure.Core.Serialization;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("Tag")]
    public class ModelXmlOnly : IXmlSerializable, IModelSerializable<ModelXmlOnly>
    {
        internal ModelXmlOnly() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelXmlOnly(string key, string value, string readonlyProperty, ChildModelXmlOnly childModel)
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
        public ChildModelXmlOnly RenamedChildModelXml { get; set; }

        public static implicit operator RequestContent(ModelXmlOnly modelXml)
        {
            if (modelXml == null)
            {
                return null;
            }

            return RequestContent.Create(modelXml, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelXmlOnly(Response response)
        {
            Argument.AssertNotNull(response, nameof(response));

            return DeserializeModelXmlOnly(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
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

        public static ModelXmlOnly DeserializeModelXmlOnly(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            string key = default;
            string value = default;
            string readonlyProperty = default;
            ChildModelXmlOnly childModelXml = default;
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
                childModelXml = ChildModelXmlOnly.DeserializeChildModelXmlOnly(renamedChildModelXmlElement, options);
            }
            return new ModelXmlOnly(key, value, readonlyProperty, childModelXml);
        }

        BinaryData IModelSerializable<ModelXmlOnly>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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

        ModelXmlOnly IModelSerializable<ModelXmlOnly>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeModelXmlOnly(XElement.Load(data.ToStream()), options);
        }
    }
}
