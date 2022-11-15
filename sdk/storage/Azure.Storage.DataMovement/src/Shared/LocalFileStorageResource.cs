﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Can consume stream. Will append stream to end of file.
        /// Will create file if it doesn't already exist.
        /// </summary>
        /// <param name="stream">Stream to append to the local file</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            CancellationToken token = default)
        {
            // Appends incoming stream to the local file resource
            using (FileStream fileStream = new FileStream(
                    _path,
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
        public override async Task WriteStreamToOffsetAsync(
            long offset,
            long length,
            Stream stream,
            StorageResourceWriteToOffsetOptions options,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // Appends incoming stream to the local file resource
            using (FileStream fileStream = new FileStream(
                    _path,
                    FileMode.OpenOrCreate,
                    FileAccess.Write))
            {
                fileStream.Seek(offset, SeekOrigin.Begin);
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
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task CopyFromUriAsync(
            StorageResource sourceResource,
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
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get length of the file
        /// </summary>
        /// <returns>Returns the lenght of the local file, however if the local file does not exist default will be returned.</returns>
        internal Task<long?> GetLength()
        {
            FileInfo fileInfo = new FileInfo(_path);

            if (fileInfo.Exists)
            {
                return Task.FromResult<long?>(fileInfo.Length);
            }
            // File does not exist, no length.
            return Task.FromResult<long?>(default);
        }

        /// <summary>
        /// Gets the readable input stream.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<ReadStreamStorageResourceInfo> ReadStreamAsync(
            long? position = default,
            CancellationToken cancellationToken = default)
        {
            FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            return Task.FromResult(new ReadStreamStorageResourceInfo(stream));
        }

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
        public override Task<ReadStreamStorageResourceInfo> ReadPartialStreamAsync(
            long offset,
            long length,
            CancellationToken cancellationToken = default)
        {
            FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read);
            stream.Position = offset;
            return Task.FromResult(new ReadStreamStorageResourceInfo(stream));
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken)
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
        public override Task CompleteTransferAsync(CancellationToken cancellationToken)
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
