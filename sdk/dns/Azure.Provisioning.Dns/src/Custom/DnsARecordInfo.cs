// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Dns;

public partial class DnsARecordInfo
{
    private BicepValue<IPAddress> _ipv4Address;

    /// <summary> The IPv4 address of this A record. </summary>
    [CodeGenMember("IPv4Address")]
    public BicepValue<IPAddress> Ipv4Address
    {
        get
        {
            Initialize();
            return _ipv4Address;
        }
        set
        {
            Initialize();
            _ipv4Address.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _ipv4Address = DefineProperty<IPAddress>(nameof(Ipv4Address), ["ipv4Address"], isRequired: true);
    }
}
