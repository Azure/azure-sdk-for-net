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
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public class AttestationAdministrationClient
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly AttestationClientOptions _options;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly PolicyRestClient _policyClient;
        private readonly PolicyCertificatesRestClient _policyManagementClient;
        private readonly AttestationClient _attestationClient;

        private IReadOnlyList<AttestationSigner> _signers;
        // NOTE The SemaphoreSlim type does NOT need Disposable based on the current usage because AvailableWaitHandle is not referenced.
        private SemaphoreSlim _statelock = new SemaphoreSlim(1, 1);

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
        public AttestationAdministrationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new AttestationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
        /// <param name="options"><see cref="AttestationClientOptions"/> used to configure the API client.</param>
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

        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        protected AttestationAdministrationClient()
        {
        }

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{String}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// This API returns the underlying attestation policy object stored in the attestation service for this <paramref name="attestationType"/>.
        ///
        /// The actual service response to the API is an RFC 7519 JSON Web Token(see https://tools.ietf.org/html/rfc7519"). This token can be retrieved from <see cref="AttestationResponse{T}.Token"/>.
        /// For the GetPolicy API, the body of the <see cref="AttestationResponse{T}.Token"/> is a <see cref="StoredAttestationPolicy"/> object, NOT a string.
        /// </remarks>
        public virtual AttestationResponse<string> GetPolicy(AttestationType attestationType, CancellationToken cancellationToken = default)
            => GetPolicyInternalAsync(attestationType, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType">Attestation Type to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{String}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// This API returns the underlying attestation policy object stored in the attestation service for this <paramref name="attestationType"/>.
        ///
        /// The actual service response to the API is an RFC 7519 JSON Web Token(see https://tools.ietf.org/html/rfc7519"). This token can be retrieved from <see cref="AttestationResponse{T}.Token"/>.
        /// For the GetPolicyAsync API, the body of the <see cref="AttestationResponse{T}.Token"/> is a <see cref="StoredAttestationPolicy"/> object, NOT a string.
        /// </remarks>
        public virtual async Task<AttestationResponse<string>> GetPolicyAsync(AttestationType attestationType, CancellationToken cancellationToken = default)
            => await GetPolicyInternalAsync(attestationType, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves the attesttion policy for the specified <see cref="AttestationType"/>.
        /// </summary>
        /// <param name="attestationType"><see cref="AttestationType"/> to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <param name="async">True if the call should be asynchronous.</param>
        /// <returns>An <see cref="AttestationResponse{String}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// This API returns the underlying attestation policy object stored in the attestation service for this <paramref name="attestationType"/>.
        ///
        /// The actual service response to the API is an RFC 7519 JSON Web Token (see https://tools.ietf.org/html/rfc7519"). This token can be retrieved from <see cref="AttestationResponse{T}.Token"/>.
        /// For the GetPolicy API, the body of the <see cref="AttestationResponse{T}.Token"/> is a <see cref="StoredAttestationPolicy"/> object, NOT a string.
        /// </remarks>
        private async Task<AttestationResponse<string>> GetPolicyInternalAsync(AttestationType attestationType, bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicy)}");
            scope.Start();
            try
            {
                Response<PolicyResponse> result;
                if (async)
                {
                    result = await _policyClient.GetAsync(attestationType, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    result = _policyClient.Get(attestationType, cancellationToken);
                }

                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(async, cancellationToken).ConfigureAwait(false);

                    if (!await token.ValidateTokenInternal(_options.TokenOptions, signers, async, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }

                PolicyModificationResult policyResult = token.GetBody<PolicyModificationResult>();

                var response = new AttestationResponse<StoredAttestationPolicy>(result.GetRawResponse(), policyResult.PolicyToken);

                return new AttestationResponse<string>(result.GetRawResponse(), token, response.Value.AttestationPolicy);
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// If the <paramref name="signingKey"/> parameter is not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <see cref="AttestationTokenSigningKey.Certificate"/> field MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// Clients need to be able to verify that the attestation policy document was not modified before the policy document was received by the attestation service's enclave.
        /// There are two properties provided in the [PolicyResult][attestation_policy_result] that can be used to verify that the service received the policy document:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="PolicyModificationResult.PolicySigner"/> - if the <see cref="SetPolicy(AttestationType, string, AttestationTokenSigningKey, CancellationToken)"/> call included a signing certificate, this will be the certificate provided at the time of the `SetPolicy` call. If no policy signer was set, this will be null. </description>
        /// </item>
        /// <item>
        /// <description><see cref="PolicyModificationResult.PolicyTokenHash"/> - this is the hash of the [JSON Web Token][json_web_token] sent to the service</description>
        /// </item>
        /// </list>
        /// To verify the hash, clients can generate an attestation token and verify the hash generated from that token:
        /// <code snippet="Snippet:VerifySigningHash" language="csharp">
        /// // The SetPolicyAsync API will create an AttestationToken signed with the TokenSigningKey to transmit the policy.
        /// // To verify that the policy specified by the caller was received by the service inside the enclave, we
        /// // verify that the hash of the policy document returned from the Attestation Service matches the hash
        /// // of an attestation token created locally.
        /// TokenSigningKey signingKey = new TokenSigningKey(&lt;Customer provided signing key&gt;, &lt;Customer provided certificate&gt;)
        /// var policySetToken = new AttestationToken(
        ///     BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }),
        ///     signingKey);
        ///
        /// using var shaHasher = SHA256.Create();
        /// byte[] attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));
        ///
        /// Debug.Assert(attestationPolicyHash.SequenceEqual(setResult.Value.PolicyTokenHash.ToArray()));
        /// </code>
        ///
        /// If the signing key and certificate are not provided, then the SetPolicyAsync API will create an unsecured attestation token
        /// wrapping the attestation policy. To validate the <see cref="PolicyModificationResult.PolicyTokenHash"/> return value, a developer
        /// can create their own <see cref="AttestationToken"/> and create the hash of that.
        /// <code>
        /// using var shaHasher = SHA256Managed.Create();
        /// var policySetToken = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging });
        /// disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));
        /// </code>
        /// </remarks>
        public virtual AttestationResponse<PolicyModificationResult> SetPolicy(
            AttestationType attestationType,
            string policyToSet,
            AttestationTokenSigningKey signingKey = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(policyToSet, nameof(policyToSet));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet = new AttestationToken(
                    BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = policyToSet, }),
                    signingKey);
                var result = _policyClient.Set(attestationType, tokenToSet.Serialize(), cancellationToken);
                var token = AttestationToken.Deserialize(result.Value.Token);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = GetSignersAsync(false, cancellationToken).EnsureCompleted();
                    if (!token.ValidateToken(_options.TokenOptions, signers, cancellationToken))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                return new AttestationResponse<PolicyModificationResult>(result.GetRawResponse(), token);
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// If the <paramref name="signingKey"/> parameter is not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <see cref="AttestationTokenSigningKey.Certificate"/> field MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// Clients need to be able to verify that the attestation policy document was not modified before the policy document was received by the attestation service's enclave.
        /// There are two properties provided in the [PolicyResult][attestation_policy_result] that can be used to verify that the service received the policy document:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="PolicyModificationResult.PolicySigner"/> - if the <see cref="SetPolicy(AttestationType, string, AttestationTokenSigningKey, CancellationToken)"/> call included a signing certificate, this will be the certificate provided at the time of the `SetPolicy` call. If no policy signer was set, this will be null. </description>
        /// </item>
        /// <item>
        /// <description><see cref="PolicyModificationResult.PolicyTokenHash"/> - this is the hash of the [JSON Web Token][json_web_token] sent to the service</description>
        /// </item>
        /// </list>
        /// To verify the hash, clients can generate an attestation token and verify the hash generated from that token:
        /// <code snippet="Snippet:VerifySigningHash" language="csharp">
        /// // The SetPolicyAsync API will create an AttestationToken signed with the TokenSigningKey to transmit the policy.
        /// // To verify that the policy specified by the caller was received by the service inside the enclave, we
        /// // verify that the hash of the policy document returned from the Attestation Service matches the hash
        /// // of an attestation token created locally.
        /// TokenSigningKey signingKey = new TokenSigningKey(&lt;Customer provided signing key&gt;, &lt;Customer provided certificate&gt;)
        /// var policySetToken = new AttestationToken(
        ///     BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = attestationPolicy }),
        ///     signingKey);
        ///
        /// using var shaHasher = SHA256.Create();
        /// byte[] attestationPolicyHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));
        ///
        /// Debug.Assert(attestationPolicyHash.SequenceEqual(setResult.Value.PolicyTokenHash.ToArray()));
        /// </code>
        ///
        /// If the signing key and certificate are not provided, then the SetPolicyAsync API will create an unsecured attestation token
        /// wrapping the attestation policy. To validate the <see cref="PolicyModificationResult.PolicyTokenHash"/> return value, a developer
        /// can create their own <see cref="AttestationToken"/> and create the hash of that.
        /// <code>
        /// using var shaHasher = SHA256Managed.Create();
        /// var policySetToken = new AttestationToken(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging });
        /// disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));
        /// </code>
        /// </remarks>
        public virtual async Task<AttestationResponse<PolicyModificationResult>> SetPolicyAsync(
            AttestationType attestationType,
            string policyToSet,
            AttestationTokenSigningKey signingKey = default,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(policyToSet))
            {
                throw new ArgumentException($"'{nameof(policyToSet)}' cannot be null or empty.", nameof(policyToSet));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(SetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet = new AttestationToken(BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = policyToSet, }), signingKey);

                var result = await _policyClient.SetAsync(attestationType, tokenToSet.Serialize(), cancellationToken).ConfigureAwait(false);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(true, cancellationToken).ConfigureAwait(false);
                    if (!await token.ValidateTokenAsync(_options.TokenOptions, signers, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                return new AttestationResponse<PolicyModificationResult>(result.GetRawResponse(), token);
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
        /// <param name="signingKey">If provided, specifies the signing key and certificate used to sign the request to the attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// If the <paramref name="signingKey"/> parameter is not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <see cref="AttestationTokenSigningKey.Certificate"/> fieldMUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// </remarks>
        ///
        public virtual AttestationResponse<PolicyModificationResult> ResetPolicy(
            AttestationType attestationType,
            AttestationTokenSigningKey signingKey = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet = new AttestationToken(null, signingKey);

                var result = _policyClient.Reset(attestationType, tokenToSet.Serialize(), cancellationToken);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = GetSignersAsync(false, cancellationToken).EnsureCompleted();
                    if (!token.ValidateTokenInternal(_options.TokenOptions, signers, false, cancellationToken).EnsureCompleted())
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                return new AttestationResponse<PolicyModificationResult>(result.GetRawResponse(), token);
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// If the <paramref name="signingKey"/> parameter is not provided, then the policy document sent to the
        /// attestation service will be unsigned. Unsigned attestation policies are only allowed when the attestation instance is running in AAD mode - if the
        /// attestation instance is running in Isolated mode, then a signing key and signing certificate MUST be provided to ensure that the caller of the API is authorized to change policy.
        /// The <see cref="AttestationTokenSigningKey.Certificate"/> parameter MUST be one of the certificates returned by the <see cref="GetPolicyManagementCertificates(CancellationToken)"/> API.
        /// <para/>
        /// </remarks>
        public virtual async Task<AttestationResponse<PolicyModificationResult>> ResetPolicyAsync(
            AttestationType attestationType,
            AttestationTokenSigningKey signingKey = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(ResetPolicy)}");
            scope.Start();
            try
            {
                AttestationToken tokenToSet = new AttestationToken(null, signingKey);

                var result = await _policyClient.ResetAsync(attestationType, tokenToSet.Serialize(), cancellationToken).ConfigureAwait(false);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(true, cancellationToken).ConfigureAwait(false);
                    if (!await token.ValidateTokenAsync(_options.TokenOptions, signers, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                return new AttestationResponse<PolicyModificationResult>(result.GetRawResponse(), token);
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
        public virtual AttestationResponse<IReadOnlyList<X509Certificate2>> GetPolicyManagementCertificates(CancellationToken cancellationToken = default)
            => GetPolicyManagementCertificatesInternalAsync(false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Returns the set of policy management certificates currently configured for the attestation service instance.
        ///
        /// If the service instance is running in AAD mode, this list will always be empty.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel the operation.</param>
        /// <returns>A set of <see cref="X509Certificate2"/> objects representing the set of root certificates for policy management.</returns>
        public virtual async Task<AttestationResponse<IReadOnlyList<X509Certificate2>>> GetPolicyManagementCertificatesAsync(CancellationToken cancellationToken = default)
            => await GetPolicyManagementCertificatesInternalAsync(true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns the set of policy management certificates currently configured for the attestation service instance.
        ///
        /// If the service instance is running in AAD mode, this list will always be empty.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel the operation.</param>
        /// <param name="async">True if this request should be processed asyncly.</param>
        /// <returns>A set of <see cref="X509Certificate2"/> objects representing the set of root certificates for policy management.</returns>
        private async Task<AttestationResponse<IReadOnlyList<X509Certificate2>>> GetPolicyManagementCertificatesInternalAsync(bool async, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(GetPolicyManagementCertificates)}");
            scope.Start();
            try
            {
                Response<PolicyCertificatesResponse> result;
                if (async)
                {
                    result = await _policyManagementClient.GetAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    result = _policyManagementClient.Get(cancellationToken);
                }
                var token = AttestationToken.Deserialize(result.Value.Token);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(async, cancellationToken).ConfigureAwait(false);
                    if (!await token.ValidateTokenInternal(_options.TokenOptions, signers, async, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                List<X509Certificate2> certificates = new List<X509Certificate2>();
                foreach (var cert in token.GetBody<PolicyCertificatesResult>().InternalPolicyCertificates.Keys)
                {
                    certificates.Add(new X509Certificate2(Convert.FromBase64String(cert.X5C[0])));
                }
                return new AttestationResponse<IReadOnlyList<X509Certificate2>>(result.GetRawResponse(), token, certificates.AsReadOnly());
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        /// <remarks>
        /// </remarks>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> AddPolicyManagementCertificate(
            X509Certificate2 newSigningCertificate,
            AttestationTokenSigningKey existingSigningKey,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(existingSigningKey, nameof(existingSigningKey));
            Argument.AssertNotNull(newSigningCertificate, nameof(newSigningCertificate));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToAdd = new AttestationToken(
                        BinaryData.FromObjectAsJson(new PolicyCertificateModification(newSigningCertificate)),
                        existingSigningKey);
                var result = _policyManagementClient.Add(tokenToAdd.Serialize(), cancellationToken);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = GetSignersAsync(false, cancellationToken).EnsureCompleted();
                    if (!token.ValidateTokenInternal(_options.TokenOptions, signers, false, cancellationToken).EnsureCompleted())
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> AddPolicyManagementCertificateAsync(
            X509Certificate2 newSigningCertificate,
            AttestationTokenSigningKey existingSigningKey,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(existingSigningKey, nameof(existingSigningKey));
            Argument.AssertNotNull(newSigningCertificate, nameof(newSigningCertificate));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(AddPolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToAdd = new AttestationToken(
                        BinaryData.FromObjectAsJson(new PolicyCertificateModification(newSigningCertificate)),
                        existingSigningKey);
                var result = await _policyManagementClient.AddAsync(tokenToAdd.Serialize(), cancellationToken).ConfigureAwait(false);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(true, cancellationToken).ConfigureAwait(false);
                    if (!await token.ValidateTokenInternal(_options.TokenOptions, signers, true, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual AttestationResponse<PolicyCertificatesModificationResult> RemovePolicyManagementCertificate(
            X509Certificate2 certificateToRemove,
            AttestationTokenSigningKey existingSigningKey,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToRemove = new AttestationToken(
                        BinaryData.FromObjectAsJson(new PolicyCertificateModification(certificateToRemove)),
                        existingSigningKey);

                var result = _policyManagementClient.Remove(tokenToRemove.Serialize(), cancellationToken);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = GetSignersAsync(false, cancellationToken).EnsureCompleted();
                    if (!token.ValidateTokenInternal(_options.TokenOptions, signers, false, cancellationToken).EnsureCompleted())
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
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
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{PolicyCertificatesModificationResult}"/> with the policy for the specified attestation type.</returns>
        public virtual async Task<AttestationResponse<PolicyCertificatesModificationResult>> RemovePolicyManagementCertificateAsync(
            X509Certificate2 certificateToRemove,
            AttestationTokenSigningKey existingSigningKey,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationAdministrationClient)}.{nameof(RemovePolicyManagementCertificate)}");
            scope.Start();
            try
            {
                var tokenToRemove = new AttestationToken(
                        BinaryData.FromObjectAsJson(new PolicyCertificateModification(certificateToRemove)),
                        existingSigningKey);

                var result = await _policyManagementClient.RemoveAsync(tokenToRemove.Serialize(), cancellationToken).ConfigureAwait(false);
                var token = AttestationToken.Deserialize(result.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(true, cancellationToken).ConfigureAwait(false);
                    if (!await token.ValidateTokenAsync(_options.TokenOptions, signers, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, token);
                    }
                }
                return new AttestationResponse<PolicyCertificatesModificationResult>(result.GetRawResponse(), token);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<IReadOnlyList<AttestationSigner>> GetSignersAsync(bool async, CancellationToken cancellationToken)
        {
            if (async)
            {
                await _statelock.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    if (_signers == null)
                    {
                        _signers = (await _attestationClient.GetSigningCertificatesAsync(cancellationToken).ConfigureAwait(false)).Value;
                    }

                    return _signers;
                }
                finally
                {
                    _statelock.Release();
                }
            }
            else
            {
                _statelock.Wait(cancellationToken);
                try
                {
                    if (_signers == null)
                    {
                        _signers = _attestationClient.GetSigningCertificates(cancellationToken).Value;
                    }

                    return _signers;
                }
                finally
                {
                    _statelock.Release();
                }
            }
        }
    }
}
