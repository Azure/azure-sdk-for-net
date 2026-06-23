// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicy.ExportIPv4RoutePolicyId instead.")]
        public ResourceIdentifier ExportRoutePolicyId
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicy.ExportIPv4RoutePolicyId instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicy.ExportIPv4RoutePolicyId instead.");
        }

        // Backward compatibility that adds back a previously safe flattened property.
        // This is no longer flattened because its type has more than one properties now.
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicy.ImportIPv4RoutePolicyId instead.")]
        public ResourceIdentifier ImportRoutePolicyId
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicy.ImportIPv4RoutePolicyId instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicy.ImportIPv4RoutePolicyId instead.");
        }

        /// <summary> List of Connected IPv4 Subnets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ConnectedIPv4SubnetSettings instead.")]
        public IList<ConnectedSubnet> ConnectedIPv4Subnets
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ConnectedIPv4SubnetSettings instead.");
        }

        /// <summary> List of connected IPv6 Subnets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ConnectedIPv6SubnetSettings instead.")]
        public IList<ConnectedSubnet> ConnectedIPv6Subnets
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ConnectedIPv6SubnetSettings instead.");
        }

        /// <summary> BGP configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use BgpSettings instead.")]
        public BgpConfiguration BgpConfiguration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use BgpSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use BgpSettings instead.");
        }

        /// <summary> Static Route Configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use StaticRouteSettings instead.")]
        public StaticRouteConfiguration StaticRouteConfiguration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use StaticRouteSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use StaticRouteSettings instead.");
        }
    }
}
