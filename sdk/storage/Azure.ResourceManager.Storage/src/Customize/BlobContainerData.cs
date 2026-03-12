// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobContainerData
    {
        /// <summary> Backward-compatible alias for Deleted. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDeleted => Deleted;

        /// <summary> Backward-compatible alias for DenyEncryptionScopeOverride. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PreventEncryptionScopeOverride
        {
            get => DenyEncryptionScopeOverride;
            set => DenyEncryptionScopeOverride = value;
        }
    }
}
