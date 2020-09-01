// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.SchemaRegistry.Models;

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
        public SchemaRegistryClient(string endpoint, TokenCredential credential) : this(endpoint, credential, new SchemaRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(string endpoint, TokenCredential credential, SchemaRegistryClientOptions options) : this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://eventhubs.azure.net/.default")),
            endpoint)
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
            //TODO: Hardcoded API version.
            RestClient = new SchemaRestClient(clientDiagnostics, pipeline, endpoint, "2017-04");
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary>
        /// TODO. (Create OR Get). (Register/Create).
        /// </summary>
        public virtual async Task<Response<SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.RegisterSchema");
            scope.Start();
            try
            {
                var response = await RestClient.RegisterAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
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
        public virtual Response<SchemaProperties> RegisterSchema(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.RegisterSchema");
            scope.Start();
            try
            {
                var response = RestClient.Register(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
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
        public virtual async Task<Response<SchemaProperties>> GetSchemaIdAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = await RestClient.QueryIdByContentAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
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
        public virtual Response<SchemaProperties> GetSchemaId(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("SchemaRegistryClient.GetSchema");
            scope.Start();
            try
            {
                var response = RestClient.QueryIdByContent(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
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
                var properties = new SchemaProperties(response.Value, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
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
                var properties = new SchemaProperties(response.Value, response.Headers.Location, response.Headers.XSchemaType, response.Headers.XSchemaId, response.Headers.XSchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
