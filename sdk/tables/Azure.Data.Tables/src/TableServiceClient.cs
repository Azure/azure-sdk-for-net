// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables
{
    public class TableServiceClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly ServiceRestClient _serviceOperations;
        private readonly ServiceRestClient _secondaryServiceOperations;
        private readonly OdataMetadataFormat _format = OdataMetadataFormat.ApplicationJsonOdataMinimalmetadata;
        private readonly string _version;
        internal readonly bool _isPremiumEndpoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        public TableServiceClient(Uri endpoint)
                : this(endpoint, options: null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>.
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
        /// Initializes a new instance of the <see cref="TableServiceClient"/>.
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
        /// Initializes a new instance of the <see cref="TableServiceClient"/>.
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

        internal TableServiceClient(Uri endpoint, TableSharedKeyPipelinePolicy policy, TableClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new TableClientOptions();
            var endpointString = endpoint.ToString();
            var secondaryEndpoint = endpointString.Insert(endpointString.IndexOf('.'), "-secondary");
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, policy);

            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpointString);
            _serviceOperations = new ServiceRestClient(_diagnostics, pipeline, endpointString);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, pipeline, secondaryEndpoint);
            _version = options.VersionString;
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

        public virtual TableClient GetTableClient(string tableName)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            return new TableClient(tableName, _tableOperations, _version, _diagnostics, _isPremiumEndpoint);
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="filter">Returns only tables that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of tables that will be returned per page.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<TableItem> GetTablesAsync(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
            scope.Start();
            try
            {
                return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.QueryAsync(
                    null,
                    null,
                    new QueryOptions() { Filter = filter, Select = null, Top = maxPerPage, Format = _format },
                    cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _tableOperations.QueryAsync(
                       null,
                       nextTableName: nextLink,
                       new QueryOptions() { Filter = filter, Select = null, Top = maxPerPage, Format = _format },
                       cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            });
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
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of tables that will be returned per page.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Pageable<TableItem> GetTables(string filter = null, int? maxPerPage = null, CancellationToken cancellationToken = default)
        {

            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
                scope.Start();
                try
                {
                    var response = _tableOperations.Query(
                            null,
                            null,
                            new QueryOptions() { Filter = filter, Select = null, Top = maxPerPage, Format = _format },
                            cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (nextLink, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(GetTables)}");
                scope.Start();
                try
                {
                    var response = _tableOperations.Query(
                        null,
                        nextTableName: nextLink,
                        new QueryOptions() { Filter = filter, Select = null, Top = maxPerPage, Format = _format },
                        cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual Response<TableItem> CreateTable(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties() { TableName = tableName }, null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table.</returns>
        public virtual async Task<Response<TableItem>> CreateTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = tableName }, null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual Response<TableItem> CreateTableIfNotExists(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties() { TableName = tableName }, null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken);
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
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>If the table does not already exist, a <see cref="Response{TableItem}"/>. If the table already exists, <c>null</c>.</returns>
        public virtual async Task<Response<TableItem>> CreateTableIfNotExistsAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = tableName }, null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Deletes a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Response DeleteTable(string tableName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return _tableOperations.Delete(tableName, null, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteAsync(tableName, null, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="properties"> The Table Service properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
