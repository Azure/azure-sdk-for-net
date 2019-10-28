// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly int _workerCount;

        public PartitionedDownloader(BlobBaseClient client, StorageTransferOptions transferOptions = default, long? singleBlockThreshold = null)
        {
            _client = client;
            _singleBlockThreshold = singleBlockThreshold ?? Constants.Blob.Block.MaxUploadBytes;
            _workerCount =
                transferOptions.MaximumConcurrency ?? Constants.Blob.Block.DefaultConcurrentTransfersCount;
            _blockSize =
                Math.Min(
                    Constants.Blob.Block.MaxStageBytes,
                    transferOptions.MaximumTransferLength ?? Constants.DefaultBufferSize
                );
        }

        private static long ParseLength(string s)
        {
            int lengthSeparator = s.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);

            if (lengthSeparator == -1)
            {
                Errors.ParsingHttpRangeFailed();
            }

            return long.Parse(s.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        public async Task<Response<BlobProperties>> DownloadToAsync(Stream stream, BlobRequestConditions conditions, CancellationToken cancellationToken)
        {
            var initialRange = new HttpRange(0, _singleBlockThreshold);

            Task<Response<BlobDownloadInfo>> initialResponseTask = _client.DownloadAsync(initialRange, conditions, rangeGetContentHash: false, cancellationToken);
            Response<BlobDownloadInfo> initialRequest = await initialResponseTask.ConfigureAwait(false);

            long initialLength = initialRequest.Value.ContentLength;
            long totalLength = ParseLength(initialRequest.Value.Details.ContentRange);
            ETag etag = initialRequest.Value.Details.ETag;
            Response<BlobProperties> properties = CreateProperties(initialRequest, totalLength);

            if (initialLength == totalLength)
            {
                await CopyToAsync(initialRequest, stream, cancellationToken).ConfigureAwait(false);
                return properties;
            }

            Queue<Task<Response<BlobDownloadInfo>>> runningTasks = new Queue<Task<Response<BlobDownloadInfo>>>();
            runningTasks.Enqueue(initialResponseTask);

            BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

            async Task ConsumeQueuedTask()
            {
                using BlobDownloadInfo result = await runningTasks.Dequeue().ConfigureAwait(false);
                await CopyToAsync(result, stream, cancellationToken).ConfigureAwait(false);
            }

            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
            {
                Task<Response<BlobDownloadInfo>> task = _client.DownloadAsync(httpRange, conditionsWithEtag, rangeGetContentHash: false, cancellationToken);

                runningTasks.Enqueue(task);

                if (runningTasks.Count < _workerCount)
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

        private static Response<BlobProperties> CreateProperties(Response<BlobDownloadInfo> response, long totalLength)
        {
            return Response.FromValue(new BlobProperties()
            {
                ContentLength = totalLength,LastModified = response.Value.Details.LastModified,
                BlobType = response.Value.BlobType,
                Metadata = response.Value.Details.Metadata,
                CopyCompletedOn = response.Value.Details.CopyCompletedOn,
                CopyStatusDescription = response.Value.Details.CopyStatusDescription,
                CopyId = response.Value.Details.CopyId,
                CopyProgress = response.Value.Details.CopyProgress,
                CopySource = response.Value.Details.CopySource,
                CopyStatus = response.Value.Details.CopyStatus,
                LeaseDuration = response.Value.Details.LeaseDuration,
                LeaseState = response.Value.Details.LeaseState,
                LeaseStatus = response.Value.Details.LeaseStatus,
                ContentType = response.Value.ContentType,
                ETag = response.Value.Details.ETag,
                ContentHash = response.Value.ContentHash,
                ContentDisposition = response.Value.Details.ContentDisposition,
                CacheControl = response.Value.Details.CacheControl,
                BlobSequenceNumber = response.Value.Details.BlobSequenceNumber,
                AcceptRanges = response.Value.Details.AcceptRanges,
                BlobCommittedBlockCount = response.Value.Details.BlobCommittedBlockCount,
                IsServerEncrypted = response.Value.Details.IsServerEncrypted,
                EncryptionKeySha256 = response.Value.Details.EncryptionKeySha256,

                ContentEncoding = new string[] { response.Value.Details.ContentEncoding },
                ContentLanguage = new string[] { response.Value.Details.ContentLanguage },

                // TODO: These do not exist on BlobDownloadInfo
                //AccessTier = response.Value.Details.AccessTier,
                //AccessTierInferred = response.Value.Details.AccessTierInferred,
                //ArchiveStatus = response.Value.Details.ArchiveStatus,
                //AccessTierChangedOn = response.Value.Details.AccessTierChangedOn,
                //IsIncrementalCopy = response.Value.Details.IsIncrementalCopy,
                //DestinationSnapshot = response.Value.Details.DestinationSnapshot,
                //CreatedOn = response.Value.Details.CreatedOn,
            }, response.GetRawResponse());
        }

        public Response<BlobProperties> DownloadTo(Stream stream, BlobRequestConditions conditions, CancellationToken cancellationToken)
        {
            var initialRange = new HttpRange(0, _singleBlockThreshold);
            Response<BlobDownloadInfo> initialRequest = _client.Download(initialRange, conditions, rangeGetContentHash: false, cancellationToken);

            long initialLength = initialRequest.Value.ContentLength;
            long totalLength = ParseLength(initialRequest.Value.Details.ContentRange);
            ETag etag = initialRequest.Value.Details.ETag;

            Response<BlobProperties> properties = CreateProperties(initialRequest, totalLength);

            CopyTo(initialRequest, stream, cancellationToken);

            if (initialLength == totalLength)
            {
                return properties;
            }

            BlobRequestConditions conditionsWithEtag = CreateConditionsWithEtag(conditions, etag);

            foreach (HttpRange httpRange in GetRanges(initialLength, totalLength))
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

        private IEnumerable<HttpRange> GetRanges(long l, long length)
        {
            for (long i = l; i < length; i += _blockSize)
            {
                yield return new HttpRange(i, Math.Min(length - i, _blockSize));
            }
        }
    }
}
