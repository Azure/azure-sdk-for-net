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
        private bool _allowBlobModifications;

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
            _length = -1;
            _allowBlobModifications = !(_requestConditions == null && _createRequestConditionsFunc != null);
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

            if (_bufferPosition == 0 || _bufferPosition == _buffer.Length)
            {
                int lastDownloadedBytes = await DownloadInternal(async, cancellationToken).ConfigureAwait(false);
                if (lastDownloadedBytes == 0)
                {
                    return 0;
                }
            }

            int remainingBytesInBuffer = _bufferLength - _bufferPosition;

            // We will return the minimum of remainingBytesInBuffer and the count provided by the user
            int bytesToWrite = Math.Min(remainingBytesInBuffer, count);

            Array.Copy(_buffer, _bufferPosition, buffer, offset, bytesToWrite);

            _position += bytesToWrite;

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

            int copiedBytes;

            if (async)
            {
                copiedBytes = await networkStream.ReadAsync(
                    buffer: _buffer,
                    offset: 0,
                    count: _buffer.Length,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                copiedBytes = networkStream.Read(
                    buffer: _buffer,
                    offset: 0,
                    count: _buffer.Length);
            }

            _bufferPosition = 0;
            _bufferLength = copiedBytes;
            _length = GetBlobLengthFromResponse(response.GetRawResponse());

            // Set _requestConditions If-Match if we are not allowing the blob to be modified.
            if (!_allowBlobModifications)
            {
                _requestConditions = _createRequestConditionsFunc(response.GetRawResponse().Headers.ETag);
            }

            return response.GetRawResponse().Headers.ContentLength.GetValueOrDefault();
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

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => _length;

        public override long Position
        {
            get => _position;
            set => throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
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
