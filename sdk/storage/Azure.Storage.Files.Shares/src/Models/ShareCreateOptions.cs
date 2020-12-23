// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for creating a Share.
    /// </summary>
    public class ShareCreateOptions
    {
        /// <summary>
        /// Optional custom metadata to set for this share.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Maximum size of the share in gigabytes.  If unspecified, use the service's default value.
        /// </summary>
        public int? QuotaInGB { get; set; }

        /// <summary>
        /// Optional.  Specifies the access tier of the share.
        /// </summary>
        public ShareAccessTier? AccessTier { get; set; }

        /// <summary>
        /// The protocols to enable for the share.
        /// </summary>
        public ShareProtocols? Protocols { get; set; }

        /// <summary>
        /// The root squash to set for the share.  Only valid for NFS shares.
        /// </summary>
        public ShareRootSquash? RootSquash { get; set; }
    }
}
