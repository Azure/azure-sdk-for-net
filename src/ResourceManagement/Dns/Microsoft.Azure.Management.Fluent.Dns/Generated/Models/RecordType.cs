// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Fluent.Dns.Models
{
    /// <summary>
    /// Defines values for RecordType.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RecordType
    {
        [System.Runtime.Serialization.EnumMember(Value = "A")]
        A,
        [System.Runtime.Serialization.EnumMember(Value = "AAAA")]
        AAAA,
        [System.Runtime.Serialization.EnumMember(Value = "CNAME")]
        CNAME,
        [System.Runtime.Serialization.EnumMember(Value = "MX")]
        MX,
        [System.Runtime.Serialization.EnumMember(Value = "NS")]
        NS,
        [System.Runtime.Serialization.EnumMember(Value = "PTR")]
        PTR,
        [System.Runtime.Serialization.EnumMember(Value = "SOA")]
        SOA,
        [System.Runtime.Serialization.EnumMember(Value = "SRV")]
        SRV,
        [System.Runtime.Serialization.EnumMember(Value = "TXT")]
        TXT
    }
}
