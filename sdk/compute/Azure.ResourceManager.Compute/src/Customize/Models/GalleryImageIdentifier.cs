// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryImageIdentifier
    {
        /// <summary> Initializes a new instance of GalleryImageIdentifier. </summary>
        public GalleryImageIdentifier()
        {
        }

        /// <summary> Initializes a new instance of GalleryImageIdentifier. </summary>
        /// <param name="publisher"> The name of the gallery image definition publisher. </param>
        /// <param name="offer"> The name of the gallery image definition offer. </param>
        /// <param name="sku"> The name of the gallery image definition SKU. </param>
        public GalleryImageIdentifier(string publisher, string offer, string sku)
        {
            Publisher = publisher;
            Offer = offer;
            Sku = sku;
        }
    }
}
