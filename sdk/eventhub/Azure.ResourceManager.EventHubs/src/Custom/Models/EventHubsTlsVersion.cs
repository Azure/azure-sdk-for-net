// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventHubs.Models
{
    [CodeGenSuppress("Tls10")]
    [CodeGenSuppress("Tls11")]
    [CodeGenSuppress("Tls12")]
    [CodeGenSuppress("Tls13")]
    public readonly partial struct EventHubsTlsVersion
    {
        /// <summary> TLS 1.0. </summary>
        public static EventHubsTlsVersion Tls1_0 { get; } = new EventHubsTlsVersion(Tls10Value);
        /// <summary> TLS 1.1. </summary>
        public static EventHubsTlsVersion Tls1_1 { get; } = new EventHubsTlsVersion(Tls11Value);
        /// <summary> TLS 1.2. </summary>
        public static EventHubsTlsVersion Tls1_2 { get; } = new EventHubsTlsVersion(Tls12Value);
        /// <summary> TLS 1.3. </summary>
        public static EventHubsTlsVersion Tls1_3 { get; } = new EventHubsTlsVersion(Tls13Value);
    }
}
