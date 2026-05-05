// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat shims. The v1.14.0 baseline exposed both the verb-prefixed
    // (DisablePasswordAuthentication / EnableVmAgentPlatformUpdates) and the Is*-style
    // (IsPasswordAuthenticationDisabled / IsVmAgentPlatformUpdatesEnabled) names for the
    // same wire fields. The Is* form is the new canonical name; the Disable*/Enable* form
    // is kept as a deprecated alias for source compatibility.
    public partial class LinuxConfiguration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisablePasswordAuthentication
        {
            get => IsPasswordAuthenticationDisabled;
            set => IsPasswordAuthenticationDisabled = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableVmAgentPlatformUpdates
        {
            get => IsVmAgentPlatformUpdatesEnabled;
            set => IsVmAgentPlatformUpdatesEnabled = value;
        }
    }
}
