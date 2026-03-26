// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // we have this customization here to change its namespace to avoid breaking changes
    [CodeGenType("SharedGalleryImageData")]
    [CodeGenSuppress("Identifier")]
    public partial class SharedGalleryImageData
    {
        // we also must add back this property to avoid breaking changes, but its payload never have this property.
        /// <summary>
        /// The resource identifier.
        ///
        /// This property is depracated and will be removed in a future release.
        /// There is possibility that this property will be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id { get; internal set; }

        /// <summary> This is the gallery image definition identifier. </summary>
        public new GalleryImageIdentifier Identifier => Properties?.Identifier;
    }
}
