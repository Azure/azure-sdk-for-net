// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    public class TableServiceClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly ServiceRestClient _serviceOperations;
        private readonly OdataMetadataFormat _format = OdataMetadataFormat.ApplicationJsonOdataFullmetadata;
        private readonly string _version;
        internal readonly bool _isPremiumEndpoint;

        public TableServiceClient(Uri endpoint)
                : this(endpoint, options: null)
        { }

        public TableServiceClient(Uri endpoint, TableClientOptions options = null)
            : this(endpoint, default(TableSharedKeyPipelinePolicy), options)
        {
            if (endpoint.Scheme != "https")
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.", nameof(endpoint));
            }
        }

        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

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
            HttpPipeline pipeline;

            if (policy == default)
            {
                pipeline = HttpPipelineBuilder.Build(options);
            }
            else
            {
                pipeline = HttpPipelineBuilder.Build(options, policy);
            }

            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, pipeline, endpointString);
            _serviceOperations = new ServiceRestClient(_diagnostics, pipeline, endpointString);
            _version = options.VersionString;

            string absoluteUri = endpoint.OriginalString.ToLowerInvariant();
            _isPremiumEndpoint = (endpoint.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase) && endpoint.Port != 10002) ||
                absoluteUri.Contains(TableConstants.CosmosTableDomain) || absoluteUri.Contains(TableConstants.LegacyCosmosTableDomain);
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

        public virtual TableClient GetTableClient(string tableName)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            return new TableClient(tableName, _tableOperations, _version, _diagnostics, _isPremiumEndpoint);
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<TableItem> GetTablesAsync(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
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
                    new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
                    cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _tableOperations.QueryAsync(
                       null,
                       nextTableName: nextLink,
                       new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
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
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Pageable<TableItem> GetTables(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
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
                            new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
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
                        new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
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
        /// <returns></returns>
        public virtual Response<TableItem> CreateTable(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties(tableName), null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken);
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
        /// <returns></returns>
        public virtual async Task<Response<TableItem>> CreateTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTable)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties(tableName), null, queryOptions: new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
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

        /// <summary> Sets properties for an account&apos;s Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="tableServiceProperties"> The Table Service properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetProperties(TableServiceProperties tableServiceProperties, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return _serviceOperations.SetProperties(tableServiceProperties, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Sets properties for an account&apos;s Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="tableServiceProperties"> The Table Service properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetPropertiesAsync(TableServiceProperties tableServiceProperties, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return await _serviceOperations.SetPropertiesAsync(tableServiceProperties, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the properties of an account&apos;s Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
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

        /// <summary> Gets the properties of an account&apos;s Table service, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
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
    }
}
