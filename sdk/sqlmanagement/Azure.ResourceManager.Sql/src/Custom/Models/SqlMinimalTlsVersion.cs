// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql.Models
{
    public partial struct SqlMinimalTlsVersion
    {
        /// <summary> None. </summary>
        [CodeGenMember("None")]
        public static SqlMinimalTlsVersion TlsNone { get; } = new SqlMinimalTlsVersion(NoneValue);
        /// <summary> 1.0. </summary>
        [CodeGenMember("_10")]
        public static SqlMinimalTlsVersion Tls1_0 { get; } = new SqlMinimalTlsVersion(_10Value);
        /// <summary> 1.1. </summary>
        [CodeGenMember("_11")]
        public static SqlMinimalTlsVersion Tls1_1 { get; } = new SqlMinimalTlsVersion(_11Value);
        /// <summary> 1.2. </summary>
        [CodeGenMember("_12")]
        public static SqlMinimalTlsVersion Tls1_2 { get; } = new SqlMinimalTlsVersion(_12Value);
        /// <summary> 1.3. </summary>
        [CodeGenMember("_13")]
        public static SqlMinimalTlsVersion Tls1_3 { get; } = new SqlMinimalTlsVersion(_13Value);
    }
}
