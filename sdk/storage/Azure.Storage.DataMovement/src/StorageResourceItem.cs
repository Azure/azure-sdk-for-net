// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Abstract class for a single storage resource.
    /// </summary>
    public abstract class StorageResourceItem : StorageResource
    {
        /// <summary>
        /// For Mocking.
        /// </summary>
        protected StorageResourceItem() { }

        /// <summary>
        /// The identifier for the type of storage resource.
        /// </summary>
        protected internal abstract string ResourceId { get; }

        /// <summary>
        /// Defines the transfer type of the storage resource.
        /// </summary>
        protected internal abstract DataTransferOrder TransferType { get; }

        /// <summary>
        /// Defines the maximum supported chunk size for the storage resource.
        /// </summary>
        protected internal abstract long MaxSupportedChunkSize { get; }

        /// <summary>
        /// Storage Resource is a container.
        /// </summary>
        protected internal override bool IsContainer => false;

        /// <summary>
        /// Length of the storage resource. This information is can obtained during a GetStorageResources API call.
        ///
        /// Will return default if the length was not set by a GetStorageResources API call.
        /// </summary>
        protected internal abstract long? Length { get; }

        /// <summary>
        /// Properties of the Storage Resource Item.
        /// </summary>
        protected StorageResourceItemProperties ResourceProperties { get; set; }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected internal abstract Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="streamLength">
        /// The length of the stream.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the resource item.
        /// </param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected internal abstract Task CopyFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long completeLength,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected internal abstract Task CopyFromUriAsync(
            StorageResourceItem sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="range"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns></returns>
        protected internal abstract Task CopyBlockFromUriAsync(
            StorageResourceItem sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceItemProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Storage Resource. See <see cref="StorageResourceItemProperties"/></returns>
        protected internal abstract Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken token = default);

        /// <summary>
        /// Gets the Authorization Header for the storage resource if available.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// Gets the HTTP Authorization header for the storage resource if available. If not available
        /// will return default.
        /// </returns>
        protected internal abstract Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// If the operation requires any ending transfers (e.g. Committing a block list, flushing crypto streams)
        /// </summary>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeTransferOptions">
        /// Optional parameters.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The Task which Commits the list of ids</returns>
        protected internal abstract Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the respective storage resource.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// If the storage resource exists and is deleted, true will be returned.
        /// Otherwise if the storage resource does not exist, false will be returned.
        /// </returns>
        protected internal abstract Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default);
    }
}
