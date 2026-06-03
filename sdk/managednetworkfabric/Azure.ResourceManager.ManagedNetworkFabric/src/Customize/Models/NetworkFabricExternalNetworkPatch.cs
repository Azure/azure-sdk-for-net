// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricExternalNetworkPatch
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

        /// <summary> option B properties object. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionBSettings instead.")]
        public L3OptionBProperties OptionBProperties
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBSettings instead.");
        }

        /// <summary> Import Route Policy either IPv4 or IPv6. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.")]
        public ImportRoutePolicy ImportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
        }

        /// <summary> Export Route Policy either IPv4 or IPv6. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.")]
        public ExportRoutePolicy ExportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
        }

        private static L3OptionBProperties ToL3OptionBProperties(L3OptionBPatchProperties value)
            => value is null ? null : new L3OptionBProperties(
                value.ImportRouteTargets.ToList(),
                value.ExportRouteTargets.ToList(),
                ToRouteTargetInformation(value.RouteTargets),
                additionalBinaryDataProperties: null);

        private static L3OptionBPatchProperties ToL3OptionBPatchProperties(L3OptionBProperties value)
            => value is null ? null : new L3OptionBPatchProperties(
                value.ImportRouteTargets.ToList(),
                value.ExportRouteTargets.ToList(),
                ToRouteTargetPatchInformation(value.RouteTargets),
                additionalBinaryDataProperties: null);

        private static RouteTargetInformation ToRouteTargetInformation(RouteTargetPatchInformation value)
            => value is null ? null : new RouteTargetInformation(
                value.ImportIPv4RouteTargets.ToList(),
                value.ImportIPv6RouteTargets.ToList(),
                value.ExportIPv4RouteTargets.ToList(),
                value.ExportIPv6RouteTargets.ToList(),
                additionalBinaryDataProperties: null);

        private static RouteTargetPatchInformation ToRouteTargetPatchInformation(RouteTargetInformation value)
            => value is null ? null : new RouteTargetPatchInformation(
                value.ImportIPv4RouteTargets.ToList(),
                value.ImportIPv6RouteTargets.ToList(),
                value.ExportIPv4RouteTargets.ToList(),
                value.ExportIPv6RouteTargets.ToList(),
                additionalBinaryDataProperties: null);

        private static ImportRoutePolicy ToImportRoutePolicy(ImportRoutePolicyPatch value)
            => value is null ? null : new ImportRoutePolicy(value.ImportIPv4RoutePolicyId, value.ImportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ImportRoutePolicyPatch ToImportRoutePolicyPatch(ImportRoutePolicy value)
            => value is null ? null : new ImportRoutePolicyPatch(value.ImportIPv4RoutePolicyId, value.ImportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ExportRoutePolicy ToExportRoutePolicy(ExportRoutePolicyPatch value)
            => value is null ? null : new ExportRoutePolicy(value.ExportIPv4RoutePolicyId, value.ExportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ExportRoutePolicyPatch ToExportRoutePolicyPatch(ExportRoutePolicy value)
            => value is null ? null : new ExportRoutePolicyPatch(value.ExportIPv4RoutePolicyId, value.ExportIPv6RoutePolicyId, additionalBinaryDataProperties: null);
    }
}
