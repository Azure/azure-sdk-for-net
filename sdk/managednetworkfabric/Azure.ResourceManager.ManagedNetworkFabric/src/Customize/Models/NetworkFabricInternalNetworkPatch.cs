// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version replaced the flat ExportRoutePolicyId/ImportRoutePolicyId properties with
    // nested ExportRoutePolicy/ImportRoutePolicy objects on the patch model. These shims delegate to
    // the nested properties to preserve the v1.1.2 surface.
    public partial class NetworkFabricInternalNetworkPatch
    {
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
