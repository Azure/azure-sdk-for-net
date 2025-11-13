// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // we have this customization here to change its namespace to avoid breaking changes
    [CodeGenType("CommunityGalleryImageData")]
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

        // we also must add back this property to avoid breaking changes, but its payload never have this property.
        /// <summary> The resource identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id { get; internal set; }
    }
}
