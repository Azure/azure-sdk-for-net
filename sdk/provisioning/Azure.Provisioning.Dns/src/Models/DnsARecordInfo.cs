// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Net;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An A record.
/// </summary>
public partial class DnsARecordInfo : ProvisionableConstruct
{
    public BicepValue<IPAddress> Ipv4Address
    {
        get { Initialize(); return _ipv4Address!; }
        set { Initialize(); _ipv4Address!.Assign(value); }
    }
    private BicepValue<IPAddress>? _ipv4Address;

    /// <summary>
    /// Creates a new DnsARecordInfo.
    /// </summary>
    public DnsARecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsARecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _ipv4Address = DefineProperty<IPAddress>(nameof(Ipv4Address), ["ipv4Address"], isRequired: true);
    }
}
