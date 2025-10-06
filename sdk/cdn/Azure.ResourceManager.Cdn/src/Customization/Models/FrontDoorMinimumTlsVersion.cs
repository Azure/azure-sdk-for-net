// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary> TLS protocol version that will be used for Https. </summary>
    public enum FrontDoorMinimumTlsVersion
    {
#pragma warning disable CA1707
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("TLS10")]
        Tls1_0,
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("TLS12")]
        Tls1_2,
        /// <summary> TLS 1.3. </summary>
        [CodeGenMember("TLS13")]
        Tls1_3
#pragma warning restore CA1707
    }
}
