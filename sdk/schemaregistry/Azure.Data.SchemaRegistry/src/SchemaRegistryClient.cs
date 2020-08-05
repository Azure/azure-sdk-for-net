// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// The Schema Registry client.
    /// </summary>
    public class SchemaRegistryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SchemaRestClient RestClient { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new SchemaRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(Uri endpoint, TokenCredential credential, SchemaRegistryClientOptions options) : this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default")),
            endpoint.ToString())//,
                                //options.Version)
        {
        }

        /// <summary> Initializes a new instance of SchemaRegistryClient for mocking. </summary>
        protected SchemaRegistryClient()
        {
        }
        /// <summary> Initializes a new instance of SchemaRegistryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="vaultBaseUrl"> The vault name, for example https://myvault.vault.azure.net. </param>
        ///// <param name="apiVersion"> Api Version. </param>
        internal SchemaRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string vaultBaseUrl)//, string apiVersion = "7.0")
        {
            RestClient = new SchemaRestClient(clientDiagnostics, pipeline, vaultBaseUrl);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        // /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        // /// <param name="secretName"> The name of the secret. </param>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // public virtual async Task<Response<SecretBundle>> GetSecretAsync(string secretName, CancellationToken cancellationToken = default)
        // {
        //     using var scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSecret");
        //     scope.Start();
        //     try
        //     {
        //         return await RestClient.GetSecretAsync(secretName, cancellationToken).ConfigureAwait(false);
        //     }
        //     catch (Exception e)
        //     {
        //         scope.Failed(e);
        //         throw;
        //     }
        // }

        // /// <summary> The GET operation is applicable to any secret stored in Azure Key Vault. This operation requires the secrets/get permission. </summary>
        // /// <param name="secretName"> The name of the secret. </param>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // public virtual Response<SecretBundle> GetSecret(string secretName, CancellationToken cancellationToken = default)
        // {
        //     using var scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSecret");
        //     scope.Start();
        //     try
        //     {
        //         return RestClient.GetSecret(secretName, cancellationToken);
        //     }
        //     catch (Exception e)
        //     {
        //         scope.Failed(e);
        //         throw;
        //     }
        // }
    }
}
