// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs.Models
{
    public readonly partial struct EventHubsTlsVersion
    {
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("_10")]
        public static EventHubsTlsVersion Tls1_0 { get; } = new EventHubsTlsVersion(_10Value);
        /// <summary> TLS 1.1. </summary>
        [CodeGenMember("_11")]
        public static EventHubsTlsVersion Tls1_1 { get; } = new EventHubsTlsVersion(_11Value);
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("_12")]
        public static EventHubsTlsVersion Tls1_2 { get; } = new EventHubsTlsVersion(_12Value);
        /// <summary> TLS 1.3. </summary>
        [CodeGenMember("_13")]
        public static EventHubsTlsVersion Tls1_3 { get; } = new EventHubsTlsVersion(_13Value);
    }
}
