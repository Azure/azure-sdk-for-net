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
            get => ToLayer2Configuration(Layer2Settings);
            set => Layer2Settings = ToLayer2ConfigurationPatch(value);
        }

        /// <summary> Common properties for Layer3Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use OptionBLayer3Settings instead.")]
        public OptionBLayer3Configuration OptionBLayer3Configuration
        {
            get => ToOptionBLayer3Configuration(OptionBLayer3Settings);
            set => OptionBLayer3Settings = ToOptionBLayer3ConfigurationPatchProperties(value);
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
    }
}
