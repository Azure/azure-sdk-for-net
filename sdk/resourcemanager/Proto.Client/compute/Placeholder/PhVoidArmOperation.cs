// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Proto.Compute
{
    /// <summary>
    /// A class representing an arm operation wrapper object.
    /// </summary>
    public class PhVoidArmOperation : Operation
    {
        private readonly Operation _wrappedOperation;
        private readonly OperationOrResponseInternals _wrappedResponseOperation;

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
        public PhVoidArmOperation(Operation wrapped)
        {
            if (wrapped is null)
                throw new ArgumentNullException(nameof(wrapped));

            _wrappedOperation = wrapped;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhVoidArmOperation"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        public PhVoidArmOperation(Response wrapped)
        {
            if (wrapped is null)
                throw new ArgumentNullException(nameof(wrapped));

            _wrappedResponseOperation = new OperationOrResponseInternals(wrapped);
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _doesWrapOperation ? _wrappedOperation.GetRawResponse() : _wrappedResponseOperation.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => 
            _doesWrapOperation 
            ? _wrappedOperation.UpdateStatus(cancellationToken) 
            : _wrappedResponseOperation.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            _doesWrapOperation 
            ? _wrappedOperation.UpdateStatusAsync(cancellationToken) 
            : _wrappedResponseOperation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) =>
            WaitForCompletionResponseAsync(OperationInternals.DefaultPollingInterval, cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            _doesWrapOperation
            ? _wrappedOperation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken)
            : _wrappedResponseOperation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
