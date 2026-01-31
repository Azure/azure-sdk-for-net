// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A wrapper class that wraps an ArmOperation&lt;T&gt; and exposes it as a non-generic ArmOperation.
    /// This is used to maintain backward compatibility for methods that return ArmOperation.
    /// </summary>
    internal class CustomNetworkCloudArmOperationWrapper<T> : ArmOperation where T : notnull
    {
        private readonly ArmOperation<T> _innerOperation;

        /// <summary>
        /// Initializes a new instance of CustomNetworkCloudArmOperationWrapper.
        /// </summary>
        /// <param name="innerOperation">The inner ArmOperation&lt;T&gt; to wrap.</param>
        internal CustomNetworkCloudArmOperationWrapper(ArmOperation<T> innerOperation)
        {
            _innerOperation = innerOperation ?? throw new ArgumentNullException(nameof(innerOperation));
        }

        /// <inheritdoc />
        public override string Id => _innerOperation.Id;

        /// <inheritdoc />
        public override RehydrationToken? GetRehydrationToken() => _innerOperation.GetRehydrationToken();

        /// <inheritdoc />
        public override bool HasCompleted => _innerOperation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _innerOperation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken) => _innerOperation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken) => _innerOperation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(CancellationToken cancellationToken) => _innerOperation.WaitForCompletionResponse(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken) => _innerOperation.WaitForCompletionResponse(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken) => _innerOperation.WaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _innerOperation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
