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
    internal class LazyLoadingReadOnlyStream<TRequestConditions, TProperties> : Stream
    {
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
        /// Request conditions to send on the download requests.
        /// </summary>
        private TRequestConditions _requestConditions;

        /// <summary>
        /// Download() function.
        /// </summary>
        private readonly Func<HttpRange, TRequestConditions, bool, bool, CancellationToken, Task<Response<IDownloadedContent>>> _downloadInternalFunc;

        /// <summary>
        /// Function to create RequestConditions.
        /// </summary>
        private readonly Func<ETag?, TRequestConditions> _createRequestConditionsFunc;

        /// <summary>
        /// Function to get properties.
        /// </summary>
        private readonly Func<bool, CancellationToken, Task<Response<TProperties>>> _getPropertiesInternalFunc;

        public LazyLoadingReadOnlyStream(
            Func<HttpRange, TRequestConditions, bool, bool, CancellationToken, Task<Response<IDownloadedContent>>> downloadInternalFunc,
            Func<ETag?, TRequestConditions> createRequestConditionsFunc,
            Func<bool, CancellationToken, Task<Response<TProperties>>> getPropertiesFunc,
            long initialLenght,
            long position = 0,
            int? bufferSize = default,
            TRequestConditions requestConditions = default)
        {
            _downloadInternalFunc = downloadInternalFunc;
            _createRequestConditionsFunc = createRequestConditionsFunc;
            _getPropertiesInternalFunc = getPropertiesFunc;
            _position = position;
            _bufferSize = bufferSize ?? Constants.DefaultStreamingDownloadSize;
            _buffer = ArrayPool<byte>.Shared.Rent(_bufferSize);
            _bufferPosition = 0;
            _bufferLength = 0;
            _requestConditions = requestConditions;
            _length = initialLenght;
            _allowBlobModifications = !(_requestConditions == null && _createRequestConditionsFunc != null);
            _bufferInvalidated = false;
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

            if (_bufferPosition == 0 || _bufferPosition == _bufferLength || _bufferInvalidated)
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

#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            response = await _downloadInternalFunc(range, _requestConditions, default, async, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.

            using Stream networkStream = response.Value.Content;

            // The number of bytes we just downloaded.
            long downloadSize = GetResponseRange(response.GetRawResponse()).Length.Value;

            // The number of bytes we copied in the last loop.
            int copiedBytes;

            // Bytes we have copied so far.
            int totalCopiedBytes = 0;

            // Bytes remaining to copy.  It is save to truncate the long because we asked for a max of int _buffer size bytes.
            int remainingBytes = (int)downloadSize;

            do
            {
                if (async)
                {
                    copiedBytes = await networkStream.ReadAsync(
                        buffer: _buffer,
                        offset: totalCopiedBytes,
                        count: remainingBytes,
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    copiedBytes = networkStream.Read(
                        buffer: _buffer,
                        offset: totalCopiedBytes,
                        count: remainingBytes);
                }

                totalCopiedBytes += copiedBytes;
                remainingBytes -= copiedBytes;
            }
            while (copiedBytes != 0);

            _bufferPosition = 0;
            _bufferLength = totalCopiedBytes;
            _length = GetBlobLengthFromResponse(response.GetRawResponse());

            // Set _requestConditions If-Match if we are not allowing the blob to be modified.
            if (!_allowBlobModifications)
            {
                _requestConditions = _createRequestConditionsFunc(response.GetRawResponse().Headers.ETag);
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
#pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            Response<TProperties> response = await _getPropertiesInternalFunc(async, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.

            response.GetRawResponse().Headers.TryGetValue("Content-Length", out string lengthString);

            if (lengthString == null)
            {
                throw new ArgumentException($"{HttpHeader.Names.ContentLength} header is mssing on get properties response.");
            }

            return Convert.ToInt64(lengthString, CultureInfo.InvariantCulture);
        }

        private static long GetBlobLengthFromResponse(Response response)
        {
            response.Headers.TryGetValue("Content-Range", out string lengthString);

            if (lengthString == null)
            {
                throw new ArgumentException("Content-Range header is mssing on download response.");
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
                throw new ArgumentException($"New {nameof(offset)} cannot be less than 0.  Value was {newPosition}");
            }

            // newPosition > _length
            if (newPosition > _length)
            {
                throw new ArgumentException(
                    "You cannot seek past the last known length of the underlying blob or file.");
            }

            // newPosition is less than _position, but within _buffer.
            long beginningOfBuffer = _position - _bufferPosition;
            if (newPosition < _position && newPosition > beginningOfBuffer)
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
                        throw new ArgumentException($"Cannot {nameof(Seek)} with {nameof(SeekOrigin)}.{nameof(SeekOrigin.End)} on a growing blob or file.  Call Stream.Seek(Stream.Length, SeekOrigin.Begin) to get to the end of known data.");
                    }
                    else
                    {
                        return _length + offset;
                    }
                default:
                    throw new ArgumentException($"Unknown ${nameof(SeekOrigin)} value");
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
