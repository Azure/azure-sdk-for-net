// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable AZC0032 // Legacy compatibility type name from previous GA API surface.
#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SecuritySolutionsReferenceData : ResourceData
    {
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

        public SecurityFamily SecurityFamily { get; set; }
        public string AlertVendorName { get; set; }
        public Uri PackageInfoUrl { get; set; }
        public string ProductName { get; set; }
        public string Publisher { get; set; }
        public string PublisherDisplayName { get; set; }
        public string Template { get; set; }
        public AzureLocation? Location => default;
        public Uri PackageInfoUri { get; set; }
    }
}
