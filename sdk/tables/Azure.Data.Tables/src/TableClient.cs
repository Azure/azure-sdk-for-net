// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// The <see cref="TableClient"/> allows you to interact with Azure Tables hosted in either Azure storage accounts or Azure Cosmos DB table API.
    /// </summary>
    public class TableClient
    {
        private static readonly char[] ContinuationTokenSplit = { ' ' };
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly string _version;
        private readonly bool _isCosmosEndpoint;
        private readonly ResponseFormat _returnNoContent = ResponseFormat.ReturnNoContent;
        private readonly QueryOptions _defaultQueryOptions = new() { Format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata };
        private string _accountName;
        private readonly Uri _endpoint;
        private Guid? _batchGuid;
        private Guid? _changesetGuid;
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The <see cref="TableSharedKeyCredential"/> used to authenticate and generate SAS
        /// </summary>
        private TableSharedKeyCredential _tableSharedKeyCredential;

        /// <summary>
        /// Gets the The <see cref="TableSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        internal virtual TableSharedKeyCredential SharedKeyCredential => _tableSharedKeyCredential;

        /// <summary>
        /// The name of the table with which this client instance will interact.
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// The name of the table account with which this client instance will interact.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName != null)
                {
                    return _accountName;
                }

                var builder = new TableUriBuilder(_endpoint);
                _accountName = builder.AccountName;
                return _accountName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified <see cref="Uri" /> which contains a SAS token.
        /// See <see cref="GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/{table_name}?{sas_token}" or
        /// "https://{account_name}.table.cosmos.azure.com/{table_name}?{sas_token}".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not https.</exception>
        public TableClient(Uri endpoint, TableClientOptions options = null)
            : this(endpoint, null, default, default, options)
        {
            if (endpoint.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException("Cannot a use SAS token credential without HTTPS.", nameof(endpoint));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified <see cref="Uri" /> and <see cref="AzureSasCredential"/>.
        /// See <see cref="GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/{table_name}"
        /// or "https://{account_name}.table.cosmos.azure.com/{table_name}".
        /// </param>
        /// <param name="credential">The shared access signature credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> is not https.</exception>
        public TableClient(Uri endpoint, AzureSasCredential credential, TableClientOptions options = null)
            : this(endpoint, null, default, credential, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            if (endpoint.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException("Cannot a use SAS token credential without HTTPS.", nameof(endpoint));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified table service <see cref="Uri" /> and <see cref="TableSharedKeyCredential" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        /// <exception cref="ArgumentNullException"><paramref name="tableName"/> or <paramref name="credential"/> is null.</exception>
        public TableClient(Uri endpoint, string tableName, TableSharedKeyCredential credential)
            : this(endpoint, tableName, new TableSharedKeyPipelinePolicy(credential), default, null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _tableSharedKeyCredential = credential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified table service <see cref="Uri" /> and <see cref="TableSharedKeyCredential" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="tableName"/> or <paramref name="credential"/> is null.</exception>
        public TableClient(Uri endpoint, string tableName, TableSharedKeyCredential credential, TableClientOptions options = null)
            : this(endpoint, tableName, new TableSharedKeyPipelinePolicy(credential), default, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _tableSharedKeyCredential = credential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified connection string.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Table
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        public TableClient(string connectionString, string tableName)
            : this(connectionString, tableName, default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>.
        /// Initializes a new instance of the <see cref="TableClient"/> using the specified connection string.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information,
        /// <see href="https://docs.microsoft.com/azure/storage/common/storage-configure-connection-string">
        /// Configure Azure Storage connection strings</see>.
        /// </param>
        /// <param name="tableName">The name of the table with which this client instance will interact.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        public TableClient(string connectionString, string tableName, TableClientOptions options = null)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            TableConnectionString connString = TableConnectionString.Parse(connectionString);
            _accountName = connString._accountName;
            _isCosmosEndpoint = TableServiceClient.IsPremiumEndpoint(connString.TableStorageUri.PrimaryUri);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();

            options ??= TableClientOptions.DefaultOptions;
            var endpointString = connString.TableStorageUri.PrimaryUri.ToString();

            TableSharedKeyPipelinePolicy policy = connString.Credentials switch
            {
                TableSharedKeyCredential credential => new TableSharedKeyPipelinePolicy(credential),
                _ => default
            };

            HttpPipeline pipeline =
                HttpPipelineBuilder.Build(options, perCallPolicies, new HttpPipelinePolicy[] { policy }, new ResponseClassifier());

            _version = options.VersionString;
            _diagnostics = new TablesClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpointString, _version);
            Name = tableName;
        }

        internal TableClient(Uri endpoint, string tableName, TableSharedKeyPipelinePolicy policy, AzureSasCredential sasCredential, TableClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            // If we were provided no tableName, try to parse it from the endpoint.
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = new TableSasBuilder(endpoint).TableName;
            }

            // If the sasCredential is provided, we can extract the tableName from it.
            if (string.IsNullOrEmpty(tableName) && sasCredential != null)
            {
                var builder = new UriBuilder(endpoint);
                builder.Query = sasCredential.Signature;
                tableName = new TableSasBuilder(builder.Uri).TableName;
            }

            Argument.AssertNotNullOrEmpty(tableName, nameof(tableName));

            _endpoint = endpoint;
            _isCosmosEndpoint = TableServiceClient.IsPremiumEndpoint(endpoint);
            options ??= TableClientOptions.DefaultOptions;

            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();
            HttpPipelinePolicy authPolicy = sasCredential switch
            {
                null => policy,
                _ => new AzureSasCredentialSynchronousPolicy(sasCredential)
            };
            _pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies,
                new[] { authPolicy },
                new ResponseClassifier());

            _version = options.VersionString;
            _diagnostics = new TablesClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, _pipeline, endpoint.AbsoluteUri, _version);
            Name = tableName;
        }

        internal TableClient(
            string table,
            TableRestClient tableOperations,
            string version,
            ClientDiagnostics diagnostics,
            bool isPremiumEndpoint,
            Uri endpoint,
            HttpPipeline pipeline)
        {
            _tableOperations = tableOperations;
            _version = version;
            Name = table;
            _diagnostics = diagnostics;
            _isCosmosEndpoint = isPremiumEndpoint;
            _endpoint = endpoint;
            _pipeline = pipeline;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/> class for mocking.
        /// </summary>
        protected TableClient()
        { }

        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table which can be used to generate a Shared Access Signature (SAS)
        /// token capable of granting limited access to table resources.
        /// See <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-service-sas">Create a service SAS</see> for more details.
        /// </summary>
        /// <param name="permissions"><see cref="TableSasPermissions"/> containing the allowed permissions.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            return new(Name, permissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table which can be used to generate a Shared Access Signature (SAS)
        /// token capable of granting limited access to table resources.
        /// See <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-service-sas">Create a service SAS</see> for more details.
        /// </summary>
        /// <param name="rawPermissions">
        /// The permissions associated with the shared access signature.
        /// This string should contain one or more of the following permission characters in this order: "racwdl".
        /// See <see cref="GetSasBuilder(TableSasPermissions, DateTimeOffset)"/> if you prefer to specify strongly typed permission settings.
        /// </param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(string rawPermissions, DateTimeOffset expiresOn)
        {
            return new(Name, rawPermissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Creates the table specified by the tableName parameter used to construct this client instance.
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
                var response = _tableOperations.Create(
                    new TableProperties { TableName = Name },
                    null,
                    _defaultQueryOptions,
                    cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the table specified by the tableName parameter used to construct this client instance.
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
                var response = await _tableOperations.CreateAsync(
                        new TableProperties { TableName = Name },
                        null,
                        _defaultQueryOptions,
                        cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the table specified by the tableName parameter used to construct this client instance if it does not already exist.
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
                var response = _tableOperations.Create(
                    new TableProperties { TableName = Name },
                    null,
                    _defaultQueryOptions,
                    cancellationToken);
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
        /// Creates the table specified by the tableName parameter used to construct this client instance if it does not already exist.
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
                var response = await _tableOperations.CreateAsync(
                        new TableProperties { TableName = Name },
                        null,
                        _defaultQueryOptions,
                        cancellationToken)
                    .ConfigureAwait(false);
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
        /// Deletes the table specified by the tableName parameter used to construct this client instance.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table exists, a <see cref="Response"/>. If the table already does not exist, <c>null</c>.</returns>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                using var message = _tableOperations.CreateDeleteRequest(Name);
                _pipeline.Send(message, cancellationToken);

                switch (message.Response.Status)
                {
                    case 404:
                    case 204:
                        return message.Response;
                    default:
                        throw _diagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the table specified by the tableName parameter used to construct this client instance.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table exists, a <see cref="Response"/>. If the table already does not exist, <c>null</c>.</returns>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                using var message = _tableOperations.CreateDeleteRequest(Name);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

                switch (message.Response.Status)
                {
                    case 404:
                    case 204:
                        return message.Response;
                    default:
                        throw _diagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a Table Entity of type <typeparamref name="T"/> into the Table.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
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
                var response = await _tableOperations.InsertEntityAsync(
                        Name,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        responsePreference: _returnNoContent,
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a Table Entity of type <typeparamref name="T"/> into the Table.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
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
                var response = _tableOperations.InsertEntity(
                    Name,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    responsePreference: _returnNoContent,
                    queryOptions: _defaultQueryOptions,
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
        /// Gets the specified table entity of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual Response<T> GetEntity<T>(string partitionKey, string rowKey, IEnumerable<string> select = null, CancellationToken cancellationToken = default)
            where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            string selectArg = select == null ? null : string.Join(",", select);

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.QueryEntityWithPartitionAndRowKey(
                    Name,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions { Format = _defaultQueryOptions.Format, Select = selectArg },
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
        /// Gets the specified table entity of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="select">Selects which set of entity properties to return in the result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual async Task<Response<T>> GetEntityAsync<T>(
            string partitionKey,
            string rowKey,
            IEnumerable<string> select = null,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            string selectArg = select == null ? null : string.Join(",", select);

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.QueryEntityWithPartitionAndRowKeyAsync(
                        Name,
                        partitionKey,
                        rowKey,
                        queryOptions: new QueryOptions { Format = _defaultQueryOptions.Format, Select = selectArg },
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

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
        /// Replaces the specified table entity of type <typeparamref name="T"/>, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">Determines the behavior of the upsert operation when the entity already exists in the table.
        /// See <see cref="TableUpdateMode"/> for more details.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpsertEntityAsync<T>(
            T entity,
            TableUpdateMode mode = TableUpdateMode.Merge,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                return mode switch
                {
                    TableUpdateMode.Replace => await _tableOperations.UpdateEntityAsync(
                            Name,
                            TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                            TableOdataFilter.EscapeStringValue(entity.RowKey),
                            tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                            queryOptions: _defaultQueryOptions,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false),
                    TableUpdateMode.Merge => await _tableOperations.MergeEntityAsync(
                            Name,
                            TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                            TableOdataFilter.EscapeStringValue(entity.RowKey),
                            tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                            queryOptions: _defaultQueryOptions,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false),
                    _ => throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}")
                };
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity of type <typeparamref name="T"/>, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">Determines the behavior of the update operation when the entity already exists in the table.
        /// See <see cref="TableUpdateMode"/> for more details.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpsertEntity<T>(T entity, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default)
            where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                return mode switch
                {
                    TableUpdateMode.Replace => _tableOperations.UpdateEntity(
                        Name,
                        TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                        TableOdataFilter.EscapeStringValue(entity.RowKey),
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken),
                    TableUpdateMode.Merge => _tableOperations.MergeEntity(
                        Name,
                        TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                        TableOdataFilter.EscapeStringValue(entity.RowKey),
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken),
                    _ => throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}")
                };
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified table entity of type <typeparamref name="T"/>, if it exists.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Replace"/>, the entity will be replaced.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Merge"/>, the property values present in the <paramref name="entity"/>
        /// will be merged with the existing entity.
        /// </summary>
        /// <remarks>
        /// See <see cref="TableUpdateMode"/> for more information about the behavior of the <paramref name="mode"/>.
        /// </remarks>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// </param>
        /// <param name="mode">Determines the behavior of the Update operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpdateEntityAsync<T>(
            T entity,
            ETag ifMatch,
            TableUpdateMode mode = TableUpdateMode.Merge,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity.RowKey, nameof(entity.RowKey));
            Argument.AssertNotDefault(ref ifMatch, nameof(ifMatch));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(
                            Name,
                            TableOdataFilter.EscapeStringValue(entity.PartitionKey),
                            TableOdataFilter.EscapeStringValue(entity.RowKey),
                            tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                            ifMatch: ifMatch.ToString(),
                            queryOptions: _defaultQueryOptions,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                if (mode == TableUpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(
                            Name,
                            TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                            TableOdataFilter.EscapeStringValue(entity.RowKey),
                            tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                            ifMatch: ifMatch.ToString(),
                            queryOptions: _defaultQueryOptions,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified table entity of type <typeparamref name="T"/>, if it exists.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Replace"/>, the entity will be replaced.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Merge"/>, the property values present in the
        /// <paramref name="entity"/> will be merged with the existing entity.
        /// </summary>
        /// <remarks>
        /// See <see cref="TableUpdateMode"/> for more information about the behavior of the <paramref name="mode"/>.
        /// </remarks>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// </param>
        /// <param name="mode">Determines the behavior of the Update operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge, CancellationToken cancellationToken = default)
            where T : class, ITableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNull(entity.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity.RowKey, nameof(entity.RowKey));
            Argument.AssertNotDefault(ref ifMatch, nameof(ifMatch));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == TableUpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(
                        Name,
                        TableOdataFilter.EscapeStringValue(entity!.PartitionKey),
                        TableOdataFilter.EscapeStringValue(entity!.RowKey),
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken);
                }
                if (mode == TableUpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(
                        Name,
                        TableOdataFilter.EscapeStringValue(entity.PartitionKey),
                        TableOdataFilter.EscapeStringValue(entity.RowKey),
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: ifMatch.ToString(),
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken);
                }
                throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
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
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="filter">
        /// Returns only entities that satisfy the specified filter expression.
        /// For example, the following expression would filter entities with a PartitionKey of 'foo': <c>e => e.PartitionKey == "foo"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="select">
        /// An <see cref="IEnumerable{String}"/> of entity property names that selects which set of entity properties to return in the result set.
        /// For example, the following value would return only the PartitionKey and RowKey properties: <c>new[] { "PartitionKey, RowKey"}</c>.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of entity models serialized as type <typeparamref name="T"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<T> QueryAsync<T>(
            Expression<Func<T, bool>> filter,
            int? maxPerPage = null,
            IEnumerable<string> select = null,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
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
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="filter">
        /// Returns only entities that satisfy the specified filter expression.
        /// For example, the following expression would filter entities with a PartitionKey of 'foo': <c>e => e.PartitionKey == "foo"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="select">
        /// An <see cref="IEnumerable{String}"/> of entity property names that selects which set of entity properties to return in the result set.
        /// For example, the following value would return only the PartitionKey and RowKey properties: <c>new[] { "PartitionKey, RowKey"}</c>.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing a collection of entity models serialized as type <typeparamref name="T"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<T> Query<T>(
            Expression<Func<T, bool>> filter,
            int? maxPerPage = null,
            IEnumerable<string> select = null,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
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
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="filter">
        /// Returns only entities that satisfy the specified OData filter.
        /// For example, the following filter would filter entities with a PartitionKey of 'foo': <c>"PartitionKey eq 'foo'"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="select">
        /// An <see cref="IEnumerable{String}"/> of entity property names that selects which set of entity properties to return in the result set.
        /// For example, the following value would return only the PartitionKey and RowKey properties: <c>new[] { "PartitionKey, RowKey"}</c>.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of entity models serialized as type <typeparamref name="T"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<T> QueryAsync<T>(
            string filter = null,
            int? maxPerPage = null,
            IEnumerable<string> select = null,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            string selectArg = select == null ? null : string.Join(",", select);

            return PageableHelpers.CreateAsyncEnumerable(
                async pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var response = await _tableOperations.QueryEntitiesAsync(
                                Name,
                                queryOptions: new QueryOptions { Format = _defaultQueryOptions.Format, Top = pageSizeHint, Filter = filter, Select = selectArg },
                                cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

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
                },
                async (continuationToken, pageSizeHint) =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                        var response = await _tableOperations.QueryEntitiesAsync(
                                Name,
                                queryOptions: new QueryOptions { Format = _defaultQueryOptions.Format, Top = pageSizeHint, Filter = filter, Select = selectArg },
                                nextPartitionKey: NextPartitionKey,
                                nextRowKey: NextRowKey,
                                cancellationToken: cancellationToken)
                            .ConfigureAwait(false);

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
                },
                maxPerPage);
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="filter">
        /// Returns only entities that satisfy the specified OData filter.
        /// For example, the following filter would filter entities with a PartitionKey of 'foo': <c>"PartitionKey eq 'foo'"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="select">
        /// An <see cref="IEnumerable{String}"/> of entity property names that selects which set of entity properties to return in the result set.
        /// For example, the following value would return only the PartitionKey and RowKey properties: <c>new[] { "PartitionKey, RowKey"}</c>.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing a collection of entity models serialized as type <typeparamref name="T"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<T> Query<T>(
            string filter = null,
            int? maxPerPage = null,
            IEnumerable<string> select = null,
            CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            string selectArg = select == null ? null : string.Join(",", select);

            return PageableHelpers.CreateEnumerable(
                pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var queryOptions = new QueryOptions { Format = _defaultQueryOptions.Format, Top = pageSizeHint, Filter = filter, Select = selectArg };

                        var response = _tableOperations.QueryEntities(
                            Name,
                            queryOptions: queryOptions,
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
                },
                (continuationToken, pageSizeHint) =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                        var queryOptions = new QueryOptions { Format = _defaultQueryOptions.Format, Top = pageSizeHint, Filter = filter, Select = selectArg };

                        var response = _tableOperations.QueryEntities(
                            Name,
                            queryOptions: queryOptions,
                            nextPartitionKey: NextPartitionKey,
                            nextRowKey: NextRowKey,
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
                },
                maxPerPage);
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// The default is to delete unconditionally.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> DeleteEntityAsync(
            string partitionKey,
            string rowKey,
            ETag ifMatch = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(DeleteEntity)}");
            scope.Start();
            try
            {
                var etag = ifMatch == default ? ETag.All.ToString() : ifMatch.ToString();
                using var message = _tableOperations.CreateDeleteEntityRequest(Name, partitionKey, rowKey, etag, null, _defaultQueryOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

                switch (message.Response.Status)
                {
                    case 404:
                    case 204:
                        return message.Response;
                    default:
                        throw _diagnostics.CreateRequestFailedException(message.Response);
                }
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
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// The default is to delete unconditionally.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>If the entity exists, the <see cref="Response"/> indicating the result of the operation. If the entity does not exist, <c>null</c></returns>
        public virtual Response DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(DeleteEntity)}");
            scope.Start();
            try
            {
                var etag = ifMatch == default ? ETag.All.ToString() : ifMatch.ToString();
                using var message = _tableOperations.CreateDeleteEntityRequest(Name, partitionKey, rowKey, etag, null, _defaultQueryOptions);
                _pipeline.Send(message, cancellationToken);

                switch (message.Response.Status)
                {
                    case 404:
                    case 204:
                        return message.Response;
                    default:
                        throw _diagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<IReadOnlyList<TableSignedIdentifier>>> GetAccessPoliciesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicies)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.GetAccessPolicyAsync(Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<IReadOnlyList<TableSignedIdentifier>> GetAccessPolicies(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicies)}");
            scope.Start();
            try
            {
                var response = _tableOperations.GetAccessPolicy(Name, cancellationToken: cancellationToken);
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
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> SetAccessPolicyAsync(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return await _tableOperations.SetAccessPolicyAsync(Name, tableAcl: tableAcl, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response SetAccessPolicy(IEnumerable<TableSignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return _tableOperations.SetAccessPolicy(Name, tableAcl: tableAcl, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an OData filter query string from the provided expression.
        /// </summary>
        /// <typeparam name="T">The type of the entity being queried. Typically this will be derived from <see cref="ITableEntity"/>
        /// or <see cref="Dictionary{String, Object}"/>.</typeparam>
        /// <param name="filter">A filter expression.</param>
        /// <returns>The string representation of the filter expression.</returns>
        public static string CreateQueryFilter<T>(Expression<Func<T, bool>> filter) => Bind(filter);

        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <returns>A valid OData filter expression.</returns>
        public static string CreateQueryFilter(FormattableString filter) => TableOdataFilter.Create(filter);

        /// <summary>
        /// Submits the batch transaction to the service for execution.
        /// The sub-operations contained in the batch will either succeed or fail together as a transaction.
        /// </summary>
        /// <param name="transactionActions">The <see cref="IEnumerable{T}"/> containing the <see cref="TableTransactionAction"/>s to submit to the service.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns><see cref="Response{T}"/> containing a <see cref="TableTransactionResult"/>.</returns>
        /// <exception cref="RequestFailedException"/> if the batch transaction fails./>
        /// <exception cref="InvalidOperationException"/> if the batch has been previously submitted.
        public virtual async Task<Response<IReadOnlyList<Response>>> SubmitTransactionAsync(
            IEnumerable<TableTransactionAction> transactionActions,
            CancellationToken cancellationToken = default) =>
            await SubmitTransactionInternalAsync(transactionActions, _batchGuid ?? Guid.NewGuid(), _changesetGuid ?? Guid.NewGuid(), true, cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Submits the batch transaction to the service for execution.
        /// The sub-operations contained in the batch will either succeed or fail together as a transaction.
        /// </summary>
        /// <param name="transactionActions">The <see cref="IEnumerable{T}"/> containing the <see cref="TableTransactionAction"/>s to submit to the service.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns><see cref="Response{T}"/> containing a <see cref="TableTransactionResult"/>.</returns>
        /// <exception cref="RequestFailedException"/> if the batch transaction fails./>
        /// <exception cref="InvalidOperationException"/> if the batch has been previously submitted.
        public virtual Response<IReadOnlyList<Response>> SubmitTransaction(
            IEnumerable<TableTransactionAction> transactionActions,
            CancellationToken cancellationToken = default) =>
            SubmitTransactionInternalAsync(transactionActions, _batchGuid ?? Guid.NewGuid(), _changesetGuid ?? Guid.NewGuid(), false, cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// The <see cref="GenerateSasUri(TableSasPermissions, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Table Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and parameters passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="permissions"> Required. Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="TableSasPermissions"/>.
        /// </param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <returns> A <see cref="TableSasBuilder"/> on successfully deleting. </returns>
        /// <remarks> An <see cref="Exception"/> will be thrown if a failure occurs. </remarks>
        public virtual Uri GenerateSasUri(TableSasPermissions permissions, DateTimeOffset expiresOn)
            => GenerateSasUri(new TableSasBuilder(Name, permissions, expiresOn) { TableName = Name });

        /// <summary>
        /// The <see cref="GenerateSasUri(TableSasBuilder)"/> returns a
        /// <see cref="Uri"/> that generates a Table Service SAS Uri based
        /// on the Client properties and builder passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>
        /// </summary>
        /// <param name="builder"> Used to generate a Shared Access Signature (SAS). </param>
        /// <returns> A <see cref="TableSasBuilder"/> on successfully deleting. </returns>
        /// <remarks> An <see cref="Exception"/> will be thrown if a failure occurs. </remarks>
        public virtual Uri GenerateSasUri(
            TableSasBuilder builder)
        {
            builder = builder ?? throw Errors.ArgumentNull(nameof(builder));
            if (!builder.TableName.Equals(Name, StringComparison.InvariantCulture))
            {
                throw new ArgumentException($"The {nameof(builder.TableName)} must match the table name used to initialize this instance of the client");
            }
            TableUriBuilder sasUri = new(_endpoint);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
            return sasUri.ToUri();
        }

        internal virtual async Task<Response<IReadOnlyList<Response>>> SubmitTransactionInternalAsync(
            IEnumerable<TableTransactionAction> transactionalBatch,
            Guid batchId,
            Guid changesetId,
            bool async,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitTransaction)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(transactionalBatch, nameof(transactionalBatch));
                List<TableTransactionAction> batchItems = transactionalBatch.ToList();
                if (!batchItems.Any())
                {
                    throw new InvalidOperationException(TableConstants.ExceptionMessages.BatchIsEmpty);
                }
                Dictionary<string, HttpMessage> requestLookup = new();

                var batchOperations = new TableRestClient(_diagnostics, CreateBatchPipeline(), _tableOperations.endpoint, _tableOperations.clientVersion);
                var _batch = BuildChangeSet(batchOperations, batchItems, requestLookup, batchId, changesetId);
                var request = _tableOperations.CreateBatchRequest(_batch, null, null);

                return async
                    ? await _tableOperations.SendBatchRequestAsync(request, cancellationToken).ConfigureAwait(false)
                    : _tableOperations.SendBatchRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Builds an ordered list of <see cref="HttpMessage"/>s containing the batch sub-requests.
        /// </summary>
        /// <returns></returns>
        private MultipartContent BuildChangeSet(
            TableRestClient batchOperations,
            IEnumerable<TableTransactionAction> batch,
            Dictionary<string, HttpMessage> requestLookup,
            Guid batchId,
            Guid changesetId)
        {
            var batchContent = TableRestClient.CreateBatchContent(batchId);
            var changeset = batchContent.AddChangeset(changesetId);
            foreach (var item in batch)
            {
                //var item = batch._requestLookup[key];
                HttpMessage message = item.ActionType switch
                {
                    TableTransactionActionType.Add => batchOperations.CreateInsertEntityRequest(
                        Name,
                        null,
                        _returnNoContent,
                        item.Entity.ToOdataAnnotatedDictionary(),
                        new QueryOptions { Format = _defaultQueryOptions.Format!.Value }),
                    TableTransactionActionType.Delete => batchOperations.CreateDeleteEntityRequest(
                        Name,
                        TableOdataFilter.EscapeStringValue(item.Entity.PartitionKey),
                        TableOdataFilter.EscapeStringValue(item.Entity.RowKey),
                        item.ETag == default ? ETag.All.ToString() : item.ETag.ToString(),
                        null,
                        new QueryOptions { Format = _defaultQueryOptions.Format!.Value }),
                    TableTransactionActionType.UpdateReplace => CreateUpdateOrMergeRequest(batchOperations, item.Entity, TableUpdateMode.Replace, item.ETag),
                    TableTransactionActionType.UpdateMerge => CreateUpdateOrMergeRequest(batchOperations, item.Entity, TableUpdateMode.Merge, item.ETag),
                    TableTransactionActionType.UpsertReplace => CreateUpdateOrMergeRequest(batchOperations, item.Entity, TableUpdateMode.Replace),
                    TableTransactionActionType.UpsertMerge => CreateUpdateOrMergeRequest(batchOperations, item.Entity, TableUpdateMode.Merge),
                    _ => throw new InvalidOperationException("Unknown request type.")
                };
                requestLookup[item.Entity.RowKey] = message;
                changeset.AddContent(new RequestRequestContent(message!.Request));
            }
            return batchContent;
        }

        private HttpMessage CreateUpdateOrMergeRequest(TableRestClient batchOperations, ITableEntity entity, TableUpdateMode mode, ETag ifMatch = default)
        {
            HttpMessage msg = mode switch
            {
                TableUpdateMode.Replace => batchOperations.CreateUpdateEntityRequest(
                    Name,
                    TableOdataFilter.EscapeStringValue(entity.PartitionKey),
                    TableOdataFilter.EscapeStringValue(entity.RowKey),
                    null,
                    ifMatch == default ? null : ifMatch.ToString(),
                    entity.ToOdataAnnotatedDictionary(),
                    new QueryOptions { Format = _defaultQueryOptions.Format!.Value }),
                TableUpdateMode.Merge => batchOperations.CreateMergeEntityRequest(
                    Name,
                    TableOdataFilter.EscapeStringValue(entity.PartitionKey),
                    TableOdataFilter.EscapeStringValue(entity.RowKey),
                    null,
                    ifMatch == default ? null : ifMatch.ToString(),
                    entity.ToOdataAnnotatedDictionary(),
                    new QueryOptions { Format = _defaultQueryOptions.Format!.Value }),
                _ => throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}")
            };

            if (_isCosmosEndpoint && mode == TableUpdateMode.Merge)
            {
                CosmosPatchTransformPolicy.TransformPatchToCosmosPost(msg);
            }

            return msg;
        }

        /// <summary>
        /// Creates a pipeline to use for processing sub-operations before they are combined into a single multipart request.
        /// </summary>
        /// <returns>A pipeline to use for processing sub-operations.</returns>
        private static HttpPipeline CreateBatchPipeline()
        {
            // Configure the options to use minimal policies
            var options = new TableClientOptions();
            options.Diagnostics.IsLoggingEnabled = false;
            options.Diagnostics.IsTelemetryEnabled = false;
            options.Diagnostics.IsDistributedTracingEnabled = false;
            options.Retry.MaxRetries = 0;

            // Use an empty transport so requests aren't sent
            options.Transport = new MemoryTransport();

            // Use the same authentication mechanism
            return HttpPipelineBuilder.Build(options);
        }

        internal static string Bind(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Dictionary<Expression, Expression> normalizerRewrites = new(ReferenceEqualityComparer<Expression>.Instance);

            // Evaluate any local valid expressions ( lambdas etc)
            Expression partialEvaluatedExpression = Evaluator.PartialEval(expression);

            // Normalize expression, replace String Comparisons etc.
            Expression normalizedExpression = ExpressionNormalizer.Normalize(partialEvaluatedExpression, normalizerRewrites);

            // Parse the Bound expression into an OData filter.
            ExpressionParser parser = new();
            parser.Translate(normalizedExpression);

            // Return the FilterString.
            return parser.FilterString == "true" ? null : parser.FilterString;
        }

        internal static string CreateContinuationTokenFromHeaders(TableQueryEntitiesHeaders headers)
        {
            if (headers.XMsContinuationNextPartitionKey == null && headers.XMsContinuationNextRowKey == null)
            {
                return null;
            }
            return $"{headers.XMsContinuationNextPartitionKey} {headers.XMsContinuationNextRowKey}";
        }

        internal static (string NextPartitionKey, string NextRowKey) ParseContinuationToken(string continuationToken)
        {
            // There were no headers passed and the continuation token contains just the space delimiter
            if (continuationToken is null || continuationToken.Length <= 1)
            {
                return (null, null);
            }

            var tokens = continuationToken.Split(ContinuationTokenSplit, 2);
            return (tokens[0], tokens.Length > 1 && tokens[1].Length > 0 ? tokens[1] : null);
        }

        /// <summary>
        /// Re-initializes the batch with the specified Guids for testing purposes.
        /// </summary>
        /// <param name="batchGuid">The batch boundary Guid.</param>
        /// <param name="changesetGuid">The changeset boundary Guid.</param>
        internal virtual void SetBatchGuids(Guid batchGuid, Guid changesetGuid)
        {
            _batchGuid = batchGuid;
            _changesetGuid = changesetGuid;
        }
    }
}
