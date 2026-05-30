// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricInternalNetworkPatch
    {
        // Backward compatibility that adds back a previously safe flattened property.
        // This is no longer flattened because its type has more than one properties now.
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ExportRoutePolicyId
        {
            get => ExportRoutePolicy?.ExportIPv4RoutePolicyId;
            set
            {
                if (ExportRoutePolicy == null)
                    ExportRoutePolicy = new ExportRoutePolicy();
                ExportRoutePolicy.ExportIPv4RoutePolicyId = value;
            }
        }

        // Backward compatibility that adds back a previously safe flattened property.
        // This is no longer flattened because its type has more than one properties now.
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ImportRoutePolicyId
        {
            get => ImportRoutePolicy?.ImportIPv4RoutePolicyId;
            set
            {
                if (ImportRoutePolicy == null)
                    ImportRoutePolicy = new ImportRoutePolicy();
                ImportRoutePolicy.ImportIPv4RoutePolicyId = value;
            }
        }

        /// <summary> List of Connected IPv4 Subnets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ConnectedIPv4SubnetSettings instead.")]
        public IList<ConnectedSubnet> ConnectedIPv4Subnets
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new InternalNetworkPatchProperties();
                }
                return new ConnectedSubnetList(Properties.ConnectedIPv4SubnetSettings);
            }
        }

        /// <summary> List of connected IPv6 Subnets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ConnectedIPv6SubnetSettings instead.")]
        public IList<ConnectedSubnet> ConnectedIPv6Subnets
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new InternalNetworkPatchProperties();
                }
                return new ConnectedSubnetList(Properties.ConnectedIPv6SubnetSettings);
            }
        }

        /// <summary> BGP configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use BgpSettings instead.")]
        public BgpConfiguration BgpConfiguration
        {
            get => ToBgpConfiguration(BgpSettings);
            set => BgpSettings = ToBgpPatchConfiguration(value);
        }

        /// <summary> Static Route Configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use StaticRouteSettings instead.")]
        public StaticRouteConfiguration StaticRouteConfiguration
        {
            get => ToStaticRouteConfiguration(StaticRouteSettings);
            set => StaticRouteSettings = ToStaticRoutePatchConfiguration(value);
        }

        private static BgpPatchConfiguration ToBgpPatchConfiguration(BgpConfiguration value)
            => value is null ? null : new BgpPatchConfiguration(
                value.Annotation,
                additionalBinaryDataProperties: null,
                ToBfdPatchConfiguration(value.BfdConfiguration),
                value.DefaultRouteOriginate,
                value.AllowAS,
                value.AllowASOverride,
                value.FabricAsn,
                value.PeerAsn,
                value.IPv4ListenRangePrefixes,
                value.IPv6ListenRangePrefixes,
                value.IPv4NeighborAddress.Select(ToNeighborAddressPatch).ToList(),
                value.IPv6NeighborAddress.Select(ToNeighborAddressPatch).ToList(),
                ToInternalNetworkBmpPatchProperties(value.BmpConfiguration),
                value.V4OverV6BgpSession,
                value.V6OverV4BgpSession);

        private static BgpConfiguration ToBgpConfiguration(BgpPatchConfiguration value)
            => value is null ? null : new BgpConfiguration(
                value.Annotation,
                additionalBinaryDataProperties: null,
                ToBfdConfiguration(value.BfdConfiguration),
                value.DefaultRouteOriginate,
                value.AllowAS,
                value.AllowASOverride,
                value.FabricAsn,
                value.PeerAsn,
                value.Ipv4ListenRangePrefixes,
                value.Ipv6ListenRangePrefixes,
                value.Ipv4NeighborAddress.Select(ToNeighborAddress).ToList(),
                value.Ipv6NeighborAddress.Select(ToNeighborAddress).ToList(),
                ToInternalNetworkBmpProperties(value.BmpConfiguration),
                value.V4OverV6BgpSession,
                value.V6OverV4BgpSession);

        private static StaticRoutePatchConfiguration ToStaticRoutePatchConfiguration(StaticRouteConfiguration value)
            => value is null ? null : new StaticRoutePatchConfiguration(
                ToBfdPatchConfiguration(value.BfdConfiguration),
                value.IPv4Routes.Select(ToStaticRoutePatchProperties).ToList(),
                value.IPv6Routes.Select(ToStaticRoutePatchProperties).ToList(),
                additionalBinaryDataProperties: null);

        private static StaticRouteConfiguration ToStaticRouteConfiguration(StaticRoutePatchConfiguration value)
            => value is null ? null : new StaticRouteConfiguration(
                ToBfdConfiguration(value.BfdConfiguration),
                value.IPv4Routes.Select(ToStaticRouteProperties).ToList(),
                value.IPv6Routes.Select(ToStaticRouteProperties).ToList(),
                extension: default,
                additionalBinaryDataProperties: null);

        private static BfdPatchConfiguration ToBfdPatchConfiguration(BfdConfiguration value)
            => value is null ? null : new BfdPatchConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);

        private static BfdConfiguration ToBfdConfiguration(BfdPatchConfiguration value)
            => value is null ? null : new BfdConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);

        private static NeighborAddressPatch ToNeighborAddressPatch(NeighborAddress value)
            => value is null ? null : new NeighborAddressPatch(value.Address, value.BfdAdministrativeState, value.BgpAdministrativeState, value.ConfigurationState, additionalBinaryDataProperties: null);

        private static NeighborAddress ToNeighborAddress(NeighborAddressPatch value)
            => value is null ? null : new NeighborAddress(value.Address, value.BfdAdministrativeState, value.BgpAdministrativeState, value.ConfigurationState, additionalBinaryDataProperties: null);

        private static InternalNetworkBmpPatchProperties ToInternalNetworkBmpPatchProperties(InternalNetworkBmpProperties value)
            => value is null ? null : new InternalNetworkBmpPatchProperties(value.NeighborIPExclusions, value.BmpConfigurationState, additionalBinaryDataProperties: null);

        private static InternalNetworkBmpProperties ToInternalNetworkBmpProperties(InternalNetworkBmpPatchProperties value)
            => value is null ? null : new InternalNetworkBmpProperties(value.NeighborIPExclusions, value.BmpConfigurationState, exportPolicyConfiguration: null, additionalBinaryDataProperties: null);

        private static StaticRoutePatchProperties ToStaticRoutePatchProperties(StaticRouteProperties value)
            => value is null ? null : new StaticRoutePatchProperties(value.Prefix, value.NextHop, additionalBinaryDataProperties: null);

        private static StaticRouteProperties ToStaticRouteProperties(StaticRoutePatchProperties value)
            => value is null ? null : new StaticRouteProperties(value.Prefix, value.NextHop, additionalBinaryDataProperties: null);

        private sealed class ConnectedSubnetList : IList<ConnectedSubnet>
        {
            private readonly IList<NetworkFabricConnectedSubnetPatch> _inner;

            public ConnectedSubnetList(IList<NetworkFabricConnectedSubnetPatch> inner)
            {
                _inner = inner;
            }

            public ConnectedSubnet this[int index]
            {
                get => ToConnectedSubnet(_inner[index]);
                set => _inner[index] = ToConnectedSubnetPatch(value);
            }

            public int Count => _inner.Count;

            public bool IsReadOnly => _inner.IsReadOnly;

            public void Add(ConnectedSubnet item) => _inner.Add(ToConnectedSubnetPatch(item));

            public void Clear() => _inner.Clear();

            public bool Contains(ConnectedSubnet item) => _inner.Contains(ToConnectedSubnetPatch(item));

            public void CopyTo(ConnectedSubnet[] array, int arrayIndex)
            {
                for (int i = 0; i < _inner.Count; i++)
                {
                    array[arrayIndex + i] = ToConnectedSubnet(_inner[i]);
                }
            }

            public IEnumerator<ConnectedSubnet> GetEnumerator()
            {
                foreach (NetworkFabricConnectedSubnetPatch item in _inner)
                {
                    yield return ToConnectedSubnet(item);
                }
            }

            public int IndexOf(ConnectedSubnet item) => _inner.IndexOf(ToConnectedSubnetPatch(item));

            public void Insert(int index, ConnectedSubnet item) => _inner.Insert(index, ToConnectedSubnetPatch(item));

            public bool Remove(ConnectedSubnet item) => _inner.Remove(ToConnectedSubnetPatch(item));

            public void RemoveAt(int index) => _inner.RemoveAt(index);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private static ConnectedSubnet ToConnectedSubnet(NetworkFabricConnectedSubnetPatch value)
                => value is null ? null : new ConnectedSubnet(value.Annotation, additionalBinaryDataProperties: null, value.Prefix);

            private static NetworkFabricConnectedSubnetPatch ToConnectedSubnetPatch(ConnectedSubnet value)
                => value is null ? null : new NetworkFabricConnectedSubnetPatch(value.Annotation, additionalBinaryDataProperties: null, value.Prefix);
        }
    }
}
