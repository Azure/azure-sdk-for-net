// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
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
        public SchemaRegistryClient(string fullyQualifiedNamespace, TokenCredential credential) : this(fullyQualifiedNamespace, credential, new SchemaRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(string fullyQualifiedNamespace, TokenCredential credential, SchemaRegistryClientOptions options) : this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, CredentialScope)),
            fullyQualifiedNamespace,
            options.Version)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/> class for mocking use in testing.
        /// </summary>
        /// <remarks>
        /// This constructor exists only to support mocking. When used, class state is not fully initialized, and
        /// will not function correctly; virtual members are meant to be mocked.
        ///</remarks>
        protected SchemaRegistryClient()
        {
        }

        /// <summary>Initializes a new instance of <see cref="SchemaRegistryClient"/>.</summary>
        /// <param name="clientDiagnostics">The handler for diagnostic messaging in the client.</param>
        /// <param name="pipeline">The HTTP pipeline for sending and receiving REST requests and responses.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified namespace. For example, myschemaregistry.servicebus.windows.net.</param>
        /// <param name="apiVersion">The API version of the service.</param>
        internal SchemaRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string fullyQualifiedNamespace, string apiVersion)
        {
            RestClient = new SchemaRestClient(clientDiagnostics, pipeline, fullyQualifiedNamespace, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
        }

        /// <summary>
        /// Gets the fully qualified namespace that the client is connecting to.
        /// </summary>
        public string FullyQualifiedNamespace { get; }

        private const string RegisterSchemaScopeName = "SchemaRegistryClient.RegisterSchema";
        private const string GetSchemaIdScopeName = "SchemaRegistryClient.GetSchemaId";
        private const string GetSchemaScopeName = "SchemaRegistryClient.GetSchema";

        /// <summary>
        /// Registers a schema with the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual async Task<Response<SchemaProperties>> RegisterSchemaAsync(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
            await RegisterSchemaInternalAsync(groupName, schemaName, schemaDefinition, format, true, cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Registers a schema with the SchemaRegistry service.
        /// If the schema did not previously exist in the Schema Registry instance, it is added to the instance and assigned a schema ID.
        /// If the schema did previous exist in the Schema Registry instance, a new version of the schema is added to the instance and assigned a new schema ID.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual Response<SchemaProperties> RegisterSchema(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
                RegisterSchemaInternalAsync(groupName, schemaName, schemaDefinition, format, false, cancellationToken)
                    .EnsureCompleted();

        private async Task<Response<SchemaProperties>> RegisterSchemaInternalAsync(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            bool async,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(RegisterSchemaScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<SchemaRegisterHeaders> response;
                if (async)
                {
                    response = await RestClient.RegisterAsync(groupName, schemaName, format.ToContentType().ToString(), new BinaryData(schemaDefinition).ToStream(), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.Register(groupName, schemaName, format.ToContentType().ToString(), new BinaryData(schemaDefinition).ToStream(), cancellationToken);
                }

                var properties = new SchemaProperties(format, response.Headers.SchemaId, response.Headers.SchemaGroupName, response.Headers.SchemaName, response.Headers.SchemaVersion!.Value);

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
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Response<SchemaProperties>> GetSchemaPropertiesAsync(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
                await GetSchemaPropertiesInternalAsync(groupName, schemaName, schemaDefinition, format, true, cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// Gets the schema ID associated with the schema from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="schemaName">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Response<SchemaProperties> GetSchemaProperties(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
                GetSchemaPropertiesInternalAsync(groupName, schemaName, schemaDefinition, format, false, cancellationToken).EnsureCompleted();

        private async Task<Response<SchemaProperties>> GetSchemaPropertiesInternalAsync(
            string groupName,
            string schemaName,
            string schemaDefinition,
            SchemaFormat format,
            bool async,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaIdScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<SchemaQueryIdByContentHeaders> response;
                if (async)
                {
                    response = await RestClient.QueryIdByContentAsync(groupName, schemaName, format.ToContentType() , new BinaryData(schemaDefinition).ToStream(), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.QueryIdByContent(groupName, schemaName, format.ToContentType(), new BinaryData(schemaDefinition).ToStream(), cancellationToken);
                }

                var properties = new SchemaProperties(format, response.Headers.SchemaId, response.Headers.SchemaGroupName, response.Headers.SchemaName, response.Headers.SchemaVersion!.Value);

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
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Response<SchemaRegistrySchema>> GetSchemaAsync(string schemaId, CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
            await GetSchemaInternalAsync(schemaId, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the schema content associated with the group name, schema name, and version from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName"> Schema group under which schema is registered.  Group's serialization type should match the serialization type specified in the request</param>
        /// <param name="schemaName"> Name of schema. </param>
        /// <param name="schemaVersion"> Version number of specific schema. </param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Response<SchemaRegistrySchema>> GetSchemaAsync(string groupName, string schemaName, int schemaVersion, CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
            await GetSchemaInternalAsync(groupName, schemaName, schemaVersion, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets the schema content associated with the schema ID from the SchemaRegistry service.
        /// </summary>
        /// <param name="schemaId">The schema ID of the the schema from the SchemaRegistry.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Response<SchemaRegistrySchema> GetSchema(string schemaId, CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
            GetSchemaInternalAsync(schemaId, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Gets the schema content associated with the group name, schema name, and version from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName"> Schema group under which schema is registered.  Group's serialization type should match the serialization type specified in the request.  </param>
        /// <param name="schemaName"> Name of schema. </param>
        /// <param name="schemaVersion"> Version number of specific schema. </param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Response<SchemaRegistrySchema> GetSchema(string groupName, string schemaName, int schemaVersion, CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
            GetSchemaInternalAsync(groupName, schemaName, schemaVersion, false, cancellationToken).EnsureCompleted();

        private async Task<Response<SchemaRegistrySchema>> GetSchemaInternalAsync(string groupName, string schemaName, int version, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<Stream, SchemaGetSchemaVersionHeaders> response;
                if (async)
                {
                    response = await RestClient.GetSchemaVersionAsync(groupName, schemaName, version, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.GetSchemaVersion(groupName, schemaName, version, cancellationToken);
                }

                var properties = new SchemaProperties(SchemaFormat.FromContentType(response.Headers.ContentType.Value.ToString()), response.Headers.SchemaId, response.Headers.SchemaGroupName, response.Headers.SchemaName, response.Headers.SchemaVersion!.Value);
                var schema = new SchemaRegistrySchema(properties, BinaryData.FromStream(response.Value).ToString());

                return Response.FromValue(schema, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<SchemaRegistrySchema>> GetSchemaInternalAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<Stream, SchemaGetByIdHeaders> response;
                if (async)
                {
                    response = await RestClient.GetByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.GetById(schemaId, cancellationToken);
                }

                var properties = new SchemaProperties(SchemaFormat.FromContentType(response.Headers.ContentType.Value.ToString()), response.Headers.SchemaId, response.Headers.SchemaGroupName, response.Headers.SchemaName, response.Headers.SchemaVersion!.Value);
                var schema = new SchemaRegistrySchema(properties, BinaryData.FromStream(response.Value).ToString());

                return Response.FromValue(schema, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
