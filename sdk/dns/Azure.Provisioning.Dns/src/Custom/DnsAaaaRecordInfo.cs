// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Dns;

public partial class DnsAaaaRecordInfo
{
    private BicepValue<IPAddress> _ipv6Address;

    /// <summary> The IPv6 address of this AAAA record. </summary>
    [CodeGenMember("IPv6Address")]
    public BicepValue<IPAddress> Ipv6Address
    {
        get
        {
            Initialize();
            return _ipv6Address;
        }
        set
        {
            Initialize();
            _ipv6Address.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _ipv6Address = DefineProperty<IPAddress>(nameof(Ipv6Address), ["ipv6Address"], isRequired: true);
    }
}
