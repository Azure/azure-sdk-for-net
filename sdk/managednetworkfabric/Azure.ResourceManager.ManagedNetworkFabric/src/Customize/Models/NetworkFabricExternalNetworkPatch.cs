// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the TypeSpec migration. The generated model now exposes
    // nested ExportRoutePolicy/ImportRoutePolicy objects on the patch model. These shims delegate to
    // the nested properties to preserve the flat ExportRoutePolicyId/ImportRoutePolicyId surface.
    public partial class NetworkFabricExternalNetworkPatch
    {
        /// <summary> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </summary>
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
