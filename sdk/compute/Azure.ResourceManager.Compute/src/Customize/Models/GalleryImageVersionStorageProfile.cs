// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryImageVersionStorageProfile
    {
        // Backward compatibility: previous AutoRest-generated shape exposed both `Source`
        // (typed as the base GalleryArtifactVersionSource) and `GallerySource` (typed as
        // GalleryArtifactVersionFullSource). The TypeSpec rename produces `GallerySource`
        // only; this shim preserves the deprecated `Source` accessor by forwarding to the
        // same underlying storage as `GallerySource`.
        /// <summary> The source of the gallery artifact version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryArtifactVersionSource Source
        {
            get => GallerySource;
            set => GallerySource = value as GalleryArtifactVersionFullSource;
        }
    }
}
