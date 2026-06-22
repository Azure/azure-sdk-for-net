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
    /// A long-running operation for <see cref="SecretClient.StartRecoverDeletedSecret(string, CancellationToken)"/> or <see cref="SecretClient.StartRecoverDeletedSecretAsync(string, CancellationToken)"/>.
    /// </summary>
    public class RecoverDeletedSecretOperation : Operation<SecretProperties>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultSecretsClient _generated;
        private readonly OperationInternal _operationInternal;
        private readonly SecretProperties _value;

        internal RecoverDeletedSecretOperation(KeyVaultSecretsClient generated, ClientDiagnostics diagnostics, Response<SecretProperties> response)
        {
            _generated = generated ?? throw new ArgumentNullException(nameof(generated));
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _operationInternal = new(this, diagnostics, response.GetRawResponse(), nameof(RecoverDeletedSecretOperation), new[] { new KeyValuePair<string, string>("secret", _value.Name) });
        }

        /// <summary> Initializes a new instance of <see cref="RecoverDeletedSecretOperation" /> for mocking. </summary>
        protected RecoverDeletedSecretOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.AbsoluteUri;

        /// <summary>
        /// Gets the <see cref="SecretProperties"/> of the secret being recovered.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a secret in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="SecretProperties"/> immediately but may take time to actually recover the deleted secret if soft-delete is enabled.
        /// </remarks>
        public override SecretProperties Value => _value;

        /// <inheritdoc/>
        public override bool HasCompleted => _operationInternal.HasCompleted;

        /// <inheritdoc/>
        /// <remarks>
        /// Always returns <see langword="true"/>. The recover call returns the
        /// <see cref="SecretProperties"/> immediately (the value is populated from that response),
        /// even when soft-delete polling has not yet completed. Callers should still await
        /// <see cref="WaitForCompletionAsync(CancellationToken)"/> before using the recovered
        /// secret if soft-delete is enabled.
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
        public override ValueTask<Response<SecretProperties>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<SecretProperties>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            Response response = async
                ? await _generated.GetSecretAsync(_value.Name, secretVersion: null, outContentType: default, context: ctx).ConfigureAwait(false)
                : _generated.GetSecret(_value.Name, secretVersion: null, outContentType: default, context: ctx);

            return response.Status switch
            {
                200 or 403 => OperationState.Success(response), // 403 == access denied, but proves the secret was recovered.
                404        => OperationState.Pending(response),
                _          => OperationState.Failure(response, new RequestFailedException(response)),
            };
        }

        RehydrationToken IOperation.GetRehydrationToken() =>
            throw new NotSupportedException($"{nameof(GetRehydrationToken)} is not supported.");
    }
}