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
            _wrappedResponseOperation = new PhNoValueArmOperation(wrapped);
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

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
            var task = WaitForCompletionAsync(ArmOperationHelpers<object>.DefaultPollingInterval, cancellationToken);
            return await task.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            var task = _doesWrapOperation
                ? _wrappedOperation.WaitForCompletionAsync(pollingInterval, cancellationToken)
                : _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);
            var value = await task.ConfigureAwait(false);
            return value;
        }

        /// <inheritdoc/>
        public override Response WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<object>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <inheritdoc/>
        public override Response WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Value;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }

        /// <inheritdoc/>
        public override Response CreateResult(Response response, CancellationToken cancellationToken)
        {
            return response;
        }

        /// <inheritdoc/>
        public override ValueTask<Response> CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            return new ValueTask<Response>(response);
        }
    }
}
