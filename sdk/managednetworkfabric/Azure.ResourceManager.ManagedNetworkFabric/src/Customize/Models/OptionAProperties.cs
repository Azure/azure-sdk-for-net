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
    [Obsolete("This type is obsolete and will be removed in a future version. Use VpnOptionAProperties or VpnOptionAPatchProperties instead.")]
    public partial class OptionAProperties : IJsonModel<OptionAProperties>, IPersistableModel<OptionAProperties>
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="OptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use VpnOptionAProperties or VpnOptionAPatchProperties instead.")]
        public OptionAProperties()
        {
        }

        [Obsolete("This constructor is obsolete and will be removed in a future version. Use VpnOptionAProperties or VpnOptionAPatchProperties instead.")]
        internal OptionAProperties(int? mtu, int? vlanId, long? peerAsn, BfdConfiguration bfdConfiguration, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Mtu = mtu;
            VlanId = vlanId;
            PeerAsn = peerAsn;
            BfdConfiguration = bfdConfiguration;
            this.additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> BFD Configuration properties. </summary>
        public BfdConfiguration BfdConfiguration { get; set; }

        /// <summary> MTU to use for option A peering. </summary>
        public int? Mtu { get; set; }

        /// <summary> Peer ASN number.Example : 28. </summary>
        public long? PeerAsn { get; set; }

        /// <summary> Vlan Id.Example : 501. </summary>
        public int? VlanId { get; set; }

        /// <summary> Writes this <see cref="OptionAProperties"/> instance as binary data. </summary>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerManagedNetworkFabricContext.Default);
                default:
                    throw new FormatException($"The model {nameof(OptionAProperties)} does not support writing '{options.Format}' format.");
            }
        }

        /// <summary> Reads a <see cref="OptionAProperties"/> instance from binary data. </summary>
        protected virtual OptionAProperties PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeOptionAProperties(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OptionAProperties)} does not support reading '{options.Format}' format.");
            }
        }

        BinaryData IPersistableModel<OptionAProperties>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        OptionAProperties IPersistableModel<OptionAProperties>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<OptionAProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<OptionAProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes this <see cref="OptionAProperties"/> instance as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OptionAProperties)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Mtu))
            {
                writer.WritePropertyName("mtu"u8);
                writer.WriteNumberValue(Mtu.Value);
            }
            if (Optional.IsDefined(VlanId))
            {
                writer.WritePropertyName("vlanId"u8);
                writer.WriteNumberValue(VlanId.Value);
            }
            if (Optional.IsDefined(PeerAsn))
            {
                writer.WritePropertyName("peerASN"u8);
                writer.WriteNumberValue(PeerAsn.Value);
            }
            if (Optional.IsDefined(BfdConfiguration))
            {
                writer.WritePropertyName("bfdConfiguration"u8);
                writer.WriteObjectValue(BfdConfiguration, options);
            }
            if (options.Format != "W" && additionalBinaryDataProperties != null)
            {
                foreach (var item in additionalBinaryDataProperties)
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

        OptionAProperties IJsonModel<OptionAProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <summary> Reads a <see cref="OptionAProperties"/> instance from JSON. </summary>
        protected virtual OptionAProperties JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<OptionAProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OptionAProperties)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOptionAProperties(document.RootElement, options);
        }

        internal virtual VpnOptionAProperties ToVpnOptionAProperties()
            => new VpnOptionAProperties(
                primaryIPv4Prefix: default,
                primaryIPv6Prefix: default,
                secondaryIPv4Prefix: default,
                secondaryIPv6Prefix: default,
                additionalBinaryDataProperties,
                Mtu,
                VlanId.GetValueOrDefault(),
                PeerAsn.GetValueOrDefault(),
                BfdConfiguration);

        internal virtual VpnOptionAPatchProperties ToVpnOptionAPatchProperties()
            => new VpnOptionAPatchProperties(
                primaryIPv4Prefix: default,
                primaryIPv6Prefix: default,
                secondaryIPv4Prefix: default,
                secondaryIPv6Prefix: default,
                additionalBinaryDataProperties,
                Mtu,
                VlanId,
                PeerAsn,
                ToBfdPatchConfiguration(BfdConfiguration));

        internal static OptionAProperties FromGenerated(VpnOptionAProperties value)
            => value is null ? null : new OptionAProperties(
                value.Mtu,
                value.VlanId,
                value.PeerAsn,
                value.BfdConfiguration,
                additionalBinaryDataProperties: null);

        internal static OptionAProperties FromGenerated(VpnOptionAPatchProperties value)
            => value is null ? null : new OptionAProperties(
                value.Mtu,
                value.VlanId,
                value.PeerAsn,
                ToBfdConfiguration(value.BfdConfiguration),
                additionalBinaryDataProperties: null);

        internal static OptionAProperties DeserializeOptionAProperties(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? mtu = default;
            int? vlanId = default;
            long? peerAsn = default;
            BfdConfiguration bfdConfiguration = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("mtu"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mtu = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("vlanId"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vlanId = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("peerASN"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    peerAsn = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("bfdConfiguration"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bfdConfiguration = BfdConfiguration.DeserializeBfdConfiguration(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new OptionAProperties(mtu, vlanId, peerAsn, bfdConfiguration, additionalBinaryDataProperties);
        }

        internal static BfdPatchConfiguration ToBfdPatchConfiguration(BfdConfiguration value)
            => value is null ? null : new BfdPatchConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);

        internal static BfdConfiguration ToBfdConfiguration(BfdPatchConfiguration value)
            => value is null ? null : new BfdConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);
    }
}
