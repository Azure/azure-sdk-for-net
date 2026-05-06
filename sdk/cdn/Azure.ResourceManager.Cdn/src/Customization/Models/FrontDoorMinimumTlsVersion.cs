// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename enum members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator removes separators from TLS version numbers to produce member names (e.g., TLS10, TLS12, TLS13),
    // but the old SDK used underscore-separated readable names (e.g., Tls1_0, Tls1_2, Tls1_3).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.

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
