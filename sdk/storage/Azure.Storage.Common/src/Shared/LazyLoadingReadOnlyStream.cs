// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage
{
    /// <summary>
    /// Used for Open Read APIs.
    /// </summary>
    internal class LazyLoadingReadOnlyStream<TProperties> : Stream
    {
        /// <summary>
        /// Delegate for a resource's direct REST download method.
        /// </summary>
        /// <param name="range">
        /// Content range to download.
        /// </param>
        /// <param name="transferValidation">
        /// Optional validation options.
        /// </param>
        /// <param name="async">
        /// Whether to perform the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for cancelling the download request.
        /// </param>
        /// <returns>
        /// Downloaded resource content.
        /// </returns>
        public delegate Task<Response<IDownloadedContent>> DownloadInternalAsync(
            HttpRange range,
            DownloadTransferValidationOptions transferValidation,
            bool async,
            CancellationToken cancellationToken);

        /// <summary>
        /// Delegate for getting properties for the target resource.
        /// </summary>
        /// <param name="async">
        /// Whether to perform the operation asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token for cancelling the download request.
        /// </param>
        /// <returns>
        /// Resource properties.
        /// </returns>
        public delegate Task<Response<TProperties>> GetPropertiesAsync(bool async, CancellationToken cancellationToken);

        /// <summary>
        /// Delegate to replicate how a client will alter the download range.
        /// Used to avoid requesting blob ranges that will result in error after transformation.
        /// </summary>
        /// <param name="range">Range this stream will request on download.</param>
        /// <returns>Range the underlying client will adjust to.</returns>
        /// <remarks>
        /// Used by advanced features such as clientside encryption, which alters ranges to
        /// ensure necessary info for decryption is downloaded.
        /// </remarks>
        public delegate HttpRange PredictEncryptedRangeAdjustment(HttpRange range);

        /// <summary>
        /// No-op for range adjustment.
        /// </summary>
        public static PredictEncryptedRangeAdjustment NoRangeAdjustment => range => range;

        /// <summary>
        /// The current position within the blob or file.
        /// </summary>
        private long _position;

        /// <summary>
        /// Last known length of underlying blob or file.
        /// </summary>
        private long _length;

        /// <summary>
        /// The number of bytes to download per call.
        /// </summary>
        private readonly int _bufferSize;

        /// <summary>
        /// The backing buffer.
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// The current position within the buffer.
        /// </summary>
        private int _bufferPosition;

        /// <summary>
        /// The current length of the buffer that is populated.
        /// </summary>
        private int _bufferLength;

        /// <summary>
        /// If we are allowing the blob to be modifed while we read it.
        /// </summary>
        private readonly bool _allowBlobModifications;

        /// <summary>
        /// Indicated the user has called Seek() since the last Read() call, and the new position is outside _buffer.
        /// </summary>
        private bool _bufferInvalidated;

        /// <summary>
        /// Download() function.
        /// </summary>
        private readonly DownloadInternalAsync _downloadInternalFunc;

        /// <summary>
        /// Function to get properties.
        /// </summary>
        private readonly GetPropertiesAsync _getPropertiesInternalFunc;

        /// <summary>
        /// Hashing options to use with <see cref="_downloadInternalFunc"/>.
        /// </summary>
        private readonly DownloadTransferValidationOptions _validationOptions;

        /// <summary>
        /// Helper to determine how <see cref="_downloadInternalFunc"/> will adjust the range this class.
        /// requests.
        /// </summary>
        private readonly PredictEncryptedRangeAdjustment _predictEncryptedRangeAdjustment;

        public LazyLoadingReadOnlyStream(
            DownloadInternalAsync downloadInternalFunc,
            GetPropertiesAsync getPropertiesFunc,
            DownloadTransferValidationOptions transferValidation,
            bool allowModifications,
            long initialLength,
            long position = 0,
            int? bufferSize = default,
            PredictEncryptedRangeAdjustment rangePredictionFunc = default)
        {
            _downloadInternalFunc = downloadInternalFunc;
            _getPropertiesInternalFunc = getPropertiesFunc;
            _predictEncryptedRangeAdjustment = rangePredictionFunc ?? (range => range);
            _position = position;

            // If the blob cannot be modified and the total blob size is less than the default streaming size,
            // the buffer size should be limited to the total blob size.
            int maxBufferSize = allowModifications ? Constants.DefaultStreamingDownloadSize : (int)Math.Min(initialLength, Constants.DefaultStreamingDownloadSize);
            _bufferSize = bufferSize ?? maxBufferSize;

            _buffer = ArrayPool<byte>.Shared.Rent(_bufferSize);
            _allowBlobModifications = allowModifications;
            _bufferPosition = 0;
            _bufferLength = 0;
            _length = initialLength;
            _bufferInvalidated = false;

            // the caller to this stream cannot defer validation, as they cannot access a returned hash
            if (!(transferValidation?.AutoValidateChecksum ?? true))
            {
                throw Errors.CannotDeferTransactionalHashVerification();
            }
            // we defer hash validation on download calls to validate in-place with our existing buffer
            _validationOptions = transferValidation == default
                ? default
                : new DownloadTransferValidationOptions
                {
                    ChecksumAlgorithm = transferValidation.ChecksumAlgorithm,
                    AutoValidateChecksum = false
                };
        }

        public override int Read(byte[] buffer, int offset, int count)
            => ReadInternal(
                buffer,
                offset,
                count,
                async: false,
                default)
            .EnsureCompleted();

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => await ReadInternal(
                buffer,
                offset,
                count,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        public async Task<int> ReadInternal(byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
        {
            ValidateReadParameters(buffer, offset, count);

            if (_position == _length)
            {
                if (_allowBlobModifications)
                {
                    // In case the blob grow since our last download call.
                    _length = await GetBlobLengthInternal(async, cancellationToken).ConfigureAwait(false);

                    if (_position == _length)
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            if (_bufferPosition == _bufferLength || _bufferInvalidated)
            {
                int lastDownloadedBytes = await DownloadInternal(async, cancellationToken).ConfigureAwait(false);
                if (lastDownloadedBytes == 0)
                {
                    return 0;
                }
                _bufferInvalidated = false;
            }

            int remainingBytesInBuffer = _bufferLength - _bufferPosition;

            // We will return the minimum of remainingBytesInBuffer and the count provided by the user
            int bytesToWrite = Math.Min(remainingBytesInBuffer, count);

            Array.Copy(_buffer, _bufferPosition, buffer, offset, bytesToWrite);

            _position += bytesToWrite;
            _bufferPosition += bytesToWrite;

            return bytesToWrite;
        }

        private async Task<int> DownloadInternal(bool async, CancellationToken cancellationToken)
        {
            Response<IDownloadedContent> response;

            HttpRange range = new HttpRange(_position, _bufferSize);

            // if _downloadInternalFunc is going to produce a range out of bounds response, we're at the end of the blob
            if (_predictEncryptedRangeAdjustment(range).Offset >= _length)
            {
                return 0;
            }

            response = await _downloadInternalFunc(range, _validationOptions, async, cancellationToken).ConfigureAwait(false);

            using Stream networkStream = response.Value.Content;
            // use stream copy to ensure consumption of any trailing metadata (e.g. structured message)
            // allow buffer limits to catch the error of data size mismatch
            int totalCopiedBytes = (int) await networkStream.CopyToInternal(new MemoryStream(_buffer), async, cancellationToken).ConfigureAwait((false));

            _bufferPosition = 0;
            _bufferLength = totalCopiedBytes;
            _length = GetBlobLengthFromResponse(response.GetRawResponse());

            // if we deferred transactional hash validation on download, validate now
            // currently we always defer but that may change
            if (_validationOptions != default && _validationOptions.ChecksumAlgorithm == StorageChecksumAlgorithm.MD5 && !_validationOptions.AutoValidateChecksum) // TODO better condition
            {
                ContentHasher.AssertResponseHashMatch(_buffer, _bufferPosition, _bufferLength, _validationOptions.ChecksumAlgorithm, response.GetRawResponse());
            }

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
                throw new ArgumentOutOfRangeException(nameof(offset), $"{nameof(offset)} cannot be less than 0.");
            }

            if (offset > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), $"{nameof(offset)} cannot exceed {nameof(buffer)} length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} cannot be less than 0.");
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            // Return the buffer to the pool if we're called from Dispose or a finalizer
            if (_buffer != null)
            {
                ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
                _buffer = null;
            }
        }

        private async Task<long> GetBlobLengthInternal(bool async, CancellationToken cancellationToken)
        {
            Response<TProperties> response = await _getPropertiesInternalFunc(async, cancellationToken).ConfigureAwait(false);

            response.GetRawResponse().Headers.TryGetValue("Content-Length", out string lengthString);

            if (lengthString == null)
            {
                throw new ArgumentException($"{HttpHeader.Names.ContentLength} header is missing on get properties response.");
            }

            return Convert.ToInt64(lengthString, CultureInfo.InvariantCulture);
        }

        private static long GetBlobLengthFromResponse(Response response)
        {
            response.Headers.TryGetValue("Content-Range", out string lengthString);

            if (lengthString == null)
            {
                throw new ArgumentException("Content-Range header is missing on download response.");
            }

            string[] split = lengthString.Split('/');
            return Convert.ToInt64(split[1], CultureInfo.InvariantCulture);
        }

        private static HttpRange GetResponseRange(Response response)
        {
            response.Headers.TryGetValue("Content-Range", out string rangeString);

            if (rangeString == null)
            {
                throw new InvalidOperationException("Content-Range header is missing on download response.");
            }

            string[] split = rangeString.Split('/');
            string[] rangeSplit = split[0].Split('-');
            string[] firstbyteSplit = rangeSplit[0].Split(' ');

            long firstByte = Convert.ToInt64(firstbyteSplit[1], CultureInfo.InvariantCulture);
            long lastByte = Convert.ToInt64(rangeSplit[1], CultureInfo.InvariantCulture);

            return new HttpRange(firstByte, lastByte - firstByte + 1);
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _length;

        public override long Position
        {
            get => _position;
            set => Seek(value, SeekOrigin.Begin);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPosition = CalculateNewPosition(offset, origin);

            if (newPosition == _position)
            {
                return _position;
            }

            // newPosition < 0
            if (newPosition < 0)
            {
                throw new ArgumentException($"New {nameof(offset)} cannot be less than 0.  Value was {newPosition}", nameof(offset));
            }

            // newPosition > _length
            if (newPosition > _length)
            {
                throw new ArgumentException("You cannot seek past the last known length of the underlying blob or file.", nameof(offset));
            }

            // newPosition is less than _position, but within _buffer.
            long beginningOfBuffer = _position - _bufferPosition;
            if (newPosition < _position && newPosition >= beginningOfBuffer)
            {
                _bufferPosition = (int)(newPosition - beginningOfBuffer);
                _position = newPosition;
                return newPosition;
            }

            // newPosition is greater than _position, but within _buffer.
            long endOfBuffer = _position + (_bufferLength - _bufferPosition);
            if (newPosition > _position && newPosition < endOfBuffer)
            {
                _bufferPosition = (int)(newPosition - beginningOfBuffer);
                _position = newPosition;
                return newPosition;
            }

            // newPosition is outside of _buffer, we will need to re-download.
            _bufferInvalidated = true;
            _position = newPosition;
            return newPosition;
        }

        internal long CalculateNewPosition(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    return offset;
                case SeekOrigin.Current:
                    return _position + offset;
                case SeekOrigin.End:
                    if (_allowBlobModifications)
                    {
                        throw new ArgumentException($"Cannot {nameof(Seek)} with {nameof(SeekOrigin)}.{nameof(SeekOrigin.End)} on a growing blob or file.  Call Stream.Seek(Stream.Length, SeekOrigin.Begin) to get to the end of known data.", nameof(origin));
                    }
                    else
                    {
                        return _length + offset;
                    }
                default:
                    throw new ArgumentException($"Unknown ${nameof(SeekOrigin)} value", nameof(origin));
            }
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void Flush() { }

        public override Task FlushAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;
    }
}
