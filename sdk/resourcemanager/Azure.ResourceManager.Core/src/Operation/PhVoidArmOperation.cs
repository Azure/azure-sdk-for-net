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
        private readonly Operation _wrappedOperation;
        private readonly OperationOrResponseInternals<Response> _wrappedResponseOperation;

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

            _wrappedResponseOperation = new OperationOrResponseInternals<Response>(Response.FromValue(wrapped, wrapped));
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _doesWrapOperation ? _wrappedOperation.GetRawResponse() : _wrappedResponseOperation.GetRawResponse();

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _doesWrapOperation ? _wrappedOperation.UpdateStatus(cancellationToken) : _wrappedResponseOperation.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _doesWrapOperation ? _wrappedOperation.UpdateStatusAsync(cancellationToken) : _wrappedResponseOperation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
        {
            var task = WaitForCompletionResponseAsync(OperationInternals<object>.DefaultPollingInterval, cancellationToken);
            return await task.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_doesWrapOperation)
            {
                return await _wrappedOperation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                var taskResponseResponse = await _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
                var taskResponse = Task.FromResult(taskResponseResponse.Value);
                var valueTask = new ValueTask<Response>(taskResponse);
                return await valueTask.ConfigureAwait(false);
            }
        }
    }
}
