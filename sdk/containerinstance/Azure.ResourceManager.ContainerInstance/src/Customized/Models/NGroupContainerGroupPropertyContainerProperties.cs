// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> The properties of a container in the NGroup. </summary>
    public partial class NGroupContainerGroupPropertyContainerProperties : IJsonModel<NGroupContainerGroupPropertyContainerProperties>, IPersistableModel<NGroupContainerGroupPropertyContainerProperties>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="NGroupContainerGroupPropertyContainerProperties"/>. </summary>
        public NGroupContainerGroupPropertyContainerProperties()
        {
            VolumeMounts = new ChangeTrackingList<ContainerVolumeMount>();
        }

        /// <summary> Initializes a new instance of <see cref="NGroupContainerGroupPropertyContainerProperties"/>. </summary>
        /// <param name="volumeMounts"> The volume mounts available to the container instance. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal NGroupContainerGroupPropertyContainerProperties(IList<ContainerVolumeMount> volumeMounts, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            VolumeMounts = volumeMounts;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The volume mounts available to the container instance. </summary>
        public IList<ContainerVolumeMount> VolumeMounts { get; }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NGroupContainerGroupPropertyContainerProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainerProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNGroupContainerGroupPropertyContainerProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainerProperties)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainerProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContainerInstanceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainerProperties)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NGroupContainerGroupPropertyContainerProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NGroupContainerGroupPropertyContainerProperties IPersistableModel<NGroupContainerGroupPropertyContainerProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NGroupContainerGroupPropertyContainerProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NGroupContainerGroupPropertyContainerProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainerProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainerProperties)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(VolumeMounts))
            {
                writer.WritePropertyName("volumeMounts"u8);
                writer.WriteStartArray();
                foreach (ContainerVolumeMount item in VolumeMounts)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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
        NGroupContainerGroupPropertyContainerProperties IJsonModel<NGroupContainerGroupPropertyContainerProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual NGroupContainerGroupPropertyContainerProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NGroupContainerGroupPropertyContainerProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NGroupContainerGroupPropertyContainerProperties)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNGroupContainerGroupPropertyContainerProperties(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NGroupContainerGroupPropertyContainerProperties DeserializeNGroupContainerGroupPropertyContainerProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<ContainerVolumeMount> volumeMounts = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("volumeMounts"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ContainerVolumeMount> array = new List<ContainerVolumeMount>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ContainerVolumeMount.DeserializeContainerVolumeMount(item, options));
                    }
                    volumeMounts = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new NGroupContainerGroupPropertyContainerProperties(volumeMounts ?? new ChangeTrackingList<ContainerVolumeMount>(), additionalBinaryDataProperties);
        }
    }
}
