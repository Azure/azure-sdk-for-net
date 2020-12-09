// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// The Schema Registry client provides operations to interact with the Schema Registry service.
    /// </summary>
    public class SchemaRegistryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal SchemaRestClient RestClient { get; }
        private const string CredentialScope = "https://eventhubs.azure.net/.default";

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
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, CredentialScope)),
            endpoint,
            options.Version)
        {
        }

        /// <summary>Initializes a new instance of <see cref="SchemaRegistryClient"/> for mocking.</summary>
        protected SchemaRegistryClient()
        {
        }

        /// <summary>Initializes a new instance of <see cref="SchemaRegistryClient"/>.</summary>
        /// <param name="clientDiagnostics">The handler for diagnostic messaging in the client.</param>
        /// <param name="pipeline">The HTTP pipeline for sending and receiving REST requests and responses.</param>
        /// <param name="endpoint">The endpoint URI. For example, myschemaregistry.servicebus.windows.net.</param>
        /// <param name="apiVersion">The API version of the service.</param>
        internal SchemaRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion)
        {
            RestClient = new SchemaRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
        }

        private const string RegisterSchemaScopeName = "SchemaRegistryClient.RegisterSchema";
        private const string GetSchemaIdScopeName = "SchemaRegistryClient.GetSchemaId";
        private const string GetSchemaScopeName = "SchemaRegistryClient.GetSchema";

        /// <summary>
        /// Registers a schema with the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="serializationType">The serialization format of the schema.</param>
        /// <param name="schemaContent">The string representation of the schema's content.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual async Task<Response<SchemaProperties>> RegisterSchemaAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(RegisterSchemaScopeName);
            scope.Start();
            try
            {
                var response = await RestClient.RegisterAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Registers a schema with the SchemaRegistry service.
        /// If the schema did not previously exist in the Schema Registry instance, it is added to the instance and assigned a schema ID.
        /// If the schema did previous exist in the Schema Registry instance, a new version of the schema is added to the instance and assigned a new schema ID.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="serializationType">The serialization format of the schema.</param>
        /// <param name="schemaContent">The string representation of the schema's content.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual Response<SchemaProperties> RegisterSchema(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(RegisterSchemaScopeName);
            scope.Start();
            try
            {
                var response = RestClient.Register(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the schema ID associated with the schema from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="serializationType">The serialization format of the schema.</param>
        /// <param name="schemaContent">The string representation of the schema's content.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
        public virtual async Task<Response<SchemaProperties>> GetSchemaIdAsync(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaIdScopeName);
            scope.Start();
            try
            {
                var response = await RestClient.QueryIdByContentAsync(groupName, schemaName, serializationType, schemaContent, cancellationToken).ConfigureAwait(false);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the schema ID associated with the schema from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="serializationType">The serialization format of the schema.</param>
        /// <param name="schemaContent">The string representation of the schema's content.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
        public virtual Response<SchemaProperties> GetSchemaId(string groupName, string schemaName, SerializationType serializationType, string schemaContent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaIdScopeName);
            scope.Start();
            try
            {
                var response = RestClient.QueryIdByContent(groupName, schemaName, serializationType, schemaContent, cancellationToken);
                var properties = new SchemaProperties(schemaContent, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the schema content associated with the schema ID from the SchemaRegistry service.
        /// </summary>
        /// <param name="schemaId">The schema ID of the the schema from the SchemaRegistry.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
        public virtual async Task<Response<SchemaProperties>> GetSchemaAsync(string schemaId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                var response = await RestClient.GetByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
                var properties = new SchemaProperties(response.Value, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                return Response.FromValue(properties, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the schema content associated with the schema ID from the SchemaRegistry service.
        /// </summary>
        /// <param name="schemaId">The schema ID of the the schema from the SchemaRegistry.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
        public virtual Response<SchemaProperties> GetSchema(string schemaId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                var response = RestClient.GetById(schemaId, cancellationToken);
                var properties = new SchemaProperties(response.Value, response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
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
