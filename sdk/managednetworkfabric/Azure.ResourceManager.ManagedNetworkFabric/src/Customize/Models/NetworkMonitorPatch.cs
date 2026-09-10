// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The Network Monitor Patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkMonitorPatchContent instead.")]
    public partial class NetworkMonitorPatch : TagsUpdate, IJsonModel<NetworkMonitorPatch>, IPersistableModel<NetworkMonitorPatch>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkMonitorPatch"/>. </summary>
        public NetworkMonitorPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkMonitorPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Monitor Patch properties. </param>
        internal NetworkMonitorPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkMonitorPatchProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> Network Monitor Patch properties. </summary>
        internal NetworkMonitorPatchProperties Properties { get; set; }

        /// <summary> BGP Monitoring Protocol (BMP) Configurations for the Network Monitor. </summary>
        public BmpConfigurationPatchProperties BmpConfiguration
        {
            get => Properties is null ? default : Properties.BmpConfiguration;
            set
            {
                Properties ??= new NetworkMonitorPatchProperties();
                Properties.BmpConfiguration = value;
            }
        }

        internal NetworkMonitorPatchContent ToContent()
            => new NetworkMonitorPatchContent(Tags, _additionalBinaryDataProperties, Properties);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ManagedNetworkFabricResourcePatch PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkMonitorPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkMonitorPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkMonitorPatch)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkMonitorPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkMonitorPatch)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<NetworkMonitorPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkMonitorPatch IPersistableModel<NetworkMonitorPatch>.Create(BinaryData data, ModelReaderWriterOptions options) => (NetworkMonitorPatch)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<NetworkMonitorPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="networkMonitorPatch"> The <see cref="NetworkMonitorPatch"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(NetworkMonitorPatch networkMonitorPatch)
        {
            if (networkMonitorPatch == null)
            {
                return null;
            }
            return RequestContent.Create(networkMonitorPatch, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<NetworkMonitorPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkMonitorPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkMonitorPatch)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        NetworkMonitorPatch IJsonModel<NetworkMonitorPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (NetworkMonitorPatch)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override ManagedNetworkFabricResourcePatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkMonitorPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkMonitorPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkMonitorPatch(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static NetworkMonitorPatch DeserializeNetworkMonitorPatch(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IDictionary<string, string> tags = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            NetworkMonitorPatchProperties properties = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("tags"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        dictionary.Add(prop0.Name, prop0.Value.ValueKind == JsonValueKind.Null ? null : prop0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = NetworkMonitorPatchProperties.DeserializeNetworkMonitorPatchProperties(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new NetworkMonitorPatch(tags ?? new ChangeTrackingDictionary<string, string>(), additionalBinaryDataProperties, properties);
        }
    }
}
