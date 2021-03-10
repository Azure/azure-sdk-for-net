// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A calss representing an arm operation wrapper object.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert TModel into. </typeparam>
    /// <typeparam name="TModel"> The model returned by existing Operation methods. </typeparam>
    public class PhArmOperation<TOperations, TModel> : ArmOperation<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Response<TModel> _syncWrapped;
        private readonly Operation<TModel> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class for mocking.
        /// </summary>
        protected PhArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhArmOperation(Operation<TModel> wrapped, Func<TModel, TOperations> converter)
            : base(null)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public PhArmOperation(Response<TModel> wrapped, Func<TModel, TOperations> converter)
            : base(converter(wrapped.Value))
        {
            _converter = converter;
            _syncWrapped = wrapped;
        }

        /// <inheritdoc/>
        public override string Id => _wrapped?.Id;

        /// <inheritdoc/>
        public override TOperations Value => CompletedSynchronously ? SyncValue : _converter(_wrapped.Value);

        /// <inheritdoc/>
        public override bool HasCompleted => CompletedSynchronously || _wrapped.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => CompletedSynchronously || _wrapped.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return CompletedSynchronously ? _syncWrapped.GetRawResponse() : _wrapped.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously ? _syncWrapped.GetRawResponse() : _wrapped.UpdateStatus(cancellationToken);
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously
                ? new ValueTask<Response>(_syncWrapped.GetRawResponse())
                : _wrapped.UpdateStatusAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return CompletedSynchronously
                ? new PhArmResponse<TOperations, TModel>(_syncWrapped, _converter)
                : new PhArmResponse<TOperations, TModel>(
                    await _wrapped.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                    _converter);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return CompletedSynchronously
                ? new PhArmResponse<TOperations, TModel>(_syncWrapped, _converter)
                : new PhArmResponse<TOperations, TModel>(
                    await _wrapped.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false),
                    _converter);
        }
    }
}
