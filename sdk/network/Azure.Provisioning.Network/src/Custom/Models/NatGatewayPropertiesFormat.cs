// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class NatGatewayPropertiesFormat
{
    private BicepList<WritableSubResource> _publicIPAddresses;
    private BicepList<WritableSubResource> _publicIPAddressesV6;
    private BicepList<WritableSubResource> _publicIPPrefixes;
    private BicepList<WritableSubResource> _publicIPPrefixesV6;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the public IPv4 address references. </summary>
    [CodeGenMember("PublicIPAddresses")]
    public BicepList<WritableSubResource> PublicIPAddresses
    {
        get
        {
            Initialize();
            return _publicIPAddresses;
        }
        set
        {
            Initialize();
            _publicIPAddresses.Assign(value);
        }
    }

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the public IPv6 address references. </summary>
    [CodeGenMember("PublicIPAddressesV6")]
    public BicepList<WritableSubResource> PublicIPAddressesV6
    {
        get
        {
            Initialize();
            return _publicIPAddressesV6;
        }
        set
        {
            Initialize();
            _publicIPAddressesV6.Assign(value);
        }
    }

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the public IPv4 prefix references. </summary>
    [CodeGenMember("PublicIPPrefixes")]
    public BicepList<WritableSubResource> PublicIPPrefixes
    {
        get
        {
            Initialize();
            return _publicIPPrefixes;
        }
        set
        {
            Initialize();
            _publicIPPrefixes.Assign(value);
        }
    }

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the public IPv6 prefix references. </summary>
    [CodeGenMember("PublicIPPrefixesV6")]
    public BicepList<WritableSubResource> PublicIPPrefixesV6
    {
        get
        {
            Initialize();
            return _publicIPPrefixesV6;
        }
        set
        {
            Initialize();
            _publicIPPrefixesV6.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _publicIPAddresses = DefineListProperty<WritableSubResource>(nameof(PublicIPAddresses), new string[] { "publicIpAddresses" });
        _publicIPAddressesV6 = DefineListProperty<WritableSubResource>(nameof(PublicIPAddressesV6), new string[] { "publicIpAddressesV6" });
        _publicIPPrefixes = DefineListProperty<WritableSubResource>(nameof(PublicIPPrefixes), new string[] { "publicIpPrefixes" });
        _publicIPPrefixesV6 = DefineListProperty<WritableSubResource>(nameof(PublicIPPrefixesV6), new string[] { "publicIpPrefixesV6" });
    }
}
