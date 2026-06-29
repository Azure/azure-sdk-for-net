// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppService
{
    internal sealed class ProjectedArmOperation<TIn, TOut> : ArmOperation<TOut>
    {
        private readonly ArmOperation<TIn> _inner;
        private readonly Func<TIn, TOut> _convert;

        public ProjectedArmOperation(ArmOperation<TIn> inner, Func<TIn, TOut> convert)
        {
            _inner = inner;
            _convert = convert;
        }

        public override TOut Value => _convert(_inner.Value);
        public override bool HasValue => _inner.HasValue;
        public override string Id => _inner.Id;
        public override bool HasCompleted => _inner.HasCompleted;
        public override Response GetRawResponse() => _inner.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
        public override Response<TOut> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            Response<TIn> r = _inner.WaitForCompletion(cancellationToken);
            return Response.FromValue(_convert(r.Value), r.GetRawResponse());
        }
        public override Response<TOut> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response<TIn> r = _inner.WaitForCompletion(pollingInterval, cancellationToken);
            return Response.FromValue(_convert(r.Value), r.GetRawResponse());
        }
        public override async ValueTask<Response<TOut>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            Response<TIn> r = await _inner.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_convert(r.Value), r.GetRawResponse());
        }
        public override async ValueTask<Response<TOut>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response<TIn> r = await _inner.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_convert(r.Value), r.GetRawResponse());
        }
        public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default) => _inner.WaitForCompletionResponse(cancellationToken);
        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken) => _inner.WaitForCompletionResponse(pollingInterval, cancellationToken);
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _inner.WaitForCompletionResponseAsync(cancellationToken);
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _inner.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
