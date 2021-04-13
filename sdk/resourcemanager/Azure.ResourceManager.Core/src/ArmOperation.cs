// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="OperationsBase"/> to return representing the result of the ArmOperation. </typeparam>
    public abstract class ArmOperation<TOperations> : Operation<TOperations>
        where TOperations : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class.
        /// </summary>
        /// <param name="syncValue"> The <see cref="OperationsBase"/> representing the result of the ArmOperation. </param>
        protected ArmOperation(TOperations syncValue)
        {
            CompletedSynchronously = syncValue != null;
            SyncValue = syncValue;
        }

        /// <summary>
        /// Gets a value indicating whether or not the operation completed synchronously.
        /// </summary>
        protected bool CompletedSynchronously { get; }

        /// <summary>
        /// Gets the <see cref="OperationsBase"/> representing the result of the ArmOperation.
        /// </summary>
        protected TOperations SyncValue { get; }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public Response<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<TOperations>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="pollingInterval"> The polling interval in seconds to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public Response<TOperations> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            var polling = TimeSpan.FromSeconds(pollingInterval);
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    Response<TOperations> response = Response.FromValue(Value, GetRawResponse());
                    return new ArmResponse<TOperations, TOperations>(response, old => old);
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }

    /// <summary>
    /// A class representing an arm operation wrapper object.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="ResourceOperationsBase"/> to convert TModel into. </typeparam>
    /// <typeparam name="TModel"> The model returned by existing Operation methods. </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Allowed when we have a generic version of the same type")]
    public class ArmOperation<TOperations, TModel> : ArmOperation<TOperations>
        where TOperations : class
        where TModel : class
    {
        private readonly Func<TModel, TOperations> _converter;
        private readonly Response<TModel> _syncWrapped;
        private readonly Operation<TModel> _wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations, TModel}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public ArmOperation(Operation<TModel> wrapped, Func<TModel, TOperations> converter)
            : base(null)
        {
            _wrapped = wrapped;
            _converter = converter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations, TModel}"/> class.
        /// </summary>
        /// <param name="wrapped"> The results to wrap. </param>
        /// <param name="converter"> The function used to convert from existing type to new type. </param>
        public ArmOperation(Response<TModel> wrapped, Func<TModel, TOperations> converter)
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
                ? new ArmResponse<TOperations, TModel>(_syncWrapped, _converter)
                : new ArmResponse<TOperations, TModel>(
                    await _wrapped.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false),
                    _converter);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return CompletedSynchronously
                ? new ArmResponse<TOperations, TModel>(_syncWrapped, _converter)
                : new ArmResponse<TOperations, TModel>(
                    await _wrapped.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false),
                    _converter);
        }
    }
}
