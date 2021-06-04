﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// The client to use to connect to the Metrics Advisor Cognitive Service to handle administrative
    /// operations, configuring the behavior of the service. It provides the ability to create and manage
    /// data feeds, anomaly detection configurations, anomaly alerting configurations and hooks.
    /// </summary>
    public class MetricsAdvisorAdministrationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient _serviceRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorAdministrationClient(Uri endpoint, MetricsAdvisorKeyCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorAdministrationClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientsOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientsOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));

            _serviceRestClient = new MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential, MetricsAdvisorClientsOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientsOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));

            _serviceRestClient = new MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class. This constructor
        /// is intended to be used for mocking only.
        /// </summary>
        protected MetricsAdvisorAdministrationClient()
        {
        }

        #region DataFeed

        /// <summary>
        /// Gets an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<DataFeed>> GetDataFeedAsync(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
            scope.Start();

            try
            {
                Response<DataFeedDetail> response = await _serviceRestClient.GetDataFeedByIdAsync(dataFeedGuid, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DataFeed(response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual Response<DataFeed> GetDataFeed(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
            scope.Start();

            try
            {
                Response<DataFeedDetail> response = _serviceRestClient.GetDataFeedById(dataFeedGuid, cancellationToken);
                return Response.FromValue(new DataFeed(response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="DataFeed"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataFeed"/>s.</returns>
        public virtual AsyncPageable<DataFeed> GetDataFeedsAsync(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            string name = options?.GetDataFeedsFilter?.Name;
            DataFeedSourceType? sourceType = options?.GetDataFeedsFilter?.SourceType;
            DataFeedGranularityType? granularityType = options?.GetDataFeedsFilter?.GranularityType;
            DataFeedStatus? status = options?.GetDataFeedsFilter?.Status;
            string creator = options?.GetDataFeedsFilter?.Creator;
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<DataFeed>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = await _serviceRestClient.ListDataFeedsAsync(name, sourceType, granularityType, status, creator, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(ConvertToDataFeeds(response.Value.Value), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataFeed>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = await _serviceRestClient.ListDataFeedsNextPageAsync(nextLink, name, sourceType, granularityType, status, creator, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(ConvertToDataFeeds(response.Value.Value), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="DataFeed"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataFeed"/>s.</returns>
        public virtual Pageable<DataFeed> GetDataFeeds(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            string name = options?.GetDataFeedsFilter?.Name;
            DataFeedSourceType? sourceType = options?.GetDataFeedsFilter?.SourceType;
            DataFeedGranularityType? granularityType = options?.GetDataFeedsFilter?.GranularityType;
            DataFeedStatus? status = options?.GetDataFeedsFilter?.Status;
            string creator = options?.GetDataFeedsFilter?.Creator;
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<DataFeed> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = _serviceRestClient.ListDataFeeds(name, sourceType, granularityType, status, creator, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(ConvertToDataFeeds(response.Value.Value), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataFeed> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = _serviceRestClient.ListDataFeedsNextPage(nextLink, name, sourceType, granularityType, status, creator, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(ConvertToDataFeeds(response.Value.Value), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Creates a <see cref="DataFeed"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="dataFeed">Specifies how the created <see cref="DataFeed"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing information about the created data feed.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/>, <paramref name="dataFeed"/>.Name, <paramref name="dataFeed"/>.DataSource, <paramref name="dataFeed"/>.Granularity, <paramref name="dataFeed"/>.Schema, <paramref name="dataFeed"/>.IngestionSettings, or <paramref name="dataFeed"/>.IngestionSettings.IngestionStartTime is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeed"/>.Name is empty.</exception>
        public virtual async Task<Response<DataFeed>> CreateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateDataFeedHeaders> response = await _serviceRestClient.CreateDataFeedAsync(dataFeedDetail, cancellationToken).ConfigureAwait(false);

                string dataFeedId = ClientCommon.GetDataFeedId(response.Headers.Location);

                try
                {
                    var createdDataFeed = await GetDataFeedAsync(dataFeedId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdDataFeed, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="DataFeed"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="dataFeed">Specifies how the created <see cref="DataFeed"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing information about the created data feed.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/>, <paramref name="dataFeed"/>.Name, <paramref name="dataFeed"/>.DataSource, <paramref name="dataFeed"/>.Granularity, <paramref name="dataFeed"/>.Schema, <paramref name="dataFeed"/>.IngestionSettings, or <paramref name="dataFeed"/>.IngestionSettings.IngestionStartTime is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeed"/>.Name is empty.</exception>
        public virtual Response<DataFeed> CreateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateDataFeedHeaders> response = _serviceRestClient.CreateDataFeed(dataFeedDetail, cancellationToken);

                string dataFeedId = ClientCommon.GetDataFeedId(response.Headers.Location);

                try
                {
                    var createdDataFeed = GetDataFeed(dataFeedId, cancellationToken);

                    return Response.FromValue(createdDataFeed, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DataFeed"/>. In order to update your data feed, you cannot create a <see cref="DataFeed"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDataFeedAsync"/> or another CRUD operation and update it
        /// before calling this method.
        /// </summary>
        /// <param name="dataFeed">The <see cref="DataFeed"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/> or <paramref name="dataFeed"/>.Id is null.</exception>
        public virtual async Task<Response<DataFeed>> UpdateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));

            if (dataFeed.Id == null)
            {
                throw new ArgumentNullException(nameof(dataFeed), $"{nameof(dataFeed)}.Id not available. Call {nameof(GetDataFeedAsync)} and update the returned model before calling this method.");
            }

            Guid dataFeedGuid = new Guid(dataFeed.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
                Response<DataFeedDetail> response = await _serviceRestClient.UpdateDataFeedAsync(dataFeedGuid, patchModel, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DataFeed(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DataFeed"/>. In order to update your data feed, you cannot create a <see cref="DataFeed"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDataFeedAsync"/> or another CRUD operation and update it
        /// before calling this method.
        /// </summary>
        /// <param name="dataFeed">The <see cref="DataFeed"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/> or <paramref name="dataFeed"/>.Id is null.</exception>
        public virtual Response<DataFeed> UpdateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));

            if (dataFeed.Id == null)
            {
                throw new ArgumentNullException(nameof(dataFeed), $"{nameof(dataFeed)}.Id not available. Call {nameof(GetDataFeed)} and update the returned model before calling this method.");
            }

            Guid dataFeedGuid = new Guid(dataFeed.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
                Response<DataFeedDetail> response = _serviceRestClient.UpdateDataFeed(dataFeedGuid, patchModel, cancellationToken);
                return Response.FromValue(new DataFeed(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteDataFeedAsync(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDataFeed)}");
            scope.Start();
            try
            {
                return await _serviceRestClient.DeleteDataFeedAsync(dataFeedGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteDataFeed(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDataFeed)}");
            scope.Start();
            try
            {
                return _serviceRestClient.DeleteDataFeed(dataFeedGuid, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the ingestion progress for data being ingested to a given data feed.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeedIngestionProgress"/> instance.
        /// </returns>
        public virtual async Task<Response<DataFeedIngestionProgress>> GetDataFeedIngestionProgressAsync(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionProgress)}");
            scope.Start();
            try
            {
                return await _serviceRestClient.GetIngestionProgressAsync(dataFeedGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the ingestion progress for data being ingested to a given data feed.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeedIngestionProgress"/> instance.
        /// </returns>
        public virtual Response<DataFeedIngestionProgress> GetDataFeedIngestionProgress(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionProgress)}");
            scope.Start();
            try
            {
                return _serviceRestClient.GetIngestionProgress(dataFeedGuid, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resets the data ingestion status for a given data feed to back-fill data. This can be useful to fix a failed ingestion or override the existing data.
        /// Anomaly detection is re-triggered on selected range only.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="startTime">The inclusive data back-fill time range.</param>
        /// <param name="endTime">The exclusive data back-fill time range.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        public virtual async Task<Response> RefreshDataFeedIngestionAsync(string dataFeedId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(RefreshDataFeedIngestion)}");
            scope.Start();
            try
            {
                IngestionProgressResetOptions options = new IngestionProgressResetOptions(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime));

                return await _serviceRestClient.ResetDataFeedIngestionStatusAsync(dataFeedGuid, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resets the data ingestion status for a given data feed to back-fill data. This can be useful to fix a failed ingestion or override the existing data.
        /// Anomaly detection is re-triggered on selected range only.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="startTime">The inclusive data back-fill time range.</param>
        /// <param name="endTime">The exclusive data back-fill time range.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        public virtual Response RefreshDataFeedIngestion(string dataFeedId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(RefreshDataFeedIngestion)}");
            scope.Start();
            try
            {
                IngestionProgressResetOptions options = new IngestionProgressResetOptions(ClientCommon.NormalizeDateTimeOffset(startTime), ClientCommon.NormalizeDateTimeOffset(endTime));

                return _serviceRestClient.ResetDataFeedIngestionStatus(dataFeedGuid, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the ingestion status for data being ingested to a given data feed.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DataFeedIngestionStatus"/>.</returns>
        public virtual AsyncPageable<DataFeedIngestionStatus> GetDataFeedIngestionStatusesAsync(string dataFeedId, GetDataFeedIngestionStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(options, nameof(options));

            IngestionStatusQueryOptions queryOptions = new IngestionStatusQueryOptions(options.StartTime, options.EndTime);
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            async Task<Page<DataFeedIngestionStatus>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = await _serviceRestClient.GetDataFeedIngestionStatusAsync(dataFeedGuid, queryOptions, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DataFeedIngestionStatus>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = await _serviceRestClient.GetDataFeedIngestionStatusNextAsync(nextLink, queryOptions, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the ingestion status for data being ingested to a given data feed.
        /// </summary>
        /// <param name="dataFeedId">The unique identifier of the <see cref="DataFeed"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="Pageable{T}"/> containing the collection of <see cref="DataFeedIngestionStatus"/>.</returns>
        public virtual Pageable<DataFeedIngestionStatus> GetDataFeedIngestionStatuses(string dataFeedId, GetDataFeedIngestionStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(options, nameof(options));

            IngestionStatusQueryOptions queryOptions = new IngestionStatusQueryOptions(options.StartTime, options.EndTime);
            int? skip = options.Skip;
            int? maxPageSize = options.MaxPageSize;

            Page<DataFeedIngestionStatus> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = _serviceRestClient.GetDataFeedIngestionStatus(dataFeedGuid, queryOptions, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DataFeedIngestionStatus> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = _serviceRestClient.GetDataFeedIngestionStatusNext(nextLink, queryOptions, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        private static IReadOnlyList<DataFeed> ConvertToDataFeeds(IReadOnlyList<DataFeedDetail> dataFeedDetails)
        {
            List<DataFeed> dataFeeds = new List<DataFeed>();

            foreach (DataFeedDetail dataFeedDetail in dataFeedDetails)
            {
                dataFeeds.Add(new DataFeed(dataFeedDetail));
            }

            return dataFeeds;
        }

        private static void ValidateDataFeedToCreate(DataFeed dataFeed, string paramName)
        {
            Argument.AssertNotNull(dataFeed, paramName);
            Argument.AssertNotNullOrEmpty(dataFeed.Name, $"{paramName}.{nameof(dataFeed.Name)}");
            Argument.AssertNotNull(dataFeed.DataSource, $"{paramName}.{nameof(dataFeed.DataSource)}");
            Argument.AssertNotNull(dataFeed.Granularity, $"{paramName}.{nameof(dataFeed.Granularity)}");
            Argument.AssertNotNull(dataFeed.Schema, $"{paramName}.{nameof(dataFeed.Schema)}");
            Argument.AssertNotNull(dataFeed.IngestionSettings, $"{paramName}.{nameof(dataFeed.IngestionSettings)}");
            Argument.AssertNotNull(dataFeed.IngestionSettings.IngestionStartTime, $"{paramName}.{nameof(dataFeed.IngestionSettings)}.{nameof(dataFeed.IngestionSettings.IngestionStartTime)}");
        }

        #endregion DataFeed

        #region AnomalyDetectionConfiguration

        /// <summary>
        /// Creates an <see cref="AnomalyDetectionConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="detectionConfiguration">Specifies how the created <see cref="AnomalyDetectionConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing information about the created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/>, <paramref name="detectionConfiguration"/>.MetricId, <paramref name="detectionConfiguration"/>.Name, or <paramref name="detectionConfiguration"/>.WholeSeriesDetectionConditions is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfiguration"/>.MetricId or <paramref name="detectionConfiguration"/>.Name is empty.</exception>
        public virtual async Task<Response<AnomalyDetectionConfiguration>> CreateDetectionConfigurationAsync(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            ValidateDetectionConfigurationToCreate(detectionConfiguration, nameof(detectionConfiguration));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDetectionConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyDetectionConfigurationHeaders> response = await _serviceRestClient.CreateAnomalyDetectionConfigurationAsync(detectionConfiguration, cancellationToken).ConfigureAwait(false);
                string detectionConfigurationId = ClientCommon.GetAnomalyDetectionConfigurationId(response.Headers.Location);

                try
                {
                    var createdConfig = await GetDetectionConfigurationAsync(detectionConfigurationId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdConfig, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The configuration has been created successfully, but the client failed to fetch its data. Configuration ID: {detectionConfigurationId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an <see cref="AnomalyDetectionConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="detectionConfiguration">Specifies how the created <see cref="AnomalyDetectionConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing information about the created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/>, <paramref name="detectionConfiguration"/>.MetricId, <paramref name="detectionConfiguration"/>.Name, or <paramref name="detectionConfiguration"/>.WholeSeriesDetectionConditions is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfiguration"/>.MetricId or <paramref name="detectionConfiguration"/>.Name is empty.</exception>
        public virtual Response<AnomalyDetectionConfiguration> CreateDetectionConfiguration(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            ValidateDetectionConfigurationToCreate(detectionConfiguration, nameof(detectionConfiguration));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDetectionConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyDetectionConfigurationHeaders> response = _serviceRestClient.CreateAnomalyDetectionConfiguration(detectionConfiguration, cancellationToken);
                string detectionConfigurationId = ClientCommon.GetAnomalyDetectionConfigurationId(response.Headers.Location);

                try
                {
                    var createdConfig = GetDetectionConfiguration(detectionConfigurationId, cancellationToken);

                    return Response.FromValue(createdConfig, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The configuration has been created successfully, but the client failed to fetch its data. Configuration ID: {detectionConfigurationId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="AnomalyDetectionConfiguration"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<AnomalyDetectionConfiguration>> GetDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfiguration)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.GetAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="AnomalyDetectionConfiguration"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response<AnomalyDetectionConfiguration> GetDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfiguration)}");
            scope.Start();

            try
            {
                return _serviceRestClient.GetAnomalyDetectionConfiguration(detectionConfigurationGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AnomalyDetectionConfiguration"/>. In order to update your configuration, you cannot create an <see cref="AnomalyDetectionConfiguration"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDetectionConfigurationAsync"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="detectionConfiguration">The <see cref="AnomalyDetectionConfiguration"/> instance containing the desired updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing information about the updated configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/> or <paramref name="detectionConfiguration"/>.Id is null.</exception>
        public virtual async Task<Response<AnomalyDetectionConfiguration>> UpdateDetectionConfigurationAsync(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));

            if (detectionConfiguration.Id == null)
            {
                throw new ArgumentNullException(nameof(detectionConfiguration), $"{nameof(detectionConfiguration)}.Id not available. Call {nameof(GetDetectionConfigurationAsync)} and update the returned model before calling this method.");
            }

            Guid detectionConfigurationGuid = new Guid(detectionConfiguration.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDetectionConfiguration)}");
            scope.Start();

            try
            {
                AnomalyDetectionConfigurationPatch patch = detectionConfiguration.GetPatchModel();
                return await _serviceRestClient.UpdateAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, patch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AnomalyDetectionConfiguration"/>. In order to update your configuration, you cannot create an <see cref="AnomalyDetectionConfiguration"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDetectionConfiguration"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="detectionConfiguration">The <see cref="AnomalyDetectionConfiguration"/> instance containing the desired updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/>
        /// instance containing information about the updated configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/> or <paramref name="detectionConfiguration"/>.Id is null.</exception>
        public virtual Response<AnomalyDetectionConfiguration> UpdateDetectionConfiguration(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));

            if (detectionConfiguration.Id == null)
            {
                throw new ArgumentNullException(nameof(detectionConfiguration), $"{nameof(detectionConfiguration)}.Id not available. Call {nameof(GetDetectionConfiguration)} and update the returned model before calling this method.");
            }

            Guid detectionConfigurationGuid = new Guid(detectionConfiguration.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDetectionConfiguration)}");
            scope.Start();

            try
            {
                AnomalyDetectionConfigurationPatch patch = detectionConfiguration.GetPatchModel();
                return _serviceRestClient.UpdateAnomalyDetectionConfiguration(detectionConfigurationGuid, patch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="AnomalyDetectionConfiguration"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="metricId">Filters the result. The unique identifier of the metric to which the returned <see cref="AnomalyDetectionConfiguration"/>s apply.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AnomalyDetectionConfiguration"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<AnomalyDetectionConfiguration> GetDetectionConfigurationsAsync(string metricId, GetDetectionConfigurationsOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<AnomalyDetectionConfiguration>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyDetectionConfigurationList> response = await _serviceRestClient.GetAnomalyDetectionConfigurationsByMetricAsync(metricGuid, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AnomalyDetectionConfiguration>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyDetectionConfigurationList> response = await _serviceRestClient.GetAnomalyDetectionConfigurationsByMetricNextPageAsync(nextLink, metricGuid, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="AnomalyDetectionConfiguration"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="metricId">Filters the result. The unique identifier of the metric to which the returned <see cref="AnomalyDetectionConfiguration"/>s apply.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="AnomalyDetectionConfiguration"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<AnomalyDetectionConfiguration> GetDetectionConfigurations(string metricId, GetDetectionConfigurationsOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<AnomalyDetectionConfiguration> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyDetectionConfigurationList> response = _serviceRestClient.GetAnomalyDetectionConfigurationsByMetric(metricGuid, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AnomalyDetectionConfiguration> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDetectionConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyDetectionConfigurationList> response = _serviceRestClient.GetAnomalyDetectionConfigurationsByMetricNextPage(nextLink, metricGuid, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Deletes an existing <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDetectionConfiguration)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.DeleteAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <param name="detectionConfigurationId">The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDetectionConfiguration)}");
            scope.Start();

            try
            {
                return _serviceRestClient.DeleteAnomalyDetectionConfiguration(detectionConfigurationGuid, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static void ValidateDetectionConfigurationToCreate(AnomalyDetectionConfiguration configuration, string paramName)
        {
            Argument.AssertNotNull(configuration, paramName);
            Argument.AssertNotNullOrEmpty(configuration.MetricId, $"{paramName}.{nameof(AnomalyDetectionConfiguration.MetricId)}");
            Argument.AssertNotNullOrEmpty(configuration.Name, $"{paramName}.{nameof(AnomalyDetectionConfiguration.Name)}");
            Argument.AssertNotNull(configuration.WholeSeriesDetectionConditions, $"{paramName}.{nameof(AnomalyDetectionConfiguration.WholeSeriesDetectionConditions)}");
        }

        #endregion AnomalyDetectionConfiguration

        #region AnomalyAlertConfiguration

        /// <summary>
        /// Creates an <see cref="AnomalyAlertConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="alertConfiguration">Specifies how the created <see cref="AnomalyAlertConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing information about the created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.Name is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfiguration"/>.Name is empty.</exception>
        public virtual async Task<Response<AnomalyAlertConfiguration>> CreateAlertConfigurationAsync(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            Argument.AssertNotNullOrEmpty(alertConfiguration.Name, $"{nameof(alertConfiguration)}.{nameof(alertConfiguration.Name)}");

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateAlertConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyAlertingConfigurationHeaders> response = await _serviceRestClient.CreateAnomalyAlertingConfigurationAsync(alertConfiguration, cancellationToken).ConfigureAwait(false);
                string alertConfigurationId = ClientCommon.GetAnomalyAlertConfigurationId(response.Headers.Location);

                try
                {
                    var createdConfig = await GetAlertConfigurationAsync(alertConfigurationId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdConfig, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The configuration has been created successfully, but the client failed to fetch its data. Configuration ID: {alertConfigurationId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an <see cref="AnomalyAlertConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="alertConfiguration">Specifies how the created <see cref="AnomalyAlertConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing information about the created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.Name is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfiguration"/>.Name is empty.</exception>
        public virtual Response<AnomalyAlertConfiguration> CreateAlertConfiguration(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            Argument.AssertNotNullOrEmpty(alertConfiguration.Name, $"{nameof(alertConfiguration)}.{nameof(alertConfiguration.Name)}");

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateAlertConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyAlertingConfigurationHeaders> response = _serviceRestClient.CreateAnomalyAlertingConfiguration(alertConfiguration, cancellationToken);
                string alertConfigurationId = ClientCommon.GetAnomalyAlertConfigurationId(response.Headers.Location);

                try
                {
                    var createdConfig = GetAlertConfiguration(alertConfigurationId, cancellationToken);

                    return Response.FromValue(createdConfig, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The configuration has been created successfully, but the client failed to fetch its data. Configuration ID: {alertConfigurationId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AnomalyAlertConfiguration"/>. In order to update your configuration, you cannot create an <see cref="AnomalyAlertConfiguration"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetAlertConfigurationAsync"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="alertConfiguration">The <see cref="AnomalyAlertConfiguration"/> containing the updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing information about the updated configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.Id is null.</exception>
        public virtual async Task<Response<AnomalyAlertConfiguration>> UpdateAlertConfigurationAsync(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));

            if (alertConfiguration.Id == null)
            {
                throw new ArgumentNullException(nameof(alertConfiguration), $"{nameof(alertConfiguration)}.Id not available. Call {nameof(GetAlertConfigurationAsync)} and update the returned model before calling this method.");
            }

            Guid alertConfigurationGuid = new Guid(alertConfiguration.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateAlertConfiguration)}");
            scope.Start();

            try
            {
                AnomalyAlertingConfigurationPatch patch = alertConfiguration.GetPatchModel();
                return await _serviceRestClient.UpdateAnomalyAlertingConfigurationAsync(alertConfigurationGuid, patch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AnomalyAlertConfiguration"/>. In order to update your configuration, you cannot create an <see cref="AnomalyAlertConfiguration"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetAlertConfiguration"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="alertConfiguration">The <see cref="AnomalyAlertConfiguration"/> containing the updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing information about the updated configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.Id is null.</exception>
        public virtual Response<AnomalyAlertConfiguration> UpdateAlertConfiguration(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));

            if (alertConfiguration.Id == null)
            {
                throw new ArgumentNullException(nameof(alertConfiguration), $"{nameof(alertConfiguration)}.Id not available. Call {nameof(GetAlertConfiguration)} and update the returned model before calling this method.");
            }

            Guid alertConfigurationGuid = new Guid(alertConfiguration.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateAlertConfiguration)}");
            scope.Start();

            try
            {
                AnomalyAlertingConfigurationPatch patch = alertConfiguration.GetPatchModel();
                return _serviceRestClient.UpdateAnomalyAlertingConfiguration(alertConfigurationGuid, patch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<AnomalyAlertConfiguration>> GetAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfiguration)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.GetAnomalyAlertingConfigurationAsync(alertConfigurationGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response<AnomalyAlertConfiguration> GetAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfiguration)}");
            scope.Start();

            try
            {
                return _serviceRestClient.GetAnomalyAlertingConfiguration(alertConfigurationGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="AnomalyAlertConfiguration"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="detectionConfigurationId">Filters the result. The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> to which the returned <see cref="AnomalyAlertConfiguration"/>s apply.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AnomalyAlertConfiguration"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual AsyncPageable<AnomalyAlertConfiguration> GetAlertConfigurationsAsync(string detectionConfigurationId, GetAlertConfigurationsOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<AnomalyAlertConfiguration>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyAlertingConfigurationList> response = await _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AnomalyAlertConfiguration>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyAlertingConfigurationList> response = await _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfigurationNextPageAsync(nextLink, detectionConfigurationGuid, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="AnomalyAlertConfiguration"/>s in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="detectionConfigurationId">Filters the result. The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> to which the returned <see cref="AnomalyAlertConfiguration"/>s apply.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AnomalyAlertConfiguration"/>s.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Pageable<AnomalyAlertConfiguration> GetAlertConfigurations(string detectionConfigurationId, GetAlertConfigurationsOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<AnomalyAlertConfiguration> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyAlertingConfigurationList> response = _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfiguration(detectionConfigurationGuid, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AnomalyAlertConfiguration> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAlertConfigurations)}");
                scope.Start();

                try
                {
                    Response<AnomalyAlertingConfigurationList> response = _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfigurationNextPage(nextLink, detectionConfigurationGuid, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Deletes an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteAlertConfiguration)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.DeleteAnomalyAlertingConfigurationAsync(alertConfigurationGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteAlertConfiguration)}");
            scope.Start();

            try
            {
                return _serviceRestClient.DeleteAnomalyAlertingConfiguration(alertConfigurationGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion AnomalyAlertConfiguration

        #region NotificationHook

        /// <summary>
        /// Creates a <see cref="NotificationHook"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="hook">Specifies how the created <see cref="NotificationHook"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="NotificationHook"/>
        /// instance containing information about the created hook.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> is null; or <paramref name="hook"/> is an <see cref="EmailNotificationHook"/> and <paramref name="hook"/>.EmailsToAlert is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hook"/> is an <see cref="EmailNotificationHook"/> and <paramref name="hook"/>.EmailsToAlert is empty.</exception>
        public virtual async Task<Response<NotificationHook>> CreateHookAsync(NotificationHook hook, CancellationToken cancellationToken = default)
        {
            ValidateHookToCreate(hook, nameof(hook));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateHook)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateHookHeaders> response = await _serviceRestClient.CreateHookAsync(hook, cancellationToken).ConfigureAwait(false);
                string hookId = ClientCommon.GetHookId(response.Headers.Location);

                try
                {
                    var createdHook = await GetHookAsync(hookId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdHook, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The hook has been created successfully, but the client failed to fetch its data. Hook ID: {hookId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="NotificationHook"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="hook">Specifies how the created <see cref="NotificationHook"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="NotificationHook"/>
        /// instance containing information about the created hook.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> is null; or <paramref name="hook"/> is an <see cref="EmailNotificationHook"/> and <paramref name="hook"/>.EmailsToAlert is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hook"/> is an <see cref="EmailNotificationHook"/> and <paramref name="hook"/>.EmailsToAlert is empty.</exception>
        public virtual Response<NotificationHook> CreateHook(NotificationHook hook, CancellationToken cancellationToken = default)
        {
            ValidateHookToCreate(hook, nameof(hook));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateHook)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateHookHeaders> response = _serviceRestClient.CreateHook(hook, cancellationToken);
                string hookId = ClientCommon.GetHookId(response.Headers.Location);

                try
                {
                    var createdHook = GetHook(hookId, cancellationToken);

                    return Response.FromValue(createdHook, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The hook has been created successfully, but the client failed to fetch its data. Hook ID: {hookId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="NotificationHook"/>. In order to update your hook, you cannot create a <see cref="NotificationHook"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetHookAsync"/> or another CRUD operation and update it
        /// before calling this method.
        /// </summary>
        /// <param name="hook">The <see cref="NotificationHook"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> or <paramref name="hook"/>.Id is null.</exception>
        public virtual async Task<Response<NotificationHook>> UpdateHookAsync(NotificationHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook.Id == null)
            {
                throw new ArgumentNullException(nameof(hook), $"{nameof(hook)}.Id not available. Call {nameof(GetHookAsync)} and update the returned model before calling this method.");
            }

            Guid hookGuid = new Guid(hook.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateHook)}");
            scope.Start();

            try
            {
                HookInfoPatch patch = NotificationHook.GetPatchModel(hook);

                return await _serviceRestClient.UpdateHookAsync(hookGuid, patch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="NotificationHook"/>. In order to update your hook, you cannot create a <see cref="NotificationHook"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetHook"/> or another CRUD operation and update it
        /// before calling this method.
        /// </summary>
        /// <param name="hook">The <see cref="NotificationHook"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> or <paramref name="hook"/>.Id is null.</exception>
        public virtual Response<NotificationHook> UpdateHook(NotificationHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook.Id == null)
            {
                throw new ArgumentNullException(nameof(hook), $"{nameof(hook)}.Id not available. Call {nameof(GetHook)} and update the returned model before calling this method.");
            }

            Guid hookGuid = new Guid(hook.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateHook)}");
            scope.Start();

            try
            {
                HookInfoPatch patch = NotificationHook.GetPatchModel(hook);

                return _serviceRestClient.UpdateHook(hookGuid, patch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="NotificationHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="NotificationHook"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="NotificationHook"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<NotificationHook>> GetHookAsync(string hookId, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHook)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.GetHookAsync(hookGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="NotificationHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="NotificationHook"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="NotificationHook"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual Response<NotificationHook> GetHook(string hookId, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHook)}");
            scope.Start();

            try
            {
                return _serviceRestClient.GetHook(hookGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="NotificationHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="NotificationHook"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteHookAsync(string hookId, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteHook)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.DeleteHookAsync(hookGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="NotificationHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="NotificationHook"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteHook(string hookId, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteHook)}");
            scope.Start();

            try
            {
                return _serviceRestClient.DeleteHook(hookGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="NotificationHook"/>s in this resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="NotificationHook"/>s.</returns>
        public virtual AsyncPageable<NotificationHook> GetHooksAsync(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<NotificationHook>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = await _serviceRestClient.ListHooksAsync(options?.HookNameFilter, options?.Skip, options?.MaxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<NotificationHook>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = await _serviceRestClient.ListHooksNextPageAsync(nextLink, options?.HookNameFilter, options?.Skip, options?.MaxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="NotificationHook"/>s in this resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="NotificationHook"/>s.</returns>
        public virtual Pageable<NotificationHook> GetHooks(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            Page<NotificationHook> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = _serviceRestClient.ListHooks(options?.HookNameFilter, options?.Skip, options?.MaxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<NotificationHook> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = _serviceRestClient.ListHooksNextPage(nextLink, options?.HookNameFilter, options?.Skip, options?.MaxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        private static void ValidateHookToCreate(NotificationHook hook, string paramName)
        {
            Argument.AssertNotNull(hook, paramName);
            Argument.AssertNotNullOrEmpty(hook.Name, $"{paramName}.{nameof(hook.Name)}");

            if (hook is EmailNotificationHook emailHook)
            {
                Argument.AssertNotNullOrEmpty(emailHook.EmailsToAlert, $"{paramName}.{nameof(EmailNotificationHook.EmailsToAlert)}");
            }
            else if (hook is WebNotificationHook webHook)
            {
                Argument.AssertNotNull(webHook.Endpoint, $"{paramName}.{nameof(WebNotificationHook.Endpoint)}");
            }
            else
            {
                throw new ArgumentException($"Invalid hook type. A hook must be created from an ${nameof(EmailNotificationHook)} or a {nameof(WebNotificationHook)} instance.");
            }
        }

        #endregion NotificationHook

        #region Credential

        /// <summary>
        /// Creates a <see cref="DatasourceCredential"/> and assigns it a unique ID. This API provides different ways of
        /// authenticating to a <see cref="DataFeedSource"/> for data ingestion when the default authentication method does not suffice.
        /// Please see <see cref="DatasourceCredential"/> for a list of supported credentials.
        /// </summary>
        /// <param name="datasourceCredential">Specifies how the created <see cref="DatasourceCredential"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing information about the created datasource credential.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredential"/> is null.</exception>
        public virtual async Task<Response<DatasourceCredential>> CreateDatasourceCredentialAsync(DatasourceCredential datasourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(datasourceCredential, nameof(datasourceCredential));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDatasourceCredential)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateCredentialHeaders> response = await _serviceRestClient.CreateCredentialAsync(datasourceCredential, cancellationToken).ConfigureAwait(false);
                string credentialId = ClientCommon.GetCredentialId(response.Headers.Location);

                try
                {
                    var createdCredential = await GetDatasourceCredentialAsync(credentialId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdCredential, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The datasource credential has been created successfully, but the client failed to fetch its data. Datasource Credential ID: {credentialId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="DatasourceCredential"/> and assigns it a unique ID. This API provides different ways of
        /// authenticating to a <see cref="DataFeedSource"/> for data ingestion when the default authentication method does not suffice.
        /// Please see <see cref="DatasourceCredential"/> for a list of supported credentials.
        /// </summary>
        /// <param name="datasourceCredential">Specifies how the created <see cref="DatasourceCredential"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing information about the created datasource credential.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredential"/> is null.</exception>
        public virtual Response<DatasourceCredential> CreateDatasourceCredential(DatasourceCredential datasourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(datasourceCredential, nameof(datasourceCredential));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDatasourceCredential)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<MicrosoftAzureMetricsAdvisorRestAPIOpenAPIV2CreateCredentialHeaders> response = _serviceRestClient.CreateCredential(datasourceCredential, cancellationToken);
                string credentialId = ClientCommon.GetCredentialId(response.Headers.Location);

                try
                {
                    var createdCredential = GetDatasourceCredential(credentialId, cancellationToken);

                    return Response.FromValue(createdCredential, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The datasource credential has been created successfully, but the client failed to fetch its data. Datasource Credential ID: {credentialId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DatasourceCredential"/>. In order to update your credential, you cannot create a <see cref="DatasourceCredential"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDatasourceCredentialAsync"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="datasourceCredential">The <see cref="DatasourceCredential"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing information about the updated credential.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredential"/> or <paramref name="datasourceCredential"/>.Id is null.</exception>
        public virtual async Task<Response<DatasourceCredential>> UpdateDatasourceCredentialAsync(DatasourceCredential datasourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(datasourceCredential, nameof(datasourceCredential));

            if (datasourceCredential.Id == null)
            {
                throw new ArgumentNullException(nameof(datasourceCredential), $"{nameof(datasourceCredential)}.Id not available. Call {nameof(GetDatasourceCredentialAsync)} and update the returned model before calling this method.");
            }

            Guid credentialGuid = new Guid(datasourceCredential.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDatasourceCredential)}");
            scope.Start();

            try
            {
                DataSourceCredentialPatch patch = datasourceCredential.GetPatchModel();

                return await _serviceRestClient.UpdateCredentialAsync(credentialGuid, patch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DatasourceCredential"/>. In order to update your credential, you cannot create a <see cref="DatasourceCredential"/>
        /// directly from its constructor. You need to obtain an instance via <see cref="GetDatasourceCredentialAsync"/> or another CRUD operation and update
        /// it before calling this method.
        /// </summary>
        /// <param name="datasourceCredential">The <see cref="DatasourceCredential"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing information about the updated credential.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredential"/> or <paramref name="datasourceCredential"/>.Id is null.</exception>
        public virtual Response<DatasourceCredential> UpdateDatasourceCredential(DatasourceCredential datasourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(datasourceCredential, nameof(datasourceCredential));

            if (datasourceCredential.Id == null)
            {
                throw new ArgumentNullException(nameof(datasourceCredential), $"{nameof(datasourceCredential)}.Id not available. Call {nameof(GetDatasourceCredential)} and update the returned model before calling this method.");
            }

            Guid credentialGuid = new Guid(datasourceCredential.Id);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDatasourceCredential)}");
            scope.Start();

            try
            {
                DataSourceCredentialPatch patch = datasourceCredential.GetPatchModel();

                return _serviceRestClient.UpdateCredential(credentialGuid, patch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="DatasourceCredential"/>.
        /// </summary>
        /// <param name="datasourceCredentialId">The unique identifier of the <see cref="DatasourceCredential"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="datasourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<DatasourceCredential>> GetDatasourceCredentialAsync(string datasourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(datasourceCredentialId, nameof(datasourceCredentialId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredential)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.GetCredentialAsync(credentialGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="DatasourceCredential"/>.
        /// </summary>
        /// <param name="datasourceCredentialId">The unique identifier of the <see cref="DatasourceCredential"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DatasourceCredential"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="datasourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual Response<DatasourceCredential> GetDatasourceCredential(string datasourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(datasourceCredentialId, nameof(datasourceCredentialId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredential)}");
            scope.Start();

            try
            {
                return _serviceRestClient.GetCredential(credentialGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="DatasourceCredential"/> instances in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DatasourceCredential"/> instances.</returns>
        public virtual AsyncPageable<DatasourceCredential> GetDatasourceCredentialsAsync(GetDatasourceCredentialsOptions options = default, CancellationToken cancellationToken = default)
        {
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            async Task<Page<DatasourceCredential>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredentials)}");
                scope.Start();

                try
                {
                    Response<DataSourceCredentialList> response = await _serviceRestClient.ListCredentialsAsync(skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DatasourceCredential>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredentials)}");
                scope.Start();

                try
                {
                    Response<DataSourceCredentialList> response = await _serviceRestClient.ListCredentialsNextPageAsync(nextLink, skip, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a collection of items describing the existing <see cref="DatasourceCredential"/> instances in this Metrics
        /// Advisor resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="DatasourceCredential"/> instances.</returns>
        public virtual Pageable<DatasourceCredential> GetDatasourceCredentials(GetDatasourceCredentialsOptions options = default, CancellationToken cancellationToken = default)
        {
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            Page<DatasourceCredential> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredentials)}");
                scope.Start();

                try
                {
                    Response<DataSourceCredentialList> response = _serviceRestClient.ListCredentials(skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DatasourceCredential> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDatasourceCredentials)}");
                scope.Start();

                try
                {
                    Response<DataSourceCredentialList> response = _serviceRestClient.ListCredentialsNextPage(nextLink, skip, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Deletes an existing <see cref="DatasourceCredential"/>.
        /// </summary>
        /// <param name="datasourceCredentialId">The unique identifier of the <see cref="DatasourceCredential"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="datasourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteDatasourceCredentialAsync(string datasourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(datasourceCredentialId, nameof(datasourceCredentialId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDatasourceCredential)}");
            scope.Start();

            try
            {
                return await _serviceRestClient.DeleteCredentialAsync(credentialGuid, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="DatasourceCredential"/>.
        /// </summary>
        /// <param name="datasourceCredentialId">The unique identifier of the <see cref="DatasourceCredential"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="datasourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="datasourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteDatasourceCredential(string datasourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(datasourceCredentialId, nameof(datasourceCredentialId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDatasourceCredential)}");
            scope.Start();

            try
            {
                return _serviceRestClient.DeleteCredential(credentialGuid, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Credential
    }
}
