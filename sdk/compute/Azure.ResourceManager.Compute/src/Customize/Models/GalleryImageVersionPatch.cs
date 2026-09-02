// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: the previously shipped patch model exposed the soft-delete restore flag as Restore.
    // Keep the generated IsRestoreEnabled name for consistency and redirect the old name to it.
    public partial class GalleryImageVersionPatch
    {
        /// <summary> Indicates if this is a soft-delete resource restoration request. </summary>
        [Obsolete("Use IsRestoreEnabled instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Restore
        {
            get => IsRestoreEnabled;
            set => IsRestoreEnabled = value;
        }
    }
}
