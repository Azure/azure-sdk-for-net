// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Queryable;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The <see cref="TableClient"/> allows you to interact with Azure Storage
    /// Tables.
    /// </summary>
    public class TableClient
    {
        private readonly string _table;
        private readonly OdataMetadataFormat _format;
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly string _version;
        private readonly bool _isPremiumEndpoint;
        private ResponseFormat _returnNoContent = ResponseFormat.ReturnNoContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>.
        /// </summary>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not https.</exception>
        public TableClient(string tableName, Uri endpoint, TableClientOptions options = null)
            : this(tableName, endpoint, default(TableSharedKeyPipelinePolicy), options)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            if (endpoint.Scheme != "https")
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.", nameof(endpoint));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>.
        /// </summary>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        /// <exception cref="ArgumentNullException"><paramref name="tableName"/> or <paramref name="credential"/> is null.</exception>
        public TableClient(string tableName, Uri endpoint, TableSharedKeyCredential credential)
            : this(tableName, endpoint, new TableSharedKeyPipelinePolicy(credential), null)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            Argument.AssertNotNull(credential, nameof(credential));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>.
        /// </summary>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="tableName"/> or <paramref name="credential"/> is null.</exception>
        public TableClient(string tableName, Uri endpoint, TableSharedKeyCredential credential, TableClientOptions options = null)
            : this(tableName, endpoint, new TableSharedKeyPipelinePolicy(credential), options)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            Argument.AssertNotNull(credential, nameof(credential));
        }

        internal TableClient(string tableName, Uri endpoint, TableSharedKeyPipelinePolicy policy, TableClientOptions options)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new TableClientOptions();
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, policy);

            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpoint.ToString());
            _version = options.VersionString;
            _table = tableName;
            _format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata;
            _isPremiumEndpoint = TableServiceClient.IsPremiumEndpoint(endpoint);
            ;
        }

        internal TableClient(string table, TableRestClient tableOperations, string version, ClientDiagnostics diagnostics, bool isPremiumEndpoint)
        {
            _tableOperations = tableOperations;
            _version = version;
            _table = table;
            _format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata;
            _diagnostics = diagnostics;
            _isPremiumEndpoint = isPremiumEndpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>
        /// class for mocking.
        /// </summary>
        protected TableClient()
        { }


        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table.
        /// </summary>
        /// <param name="permissions"><see cref="TableSasPermissions"/> containing the allowed permissions.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            return new TableSasBuilder(_table, permissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table.
        /// </summary>
        /// <param name="rawPermissions">The permissions associated with the shared access signature. This string should contain one or more of the following permission characters in this order: "racwdl".</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(string rawPermissions, DateTimeOffset expiresOn)
        {
            return new TableSasBuilder(_table, rawPermissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Creates the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual Response<TableItem> Create(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Create)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties() { TableName = _table }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual async Task<Response<TableItem>> CreateAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Create)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = _table }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual Response<TableItem> CreateIfNotExists(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateIfNotExists)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties() { TableName = _table }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                return default;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual async Task<Response<TableItem>> CreateIfNotExistsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateIfNotExists)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = _table }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                return default;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return _tableOperations.Delete(table: _table, null, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the current table.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteAsync(table: _table, null, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>A <see cref="Response"/> containing headers such as ETag.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual async Task<Response> AddEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(AddEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.InsertEntityAsync(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    responsePreference: _returnNoContent,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response"/> containing headers such as ETag</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual Response AddEntity<T>(T entity, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(AddEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.InsertEntity(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    responsePreference: _returnNoContent,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual Response<T> GetEntity<T>(string partitionKey, string rowKey, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.QueryEntitiesWithPartitionAndRowKey(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual async Task<Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.QueryEntitiesWithPartitionAndRowKeyAsync(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpsertEntityAsync<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else if (mode == TableUpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpsertEntity<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else if (mode == TableUpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">The If-Match value to be used for optimistic concurrency.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpdateEntityAsync<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            Argument.AssertNotDefault(ref ifMatch, nameof(ifMatch));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else if (mode == TableUpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">The If-Match value to be used for optimistic concurrency.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            Argument.AssertNotDefault(ref ifMatch, nameof(ifMatch));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else if (mode == TableUpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<T> QueryAsync<T>(Expression<Func<T, bool>> filter, int? maxPerPage = null, IEnumerable<string> select = null, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return QueryAsync<T>(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<T> Query<T>(Expression<Func<T, bool>> filter, int? maxPerPage = null, IEnumerable<string> select = null, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return Query<T>(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<T> QueryAsync<T>(string filter = null, int? maxPerPage = null, IEnumerable<string> select = null, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            string selectArg = select == null ? null : string.Join(",", select);

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = selectArg },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                    CreateContinuationTokenFromHeaders(response.Headers),
                    response.GetRawResponse());
            }, async (continuationToken, _) =>
            {
                var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = selectArg },
                    nextPartitionKey: NextPartitionKey,
                    nextRowKey: NextRowKey,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                    CreateContinuationTokenFromHeaders(response.Headers),
                    response.GetRawResponse());
            });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }


        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual Pageable<T> Query<T>(string filter = null, int? maxPerPage = null, IEnumerable<string> select = null, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            string selectArg = select == null ? null : string.Join(",", select);

            return PageableHelpers.CreateEnumerable((int? _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var response = _tableOperations.QueryEntities(_table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = selectArg },
                        cancellationToken: cancellationToken);

                    return Page.FromValues(
                        response.Value.Value.ToTableEntityList<T>(),
                        CreateContinuationTokenFromHeaders(response.Headers),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (continuationToken, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                    var response = _tableOperations.QueryEntities(
                        _table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = selectArg },
                        nextPartitionKey: NextPartitionKey,
                        nextRowKey: NextRowKey,
                        cancellationToken: cancellationToken);

                    return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                        CreateContinuationTokenFromHeaders(response.Headers),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="ifMatch">The If-Match value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> DeleteEntityAsync(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(DeleteEntity)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteEntityAsync(_table,
                    partitionKey,
                    rowKey,
                    ifMatch: ifMatch == default ? ETag.All.ToString() : ifMatch.ToString(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="ifMatch">The If-Match value to be used for optimistic concurrency. The default is to delete unconditionally.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(DeleteEntity)}");
            scope.Start();
            try
            {
                return _tableOperations.DeleteEntity(_table,
                    partitionKey,
                    rowKey,
                    ifMatch: ifMatch == default ? ETag.All.ToString() : ifMatch.ToString(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<IReadOnlyList<SignedIdentifier>>> GetAccessPolicyAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicy)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.GetAccessPolicyAsync(_table, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<IReadOnlyList<SignedIdentifier>> GetAccessPolicy(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicy)}");
            scope.Start();
            try
            {
                var response = _tableOperations.GetAccessPolicy(_table, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> SetAccessPolicyAsync(IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return await _tableOperations.SetAccessPolicyAsync(_table, tableAcl: tableAcl, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response SetAccessPolicy(IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return _tableOperations.SetAccessPolicy(_table, tableAcl: tableAcl, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual async Task<Response<List<Response>>> BatchTestAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(BatchTest)}");
            scope.Start();
            try
            {
                var batch = TableRestClient.CreateBatchContent();
                var changeset = batch.AddChangeset();
                foreach (var entity in entities)
                {
                    _tableOperations.AddInsertEntityRequest(
                        changeset,
                        _table,
                        null,
                        null,
                        null,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format });
                }
                return await _tableOperations.SendBatchRequestAsync(_tableOperations.CreateBatchRequest(batch, null, null), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual Response<List<Response>> BatchTest<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(BatchTest)}");
            scope.Start();
            try
            {
                var batch = TableRestClient.CreateBatchContent();
                var changeset = batch.AddChangeset();
                foreach (var entity in entities)
                {
                    _tableOperations.AddInsertEntityRequest(
                        changeset,
                        _table,
                        null,
                        null,
                        null,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format });
                }
                return _tableOperations.SendBatchRequest(_tableOperations.CreateBatchRequest(batch, null, null), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an Odata filter query string from the provided expression.
        /// </summary>
        /// <typeparam name="T">The type of the entity being queried. Typically this will be derrived from <see cref="ITableEntity"/> or <see cref="Dictionary{String, Object}"/>.</typeparam>
        /// <param name="filter">A filter expresssion.</param>
        /// <returns>The string representation of the filter expression.</returns>
        public static string CreateQueryFilter<T>(Expression<Func<T, bool>> filter) => Bind(filter);

        internal static string Bind(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Dictionary<Expression, Expression> normalizerRewrites = new Dictionary<Expression, Expression>(ReferenceEqualityComparer<Expression>.Instance);

            // Evaluate any local valid expressions ( lambdas etc)
            Expression partialEvaluatedExpression = Evaluator.PartialEval(expression);

            // Normalize expression, replace String Comparisons etc.
            Expression normalizedExpression = ExpressionNormalizer.Normalize(partialEvaluatedExpression, normalizerRewrites);

            // Parse the Bound expression into an OData filter.
            ExpressionParser parser = new ExpressionParser();
            parser.Translate(normalizedExpression);

            // Return the FilterString.
            return parser.FilterString == "true" ? null : parser.FilterString;
        }

        private static string CreateContinuationTokenFromHeaders(TableQueryEntitiesHeaders headers)
        {
            if (headers.XMsContinuationNextPartitionKey == null && headers.XMsContinuationNextRowKey == null)
            {
                return null;
            }
            else
            {
                return $"{headers.XMsContinuationNextPartitionKey} {headers.XMsContinuationNextRowKey}";
            }
        }

        private static (string NextPartitionKey, string NextRowKey) ParseContinuationToken(string continuationToken)
        {
            // There were no headers passed and the continuation token contains just the space delimiter
            if (continuationToken?.Length <= 1)
            {
                return (null, null);
            }

            var tokens = continuationToken.Split(' ');
            return (tokens[0], tokens.Length > 1 ? tokens[1] : null);
        }
    }
}
