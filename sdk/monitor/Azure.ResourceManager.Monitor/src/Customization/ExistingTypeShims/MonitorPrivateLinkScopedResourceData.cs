// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Monitor
{
    public partial class MonitorPrivateLinkScopedResourceData
    {
        /// <summary> State of the Azure monitor resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => ScopedResourceProvisioningState.HasValue ? ScopedResourceProvisioningState.Value.ToString() : null;
    }
}
