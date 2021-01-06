// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        internal readonly bool _isPremiumEndpoint;
        private readonly QueryOptions _defaultQueryOptions = new QueryOptions() { Format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata };

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential. See <see cref="TableClient.GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        public TableServiceClient(Uri endpoint)
                : this(endpoint, options: null)
        { }

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
            : this(connectionString, options: null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential. See <see cref="TableClient.GetSasBuilder(TableSasPermissions, DateTimeOffset)" /> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        public TableServiceClient(Uri endpoint, TableClientOptions options = null)
            : this(endpoint, default(TableSharedKeyPipelinePolicy), options)
        {
            if (endpoint.Scheme != "https")
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.", nameof(endpoint));
            }
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
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), null)
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
        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential, TableClientOptions options = null)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), options)
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
        public TableServiceClient(string connectionString, TableClientOptions options = null)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            TableConnectionString connString = TableConnectionString.Parse(connectionString);

            options ??= new TableClientOptions();
            var endpointString = connString.TableStorageUri.PrimaryUri.AbsoluteUri;
            var secondaryEndpoint = connString.TableStorageUri.SecondaryUri?.AbsoluteUri;

            TableSharedKeyPipelinePolicy policy = connString.Credentials switch
            {
                TableSharedKeyCredential credential => new TableSharedKeyPipelinePolicy(credential),
                _ => default
            };
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, policy);

            _version = options.VersionString;
            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, pipeline, secondaryEndpoint, _version);
            _isPremiumEndpoint = IsPremiumEndpoint(connString.TableStorageUri.PrimaryUri);
        }

        internal TableServiceClient(Uri endpoint, TableSharedKeyPipelinePolicy policy, TableClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new TableClientOptions();
            var endpointString = endpoint.AbsoluteUri;
            string secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(endpoint)?.AbsoluteUri;
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, policy);

            _version = options.VersionString;
            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, pipeline, secondaryEndpoint, _version);
            _isPremiumEndpoint = IsPremiumEndpoint(endpoint);
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
        public virtual TableAccountSasBuilder GetSasBuilder(TableAccountSasPermissions permissions, TableAccountSasResourceTypes resourceTypes, DateTimeOffset expiresOn)
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

            return new TableClient(tableName, _tableOperations, _version, _diagnostics, _isPremiumEndpoint);
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">Returns only tables that satisfy the specified filter.</param>
        /// <param name="maxPerPage">
        /// The maximum number of tables that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing a collection of <see cref="TableItem"/>s.</returns>
        public virtual AsyncPageable<TableItem> GetTablesAsync(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(
                async pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
                    scope.Start();
                    try
                    {
                        var response = await _tableOperations.QueryAsync(
                            null,
                            new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                            cancellationToken).ConfigureAwait(false);
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
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
                    scope.Start();
                    try
                    {
                        var response = await _tableOperations.QueryAsync(
                            nextTableName: nextLink,
                            new QueryOptions() { Filter = filter, Select = null, Top = pageSizeHint, Format = _format },
                            cancellationToken).ConfigureAwait(false);
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
        /// <param name="filter">Returns only tables that satisfy the specified filter.</param>
        /// <param name="maxPerPage">
        /// The maximum number tables that will be returned per page.
        /// Note: This value does not limit the total number of results if the result is fully enumerated.
        /// </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing a collection of <see cref="TableItem"/>.</returns>
        public virtual Pageable<TableItem> GetTables(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(
                pageSizeHint =>
                {
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
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
                    using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
                    scope.Start();
                    try
                    {
                        var response = _tableOperations.Query(
                            nextTableName: nextLink,
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
                var response = _tableOperations.Create(new TableProperties() { TableName = tableName }, null, queryOptions: _defaultQueryOptions, cancellationToken: cancellationToken);
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
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = tableName }, null, queryOptions: _defaultQueryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                var response = _tableOperations.Create(new TableProperties() { TableName = tableName }, null, queryOptions: _defaultQueryOptions, cancellationToken: cancellationToken);
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
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = tableName }, null, queryOptions: _defaultQueryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return _tableOperations.Delete(tableName, cancellationToken: cancellationToken);
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
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteAsync(tableName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
            string absoluteUri = endpoint.OriginalString.ToLowerInvariant();
            return (endpoint.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase) && endpoint.Port != 10002) ||
                absoluteUri.Contains(TableConstants.CosmosTableDomain) || absoluteUri.Contains(TableConstants.LegacyCosmosTableDomain);
        }
    }
}
