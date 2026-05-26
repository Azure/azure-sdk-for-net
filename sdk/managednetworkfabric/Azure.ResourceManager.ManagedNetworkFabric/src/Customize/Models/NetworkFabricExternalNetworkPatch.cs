// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the TypeSpec migration. The previous SDK exposed
    // route policy IDs directly while the generated model now uses nested route policy objects.
    // Removing these shims would drop the flat ExportRoutePolicyId/ImportRoutePolicyId patch properties.
    public partial class NetworkFabricExternalNetworkPatch
    {
        /// <summary> Import Route Policy either IPv4 or IPv6. </summary>
        [CodeGenMember("ImportRoutePolicy")]
        public ImportRoutePolicy ImportRoutePolicy
        {
            get => Properties?.ImportRoutePolicy is null ? default : new ImportRoutePolicy { ImportIpv4RoutePolicyId = Properties.ImportRoutePolicy.ImportIpv4RoutePolicyId, ImportIpv6RoutePolicyId = Properties.ImportRoutePolicy.ImportIpv6RoutePolicyId };
            set
            {
                if (Properties is null)
                {
                    Properties = new ExternalNetworkPatchProperties();
                }
                Properties.ImportRoutePolicy = value is null ? default : new ImportRoutePolicyPatch { ImportIpv4RoutePolicyId = value.ImportIpv4RoutePolicyId, ImportIpv6RoutePolicyId = value.ImportIpv6RoutePolicyId };
            }
        }

        /// <summary> Export Route Policy either IPv4 or IPv6. </summary>
        [CodeGenMember("ExportRoutePolicy")]
        public ExportRoutePolicy ExportRoutePolicy
        {
            get => Properties?.ExportRoutePolicy is null ? default : new ExportRoutePolicy { ExportIpv4RoutePolicyId = Properties.ExportRoutePolicy.ExportIpv4RoutePolicyId, ExportIpv6RoutePolicyId = Properties.ExportRoutePolicy.ExportIpv6RoutePolicyId };
            set
            {
                if (Properties is null)
                {
                    Properties = new ExternalNetworkPatchProperties();
                }
                Properties.ExportRoutePolicy = value is null ? default : new ExportRoutePolicyPatch { ExportIpv4RoutePolicyId = value.ExportIpv4RoutePolicyId, ExportIpv6RoutePolicyId = value.ExportIpv6RoutePolicyId };
            }
        }

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
