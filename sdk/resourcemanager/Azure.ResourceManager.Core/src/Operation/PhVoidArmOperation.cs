// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A calss representing an arm operation wrapper object.
    /// </summary>
    public class PhVoidArmOperation : ArmOperation
    {
        private readonly Operation<Response> _wrappedOperation;
        private readonly ArmOperation _wrappedResponseOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhVoidArmOperation"/> class for mocking.
        /// </summary>
        protected PhVoidArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhVoidArmOperation"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        public PhVoidArmOperation(Operation<Response> wrapped)
        {
            _wrappedOperation = wrapped;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhVoidArmOperation"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        public PhVoidArmOperation(Response wrapped)
        {
            _wrappedResponseOperation = new VoidArmOperation(wrapped);
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override Response Value => throw new InvalidOperationException();

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => false;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _doesWrapOperation ? _wrappedOperation.GetRawResponse() : _wrappedResponseOperation.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? _wrappedOperation.UpdateStatus(cancellationToken) : _wrappedResponseOperation.UpdateStatus(cancellationToken);
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? _wrappedOperation.UpdateStatusAsync(cancellationToken)
                : _wrappedResponseOperation.UpdateStatusAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(ArmOperationHelpers<Response>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? Response.FromValue(await _wrappedOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false), _wrappedOperation.GetRawResponse())
                : Response.FromValue(await _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false), _wrappedOperation.GetRawResponse());
        }

        /// <inheritdoc/>
        public override Response WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<Response>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <inheritdoc/>
        public override Response WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse());
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
