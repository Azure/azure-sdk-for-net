// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Proto.Network
{
    /// <summary>
    /// A class representing an arm operation wrapper object.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1618:Generic type parameters should be documented", Justification = "<Pending>")]
    internal class PhValueArmOperation<TOperations> : Operation<TOperations>
        where TOperations : class
    {
        private readonly Operation<TOperations> _wrappedOperation;
        private readonly OperationOrResponseInternals<TOperations> _wrappedResponseOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhValueArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected PhValueArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhValueArmOperation{TOperations}"/>.
        /// </summary>
        /// <param name="wrapped"> The operation object to wrap. </param>
        public PhValueArmOperation(Operation<TOperations> wrapped)
        {
            if (wrapped is null)
                throw new ArgumentNullException(nameof(wrapped));

            _wrappedOperation = wrapped;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhValueArmOperation{TOperations}"/>.
        /// </summary>
        /// <param name="wrapped"> The response object to wrap. </param>
        public PhValueArmOperation(Response<TOperations> wrapped)
        {
            if (wrapped is null)
                throw new ArgumentNullException(nameof(wrapped));

            _wrappedResponseOperation = new OperationOrResponseInternals<TOperations>(wrapped);
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        public override TOperations Value => _doesWrapOperation ? _wrappedOperation.Value : _wrappedResponseOperation.Value;

        public override bool HasValue => _doesWrapOperation ? _wrappedOperation.HasValue : _wrappedResponseOperation.HasValue;

        public override string Id => _wrappedOperation?.Id;

        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        public override Response GetRawResponse() => _doesWrapOperation? _wrappedOperation.GetRawResponse() : _wrappedResponseOperation.GetRawResponse();

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _doesWrapOperation ? _wrappedOperation.UpdateStatus(cancellationToken) : _wrappedResponseOperation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _doesWrapOperation ? _wrappedOperation.UpdateStatusAsync(cancellationToken) : _wrappedResponseOperation.UpdateStatusAsync(cancellationToken);

        public override ValueTask<Response<TOperations>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _doesWrapOperation ? _wrappedOperation.WaitForCompletionAsync(cancellationToken) : _wrappedResponseOperation.WaitForCompletionAsync(cancellationToken);

        public override ValueTask<Response<TOperations>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => _doesWrapOperation ? _wrappedOperation.WaitForCompletionAsync(pollingInterval, cancellationToken) : _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
