// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the SecurityTaskProperties class.
    /// </summary>
    public partial class SecurityTaskProperties
    {
        /// <summary>
        /// Gets the Name value preserved from the previous public API surface.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
