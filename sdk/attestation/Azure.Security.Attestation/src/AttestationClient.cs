// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public class AttestationClient
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AttestationRestClient _restClient;
        private readonly SigningCertificatesRestClient _metadataClient;
        private readonly AttestationClientOptions _options;
        private IReadOnlyList<AttestationSigner> _signers;
        // NOTE The SemaphoreSlim type does NOT need Disposable based on the current usage because AvailableWaitHandle is not referenced.
        private SemaphoreSlim _statelock = new SemaphoreSlim(1, 1);

        // The default scope for our data plane operations.
        private readonly string DefaultScope = "https://attest.azure.net/.default";

        /// <summary>
        /// Returns the URI used to communicate with the service.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
        public AttestationClient(Uri endpoint, TokenCredential credential): this(endpoint, credential, new AttestationClientOptions())
        {
            Endpoint = endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
        /// <param name="options"><see cref="AttestationClientOptions"/> used to configure the API client.</param>
        public AttestationClient(Uri endpoint, TokenCredential credential, AttestationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            /*Argument.AssertNotNull(credential, nameof(credential));*/
            Argument.AssertNotNull(options, nameof(options));

            // Add the authentication policy to our builder.
            _pipeline = HttpPipelineBuilder.Build(options, credential != null ? new BearerTokenAuthenticationPolicy(credential, DefaultScope) : null);

            // Initialize the ClientDiagnostics.
            _clientDiagnostics = new ClientDiagnostics(options);

            _options = options;

            Endpoint = endpoint;

            // Initialize the Rest Client.
            _restClient = new AttestationRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri, options.Version);

            _metadataClient = new SigningCertificatesRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri);
        }
        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        protected AttestationClient()
        {
        }

        /// <summary>
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/>.</returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an Intel SGX Quote.
        /// <seealso href="https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html"/>  for more information.
        ///</remarks>
        public virtual AttestationResponse<AttestationResult> AttestSgxEnclave(AttestationRequest request, CancellationToken cancellationToken = default)
                => AttestSgxEnclaveInternal(request, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/>.</returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an Intel SGX Quote.
        /// <seealso href="https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html"/>  for more information.
        ///</remarks>
        public virtual async Task<AttestationResponse<AttestationResult>> AttestSgxEnclaveAsync(AttestationRequest request, CancellationToken cancellationToken = default)
            => await AttestSgxEnclaveInternal(request, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="async">true if the API call should be asynchronous, false otherwise.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/></returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an Intel SGX Quote.
        /// <seealso href="https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html"/>  for more information.
        ///</remarks>
        private async Task<AttestationResponse<AttestationResult>> AttestSgxEnclaveInternal(AttestationRequest request, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            Argument.AssertNotNull(request.Evidence, nameof(request.Evidence));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var attestSgxEnclaveRequest = new AttestSgxEnclaveRequest
                {
                    Quote = request.Evidence.ToArray(),
                    DraftPolicyForAttestation = request.DraftPolicyForAttestation,
                };

                if (request.InittimeData != null)
                {
                    attestSgxEnclaveRequest.InitTimeData = new InitTimeData
                    {
                        Data = request.InittimeData.BinaryData.ToArray(),
                        DataType = request.InittimeData.DataIsJson ? DataType.Json : DataType.Binary,
                    };
                }
                else
                {
                    attestSgxEnclaveRequest.InitTimeData = null;
                }

                if (request.RuntimeData != null)
                {
                    attestSgxEnclaveRequest.RuntimeData = new RuntimeData
                    {
                        Data = request.RuntimeData.BinaryData.ToArray(),
                        DataType = request.RuntimeData.DataIsJson ? DataType.Json : DataType.Binary,
                    };
                }
                else
                {
                    attestSgxEnclaveRequest.RuntimeData = null;
                }

                Response<AttestationResponse> response;
                if (async)
                {
                    response = await _restClient.AttestSgxEnclaveAsync(attestSgxEnclaveRequest, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = _restClient.AttestSgxEnclave(attestSgxEnclaveRequest, cancellationToken);
                }
                var attestationToken = AttestationToken.Deserialize(response.Value.Token, _clientDiagnostics);
                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(async, cancellationToken).ConfigureAwait(false);
                    if (!await attestationToken.ValidateTokenInternal(_options.TokenOptions, signers, async, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, attestationToken);
                    }
                }

                return new AttestationResponse<AttestationResult>(response.GetRawResponse(), attestationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Attest an Open Enclave enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/>.</returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an OpenEnclave Report or OpenEnclave Evidence.</remarks>
        /// <seealso href="https://github.com/openenclave/openenclave"/>  for more information.
        public virtual AttestationResponse<AttestationResult> AttestOpenEnclave(AttestationRequest request, CancellationToken cancellationToken = default)
            => AttestOpenEnclaveInternalAsync(request, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Attest an Open Enclave enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/>.</returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an OpenEnclave Report or OpenEnclave Evidence.</remarks>
        /// <seealso href="https://github.com/openenclave/openenclave"/>  for more information.
        public virtual async Task<AttestationResponse<AttestationResult>> AttestOpenEnclaveAsync(AttestationRequest request, CancellationToken cancellationToken = default)
            => await AttestOpenEnclaveInternalAsync(request, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Attest an Open Enclave enclave.
        /// </summary>
        /// <param name="request">Aggregate type containing the information needed to perform an attestation operation.</param>
        /// <param name="async">true if the API call should be asynchronous, false otherwise.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="request"/>.</returns>
        /// <remarks>The <see cref="AttestationRequest.Evidence"/> must be an OpenEnclave Report or OpenEnclave Evidence.</remarks>
        /// <seealso href="https://github.com/openenclave/openenclave"/>  for more information.
        private async Task<AttestationResponse<AttestationResult>> AttestOpenEnclaveInternalAsync(AttestationRequest request, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            Argument.AssertNotNull(request.Evidence, nameof(request.Evidence));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                var attestOpenEnclaveRequest = new AttestOpenEnclaveRequest
                {
                    Report = request.Evidence.ToArray(),
                    DraftPolicyForAttestation = request.DraftPolicyForAttestation,
                    RuntimeData = null,
                    InitTimeData = null,
            };

                if (request.InittimeData != null)
                {
                    attestOpenEnclaveRequest.InitTimeData = new InitTimeData
                    {
                        Data = request.InittimeData.BinaryData.ToArray(),
                        DataType = request.InittimeData.DataIsJson ? DataType.Json : DataType.Binary,
                    };
                }

                if (request.RuntimeData != null)
                {
                    attestOpenEnclaveRequest.RuntimeData = new RuntimeData
                    {
                        Data = request.RuntimeData.BinaryData.ToArray(),
                        DataType = request.RuntimeData.DataIsJson ? DataType.Json : DataType.Binary,
                    };
                }

                var response = async ? await _restClient.AttestOpenEnclaveAsync(attestOpenEnclaveRequest, cancellationToken).ConfigureAwait(false)
                                    : _restClient.AttestOpenEnclave(attestOpenEnclaveRequest, cancellationToken);
                var attestationToken = AttestationToken.Deserialize(response.Value.Token, _clientDiagnostics);

                if (_options.TokenOptions.ValidateToken)
                {
                    var signers = await GetSignersAsync(async, cancellationToken).ConfigureAwait(false);
                    if (!await attestationToken.ValidateTokenInternal(_options.TokenOptions, signers, async, cancellationToken).ConfigureAwait(false))
                    {
                        AttestationTokenValidationFailedException.ThrowFailure(signers, attestationToken);
                    }
                }

                return new AttestationResponse<AttestationResult>(response.GetRawResponse(), attestationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Attest a TPM based enclave.
        /// See <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/> for more information.
        /// </summary>
        /// <param name="request">TPM Attestation request.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>A <see cref="TpmAttestationResponse"/> containing the TPM attestation response.</returns>
        public virtual Response<TpmAttestationResponse> AttestTpm(TpmAttestationRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                return _restClient.AttestTpm(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Attest a TPM based enclave.
        /// See <seealso href="https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol"/> for more information.
        /// </summary>
        /// <param name="request">TPM Attestation request.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>A <see cref="TpmAttestationResponse"/> containing the TPM attestation response.</returns>
        public virtual async Task<Response<TpmAttestationResponse>> AttestTpmAsync(TpmAttestationRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                return await _restClient.AttestTpmAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the signing certificates used to sign attestation requests.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{T}"/> whose specialization contains a list of signers which can be used to sign attestation tokens.</returns>
        public virtual Response<IReadOnlyList<AttestationSigner>> GetSigningCertificates(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(GetSigningCertificates)}");
            scope.Start();
            try
            {
                var keys = _metadataClient.Get(cancellationToken);

                return Response.FromValue(AttestationSigner.FromJsonWebKeySet(keys), keys.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the signing certificates used to sign attestation requests.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>An <see cref="AttestationResponse{T}"/> whose specialization contains a list of signers which can be used to sign attestation tokens.</returns>
        public virtual Task<Response<IReadOnlyList<AttestationSigner>>> GetSigningCertificatesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(GetSigningCertificates)}");
            scope.Start();
            try
            {
                var keys = _metadataClient.Get(cancellationToken);
                return Task.FromResult(Response.FromValue(AttestationSigner.FromJsonWebKeySet(keys), keys.GetRawResponse()));
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
                        _signers = (await GetSigningCertificatesAsync(cancellationToken).ConfigureAwait(false)).Value;
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
                        _signers = GetSigningCertificates(cancellationToken).Value;
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
