// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    public class LocalFileStorageResource : StorageResource
    {
        private string _path;

        /// <summary>
        /// Returns URL
        /// </summary>
        /// <returns></returns>
        public override Uri Uri => throw new NotSupportedException();

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public override string Path => _path;

        /// <summary>
        /// Cannot return a Url because this is a local path.
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri => ProduceUriType.NoUri;

        /// <summary>
        /// Cannot perform service to service copies. This respective resource is a local resource.
        /// </summary>
        public override TransferCopyMethod ServiceCopyMethod => TransferCopyMethod.None;

        /// <summary>
        /// Defines the recommended Transfer Type of the resource
        /// </summary>
        public override TransferType TransferType => TransferType.Sequential;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        /// TODO: consider changing this.
        public override long MaxChunkSize => Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Creates the local file.
        /// </summary>
        /// <param name="overwrite"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task CreateAsync(
            bool overwrite,
            long size = 0,
            CancellationToken cancellationToken = default)
        {
            if (overwrite || !File.Exists(_path))
            {
                File.Create(_path).Close();
                FileAttributes attributes = File.GetAttributes(_path);
                File.SetAttributes(_path, attributes | FileAttributes.Temporary);
                return Task.CompletedTask;
            }
            // TODO: maybe better exception type?
            throw new IOException($"File path `{_path}` already exists. Cannot overwite file");
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ReadStreamStorageResourceResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            stream.Position = position;
            return Task.FromResult(new ReadStreamStorageResourceResult(stream));
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="length"></param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            bool overwrite,
            long position = 0,
            long? length = default,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // Appends incoming stream to the local file resource
            using (FileStream fileStream = new FileStream(
                    _path,
                    FileMode.OpenOrCreate,
                    FileAccess.Write))
            {
                if (position > 0)
                {
                    fileStream.Seek(position, SeekOrigin.Begin);
                }
                await stream.CopyToAsync(
                    fileStream,
                    (int) length,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task CopyFromUriAsync(
            StorageResource sourceResource,
            bool overwrite,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Uploads/copy the blob from a url
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="range"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            bool overwrite,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            FileInfo fileInfo = new FileInfo(_path);
            if (fileInfo.Exists)
            {
                return Task.FromResult(fileInfo.ToStorageResourceProperties());
            }
            return Task.FromResult<StorageResourceProperties>(default);
        }

        /// <summary>
        /// Completes the transfer if the resource resides locally.
        ///
        /// If the transfer requires client-side encryption, necessary
        /// operations will occur here.
        /// </summary>
        public override Task CompleteTransferAsync(CancellationToken cancellationToken = default)
        {
            if (File.Exists(_path))
            {
                // Make file visible
                FileAttributes attributes = File.GetAttributes(_path);
                File.SetAttributes(_path, attributes | FileAttributes.Normal);
            }
            return Task.CompletedTask;
        }
    }
}
