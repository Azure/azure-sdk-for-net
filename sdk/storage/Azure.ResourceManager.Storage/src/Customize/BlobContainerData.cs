// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties (IsDeleted, PreventEncryptionScopeOverride)
// for renamed generated properties. Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerData
    {
        /// <summary> Backward-compatible alias for Deleted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.deleted")]
        public bool? IsDeleted => Deleted;

        /// <summary> Backward-compatible alias for DenyEncryptionScopeOverride. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.denyEncryptionScopeOverride")]
        public bool? PreventEncryptionScopeOverride
        {
            get => DenyEncryptionScopeOverride;
            set => DenyEncryptionScopeOverride = value;
        }
    }
}
