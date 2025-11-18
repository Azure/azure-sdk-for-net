// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Net;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An AAAA record.
/// </summary>
public partial class DnsAaaaRecordInfo : ProvisionableConstruct
{
    public BicepValue<IPAddress> Ipv6Addresses
    {
        get { Initialize(); return _ipv6Addresses!; }
        set { Initialize(); _ipv6Addresses!.Assign(value); }
    }
    private BicepValue<IPAddress>? _ipv6Addresses;

    /// <summary>
    /// Creates a new DnsAaaaRecordInfo.
    /// </summary>
    public DnsAaaaRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsAaaaRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _ipv6Addresses = DefineProperty<IPAddress>("IPv6Addresses", ["ipv6Addresses"]);
    }
}
