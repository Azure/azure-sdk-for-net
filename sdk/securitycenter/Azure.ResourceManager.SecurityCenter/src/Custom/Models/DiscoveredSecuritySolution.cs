// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class DiscoveredSecuritySolution
    {
        public DiscoveredSecuritySolution(SecurityFamily securityFamily, string offer, string publisher, string sku) { }
        public SecurityFamily SecurityFamily { get; set; }
        public string Publisher { get; set; }
        public string Offer { get; set; }
        public string Sku { get; set; }
    }
}
