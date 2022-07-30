// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Optional parameters for Start Copy from URL.
    ///
    /// TODO: Reassess which options can be applied from the original BlobCopyFromUriOptions
    /// </summary>
    public class BlobFolderCopyFromUriOptions
    {
        /// <summary>
        /// Optional <see cref="AccessTier"/>
        /// Indicates the tier to be set on the blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

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
        /// Optional.  Source authentication used to access the source blob.
        /// Note that is parameter does not apply to
        /// <see cref="BlobBaseClient.StartCopyFromUriAsync(System.Uri, BlobCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional. Indicates progress handling for specific
        /// </summary>
        public IProgress<BlobFolderCopyProgress> ProgressHandler { get; set; }

        /// <summary>
        /// If a blob gets transferred successfully the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobSingleCopyCompletedEventArgs> CopyCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobSingleCopyCompletedEventArgs> GetCopyCompleted() => CopyCompletedEventHandler;

        /// <summary>
        /// If a directory gets transferred successfully the event will get added to this handler.
        /// When all blobs are transferred in the respective directory an event argument will be added to this event handler.
        ///
        /// Empty directories cannot be transferred because empty directories do not exist in a flat namespace, therfore will not be included in this count
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderCopyCompletedEventArgs> FolderCopyCompletedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderCopyCompletedEventArgs> GetFolderCompleted() => FolderCopyCompletedEventHandler;

        /// <summary>
        /// If a blob transfer fails, the event will get added to this handler
        /// </summary>
        public event SyncAsyncEventHandler<BlobSingleCopyFailedEventArgs> CopyFailedEventHandler;

        internal SyncAsyncEventHandler<BlobSingleCopyFailedEventArgs> GetDownloadFailed() => CopyFailedEventHandler;

        /// <summary>
        /// If a directory transfer fails, the event will get added to this handler.
        /// This is due to either due to access one of any blobs in the directory or to transfer all the blobs in the directory.
        ///
        /// Empty directories cannot be transferred because empty directories do not exist in a flat namespace, therefore will not be included in this count
        /// </summary>
        public event SyncAsyncEventHandler<BlobFolderCopyFailedEventArgs> FolderCopyFailedEventHandler;
        internal SyncAsyncEventHandler<BlobFolderCopyFailedEventArgs> GetFolderFailed() => FolderCopyFailedEventHandler;

        /// <summary>
        /// If the transfer status of the job changes then the event will get added to this handler.
        /// </summary>
        public event SyncAsyncEventHandler<StorageTransferStatusEventArgs> TransferStatusEventHandler;
        internal SyncAsyncEventHandler<StorageTransferStatusEventArgs> GetTransferStatus() => TransferStatusEventHandler;
    }
}
