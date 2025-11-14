// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Dns;

/// <summary>
/// An NS record.
/// </summary>
public partial class DnsNSRecordInfo : ProvisionableConstruct
{
    /// <summary> The name server name for this NS record. </summary>
    public BicepValue<string> DnsNSDomainName
    {
        get { Initialize(); return _dnsNSDomainName!; }
        set { Initialize(); _dnsNSDomainName!.Assign(value); }
    }
    private BicepValue<string>? _dnsNSDomainName;

    /// <summary>
    /// Creates a new DnsNSRecordInfo.
    /// </summary>
    public DnsNSRecordInfo()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DnsNSRecordInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _dnsNSDomainName = DefineProperty<string>("DnsNSDomainName", ["nsdname"]);
    }
}
