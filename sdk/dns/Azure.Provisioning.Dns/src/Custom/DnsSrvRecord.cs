// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Dns;

// The shared properties model includes every record kind; expose only SRV records on this resource.
[CodeGenSuppress("DnsARecords")]
[CodeGenSuppress("DnsAaaaRecords")]
[CodeGenSuppress("DnsMXRecords")]
[CodeGenSuppress("DnsNSRecords")]
[CodeGenSuppress("DnsPtrRecords")]
[CodeGenSuppress("DnsSoaRecord")]
[CodeGenSuppress("DnsTxtRecords")]
[CodeGenSuppress("DnsCaaRecords")]
[CodeGenSuppress("DnsDSRecords")]
[CodeGenSuppress("DnsTlsaRecords")]
[CodeGenSuppress("DnsNaptrRecords")]
[CodeGenSuppress("Cname")]
public partial class DnsSrvRecord
{
    /// <summary> The SRV record data in the record set. </summary>
    [CodeGenMember("DnsSrvRecords")]
    public BicepList<DnsSrvRecordInfo> SrvRecords
    {
        get => Properties is null ? default : Properties.DnsSrvRecords;
        set
        {
            if (Properties is null)
            {
                Properties = new DnsRecordSetProperties();
            }
            Properties.DnsSrvRecords = value;
        }
    }

    /// <summary> Supported DnsSrvRecord resource versions. </summary>
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
