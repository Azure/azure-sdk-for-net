// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryImageVersionStorageProfile
    {
        /// <summary>
        /// The gallery artifact version source.
        /// This is no longer supported. Please use <see cref="GallerySource"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryArtifactVersionSource Source { get; set; } // the old property to keep backward compatiblility, working as a backing property of GallerySource

        /// <summary> The source of the gallery artifact version. </summary>
        public GalleryArtifactVersionFullSource GallerySource { get => Source as GalleryArtifactVersionFullSource; set => Source = value; }
    }
}
