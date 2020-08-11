// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Template.Models;

namespace Azure.Template
{
    /// <summary>
    /// The sample secrets client.
    /// </summary>
    public class MiniSecretClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal ServiceRestClient RestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretClient"/>.
        /// </summary>
        public MiniSecretClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new MiniSecretClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniSecretClient"/>.
        /// </summary>
        public MiniSecretClient(Uri endpoint, TokenCredential credential, MiniSecretClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
            endpoint.ToString(),
            options.Version)
        {
        }

        /// <summary> Initializes a new instance of MiniSecretClient for mocking. </summary>
        protected MiniSecretClient()
        {
        }
        /// <summary> Initializes a new instance of MiniSecretClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="vaultBaseUrl"> The vault name, for example https://myvault.vault.azure.net. </param>
        /// <param name="apiVersion"> Api Version. </param>
        internal MiniSecretClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string vaultBaseUrl, string apiVersion = "7.0")
        {
            RestClient = new ServiceRestClient(clientDiagnostics, pipeline, vaultBaseUrl, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        /// <param name="secretName"> The name of the secret. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecretBundle>> GetSecretAsync(string secretName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MiniSecretClient.GetSecret");
            scope.Start();
            try
            {
                return await RestClient.GetSecretAsync(secretName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        /// <param name="secretName"> The name of the secret. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecretBundle> GetSecret(string secretName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MiniSecretClient.GetSecret");
            scope.Start();
            try
            {
                return RestClient.GetSecret(secretName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
