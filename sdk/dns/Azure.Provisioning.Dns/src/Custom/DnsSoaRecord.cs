// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Dns;

// The shared properties model includes every record kind; expose only SOA records on this resource.
[CodeGenSuppress("DnsARecords")]
[CodeGenSuppress("DnsAaaaRecords")]
[CodeGenSuppress("DnsMXRecords")]
[CodeGenSuppress("DnsNSRecords")]
[CodeGenSuppress("DnsPtrRecords")]
[CodeGenSuppress("DnsSrvRecords")]
[CodeGenSuppress("DnsTxtRecords")]
[CodeGenSuppress("DnsCaaRecords")]
[CodeGenSuppress("DnsDSRecords")]
[CodeGenSuppress("DnsTlsaRecords")]
[CodeGenSuppress("DnsNaptrRecords")]
[CodeGenSuppress("Cname")]
public partial class DnsSoaRecord
{
    /// <summary> The SOA record data in the record set. </summary>
    [CodeGenMember("DnsSoaRecord")]
    public DnsSoaRecordInfo SoaRecordInfo
    {
        get => Properties is null ? default : Properties.DnsSoaRecord;
        set
        {
            if (Properties is null)
            {
                Properties = new DnsRecordSetProperties();
            }
            Properties.DnsSoaRecord = value;
        }
    }

    // SoaRecordInfo identifies the model type; retain the released SoaRecord member for source and binary compatibility.
    /// <summary> The SOA record data in the record set. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use SoaRecordInfo instead.")]
    public DnsSoaRecordInfo SoaRecord
    {
        get => SoaRecordInfo;
        set => SoaRecordInfo = value;
    }

    /// <summary> Supported DnsSoaRecord resource versions. </summary>
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
