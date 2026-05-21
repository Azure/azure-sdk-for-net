// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The DnsRecordType. </summary>
    public enum DnsRecordType
    {
        /// <summary> A. </summary>
        A = 0,
        /// <summary> AAAA. </summary>
        Aaaa = 1,
        /// <summary> CAA. </summary>
        Caa = 2,
        /// <summary> CNAME. </summary>
        Cname = 3,
        /// <summary> MX. </summary>
        MX = 4,
        /// <summary> NS. </summary>
        NS = 5,
        /// <summary> PTR. </summary>
        Ptr = 6,
        /// <summary> SOA. </summary>
        Soa = 7,
        /// <summary> SRV. </summary>
        Srv = 8,
        /// <summary> TXT. </summary>
        Txt = 9,
        /// <summary> TLSA. </summary>
        Tlsa = 10,
        /// <summary> DS. </summary>
        DS = 11,
        /// <summary> NAPTR. </summary>
        Naptr = 12,
        /// <summary> CAA. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        CAA = 2,
        /// <summary> PTR. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        PTR = 6,
        /// <summary> SOA. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SOA = 7,
        /// <summary> SRV. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        SRV = 8,
        /// <summary> TXT. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TXT = 9,
    }
}
