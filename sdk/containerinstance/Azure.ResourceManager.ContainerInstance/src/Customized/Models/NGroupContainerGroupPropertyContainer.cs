// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Container which can be set while creating or updating the NGroups. </summary>
    public partial class NGroupContainerGroupPropertyContainer : IJsonModel<NGroupContainerGroupPropertyContainer>, IPersistableModel<NGroupContainerGroupPropertyContainer>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="NGroupContainerGroupPropertyContainer"/>. </summary>
        public NGroupContainerGroupPropertyContainer()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NGroupContainerGroupPropertyContainer"/>. </summary>
        /// <param name="name"> The user-provided name of the container instance. </param>
        /// <param name="properties"> The properties of the container. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal NGroupContainerGroupPropertyContainer(string name, NGroupContainerGroupPropertyContainerProperties properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Properties = properties;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The user-provided name of the container instance. </summary>
        public string Name { get; set; }

        /// <summary> The properties of the container. </summary>
        public NGroupContainerGroupPropertyContainerProperties Properties { get; set; }

        // backward-compat shim: old property returned IList<ContainerVolumeMount>, new is on Properties.VolumeMounts
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerVolumeMount> VolumeMounts
            => Properties?.VolumeMounts;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ContainerVolumeMount> NGroupCGPropertyContainerVolumeMounts => VolumeMounts;

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NGroupContainerGroupPropertyContainer PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainer>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNGroupContainerGroupPropertyContainer(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainer)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainer>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContainerInstanceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainer)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NGroupContainerGroupPropertyContainer>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NGroupContainerGroupPropertyContainer IPersistableModel<NGroupContainerGroupPropertyContainer>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NGroupContainerGroupPropertyContainer>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NGroupContainerGroupPropertyContainer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainer)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
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

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NGroupContainerGroupPropertyContainer IJsonModel<NGroupContainerGroupPropertyContainer>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NGroupContainerGroupPropertyContainer JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainer)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNGroupContainerGroupPropertyContainer(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NGroupContainerGroupPropertyContainer DeserializeNGroupContainerGroupPropertyContainer(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            NGroupContainerGroupPropertyContainerProperties properties = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = NGroupContainerGroupPropertyContainerProperties.DeserializeNGroupContainerGroupPropertyContainerProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new NGroupContainerGroupPropertyContainer(name, properties, additionalBinaryDataProperties);
        }
    }
}
