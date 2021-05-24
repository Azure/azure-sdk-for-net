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
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert TModel into. </typeparam>
    /// <typeparam name="TModel"> The model returned by existing Operation methods. </typeparam>
    public class PhArmOperation<TOperations, TModel> : Operation<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Operation<TModel> _wrappedOperation;
        private readonly Operation<TModel> _wrappedResponseOperation;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhArmOperation(Operation<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            if (wrapped is null)
            {
                throw new ArgumentNullException(nameof(wrapped));
            }

            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            _wrappedOperation = wrapped;
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhArmOperation(Response<TModel> wrapped, Func<TModel, TOperations> converter)
        {
            if (wrapped is null)
            {
                throw new ArgumentNullException(nameof(wrapped));
            }

            if (converter is null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            _wrappedResponseOperation = new PhValueArmOperation<TModel>(wrapped);
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class for mocking.
        /// </summary>
        protected PhArmOperation()
        {
        }

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override TOperations Value => _converter(_doesWrapOperation ? _wrappedOperation.Value : _wrappedResponseOperation.Value);

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _doesWrapOperation ? _wrappedOperation.HasValue : _wrappedResponseOperation.HasValue;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "<Pending>")]
        private bool _doesWrapOperation => _wrappedResponseOperation is null;

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
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            var task = WaitForCompletionAsync(OperationInternals.DefaultPollingInterval, cancellationToken);
            return await task.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            var value = _doesWrapOperation 
                ? await _wrappedOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false) 
                : await _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(_converter(value.Value), GetRawResponse());
        }
    }
}
