// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    internal class LocalFileStorageResource : StorageResourceItem
    {
        private Uri _uri;

        protected internal override string ResourceId => "LocalFile";

        public override Uri Uri => _uri;

        public override string ProviderId => "local";

        protected internal override TransferOrder TransferType => TransferOrder.Sequential;

        protected internal override long MaxSupportedSingleTransferSize => Constants.Blob.Block.MaxStageBytes;

        protected internal override long MaxSupportedChunkSize => Constants.Blob.Block.MaxStageBytes;

        protected internal override int MaxSupportedChunkCount => int.MaxValue;

        protected internal override long? Length => default;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            Argument.AssertNotNullOrWhiteSpace(path, nameof(path));
            _uri = PathScanner.GetEncodedUriFromPath(path);
        }

        /// <summary>
        /// Internal Constructor for uri
        /// </summary>
        /// <param name="uri"></param>
        internal LocalFileStorageResource(Uri uri)
        {
            Argument.AssertNotNull(uri, nameof(uri));
            Argument.AssertNotNullOrWhiteSpace(uri.AbsoluteUri, nameof(uri));
            _uri = uri;
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
        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            FileStream stream = new FileStream(_uri.LocalPath, FileMode.Open, FileAccess.Read);
            stream.Position = position;
            return Task.FromResult(new StorageResourceReadStreamResult(stream));
        }

        /// <summary>
        /// Creates the local file.
        /// </summary>
        /// <param name="overwrite"></param>
        internal void Create(bool overwrite)
        {
            if (overwrite || !File.Exists(_uri.LocalPath))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_uri.LocalPath));
                File.Create(_uri.LocalPath).Close();
                FileAttributes attributes = File.GetAttributes(_uri.LocalPath);
                File.SetAttributes(_uri.LocalPath, attributes | FileAttributes.Temporary);
            }
            else
            {
                throw Errors.LocalFileAlreadyExists(_uri.LocalPath);
            }
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="streamLength">
        /// The length of the stream.
        /// </param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the resource item.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override async Task CopyFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long completeLength,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            long position = options?.Position != default ? options.Position.Value : 0;
            if (options?.Initial == true)
            {
                Create(overwrite);
            }
            if (streamLength > 0)
            {
                // Appends incoming stream to the local file resource
                using (FileStream fileStream = new FileStream(
                    _uri.LocalPath,
                    FileMode.Open,
                    FileAccess.Write))
                {
                    if (position > 0)
                    {
                        fileStream.Seek(position, SeekOrigin.Begin);
                    }

                    int bufferSize = Math.Min((int)streamLength, DataMovementConstants.DefaultStreamCopyBufferSize);
                    await stream.CopyToAsync(fileStream, bufferSize, cancellationToken).ConfigureAwait(false);
                }
            }
        }

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override Task CopyFromUriAsync(
            StorageResourceItem sourceResource,
            bool overwrite,
            long completeLength,
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
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected internal override Task CopyBlockFromUriAsync(
            StorageResourceItem sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get properties of the resource.
        ///
        /// See <see cref="StorageResourceItemProperties"/>.
        /// </summary>
        /// <returns>Returns the properties of the Local File Storage Resource. See <see cref="StorageResourceItemProperties"/></returns>
        protected internal override Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            FileInfo fileInfo = new FileInfo(_uri.LocalPath);
            if (fileInfo.Exists)
            {
                StorageResourceItemProperties properties = fileInfo.ToStorageResourceProperties();
                return Task.FromResult(properties);
            }
            throw new FileNotFoundException();
        }

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
        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Completes the transfer if the resource resides locally.
        ///
        /// If the transfer requires client-side encryption, necessary
        /// operations will occur here.
        /// </summary>
        protected internal override Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions = default,
            CancellationToken cancellationToken = default)
        {
            if (File.Exists(_uri.LocalPath))
            {
                // Make file visible
                FileAttributes attributes = File.GetAttributes(_uri.LocalPath);
                File.SetAttributes(_uri.LocalPath, attributes | FileAttributes.Normal);
            }
            return Task.CompletedTask;
        }

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
        protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            if (File.Exists(_uri.LocalPath))
            {
                File.Delete(_uri.LocalPath);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new LocalSourceCheckpointDetails();
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new LocalDestinationCheckpointDetails();
        }

        // no-op for get permissions
        protected internal override Task<string> GetPermissionsAsync(
            StorageResourceItemProperties properties = default,
            CancellationToken cancellationToken = default)
            => Task.FromResult((string)default);

        // no-op for set permissions
        protected internal override Task SetPermissionsAsync(
            StorageResourceItem sourceResource,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken = default)
            => Task.CompletedTask;
    }
}
