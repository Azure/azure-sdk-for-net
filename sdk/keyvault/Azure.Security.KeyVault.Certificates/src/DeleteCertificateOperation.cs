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
    /// A long-running operation for <see cref="CertificateClient.StartDeleteCertificate(string, CancellationToken)"/> or <see cref="CertificateClient.StartDeleteCertificateAsync(string, CancellationToken)"/>.
    /// </summary>
    public class DeleteCertificateOperation : Operation<DeletedCertificate>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultCertificatesClient _generated;
        private readonly OperationInternal _operationInternal;
        private readonly DeletedCertificate _value;

        internal DeleteCertificateOperation(KeyVaultCertificatesClient generated, ClientDiagnostics diagnostics, Response<DeletedCertificate> response)
        {
            _generated = generated ?? throw new ArgumentNullException(nameof(generated));
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");

            // The recoveryId is only returned if soft delete is enabled. Without it the
            // service performed an immediate delete so there is nothing to poll for - skip
            // straight to a Succeeded state (matches the legacy fast-path behavior).
            if (_value.RecoveryId is null)
            {
                _operationInternal = OperationInternal.Succeeded(response.GetRawResponse());
            }
            else
            {
                _operationInternal = new(this, diagnostics, response.GetRawResponse(), nameof(DeleteCertificateOperation), new[]
                {
                    new KeyValuePair<string, string>("secret", _value.Name), // Retained for backward compatibility.
                    new KeyValuePair<string, string>("certificate", _value.Name),
                });
            }
        }

        /// <summary> Initializes a new instance of <see cref="DeleteCertificateOperation" /> for mocking. </summary>
        protected DeleteCertificateOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.AbsoluteUri;

        /// <summary>
        /// Gets the <see cref="DeletedCertificate"/>.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to purge or recover a certificate in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="DeletedCertificate"/> immediately but may take time to actually delete the certificate if soft-delete is enabled.
        /// </remarks>
        public override DeletedCertificate Value => _value;

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
        public override ValueTask<Response<DeletedCertificate>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<DeletedCertificate>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            // Soft-delete semantics: 404 -> still pending, 200 -> deleted. Use
            // ErrorOptions.NoThrow so the protocol overload surfaces 404 as a raw
            // Response (which we map to Pending) instead of throwing.
            var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
            Response response = async
                ? await _generated.GetDeletedCertificateAsync(_value.Name, ctx).ConfigureAwait(false)
                : _generated.GetDeletedCertificate(_value.Name, ctx);

            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the certificate was deleted.
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