// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: the corrected generated methods return ArmOperation<MachineLearningRegistryComponent*Resource>,
    // but the shipped API must continue returning ArmOperation<MachineLearninRegistryComponent*Resource>.
    // ArmOperation<T> is invariant, so this adapter forwards polling and projects the terminal value.
    internal sealed class MachineLearninRegistryComponentCompatOperation<TInner, TCompat> : ArmOperation<TCompat>
    {
        private readonly ArmOperation<TInner> _innerOperation;
        private readonly Func<TInner, TCompat> _converter;

        public MachineLearninRegistryComponentCompatOperation(ArmOperation<TInner> innerOperation, Func<TInner, TCompat> converter)
        {
            _innerOperation = innerOperation;
            _converter = converter;
        }

        public override TCompat Value => _converter(_innerOperation.Value);

        public override bool HasValue => _innerOperation.HasValue;

        public override string Id => _innerOperation.Id;

        public override bool HasCompleted => _innerOperation.HasCompleted;

        public override RehydrationToken? GetRehydrationToken() => _innerOperation.GetRehydrationToken();

        public override Response GetRawResponse() => _innerOperation.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _innerOperation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _innerOperation.UpdateStatusAsync(cancellationToken);

        public override Response<TCompat> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            Response<TInner> response = _innerOperation.WaitForCompletion(cancellationToken);
            return Response.FromValue(_converter(response.Value), response.GetRawResponse());
        }

        public override Response<TCompat> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            Response<TInner> response = _innerOperation.WaitForCompletion(pollingInterval, cancellationToken);
            return Response.FromValue(_converter(response.Value), response.GetRawResponse());
        }

        public override async ValueTask<Response<TCompat>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            Response<TInner> response = await _innerOperation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_converter(response.Value), response.GetRawResponse());
        }

        public override async ValueTask<Response<TCompat>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            Response<TInner> response = await _innerOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_converter(response.Value), response.GetRawResponse());
        }
    }
}
