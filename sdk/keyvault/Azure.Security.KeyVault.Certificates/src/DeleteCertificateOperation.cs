// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A long-running operation for <see cref="CertificateClient.StartDeleteCertificate(string, CancellationToken)"/> or <see cref="CertificateClient.StartDeleteCertificateAsync(string, CancellationToken)"/>.
    /// </summary>
    public class DeleteCertificateOperation : Operation<DeletedCertificate>, IOperation
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultPipeline _pipeline;
        private readonly OperationInternal _operationInternal;
        private readonly DeletedCertificate _value;

        internal DeleteCertificateOperation(KeyVaultPipeline pipeline, Response<DeletedCertificate> response)
        {
            _pipeline = pipeline;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");

            // The recoveryId is only returned if soft delete is enabled.
            if (_value.RecoveryId is null)
            {
                // If soft delete is not enabled, deleting is immediate so set success accordingly.
                _operationInternal = OperationInternal.Succeeded(response.GetRawResponse());
            }
            else
            {
                _operationInternal = new(this, _pipeline.Diagnostics, response.GetRawResponse(), nameof(DeleteCertificateOperation), new[]
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
            Response response = async
                ? await _pipeline.GetResponseAsync(RequestMethod.Get, cancellationToken, CertificateClient.DeletedCertificatesPath, _value.Name).ConfigureAwait(false)
                : _pipeline.GetResponse(RequestMethod.Get, cancellationToken, CertificateClient.DeletedCertificatesPath, _value.Name);

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
