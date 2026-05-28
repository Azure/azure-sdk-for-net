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
        private readonly TableUriBuilder _tableUriBuilder;

        /// <summary>
        /// The <see cref="TableSharedKeyCredential"/> used to authenticate and generate SAS
        /// </summary>
        private TableSharedKeyCredential _tableSharedKeyCredential;

        /// <summary>
        /// Gets the The <see cref="TableSharedKeyCredential"/> used to authenticate and generate SAS.
        /// </summary>
        internal virtual TableSharedKeyCredential SharedKeyCredential => _tableSharedKeyCredential;

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
        /// The Uri for the table account.
        /// </summary>
        public virtual Uri Uri { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared access signature credential used to sign requests.
        /// See <see cref="GenerateSasUri(TableAccountSasPermissions,TableAccountSasResourceTypes,DateTimeOffset)"/> for creating a SAS token.</param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> does not start with 'https'.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="credential"/> is null.</exception>
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
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        public TableServiceClient(string connectionString)
            : this(connectionString, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" /> containing a shared access signature (SAS)
        /// token credential. See <see cref="GenerateSasUri(TableAccountSasPermissions,TableAccountSasResourceTypes,DateTimeOffset)"/> for creating a SAS token.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> does not start with 'https'.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> is null.</exception>
        public TableServiceClient(Uri endpoint, TableClientOptions options = null)
            : this(endpoint, default, default, options)
        {
            if (endpoint.Scheme != Uri.UriSchemeHttps && !Uri.IsLoopback)
            {
                throw new ArgumentException("Cannot use a SAS token without HTTPS.", nameof(endpoint));
            }
            if (string.IsNullOrEmpty(endpoint.Query))
            {
                throw new ArgumentException($"{nameof(endpoint)} must contain a SAS token query.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="credential">The shared access signature credential used to sign requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="endpoint"/> does not start with 'https'.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> is null.</exception>
        public TableServiceClient(Uri endpoint, AzureSasCredential credential, TableClientOptions options = null)
            : this(endpoint, default, credential, options)
        {
            if (endpoint.Scheme != Uri.UriSchemeHttps && !Uri.IsLoopback)
            {
                throw new ArgumentException($"Cannot use {nameof(AzureSasCredential)} without HTTPS.", nameof(endpoint));
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
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), default, null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _tableSharedKeyCredential = credential;
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
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential, TableClientOptions options)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), default, options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _tableSharedKeyCredential = credential;
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
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="connectionString"/> is invalid.</exception>
        public TableServiceClient(string connectionString, TableClientOptions options = null)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            TableConnectionString connString = TableConnectionString.Parse(connectionString);
            _accountName = connString._accountName;
            _endpoint = connString.TableStorageUri.PrimaryUri;
            options ??= TableClientOptions.DefaultOptions;
            var endpointString = connString.TableStorageUri.PrimaryUri.AbsoluteUri;
            _endpoint = new Uri(endpointString);
            Uri = _endpoint.Query switch
            {
                string s when !string.IsNullOrEmpty(s) => new(_endpoint.AbsoluteUri.Replace(_endpoint.Query, string.Empty)),
                _ => _endpoint
            };
            _tableUriBuilder = new TableUriBuilder(_endpoint);
            var secondaryEndpoint = connString.TableStorageUri.SecondaryUri?.AbsoluteUri;
            _isCosmosEndpoint = IsPremiumEndpoint(connString.TableStorageUri.PrimaryUri);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();

            TableSharedKeyPipelinePolicy policy = null;
            if (connString.Credentials is TableSharedKeyCredential credential)
            {
                policy = new TableSharedKeyPipelinePolicy(credential);
                // This is for SAS key generation.
                _tableSharedKeyCredential = credential;
            }
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { policy },
                ResponseClassifier = new ResponseClassifier(),
                RequestFailedDetailsParser = new TablesRequestFailedDetailsParser()
            };
            ((List<HttpPipelinePolicy>)pipelineOptions.PerCallPolicies).AddRange(perCallPolicies);
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);

            _version = options.VersionString;
            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, _pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, _pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, _pipeline, secondaryEndpoint, _version);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/> using the specified <see cref="Uri" />.
        /// </summary>
        /// <param name="endpoint">
        /// A <see cref="Uri"/> referencing the table service account.
        /// This is likely to be similar to "https://{account_name}.table.core.windows.net/" or "https://{account_name}.table.cosmos.azure.com/".
        /// </param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authorize requests.</param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline policies for authentication, retries, etc., that are applied to every request.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        public TableServiceClient(Uri endpoint, TokenCredential tokenCredential, TableClientOptions options = default)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            _tableUriBuilder = new TableUriBuilder(endpoint);
            _endpoint = endpoint;
            Uri = _endpoint.Query switch
            {
                string s when !string.IsNullOrEmpty(s) => new(_endpoint.AbsoluteUri.Replace(_endpoint.Query, string.Empty)),
                _ => _endpoint
            };
            options ??= TableClientOptions.DefaultOptions;
            _isCosmosEndpoint = IsPremiumEndpoint(_endpoint);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();
            var endpointString = _endpoint.AbsoluteUri;
            string secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(_endpoint)?.AbsoluteUri;
            var audienceScope = (options?.Audience ?? TableAudience.AzurePublicCloud)
                .GetDefaultScope(_isCosmosEndpoint);
            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { new TableBearerTokenChallengeAuthorizationPolicy(tokenCredential, audienceScope, options.EnableTenantDiscovery) },
                ResponseClassifier = new ResponseClassifier(),
                RequestFailedDetailsParser = new TablesRequestFailedDetailsParser()
            };
            ((List<HttpPipelinePolicy>)pipelineOptions.PerCallPolicies).AddRange(perCallPolicies);
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);

            _version = options.VersionString;
            _diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableRestClient(_diagnostics, _pipeline, endpointString, _version);
            _serviceOperations = new ServiceRestClient(_diagnostics, _pipeline, endpointString, _version);
            _secondaryServiceOperations = new ServiceRestClient(_diagnostics, _pipeline, secondaryEndpoint, _version);
        }

        internal TableServiceClient(Uri endpoint, TableSharedKeyPipelinePolicy policy, AzureSasCredential sasCredential, TableClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            _tableUriBuilder = new TableUriBuilder(endpoint);
            _endpoint = endpoint;
            Uri = _endpoint.Query switch
            {
                string s when !string.IsNullOrEmpty(s) => new(_endpoint.AbsoluteUri.Replace(_endpoint.Query, string.Empty)),
                _ => _endpoint
            };
            options ??= TableClientOptions.DefaultOptions;
            _isCosmosEndpoint = IsPremiumEndpoint(_endpoint);
            var perCallPolicies = _isCosmosEndpoint ? new[] { new CosmosPatchTransformPolicy() } : Array.Empty<HttpPipelinePolicy>();
            var endpointString = _endpoint.AbsoluteUri;
            string secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(_endpoint)?.AbsoluteUri;

            HttpPipelinePolicy authPolicy = policy switch
            {
                null when sasCredential != null || !string.IsNullOrWhiteSpace(_endpoint.Query) => new AzureSasCredentialSynchronousPolicy(sasCredential ?? new AzureSasCredential(_endpoint.Query)),
                _ => policy
            };

            var pipelineOptions = new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { authPolicy },
                ResponseClassifier = new ResponseClassifier(),
                RequestFailedDetailsParser = new TablesRequestFailedDetailsParser()
            };
            ((List<HttpPipelinePolicy>)pipelineOptions.PerCallPolicies).AddRange(perCallPolicies);
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);

            _version = options.VersionString;
            _diagnostics = new ClientDiagnostics(options);
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
        /// Gets a <see cref="TableAccountSasBuilder"/> instance scoped to the current account.
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
            return new TableAccountSasBuilder(permissions, resourceTypes, expiresOn);
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
            return new TableAccountSasBuilder(rawPermissions, resourceTypes, expiresOn);
        }

        /// <summary>
        /// Gets an instance of a <see cref="TableClient"/> configured with the current <see cref="TableServiceClient"/> options, affinitized to the specified <paramref name="tableName"/>.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual TableClient GetTableClient(string tableName)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));

            return new TableClient(tableName, _accountName, _tableOperations, _version, _diagnostics, _isCosmosEndpoint, _endpoint, _pipeline, _tableSharedKeyCredential);
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
                        return Page<TableItem>.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        ValidateServiceUriDoesNotContainTableName(ex);
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
                        return Page<TableItem>.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
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
                        return Page<TableItem>.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        ValidateServiceUriDoesNotContainTableName(ex);
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
                        return Page<TableItem>.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
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
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
                throw;
            }
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table. If the table already exists, then <see cref="Response.Status"/> is 409. The <see cref="Response"/> can be accessed via the GetRawResponse() method.</returns>
        public virtual Response<TableItem> CreateTableIfNotExists(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                context.AddClassifier((int)HttpStatusCode.Conflict, false);
                var response = _tableOperations.Create(
                    RequestContent.Create(new { TableName = tableName }),
                    TableConstants.Odata.MinimalMetadata,
                    TableConstants.ReturnNoContent,
                    context);

                if (response.IsError || response.Status == (int)HttpStatusCode.Conflict)
                {
                    RequestFailedException rfe = new(response);
                    if (rfe.Status != (int)HttpStatusCode.Conflict || rfe.ErrorCode == TableErrorCode.TableBeingDeleted)
                    {
                        throw rfe;
                    }
                }
                return Response.FromValue(new TableItem(tableName), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
                throw;
            }
        }

        /// <summary>
        /// Creates a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Response{TableItem}"/> containing properties of the table. If the table already exists, then <see cref="Response.Status"/> is 409. The <see cref="Response"/> can be accessed via the GetRawResponse() method.</returns>
        public virtual async Task<Response<TableItem>> CreateTableIfNotExistsAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(CreateTableIfNotExists)}");
            scope.Start();
            try
            {
                var context = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                context.AddClassifier((int)HttpStatusCode.Conflict, false);
                var response = await _tableOperations.CreateAsync(
                    RequestContent.Create(new { TableName = tableName }),
                    TableConstants.Odata.MinimalMetadata,
                    TableConstants.ReturnNoContent,
                    context).ConfigureAwait(false);

                if (response.IsError || response.Status == (int)HttpStatusCode.Conflict)
                {
                    RequestFailedException rfe = new(response);
                    if (rfe.Status != (int)HttpStatusCode.Conflict || rfe.ErrorCode == TableErrorCode.TableBeingDeleted)
                    {
                        throw rfe;
                    }
                }
                return Response.FromValue(new TableItem(tableName), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
                throw;
            }
        }

        /// <summary>
        /// Deletes a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response DeleteTable(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return _tableOperations.Delete(tableName, CreateContextForDelete(cancellationToken));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
                throw;
            }
        }

        /// <summary>
        /// Deletes a table on the service.
        /// </summary>
        /// <param name="tableName">The name of the table to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> DeleteTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tableName, nameof(tableName));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableServiceClient)}.{nameof(DeleteTable)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteAsync(tableName, CreateContextForDelete(cancellationToken)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                ValidateServiceUriDoesNotContainTableName(ex, tableName);
                throw;
            }
        }

        /// <summary> Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="properties"> The Table Service properties. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
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
                ValidateServiceUriDoesNotContainTableName(ex);
                throw;
            }
        }

        /// <summary> Sets properties for an account's Table service endpoint, including properties for Analytics and CORS (Cross-Origin Resource Sharing) rules. </summary>
        /// <param name="properties"> The Table Service properties. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
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
                ValidateServiceUriDoesNotContainTableName(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="GenerateSasUri(TableAccountSasPermissions, TableAccountSasResourceTypes, DateTimeOffset)"/>
        /// returns a <see cref="Uri"/> that generates a Table Service
        /// Shared Access Signature (SAS) Uri based on the Client properties
        /// and parameters passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>.
        /// </summary>
        /// <param name="permissions"> Specifies the list of permissions to be associated with the SAS.
        /// See <see cref="TableSasPermissions"/>.
        /// </param>
        /// <param name="resourceTypes"> Specifies the resource types that will can be accessed with the SAS.</param>
        /// <param name="expiresOn">
        /// Required. Specifies the time at which the SAS becomes invalid. This field
        /// must be omitted if it has been specified in an associated stored access policy.
        /// </param>
        /// <returns> A <see cref="TableAccountSasBuilder"/> on successfully deleting. </returns>
        /// <remarks> An <see cref="Exception"/> will be thrown if a failure occurs. </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
        public virtual Uri GenerateSasUri(TableAccountSasPermissions permissions, TableAccountSasResourceTypes resourceTypes, DateTimeOffset expiresOn)
            => GenerateSasUri(new TableAccountSasBuilder(permissions, resourceTypes, expiresOn));

        /// <summary>
        /// The <see cref="GenerateSasUri(TableAccountSasBuilder)"/> returns a
        /// <see cref="Uri"/> that generates a Table Service SAS Uri based
        /// on the Client properties and builder passed.
        ///
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas">
        /// Constructing a Service SAS</see>
        /// </summary>
        /// <param name="builder"> Used to generate a Shared Access Signature (SAS). </param>
        /// <returns> A <see cref="TableAccountSasBuilder"/> on successfully deleting. </returns>
        /// <remarks> An <see cref="Exception"/> will be thrown if a failure occurs. </remarks>
        [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/data-tables")]
        public virtual Uri GenerateSasUri(
            TableAccountSasBuilder builder)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            if (SharedKeyCredential == null)
            {
                throw new InvalidOperationException($"{nameof(GenerateSasUri)} requires that this client be constructed with a credential type other than {nameof(TokenCredential)} in order to sign the SAS token.");
            }

            TableUriBuilder sasUri = new(_endpoint);
            sasUri.Query = builder.ToSasQueryParameters(SharedKeyCredential).ToString();
            return sasUri.ToUri();
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

        internal static RequestContext CreateContextForDelete(CancellationToken cancellationToken)
        {
            var context = new RequestContext() { CancellationToken = cancellationToken };
            context.AddClassifier((int)HttpStatusCode.NotFound, false);
            return context;
        }

        private void ValidateServiceUriDoesNotContainTableName(Exception ex, string tableName = null)
        {
            tableName ??= _tableUriBuilder.Tablename;
            var fixedUri = TableUriBuilder.GetEndpointWithoutTableName(_endpoint, tableName);
            if (_endpoint.AbsolutePath != fixedUri.AbsolutePath)
            {
                var message =
                    $"The configured endpoint Uri appears to contain the table name '{tableName}'. Please try re-creating the TableServiceClient with just the account Uri. For example: {fixedUri.AbsoluteUri}.";
                if (ex is RequestFailedException rfe)
                {
                    throw new RequestFailedException(rfe.Status, message, rfe.ErrorCode, rfe);
                }
            }
        }
    }
}
