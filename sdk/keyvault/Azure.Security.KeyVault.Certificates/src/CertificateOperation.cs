// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A long running poller operation which can be used to track the status of a pending key vault certificate operation.
    /// </summary>
    public class CertificateOperation : Operation<CertificateWithPolicy>
    {
        private bool _hasValue = false;
        private bool _completed = false;
        private CertificateClient _client;

        internal CertificateOperation(Response<CertificateOperationProperties> properties, CertificateClient client)
            : base(properties.Value.Id.ToString())
        {
            Properties = properties;

            _client = client;
        }

        /// <summary>
        /// The properties of the pending certificate operation
        /// </summary>
        public CertificateOperationProperties Properties { get; private set; }

        /// <summary>
        /// Specifies whether the operation has reached a terminal state
        /// </summary>
        public override bool HasCompleted => _completed;

        /// <summary>
        /// Specifies whether the Value property can be safely accessed
        /// </summary>
        public override bool HasValue => _hasValue;

        /// <summary>
        /// Updates the status of the certificate operation
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation</returns>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = _client.GetPendingCertificate(Properties.Name, cancellationToken);

                SetRawResponse(pollResponse.GetRawResponse());

                Properties = pollResponse;
            }

            if (Properties.Status == "completed")
            {
                Response<CertificateWithPolicy> getResponse = _client.GetCertificateWithPolicy(Properties.Name, cancellationToken);

                SetRawResponse(getResponse.GetRawResponse());

                Value = getResponse.Value;

                _completed = true;

                _hasValue = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                throw new OperationCanceledException("The certificate opertation has been canceled");
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed");
            }

            return GetRawResponse();
        }

        /// <summary>
        /// Updates the status of the certificate operation
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The raw response of the poll operation</returns>
        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            if (!_completed)
            {
                Response<CertificateOperationProperties> pollResponse = await _client.GetPendingCertificateAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                SetRawResponse(pollResponse.GetRawResponse());

                Properties = pollResponse;
            }

            if (Properties.Status == "completed")
            {
                Response<CertificateWithPolicy> getResponse = await _client.GetCertificateWithPolicyAsync(Properties.Name, cancellationToken).ConfigureAwait(false);

                SetRawResponse(getResponse.GetRawResponse());

                Value = getResponse.Value;

                _completed = true;

                _hasValue = true;
            }
            else if (Properties.Status == "cancelled")
            {
                _completed = true;

                throw new OperationCanceledException("The certificate opertation has been canceled");
            }
            else if (Properties.Error != null)
            {
                _completed = true;

                throw new InvalidOperationException("The certificate operation failed, see Properties.Error for more details");
            }

            return GetRawResponse();
        }
    }
}
