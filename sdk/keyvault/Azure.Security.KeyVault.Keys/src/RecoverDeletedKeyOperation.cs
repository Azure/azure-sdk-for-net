// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// A long-running operation for <see cref="KeyClient.StartRecoverDeletedKey(string, CancellationToken)"/> or <see cref="KeyClient.StartRecoverDeletedKeyAsync(string, CancellationToken)"/>.
    /// </summary>
    public class RecoverDeletedKeyOperation : Operation<KeyVaultKey>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultPipeline _pipeline;
        private readonly OperationInternal _operationInternal;
        private readonly KeyVaultKey _value;

        internal RecoverDeletedKeyOperation(KeyVaultPipeline pipeline, Response<KeyVaultKey> response)
        {
            _pipeline = pipeline;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _operationInternal = new(this, _pipeline.Diagnostics, response.GetRawResponse(), nameof(RecoverDeletedKeyOperation), new[]
            {
                new KeyValuePair<string, string>("secret", _value.Name), // Retained for backward compatibility.
                new KeyValuePair<string, string>("key", _value.Name),
            });
        }

        /// <summary> Initializes a new instance of <see cref="RecoverDeletedKeyOperation" /> for mocking. </summary>
        protected RecoverDeletedKeyOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.AbsoluteUri;

        /// <summary>
        /// Gets the <see cref="KeyVaultKey"/> of the key being recovered.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a key in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="KeyVaultKey"/> immediately but may take time to actually recover the deleted key if soft-delete is enabled.
        /// </remarks>
        public override KeyVaultKey Value => _value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        public override bool HasValue => true;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                return _operationInternal.UpdateStatus(cancellationToken);
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!HasCompleted)
            {
                return await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            }

            return GetRawResponse();
        }

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultKey>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultKey>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            Response response = async
                ? await _pipeline.GetResponseAsync(RequestMethod.Get, cancellationToken, KeyClient.KeysPath, _value.Name).ConfigureAwait(false)
                : _pipeline.GetResponse(RequestMethod.Get, cancellationToken, KeyClient.KeysPath, _value.Name);

            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the key was recovered.
                    return OperationState.Success(response);

                case 404:
                    return OperationState.Pending(response);

                default:
                    return OperationState.Failure(response, new RequestFailedException(response));
            }
        }

        // This method is never invoked since we don't override Operation<T>.GetRehydrationToken.
        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
