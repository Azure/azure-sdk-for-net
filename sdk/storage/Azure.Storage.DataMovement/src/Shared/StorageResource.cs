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
        /// For Mocking
        /// </summary>
        protected StorageResource() { }

        /// <summary>
        /// Produces readable stream to download
        /// </summary>
        /// <returns></returns>
        public abstract Stream GetReadableInputStream();

        /// <summary>
        /// Produces writable stream to upload
        /// </summary>
        /// <returns></returns>
        public abstract Stream GetConsumableStream();

        /// <summary>
        /// Defines whether the object can consume a readable stream and upload it
        /// </summary>
        /// <returns></returns>
        public abstract StreamConsumableType CanConsumeReadableStream();

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task ConsumeReadableStream(
            Stream stream,
            ConsumeReadableStreamOptions options,
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
        public abstract Task ConsumePartialOffsetReadableStream(
            long offset,
            long length,
            Stream stream,
            ConsumePartialReadableStreamOptions options,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Defines whether the object can generate a URL to consume
        /// </summary>
        /// <returns></returns>
        public abstract ProduceUriType CanProduceUri();

        /// <summary>
        /// Returns URL with SAS
        /// </summary>
        /// <returns></returns>
        public abstract Uri GetUri();

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sasUri"></param>
        /// <returns></returns>
        public abstract Task ConsumeUri(Uri sasUri);

        /// <summary>
        /// returns path split up
        /// </summary>
        /// <returns></returns>
        public abstract List<string> GetPath();

        /// <summary>
        /// Get lengths of the resource.
        /// </summary>
        /// <returns>Returns the properties of the storage resource</returns>
        public abstract Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token);

        /// <summary>
        /// Determines whether or not the resource requires a commit block list (e.g. Commit Block List)
        /// to determine which blocks will make up the resource.
        /// </summary>
        /// <returns><see cref="CanCommitListType"/></returns>
        public abstract CanCommitListType CanCommitBlockListType();

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        /// <returns>The Task which Commits the list of ids</returns>
        public abstract Task CommitBlockList(IEnumerable<string> base64BlockIds, CancellationToken cancellationToken);
    }
}
