// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    ///
    /// </summary>
    public class ShareSetPropertiesOptions
    {
        /// <summary>
        /// Optional, the maximum size to set on the share in GB.
        /// </summary>
        public int? QuotaInGB { get; set; }

        /// <summary>
        /// Optional, the access tier to set on the share.
        /// </summary>
        public ShareAccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional, valid for NFS shares only.
        /// </summary>
        public ShareRootSquash? RootSquash { get; set; }

        /// <summary>
        /// Optional. Supported in version 2023-08-03 and above.  Only applicable for premium file storage accounts.
        /// Specifies whether the snapshot virtual directory should be accessible at the root of share mount point when NFS is enabled.
        /// If not specified, the default is true.
        /// </summary>

        public bool? EnableSnapshotVirtualDirectoryAccess { get; set; }
        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the share's properties.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
