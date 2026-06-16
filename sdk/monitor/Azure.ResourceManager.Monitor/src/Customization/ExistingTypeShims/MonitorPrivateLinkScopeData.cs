// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Monitor
{
    public partial class MonitorPrivateLinkScopeData
    {
        /// <summary> Current state of this PrivateLinkScope. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => PrivateLinkScopeProvisioningState.HasValue ? PrivateLinkScopeProvisioningState.Value.ToString() : null;
    }
}
