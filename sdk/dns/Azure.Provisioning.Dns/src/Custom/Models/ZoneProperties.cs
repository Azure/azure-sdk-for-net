// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Dns;

internal partial class ZoneProperties
{
    // Keep WritableSubResource-backed properties at the original Bicep paths so the released
    // DnsZone compatibility aliases remain functional while the preferred properties use DnsSubResourceInfo.
    private BicepList<WritableSubResource> _registrationVirtualNetworks;
    private BicepList<WritableSubResource> _resolutionVirtualNetworks;

    internal BicepList<WritableSubResource> RegistrationVirtualNetworks
    {
        get
        {
            Initialize();
            return _registrationVirtualNetworks;
        }
        set
        {
            Initialize();
            _registrationVirtualNetworks.Assign(value);
        }
    }

    internal BicepList<WritableSubResource> ResolutionVirtualNetworks
    {
        get
        {
            Initialize();
            return _resolutionVirtualNetworks;
        }
        set
        {
            Initialize();
            _resolutionVirtualNetworks.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _registrationVirtualNetworks = DefineListProperty<WritableSubResource>(
            nameof(RegistrationVirtualNetworks),
            new string[] { "registrationVirtualNetworks" });
        _resolutionVirtualNetworks = DefineListProperty<WritableSubResource>(
            nameof(ResolutionVirtualNetworks),
            new string[] { "resolutionVirtualNetworks" });
    }
}
