// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Storage Resource
    /// </summary>
    public class BlockBlobStorageResource : StorageResource
    {
        private BlockBlobClient _blobClient;
        /// <summary>
        /// In order to ensure the block list is sent in the correct order
        /// we will order them by the offset. {offset, block_id}
        /// </summary>
        private ConcurrentDictionary<long, string> _blocks;
        private BlockBlobStorageResourceOptions _options;

        /// <summary>
        /// Returns URL
        /// </summary>
        /// <returns></returns>
        public override Uri Uri => _blobClient.Uri;

        /// <summary>
        /// Gets the path of the resource.
        /// </summary>
        public override string Path => _blobClient.Name;

        /// <summary>
        /// Defines whether the object can produce a SAS URL
        /// </summary>
        /// <returns></returns>
        public override ProduceUriType CanProduceUri => ProduceUriType.ProducesUri;

        /// <summary>
        /// Returns the preferred method of how to perform service to service
        /// transfers. See <see cref="TransferCopyMethod"/>. This value can be set when specifying
        /// the options bag, see <see cref="BlockBlobStorageResourceServiceCopyOptions.CopyMethod"/> in
        /// <see cref="BlockBlobStorageResourceOptions.CopyOptions"/>.
        /// </summary>
        public override TransferCopyMethod ServiceCopyMethod => _options?.CopyOptions?.CopyMethod ?? TransferCopyMethod.SyncCopy;

        /// <summary>
        /// Defines the recommended Transfer Type of the resource
        /// </summary>
        public override TransferType TransferType => TransferType.Concurrent;

        /// <summary>
        /// Defines the maximum chunk size for the storage resource.
        /// </summary>
        public override long MaxChunkSize => Constants.Blob.Block.MaxStageBytes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        public BlockBlobStorageResource(
            BlockBlobClient blobClient,
            BlockBlobStorageResourceOptions options = default)
        {
            _blobClient = blobClient;
            _blocks = new ConcurrentDictionary<long, string>();
            _options = options;
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position">
        /// The offset which the stream will be copied to. Will default to 0.
        /// </param>
        /// <param name="length">
        /// The length of the stream.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<ReadStreamStorageResourceResult> ReadStreamAsync(
            long position = 0,
            long? length = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<BlobDownloadStreamingResult> response = await _blobClient.DownloadStreamingAsync(
                new BlobDownloadOptions()
                {
                    Range = new HttpRange(position, length)
                },
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToReadStreamStorageResourceInfo();
        }

        /// <summary>
        /// Consumes the readable stream to upload
        /// </summary>
        /// <param name="position"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="streamLength">
        /// The length of the stream.
        /// </param>
        /// <param name="completeLength">
        /// The expected complete length of the blob.
        /// </param>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task WriteFromStreamAsync(
            Stream stream,
            bool overwrite,
            long position = 0,
            long? streamLength = default,
            long completeLength = 0,
            StorageResourceWriteToOffsetOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                // TODO: copy over the other conditions from the uploadOptions
                IfNoneMatch = overwrite ? null : new ETag(Constants.Wildcard),
            };
            if ((streamLength == completeLength) && position == 0)
            {
                // Default to Upload
                await _blobClient.UploadAsync(
                    stream,
                    new BlobUploadOptions()
                    {
                        Conditions = conditions,
                    },
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return;
            }

            string id = Shared.StorageExtensions.GenerateBlockId(position);
            if (!_blocks.TryAdd(position, id))
            {
                throw new ArgumentException($"Cannot Stage Block to the specific offset \"{position}\", it already exists in the block list.");
            }
            await _blobClient.StageBlockAsync(
                id,
                stream,
                new BlockBlobStageBlockOptions()
                {
                    Conditions = conditions,
                },
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Consumes blob Url to upload / copy
        /// </summary>
        /// <param name="sourceResource"></param>
        /// <param name="overwrite">
        /// If set to true, will overwrite the blob if exists.
        /// </param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CopyFromUriAsync(
            StorageResource sourceResource,
            bool overwrite,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (ServiceCopyMethod == TransferCopyMethod.AsyncCopy)
            {
                await _blobClient.StartCopyFromUriAsync(sourceResource.Uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else //(ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                // We use SyncUploadFromUri over SyncCopyUploadFromUri in this case because it accepts any blob type as the source.
                // TODO: subject to change as we scale to suppport resource types outside of blobs.
                await _blobClient.SyncUploadFromUriAsync(sourceResource.Uri, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
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
        public override async Task CopyBlockFromUriAsync(
            StorageResource sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength = 0,
            StorageResourceCopyFromUriOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (ServiceCopyMethod == TransferCopyMethod.SyncCopy)
            {
                BlobRequestConditions conditions = new BlobRequestConditions
                {
                    // TODO: copy over the other conditions from the uploadOptions
                    IfNoneMatch = overwrite ? null : new ETag(Constants.Wildcard),
                };
                string id = options?.BlockId ?? Shared.StorageExtensions.GenerateBlockId(range.Offset);
                if (!_blocks.TryAdd(range.Offset, id))
                {
                    throw new ArgumentException($"Cannot Stage Block to the specific offset \"{range.Offset}\", it already exists in the block list");
                }
                await _blobClient.StageBlockFromUriAsync(
                    sourceResource.Uri,
                    id,
                    options: new StageBlockFromUriOptions()
                    {
                        SourceRange = range,
                        DestinationConditions = conditions
                    },
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                throw new NotSupportedException("TransferCopyMethod specified is not supported in this resource");
            }
        }

        /// <summary>
        /// Get properties of the resource.
        /// </summary>
        /// <returns>Returns the length of the storage resource</returns>
        public override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            BlobProperties properties = await _blobClient.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return properties.ToStorageResourceProperties();
        }

        /// <summary>
        /// Commits the block list given.
        /// </summary>
        public override async Task CompleteTransferAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            if (_blocks != null && !_blocks.IsEmpty)
            {
                IEnumerable<string> blockIds = _blocks.OrderBy(x => x.Key).Select(x => x.Value);
                await _blobClient.CommitBlockListAsync(
                    blockIds,
                    default,
                    cancellationToken).ConfigureAwait(false);
                _blocks.Clear();
            }
        }
    }
}
