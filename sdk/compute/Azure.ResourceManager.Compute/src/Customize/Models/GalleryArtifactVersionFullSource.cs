// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryArtifactVersionFullSource
    {
        // Backward compatibility: previously-shipped surface exposed an `override Uri` on
        // GalleryArtifactVersionFullSource. The wire `uri` field is no longer present on
        // this type in the current spec (it now lives on the sibling GalleryDiskImageSource),
        // so this override preserves the API shape with in-memory-only storage.
        /// <summary> The uri of the gallery artifact version source. Currently used to specify vhd/blob source. </summary>
        public override Uri Uri { get; set; }
    }
}
