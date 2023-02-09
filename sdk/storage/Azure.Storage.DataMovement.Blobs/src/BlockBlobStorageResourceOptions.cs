// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for
    /// <see cref="BlockBlobStorageResourceOptions"/>.
    /// </summary>
    public class BlockBlobStorageResourceOptions
    {
        /// <summary>
        /// Optional. Defines the copy operation to take.
        /// See <see cref="TransferCopyMethod"/>. Defaults to <see cref="TransferCopyMethod.SyncCopy"/>.
        ///
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public TransferCopyMethod CopyMethod { get; set; }

        /// <summary>
        /// Optional. Defines custom metadata to set for this block blob.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set on the destination blob.
        /// Not valid if <see cref="CopySourceTagsMode"/> is set to <see cref="BlobCopySourceTagsMode.Copy"/>.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. See <see cref="AccessTier"/>.
        /// Indicates the tier to be set on the blob.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional. See <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source storage resource blob.
        ///
        /// This optional property will be applied to copy and download scenarios.
        /// Only applies when calling
        /// <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.ReadStreamAsync(long, long?, System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// the copying of data to this blob.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.</summary>
        public BlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional. See <see cref="RehydratePriority"/>
        /// Indicates the priority with which to rehydrate an archived blob.
        ///
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
        /// and when <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.AsyncCopy"/>.
        /// </summary>
        public RehydratePriority? RehydratePriority { get; set; }

        /// <summary>
        /// Optional. See <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies to
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// Will also apply when calling
        /// <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
        /// and when <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.AsyncCopy"/>.
        /// </summary>
        public BlobImmutabilityPolicy DestinationImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional. Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        ///
        /// This optional property will be applied to copy scenarios and upload scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>,
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional.
        /// If <see cref="BlobCopySourceTagsMode.Replace"/>, the tags on the destination blob will be set to <see cref="Tags"/>.
        /// If <see cref="BlobCopySourceTagsMode.Copy"/>, the tags on the source blob will be copied to the destination blob.
        /// Default is to replace.
        ///
        /// This optional property will be applied to copy scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobCopySourceTagsMode? CopySourceTagsMode { get; set; }

        /// <summary>
        /// The copy source blob properties behavior.  If true, the properties
        /// of the source blob will be copied to the new blob.  Default is true.
        ///
        /// This optional property will be applied to sync copy scenarios.
        /// Only applies when calling <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
        /// and when the <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.SyncCopy"/>.
        /// </summary>
        public bool? CopySourceBlobProperties { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new block blob.
        ///
        /// This optional property will be applied to copy and upload scenarios.
        /// Only applies to
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// Will also apply when calling
        /// <see cref="StorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
        /// and when the <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.SyncCopy"/>.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// This operation does not allow <see cref="UploadTransferValidationOptions.PrecalculatedChecksum"/>
        /// to be set.
        ///
        /// This optional property will applied to upload scenarios.
        /// Only applies to
        /// <see cref="StorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="StorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
        public UploadTransferValidationOptions UploadTransferValidationOptions { get; set; }

        /// <summary>
        /// Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// Set <see cref="DownloadTransferValidationOptions.AutoValidateChecksum"/> to false if you
        /// would like to skip SDK checksum validation and validate the checksum found
        /// in the <see cref="Response"/> object yourself.
        /// Range must be provided explicitly, stating a range withing Azure
        /// Storage size limits for requesting a transactional hash. See the
        /// <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob">
        /// REST documentation</a> for range limitation details.
        ///
        /// This optional property will applied to download scenarios.
        /// Only applies when calling
        /// <see cref="StorageResource.ReadStreamAsync(long, long?, System.Threading.CancellationToken)"/>.
        /// </summary>
        public DownloadTransferValidationOptions DownloadTransferValidationOptions { get; set; }
    }
}
