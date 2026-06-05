// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterHttpProxyConfig
    {
        /// <summary> Whether to enable HTTP proxy. When disabled, the specified proxy configuration will be not be set on pods and nodes. </summary>
        [WirePath("enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled { get => IsHttpProxyEnabled; set => IsHttpProxyEnabled = value; }
    }
}
