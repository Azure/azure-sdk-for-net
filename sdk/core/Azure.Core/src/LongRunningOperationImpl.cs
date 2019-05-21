// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;

namespace Azure
{
    public class LongRunningOperationImpl<T> : LongRunningOperation<T>
    {
        private Response<T>? _cachedValue;

        private readonly TimeSpan _pollDelay;

        private readonly Func<CancellationToken, Task<Response<T>>> _asyncValueRequestFactory;

        private readonly Func<CancellationToken, Response<T>> _valueRequestFactory;

        private readonly Func<CancellationToken, Task<Response>> _cancelAsyncRequestFactory;

        private readonly Func<CancellationToken, Response> _cancelRequestFactory;

        private readonly Func<CancellationToken, Task<Response<LongRunningOperationStatus>>> _asyncStatusRequestFactory;

        private readonly Func<CancellationToken, Response<LongRunningOperationStatus>> _statusRequestFactory;

        public override Response Raw { get; }

        public LongRunningOperationImpl(Response raw,
            TimeSpan pollDelay,
            Func<CancellationToken, Task<Response<T>>> asyncValueRequestFactory,
            Func<CancellationToken, Response<T>> valueRequestFactory,

            Func<CancellationToken, Task<Response>> cancelAsyncRequestFactory,
            Func<CancellationToken, Response> cancelRequestFactory,

            Func<CancellationToken, Task<Response<LongRunningOperationStatus>>> asyncStatusRequestFactory,
            Func<CancellationToken, Response<LongRunningOperationStatus>> statusRequestFactory)
        {
            _pollDelay = pollDelay;
            _asyncValueRequestFactory = asyncValueRequestFactory;
            _valueRequestFactory = valueRequestFactory;
            _cancelAsyncRequestFactory = cancelAsyncRequestFactory;
            _cancelRequestFactory = cancelRequestFactory;
            _asyncStatusRequestFactory = asyncStatusRequestFactory;
            _statusRequestFactory = statusRequestFactory;
            Raw = raw;
        }

        public override async ValueTask<Response<T>> GetValueAsync(CancellationToken cancellationToken = default)
        {
            return await GetValueAsyncCore(true, cancellationToken);
        }

        public override Response<T> GetValue(CancellationToken cancellationToken = default)
        {
            return GetValueAsyncCore(false, cancellationToken).EnsureCompleted();
        }

        private async Task<Response<T>> GetValueAsyncCore(bool async, CancellationToken cancellationToken)
        {
            if (_cachedValue == null)
            {
                Response<LongRunningOperationStatus> status = async ? await GetStatusAsync(cancellationToken) : GetStatus(cancellationToken);

                while (status.Value == LongRunningOperationStatus.Running)
                {
                    await Task.Delay(_pollDelay, cancellationToken);
                }

                // TODO: Cache exception
                _cachedValue = async ? await _asyncValueRequestFactory(cancellationToken) : _valueRequestFactory(cancellationToken);
            }

            return _cachedValue.Value;
        }

        public override async ValueTask<Response<LongRunningOperationStatus>> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            // TODO: Rate limit status calls
            return await _asyncStatusRequestFactory(cancellationToken);
        }

        public override Response<LongRunningOperationStatus> GetStatus(CancellationToken cancellationToken = default)
        {
            // TODO: Rate limit status calls
            return _statusRequestFactory(cancellationToken);
        }

        public override async ValueTask<Response> CancelAsync(CancellationToken cancellationToken = default)
        {
            return await _cancelAsyncRequestFactory(cancellationToken);
        }

        public override Response Cancel(CancellationToken cancellationToken = default)
        {
            return _cancelRequestFactory(cancellationToken);
        }

        public override void Dispose()
        {
            _cachedValue?.Dispose();
        }
    }
}
