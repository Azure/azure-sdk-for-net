// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat option-bag type re-introduced for source compatibility with
    // the previous (AutoRest-based) public surface. See sibling
    // SubscriptionResourceGetVirtualMachineImagesOptions.cs for full justification.
    public partial class SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions
    {
        public SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions(AzureLocation location, string edgeZone, string publisherName, string offer, string skus)
        {
            Location = location;
            EdgeZone = edgeZone;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
        }

        public AzureLocation Location { get; }
        public string EdgeZone { get; }
        public string PublisherName { get; }
        public string Offer { get; }
        public string Skus { get; }
        public string Expand { get; set; }
        public int? Top { get; set; }
        public string Orderby { get; set; }
    }
}
