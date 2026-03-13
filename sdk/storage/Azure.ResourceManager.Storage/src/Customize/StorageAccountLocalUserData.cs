// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden alias properties for renamed ACL auth and NFSv3 booleans.
// Could use @@clientName in spec but would lose improved names.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountLocalUserData
    {
        /// <summary> Backward-compatible alias for AllowAclAuthorization. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.allowAclAuthorization")]
        public bool? IsAclAuthorizationAllowed
        {
            get => AllowAclAuthorization;
            set => AllowAclAuthorization = value;
        }

        /// <summary> Backward-compatible alias for IsNFSv3Enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNFSv3Enabled")]
        public bool? IsNfsV3Enabled
        {
            get => IsNFSv3Enabled;
            set => IsNFSv3Enabled = value;
        }
    }
}
