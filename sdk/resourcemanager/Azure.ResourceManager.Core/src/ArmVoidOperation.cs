// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Generic ARM long running operation class for operations with no returned value
    /// </summary>
    public sealed class ArmVoidOperation : ArmOperation<Response>
    {
        private readonly Operation<Response> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmVoidOperation"/> class.
        /// </summary>
        /// <param name="other"> The operation that has a response which has no body. </param>
        public ArmVoidOperation(Operation<Response> other)
            : base(null)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            _wrapped = other;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmVoidOperation"/> class.
        /// </summary>
        /// <param name="other"> The response which has no body. </param>
        public ArmVoidOperation(Response other)
            : base(other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
        }

        /// <inheritdoc/>
        public override string Id => _wrapped?.Id;

        /// <inheritdoc/>
        public override Response Value => SyncValue;

        /// <inheritdoc/>
        public override bool HasCompleted => CompletedSynchronously || _wrapped.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => CompletedSynchronously || _wrapped.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return CompletedSynchronously ? SyncValue : _wrapped.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously ? SyncValue : _wrapped.UpdateStatus(cancellationToken);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously ? SyncValue : await _wrapped.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously
                ? new WrappingResponse(SyncValue)
                : await _wrapped.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return CompletedSynchronously
                ? new WrappingResponse(SyncValue)
                : await _wrapped.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// A class which wraps a response with no body.
        /// </summary>
        internal class WrappingResponse : ArmResponse<Response>
        {
            private readonly Response _wrapped;

            /// <summary>
            /// Initializes a new instance of the <see cref="WrappingResponse"/> class.
            /// </summary>
            /// <param name="wrapped"> The response object to wrap. </param>
            public WrappingResponse(Response wrapped)
            {
                _wrapped = wrapped;
            }

            /// <inheritdoc/>
            public override Response Value => _wrapped;

            /// <inheritdoc/>
            public override Response GetRawResponse()
            {
                return _wrapped;
            }
        }
    }
}
