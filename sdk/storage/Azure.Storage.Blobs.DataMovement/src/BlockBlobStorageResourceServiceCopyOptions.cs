// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options for <see cref="BlockBlobStorageResource"/> when calling
    /// <see cref="BlockBlobStorageResource.CopyBlockFromUriAsync(System.Uri, HttpRange, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class BlockBlobStorageResourceServiceCopyOptions
    {
        /// <summary>
        /// Optional. Defines the copy operation to take.
        /// See <see cref="TransferCopyMethod"/>. Defaults to <see cref="TransferCopyMethod.SyncCopy"/>.
        /// </summary>
        public TransferCopyMethod CopyMethod { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// </summary>
    #pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
    #pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set on the destination blob.
        /// Not valid if <see cref="CopySourceTagsMode"/> is set to <see cref="BlobCopySourceTagsMode.Copy"/>.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source storage resource blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        ///
        /// This parameter is not valid for synchronous copies.
        /// </summary>
        public RehydratePriority? RehydratePriority { get; set; }

        /// <summary>
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public BlobImmutabilityPolicy DestinationImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional.
        /// If <see cref="BlobCopySourceTagsMode.Replace"/>, the tags on the destination blob will be set to <see cref="Tags"/>.
        /// If <see cref="BlobCopySourceTagsMode.Copy"/>, the tags on the source blob will be copied to the destination blob.
        /// Default is to replace.
        /// </summary>
        public BlobCopySourceTagsMode? CopySourceTagsMode { get; set; }
    }
}
