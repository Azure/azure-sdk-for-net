// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PrivateDns;

// The shared properties model includes every record kind; expose only the SOA record on this resource.
[CodeGenSuppress("PrivateDnsARecords")]
[CodeGenSuppress("PrivateDnsAaaaRecords")]
[CodeGenSuppress("PrivateDnsMXRecords")]
[CodeGenSuppress("PrivateDnsPtrRecords")]
[CodeGenSuppress("PrivateDnsSrvRecords")]
[CodeGenSuppress("PrivateDnsTxtRecords")]
[CodeGenSuppress("Cname")]
public partial class PrivateDnsSoaRecord
{
    // TypeSpec uses the management-oriented PrivateDns prefix; the provisioning API prefers the
    // shorter record-kind name, while the released GA name remains as a compatibility alias.
    /// <summary> The SOA record in the record set. </summary>
    [CodeGenMember("PrivateDnsSoaRecord")]
    public PrivateDnsSoaRecordInfo SoaRecordInfo
    {
        get => Properties is null ? default : Properties.PrivateDnsSoaRecord;
        set
        {
            if (Properties is null)
            {
                Properties = new PrivateDnsRecordSetProperties();
            }
            Properties.PrivateDnsSoaRecord = value;
        }
    }

    /// <summary> The SOA record in the record set. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future version. Please use SoaRecordInfo instead.")]
    public PrivateDnsSoaRecordInfo PrivateDnsSoaRecordInfo
    {
        get => SoaRecordInfo;
        set => SoaRecordInfo = value;
    }

    /// <summary>
    /// Supported PrivateDnsSoaRecord resource versions.
    /// </summary>
    public static partial class ResourceVersions
    {
        /// <summary>
        /// 2020-06-01.
        /// </summary>
        public static readonly string V2020_06_01 = "2020-06-01";

        /// <summary>
        /// 2020-01-01.
        /// </summary>
        public static readonly string V2020_01_01 = "2020-01-01";

        /// <summary>
        /// 2018-09-01.
        /// </summary>
        public static readonly string V2018_09_01 = "2018-09-01";
    }
}
