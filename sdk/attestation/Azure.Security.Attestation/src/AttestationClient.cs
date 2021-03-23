// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
    public class AttestationClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AttestationRestClient _restClient;
        private readonly SigningCertificatesRestClient _metadataClient;
        private readonly AttestationClientOptions _options;
        private IReadOnlyList<AttestationSigner> _signers;
        private object _statelock = new object();

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
        /// <returns></returns>
#pragma warning disable CA1822
        public virtual AttestationResponse<AttestationResult> AttestSgxEnclave(ReadOnlyMemory<byte> quote, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var response = _restClient.AttestSgxEnclave(
                    new AttestSgxEnclaveRequest
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
                    },
                    cancellationToken);
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.ValidateAttestationTokens)
                {
                    attestationToken.ValidateToken(GetSigners(), _options.ValidationCallback);
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
        /// Attest an Intel SGX enclave.
        /// </summary>
        /// <param name="quote">An Intel SGX "quote".
        /// See https://software.intel.com/content/www/us/en/develop/articles/code-sample-intel-software-guard-extensions-remote-attestation-end-to-end-example.html for more information.</param>
        /// <param name="initTimeData">Data provided when the enclave was created.</param>
        /// <param name="initTimeDataIsObject">true if the initTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject">true if the runTimeData parameter should be treated as an object, false if it should be treated as binary.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<AttestationResponse<AttestationResult>> AttestSgxEnclaveAsync(ReadOnlyMemory<byte> quote, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var response = await _restClient.AttestSgxEnclaveAsync(
                    new AttestSgxEnclaveRequest
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
                    },
                    cancellationToken).ConfigureAwait(false);
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.ValidateAttestationTokens)
                {
                    attestationToken.ValidateToken(GetSigners(), _options.ValidationCallback);
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
        /// <returns></returns>
        public virtual AttestationResponse<AttestationResult> AttestOpenEnclave(ReadOnlyMemory<byte> report, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var response = _restClient.AttestOpenEnclave(
                    new AttestOpenEnclaveRequest
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
                    },
                    cancellationToken);
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.ValidateAttestationTokens)
                {
                    attestationToken.ValidateToken(GetSigners(), _options.ValidationCallback);
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
        /// <param name="report">An Open Enclave "report".
        /// See https://github.com/openenclave/openenclave for more information.</param>
        /// <param name="initTimeData"></param>
        /// <param name="initTimeDataIsObject"></param>
        /// <param name="runTimeData">Data provided when the quote was generated.</param>
        /// <param name="runTimeDataIsObject"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<AttestationResponse<AttestationResult>> AttestOpenEnclaveAsync(ReadOnlyMemory<byte> report, BinaryData initTimeData, bool initTimeDataIsObject, BinaryData runTimeData, bool runTimeDataIsObject, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(runTimeData, nameof(runTimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                var response = await _restClient.AttestOpenEnclaveAsync(
                new AttestOpenEnclaveRequest
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
                },
                cancellationToken).ConfigureAwait(false);
                var attestationToken = new AttestationToken(response.Value.Token);

                if (_options.ValidateAttestationTokens)
                {
                    attestationToken.ValidateToken(GetSigners(), _options.ValidationCallback);
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
        /// <param name="cancellationToken"></param>
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
        /// <param name="cancellationToken"></param>
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
#pragma warning restore

        /// <summary>
        /// Retrieves the signing certificates used to sign attestation requests.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Response<IReadOnlyList<AttestationSigner>>> GetSigningCertificatesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(GetSigningCertificates)}");
            scope.Start();
            try
            {
                var keys = _metadataClient.Get(cancellationToken);

                List<AttestationSigner> returnedCertificates = new List<AttestationSigner>();
                foreach (var key in keys.Value.Keys)
                {
                    List<X509Certificate2> certificates = new List<X509Certificate2>();
                    string keyId = key.Kid;

                    if (key.X5C != null)
                    {
                        foreach (string x5c in key.X5C)
                        {
                            certificates.Add(new X509Certificate2(Convert.FromBase64String(x5c)));
                        }
                    }

                    returnedCertificates.Add(new AttestationSigner(certificates.ToArray(), keyId));
                }

                return Task.FromResult(Response.FromValue((IReadOnlyList<AttestationSigner>)returnedCertificates, keys.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private IReadOnlyList<AttestationSigner> GetSigners()
        {
            lock (_statelock)
            {
                if (_signers == null)
                {
                    _signers = GetSigningCertificates().Value;
                }

                return _signers;
            }
        }
    }
}
