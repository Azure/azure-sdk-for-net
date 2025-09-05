// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for creating an Page Blob.
    /// </summary>
    public class PageBlobCreateOptions
    {
        /// <summary>
        /// Optional user-controlled value that you can use to track requests.
        /// The value of the SequenceNumber must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        /// </summary>
        public long? SequenceNumber { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new page blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the creation of this new page blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this page blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public BlobImmutabilityPolicy ImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional.  Sets the page blob tiers on the blob.
        /// This is only supported for page blobs on premium accounts.
        /// </summary>
        public PremiumPageBlobAccessTier? PremiumPageBlobAccessTier { get; set; }
    }
}
