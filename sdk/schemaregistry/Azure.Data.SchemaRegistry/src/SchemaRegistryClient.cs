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
    public partial class SchemaRegistryClient
    {
        private const string CredentialScope = "https://eventhubs.azure.net/.default";

        private SchemaOps InternalClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(string fullyQualifiedNamespace, TokenCredential credential) : this(fullyQualifiedNamespace, credential, new SchemaRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRegistryClient"/>.
        /// </summary>
        public SchemaRegistryClient(string fullyQualifiedNamespace, TokenCredential credential, SchemaRegistryClientOptions options) : this(new Uri($"https://{fullyQualifiedNamespace}"), credential, options)
        {
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            InternalClient = GetSchemaOpsClient();
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(RegisterSchemaScopeName);
            scope.Start();
            try
            {
                Response response;
                if (async)
                {
                    response = await InternalClient.RegisterSchemaAsync(groupName, schemaName, new BinaryData(schemaDefinition), format.ToContentType().ToString(), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = InternalClient.RegisterSchema(groupName, schemaName, new BinaryData(schemaDefinition), format.ToContentType().ToString(), cancellationToken);
                }

                var schemaIdHeader = response.Headers.TryGetValue("Schema-Id", out string idHeader) ? idHeader : null;
                var schemaGroupNameHeader = response.Headers.TryGetValue("Schema-Group-Name", out string groupNameHeader) ? groupNameHeader : null;
                var schemaNameHeader = response.Headers.TryGetValue("Schema-Name", out string nameHeader) ? nameHeader : null;
                var schemaVersionHeader = response.Headers.TryGetValue("Schema-Version", out int? versionHeader) ? versionHeader : null;

                var properties = new SchemaProperties(format, schemaIdHeader, schemaGroupNameHeader, schemaNameHeader, schemaVersionHeader!.Value);

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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(GetSchemaIdScopeName);
            scope.Start();
            try
            {
                Response response;
                if (async)
                {
                    response = await InternalClient.GetSchemaIdByContentAsync(groupName, schemaName, new BinaryData(schemaDefinition), new Core.ContentType(format.ToContentType().ToString()), cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = InternalClient.GetSchemaIdByContent(groupName, schemaName, new BinaryData(schemaDefinition), new Core.ContentType(format.ToContentType().ToString()), cancellationToken);
                }

                var schemaIdHeader = response.Headers.TryGetValue("Schema-Id", out string idHeader) ? idHeader : null;
                var schemaGroupNameHeader = response.Headers.TryGetValue("Schema-Group-Name", out string groupNameHeader) ? groupNameHeader : null;
                var schemaNameHeader = response.Headers.TryGetValue("Schema-Name", out string nameHeader) ? nameHeader : null;
                var schemaVersionHeader = response.Headers.TryGetValue("Schema-Version", out int? versionHeader) ? versionHeader : null;

                var properties = new SchemaProperties(format, schemaIdHeader, schemaGroupNameHeader, schemaNameHeader, schemaVersionHeader!.Value);

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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                Response<BinaryData> response;
                if (async)
                {
                    response = await InternalClient.GetSchemaByVersionAsync(groupName, schemaName, version, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = InternalClient.GetSchemaByVersion(groupName, schemaName, version, cancellationToken);
                }

                var schemaIdHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Id", out string idHeader) ? idHeader : null;
                var schemaGroupNameHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Group-Name", out string groupNameHeader) ? groupNameHeader : null;
                var schemaNameHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Name", out string nameHeader) ? nameHeader : null;
                var schemaVersionHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Version", out int? versionHeader) ? versionHeader : null;
                var schemaContentTypeHeader = response.GetRawResponse().Headers.TryGetValue("Content-Type", out string contentTypeHeader) ? contentTypeHeader : null;

                var properties = new SchemaProperties(SchemaFormat.FromContentType(schemaContentTypeHeader), schemaIdHeader, schemaGroupNameHeader, schemaNameHeader, schemaVersionHeader!.Value);
                var schema = new SchemaRegistrySchema(properties, response.Value.ToString());

                return Response.FromValue(schema, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<SchemaRegistrySchema>> GetSchemaInternalAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                Response<BinaryData> response;
                if (async)
                {
                    response = await InternalClient.GetSchemaByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = InternalClient.GetSchemaById(schemaId, cancellationToken);
                }

                var schemaIdHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Id", out string idHeader) ? idHeader : null;
                var schemaGroupNameHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Group-Name", out string groupNameHeader) ? groupNameHeader : null;
                var schemaNameHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Name", out string nameHeader) ? nameHeader : null;
                var schemaVersionHeader = response.GetRawResponse().Headers.TryGetValue("Schema-Version", out int? versionHeader) ? versionHeader : null;
                var schemaContentTypeHeader = response.GetRawResponse().Headers.TryGetValue("Content-Type", out string contentTypeHeader) ? contentTypeHeader : null;

                var properties = new SchemaProperties(SchemaFormat.FromContentType(schemaContentTypeHeader), schemaIdHeader, schemaGroupNameHeader, schemaNameHeader, schemaVersionHeader!.Value);
                var schema = new SchemaRegistrySchema(properties, response.Value.ToString());

                return Response.FromValue(schema, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
