// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// A long-running operation for <see cref="SecretClient.StartDeleteSecret(string, CancellationToken)"/> or <see cref="SecretClient.StartDeleteSecretAsync(string, CancellationToken)"/>.
    /// </summary>
    public class DeleteSecretOperation : Operation<DeletedSecret>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultSecretsClient _generated;
        private readonly OperationInternal _operationInternal;
        private readonly DeletedSecret _value;

        internal DeleteSecretOperation(KeyVaultSecretsClient generated, ClientDiagnostics diagnostics, Response<DeletedSecret> response)
        {
            _generated = generated ?? throw new ArgumentNullException(nameof(generated));
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");

            // RecoveryId is only returned when soft-delete is enabled. Without it the
            // service performs an immediate delete and there is nothing to poll for.
            if (_value.RecoveryId is null)
            {
                _operationInternal = OperationInternal.Succeeded(response.GetRawResponse());
            }
            else
            {
                _operationInternal = new(this, diagnostics, response.GetRawResponse(), nameof(DeleteSecretOperation), new[] { new KeyValuePair<string, string>("secret", _value.Name) });
            }
        }

        /// <summary> Initializes a new instance of <see cref="DeleteSecretOperation" /> for mocking. </summary>
        protected DeleteSecretOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id?.AbsoluteUri ?? string.Empty;

        /// <summary>
        /// Gets the <see cref="DeletedSecret"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to purge or recover a secret in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="DeletedSecret"/> immediately but may take time to actually delete the secret if soft-delete is enabled.
        /// </remarks>
        public override DeletedSecret Value => _value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        /// <remarks>
        /// Always returns <see langword="true"/>. The DELETE call against Key Vault returns the
        /// <see cref="DeletedSecret"/> immediately (the value is populated from that response),
        /// even when soft-delete polling has not yet completed. Callers should still await
        /// <see cref="WaitForCompletionAsync(CancellationToken)"/> before purging or recovering
        /// the secret if soft-delete is enabled.
        /// </remarks>
        public override bool HasValue => true;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _operationInternal.RawResponse;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
            => HasCompleted ? GetRawResponse() : _operationInternal.UpdateStatus(cancellationToken);

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            => HasCompleted ? GetRawResponse() : await _operationInternal.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public override ValueTask<Response<DeletedSecret>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<DeletedSecret>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            // Soft-delete semantics: 404 -> still pending, 200 -> deleted.
            // Use ErrorOptions.NoThrow so the protocol overload surfaces the raw Response
            // on 404 rather than raising — the LRO maps it back to Pending below.
            var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            Response response = async
                ? await _generated.GetDeletedSecretAsync(_value.Name, ctx).ConfigureAwait(false)
                : _generated.GetDeletedSecret(_value.Name, ctx);

            return response.Status switch
            {
                200 or 403 => OperationState.Success(response), // 403 == access denied, but proves the secret is deleted.
                404        => OperationState.Pending(response),
                _          => OperationState.Failure(response, new RequestFailedException(response)),
            };
        }

        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}
