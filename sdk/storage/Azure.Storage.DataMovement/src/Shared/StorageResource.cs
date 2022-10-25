// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Represents abstract Storage Resource
    /// </summary>
    public abstract class StorageResource
    {
        /// <summary>
        /// For Mocking.
        /// </summary>
        protected StorageResource() { }

        /// <summary>
        /// Returns URL.
        /// </summary>
        /// <returns></returns>
        public abstract Uri Uri { get; }

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public abstract List<string> Path { get; }

        /// <summary>
        /// Defines whether the object can generate a URL to consume
        /// </summary>
        /// <returns></returns>
        public abstract ProduceUriType CanProduceUri { get; }

        /// <summary>
        /// Determines whether or not the resource requires a commit block list (e.g. Commit Block List)
        /// to determine which blocks will make up the resource.
        /// </summary>
        /// <returns><see cref="RequiresCompleteTransferType"/></returns>
        public abstract RequiresCompleteTransferType RequiresCompleteTransfer { get; }

        /// <summary>
        /// Produces readable stream to download
        /// </summary>
        /// <returns></returns>
        public abstract Task<ReadStreamStorageResourceInfo> ReadStreamAsync(
            long? position = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="offset">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task<ReadStreamStorageResourceInfo> ReadPartialStreamAsync(
            long offset,
            long length,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task WriteFromStreamAsync(
            Stream stream,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="offset">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task WriteStreamToOffsetAsync(
            long offset,
            long length,
            Stream stream,
            WriteToOffsetOptions options,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceUri"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CopyFromUriAsync(
            Uri sourceUri,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceUri"></param>
        /// <param name="range"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CopyBlockFromUriAsync(
            Uri sourceUri,
            HttpRange range,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get lengths of the resource.
        /// </summary>
        /// <returns>Returns the properties of the storage resource</returns>
        public abstract Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token);

        /// <summary>
        /// If the operation requires any ending transfers (e.g. Committing a block list, flushing crypto streams)
        /// </summary>
        /// <returns>The Task which Commits the list of ids</returns>
        public abstract Task CompleteTransferAsync(CancellationToken cancellationToken);
    }
}
