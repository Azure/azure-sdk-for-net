// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    public class LocalFileStorageResource : StorageResource
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
        /// Cannot produce URL
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ProduceUriType CanProduceUri()
        {
            return ProduceUriType.NoUri;
        }

        /// <summary>
        /// Cannot produce consumable stream, will throw a NotSupportException.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Stream GetConsumableStream()
        {
            // Cannot produce consumable stream
            throw new NotSupportedException();
        }

        /// <summary>
        /// Can consume stream. Will append stream to end of file.
        /// Will create file if it doesn't already exist.
        /// </summary>
        /// <param name="stream">Stream to append to the local file</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public override async Task ConsumeReadableStream(
            Stream stream,
            CancellationToken token = default)
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
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task ConsumePartialReadableStream(
            long offset,
            long length,
            Stream stream,
            ConsumePartialReadableStreamOptions options,
            CancellationToken cancellationToken = default)
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
                    cancellationToken)
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
        /// Gets the readable input stream.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Stream GetReadableInputStream()
        {
            return new FileStream(_originalPath, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken)
        {
            FileInfo fileInfo = new FileInfo(_originalPath);
            if (fileInfo.Exists)
            {
                return Task.FromResult(fileInfo.ToStorageResourceProperties());
            }
            return Task.FromResult<StorageResourceProperties>(default);
        }

        /// <summary>
        /// Does not require Commit List operation.
        /// </summary>
        /// <returns></returns>
        public override RequiresCommitListType CanCommitBlockListType()
        {
            return RequiresCommitListType.None;
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override Task CommitBlockList(IEnumerable<string> base64BlockIds, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
