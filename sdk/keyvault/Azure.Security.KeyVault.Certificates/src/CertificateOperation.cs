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
        private const string CancelledStatus = "cancelled";
        private const string CompletedStatus = "completed";

        private readonly CertificateClient _client;

        private bool _completed;
        private Response _response;
        private KeyVaultCertificateWithPolicy _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateOperation"/> class.
        /// You must call <see cref="UpdateStatus(CancellationToken)"/> or <see cref="UpdateStatusAsync(CancellationToken)"/> before you can get the <see cref="Value"/>.
        /// </summary>
        /// <param name="client">A <see cref="CertificateClient"/> for the Key Vault where the operation was started.</param>
        /// <param name="name">The name of the certificate being created.</param>
        public CertificateOperation(CertificateClient client, string name)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Properties = new CertificateOperationProperties(client.VaultUri, name);

            Id = Properties.Id.ToString();
            _client = client;
        }

        internal CertificateOperation(Response<CertificateOperationProperties> properties, CertificateClient client)
        {
            Properties = properties;

            Id = Properties.Id.ToString();
            _client = client;
        }

        /// <summary> Initializes a new instance of <see cref="CertificateOperation" /> for mocking. </summary>
        protected CertificateOperation() {}

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
        public override KeyVaultCertificateWithPolicy Value
        {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
            get
            {
                if (Properties is null)
                {
                    throw new InvalidOperationException("The operation was deleted so no value is available.");
                }

                if (Properties.Status == CancelledStatus)
                {
                    throw new OperationCanceledException("The operation was canceled so no value is available.");
                }

                if (Properties.Error != null)
                {
                    throw new InvalidOperationException($"The certificate operation failed: {Properties.Error.Message}");
                }

                return OperationHelpers.GetValue(ref _value);
            }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
        }

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
        /// This operation requires the certificates/get permission.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/get permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation.</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            using var _ = new UpdateStatusActivity(this);

            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = _client.GetPendingCertificate(Properties.Name, cancellationToken);

                _response = pollResponse.GetRawResponse();

                Properties = pollResponse;

                // Properties will be null if deleted.
                if (Properties is null)
                {
                    _completed = true;
                    return _response;
                }
            }

            if (Properties.Status == CompletedStatus)
            {
                Response<KeyVaultCertificateWithPolicy> getResponse = _client.GetCertificate(Properties.Name, cancellationToken);

                _response = getResponse.GetRawResponse();

                _value = getResponse.Value;

                _completed = true;
            }
            else if (Properties.Status == CancelledStatus)
            {
                _completed = true;
            }
            else if (Properties.Error != null)
            {
                _completed = true;
            }

            return GetRawResponse();
        }

        /// <summary>
        /// Updates the status of the certificate operation.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/get permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation.</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            using var _ = new UpdateStatusActivity(this);

            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = await _client.GetPendingCertificateAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                _response = pollResponse.GetRawResponse();

                Properties = pollResponse;

                // Properties will be null if deleted.
                if (Properties is null)
                {
                    _completed = true;
                    return _response;
                }
            }

            if (Properties.Status == CompletedStatus)
            {
                Response<KeyVaultCertificateWithPolicy> getResponse = await _client.GetCertificateAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                _response = getResponse.GetRawResponse();

                _value = getResponse.Value;

                _completed = true;
            }
            else if (Properties.Status == CancelledStatus)
            {
                _completed = true;
            }
            else if (Properties.Error != null)
            {
                _completed = true;
            }

            return GetRawResponse();
        }

        /// <summary>
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/update permission.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/update permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual void Cancel(CancellationToken cancellationToken = default)
        {
            Response<CertificateOperationProperties> response = _client.CancelCertificateOperation(Properties.Name, cancellationToken);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/update permission.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/update permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Task"/> to track the service request.</returns>
        public virtual async Task CancelAsync(CancellationToken cancellationToken = default)
        {
            Response<CertificateOperationProperties> response = await _client.CancelCertificateOperationAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/delete permission.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/update permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual void Delete(CancellationToken cancellationToken = default)
        {
            Response<CertificateOperationProperties> response = _client.DeleteCertificateOperation(Properties.Name, cancellationToken);

            _response = response.GetRawResponse();

            Properties = response;
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault. This operation requires the certificates/delete permission.
        /// </summary>
        /// <remarks>
        /// This operation requires the certificates/update permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Task"/> to track the service request.</returns>
        public virtual async Task DeleteAsync(CancellationToken cancellationToken = default)
        {
            Response<CertificateOperationProperties> response = await _client.DeleteCertificateOperationAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

            _response = response.GetRawResponse();

            Properties = response;
        }

        private class UpdateStatusActivity : IDisposable
        {
            private readonly CertificateOperation _operation;

            public UpdateStatusActivity(CertificateOperation operation)
            {
                _operation = operation;

                EventSource.BeginUpdateStatus(_operation.Properties);
            }

            public void Dispose()
            {
                EventSource.EndUpdateStatus(_operation.Properties);
            }

            private static CertificatesEventSource EventSource => CertificatesEventSource.Singleton;
        }
    }
}
