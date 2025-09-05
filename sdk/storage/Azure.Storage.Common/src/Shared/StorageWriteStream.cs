// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.Shared
{
    internal abstract class StorageWriteStream : Stream
    {
        protected long _position;
        protected long _bufferSize;
        protected readonly IProgress<long> _progressHandler;
        protected readonly PooledMemoryStream _buffer;
        private ArrayPool<byte> _bufferPool;
        private readonly StorageChecksumAlgorithm _checksumAlgorithm;
        private bool UseMasterCrc => _checksumAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64;

        /* Use StorageCrc64HashAlgorithm directly. Some checksum algorithms need a "finalization" step but
         * crc does not. We don't want finalization semantics in the code because we need access to the
         * cumulative crc as it's being calculated. This is because the caller can Flush() at any time, and
         * historically implementing classes call commit APIs on this flush. We don't want to call a commit
         * API if we haven't done some of our validation, but the caller isn't necessarily at the end of
         * their write when they call flush. We therefore maintain a running calculation if crc validation
         * is being used and only use a user-provided checksum (if any) on Close()/Dispose(). */
        private StorageCrc64HashAlgorithm _masterCrcChecksummer;
        private Memory<byte> _composedCrc = Memory<byte>.Empty;
        private Memory<byte> _userProvidedChecksum = Memory<byte>.Empty;
        private IHasher _bufferChecksumer;

        private bool _disposed;
        private readonly DisposableBucket _accumulatedDisposables = new DisposableBucket();

        protected StorageWriteStream(
            long position,
            long bufferSize,
            IProgress<long> progressHandler,
            UploadTransferValidationOptions transferValidation,
            PooledMemoryStream buffer = null,
            ArrayPool<byte> bufferPool = null)
        {
            _position = position;
            _bufferSize = bufferSize;
            _bufferPool = bufferPool ?? ArrayPool<byte>.Shared;

            if (progressHandler != null)
            {
                _progressHandler = new AggregatingProgressIncrementer(progressHandler);
            }

            _checksumAlgorithm = Argument.CheckNotNull(transferValidation, nameof(transferValidation)).ChecksumAlgorithm;
            if (!transferValidation.PrecalculatedChecksum.IsEmpty)
            {
                if (UseMasterCrc)
                {
                    _accumulatedDisposables.Add(_bufferPool.RentDisposable(
                        transferValidation.PrecalculatedChecksum.Length,
                        out var buf));
                    buf.Clear();
                    _userProvidedChecksum = new Memory<byte>(buf, 0, transferValidation.PrecalculatedChecksum.Length);
                    transferValidation.PrecalculatedChecksum.CopyTo(_userProvidedChecksum);
                }
                else
                {
                    throw Errors.PrecalculatedHashNotSupportedOnSplit();
                }
            }
            if (UseMasterCrc)
            {
                _masterCrcChecksummer = StorageCrc64HashAlgorithm.Create();
                _accumulatedDisposables.Add(_bufferPool.RentDisposable(
                       Constants.StorageCrc64SizeInBytes,
                       out var buf));
                buf.Clear();
                _composedCrc = new Memory<byte>(buf, 0, Constants.StorageCrc64SizeInBytes);
            }

            if (buffer != null)
            {
                if (buffer.Position != 0)
                {
                    throw Errors.CannotInitializeWriteStreamWithData();
                }
                _buffer = buffer;
            }
            else
            {
                _buffer = new PooledMemoryStream(
                    arrayPool: _bufferPool,
                    bufferSize: (int)Math.Min(Constants.MB, bufferSize));
                _accumulatedDisposables.Add(_buffer);
            }
            _bufferChecksumer = ContentHasher.GetHasherFromAlgorithmId(_checksumAlgorithm);
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

        private async Task WriteInternal(
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
                using (FinalizeAndReplaceBufferChecksum(out UploadTransferValidationOptions validationOptions))
                {
                    await AppendAndClearBufferInternal(
                        validationOptions,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

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
                        using (FinalizeAndReplaceBufferChecksum(out UploadTransferValidationOptions validationOptions))
                        {
                            await AppendAndClearBufferInternal(
                                validationOptions,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false);
                        }
                    }
                }
            }
        }

        public override void Flush()
            => FlushInternal(
                async: false,
                cancellationToken: default).EnsureCompleted();

        public override async Task FlushAsync(CancellationToken cancellationToken)
            => await FlushInternal(
                async: true,
                cancellationToken).ConfigureAwait(false);

        private async Task FlushInternal(bool async, CancellationToken cancellationToken)
        {
            using (FinalizeAndReplaceBufferChecksum(out UploadTransferValidationOptions validationOptions))
            {
                await AppendAndClearBufferInternal(validationOptions, async, cancellationToken).ConfigureAwait(false);
            }

            if (UseMasterCrc)
            {
                using (_bufferPool.RentDisposable(_masterCrcChecksummer.HashLengthInBytes, out byte[] buf))
                {
                    buf.Clear();
                    var currentAccumulated = new Memory<byte>(buf, 0, _masterCrcChecksummer.HashLengthInBytes);
                    _masterCrcChecksummer.GetCurrentHash(currentAccumulated.Span);
                    if (!currentAccumulated.Span.SequenceEqual(_composedCrc.Span))
                    {
                        throw Errors.ChecksumMismatch(currentAccumulated.Span, _composedCrc.Span);
                    }
                }
            }

            await CommitInternal(async, cancellationToken).ConfigureAwait(false);
        }

        protected virtual Task CommitInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task AppendAndClearBufferInternal(
            UploadTransferValidationOptions validationOptions,
            bool async,
            CancellationToken cancellationToken)
        {
            try
            {
                await AppendInternal(validationOptions, async, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _buffer.Clear();
            }
        }

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
            _bufferChecksumer?.AppendHash(new Span<byte>(buffer, offset, count));
            _masterCrcChecksummer?.Append(new Span<byte>(buffer, offset, count));
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

        /// <summary>
        /// Properly disposes the write stream.
        /// Note: an exception may be raised during the disposal.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                try
                {
                    Flush();
                    ValidateCallerCrcIfAny();
                }
                finally
                {
                    _accumulatedDisposables.Dispose();
                }
            }

            _disposed = true;

            base.Dispose(disposing);
        }

#if NETCOREAPP3_0_OR_GREATER || NETCORESTANDARD2_1_OR_GREATER
        /// <summary>
        /// Properly disposes the write stream.
        /// Note: an exception may be raised during the disposal.
        /// </summary>
        public override async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                await FlushAsync(cancellationToken: default).ConfigureAwait(false);
                ValidateCallerCrcIfAny();
            }
            finally
            {
                _accumulatedDisposables.Dispose();
            }

            _disposed = true;

            await base.DisposeAsync().ConfigureAwait(false);
        }
