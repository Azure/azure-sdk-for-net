// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryDiskImage
    {
        // Backward compatibility: previous AutoRest-generated shape exposed both `Source`
        // (typed as the base GalleryArtifactVersionSource) and `GallerySource` (typed as
        // the discriminator value GalleryDiskImageSource). The TypeSpec rename produces
        // `GallerySource` only; this shim preserves the deprecated `Source` accessor by
        // forwarding to the same underlying storage as `GallerySource`.
        /// <summary> The source for the disk image. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryArtifactVersionSource Source
        {
            get => GallerySource;
            set => GallerySource = value as GalleryDiskImageSource;
        }
    }
}
