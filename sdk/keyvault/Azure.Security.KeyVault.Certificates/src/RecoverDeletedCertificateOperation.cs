// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A long-running operation for <see cref="CertificateClient.StartRecoverDeletedCertificate(string, CancellationToken)"/> or <see cref="CertificateClient.StartRecoverDeletedCertificateAsync(string, CancellationToken)"/>.
    /// </summary>
    public class RecoverDeletedCertificateOperation : Operation<KeyVaultCertificateWithPolicy>
    {
        private static readonly TimeSpan s_defaultPollingInterval = TimeSpan.FromSeconds(2);

        private readonly KeyVaultPipeline _pipeline;
        private readonly KeyVaultCertificateWithPolicy _value;
        private Response _response;
        private bool _completed;

        internal RecoverDeletedCertificateOperation(KeyVaultPipeline pipeline, Response<KeyVaultCertificateWithPolicy> response)
        {
            _pipeline = pipeline;
            _value = response.Value ?? throw new InvalidOperationException("The response does not contain a value.");
            _response = response.GetRawResponse();
        }

        /// <summary> Initializes a new instance of <see cref="RecoverDeletedCertificateOperation" /> for mocking. </summary>
        protected RecoverDeletedCertificateOperation() {}

        /// <inheritdoc/>
        public override string Id => _value.Id.ToString();

        /// <summary>
        /// Gets the <see cref="KeyVaultCertificate"/> of the certificate being recovered.
        /// You should await <see cref="WaitForCompletionAsync(CancellationToken)"/> before attempting to use a certificate in this pending state.
        /// </summary>
        /// <remarks>
        /// Azure Key Vault will return a <see cref="KeyVaultCertificate"/> immediately but may take time to actually recover the deleted certificate if soft-delete is enabled.
        /// </remarks>
        public override KeyVaultCertificateWithPolicy Value => _value;

        /// <inheritdoc/>
        public override bool HasCompleted => _completed;

        /// <inheritdoc/>
        public override bool HasValue => true;

        /// <inheritdoc/>
        public override Response GetRawResponse() => _response;

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(RecoverDeletedCertificateOperation)}.{nameof(UpdateStatus)}");
                scope.AddAttribute("secret", _value.Name);
                scope.Start();

                try
                {
                    _response = _pipeline.GetResponse(RequestMethod.Get, cancellationToken, CertificateClient.CertificatesPath, _value.Name, "/", _value.Properties.Version);
                    _completed = CheckCompleted(_response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc/>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(RecoverDeletedCertificateOperation)}.{nameof(UpdateStatus)}");
                scope.AddAttribute("secret", _value.Name);
                scope.Start();

                try
                {
                    _response = await _pipeline.GetResponseAsync(RequestMethod.Get, cancellationToken, CertificateClient.CertificatesPath, _value.Name, "/", _value.Properties.Version).ConfigureAwait(false);
                    _completed = await CheckCompletedAsync(_response).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return GetRawResponse();
        }

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(s_defaultPollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        private async ValueTask<bool> CheckCompletedAsync(Response response)
        {
            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the certificate was recovered.
                    return true;

                case 404:
                    return false;

                default:
                    throw await _pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
            }
        }
        private bool CheckCompleted(Response response)
        {
            switch (response.Status)
            {
                case 200:
                case 403: // Access denied but proof the certificate was recovered.
                    return true;

                case 404:
                    return false;

                default:
                    throw _pipeline.Diagnostics.CreateRequestFailedException(response);
            }
        }
    }
}
