// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A long-running operation for <see cref="KeyClient.StartRecoverDeletedKey(string, CancellationToken)"/> or <see cref="KeyClient.StartRecoverDeletedKeyAsync(string, CancellationToken)"/>.
    /// </summary>
    public class RecoverDeletedKeyOperation : Operation<KeyVaultKey>, IOperation<KeyVaultKey>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly OperationInternal<KeyVaultKey> _operationInternal;
        private readonly KeyVaultPipeline _pipeline;

        internal RecoverDeletedKeyOperation(KeyVaultPipeline pipeline, Response<KeyVaultKey> response)
        {
            _pipeline = pipeline;
            _operationInternal = new(pipeline.Diagnostics, this)
            {
                DefaultPollingInterval = s_defaultPollingInterval,
                RawResponse = response.GetRawResponse(),
                Value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.")
            };

            _operationInternal.ScopeAttributes.Add("secret", Value.Name);
        }

        /// <summary> Initializes a new instance of <see cref="RecoverDeletedKeyOperation" /> for mocking. </summary>
        protected RecoverDeletedKeyOperation() {}

        /// <inheritdoc/>
        public override string Id => Value.Id.ToString();

        /// <summary>
        /// Gets the <see cref="KeyVaultKey"/> of the key being recovered.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a key in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="KeyVaultKey"/> immediately but may take time to actually recover the deleted key if soft-delete is enabled.
        /// </remarks>
        public override KeyVaultKey Value => _operationInternal.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => _operationInternal.HasValue;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default) =>
            _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<KeyVaultKey>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            await _operationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override async ValueTask<Response<KeyVaultKey>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            await _operationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

        async ValueTask<OperationState<KeyVaultKey>> IOperation<KeyVaultKey>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var response = async
                ? await _pipeline.GetResponseAsync(RequestMethod.Get, cancellationToken, KeyClient.KeysPath, Value.Name, "/", Value.Properties.Version).ConfigureAwait(false)
                : _pipeline.GetResponse(RequestMethod.Get, cancellationToken, KeyClient.KeysPath, Value.Name, "/", Value.Properties.Version);

            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the key was recovered.
                    return OperationState<KeyVaultKey>.Success(response, Value);

                case 404:
                    return OperationState<KeyVaultKey>.Pending(response);

                default:
                    throw _pipeline.Diagnostics.CreateRequestFailedException(response);
            }
        }
    }
}
