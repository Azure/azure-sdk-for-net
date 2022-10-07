// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    internal class LocalFileStorageResource : StorageResource
    {
        private List<string> _path;
        private string _originalPath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            _originalPath = path;
            _path = path.Split('/').ToList();
        }

        /// <summary>
        /// Cannot consume readable stream
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override StreamConsumableType CanConsumeReadableStream()
        {
            return StreamConsumableType.Consumable;
        }

        /// <summary>
        /// Can produce URL
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ProduceUriType CanProduceUri()
        {
            return ProduceUriType.ProducesUri;
        }

        /// <summary>
        /// Cannot produce consumable stream, will throw a NotSupportException.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Stream ConsumableStream()
        {
            // Cannot produce consumable stream
            throw new NotSupportedException();
        }

        /// <summary>
        /// Cannot consume readable stream, will throw a NotSupportedException.
        /// </summary>
        /// <param name="stream">Stream to append to the local file</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public override async Task ConsumeReadableStream(Stream stream, CancellationToken token = default)
        {
            // Appends incoming stream to the local file resource
            using (FileStream fileStream = new FileStream(
                    _originalPath,
                    FileMode.Append,
                    FileAccess.Write))
            {
                await stream.CopyToAsync(
                    fileStream,
                    Constants.DefaultDownloadCopyBufferSize,
                    token)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Cannot produce URL
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Task ConsumeUri(Uri uri)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get length of the file
        /// </summary>
        /// <returns>Returns the lenght of the local file, however if the local file does not exist default will be returned.</returns>
        internal Task<long?> GetLength()
        {
            FileInfo fileInfo = new FileInfo(_originalPath);

            if (fileInfo.Exists)
            {
                return Task.FromResult<long?>(fileInfo.Length);
            }
            // File does not exist, no length.
            return Task.FromResult<long?>(default);
        }

        /// <summary>
        /// Get Path of the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override List<string> GetPath()
        {
            return _path;
        }

        /// <summary>
        /// Get the Uri
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Uri GetUri()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the readable input stream
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Stream ReadableInputStream()
        {
            return new FileStream(_originalPath, FileMode.Open, FileAccess.Read);
        }
    }
}
