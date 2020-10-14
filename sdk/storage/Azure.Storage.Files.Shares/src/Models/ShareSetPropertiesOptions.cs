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
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on setting the share's properties.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }
    }
}
