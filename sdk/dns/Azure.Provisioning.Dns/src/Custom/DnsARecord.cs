// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Dns;

// The shared properties model includes every record kind; expose only A records on this resource.
[CodeGenSuppress("DnsAaaaRecords")]
[CodeGenSuppress("DnsMXRecords")]
[CodeGenSuppress("DnsNSRecords")]
[CodeGenSuppress("DnsPtrRecords")]
[CodeGenSuppress("DnsSoaRecord")]
[CodeGenSuppress("DnsSrvRecords")]
[CodeGenSuppress("DnsTxtRecords")]
[CodeGenSuppress("DnsCaaRecords")]
[CodeGenSuppress("DnsDSRecords")]
[CodeGenSuppress("DnsTlsaRecords")]
[CodeGenSuppress("DnsNaptrRecords")]
[CodeGenSuppress("Cname")]
public partial class DnsARecord
{
    /// <summary> The list of A records in the record set. </summary>
    [CodeGenMember("DnsARecords")]
    public BicepList<DnsARecordInfo> ARecords
    {
        get => Properties is null ? default : Properties.DnsARecords;
        set
        {
            if (Properties is null)
            {
                Properties = new DnsRecordSetProperties();
            }
            Properties.DnsARecords = value;
        }
    }

    /// <summary>
    /// Supported DnsARecord resource versions.
    /// </summary>
    public static partial class ResourceVersions
    {
        /// <summary> 2018-05-01. </summary>
        public static readonly string V2018_05_01 = "2018-05-01";

        /// <summary> 2017-10-01. </summary>
        public static readonly string V2017_10_01 = "2017-10-01";

        /// <summary> 2017-09-01. </summary>
        public static readonly string V2017_09_01 = "2017-09-01";

        /// <summary> 2016-04-01. </summary>
        public static readonly string V2016_04_01 = "2016-04-01";
    }
}
