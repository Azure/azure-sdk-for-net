// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Xml;
using Azure.Core.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    [XmlRoot("ChildTag")]
    internal class ChildModelXml : IXmlSerializable, IXmlModelSerializable, IJsonModelSerializable, IUtf8JsonSerializable
    {
        internal ChildModelXml() { }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ChildModelXml(string value, string readonlyProperty)
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
            Serialize(writer, ModelSerializerOptions.DefaultAzureOptions, nameHint);

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
            => Serialize(writer, options, null);

        private void Serialize(XmlWriter writer, ModelSerializerOptions options, string nameHint)
        {
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

        internal static ChildModelXml DeserializeChildModelXml(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultAzureOptions;

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
            return new ChildModelXml(value, readonlyProperty);
        }

        internal static ChildModelXml DeserializeChildModelXml(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultAzureOptions;

            string childValue = default;
            string childReadOnlyProperty = default;

            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("childValue"u8))
                {
                    childValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("childReadOnlyProperty"u8))
                {
                    childReadOnlyProperty = property.Value.GetString();
                    continue;
                }
            }
            return new ChildModelXml(childValue, childReadOnlyProperty);
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            if (options.Format == ModelSerializerFormat.Json)
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeChildModelXml(doc.RootElement, options);
            }
            if (options.Format == ModelSerializerFormat.Wire)
            {
                return DeserializeChildModelXml(XElement.Load(data.ToStream()), options);
            }
            throw new InvalidOperationException($"Unsupported format '{options.Format}' request for '{GetType().Name}'");
        }

        BinaryData IModelSerializable.Serialize(ModelSerializerOptions options)
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

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("childValue"u8);
            writer.WriteStringValue(ChildValue);
            if (options.Format == ModelSerializerFormat.Json)
            {
                writer.WritePropertyName("childReadOnlyProperty"u8);
                writer.WriteStringValue(ChildReadOnlyProperty);
            }
            writer.WriteEndObject();
        }

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) =>
            Serialize(writer, options);

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeChildModelXml(doc.RootElement, options);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) =>
            Serialize(writer, ModelSerializerOptions.DefaultAzureOptions);
    }
}
