// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename enum members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator removes separators from TLS version numbers to produce member names (e.g., TLSv1, TLSv11, TLSv12),
    // but the old SDK used underscore-separated readable names (e.g., Tls1_0, Tls1_1, Tls1_2).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.

    /// <summary> The protocol of an established TLS connection. </summary>
    public readonly partial struct DeliveryRuleSslProtocol : IEquatable<DeliveryRuleSslProtocol>
    {
#pragma warning disable CA1707
        /// <summary> TLS 1.0. </summary>
        [CodeGenMember("TLSv1")]
        public static DeliveryRuleSslProtocol Tls1_0 { get; } = new DeliveryRuleSslProtocol(TLSv1Value);
        /// <summary> TLS 1.1. </summary>
        [CodeGenMember("TLSv11")]
        public static DeliveryRuleSslProtocol Tls1_1 { get; } = new DeliveryRuleSslProtocol(TLSv11Value);
        /// <summary> TLS 1.2. </summary>
        [CodeGenMember("TLSv12")]
        public static DeliveryRuleSslProtocol Tls1_2 { get; } = new DeliveryRuleSslProtocol(TLSv12Value);
#pragma warning restore CA1707
    }
}
