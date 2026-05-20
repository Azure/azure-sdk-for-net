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
        AAAA = 1,
        /// <summary> CAA. </summary>
        CAA = 2,
        /// <summary> CNAME. </summary>
        CNAME = 3,
        /// <summary> MX. </summary>
        MX = 4,
        /// <summary> NS. </summary>
        NS = 5,
        /// <summary> PTR. </summary>
        PTR = 6,
        /// <summary> SOA. </summary>
        SOA = 7,
        /// <summary> SRV. </summary>
        SRV = 8,
        /// <summary> TXT. </summary>
        TXT = 9,
        /// <summary> TLSA. </summary>
        TLSA = 10,
        /// <summary> DS. </summary>
        DS = 11,
        /// <summary> NAPTR. </summary>
        NAPTR = 12,
        /// <summary> AAAA. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Aaaa = 1,
        /// <summary> CNAME. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Cname = 3,
        /// <summary> TLSA. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tlsa = 10,
        /// <summary> NAPTR. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Naptr = 12,
    }
}
