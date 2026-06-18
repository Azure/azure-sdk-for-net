// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the SecurityTopologyResource class.
    /// </summary>
    public partial class SecurityTopologyResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityTopologyResource"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityTopologyResource() { }
    }
}
