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
    public BicepValue<IPAddress> Ipv6Address
    {
        get { Initialize(); return _ipv6Address!; }
        set { Initialize(); _ipv6Address!.Assign(value); }
    }
    private BicepValue<IPAddress>? _ipv6Address;

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
        _ipv6Address = DefineProperty<IPAddress>(nameof(Ipv6Address), ["ipv6Address"]);
    }
}
