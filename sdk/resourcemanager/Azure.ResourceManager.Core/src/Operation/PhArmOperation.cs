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
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert TModel into. </typeparam>
    /// <typeparam name="TModel"> The model returned by existing Operation methods. </typeparam>
    public class PhArmOperation<TOperations, TModel> : ArmOperation<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Operation<TModel> _wrappedOperation;
        private readonly ArmOperation<TModel> _wrappedResponseOperation;

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
        {
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
            _wrappedResponseOperation = new ValueArmOperation<TModel>(wrapped);
            _converter = converter;
        }

        private bool _doesWrapOperation => _wrappedResponseOperation is null;

        /// <inheritdoc/>
        public override string Id => _wrappedOperation?.Id;

        /// <inheritdoc/>
        public override TOperations Value => _converter(_doesWrapOperation ? _wrappedOperation.Value : _wrappedResponseOperation.Value);

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _wrappedOperation.HasCompleted : _wrappedResponseOperation.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _doesWrapOperation ? _wrappedOperation.HasValue : _wrappedResponseOperation.HasValue;

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
            var task = WaitForCompletionAsync(ArmOperationHelpers<TOperations>.DefaultPollingInterval, cancellationToken);
            return await task.ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            var task = _doesWrapOperation 
                ? _wrappedOperation.WaitForCompletionAsync(pollingInterval, cancellationToken) 
                : _wrappedResponseOperation.WaitForCompletionAsync(pollingInterval, cancellationToken);
            var value = await task.ConfigureAwait(false);
            return Response.FromValue(_converter(value), GetRawResponse());
        }

        /// <inheritdoc/>
        public override Response<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<TOperations>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <inheritdoc/>
        public override Response<TOperations> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse()) as ArmResponse<TOperations>;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
