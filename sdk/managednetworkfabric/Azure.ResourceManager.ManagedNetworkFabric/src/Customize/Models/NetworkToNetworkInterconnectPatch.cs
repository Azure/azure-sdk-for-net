// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkToNetworkInterconnectPatch
    {
        /// <summary> Common properties for Layer2Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.")]
        public Layer2Configuration Layer2Configuration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use Layer2Settings instead.");
        }

        /// <summary> Common properties for Layer3Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.")]
        public OptionBLayer3Configuration OptionBLayer3Configuration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.");
        }

        /// <summary> NPB Static Route Configuration properties. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.")]
        public NpbStaticRouteConfiguration NpbStaticRouteConfiguration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use NpbStaticRouteSettings instead.");
        }

        /// <summary> Import Route Policy information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.")]
        public ImportRoutePolicyInformation ImportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ImportRoutePolicySettings instead.");
        }

        /// <summary> Export Route Policy information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.")]
        public ExportRoutePolicyInformation ExportRoutePolicy
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use ExportRoutePolicySettings instead.");
        }

        private static Layer2Configuration ToLayer2Configuration(Layer2ConfigurationPatch value)
            => value is null ? null : new Layer2Configuration(value.Mtu, value.Interfaces.ToList(), additionalBinaryDataProperties: null);

        private static Layer2ConfigurationPatch ToLayer2ConfigurationPatch(Layer2Configuration value)
            => value is null ? null : new Layer2ConfigurationPatch(value.Mtu, value.Interfaces.ToList(), additionalBinaryDataProperties: null);

        private static OptionBLayer3Configuration ToOptionBLayer3Configuration(OptionBLayer3ConfigurationPatchProperties value)
            => value is null ? null : new OptionBLayer3Configuration(
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                value.PeerAsn,
                value.VlanId,
                value.FabricAsn,
                value.PeLoopbackIPAddress.ToList(),
                ToNniBmpProperties(value.BmpConfiguration),
                value.PrefixLimits.Select(ToOptionBLayer3PrefixLimitProperties).ToList());

        private static OptionBLayer3ConfigurationPatchProperties ToOptionBLayer3ConfigurationPatchProperties(OptionBLayer3Configuration value)
            => value is null ? null : new OptionBLayer3ConfigurationPatchProperties(
                value.PrimaryIPv4Prefix,
                value.PrimaryIPv6Prefix,
                value.SecondaryIPv4Prefix,
                value.SecondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                value.PeerAsn,
                value.VlanId,
                value.FabricAsn,
                value.PeLoopbackIPAddress.ToList(),
                ToNniBmpPatchProperties(value.BmpConfiguration),
                value.PrefixLimits.Select(ToOptionBLayer3PrefixLimitPatchProperties).ToList());

        private static NniBmpProperties ToNniBmpProperties(NniBmpPatchProperties value)
            => value?.ConfigurationState is null ? null : new NniBmpProperties(value.ConfigurationState.Value, additionalBinaryDataProperties: null);

        private static NniBmpPatchProperties ToNniBmpPatchProperties(NniBmpProperties value)
            => value is null ? null : new NniBmpPatchProperties(value.ConfigurationState, additionalBinaryDataProperties: null);

        private static OptionBLayer3PrefixLimitProperties ToOptionBLayer3PrefixLimitProperties(OptionBLayer3PrefixLimitPatchProperties value)
            => value is null ? null : new OptionBLayer3PrefixLimitProperties(value.MaximumRoutes, additionalBinaryDataProperties: null);

        private static OptionBLayer3PrefixLimitPatchProperties ToOptionBLayer3PrefixLimitPatchProperties(OptionBLayer3PrefixLimitProperties value)
            => value is null ? null : new OptionBLayer3PrefixLimitPatchProperties(value.MaximumRoutes, additionalBinaryDataProperties: null);

        private static NpbStaticRouteConfiguration ToNpbStaticRouteConfiguration(NpbStaticRouteConfigurationPatch value)
            => value is null ? null : new NpbStaticRouteConfiguration(
                ToBfdConfiguration(value.BfdConfiguration),
                value.IPv4Routes.Select(ToStaticRouteProperties).ToList(),
                value.IPv6Routes.Select(ToStaticRouteProperties).ToList(),
                additionalBinaryDataProperties: null);

        private static NpbStaticRouteConfigurationPatch ToNpbStaticRouteConfigurationPatch(NpbStaticRouteConfiguration value)
            => value is null ? null : new NpbStaticRouteConfigurationPatch(
                ToBfdPatchConfiguration(value.BfdConfiguration),
                value.IPv4Routes.Select(ToStaticRoutePatchProperties).ToList(),
                value.IPv6Routes.Select(ToStaticRoutePatchProperties).ToList(),
                additionalBinaryDataProperties: null);

        private static ImportRoutePolicyInformation ToImportRoutePolicyInformation(ImportRoutePolicyInformationPatch value)
            => value is null ? null : new ImportRoutePolicyInformation(value.ImportIPv4RoutePolicyId, value.ImportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ImportRoutePolicyInformationPatch ToImportRoutePolicyInformationPatch(ImportRoutePolicyInformation value)
            => value is null ? null : new ImportRoutePolicyInformationPatch(value.ImportIPv4RoutePolicyId, value.ImportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ExportRoutePolicyInformation ToExportRoutePolicyInformation(ExportRoutePolicyInformationPatch value)
            => value is null ? null : new ExportRoutePolicyInformation(value.ExportIPv4RoutePolicyId, value.ExportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static ExportRoutePolicyInformationPatch ToExportRoutePolicyInformationPatch(ExportRoutePolicyInformation value)
            => value is null ? null : new ExportRoutePolicyInformationPatch(value.ExportIPv4RoutePolicyId, value.ExportIPv6RoutePolicyId, additionalBinaryDataProperties: null);

        private static BfdConfiguration ToBfdConfiguration(BfdPatchConfiguration value)
            => value is null ? null : new BfdConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);

        private static BfdPatchConfiguration ToBfdPatchConfiguration(BfdConfiguration value)
            => value is null ? null : new BfdPatchConfiguration(value.AdministrativeState, value.IntervalInMilliSeconds, value.Multiplier, additionalBinaryDataProperties: null);

        private static StaticRouteProperties ToStaticRouteProperties(StaticRoutePatchProperties value)
            => value is null ? null : new StaticRouteProperties(value.Prefix, value.NextHop, additionalBinaryDataProperties: null);

        private static StaticRoutePatchProperties ToStaticRoutePatchProperties(StaticRouteProperties value)
            => value is null ? null : new StaticRoutePatchProperties(value.Prefix, value.NextHop, additionalBinaryDataProperties: null);
    }
}
