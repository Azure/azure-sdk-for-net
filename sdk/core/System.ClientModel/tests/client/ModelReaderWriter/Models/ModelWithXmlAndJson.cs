// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ClientModel.Tests.ClientShared;
using ClientModel.Tests.Collections;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    [XmlRoot("Tag")]
    public class ModelWithXmlAndJson : IPersistableModel<ModelWithXmlAndJson>, IJsonModel<ModelWithXmlAndJson>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;
        internal ModelWithXmlAndJson()
        {
            _additionalBinaryDataProperties = new Dictionary<string, BinaryData>();
        }

        internal ModelWithXmlAndJson(string? key, string? value, string? readonlyProperty, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readonlyProperty;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Initializes a new instance of ModelXml for testing. </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public ModelWithXmlAndJson(string? key, string? value, string? readonlyProperty)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            Key = key;
            Value = value;
            ReadOnlyProperty = readonlyProperty;
            _additionalBinaryDataProperties = new Dictionary<string, BinaryData>();
        }

        /// <summary> Gets or sets the key. </summary>
        [XmlElement("Key")]
        public string? Key { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("Value")]
        public string? Value { get; set; }
        /// <summary> Gets or sets the value. </summary>
        [XmlElement("ReadOnlyProperty")]
        public string? ReadOnlyProperty { get; }

        void IJsonModel<ModelWithXmlAndJson>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelWithXmlAndJson>)this).GetFormatFromOptions(options) : options.Format;
            ModelReaderWriterHelper.ValidateFormat(this, format);

            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("value"u8);
            writer.WriteStringValue(Value);
            writer.WritePropertyName("readOnlyProperty"u8);
            writer.WriteStringValue(ReadOnlyProperty);
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ModelWithXmlAndJson IJsonModel<ModelWithXmlAndJson>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        protected virtual ModelWithXmlAndJson JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelWithXmlAndJson>)this).GetFormatFromOptions(options) : options.Format;
            ModelReaderWriterHelper.ValidateFormat(this, format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelXmlJson(document.RootElement, options);
        }

        BinaryData IPersistableModel<ModelWithXmlAndJson>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelWithXmlAndJson>)this).GetFormatFromOptions(options) : options.Format;
            ModelReaderWriterHelper.ValidateFormat(this, format);

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "X":
                    {
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
                default:
                    throw new FormatException($"The model {nameof(ModelWithXmlAndJson)} does not support writing '{options.Format}' format.");
            }
        }

        ModelWithXmlAndJson IPersistableModel<ModelWithXmlAndJson>.Create(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        protected virtual ModelWithXmlAndJson PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ModelWithXmlAndJson>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeModelXmlJson(document.RootElement, options);
                    }
                case "X":
                    return DeserializeModelXmlJson(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(ModelWithXmlAndJson)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithXmlAndJson>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";

        private void Serialize(XmlWriter writer, ModelReaderWriterOptions options, string? nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Tag");
            writer.WriteStartElement("Key");
            writer.WriteValue(Key);
            writer.WriteEndElement();
            writer.WriteStartElement("Value");
            writer.WriteValue(Value);
            writer.WriteEndElement();
            writer.WriteStartElement("ReadOnlyProperty");
            writer.WriteValue(ReadOnlyProperty);
            writer.WriteEndElement();
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WriteStartElement(item.Key);
                    writer.WriteValue(item.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        internal static ModelWithXmlAndJson DeserializeModelXmlJson(XElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            string? key = default;
            string? value = default;
            string? readonlyProperty = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new Dictionary<string, BinaryData>();

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

            return new ModelWithXmlAndJson(key, value, readonlyProperty, additionalBinaryDataProperties);
        }

        internal static ModelWithXmlAndJson DeserializeModelXmlJson(JsonElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            string? key = default;
            string? value = default;
            string? readOnlyProperty = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new Dictionary<string, BinaryData>();
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
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ModelWithXmlAndJson(key, value, readOnlyProperty, additionalBinaryDataProperties);
        }
    }
}
