// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class VirtualNetworkAppliance
{
    /// <summary> Gets or sets the bandwidth in gigabits per second as a string. </summary>
    /// <remarks> This property has independent storage from BandwidthGbps. Set only one of the two properties. </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use BandwidthGbps instead.")]
    public BicepValue<string> BandwidthInGbps
    {
        get => Properties is null ? default : Properties.LegacyBandwidthInGbps;
        set
        {
            if (Properties is null)
            {
                Properties = new VirtualNetworkAppliancePropertiesFormat();
            }
            Properties.LegacyBandwidthInGbps = value;
        }
    }
}

internal partial class VirtualNetworkAppliancePropertiesFormat
{
    private BicepValue<string> _legacyBandwidthInGbps;

    // The service changed this field from string to number. Keep the released string
    // input functional without parsing literals or rewriting Bicep expressions.
    // Register it on the backing model, alongside the numeric field, so emitting the
    // legacy value cannot replace the resource's entire properties object.
    internal BicepValue<string> LegacyBandwidthInGbps
    {
        get { Initialize(); return _legacyBandwidthInGbps; }
        set { Initialize(); _legacyBandwidthInGbps.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        BicepValue<string> value = DefineProperty<string>("BandwidthInGbps", new string[] { "bandwidthInGbps" });
        _legacyBandwidthInGbps = new LegacyBandwidthValue(value, _bandwidthGbps);
        ProvisionableProperties["BandwidthInGbps"] = _legacyBandwidthInGbps;
    }

    // Bicep compilation checks IsEmpty even for nested model properties. Detect both
    // inputs here rather than in a setter: callers can retain the returned BicepValue
    // and assign it later. Otherwise the shared wire path would silently discard one.
    private sealed class LegacyBandwidthValue : BicepValue<string>
    {
        private readonly BicepValue<double> _numeric;

        public LegacyBandwidthValue(BicepValue<string> value, BicepValue<double> numeric)
            : base((string)null)
        {
            _numeric = numeric;
            // Assigning the registered unset value would create a property-reference expression.
            // Start unset and copy only its registration metadata instead.
            Assign((BicepValue<string>)null);
            ((IBicepValue)this).Self = ((IBicepValue)value).Self;
        }

        public override bool IsEmpty
        {
            get
            {
                if (!base.IsEmpty && !_numeric.IsEmpty)
                {
                    throw new InvalidOperationException("Set either BandwidthInGbps or BandwidthGbps, not both.");
                }
                return base.IsEmpty;
            }
        }
    }
}
