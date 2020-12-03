// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal static class RetriableStream
    {
        public static Stream Create(
            Func<long, Stream> responseFactory,
            Func<long, ValueTask<Stream>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return Create(responseFactory(0), responseFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        public static async Task<Stream> CreateAsync(
            Func<long, Stream> responseFactory,
            Func<long, ValueTask<Stream>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return Create(await asyncResponseFactory(0).ConfigureAwait(false), responseFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        public static Stream Create(
            Stream initialResponse,
            Func<long, Stream> streamFactory,
            Func<long, ValueTask<Stream>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return new RetriableStreamImpl(initialResponse, streamFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        private class RetriableStreamImpl : Stream
        {
            private readonly ResponseClassifier _responseClassifier;

            private readonly Func<long, Stream> _streamFactory;

            private readonly Func<long, ValueTask<Stream>> _asyncStreamFactory;

            private readonly int _maxRetries;

            private readonly long _length;
            private readonly ExceptionDispatchInfo _lengthException;

            private Stream _currentStream;

            private long _position;

            private int _retryCount;

            private List<Exception> _exceptions;

            public RetriableStreamImpl(Stream initialStream, Func<long, Stream> streamFactory, Func<long, ValueTask<Stream>> asyncStreamFactory, ResponseClassifier responseClassifier, int maxRetries)
            {
                try
                {
                    _length = EnsureStream(initialStream).Length;
                }
                catch (Exception ex)
                {
                    _lengthException = ExceptionDispatchInfo.Capture(ex);
                }

                _currentStream = EnsureStream(initialStream);
                _streamFactory = streamFactory;
                _responseClassifier = responseClassifier;
                _asyncStreamFactory = asyncStreamFactory;
                _maxRetries = maxRetries;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                while (true)
                {
                    try
                    {
                        var result = await _currentStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
                        _position += result;
                        return result;
                    }
                    catch (Exception e)
                    {
                        await RetryAsync(e, true, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            private async Task RetryAsync(Exception exception, bool async, CancellationToken cancellationToken)
            {
                bool isNonCustomerCancelledException = exception is OperationCanceledException &&
                                                    !cancellationToken.IsCancellationRequested;

                if (!_responseClassifier.IsRetriableException(exception) && !isNonCustomerCancelledException)
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                if (_exceptions == null)
                {
                    _exceptions = new List<Exception>();
                }

                _exceptions.Add(exception);

                _retryCount++;

                if (_retryCount > _maxRetries)
                {
                    throw new AggregateException($"Retry failed after {_retryCount} tries", _exceptions);
                }

                _currentStream.Dispose();

                _currentStream = EnsureStream(async ? (await _asyncStreamFactory(_position).ConfigureAwait(false)) : _streamFactory(_position));
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                while (true)
                {
                    try
                    {
                        var result = _currentStream.Read(buffer, offset, count);
                        _position += result;
                        return result;
                    }
                    catch (Exception e)
                    {
                        RetryAsync(e, false, default).EnsureCompleted();
                    }
                }
            }

            public override bool CanRead => _currentStream.CanRead;
            public override bool CanSeek { get; }
            public override long Length
            {
                get
                {
                    _lengthException?.Throw();
                    return _length;
                }
            }

            public override long Position
            {
                get => _position;
                set => throw new NotSupportedException();
            }

            private static Stream EnsureStream(Stream stream)
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("The response didn't have content");
                }

                return stream;
            }

            public override bool CanWrite => false;

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Flush()
            {
                // Flush is allowed on read-only stream
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                _currentStream?.Dispose();
            }
        }
    }
}
