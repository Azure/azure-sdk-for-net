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
    /// <summary> option A properties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use VpnOptionAProperties instead.")]
    public partial class VpnConfigurationOptionAProperties : OptionAProperties, IJsonModel<VpnConfigurationOptionAProperties>, IPersistableModel<VpnConfigurationOptionAProperties>
    {
        /// <summary> Initializes a new instance of <see cref="VpnConfigurationOptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use VpnOptionAProperties instead.")]
        public VpnConfigurationOptionAProperties()
        {
            throw new NotSupportedException("This constructor is obsolete and will be removed in a future version. Use VpnOptionAProperties instead.");
        }

        [Obsolete("This constructor is obsolete and will be removed in a future version. Use VpnOptionAProperties instead.")]
        internal VpnConfigurationOptionAProperties(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, IDictionary<string, BinaryData> additionalBinaryDataProperties, int? mtu, int? vlanId, long? peerAsn, BfdConfiguration bfdConfiguration)
            : base(mtu, vlanId, peerAsn, bfdConfiguration, additionalBinaryDataProperties)
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

        BinaryData IPersistableModel<VpnConfigurationOptionAProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        VpnConfigurationOptionAProperties IPersistableModel<VpnConfigurationOptionAProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => (VpnConfigurationOptionAProperties)PersistableModelCreateCore(data, options);

        string IPersistableModel<VpnConfigurationOptionAProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<VpnConfigurationOptionAProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        VpnConfigurationOptionAProperties IJsonModel<VpnConfigurationOptionAProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (VpnConfigurationOptionAProperties)JsonModelCreateCore(ref reader, options);

        /// <summary> Writes this <see cref="VpnConfigurationOptionAProperties"/> instance as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VpnConfigurationOptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VpnConfigurationOptionAProperties)} does not support writing '{format}' format.");
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

        /// <summary> Reads a <see cref="VpnConfigurationOptionAProperties"/> instance from JSON. </summary>
        protected override OptionAProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VpnConfigurationOptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VpnConfigurationOptionAProperties)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVpnConfigurationOptionAProperties(document.RootElement, options);
        }

        /// <summary> Reads a <see cref="VpnConfigurationOptionAProperties"/> instance from binary data. </summary>
        protected override OptionAProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VpnConfigurationOptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeVpnConfigurationOptionAProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(VpnConfigurationOptionAProperties)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Writes this <see cref="VpnConfigurationOptionAProperties"/> instance as binary data. </summary>
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VpnConfigurationOptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(VpnConfigurationOptionAProperties)} does not support writing '{options.Format}' format.");
            }
        }

        internal override VpnOptionAProperties ToVpnOptionAProperties()
            => new VpnOptionAProperties(
                PrimaryIPv4Prefix,
                PrimaryIPv6Prefix,
                SecondaryIPv4Prefix,
                SecondaryIPv6Prefix,
                additionalBinaryDataProperties,
                Mtu,
                VlanId.GetValueOrDefault(),
                PeerAsn.GetValueOrDefault(),
                BfdConfiguration);

        internal static VpnConfigurationOptionAProperties FromGeneratedOptionAProperties(VpnOptionAProperties value)
            => value is null ? null : new VpnConfigurationOptionAProperties(
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                value.Mtu,
                value.VlanId,
                value.PeerAsn,
                value.BfdConfiguration);

        internal static VpnConfigurationOptionAProperties DeserializeVpnConfigurationOptionAProperties(JsonElement element, ModelReaderWriterOptions options)
            => FromGeneratedOptionAProperties(VpnOptionAProperties.DeserializeVpnOptionAProperties(element, options));
    }
}
