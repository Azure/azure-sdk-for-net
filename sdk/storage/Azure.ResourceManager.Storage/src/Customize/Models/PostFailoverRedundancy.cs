// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden enum aliases with old casing for redundancy values.
// Could use @@clientName on enum values in spec.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct PostFailoverRedundancy
    {
        /// <summary> Standard_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostFailoverRedundancy StandardLrs => StandardLRS;

        /// <summary> Standard_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostFailoverRedundancy StandardZrs => StandardZRS;
    }
}