#endif

        private void ValidateCallerCrcIfAny()
        {
            if (UseMasterCrc && !_userProvidedChecksum.IsEmpty)
            {
                using (_bufferPool.RentAsSpanDisposable(_masterCrcChecksummer.HashLengthInBytes, out Span<byte> currentAccumulated))
                {
                    _masterCrcChecksummer.GetCurrentHash(currentAccumulated);
                    if (!currentAccumulated.SequenceEqual(_userProvidedChecksum.Span))
                    {
                        throw Errors.ChecksumMismatch(currentAccumulated, _userProvidedChecksum.Span);
                    }
                }
            }
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
        /// <returns>Disposable for the rented memory hosting the checksum.</returns>
        protected IDisposable FinalizeAndReplaceBufferChecksum(out UploadTransferValidationOptions validationOptions)
        {
            if (_buffer.Length == 0)
            {
                validationOptions =  new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.None
                };
                return null;
            }

            Memory<byte> checksum = Memory<byte>.Empty;
            IDisposable disposableResult = null;
            if (_bufferChecksumer != null)
            {
                disposableResult = _bufferPool.RentDisposable(_bufferChecksumer.HashSizeInBytes, out byte[] buf);
                buf.Clear();
                checksum = new Memory<byte>(buf, 0, _bufferChecksumer.HashSizeInBytes);
                _bufferChecksumer.GetFinalHash(checksum.Span);

                if (UseMasterCrc)
                {
                    StorageCrc64Composer.Compose(
                        (_composedCrc.ToArray(), 0),
                        (checksum.ToArray(), _buffer.Length))
                        .CopyTo(_composedCrc);
                }

                _bufferChecksumer?.Dispose();
                _bufferChecksumer = ContentHasher.GetHasherFromAlgorithmId(_checksumAlgorithm);
            }

            validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = _checksumAlgorithm,
                PrecalculatedChecksum = checksum,
            };
            return disposableResult;
        }
    }
}
