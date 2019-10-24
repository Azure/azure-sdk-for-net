// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class PartitionedDownloader
    {
        private readonly BlobBaseClient _client;

        private readonly long _singleBlockThreshold;

        private readonly int _blockSize;
        private readonly int _threadCount;

        public PartitionedDownloader(BlobBaseClient client, StorageTransferOptions transferOptions = default, long? singleBlockThreshold = null)
        {
            _client = client;
            _singleBlockThreshold = singleBlockThreshold ?? Constants.Blob.Block.MaxUploadBytes;
            _threadCount =
                transferOptions.MaximumConcurrency ?? Constants.Blob.Block.DefaultConcurrentTransfersCount;
            _blockSize =
                Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferLength ?? Constants.DefaultBufferSize
                );
        }

        public async Task<Response<BlobProperties>> DownloadToAsync(Stream stream, BlobRequestConditions conditions, CancellationToken cancellationToken)
        {
            Response<BlobProperties> properties = await _client.GetPropertiesAsync(conditions, cancellationToken).ConfigureAwait(false);

            long length = properties.Value.ContentLength;
            ETag etag = properties.Value.ETag;

            if (length == 0)
            {
                return properties;
            }

            if (length <= _singleBlockThreshold)
            {
                using BlobDownloadInfo downloadAsync = await _client.DownloadAsync(cancellationToken).ConfigureAwait(false);
                await CopyToAsync(downloadAsync, stream, cancellationToken).ConfigureAwait(false);
                return properties;
            }

            Queue<Task<Response<BlobDownloadInfo>>> runningTasks = new Queue<Task<Response<BlobDownloadInfo>>>();

            BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

            async Task ConsumeQueuedTask()
            {
                using BlobDownloadInfo result = await runningTasks.Dequeue().ConfigureAwait(false);
                await CopyToAsync(result, stream, cancellationToken).ConfigureAwait(false);
            }

            foreach (HttpRange httpRange in GetRanges(length))
            {
                Task<Response<BlobDownloadInfo>> task = _client.DownloadAsync(httpRange, conditionsWithEtag, rangeGetContentHash: false, cancellationToken);

                runningTasks.Enqueue(task);

                if (runningTasks.Count < _threadCount)
                {
                    continue;
                }

                await ConsumeQueuedTask().ConfigureAwait(false);
            }

            while (runningTasks.Count > 0)
            {
                await ConsumeQueuedTask().ConfigureAwait(false);
            }

            return properties;
        }

        public Response<BlobProperties> DownloadTo(Stream stream, BlobRequestConditions conditions, CancellationToken cancellationToken)
        {
            Response<BlobProperties> properties = _client.GetProperties(conditions, cancellationToken);

            long length = properties.Value.ContentLength;
            ETag etag = properties.Value.ETag;

            if (length == 0)
            {
                return properties;
            }

            if (length <= _singleBlockThreshold)
            {
                using BlobDownloadInfo downloadAsync = _client.Download(cancellationToken);
                CopyTo(downloadAsync, stream, cancellationToken);
                return properties;
            }

            BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

            foreach (HttpRange httpRange in GetRanges(length))
            {
                BlobDownloadInfo result = _client.Download(httpRange, conditionsWithEtag, rangeGetContentHash: false, cancellationToken);

                CopyTo(result, stream, cancellationToken);
            }

            return properties;
        }

        private static BlobRequestConditions CreateConditionsWithEtag(BlobRequestConditions conditions, ETag etag)
        {
            BlobRequestConditions conditionsWithEtag = new BlobRequestConditions()
            {
                LeaseId = conditions?.LeaseId,
                IfMatch = conditions?.IfMatch ?? etag,
                IfNoneMatch = conditions?.IfNoneMatch,
                IfModifiedSince = conditions?.IfModifiedSince,
                IfUnmodifiedSince = conditions?.IfUnmodifiedSince
            };
            return conditionsWithEtag;
        }

        private static async Task CopyToAsync(BlobDownloadInfo result, Stream stream, CancellationToken cancellationToken)
        {
            await result.Content.CopyToAsync(stream, 8096, cancellationToken).ConfigureAwait(false);
        }

        private static void CopyTo(BlobDownloadInfo result, Stream stream, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            result.Content.CopyTo(stream, 8096);
        }

        private IEnumerable<HttpRange> GetRanges(long length)
        {
            for (long i = 0; i < length; i += _blockSize)
            {
                yield return new HttpRange(i, Math.Min(length - i, _blockSize));
            }
        }
    }
}
