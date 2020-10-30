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

        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AttestationRestClient _restClient;
        private readonly SigningCertificatesRestClient _metadataClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationClient"/> class.
        /// </summary>
        /// <param name="endpoint">Uri for the Microsoft Azure Attestation Service Instance to use.</param>
        /// <param name="credential">Credentials to be used in the Client.</param>
#pragma warning disable CA1801
        public AttestationClient(Uri endpoint, TokenCredential credential): this(endpoint, credential, new AttestationClientOptions())
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
        public AttestationClient(Uri endpoint, TokenCredential credential, AttestationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            /*Argument.AssertNotNull(credential, nameof(credential));*/
            Argument.AssertNotNull(options, nameof(options));

            // Add the authentication policy to our builder.
            _pipeline = HttpPipelineBuilder.Build(options, credential != null ? new BearerTokenAuthenticationPolicy(credential, GetDefaultScope()) : null);

            // Initialize the ClientDiagnostics.
            _clientDiagnostics = new ClientDiagnostics(options);

            _endpoint = endpoint;

            // Initialize the Rest Client.
            _restClient = new AttestationRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri, options.Version);

            _metadataClient = new SigningCertificatesRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }
#pragma warning restore
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
#pragma warning disable CA1822
        public virtual Response<AttestationToken<AttestationResult>> AttestSgxEnclave(byte[] quote, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(quote, nameof(quote));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestSgxEnclaveAsync(byte[] quote, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(quote, nameof(quote));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestSgxEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
            throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestOpenEnclave(byte[] report, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both binary blobs.</remarks>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestOpenEnclave(byte[] report, byte[] initTimeData, byte[] runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            /* Argument.AssertNotNull(initTimeData, nameof(initTimeData)); */
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both serialized objects.</remarks>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestOpenEnclave(byte[] report, object initTimeData, object runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            /* Argument.AssertNotNull(initTimeData, nameof(initTimeData));*/
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestOpenEnclaveAsync(byte[] report, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
            throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both binary blobs.</remarks>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestOpenEnclaveAsync(byte[] report, byte[] initTimeData, byte[] runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
                throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both serialized objects.</remarks>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestOpenEnclaveAsync(byte[] report, object initTimeData, object runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestSevSnpVm(byte[] report, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both binary blobs.</remarks>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestSevSnpVm(byte[] report, byte[] initTimeData, byte[] runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            /* Argument.AssertNotNull(initTimeData, nameof(initTimeData)); */
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData">Data provided when the quote was generated.</param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both serialized objects.</remarks>
        /// <returns></returns>
        public virtual Response<AttestationToken<AttestationResult>> AttestSevSnpVm(byte[] report, object initTimeData, object runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            /* Argument.AssertNotNull(initTimeData, nameof(initTimeData));*/
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestSevSnpVmAsync(byte[] report, InitTimeData initTimeData, RuntimeData runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
                throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both binary blobs.</remarks>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestSevSnpVmAsync(byte[] report, byte[] initTimeData, byte[] runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
                throw new NotImplementedException();
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
        /// <param name="runtimeData"></param>
        /// <param name="cancellationToken">Cancellation token used to cancel the request.</param>
        /// <returns></returns>
        /// <remarks>Convenience method used when the InitTime and RuntimeData are both serialized objects.</remarks>
        public virtual async Task<Response<AttestationToken<AttestationResult>>> AttestSevSnpVmAsync(byte[] report, object initTimeData, object runtimeData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(report, nameof(report));
            Argument.AssertNotNull(initTimeData, nameof(initTimeData));
            Argument.AssertNotNull(runtimeData, nameof(runtimeData));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestOpenEnclave)}");
            scope.Start();
            try
            {
                await Task.Yield();
                throw new NotImplementedException();
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
        public virtual Response<byte[]> AttestTpm(byte[] request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                throw new NotImplementedException();
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
        public virtual async Task<Response<byte[]>> AttestTpmAsync(byte[] request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(AttestTpm)}");
            scope.Start();
            try
            {
                await Task.Yield();
            throw new NotImplementedException();
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
        public virtual Response<AttestationSigner[]> GetSigningCertificates(CancellationToken cancellationToken = default)
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

                return Response.FromValue(returnedCertificates.ToArray(), keys.GetRawResponse());
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
        public virtual Task<Response<AttestationSigner[]>> GetSigningCertificatesAsync(CancellationToken cancellationToken = default)
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

                return Task.FromResult(Response.FromValue(returnedCertificates.ToArray(), keys.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // A helper method to construct the default scope based on the service endpoint.
        private static string GetDefaultScope() => $"https://attest.azure.net/.default";

    }
}
