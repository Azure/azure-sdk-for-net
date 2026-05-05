// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat shim. v1.14.0 baseline exposed both `ExcludeFromLatest` and
    // `IsExcludedFromLatest`; the Is* form is the new canonical name.
    public partial class GalleryArtifactPublishingProfileBase
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ExcludeFromLatest
        {
            get => IsExcludedFromLatest;
            set => IsExcludedFromLatest = value;
        }
    }
}
