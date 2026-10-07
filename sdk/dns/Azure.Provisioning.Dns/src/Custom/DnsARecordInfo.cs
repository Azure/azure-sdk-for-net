// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Provisioning.Dns;

public partial class DnsARecordInfo
{
    // IPv4Address follows the preferred .NET acronym casing; retain the released Ipv4Address member for source and binary compatibility.
    /// <summary> The IPv4 address of this A record. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use IPv4Address instead.")]
    public BicepValue<IPAddress> Ipv4Address
    {
        get => IPv4Address;
        set => IPv4Address = value;
    }
}
