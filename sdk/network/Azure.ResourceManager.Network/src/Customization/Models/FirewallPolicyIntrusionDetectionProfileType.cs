// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct FirewallPolicyIntrusionDetectionProfileType
    {
        // These 1.15.0 compatibility values are distinct from Off/Emerging/Core/Extended.
        /// <summary> Advanced. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility value is not defined by the current service schema.")]
        public static FirewallPolicyIntrusionDetectionProfileType Advanced { get; } = new FirewallPolicyIntrusionDetectionProfileType("Advanced");
        /// <summary> Basic. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility value is not defined by the current service schema.")]
        public static FirewallPolicyIntrusionDetectionProfileType Basic { get; } = new FirewallPolicyIntrusionDetectionProfileType("Basic");
        /// <summary> Standard. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility value is not defined by the current service schema.")]
        public static FirewallPolicyIntrusionDetectionProfileType Standard { get; } = new FirewallPolicyIntrusionDetectionProfileType("Standard");
    }
}
