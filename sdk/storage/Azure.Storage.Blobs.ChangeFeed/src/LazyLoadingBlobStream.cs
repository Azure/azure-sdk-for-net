// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class LazyLoadingBlobStream : Stream
    {
        /// <summary>
        /// BlobClient to make download calls with.
        /// </summary>
        private readonly BlobClient _blobClient;

        /// <summary>
        /// The offset within the blob of the next block we will download.
        /// </summary>
        private long _offset;

        /// <summary>
        /// The number of bytes we'll download with each download call.
        /// </summary>
        private readonly long _blockSize;

        /// <summary>
        /// Underlying Stream.
        /// </summary>
        private Stream _stream;

        /// <summary>
        /// If this LazyLoadingBlobStream has been initalized.
        /// </summary>
        private bool _initalized;

        /// <summary>
        /// The number of bytes in the last download call.
        /// </summary>
        private long _lastDownloadBytes;

        /// <summary>
        /// The current length of the blob.
        /// </summary>
        private long _blobLength;

        public LazyLoadingBlobStream(BlobClient blobClient, long offset, long blockSize)
        {
            _blobClient = blobClient;
            _offset = offset;
            _blockSize = blockSize;
            _initalized = false;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public LazyLoadingBlobStream() { }

        /// <inheritdoc/>
        public override int Read(
            byte[] buffer,
            int offset,
            int count)
            => ReadInternal(
                async: false,
                buffer,
                offset,
                count).EnsureCompleted();

        /// <inheritdoc/>
        public override async Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
            => await ReadInternal(
                async: true,
                buffer,
                offset,
                count,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Initalizes this LazyLoadingBlobStream.
        /// </summary>
        private async Task Initalize(bool async, CancellationToken cancellationToken)
        {
            await DownloadBlock(async, cancellationToken).ConfigureAwait(false);
            _initalized = true;
        }

        /// <summary>
        /// Downloads the next block.
        /// </summary>
        private async Task DownloadBlock(bool async, CancellationToken cancellationToken)
        {
            Response<BlobDownloadInfo> response;
            HttpRange range = new HttpRange(_offset, _blockSize);

            response = async
                ? await _blobClient.DownloadAsync(range, cancellationToken: cancellationToken).ConfigureAwait(false)
                : _blobClient.Download(range, cancellationToken: cancellationToken);
            _stream = response.Value.Content;
            _offset += response.Value.ContentLength;
            _lastDownloadBytes = response.Value.ContentLength;
            _blobLength = GetBlobLength(response);
        }

        /// <summary>
        /// Shared sync and async Read implementation.
        /// </summary>
        private async Task<int> ReadInternal(
            bool async,
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken = default)
        {
            ValidateReadParameters(buffer, offset, count);

            if (!_initalized)
            {
                await Initalize(async, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (_lastDownloadBytes == 0)
                {
                    return 0;
                }
            }

            int totalCopiedBytes = 0;
            do
            {
                int copiedBytes = async
                    ? await _stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false)
                    : _stream.Read(buffer, offset, count);
                offset += copiedBytes;
                count -= copiedBytes;
                totalCopiedBytes += copiedBytes;

                // We've run out of bytes in the current block.
                if (copiedBytes == 0)
                {
                    // We hit the end of the blob with the last download call.
                    if (_offset == _blobLength)
                    {
                        return totalCopiedBytes;
                    }

                    // Download the next block
                    else
                    {
                        await DownloadBlock(async, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            while (count > 0);
            return totalCopiedBytes;
        }

        private static void ValidateReadParameters(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException($"{nameof(buffer)}", $"{nameof(buffer)} cannot be null.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot be less than 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} cannot exceed {nameof(buffer)} length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(count)} cannot be less than 0.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} + {nameof(count)} cannot exceed {nameof(buffer)} length.");
            }
        }

        private static long GetBlobLength(Response<BlobDownloadInfo> response)
        {
            string lengthString = response.Value.Details.ContentRange;
            string[] split = lengthString.Split('/');
            return long.Parse(split[1], CultureInfo.InvariantCulture);
        }

        /// <inheritdoc/>
        public override bool CanRead => true;

        /// <inheritdoc/>
        public override bool CanSeek => false;

        /// <inheritdoc/>
        public override bool CanWrite => throw new NotSupportedException();

        public override long Length => throw new NotSupportedException();

        /// <inheritdoc/>
        public override long Position {
            get => _stream.Position;
            set => throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void Flush()
        {
        }

        /// <inheritdoc/>
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _stream.Dispose();
        }
    }
}
