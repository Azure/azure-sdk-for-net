// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute
{
    public partial class GalleryImageVersionData
    {
        /// <summary> Indicates if this is a soft-delete resource restoration request. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsRestoreEnabled { get => Restore; set => Restore = value; }
    }
}
