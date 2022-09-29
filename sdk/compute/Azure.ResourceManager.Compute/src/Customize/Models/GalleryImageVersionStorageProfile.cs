// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class GalleryImageVersionStorageProfile
    {
        /// <summary> The gallery artifact version source.
        /// This is no longer supported. Please use <see cref="GalleryImageVersionStorageProfile.GallerySource"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GalleryArtifactVersionSource Source
        {
            get => new GalleryArtifactVersionSource(GallerySource.Id, null, null);
            set
            {
                GallerySource = new GalleryArtifactVersionFullSource(value.Id, null);
            }
        }
    }
}
