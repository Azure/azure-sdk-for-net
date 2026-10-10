// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the DiscoveredSecuritySolution class.
    /// </summary>
    public partial class DiscoveredSecuritySolution : ResourceData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveredSecuritySolution"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="securityFamily">The value preserved for API compatibility.</param>
        /// <param name="offer">The value preserved for API compatibility.</param>
        /// <param name="publisher">The value preserved for API compatibility.</param>
        /// <param name="sku">The value preserved for API compatibility.</param>
        public DiscoveredSecuritySolution(SecurityFamily securityFamily, string offer, string publisher, string sku)
        {
            SecurityFamily = securityFamily;
            Offer = offer;
            Publisher = publisher;
            Sku = sku;
        }

        internal DiscoveredSecuritySolution(DiscoveredSecuritySolutionData data) : base(data?.Id, data?.Name, data?.ResourceType ?? default, data?.SystemData)
        {
            Location = data?.Location;
            SecurityFamily = data is null ? default : data.SecurityFamily;
            Offer = data?.Offer;
            Publisher = data?.Publisher;
            Sku = data?.Sku;
        }
        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; }
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
