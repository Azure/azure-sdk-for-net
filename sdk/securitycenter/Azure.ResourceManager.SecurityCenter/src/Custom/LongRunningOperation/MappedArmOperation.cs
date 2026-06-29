// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.SecurityCenter
{
    internal sealed class MappedArmOperation<TSource, TValue> : ArmOperation<TValue>
    {
        private readonly ArmOperation<TSource> _operation;
        private readonly Func<TSource, TValue> _convert;

        internal MappedArmOperation(ArmOperation<TSource> operation, Func<TSource, TValue> convert)
        {
            _operation = operation;
            _convert = convert;
        }

        public override string Id => _operation.Id;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override TValue Value => _convert(_operation.Value);

        public override RehydrationToken? GetRehydrationToken() => _operation.GetRehydrationToken();
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        public override Response<TValue> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            Response<TSource> response = _operation.WaitForCompletion(cancellationToken);
            return Response.FromValue(_convert(response.Value), response.GetRawResponse());
        }

        public override Response<TValue> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            Response<TSource> response = _operation.WaitForCompletion(pollingInterval, cancellationToken);
            return Response.FromValue(_convert(response.Value), response.GetRawResponse());
        }

        public override async ValueTask<Response<TValue>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            Response<TSource> response = await _operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_convert(response.Value), response.GetRawResponse());
        }

        public override async ValueTask<Response<TValue>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            Response<TSource> response = await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_convert(response.Value), response.GetRawResponse());
        }
    }
}
