// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A long-running operation for <see cref="CertificateClient.StartRecoverDeletedCertificate(string, CancellationToken)"/> or <see cref="CertificateClient.StartRecoverDeletedCertificateAsync(string, CancellationToken)"/>.
    /// </summary>
    public class RecoverDeletedCertificateOperation : Operation<KeyVaultCertificateWithPolicy>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultCertificatesClient _generated;
        private readonly OperationInternal _operationInternal;
        private readonly KeyVaultCertificateWithPolicy _value;

        internal RecoverDeletedCertificateOperation(KeyVaultCertificatesClient generated, ClientDiagnostics diagnostics, Response<KeyVaultCertificateWithPolicy> response)
        {
            _generated = generated ?? throw new ArgumentNullException(nameof(generated));
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _operationInternal = new(this, diagnostics, response.GetRawResponse(), nameof(RecoverDeletedCertificateOperation), new[]
            {
                new KeyValuePair<string, string>("secret", _value.Name), // Retained for backward compatibility.
                new KeyValuePair<string, string>("certificate", _value.Name),
            });
        }

        /// <summary> Initializes a new instance of <see cref="RecoverDeletedCertificateOperation" /> for mocking. </summary>
        protected RecoverDeletedCertificateOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.AbsoluteUri;

        /// <summary>
        /// Gets the <see cref="KeyVaultCertificate"/> of the certificate being recovered.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a certificate in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="KeyVaultCertificate"/> immediately but may take time to actually recover the deleted certificate if soft-delete is enabled.
        /// </remarks>
        public override KeyVaultCertificateWithPolicy Value => _value;

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
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            Response response = async
                ? await _generated.GetCertificateAsync(_value.Name, certificateVersion: null, context: ctx).ConfigureAwait(false)
                : _generated.GetCertificate(_value.Name, certificateVersion: null, context: ctx);

            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the certificate was recovered.
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