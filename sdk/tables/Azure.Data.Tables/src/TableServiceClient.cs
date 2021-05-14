// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The <see cref="TableServiceClient"/> provides synchronous and asynchronous methods to perform table level operations with Azure Tables hosted in either Azure storage accounts or Azure Cosmos DB table API.
    /// </summary>
    public class TableServiceClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly ServiceRestClient _serviceOperations;
        private readonly ServiceRestClient _secondaryServiceOperations;
        private readonly OdataMetadataFormat _format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata;
        private readonly string _version;
        internal readonly bool _isCosmosEndpoint;
        private readonly QueryOptions _defaultQueryOptions = new QueryOptions() { Format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata };
        private string _accountName;
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// The name of the table account with which this client instance will interact.
        /// </summary>
        public virtual string AccountName
        {
            get
            {
                if (_accountName == null)
                {
                    var builder = new TableUriBuilder(_endpoint);
                    _accountName = builder.AccountName;
                }

                return _accountName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential. See <see cref="TableClient.GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared access signature credential used to sign requests.</param>
        public TableServiceClient(Uri endpoint, AzureSasCredential credential)
            : this(endpoint, credential, null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified connection string.
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
        public TableServiceClient(string connectionString)
            : this(connectionString, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential. See <see cref="TableClient.GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared access signature credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        public TableServiceClient(Uri endpoint, AzureSasCredential credential, TablesClientOptions options = null)
            : this(endpoint, default, credential, options)
        {
            if (endpoint.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.", nameof(endpoint));
            }

            Argument.AssertNotNull(credential, nameof(credential));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified table service <see cref="Uri" /> and <see cref="TableSharedKeyCredential" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), default, null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified table service <see cref="Uri" /> and <see cref="TableSharedKeyCredential" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared key credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential, TablesClientOptions options)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), default, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified connection string.
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
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        public TableServiceClient(string connectionString, TablesClientOptions options = null)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            TableConnectionString connString = TableConnectionString.Parse(connectionString);
            _accountName = connString._accountName;

            options ??= new TablesClientOptions();
            var endpointString = connString.TableStorageUri.PrimaryUri.AbsoluteUri;
            var secondaryEndpoint = connString.TableStorageUri.SecondaryUri?.AbsoluteUri;
            _isCosmosEndpoint = TableServiceClient.IsPremiumEndpoint(connString.TableStorageUri.PrimaryUri);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();

            TableSharedKeyPipelinePolicy policy = connString.Credentials switch
            {
                TableSharedKeyCredential credential => new TableSharedKeyPipelinePolicy(credential),
                _ => default
            };
            _pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies: perCallPolicies,
                perRetryPolicies: new[] { policy },
                new ResponseClassifier());

            _version = options.VersionString;
            _diagnostics = new TablesClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, _pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, _pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, _pipeline, secondaryEndpoint, _version);
        }

        internal TableServiceClient(Uri endpoint, TableSharedKeyPipelinePolicy policy, AzureSasCredential sasCredential, TablesClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            _endpoint = endpoint;
            options ??= new TablesClientOptions();
            _isCosmosEndpoint = IsPremiumEndpoint(endpoint);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();
            var endpointString = endpoint.AbsoluteUri;
            string secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(endpoint)?.AbsoluteUri;

            HttpPipelinePolicy authPolicy = sasCredential switch
            {
                null => policy,
                _ => new AzureSasCredentialSynchronousPolicy(sasCredential)
            };
            _pipeline = HttpPipelineBuilder.Build(
                options,
                perCallPolicies: perCallPolicies,
                perRetryPolicies: new[] { authPolicy },
                new ResponseClassifier());

            _version = options.VersionString;
            _diagnostics = new TablesClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, _pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, _pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, _pipeline, secondaryEndpoint, _version);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>
        /// class for mocking.
        /// </summary>
        internal TableServiceClient(TableRestClient internalClient)
        {
            _tableOperations = internalClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected TableServiceClient()
        { }

        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current account.
        /// </summary>
        /// <param name="permissions"><see cref="TableAccountSasPermissions"/> containing the allowed permissions.</param>
        /// <param name="resourceTypes"><see cref="TableAccountSasResourceTypes"/> containing the accessible resource types.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableAccountSasBuilder"/>.</returns>
        public virtual TableAccountSasBuilder GetSasBuilder(
            TableAccountSasPermissions permissions,
            TableAccountSasResourceTypes resourceTypes,
            DateTimeOffset expiresOn)
        {
            return new TableAccountSasBuilder(permissions, resourceTypes, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Gets a <see cref="TableAccountSasBuilder"/> instance scoped to the current table.
        /// </summary>
        /// <param name="rawPermissions">The permissions associated with the shared access signature. This string should contain one or more of the following permission characters in this order: "racwdl".</param>
        /// <param name="resourceTypes"><see cref="TableAccountSasResourceTypes"/> containing the accessible resource types.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableAccountSasBuilder"/>.</returns>
        public virtual TableAccountSasBuilder GetSasBuilder(string rawPermissions, TableAccountSasResourceTypes resourceTypes, DateTimeOffset expiresOn)
        {
            return new TableAccountSasBuilder(rawPermissions, resourceTypes, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Gets an instance of a <see cref="TableClient"/> configured with the current <see cref="TableServiceClient"/> options, affinitized to the specified <paramref name="tableName"/>.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual TableClient GetTableClient(string tableName)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            return new TableClient(tableName, _tableOperations, _version, _diagnostics, _isCosmosEndpoint, _endpoint, _pipeline);
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter.
        /// For example, the following would filter tables with a Name of 'foo': <c>"TableName eq 'foo'"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of tables that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of <see cref="TableItem"/>s.</returns>
        public virtual AsyncPageable<TableItem> QueryAsync(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(
                async pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var response = await _tableOperations.QueryAsync(
                                null,
                                new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                                cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                },
                async (nextLink, pageSizeHint) =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var response = await _tableOperations.QueryAsync(
                                nextTableName: nextLink,
                                new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                                cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
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
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter.
        /// For example, the following would filter tables with a Name of 'foo': <c>"TableName eq 'foo'"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number tables that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing a collection of <see cref="TableItem"/>.</returns>
        public virtual Pageable<TableItem> Query(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(
                pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var response = _tableOperations.Query(
                            null,
                            new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                            cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                },
                (nextLink, pageSizeHint) =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var response = _tableOperations.Query(
                            nextLink,
                            new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                            cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
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
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter expression.
        /// For example, the following would filter tables with a Name of 'foo': <c>"TableName eq {someStringVariable}"</c>.
        /// The filter string will be properly quoted and escaped.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of <see cref="TableItem"/>s.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<TableItem> QueryAsync(FormattableString filter, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return QueryAsync(TableOdataFilter.Create(filter), maxPerPage, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter expression.
        /// For example, the following would filter tables with a Name of 'foo': <c>"TableName eq {someStringVariable}"</c>.
        /// The filter string will be properly quoted and escaped.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing a collection of <see cref="TableItem"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<TableItem> Query(FormattableString filter, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return Query(TableOdataFilter.Create(filter), maxPerPage, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter expression.
        /// For example, the following expression would filter tables with a Name of 'foo': <c>e => e.Name == "foo"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of <see cref="TableItem"/>s.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<TableItem> QueryAsync(
            Expression<Func<TableItem, bool>> filter,
            int? maxPerPage = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return QueryAsync(TableClient.Bind(filter), maxPerPage, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">
        /// Returns only tables that satisfy the specified filter expression.
        /// For example, the following expression would filter tables with a Name of 'foo': <c>e => e.Name == "foo"</c>.
        /// </param>
        /// <param name="maxPerPage">
        /// The maximum number of entities that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing a collection of <see cref="TableItem"/>.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<TableItem> Query(Expression<Func<TableItem, bool>> filter, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return Query(TableClient.Bind(filter), maxPerPage, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual Response<TableItem> CreateTable(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(
                    new TableProperties() { TableName = tableName },
                    null,
                    queryOptions: _defaultQueryOptions,
                    cancellationToken: cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual async Task<Response<TableItem>> CreateTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(
                        new TableProperties() { TableName = tableName },
                        null,
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken)
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
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual Response<TableItem> CreateTableIfNotExists(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(
                    new TableProperties() { TableName = tableName },
                    null,
                    queryOptions: _defaultQueryOptions,
                    cancellationToken: cancellationToken);
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
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual async Task<Response<TableItem>> CreateTableIfNotExistsAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(
                        new TableProperties() { TableName = tableName },
                        null,
                        queryOptions: _defaultQueryOptions,
                        cancellationToken: cancellationToken)
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
        /// Deletes a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response DeleteTable(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                using var message = _tableOperations.CreateDeleteRequest(tableName);
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
        /// Deletes a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> DeleteTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                using var message = _tableOperations.CreateDeleteRequest(tableName);
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

        /// <summary> Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="properties"> The Table Service properties. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response SetProperties(TableServiceProperties properties, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return _serviceOperations.SetProperties(properties, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="properties"> The Table Service properties. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> SetPropertiesAsync(TableServiceProperties properties, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return await _serviceOperations.SetPropertiesAsync(properties, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the properties of an account's Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response{TableServiceProperties}"/> indicating the result of the operation.</returns>
        public virtual Response<TableServiceProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                var response = _serviceOperations.GetProperties(cancellationToken: cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the properties of an account's Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response{TableServiceProperties}"/> indicating the result of the operation.</returns>
        public virtual async Task<Response<TableServiceProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                var response = await _serviceOperations.GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the account. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<TableServiceStatistics>> GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetStatistics)}");
            scope.Start();
            try
            {
                var response = await _secondaryServiceOperations.GetStatisticsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves statistics related to replication for the Table service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the account. </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<TableServiceStatistics> GetStatistics(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetStatistics)}");
            scope.Start();
            try
            {
                var response = _secondaryServiceOperations.GetStatistics(cancellationToken: cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static bool IsPremiumEndpoint(Uri endpoint)
        {
            return (endpoint.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase) && endpoint.Port != 10002) ||
                   endpoint.Host.IndexOf(TableConstants.CosmosTableDomain, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   endpoint.Host.IndexOf(TableConstants.LegacyCosmosTableDomain, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Creates an OData filter query string from the provided expression.
        /// </summary>
        /// <param name="filter">A filter expression.</param>
        /// <returns>The string representation of the filter expression.</returns>
        public static string CreateQueryFilter(Expression<Func<TableItem, bool>> filter) => TableClient.Bind(filter);

        /// <summary>
        /// Create an OData filter expression from an interpolated string.  The interpolated values will be quoted and escaped as necessary.
        /// </summary>
        /// <param name="filter">An interpolated filter string.</param>
        /// <returns>A valid OData filter expression.</returns>
        public static string CreateQueryFilter(FormattableString filter) => TableOdataFilter.Create(filter);
    }
}
