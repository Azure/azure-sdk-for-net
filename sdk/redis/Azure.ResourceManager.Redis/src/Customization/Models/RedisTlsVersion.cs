// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    [CodeGenSuppress("_10")]
    [CodeGenSuppress("_11")]
    [CodeGenSuppress("_12")]
    public readonly partial struct RedisTlsVersion
    {
        /// <summary> TLS protocol version 1.0 -- deprecated for security reasons. Do not use this value for new caches. </summary>
        public static RedisTlsVersion Tls1_0 { get; } = new RedisTlsVersion(_10Value);

        /// <summary> TLS protocol version 1.1 -- deprecated for security reasons. Do not use this value for new caches. </summary>
        public static RedisTlsVersion Tls1_1 { get; } = new RedisTlsVersion(_11Value);

        /// <summary> TLS protocol version 1.2 -- use this value, or higher, for new caches. Or do not specify, so that your cache uses the recommended default value. </summary>
        public static RedisTlsVersion Tls1_2 { get; } = new RedisTlsVersion(_12Value);
    }
}