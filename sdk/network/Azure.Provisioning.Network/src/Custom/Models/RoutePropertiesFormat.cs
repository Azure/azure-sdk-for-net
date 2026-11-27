// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Network;

internal partial class RoutePropertiesFormat
{
    // Restore writable registration as well as the released RouteResource setter;
    // assigning the generated output-only value would otherwise throw.
    public BicepValue<bool> HasBgpOverride
    {
        get { Initialize(); return _hasBgpOverride; }
        set { Initialize(); _hasBgpOverride.Assign(value); }
    }
    private BicepValue<bool> _hasBgpOverride;

    partial void DefineAdditionalProperties()
    {
        _hasBgpOverride = DefineProperty<bool>(nameof(HasBgpOverride), new string[] { "hasBgpOverride" });
    }
}
