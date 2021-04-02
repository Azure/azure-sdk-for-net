// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

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
        /// <param name="attestationType"><see cref="AttestationType"/> to retrive.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{String}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// This API returns the underlying attestation policy object stored in the attestation service for this <paramref name="attestationType"/>.
        ///
        /// The actual service response to the API is an RFC 7519 JSON Web Token. This token can be retrieved from <see cref="AttestationResponse{T}.Token"/>.
        /// For the GetPolicy API, the body of the <see cref="AttestationResponse{T}.Token"/> is a <see cref="StoredAttestationPolicy"/> object, NOT a string.
        /// </remarks>
        public virtual AttestationResponse<string> GetPolicy(AttestationType attestationType, CancellationToken cancellationToken = default)
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

                var response = new AttestationResponse<StoredAttestationPolicy>(result.GetRawResponse(), policyResult.PolicyToken);

                return new AttestationResponse<string>(result.GetRawResponse(), policyResult.PolicyToken, response.Value.AttestationPolicy);
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{String}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// This API returns the underlying attestation policy object stored in the attestation service for this <paramref name="attestationType"/>.
        ///
        /// The actual service response to the API is an RFC 7519 JSON Web Token. This token can be retrieved from <see cref="AttestationResponse{T}.Token"/>.
        /// For the GetPolicyAsync API, the body of the <see cref="AttestationResponse{T}.Token"/> is a <see cref="StoredAttestationPolicy"/> object, NOT a string.
        /// </remarks>
        public virtual async Task<AttestationResponse<string>> GetPolicyAsync(AttestationType attestationType, CancellationToken cancellationToken = default)
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
                var response = new AttestationResponse<StoredAttestationPolicy>(result.GetRawResponse(), policyResult.PolicyToken);

                return new AttestationResponse<string>(result.GetRawResponse(), policyResult.PolicyToken, response.Value.AttestationPolicy);
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
        /// <param name="policyToSet">Specifies the attestation policy to set.</param>
        /// <param name="signingKey">If provided, specifies the signing key used to sign the request to the attestation service.</param>
        /// <param name="signingCertificate">If provided, specifies the X.509 certificate which will be used to validate the request with the attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// The <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are optional, but if one is provided the other must also be provided.
        ///
        /// If the <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <paramref name="signingCertificate"/> parameter MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// Clients need to be able to verify that the attestation policy document was not modified before the policy document was received by the attestation service's enclave.
        /// There are two properties provided in the [PolicyResult][attestation_policy_result] that can be used to verify that the service received the policy document:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="PolicyResult.PolicySigner"/> - if the <see cref="SetPolicy(AttestationType, string, AsymmetricAlgorithm, X509Certificate2, CancellationToken)"/> call included a signing certificate, this will be the certificate provided at the time of the `SetPolicy` call. If no policy signer was set, this will be null. </description>
        /// </item>
        /// <item>
        /// <description><see cref="PolicyResult.PolicyTokenHash"/> - this is the hash of the [JSON Web Token][json_web_token] sent to the service</description>
        /// </item>
        /// </list>
        /// To verify the hash, clients can generate an attestation token and verify the hash generated from that token:
        /// <code snippet="Snippet:VerifySigningHash">
        /// // The SetPolicyAsync API will create a SecuredAttestationToken to transmit the policy.
        /// var policySetToken = new SecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }, TestEnvironment.PolicySigningKey0, policyTokenSigner);
        ///
        /// var shaHasher = SHA256Managed.Create();
        /// var attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));
        ///
        /// CollectionAssert.AreEqual(attestationPolicyHash, setResult.Value.PolicyTokenHash);
        /// </code>
        ///
        /// If the signing key and certificate are not provided, then the SetPolicyAsync API will create an unsecured attestation token
        /// wrapping the attestation policy. To validate the <see cref="PolicyResult.PolicyTokenHash"/> return value, a developer
        /// can create their own <see cref="UnsecuredAttestationToken"/> and create the hash of that.
        /// <code>
        /// var shaHasher = SHA256Managed.Create();
        /// var policySetToken = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging });
        /// disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));
        /// </code>
        /// </remarks>
        public virtual AttestationResponse<PolicyResult> SetPolicy(
            AttestationType attestationType,
            string policyToSet,
            AsymmetricAlgorithm signingKey = default,
            X509Certificate2 signingCertificate = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(policyToSet, nameof(policyToSet));

            if (signingKey is null && signingCertificate is not null || signingCertificate is null && signingKey is not null)
            {
                throw new ArgumentException($"If you specify '{nameof(signingKey)}' or '{nameof(signingCertificate)}', you must also specify '{nameof(signingCertificate)}' or '{nameof(signingKey)}'.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet;
                if (signingKey is null)
                {
                    tokenToSet = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = policyToSet, });
                }
                else
                {
                    tokenToSet = new SecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = policyToSet,}, signingKey, signingCertificate);
                }
                var result = _policyClient.Set(attestationType, tokenToSet.ToString(), cancellationToken);
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
        /// <param name="policyToSet">Specifies the attestation policy to set.</param>
        /// <param name="signingKey">If provided, specifies the signing key used to sign the request to the attestation service.</param>
        /// <param name="signingCertificate">If provided, specifies the X.509 certificate which will be used to validate the request with the attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// The <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are optional, but if one is provided the other must also be provided.
        /// <para/>
        /// If the <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <paramref name="signingCertificate"/> parameter MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// <para/>
        /// Clients need to be able to verify that the attestation policy document was not modified before the policy document was received by the attestation service's enclave.
        /// There are two properties provided in the [PolicyResult][attestation_policy_result] that can be used to verify that the service received the policy document:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="PolicyResult.PolicySigner"/> - if the <see cref="SetPolicy(AttestationType, string, AsymmetricAlgorithm, X509Certificate2, CancellationToken)"/> call included a signing certificate, this will be the certificate provided at the time of the `SetPolicy` call. If no policy signer was set, this will be null. </description>
        /// </item>
        /// <item>
        /// <description><see cref="PolicyResult.PolicyTokenHash"/> - this is the hash of the [JSON Web Token][json_web_token] sent to the service</description>
        /// </item>
        /// </list>
        /// To verify the hash, clients can generate an attestation token and verify the hash generated from that token:
        /// <code snippet="Snippet:VerifySigningHash">
        /// // The SetPolicyAsync API will create a SecuredAttestationToken to transmit the policy.
        /// var policySetToken = new SecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }, TestEnvironment.PolicySigningKey0, policyTokenSigner);
        ///
        /// var shaHasher = SHA256Managed.Create();
        /// var attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));
        ///
        /// CollectionAssert.AreEqual(attestationPolicyHash, setResult.Value.PolicyTokenHash);
        /// </code>
        ///
        /// If the signing key and certificate are not provided, then the SetPolicyAsync API will create an unsecured attestation token
        /// wrapping the attestation policy. To validate the <see cref="PolicyResult.PolicyTokenHash"/> return value, a developer
        /// can create their own <see cref="UnsecuredAttestationToken"/> and create the hash of that.
        /// <code>
        /// var shaHasher = SHA256Managed.Create();
        /// var policySetToken = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging });
        /// disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));
        /// </code>
        /// </remarks>
        public virtual async Task<AttestationResponse<PolicyResult>> SetPolicyAsync(
            AttestationType attestationType,
            string policyToSet,
            AsymmetricAlgorithm signingKey = default,
            X509Certificate2 signingCertificate = default,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(policyToSet))
            {
                throw new ArgumentException($"'{nameof(policyToSet)}' cannot be null or empty.", nameof(policyToSet));
            }

            if (signingKey is null && signingCertificate is not null || signingCertificate is null && signingKey is not null)
            {
                throw new ArgumentException($"If you specify '{nameof(signingKey)}' or '{nameof(signingCertificate)}', you must also specify '{nameof(signingCertificate)}' or '{nameof(signingKey)}'.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet;
                if (signingKey is null)
                {
                    tokenToSet = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = policyToSet, });
                }
                else
                {
                    tokenToSet = new SecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = policyToSet, }, signingKey, signingCertificate);
                }

                var result = await _policyClient.SetAsync(attestationType, tokenToSet.ToString(), cancellationToken).ConfigureAwait(false);
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
        /// <param name="signingKey">If provided, specifies the signing key used to sign the request to the attestation service.</param>
        /// <param name="signingCertificate">If provided, specifies the X.509 certificate which will be used to validate the request with the attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// The <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are optional, but if one is provided the other must also be provided.
        /// <para/>
        /// If the <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <paramref name="signingCertificate"/> parameter MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// </remarks>
        ///
        public virtual AttestationResponse<PolicyResult> ResetPolicy(
            AttestationType attestationType,
            AsymmetricAlgorithm signingKey = default,
            X509Certificate2 signingCertificate = default,
            CancellationToken cancellationToken = default)
        {
            if (signingKey is null && signingCertificate is not null || signingCertificate is null && signingKey is not null)
            {
                throw new ArgumentException($"If you specify '{nameof(signingKey)}' or '{nameof(signingCertificate)}', you must also specify '{nameof(signingCertificate)}' or '{nameof(signingKey)}'.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet;
                if (signingKey is null)
                {
                    tokenToSet = new UnsecuredAttestationToken();
                }
                else
                {
                    tokenToSet = new SecuredAttestationToken(signingKey, signingCertificate);
                }

                var result = _policyClient.Reset(attestationType, tokenToSet.ToString(), cancellationToken);
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
        /// <param name="signingKey">If provided, specifies the signing key used to sign the request to the attestation service.</param>
        /// <param name="signingCertificate">If provided, specifies the X.509 certificate which will be used to validate the request with the attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// The <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are optional, but if one is provided the other must also be provided.
        /// <para/>
        /// If the <paramref name="signingKey"/> and <paramref name="signingCertificate"/> parameters are not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <paramref name="signingCertificate"/> parameter MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// </remarks>
        public virtual async Task<AttestationResponse<PolicyResult>> ResetPolicyAsync(
            AttestationType attestationType,
            AsymmetricAlgorithm signingKey = default,
            X509Certificate2 signingCertificate = default,
            CancellationToken cancellationToken = default)
        {
            if (signingKey is null && signingCertificate is not null || signingCertificate is null && signingKey is not null)
            {
                throw new ArgumentException($"If you specify '{nameof(signingKey)}' or '{nameof(signingCertificate)}', you must also specify '{nameof(signingCertificate)}' or '{nameof(signingKey)}'.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet;
                if (signingKey is null)
                {
                    tokenToSet = new UnsecuredAttestationToken();
                }
                else
                {
                    tokenToSet = new SecuredAttestationToken(signingKey, signingCertificate);
                }

                var result = await _policyClient.ResetAsync(attestationType, tokenToSet.ToString(), cancellationToken).ConfigureAwait(false);
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
        /// Returns the set of policy management certificates currently configured for the attestation service instance.
        ///
        /// If the service instance is running in AAD mode, this list will always be empty.
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
        /// Returns the set of policy management certificates currently configured for the attestation service instance.
        ///
        /// If the service instance is running in AAD mode, this list will always be empty.
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
        /// Adds the specified new signing certificate to the set of policy management certificates.
        /// </summary>
        /// <param name="newSigningCertificate">The new certificate to add.</param>
        /// <param name="existingSigningKey">An existing key corresponding to the existing certificate.</param>
        /// <param name="existingSigningCertificate">One of the existing policy management certificates.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// </remarks>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> AddPolicyManagementCertificate(
            X509Certificate2 newSigningCertificate,
            AsymmetricAlgorithm existingSigningKey,
            X509Certificate2 existingSigningCertificate,
            CancellationToken cancellationToken = default)
        {
            if (newSigningCertificate is null)
            {
                throw new ArgumentNullException(nameof(newSigningCertificate));
            }

            if (existingSigningKey is null)
            {
                throw new ArgumentNullException(nameof(existingSigningKey));
            }

            if (existingSigningCertificate is null)
            {
                throw new ArgumentNullException(nameof(existingSigningCertificate));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToAdd = new SecuredAttestationToken(
                        new PolicyCertificateModification(newSigningCertificate),
                        existingSigningKey,
                        existingSigningCertificate);
                var result = _policyManagementClient.Add(tokenToAdd.ToString(), cancellationToken);
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
        /// Adds the specified new signing certificate to the set of policy management certificates.
        /// </summary>
        /// <param name="newSigningCertificate">The new certificate to add.</param>
        /// <param name="existingSigningKey">An existing key corresponding to the existing certificate.</param>
        /// <param name="existingSigningCertificate">One of the existing policy management certificates.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> AddPolicyManagementCertificateAsync(
            X509Certificate2 newSigningCertificate,
            AsymmetricAlgorithm existingSigningKey,
            X509Certificate2 existingSigningCertificate,
            CancellationToken cancellationToken = default)
        {
            if (newSigningCertificate is null)
            {
                throw new ArgumentNullException(nameof(newSigningCertificate));
            }

            if (existingSigningKey is null)
            {
                throw new ArgumentNullException(nameof(existingSigningKey));
            }

            if (existingSigningCertificate is null)
            {
                throw new ArgumentNullException(nameof(existingSigningCertificate));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToAdd = new SecuredAttestationToken(
                        new PolicyCertificateModification(newSigningCertificate),
                        existingSigningKey,
                        existingSigningCertificate);
                var result = await _policyManagementClient.AddAsync(tokenToAdd.ToString(), cancellationToken).ConfigureAwait(false);
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
        /// <param name="certificateToRemove">The certificate to remove.</param>
        /// <param name="existingSigningKey">An existing key corresponding to the existing certificate.</param>
        /// <param name="existingSigningCertificate">An existing policy management certificates.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> RemovePolicyManagementCertificate(
            X509Certificate2 certificateToRemove,
            AsymmetricAlgorithm existingSigningKey,
            X509Certificate2 existingSigningCertificate,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToRemove = new SecuredAttestationToken(
                        new PolicyCertificateModification(certificateToRemove),
                        existingSigningKey,
                        existingSigningCertificate);

                var result = _policyManagementClient.Remove(tokenToRemove.ToString(), cancellationToken);
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
        /// <param name="certificateToRemove">The certificate to remove.</param>
        /// <param name="existingSigningKey">An existing key corresponding to the existing certificate.</param>
        /// <param name="existingSigningCertificate">One of the existing policy management certificates.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> RemovePolicyManagementCertificateAsync(
            X509Certificate2 certificateToRemove,
            AsymmetricAlgorithm existingSigningKey,
            X509Certificate2 existingSigningCertificate,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToRemove = new SecuredAttestationToken(
                        new PolicyCertificateModification(certificateToRemove),
                        existingSigningKey,
                        existingSigningCertificate);

                var result = await _policyManagementClient.RemoveAsync(tokenToRemove.ToString(), cancellationToken).ConfigureAwait(false);
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
