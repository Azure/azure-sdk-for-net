// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricInternalNetworkData
    {
        // Backward compatibility shim for the TypeSpec migration. The current generated property
        // is BgpSettings and uses the shared BgpConfiguration model directly.
        /// <summary> BGP configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use BgpSettings instead.")]
        public InternalNetworkBgpConfiguration BgpConfiguration
        {
            get => InternalNetworkBgpConfiguration.FromBgpConfiguration(BgpSettings);
            set => BgpSettings = value;
        }

        // Backward compatibility shim for the TypeSpec migration. The current generated property
        // is StaticRouteSettings and uses the shared StaticRouteConfiguration model directly.
        /// <summary> Static Route Configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use StaticRouteSettings instead.")]
        public InternalNetworkStaticRouteConfiguration StaticRouteConfiguration
        {
            get => InternalNetworkStaticRouteConfiguration.FromStaticRouteConfiguration(StaticRouteSettings);
            set => StaticRouteSettings = value;
        }

        // Backward compatibility that adds back a previously safe flattened property.
        // This is no longer flattened because its type has more than one properties now.
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicy.ExportIPv4RoutePolicyId instead.")]
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
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicy.ImportIPv4RoutePolicyId instead.")]
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
    }
}
