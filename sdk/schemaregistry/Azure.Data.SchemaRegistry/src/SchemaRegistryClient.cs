// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
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
        /// <param name="endpoint"> The vault name, for example https://myvault.vault.azure.net. </param>
        internal SchemaRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint)
        {
            RestClient = new SchemaRestClient(clientDiagnostics, pipeline, endpoint);
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

        /// <summary>
        /// TODO. (Create OR Get). (Register/Create).
        /// </summary>
        public virtual async Task<Response<SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, string serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.RegisterSchema");
            scope.Start();
            try
            {
                var response = await RestClient.RegisterAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// TODO. (Create OR Get). (Register/Create).
        /// </summary>
        public virtual Response<SchemaProperties> RegisterSchema(string groupName, string schemaName, string serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.RegisterSchema");
            scope.Start();
            try
            {
                var response = RestClient.Register(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// TODO. (Opposite of TryGet) (Find/Query/Get).
        /// </summary>
        public virtual async Task<Response<SchemaProperties>> GetSchemaAsync(string groupName, string schemaName, string serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = await RestClient.GetIdByContentAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// TODO. (Opposite of TryGet) (Find/Query/Get).
        /// </summary>
        public virtual Response<SchemaProperties> GetSchema(string groupName, string schemaName, string serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = RestClient.GetIdByContent(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// TODO. (Opposite of TryGet) (Find/Query/Get).
        /// </summary>
        public virtual async Task<Response<SchemaProperties>> GetSchemaAsync(string schemaId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = await RestClient.GetByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// TODO. (Opposite of TryGet) (Find/Query/Get).
        /// </summary>
        public virtual Response<SchemaProperties> GetSchema(string schemaId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = RestClient.GetById(schemaId, cancellationToken);
                return Response.FromValue(
                    new SchemaProperties(response.Headers.Location, response.Headers.XSerialization, response.Headers.XSchemaId, response.Headers.XSchemaVersion),
                    response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
