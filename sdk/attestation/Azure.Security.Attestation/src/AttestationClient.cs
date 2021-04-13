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
    public class AttestationClient : IDisposable
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AttestationRestClient _restClient;
        private readonly SigningCertificatesRestClient _metadataClient;
        private readonly AttestationClientOptions _options;
        private IReadOnlyList<AttestationSigner> _signers;
        private SemaphoreSlim _statelock = new SemaphoreSlim(1, 1);
        private bool _disposedValue;

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
        /// <param name="quote">An Intel SGX "quote".
        /// See https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html" for more information.</param>
        /// <param name="initTimeData">Data provided when the enclave was created.</param>
        /// <param name="initTimeDataIsObject">true if the initTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject">true if the runTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="quote"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
            public virtual AttestationResponse<AttestationResult> AttestSgxEnclave(ReadOnlyMemory<byte> quote, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
                => AttestSgxEnclaveInternal(quote, initTimeData, initTimeDataIsObject, runTimeData, runTimeDataIsObject, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="quote">An Intel SGX "quote".
        /// See https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html for more information.</param>
        /// <param name="initTimeData">Data provided when the enclave was created.</param>
        /// <param name="initTimeDataIsObject">true if the initTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject">true if the runTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="quote"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
        public virtual async Task<AttestationResponse<AttestationResult>> AttestSgxEnclaveAsync(ReadOnlyMemory<byte> quote, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
            => await AttestSgxEnclaveInternal(quote, initTimeData, initTimeDataIsObject, runTimeData, runTimeDataIsObject, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="quote">An Intel SGX "quote".
        /// See https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html for more information.</param>
        /// <param name="initTimeData">Data provided when the enclave was created.</param>
        /// <param name="initTimeDataIsObject">true if the initTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject">true if the runTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="async">true if the API call should be asynchronous, false otherwise.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="quote"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
        private async Task<AttestationResponse<AttestationResult>> AttestSgxEnclaveInternal(ReadOnlyMemory<byte> quote, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var attestSgxEnclaveRequest = new AttestSgxEnclaveRequest
                {
                    Quote = quote.ToArray(),
                    InitTimeData = initTimeData != null ? new InitTimeData
                    {
                        Data = initTimeData.ToArray(),
                        DataType = initTimeDataIsObject ? DataType.Json : DataType.Binary,
                    } : null,
                    RuntimeData = runTimeData != null ? new RuntimeData
                    {
                        Data = runTimeData.ToArray(),
                        DataType = runTimeDataIsObject ? DataType.Json : DataType.Binary,
                    } : null,
                };

                Response<AttestationResponse> response;
                if (async)
                {
                    response = await _restClient.AttestSgxEnclaveAsync(attestSgxEnclaveRequest, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = _restClient.AttestSgxEnclave(attestSgxEnclaveRequest, cancellationToken);
                }
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.TokenOptions.ValidateToken)
                {
                    await attestationToken.ValidateTokenInternalAsync(_options.TokenOptions, await GetSignersAsync(cancellationToken).ConfigureAwait(false), async, cancellationToken).ConfigureAwait(false);
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
        /// <param name="report">An OpenEnclave "report".
        /// See https://github.com/openenclave/openenclave for more information.</param>
        /// <param name="initTimeData">Data provided when the enclave was created.</param>
        /// <param name="initTimeDataIsObject"></param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="report"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
        public virtual AttestationResponse<AttestationResult> AttestOpenEnclave(ReadOnlyMemory<byte> report, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
            => AttestOpenEnclaveInternalAsync(report, initTimeData, initTimeDataIsObject, runTimeData, runTimeDataIsObject, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Attest an Open Enclave enclave.
        /// </summary>
        /// <param name="report">An Open Enclave "report".
        /// See https://github.com/openenclave/openenclave for more information.</param>
        /// <param name="initTimeData"></param>
        /// <param name="initTimeDataIsObject"></param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="report"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
        public virtual async Task<AttestationResponse<AttestationResult>> AttestOpenEnclaveAsync(ReadOnlyMemory<byte> report, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
            => await AttestOpenEnclaveInternalAsync(report, initTimeData, initTimeDataIsObject, runTimeData, runTimeDataIsObject, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Attest an Open Enclave enclave.
        /// </summary>
        /// <param name="report">An Open Enclave "report".
        /// See https://github.com/openenclave/openenclave for more information.</param>
        /// <param name="initTimeData"></param>
        /// <param name="initTimeDataIsObject"></param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject"></param>
        /// <param name="async">true if the API call should be asynchronous, false otherwise.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns>An <see cref="AttestationResponse{AttestationResult}"/> which contains the validated claims for the supplied <paramref name="report"/>, <paramref name="runTimeData"/>, and <paramref name="initTimeData"/></returns>
        private async Task<AttestationResponse<AttestationResult>> AttestOpenEnclaveInternalAsync(ReadOnlyMemory<byte> report, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, bool async, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                AttestOpenEnclaveRequest request = new AttestOpenEnclaveRequest
                {
                    Report = report.ToArray(),
                    InitTimeData = initTimeData != null ? new InitTimeData
                    {
                        Data = initTimeData.ToArray(),
                        DataType = initTimeDataIsObject ? DataType.Json : DataType.Binary,
                    } : null,
                    RuntimeData = runTimeData != null ? new RuntimeData
                    {
                        Data = runTimeData.ToArray(),
                        DataType = runTimeDataIsObject ? DataType.Json : DataType.Binary,
                    } : null,
                };
                var response = async ? await _restClient.AttestOpenEnclaveAsync(request, cancellationToken).ConfigureAwait(false)
                                    : _restClient.AttestOpenEnclave(request, cancellationToken);
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.TokenOptions.ValidateToken)
                {
                    await attestationToken.ValidateTokenInternalAsync(_options.TokenOptions, await GetSignersAsync(cancellationToken).ConfigureAwait(false), async, cancellationToken).ConfigureAwait(false);
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
        /// See https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol for more information.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>A <see cref="TpmAttestationResponse"/>.</returns>
        public virtual Response<BinaryData> AttestTpm(BinaryData request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                var response = _restClient.AttestTpm(new TpmAttestationRequest { Data = request.ToArray() }, cancellationToken);

                BinaryData responseData = new BinaryData(response.Value);

                return Response.FromValue(responseData, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Attest a TPM based enclave.
        /// See https://docs.microsoft.com/en-us/azure/attestation/virtualization-based-security-protocol for more information.
        /// </summary>
        /// <param name="request">Incoming request to send to the TPM attestation service.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel this operation.</param>
        /// <returns>A <see cref="BinaryData"/> structure containing the value of <see cref="TpmAttestationResponse.Data"/>.</returns>
        public virtual async Task<Response<BinaryData>> AttestTpmAsync(BinaryData request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                var response = await _restClient.AttestTpmAsync(new TpmAttestationRequest { Data = request.ToArray() }, cancellationToken).ConfigureAwait(false);

                BinaryData responseData = new BinaryData(response.Value.Data);

                return  Response.FromValue(responseData, response.GetRawResponse());
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

        private async Task<IReadOnlyList<AttestationSigner>> GetSignersAsync(CancellationToken cancellationToken)
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

        private IReadOnlyList<AttestationSigner> GetSigners(CancellationToken cancellationToken)
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

        /// <summary>
        /// Dispose this object.
        /// </summary>
        /// <param name="disposing">True if the caller wants us to dispose our underlying objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                    _statelock.Dispose();
                }

                _disposedValue = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
