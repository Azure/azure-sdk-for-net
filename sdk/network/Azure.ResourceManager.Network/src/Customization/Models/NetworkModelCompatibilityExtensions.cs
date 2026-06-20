// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    internal static partial class NetworkModelCompatibilityExtensions
    {
        /// <summary> Invokes the ToFirewallPolicyIdpsSignatureMode compatibility operation. </summary>
        public static FirewallPolicyIdpsSignatureMode ToFirewallPolicyIdpsSignatureMode(this int value) => (FirewallPolicyIdpsSignatureMode)value;
        /// <summary> Invokes the ToFirewallPolicyIdpsSignatureSeverity compatibility operation. </summary>
        public static FirewallPolicyIdpsSignatureSeverity ToFirewallPolicyIdpsSignatureSeverity(this int value) => (FirewallPolicyIdpsSignatureSeverity)value;
        /// <summary> Invokes the ToFirewallPolicyIdpsSignatureDirection compatibility operation. </summary>
        public static FirewallPolicyIdpsSignatureDirection ToFirewallPolicyIdpsSignatureDirection(this int value) => (FirewallPolicyIdpsSignatureDirection)value;
    }
}
