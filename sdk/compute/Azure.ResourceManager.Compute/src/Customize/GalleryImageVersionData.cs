// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Compute
{
    // Backward-compat shim. v1.14.0 baseline exposed `IsRestoreEnabled` on
    // GalleryImageVersionData (while GalleryImageVersionPatch used the bare `Restore` name).
    // After unifying the spec name to `restore`, `Restore` is the canonical generated name on
    // both Data and Patch; this shim restores the historical Data accessor.
    public partial class GalleryImageVersionData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsRestoreEnabled
        {
            get => Restore;
            set => Restore = value;
        }
    }
}
