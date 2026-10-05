// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;

namespace Azure.Provisioning.Dns;

public partial class DnsAaaaRecordInfo
{
    // IPv6Address follows the preferred .NET acronym casing; retain the released Ipv6Address member for source and binary compatibility.
    /// <summary> The IPv6 address of this AAAA record. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use IPv6Address instead.")]
    public BicepValue<IPAddress> Ipv6Address
    {
        get => IPv6Address;
        set => IPv6Address = value;
    }
}
