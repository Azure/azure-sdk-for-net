// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Automation;

namespace Azure.ResourceManager.Automation.Models
{
    /// <summary> The parameters supplied to the create or update module operation. </summary>
    public partial class AutomationAccountPython2PackageCreateOrUpdateContent : IJsonModel<AutomationAccountPython2PackageCreateOrUpdateContent>, IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="AutomationAccountPython2PackageCreateOrUpdateContent"/>. </summary>
        /// <param name="contentLink"> Gets or sets the module content link. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentLink"/> is null. </exception>
        public AutomationAccountPython2PackageCreateOrUpdateContent(AutomationContentLink contentLink)
        {
            Argument.AssertNotNull(contentLink, nameof(contentLink));

            Properties = new PythonPackageCreateProperties(contentLink);
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="AutomationAccountPython2PackageCreateOrUpdateContent"/>. </summary>
        /// <param name="properties"> Gets or sets the module create properties. </param>
        /// <param name="tags"> Gets or sets the tags attached to the resource. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal AutomationAccountPython2PackageCreateOrUpdateContent(PythonPackageCreateProperties properties, IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Properties = properties;
            Tags = tags;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Gets or sets the module create properties. </summary>
        internal PythonPackageCreateProperties Properties { get; }

        /// <summary> Gets or sets the tags attached to the resource. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary> Gets or sets the module content link. </summary>
        public AutomationContentLink ContentLink
        {
            get
            {
                return Properties.ContentLink;
            }
        }

        internal AutomationPythonPackageCreateOrUpdateContent ToAutomationPythonPackageCreateOrUpdateContent()
        {
            return new AutomationPythonPackageCreateOrUpdateContent(Properties, Tags, _additionalBinaryDataProperties);
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual AutomationAccountPython2PackageCreateOrUpdateContent PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeAutomationAccountPython2PackageCreateOrUpdateContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AutomationAccountPython2PackageCreateOrUpdateContent)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
                        {
                            ((IJsonModel<AutomationAccountPython2PackageCreateOrUpdateContent>)this).Write(writer, options);
                        }
                        return BinaryData.FromBytes(stream.ToArray());
                    }
                default:
                    throw new FormatException($"The model {nameof(AutomationAccountPython2PackageCreateOrUpdateContent)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual AutomationAccountPython2PackageCreateOrUpdateContent JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AutomationAccountPython2PackageCreateOrUpdateContent)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAutomationAccountPython2PackageCreateOrUpdateContent(document.RootElement, options);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AutomationAccountPython2PackageCreateOrUpdateContent)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteObjectValue(Properties, options);
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
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

        AutomationAccountPython2PackageCreateOrUpdateContent IJsonModel<AutomationAccountPython2PackageCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        void IJsonModel<AutomationAccountPython2PackageCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        AutomationAccountPython2PackageCreateOrUpdateContent IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<AutomationAccountPython2PackageCreateOrUpdateContent>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        internal static AutomationAccountPython2PackageCreateOrUpdateContent DeserializeAutomationAccountPython2PackageCreateOrUpdateContent(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            PythonPackageCreateProperties properties = default;
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("properties"u8))
                {
                    properties = PythonPackageCreateProperties.DeserializePythonPackageCreateProperties(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    tags = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new AutomationAccountPython2PackageCreateOrUpdateContent(properties, tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties);
        }
    }
}