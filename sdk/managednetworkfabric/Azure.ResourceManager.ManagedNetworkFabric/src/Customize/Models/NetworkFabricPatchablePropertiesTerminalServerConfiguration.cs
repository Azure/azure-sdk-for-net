// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.ManagedNetworkFabric;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Network and credentials configuration already applied to terminal server. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerPatchConfiguration instead.")]
    public partial class NetworkFabricPatchablePropertiesTerminalServerConfiguration : TerminalServerPatchableProperties, IJsonModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>, IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricPatchablePropertiesTerminalServerConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerPatchConfiguration instead.")]
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration()
        {
        }

        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerPatchConfiguration instead.")]
        internal NetworkFabricPatchablePropertiesTerminalServerConfiguration(string username, string password, string serialNumber, IDictionary<string, BinaryData> additionalBinaryDataProperties, string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix)
            : base(username, password, serialNumber, additionalBinaryDataProperties)
        {
            PrimaryIPv4Prefix = primaryIPv4Prefix;
            PrimaryIPv6Prefix = primaryIPv6Prefix;
            SecondaryIPv4Prefix = secondaryIPv4Prefix;
            SecondaryIPv6Prefix = secondaryIPv6Prefix;
        }

        /// <summary> IPv4 Address Prefix. </summary>
        public string PrimaryIPv4Prefix { get; set; }

        /// <summary> IPv6 Address Prefix. </summary>
        public string PrimaryIPv6Prefix { get; set; }

        /// <summary> Secondary IPv4 Address Prefix. </summary>
        public string SecondaryIPv4Prefix { get; set; }

        /// <summary> Secondary IPv6 Address Prefix. </summary>
        public string SecondaryIPv6Prefix { get; set; }

        void IJsonModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        NetworkFabricPatchablePropertiesTerminalServerConfiguration IJsonModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (NetworkFabricPatchablePropertiesTerminalServerConfiguration)JsonModelCreateCore(ref reader, options);

        BinaryData IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        NetworkFabricPatchablePropertiesTerminalServerConfiguration IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (NetworkFabricPatchablePropertiesTerminalServerConfiguration)PersistableModelCreateCore(data, options);

        string IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Writes this <see cref="NetworkFabricPatchablePropertiesTerminalServerConfiguration"/> instance as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricPatchablePropertiesTerminalServerConfiguration)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(PrimaryIPv4Prefix))
            {
                writer.WritePropertyName("primaryIpv4Prefix"u8);
                writer.WriteStringValue(PrimaryIPv4Prefix);
            }
            if (Optional.IsDefined(PrimaryIPv6Prefix))
            {
                writer.WritePropertyName("primaryIpv6Prefix"u8);
                writer.WriteStringValue(PrimaryIPv6Prefix);
            }
            if (Optional.IsDefined(SecondaryIPv4Prefix))
            {
                writer.WritePropertyName("secondaryIpv4Prefix"u8);
                writer.WriteStringValue(SecondaryIPv4Prefix);
            }
            if (Optional.IsDefined(SecondaryIPv6Prefix))
            {
                writer.WritePropertyName("secondaryIpv6Prefix"u8);
                writer.WriteStringValue(SecondaryIPv6Prefix);
            }
        }

        /// <summary> Reads a <see cref="NetworkFabricPatchablePropertiesTerminalServerConfiguration"/> instance from JSON. </summary>
        protected override TerminalServerPatchableProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(NetworkFabricPatchablePropertiesTerminalServerConfiguration)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNetworkFabricPatchablePropertiesTerminalServerConfiguration(document.RootElement, options);
        }

        /// <summary> Reads a <see cref="NetworkFabricPatchablePropertiesTerminalServerConfiguration"/> instance from binary data. </summary>
        protected override TerminalServerPatchableProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeNetworkFabricPatchablePropertiesTerminalServerConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricPatchablePropertiesTerminalServerConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Writes this <see cref="NetworkFabricPatchablePropertiesTerminalServerConfiguration"/> instance as binary data. </summary>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<NetworkFabricPatchablePropertiesTerminalServerConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(NetworkFabricPatchablePropertiesTerminalServerConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        internal NetworkFabricTerminalServerPatchConfiguration ToNetworkFabricTerminalServerPatchConfiguration()
            => new NetworkFabricTerminalServerPatchConfiguration(
                Username,
                Password,
                SerialNumber,
                PrimaryIPv4Prefix,
                PrimaryIPv6Prefix,
                SecondaryIPv4Prefix,
                SecondaryIPv6Prefix,
                additionalBinaryDataProperties: null);

        internal static NetworkFabricPatchablePropertiesTerminalServerConfiguration FromNetworkFabricTerminalServerPatchConfiguration(NetworkFabricTerminalServerPatchConfiguration value)
            => value is null ? null : new NetworkFabricPatchablePropertiesTerminalServerConfiguration(
                value.Username,
                value.Password,
                value.SerialNumber,
                additionalBinaryDataProperties: null,
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix);

        internal static NetworkFabricPatchablePropertiesTerminalServerConfiguration DeserializeNetworkFabricPatchablePropertiesTerminalServerConfiguration(JsonElement element, ModelReaderWriterOptions options)
            => FromNetworkFabricTerminalServerPatchConfiguration(NetworkFabricTerminalServerPatchConfiguration.DeserializeNetworkFabricTerminalServerPatchConfiguration(element, options));
    }
}
