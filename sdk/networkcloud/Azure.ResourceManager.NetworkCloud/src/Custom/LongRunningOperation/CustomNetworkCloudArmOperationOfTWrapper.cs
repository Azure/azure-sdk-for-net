// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A wrapper class that wraps a non-generic ArmOperation and exposes it as an ArmOperation&lt;T&gt;.
    /// This is used to maintain backward compatibility for methods that returned ArmOperation&lt;NetworkCloudOperationStatusResult&gt;.
    /// </summary>
    internal class CustomNetworkCloudArmOperationOfTWrapper<T> : ArmOperation<T> where T : notnull
    {
        private readonly ArmOperation _innerOperation;
        private Response<T> _value;

        /// <summary>
        /// Initializes a new instance of CustomNetworkCloudArmOperationOfTWrapper.
        /// </summary>
        /// <param name="innerOperation">The inner non-generic ArmOperation to wrap.</param>
        internal CustomNetworkCloudArmOperationOfTWrapper(ArmOperation innerOperation)
        {
            _innerOperation = innerOperation ?? throw new ArgumentNullException(nameof(innerOperation));
        }

        /// <inheritdoc />
        public override string Id => _innerOperation.Id;

        /// <inheritdoc />
        public override T Value => _value.Value;

        /// <inheritdoc />
        public override bool HasValue => _value != null;

        /// <inheritdoc />
        public override RehydrationToken? GetRehydrationToken() => _innerOperation.GetRehydrationToken();

        /// <inheritdoc />
        public override bool HasCompleted => _innerOperation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _innerOperation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken)
        {
            Response response = _innerOperation.UpdateStatus(cancellationToken);
            SetValueIfCompleted(response);
            return response;
        }

        /// <inheritdoc />
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken)
        {
            Response response = await _innerOperation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            SetValueIfCompleted(response);
            return response;
        }

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(CancellationToken cancellationToken)
        {
            Response response = _innerOperation.WaitForCompletionResponse(cancellationToken);
            _value = CreateResponse(response);
            return _value;
        }

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response response = _innerOperation.WaitForCompletionResponse(pollingInterval, cancellationToken);
            _value = CreateResponse(response);
            return _value;
        }

        /// <inheritdoc />
        public override async ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken)
        {
            Response response = await _innerOperation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
            _value = CreateResponse(response);
            return _value;
        }

        /// <inheritdoc />
        public override async ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            Response response = await _innerOperation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            _value = CreateResponse(response);
            return _value;
        }

        private void SetValueIfCompleted(Response response)
        {
            if (_innerOperation.HasCompleted)
            {
                _value = CreateResponse(response);
            }
        }

        private static Response<T> CreateResponse(Response response)
        {
            if (typeof(T) == typeof(NetworkCloudOperationStatusResult))
            {
                T value = (T)(object)NetworkCloudOperationStatusResult.FromResponse(response);
                return Response.FromValue(value, response);
            }

            throw new NotSupportedException($"The custom NetworkCloud operation wrapper does not support result type {typeof(T).FullName}.");
        }
    }
}
