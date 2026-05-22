// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs.Models
{
    public readonly partial struct EventHubsTlsVersion
    {
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("Tls10")]
        public static EventHubsTlsVersion Tls1_0 { get; } = new EventHubsTlsVersion(Tls10Value);
        /// <summary> TLS 1.1. </summary>
        [CodeGenMember("Tls11")]
        public static EventHubsTlsVersion Tls1_1 { get; } = new EventHubsTlsVersion(Tls11Value);
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("Tls12")]
        public static EventHubsTlsVersion Tls1_2 { get; } = new EventHubsTlsVersion(Tls12Value);
        /// <summary> TLS 1.3. </summary>
        [CodeGenMember("Tls13")]
        public static EventHubsTlsVersion Tls1_3 { get; } = new EventHubsTlsVersion(Tls13Value);
    }
}
