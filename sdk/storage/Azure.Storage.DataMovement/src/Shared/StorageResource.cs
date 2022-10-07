// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public abstract Stream ReadableInputStream();

        /// <summary>
        /// Produces writable stream to upload
        /// </summary>
        /// <returns></returns>
        public abstract Stream ConsumableStream();

        /// <summary>
        /// Get length of blob
        /// </summary>
        /// <returns></returns>
        /// internal abstract Task long? GetLength();

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public abstract Task ConsumeReadableStream(Stream stream, CancellationToken token);

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
        /// Defines whether the object can consume a readable stream and upload it
        /// </summary>
        /// <returns></returns>
        public abstract StreamConsumableType CanConsumeReadableStream();

        /// <summary>
        /// defines whether the object can generate a URL to consume
        /// </summary>
        /// <returns></returns>
        public abstract ProduceUriType CanProduceUri();
    }
}
