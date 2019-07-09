// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core
{
    public static class RetriableStream
    {
        public static Stream Create(
            Func<long, Response> responseFactory,
            Func<long, Task<Response>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return Create(responseFactory(0), responseFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        public static async Task<Stream> CreateAsync(
            Func<long, Response> responseFactory,
            Func<long, Task<Response>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return Create(await asyncResponseFactory(0).ConfigureAwait(false), responseFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        public static Stream Create(
            Response initialResponse,
            Func<long, Response> responseFactory,
            Func<long, Task<Response>> asyncResponseFactory,
            ResponseClassifier responseClassifier,
            int maxRetries)
        {
            return new RetriableStreamImpl(initialResponse, responseFactory, asyncResponseFactory, responseClassifier, maxRetries);
        }

        private class RetriableStreamImpl : ReadOnlyStream
        {
            private readonly ResponseClassifier _responseClassifier;

            private readonly Func<long, Response> _responseFactory;

            private readonly Func<long, Task<Response>> _asyncResponseFactory;

            private readonly int _maxRetries;

            private readonly Stream _initialStream;

            private Stream _currentStream;

            private long _position;

            private int _retryCount;

            private List<Exception> _exceptions;

            public RetriableStreamImpl(Response initialResponse,  Func<long, Response> responseFactory, Func<long, Task<Response>> asyncResponseFactory, ResponseClassifier responseClassifier, int maxRetries)
            {
                _initialStream = initialResponse.ContentStream;
                _currentStream = initialResponse.ContentStream;
                _responseFactory = responseFactory;
                _responseClassifier = responseClassifier;
                _asyncResponseFactory = asyncResponseFactory;
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
                        await RetryAsync(e, true).ConfigureAwait(false);
                    }
                }
            }

            private async Task RetryAsync(Exception exception, bool async)
            {
                if (!_responseClassifier.IsRetriableException(exception))
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

                _currentStream = async ? (await _asyncResponseFactory(_position).ConfigureAwait(false)).ContentStream : _responseFactory(_position).ContentStream;
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
                        RetryAsync(e, false).EnsureCompleted();
                    }
                }
            }

            public override bool CanRead => _currentStream.CanRead;
            public override bool CanSeek { get; } = false;
            public override long Length => _initialStream.Length;

            public override long Position
            {
                get => _position;
                set => throw new NotSupportedException();
            }
        }
    }
}
