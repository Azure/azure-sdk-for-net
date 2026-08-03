// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec schema does not generate the same ARM resource-data base type as the GA SDK; this partial restores the GA inheritance so resource data remains assignable to the same base class.
    /// <summary>
    /// Provides a compatibility shim for the SecuritySolutionsReferenceData class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecuritySolutionsReferenceData : ResourceData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecuritySolutionsReferenceData"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="securityFamily">The value preserved for API compatibility.</param>
        /// <param name="alertVendorName">The value preserved for API compatibility.</param>
        /// <param name="packageInfoUrl">The value preserved for API compatibility.</param>
        /// <param name="productName">The value preserved for API compatibility.</param>
        /// <param name="publisher">The value preserved for API compatibility.</param>
        /// <param name="publisherDisplayName">The value preserved for API compatibility.</param>
        /// <param name="template">The value preserved for API compatibility.</param>
        public SecuritySolutionsReferenceData(SecurityFamily securityFamily, string alertVendorName, Uri packageInfoUrl, string productName, string publisher, string publisherDisplayName, string template)
        {
            SecurityFamily = securityFamily;
            AlertVendorName = alertVendorName;
            PackageInfoUrl = packageInfoUrl;
            ProductName = productName;
            Publisher = publisher;
            PublisherDisplayName = publisherDisplayName;
            Template = template;
        }
        /// <summary>
        /// Gets or sets the SecurityFamily value preserved from the previous public API surface.
        /// </summary>
        public SecurityFamily SecurityFamily { get; set; }
        /// <summary>
        /// Gets or sets the AlertVendorName value preserved from the previous public API surface.
        /// </summary>
        public string AlertVendorName { get; set; }
        /// <summary>
        /// Gets or sets the PackageInfoUrl value preserved from the previous public API surface.
        /// </summary>
        public Uri PackageInfoUrl { get; set; }
        /// <summary>
        /// Gets or sets the ProductName value preserved from the previous public API surface.
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Gets or sets the Publisher value preserved from the previous public API surface.
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Gets or sets the PublisherDisplayName value preserved from the previous public API surface.
        /// </summary>
        public string PublisherDisplayName { get; set; }
        /// <summary>
        /// Gets or sets the Template value preserved from the previous public API surface.
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Gets the Location value preserved from the previous public API surface.
        /// </summary>
        public AzureLocation? Location => default;
        /// <summary>
        /// Gets or sets the PackageInfoUri value preserved from the previous public API surface.
        /// </summary>
        public Uri PackageInfoUri { get; set; }
    }
}
