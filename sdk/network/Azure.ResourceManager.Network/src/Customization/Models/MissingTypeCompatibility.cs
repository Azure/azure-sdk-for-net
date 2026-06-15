// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
#pragma warning restore SA1402

    /// <summary> Firewall policy IDPS signature direction. </summary>
    public enum FirewallPolicyIdpsSignatureDirection
    {
        /// <summary> Zero. </summary>
        Zero = 0,
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
        /// <summary> Three. </summary>
        Three = 3,
        /// <summary> Four. </summary>
        Four = 4,
        /// <summary> Five. </summary>
        Five = 5,
    }
    /// <summary> Firewall policy IDPS signature mode. </summary>
    public enum FirewallPolicyIdpsSignatureMode
    {
        /// <summary> Zero. </summary>
        Zero = 0,
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
    }

    /// <summary> Firewall policy IDPS signature severity. </summary>
    public enum FirewallPolicyIdpsSignatureSeverity
    {
        /// <summary> One. </summary>
        One = 1,
        /// <summary> Two. </summary>
        Two = 2,
        /// <summary> Three. </summary>
        Three = 3,
    }

    internal static partial class NetworkModelCompatibilityExtensions
    {
        public static FirewallPolicyIdpsSignatureMode ToFirewallPolicyIdpsSignatureMode(this int value) => (FirewallPolicyIdpsSignatureMode)value;
        public static FirewallPolicyIdpsSignatureSeverity ToFirewallPolicyIdpsSignatureSeverity(this int value) => (FirewallPolicyIdpsSignatureSeverity)value;
        public static FirewallPolicyIdpsSignatureDirection ToFirewallPolicyIdpsSignatureDirection(this int value) => (FirewallPolicyIdpsSignatureDirection)value;
    }
}
