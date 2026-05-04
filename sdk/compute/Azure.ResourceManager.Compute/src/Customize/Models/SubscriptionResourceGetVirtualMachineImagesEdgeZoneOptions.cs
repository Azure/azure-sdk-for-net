// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat option-bag type re-introduced for source compatibility with
    // the previous (AutoRest-based) public surface. See sibling
    // SubscriptionResourceGetVirtualMachineImagesOptions.cs for full justification.
    public partial class SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions"/>. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="edgeZone"> The name of the edge zone. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <param name="version"> A valid image SKU version. </param>
        public SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions(AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version)
        {
            Location = location;
            EdgeZone = edgeZone;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
            Version = version;
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
        /// <summary> A valid image SKU version. </summary>
        public string Version { get; }
    }
}
