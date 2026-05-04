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
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions"/>. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        public SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions(AzureLocation location, string edgeZone, string publisherName, string offer, string skus)
        {
            Location = location;
            EdgeZone = edgeZone;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
        }

        /// <summary> The name of a supported Azure region. </summary>
        public AzureLocation Location { get; }
        /// <summary> The name of the edge zone. </summary>
        public string EdgeZone { get; }
        /// <summary> A valid image publisher. </summary>
        public string PublisherName { get; }
        /// <summary> A valid image publisher offer. </summary>
        public string Offer { get; }
        /// <summary> A valid image SKU. </summary>
        public string Skus { get; }
        /// <summary> The expand expression to apply on the operation. </summary>
        public string Expand { get; set; }
        /// <summary> An integer value specifying the number of images to return that matches supplied values. </summary>
        public int? Top { get; set; }
        /// <summary> Specifies the order of the results returned. Formatted as an OData query. </summary>
        public string Orderby { get; set; }
    }
}
