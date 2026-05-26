// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the TypeSpec migration. The previous SDK exposed
    // route policy IDs directly while the generated model now uses nested route policy objects.
    // Removing these shims would drop the flat ExportRoutePolicyId/ImportRoutePolicyId patch properties.
    public partial class NetworkFabricInternalNetworkPatch
    {
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicy.ExportIpv4RoutePolicyId instead.")]
        public ResourceIdentifier ExportRoutePolicyId
        {
            get => ExportRoutePolicy?.ExportIPv4RoutePolicyId;
            set
            {
                if (ExportRoutePolicy is null)
                {
                    ExportRoutePolicy = new ExportRoutePolicy();
                }
                ExportRoutePolicy.ExportIPv4RoutePolicyId = value;
            }
        }

        /// <summary> ARM Resource ID of the RoutePolicy. This is used for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicy.ImportIpv4RoutePolicyId instead.")]
        public ResourceIdentifier ImportRoutePolicyId
        {
            get => ImportRoutePolicy?.ImportIPv4RoutePolicyId;
            set
            {
                if (ImportRoutePolicy is null)
                {
                    ImportRoutePolicy = new ImportRoutePolicy();
                }
                ImportRoutePolicy.ImportIPv4RoutePolicyId = value;
            }
        }
    }
}
