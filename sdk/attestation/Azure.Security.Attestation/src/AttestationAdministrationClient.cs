// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.Attestation.Models;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Attestation Client for the Microsoft Azure Attestation service.
    ///
    /// The Attestation client contains the implementation of the "Attest" family of MAA apis.
    /// </summary>
    public class AttestationAdministrationClient
    {
        private readonly AttestationClientOptions _options;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolicyRestClient _policyClient;
        private readonly PolicyCertificatesRestClient _policyManagementClient;
        private readonly AttestationClient _attestationClient;

        private IReadOnlyList<AttestationSigner> _signers;
        private object _statelock = new object();

        // Default scope for data plane APIs.
        private const string DefaultScope = "https://attest.azure.net/.default";

        /// <summary>
        /// Returns the URI used to communicate with the service.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
#pragma warning disable CA1801
        public AttestationAdministrationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new AttestationClientOptions())
        {
        }
#pragma warning restore

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
        /// <param name="options"><see cref="AttestationClientOptions"/> used to configure the API client.</param>
#pragma warning disable CA1801
        public AttestationAdministrationClient(Uri endpoint, TokenCredential credential, AttestationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _options = options;

            // Add the authentication policy to our builder.
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, DefaultScope));

            // Initialize the ClientDiagnostics.
            _clientDiagnostics = new ClientDiagnostics(options);

            Endpoint = endpoint;

            // Initialize the Policy Rest Client.
            _policyClient = new PolicyRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri, options.Version);

            // Initialize the Certificates Rest Client.
            _policyManagementClient = new PolicyCertificatesRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri, options.Version);

            // Initialize the Attestation Rest Client.
            _attestationClient = new AttestationClient(endpoint, credential, options);
        }
#pragma warning restore

        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        protected AttestationAdministrationClient()
        {
        }

#pragma warning disable CA1822
#pragma warning disable CA1801
        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{StoredAttestationPolicy}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<StoredAttestationPolicy> GetPolicy(AttestationType attestationType, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicy)}");
            scope.Start();
            try
            {
                var result = _policyClient.Get(attestationType, cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }

                using var document = JsonDocument.Parse(token.TokenBody);
                PolicyResult policyResult = PolicyResult.DeserializePolicyResult(document.RootElement);

                return new AttestationResponse<StoredAttestationPolicy>(result.GetRawResponse(), policyResult.PolicyToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{StoredAttestationPolicy}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<StoredAttestationPolicy>> GetPolicyAsync(AttestationType attestationType, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicy)}");
            scope.Start();
            try
            {
                var result = await _policyClient.GetAsync(attestationType, cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                using var document = JsonDocument.Parse(token.TokenBody);
                PolicyResult policyResult = PolicyResult.DeserializePolicyResult(document.RootElement);
                return new AttestationResponse<StoredAttestationPolicy>(result.GetRawResponse(), policyResult.PolicyToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Sets the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> whose policy should be set.</param>
        /// <param name="policyToSet"><see cref="AttestationToken"/> specifying the new stored attestation policy.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyResult> SetPolicy(AttestationType attestationType, AttestationToken policyToSet, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                var result = _policyClient.Set(attestationType, policyToSet.ToString(), cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Sets the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> whose policy should be set.</param>
        /// <param name="policyToSet"><see cref="AttestationToken"/> specifying the new stored attestation policy.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyResult>> SetPolicyAsync(AttestationType attestationType, AttestationToken policyToSet, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                var result = await _policyClient.SetAsync(attestationType, policyToSet.ToString(), cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resets the policy for the specified <see cref="AttestationType"/> to the default value.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> whose policy should be reset.</param>
        /// <param name="authorizationToken">Signed JSON Web Token signed by one of the policy management certificates used to verify the caller is authorized to reset policy to the default value..</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyResult> ResetPolicy(AttestationType attestationType, AttestationToken authorizationToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                if (authorizationToken == null)
                {
                    authorizationToken = new UnsecuredAttestationToken();
                }
                var result = _policyClient.Reset(attestationType, authorizationToken.ToString(), cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resets the policy for the specified <see cref="AttestationType"/> to the default value.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> whose policy should be reset.</param>
        /// <param name="authorizationToken">Signed JSON Web Token signed by one of the policy management certificates used to verify the caller is authorized to reset policy to the default value..</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyResult>> ResetPolicyAsync(AttestationType attestationType, AttestationToken authorizationToken = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                if (authorizationToken == null)
                {
                    authorizationToken = new UnsecuredAttestationToken();
                }
                var result = await _policyClient.ResetAsync(attestationType, authorizationToken.ToString(), cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the set of policy management certificates currently configured for the attestation service.
        ///
        /// If the service is running in AAD mode, this list will be empty.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel the operation.</param>
        /// <returns>A set of <see cref="X509Certificate2"/> objects representing the set of root certificates for policy management.</returns>
        public virtual AttestationResponse<PolicyCertificatesResult> GetPolicyManagementCertificates(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicyManagementCertificates)}");
            scope.Start();
            try
            {
                var result = _policyManagementClient.Get(cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns the set of policy management certificates currently configured for the attestation service.
        ///
        /// If the service is running in AAD mode, this list will be empty.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel the operation.</param>
        /// <returns>A set of <see cref="X509Certificate2"/> objects representing the set of root certificates for policy management.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesResult>> GetPolicyManagementCertificatesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicyManagementCertificates)}");
            scope.Start();
            try
            {
                var result = await _policyManagementClient.GetAsync(cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="certificateToAdd">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> AddPolicyManagementCertificate(SecuredAttestationToken certificateToAdd, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var result = _policyManagementClient.Add(certificateToAdd.ToString(), cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesModificationResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="certificateToAdd">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> AddPolicyManagementCertificateAsync(SecuredAttestationToken certificateToAdd, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var result = await _policyManagementClient.AddAsync(certificateToAdd.ToString(), cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesModificationResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="certificateToAdd">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> RemovePolicyManagementCertificate(SecuredAttestationToken certificateToAdd, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var result = _policyManagementClient.Remove(certificateToAdd.ToString(), cancellationToken);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesModificationResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Removes one of the attestation policy management certificates.
        /// </summary>
        /// <param name="certificateToAdd">Attestation Type to retrive.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> RemovePolicyManagementCertificateAsync(SecuredAttestationToken certificateToAdd, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var result = await _policyManagementClient.RemoveAsync(certificateToAdd.ToString(), cancellationToken).ConfigureAwait(false);
                var token = new AttestationToken(result.Value.Token);
                if (_options.ValidateAttestationTokens)
                {
                    token.ValidateToken(GetSigners(), _options.ValidationCallback);
                }
                return new AttestationResponse<PolicyCertificatesModificationResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning restore

        private IReadOnlyList<AttestationSigner> GetSigners()
        {
            lock (_statelock)
            {
                if (_signers == null)
                {
                    _signers = _attestationClient.GetSigningCertificates().Value;
                }

                return _signers;
            }
        }
    }
}
