// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class CommunityGalleryImageData
    {
        /// <summary> This is the gallery image definition identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryImageIdentifier Identifier => new GalleryImageIdentifier()
        {
            Publisher = ImageIdentifier.Publisher,
            Offer = ImageIdentifier.Offer,
            Sku = ImageIdentifier.Sku
        };
    }
}
