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
    // Backward compatibility shim for the TypeSpec migration. The service model now uses
    // OptionBLayer3Configuration directly; keep the shipped derived type hidden for compatibility.
    /// <summary> Common properties for Layer3Configuration. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use OptionBLayer3Configuration instead.")]
    public partial class NetworkToNetworkInterconnectOptionBLayer3Configuration : OptionBLayer3Configuration, IJsonModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>, IPersistableModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkToNetworkInterconnectOptionBLayer3Configuration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkToNetworkInterconnectOptionBLayer3Configuration() : this(default(long?), default(int?))
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkToNetworkInterconnectOptionBLayer3Configuration"/>. </summary>
        /// <param name="peerAsn"> ASN of PE devices for CE/PE connectivity.Example : 28. </param>
        /// <param name="vlanId"> VLAN for CE/PE Layer 3 connectivity.Example : 501. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkToNetworkInterconnectOptionBLayer3Configuration(long? peerAsn, int? vlanId) : base(peerAsn, vlanId)
        {
        }

        internal NetworkToNetworkInterconnectOptionBLayer3Configuration(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, IDictionary<string, BinaryData> additionalBinaryDataProperties, long? peerAsn, int? vlanId, long? fabricAsn, IList<string> peLoopbackIPAddress, NniBmpProperties bmpConfiguration, IList<OptionBLayer3PrefixLimitProperties> prefixLimits)
            : base(primaryIPv4Prefix, primaryIPv6Prefix, secondaryIPv4Prefix, secondaryIPv6Prefix, additionalBinaryDataProperties, peerAsn, vlanId, fabricAsn, peLoopbackIPAddress, bmpConfiguration, prefixLimits)
        {
        }

        void IJsonModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<OptionBLayer3Configuration>)this).Write(writer, options);

        NetworkToNetworkInterconnectOptionBLayer3Configuration IJsonModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromOptionBLayer3Configuration(((IJsonModel<OptionBLayer3Configuration>)this).Create(ref reader, options));

        BinaryData IPersistableModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<OptionBLayer3Configuration>)this).Write(options);

        NetworkToNetworkInterconnectOptionBLayer3Configuration IPersistableModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromOptionBLayer3Configuration(((IPersistableModel<OptionBLayer3Configuration>)this).Create(data, options));

        string IPersistableModel<NetworkToNetworkInterconnectOptionBLayer3Configuration>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<OptionBLayer3Configuration>)this).GetFormatFromOptions(options);

        internal static NetworkToNetworkInterconnectOptionBLayer3Configuration FromOptionBLayer3Configuration(OptionBLayer3Configuration value)
            => value is null ? null : new NetworkToNetworkInterconnectOptionBLayer3Configuration(
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                value.PeerAsn,
                value.VlanId,
                value.FabricAsn,
                value.PeLoopbackIPAddress,
                value.BmpConfiguration,
                value.PrefixLimits);
    }
}
