// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Shared
{
    internal abstract class StorageWriteStream : Stream
    {
        protected long _position;
        protected long _bufferSize;
        protected readonly IProgress<long> _progressHandler;
        protected readonly PooledMemoryStream _buffer;
        private readonly StorageChecksumAlgorithm _checksumAlgorithm;
        private IHasher _bufferChecksum;
        private bool _disposed;
        private bool _shouldDisposeBuffer;

        protected StorageWriteStream(
            long position,
            long bufferSize,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
            PooledMemoryStream buffer = null)
        {
            _position = position;
            _bufferSize = bufferSize;

            if (progressHandler != null)
            {
                _progressHandler = new AggregatingProgressIncrementer(progressHandler);
            }

            _checksumAlgorithm = Argument.CheckNotNull(transferValidation, nameof(transferValidation)).ChecksumAlgorithm;
            // write streams don't support pre-calculated hashes
            if (!transferValidation.PrecalculatedChecksum.IsEmpty)
            {
                throw Errors.PrecalculatedHashNotSupportedOnSplit();
            }

            if (buffer != null)
            {
                if (buffer.Position != 0)
                {
                    throw Errors.CannotInitializeWriteStreamWithData();
                }
                _buffer = buffer;
                _shouldDisposeBuffer = false;
            }
            else
            {
                _buffer = new PooledMemoryStream(
                    arrayPool: ArrayPool<byte>.Shared,
                    maxArraySize: (int)Math.Min(Constants.MB, bufferSize));
                _shouldDisposeBuffer = true;
            }
            _bufferChecksum = ContentHasher.GetHasherFromAlgorithmId(_checksumAlgorithm);
        }

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => throw new NotSupportedException();

        public override long Position { get => _position; set => throw new NotSupportedException(); }

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(
            byte[] buffer,
            int offset,
            int count)
            => WriteInternal(
                buffer,
                offset,
                count,
                async: false,
                cancellationToken: default)
            .EnsureCompleted();

        public override async Task WriteAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
            => await WriteInternal(
                buffer,
                offset,
                count,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        protected virtual async Task WriteInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            ValidateWriteParameters(buffer, offset, count);
            int remaining = count;

            // New bytes will fit in the buffer.
            if (count <= _bufferSize - _buffer.Position)
            {
                await WriteToBufferInternal(buffer, offset, count, async, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // Finish filling the buffer.
                int remainingSpace = (int)(_bufferSize - _buffer.Position);
                await WriteToBufferInternal(
                    buffer,
                    offset,
                    remainingSpace,
                    async,
                    cancellationToken).ConfigureAwait(false);
                remaining -= remainingSpace;
                offset += remainingSpace;

                // Upload bytes.
                await AppendInternal(
                    FinalizeAndReplaceBufferChecksum(),
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);

                // We need to loop, because remaining bytes might be greater than _buffer size.
                while (remaining > 0)
                {
                    int available = (int)Math.Min(remaining, _bufferSize);
                    await WriteToBufferInternal(
                        buffer,
                        offset,
                        available,
                        async,
                        cancellationToken).ConfigureAwait(false);
                    remaining -= available;
                    offset += available;

                    // Renaming bytes won't fit in buffer.
                    if (remaining > 0)
                    {
                        await AppendInternal(
                            FinalizeAndReplaceBufferChecksum(),
                            async,
                            cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
            }
        }

        protected abstract Task FlushInternal(
            UploadTransferValidationOptions validationOptions,
            bool async,
            CancellationToken cancellationToken);

        public override void Flush()
            => FlushInternal(
                FinalizeAndReplaceBufferChecksum(),
                async: false,
                cancellationToken: default).EnsureCompleted();

        public override async Task FlushAsync(CancellationToken cancellationToken)
            => await FlushInternal(
                FinalizeAndReplaceBufferChecksum(),
                async: true,
                cancellationToken).ConfigureAwait(false);

        protected abstract Task AppendInternal(
            UploadTransferValidationOptions validationOptions,
            bool async,
            CancellationToken cancellationToken);

        protected abstract void ValidateBufferSize(long bufferSize);

        protected async Task WriteToBufferInternal(
            byte[] buffer,
            int offset,
            int count,
            bool async,
            CancellationToken cancellationToken)
        {
            _bufferChecksum?.AppendHash(new Span<byte>(buffer, offset, count));
            if (async)
            {
                await _buffer.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _buffer.Write(buffer, offset, count);
            }
            _position += count;
        }

        protected static void ValidateWriteParameters(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer), $"{nameof(buffer)} cannot be null.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), $"{nameof(offset)} cannot be less than 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), $"{nameof(offset)} cannot be greater than {nameof(buffer)} length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} cannot be less than 0.");
            }

            if (offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(offset)} and {nameof(count)}", $"{nameof(offset)} + {nameof(count)} cannot exceed {nameof(buffer)} length.");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Flush();
                if (_shouldDisposeBuffer)
                {
                    _buffer.Dispose();
                }
            }

            _disposed = true;

            base.Dispose(disposing);
        }

        /// <summary>
        /// <para>
        /// Take the checksum of the currnet buffer and reset the tracked checksum calculation.
        /// </para>
        /// <para>
        /// Note: Avoid using in subclasses. This is only exposed for page blobs, as they override
        /// <see cref="WriteInternal(byte[], int, int, bool, CancellationToken)"/> for pageblob 512
        /// requirements. Since WriteInternal is what calls
        /// <see cref="AppendInternal(UploadTransferValidationOptions, bool, CancellationToken)"/>
        /// with appropriate validation options, it needs access to this. However, it's not clear
        /// whether page blob needs direct access to calling AppendInternal or whether it can call
        /// into its base implementation instead. If it can do this, that is preferred and this can
        /// be made private.
        /// </para>
        /// </summary>
        /// <returns></returns>
        protected UploadTransferValidationOptions FinalizeAndReplaceBufferChecksum()
        {
            if (_buffer.Length == 0)
            {
                return new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.None
                };
            }

            var result = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = _checksumAlgorithm,
                PrecalculatedChecksum = _bufferChecksum?.GetFinalHash() ?? ReadOnlyMemory<byte>.Empty,
            };
            _bufferChecksum?.Dispose();
            _bufferChecksum = ContentHasher.GetHasherFromAlgorithmId(_checksumAlgorithm);

            return result;
        }
    }
}
