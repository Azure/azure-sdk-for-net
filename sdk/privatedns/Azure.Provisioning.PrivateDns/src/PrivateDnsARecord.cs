// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PrivateDns;

// The shared properties model includes every record kind; expose only A records on this resource.
[CodeGenSuppress("PrivateDnsAaaaRecords")]
[CodeGenSuppress("PrivateDnsMXRecords")]
[CodeGenSuppress("PrivateDnsPtrRecords")]
[CodeGenSuppress("PrivateDnsSoaRecord")]
[CodeGenSuppress("PrivateDnsSrvRecords")]
[CodeGenSuppress("PrivateDnsTxtRecords")]
[CodeGenSuppress("Cname")]
public partial class PrivateDnsARecord
{
    /// <summary>
    /// Supported PrivateDnsARecord resource versions.
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
