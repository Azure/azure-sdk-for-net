// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> The DnsRecordType. </summary>
    public enum DnsRecordType
    {
        /// <summary> A. </summary>
        A,
        /// <summary> AAAA. </summary>
        Aaaa,
        /// <summary> CAA. </summary>
        CAA,
        /// <summary> CNAME. </summary>
        Cname,
        /// <summary> MX. </summary>
        MX,
        /// <summary> NS. </summary>
        NS,
        /// <summary> PTR. </summary>
        PTR,
        /// <summary> SOA. </summary>
        SOA,
        /// <summary> SRV. </summary>
        SRV,
        /// <summary> TXT. </summary>
        TXT,
        /// <summary> TLSA. </summary>
        Tlsa,
        /// <summary> DS. </summary>
        DS,
        /// <summary> NAPTR. </summary>
        Naptr
    }
}
