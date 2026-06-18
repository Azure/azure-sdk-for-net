// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    /// <summary>
    /// Provides a compatibility shim for the DiscoveredSecuritySolution class.
    /// </summary>
    public partial class DiscoveredSecuritySolution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveredSecuritySolution"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="securityFamily">The value preserved for API compatibility.</param>
        /// <param name="offer">The value preserved for API compatibility.</param>
        /// <param name="publisher">The value preserved for API compatibility.</param>
        /// <param name="sku">The value preserved for API compatibility.</param>
        public DiscoveredSecuritySolution(SecurityFamily securityFamily, string offer, string publisher, string sku) { }
        /// <summary>
        /// Gets or sets the SecurityFamily value preserved from the previous public API surface.
        /// </summary>
        public SecurityFamily SecurityFamily { get; set; }
        /// <summary>
        /// Gets or sets the Publisher value preserved from the previous public API surface.
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Gets or sets the Offer value preserved from the previous public API surface.
        /// </summary>
        public string Offer { get; set; }
        /// <summary>
        /// Gets or sets the Sku value preserved from the previous public API surface.
        /// </summary>
        public string Sku { get; set; }
    }
}
