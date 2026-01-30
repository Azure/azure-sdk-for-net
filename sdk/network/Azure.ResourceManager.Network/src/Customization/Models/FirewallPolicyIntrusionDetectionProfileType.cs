// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct FirewallPolicyIntrusionDetectionProfileType : IEquatable<FirewallPolicyIntrusionDetectionProfileType>
    {
        private const string BasicValue = "Basic";
        private const string StandardValue = "Standard";
        private const string AdvancedValue = "Advanced";

        /// <summary> Basic. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirewallPolicyIntrusionDetectionProfileType Basic { get; } = new FirewallPolicyIntrusionDetectionProfileType(BasicValue);
        /// <summary> Standard. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirewallPolicyIntrusionDetectionProfileType Standard { get; } = new FirewallPolicyIntrusionDetectionProfileType(StandardValue);
        /// <summary> Advanced. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirewallPolicyIntrusionDetectionProfileType Advanced { get; } = new FirewallPolicyIntrusionDetectionProfileType(AdvancedValue);
    }
}
