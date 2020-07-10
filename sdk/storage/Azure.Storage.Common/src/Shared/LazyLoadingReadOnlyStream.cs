// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// Used for Open Read APIs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class LazyLoadingReadOnlyStream<T> : Stream
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
        /// The number of bytes in the last download call.
        /// </summary>
        private int _lastDownloadBytes;

        /// <summary>
        /// The number of bytes to download per call.
        /// </summary>
        private readonly int _bufferSize;

        /// <summary>
        /// The stream we will download to.
        /// </summary>
        private Stream _stream;

        /// <summary>
        /// Request conditions to send on the download requests.
        /// </summary>
        private readonly object _requestConditions;

        /// <summary>
        /// Async DownloadTo() function.
        /// </summary>
        private readonly Func<HttpRange, object, bool, CancellationToken, Task<Response<T>>> _downloadAsyncFunc;

        /// <summary>
        /// Sync DownloadTo() function.
        /// </summary>
        private readonly Func<HttpRange, object, bool, CancellationToken, Response<T>> _downloadFunc;

        public LazyLoadingReadOnlyStream(
            Func<HttpRange, object, bool, CancellationToken, Task<Response<T>>> downloadToAsyncFunc,
            Func<HttpRange, object, bool, CancellationToken, Response<T>> downloadToFunc,
            long position = 0,
            int bufferSize = Constants.DefaultDownloadCopyBufferSize,
            object requestConditions = default)
        {
            _downloadAsyncFunc = downloadToAsyncFunc;
            _downloadFunc = downloadToFunc;
            _position = position;
            _bufferSize = bufferSize;
            _stream = new MemoryStream(bufferSize);
            _requestConditions = requestConditions;
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

        public async Task<int> ReadInternal( byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
        {
            ValidateReadParameters(buffer, offset, count);

            if (_stream.Position == 0)
            {
                await DownloadInternal(async, cancellationToken).ConfigureAwait(false);
                if (_lastDownloadBytes == 0)
                {
                    return 0;
                }
            }

            int totalCopiedBytes = 0;
            do
            {
                int copiedBytes = async
                    ? await _stream.ReadAsync(buffer, offset, count).ConfigureAwait(false)
                    : _stream.Read(buffer, offset, count);
                offset += copiedBytes;
                count -= copiedBytes;
                _position += copiedBytes;
                totalCopiedBytes += copiedBytes;

                // We've run out of bytes in the current block.
                if (copiedBytes == 0)
                {
                    // We hit the end of the blob with the last download call.
                    if (_position == _length)
                    {
                        return totalCopiedBytes;
                    }

                    // Download the next block
                    else
                    {
                        await DownloadInternal(async, cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            while (count > 0);
            return totalCopiedBytes;
        }

        private async Task DownloadInternal(bool async, CancellationToken cancellationToken)
        {
            Response<T> response;

            HttpRange range = new HttpRange(_position, _bufferSize);

            response = async
                ? await _downloadAsyncFunc(range, _requestConditions, default, cancellationToken).ConfigureAwait(false)
                : _downloadFunc(range, _requestConditions, default, cancellationToken);

            Stream networkStream = (Stream)typeof(T).GetProperty("Content").GetValue(response.Value, null);

            _stream.SetLength(0);

            if (async)
            {
                await networkStream.CopyToAsync(
                    _stream,
                    Constants.DefaultBufferSize,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                networkStream.CopyTo(
                    _stream,
                    Constants.DefaultBufferSize);
            }

            networkStream.Dispose();

            _stream.Position = 0;
            _lastDownloadBytes = response.GetRawResponse().Headers.ContentLength.GetValueOrDefault();
            _length = GetBlobLength(response);
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

        private static long GetBlobLength(Response<T> response)
        {
            response.GetRawResponse().Headers.TryGetValue("Content-Range", out string lengthString);
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
