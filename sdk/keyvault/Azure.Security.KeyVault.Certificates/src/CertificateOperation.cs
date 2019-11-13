// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A long running poller operation which can be used to track the status of a pending key vault certificate operation.
    /// </summary>
    public class CertificateOperation : Operation<KeyVaultCertificateWithPolicy>
    {
        private readonly CertificateClient _client;
        private bool _completed;
        private CertificateOperationRequest _requestedOperation;

        private Response _response;

        private KeyVaultCertificateWithPolicy _value;

        internal CertificateOperation(Response<CertificateOperationProperties> properties, CertificateClient client)
        {
            Properties = properties;

            Id = properties.Value.Id.ToString();
            _client = client;
        }

        /// <summary>
        /// Gets the properties of the pending certificate operation.
        /// </summary>
        public CertificateOperationProperties Properties { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the operation has reached a terminal state.
        /// </summary>
        public override bool HasCompleted => _completed;

        /// <summary>
        /// Gets a value indicating whether the Value property can be safely accessed.
        /// </summary>
        public override bool HasValue => _value != null;

        /// <inheritdoc />
        public override string Id { get; }

        /// <inheritdoc />
        public override KeyVaultCertificateWithPolicy Value => _value;

        /// <inheritdoc />
        public override Response GetRawResponse() => _response;

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
            this.DefaultWaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<KeyVaultCertificateWithPolicy>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
            this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

        /// <summary>
        /// Updates the status of the certificate operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = _client.GetPendingCertificate(Properties.Name, _requestedOperation, cancellationToken);

                _response = pollResponse.GetRawResponse();

                Properties = pollResponse;

                // Response value should only ever be null for a delete request.
                if (Properties is null)
                {
                    if (_requestedOperation != CertificateOperationRequest.Delete)
                    {
                        throw new InvalidOperationException($"Expected response when requested operation is {_requestedOperation}");
                    }

                    _completed = true;

                    return GetRawResponse();
                }
            }

            if (Properties.Status == "completed")
            {
                Response<KeyVaultCertificateWithPolicy> getResponse = _client.GetCertificate(Properties.Name, cancellationToken);

                _response = getResponse.GetRawResponse();

                _value = getResponse.Value;

                _completed = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                if (_requestedOperation != CertificateOperationRequest.Cancel)
                {
                    throw new OperationCanceledException("The certificate operation has been canceled");
                }
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed");
            }

            return GetRawResponse();
        }

        /// <summary>
        /// Updates the status of the certificate operation.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = await _client.GetPendingCertificateAsync(Properties.Name, _requestedOperation, cancellationToken).ConfigureAwait(false);

                _response = pollResponse.GetRawResponse();

                Properties = pollResponse;

                // Response value should only ever be null for a delete request.
                if (Properties is null)
                {
                    if (_requestedOperation != CertificateOperationRequest.Delete)
                    {
                        throw new InvalidOperationException($"Expected response when requested operation is {_requestedOperation}");
                    }

                    _completed = true;

                    return GetRawResponse();
                }
            }

            if (Properties.Status == "completed")
            {
                Response<KeyVaultCertificateWithPolicy> getResponse = await _client.GetCertificateAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                _response = getResponse.GetRawResponse();

                _value = getResponse.Value;

                _completed = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                if (_requestedOperation != CertificateOperationRequest.Cancel)
                {
                    throw new OperationCanceledException("The certificate operation has been canceled");
                }
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed, see Properties.Error for more details");
            }

            return GetRawResponse();
        }

        /// <summary>
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual void Cancel(CancellationToken cancellationToken = default)
        {
            _requestedOperation = CertificateOperationRequest.Cancel;

            Response<CertificateOperationProperties> response = _client.CancelCertificateOperation(Properties.Name, cancellationToken);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Task"/> to track the service request.</returns>
        public virtual async Task CancelAsync(CancellationToken cancellationToken = default)
        {
            _requestedOperation = CertificateOperationRequest.Cancel;

            Response<CertificateOperationProperties> response = await _client.CancelCertificateOperationAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual void Delete(CancellationToken cancellationToken = default)
        {
            _requestedOperation = CertificateOperationRequest.Delete;

            Response<CertificateOperationProperties> response = _client.DeleteCertificateOperation(Properties.Name, cancellationToken);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Task"/> to track the service request.</returns>
        public virtual async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            _requestedOperation = CertificateOperationRequest.Delete;

            Response<CertificateOperationProperties> response = await _client.DeleteCertificateOperationAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

            _response = response.GetRawResponse();

            Properties = response;
        }
    }
}
