// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.MessagingCatalog;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    internal class Catalog
    {
        private readonly MessagingCatalogClient _client;
        private readonly string _schemaGroup;

        public Catalog(MessagingCatalogClient client, string schemaGroup)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _schemaGroup = schemaGroup;
        }

        /// <summary>
        /// Registers an Avro schema in the Messaging Catalog
        /// </summary>
        /// <param name="schemaName">The name of the schema</param>
        /// <param name="schemaDefinition">The Avro schema definition in JSON format</param>
        /// <param name="async"></param>
        /// <returns>The created or updated schema</returns>
        public async Task<CatalogSchema> RegisterSchema(string schemaName, string schemaDefinition, bool async)
        {
            try
            {
                // Create a schema version with the definition
                var schemaVersion = new SchemaVersion
                {
                    SchemaId = schemaName,
                    Format = "Avro/1.11",
                    Schema = schemaDefinition
                };

                if (async)
                {
                    // Register the schema version asynchronously
                    var versionResponse = await _client.GetSchemaVersionsClient().CreateAsync(
                        _schemaGroup,
                        schemaName,
                        schemaVersion).ConfigureAwait(false);

                    // Get the full schema details asynchronously
                    var schemaResponse = await _client.GetCatalogSchemasClient().GetSchemaAsync(
                        _schemaGroup,
                        schemaName,
                        inline: "*").ConfigureAwait(false);

                    return schemaResponse.Value;
                }
                else
                {
                    // Register the schema version synchronously
                    var versionResponse = _client.GetSchemaVersionsClient().Create(
                        _schemaGroup,
                        schemaName,
                        schemaVersion);

                    // Get the full schema details synchronously
                    var schemaResponse = _client.GetCatalogSchemasClient().GetSchema(
                        _schemaGroup,
                        schemaName,
                        inline: "*");

                    return schemaResponse.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error registering schema", ex);
            }
        }

        /// <summary>
        /// Fetches a schema from the Messaging Catalog by schema name
        /// </summary>
        /// <param name="schemaName">The name of the schema</param>
        /// <param name="async"></param>
        /// <returns>The schema with its definition</returns>
        public async Task<CatalogSchema> GetSchemaByIdAsync(string schemaName, bool async)
        {
            try
            {
                if (async)
                {
                    var response = await _client.GetCatalogSchemasClient().GetSchemaAsync(
                        _schemaGroup,
                        schemaName,
                        inline: "*").ConfigureAwait(false);

                    if (response.Value.Versions != null && response.Value.Versions.Count > 0)
                    {
                        var versionId = response.Value.VersionId;
                        if (response.Value.Versions.ContainsKey(versionId))
                        {
                            var version = response.Value.Versions[versionId];
                        }
                    }

                    return response.Value;
                }
                else
                {
                    var response = _client.GetCatalogSchemasClient().GetSchema(
                        _schemaGroup,
                        schemaName,
                        inline: "*");

                    if (response.Value.Versions != null && response.Value.Versions.Count > 0)
                    {
                        var versionId = response.Value.VersionId;
                        if (response.Value.Versions.ContainsKey(versionId))
                        {
                            var version = response.Value.Versions[versionId];
                        }
                    }

                    return response.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching schema by ID", ex);
            }
        }
    }
}
