// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Represents abstract Storage Resource
    /// </summary>
    public abstract class StorageResource
    {
        internal TokenCredential _tokenCredential;

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
        public abstract string Path { get; }

        /// <summary>
        /// If applicable, returns the preferred method of how to perform service to service
        /// transfers. See <see cref="TransferCopyMethod"/>. This value can be set when specifying
        /// the options bag for service related storage resources.
        /// </summary>
        public abstract TransferCopyMethod ServiceCopyMethod { get; }

        /// <summary>
        /// Defines whether the object can generate a URL to consume
        /// </summary>
        /// <returns></returns>
        public abstract ProduceUriType CanProduceUri { get; }

        /// <summary>
        /// Produces readable stream to download
        /// </summary>
        /// <returns></returns>
        public abstract Task<ReadStreamStorageResourceResult> ReadStreamAsync(
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
        public abstract Task<ReadStreamStorageResourceResult> ReadPartialStreamAsync(
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
            StorageResourceWriteToOffsetOptions options,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CopyFromUriAsync(
            StorageResource sourceResource,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="range"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
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
