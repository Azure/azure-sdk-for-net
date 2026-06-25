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
    // BgpConfiguration directly; keep the shipped derived type hidden for compatibility.
    /// <summary> BGP configuration properties. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future version. Use BgpConfiguration instead.")]
    public partial class InternalNetworkBgpConfiguration : BgpConfiguration, IJsonModel<InternalNetworkBgpConfiguration>, IPersistableModel<InternalNetworkBgpConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="InternalNetworkBgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternalNetworkBgpConfiguration() : this(default(long?))
        {
        }

        /// <summary> Initializes a new instance of <see cref="InternalNetworkBgpConfiguration"/>. </summary>
        /// <param name="peerAsn"> Peer ASN. Example: 65047. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternalNetworkBgpConfiguration(long? peerAsn) : base(peerAsn)
        {
        }

        internal InternalNetworkBgpConfiguration(string annotation, IDictionary<string, BinaryData> additionalBinaryDataProperties, BfdConfiguration bfdConfiguration, NetworkFabricBooleanValue? defaultRouteOriginate, int? allowAS, AllowASOverride? allowASOverride, long? fabricAsn, long? peerAsn, IList<string> iPv4ListenRangePrefixes, IList<string> iPv6ListenRangePrefixes, IList<NeighborAddress> iPv4NeighborAddress, IList<NeighborAddress> iPv6NeighborAddress, InternalNetworkBmpProperties bmpConfiguration, NetworkFabricV4OverV6BgpSessionState? v4OverV6BgpSession, NetworkFabricV6OverV4BgpSessionState? v6OverV4BgpSession) : base(annotation, additionalBinaryDataProperties, bfdConfiguration, defaultRouteOriginate, allowAS, allowASOverride, fabricAsn, peerAsn, iPv4ListenRangePrefixes, iPv6ListenRangePrefixes, iPv4NeighborAddress, iPv6NeighborAddress, bmpConfiguration, v4OverV6BgpSession, v6OverV4BgpSession)
        {
        }

        void IJsonModel<InternalNetworkBgpConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<BgpConfiguration>)this).Write(writer, options);

        InternalNetworkBgpConfiguration IJsonModel<InternalNetworkBgpConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromBgpConfiguration(((IJsonModel<BgpConfiguration>)this).Create(ref reader, options));

        BinaryData IPersistableModel<InternalNetworkBgpConfiguration>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<BgpConfiguration>)this).Write(options);

        InternalNetworkBgpConfiguration IPersistableModel<InternalNetworkBgpConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBgpConfiguration(((IPersistableModel<BgpConfiguration>)this).Create(data, options));

        string IPersistableModel<InternalNetworkBgpConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<BgpConfiguration>)this).GetFormatFromOptions(options);

        internal static InternalNetworkBgpConfiguration FromBgpConfiguration(BgpConfiguration value)
            => value is null ? null : new InternalNetworkBgpConfiguration(
                value.Annotation,
                additionalBinaryDataProperties: null,
                value.BfdConfiguration,
                value.DefaultRouteOriginate,
                value.AllowAS,
                value.AllowASOverride,
                value.FabricAsn,
                value.PeerAsn,
                value.IPv4ListenRangePrefixes,
                value.IPv6ListenRangePrefixes,
                value.IPv4NeighborAddress,
                value.IPv6NeighborAddress,
                value.BmpConfiguration,
                value.V4OverV6BgpSession,
                value.V6OverV4BgpSession);
    }
}
