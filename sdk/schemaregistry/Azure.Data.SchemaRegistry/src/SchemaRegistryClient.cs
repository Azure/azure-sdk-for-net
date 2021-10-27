﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.SchemaRegistry.Models;

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

        /// <summary>Initializes a new instance of <see cref="SchemaRegistryClient"/> for mocking.</summary>
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
        /// <param name="name">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual async Task<Response<SchemaProperties>> RegisterSchemaAsync(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
            await RegisterSchemaInternalAsync(groupName, name, schemaDefinition, format, true, cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Registers a schema with the SchemaRegistry service.
        /// If the schema did not previously exist in the Schema Registry instance, it is added to the instance and assigned a schema ID.
        /// If the schema did previous exist in the Schema Registry instance, a new version of the schema is added to the instance and assigned a new schema ID.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="name">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema.</returns>
        public virtual Response<SchemaProperties> RegisterSchema(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
                RegisterSchemaInternalAsync(groupName, name, schemaDefinition, format, false, cancellationToken)
                    .EnsureCompleted();

        private async Task<Response<SchemaProperties>> RegisterSchemaInternalAsync(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            bool async,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(RegisterSchemaScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<SchemaId, SchemaRegisterHeaders> response;
                if (async)
                {
                    response = await RestClient.RegisterAsync(groupName, name, format, schemaDefinition, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.Register(groupName, name, format, schemaDefinition, cancellationToken);
                }

                var properties = new SchemaProperties(response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);

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
        /// <param name="name">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<Response<SchemaProperties>> GetSchemaPropertiesAsync(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
                await GetSchemaPropertiesInternalAsync(groupName, name, schemaDefinition, format, true, cancellationToken)
                    .ConfigureAwait(false);

        /// <summary>
        /// Gets the schema ID associated with the schema from the SchemaRegistry service.
        /// </summary>
        /// <param name="groupName">The name of the SchemaRegistry group.</param>
        /// <param name="name">The name of the schema.</param>
        /// <param name="schemaDefinition">The string representation of the schema's content.</param>
        /// <param name="format">The serialization format of the schema.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema ID provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Response<SchemaProperties> GetSchemaProperties(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
                GetSchemaPropertiesInternalAsync(groupName, name, schemaDefinition, format, false, cancellationToken).EnsureCompleted();

        private async Task<Response<SchemaProperties>> GetSchemaPropertiesInternalAsync(
            string groupName,
            string name,
            string schemaDefinition,
            SchemaFormat format,
            bool async,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaIdScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<SchemaId, SchemaQueryIdByContentHeaders> response;
                if (async)
                {
                    response = await RestClient.QueryIdByContentAsync(groupName, name, format, schemaDefinition, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.QueryIdByContent(groupName, name, format, schemaDefinition, cancellationToken);
                }

                var properties = new SchemaProperties(response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);

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
        /// Gets the schema content associated with the schema ID from the SchemaRegistry service.
        /// </summary>
        /// <param name="schemaId">The schema ID of the the schema from the SchemaRegistry.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The properties of the schema, including the schema content provided by the service.</returns>
#pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual Response<SchemaRegistrySchema> GetSchema(string schemaId, CancellationToken cancellationToken = default) =>
#pragma warning restore AZC0015 // Unexpected client method return type.
            GetSchemaInternalAsync(schemaId, false, cancellationToken).EnsureCompleted();

        private async Task<Response<SchemaRegistrySchema>> GetSchemaInternalAsync(string schemaId, bool async, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope(GetSchemaScopeName);
            scope.Start();
            try
            {
                ResponseWithHeaders<string, SchemaGetByIdHeaders> response;
                if (async)
                {
                    response = await RestClient.GetByIdAsync(schemaId, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response = RestClient.GetById(schemaId, cancellationToken);
                }

                var properties = new SchemaProperties(response.Headers.Location, response.Headers.SerializationType, response.Headers.SchemaId, response.Headers.SchemaVersion);
                var schema = new SchemaRegistrySchema(properties, response.Value);

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
