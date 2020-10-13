// Copyright (c) Microsoft Corporation. All rights reserved.
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

        private readonly AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient _serviceRestClient;

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
        public MetricsAdvisorAdministrationClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));

            _serviceRestClient = new AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorAdministrationClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        internal MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential)
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
        internal MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential, MetricsAdvisorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));

            _serviceRestClient = new AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
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
            EntityStatus? status = options?.GetDataFeedsFilter?.Status?.ConvertToEntityStatus();
            string creator = options?.GetDataFeedsFilter?.Creator;
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            async Task<Page<DataFeed>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = await _serviceRestClient.ListDataFeedsAsync(name, sourceType, granularityType, status, creator, skip, top, cancellationToken).ConfigureAwait(false);
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
                    Response<DataFeedList> response = await _serviceRestClient.ListDataFeedsNextPageAsync(nextLink, name, sourceType, granularityType, status, creator, skip, top, cancellationToken).ConfigureAwait(false);
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
            EntityStatus? status = options?.GetDataFeedsFilter?.Status?.ConvertToEntityStatus();
            string creator = options?.GetDataFeedsFilter?.Creator;
            int? skip = options?.SkipCount;
            int? top = options?.TopCount;

            Page<DataFeed> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
                scope.Start();

                try
                {
                    Response<DataFeedList> response = _serviceRestClient.ListDataFeeds(name, sourceType, granularityType, status, creator, skip, top, cancellationToken);
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
                    Response<DataFeedList> response = _serviceRestClient.ListDataFeedsNextPage(nextLink, name, sourceType, granularityType, status, creator, skip, top, cancellationToken);
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
        /// <param name="dataFeedName">A custom name for the <see cref="DataFeed"/> to be displayed on the web portal.</param>
        /// <param name="dataSource">The source from which data will be consumed.</param>
        /// <param name="dataFeedGranularity">The frequency with which ingestion from the data source will happen.</param>
        /// <param name="dataFeedSchema">Defines how this <see cref="DataFeed"/> structures the data ingested from the data source in terms of metrics and dimensions.</param>
        /// <param name="dataFeedIngestionSettings">Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.</param>
        /// <param name="dataFeedOptions">An optional set of options configuring the behavior of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing the ID of the newly created feed.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedName"/>, <paramref name="dataSource"/>, <paramref name="dataFeedGranularity"/>, <paramref name="dataFeedSchema"/>, or <paramref name="dataFeedIngestionSettings"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedName"/> is empty.</exception>
        public virtual async Task<Response<DataFeed>> CreateDataFeedAsync(string dataFeedName, DataFeedSource dataSource, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings, DataFeedOptions dataFeedOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNull(dataSource, nameof(dataSource));
            Argument.AssertNotNull(dataFeedGranularity, nameof(dataFeedGranularity));
            Argument.AssertNotNull(dataFeedSchema, nameof(dataFeedSchema));
            Argument.AssertNotNull(dataFeedIngestionSettings, nameof(dataFeedIngestionSettings));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataFeed)}");
            scope.Start();
            try
            {
                dataSource.SetDetail(dataFeedName, dataFeedGranularity, dataFeedSchema, dataFeedIngestionSettings, dataFeedOptions);
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateDataFeedHeaders> response = await _serviceRestClient.CreateDataFeedAsync(dataSource.DataFeedDetail, cancellationToken).ConfigureAwait(false);

                string dataFeedId = ClientCommon.GetDataFeedId(response.Headers.Location);
                var createdDataFeed = new DataFeed(dataSource.DataFeedDetail) { Id = dataFeedId };
                return Response.FromValue(createdDataFeed, response.GetRawResponse());
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
        /// <param name="dataFeedName">A custom name for the <see cref="DataFeed"/> to be displayed on the web portal.</param>
        /// <param name="dataSource">The source from which data will be consumed.</param>
        /// <param name="dataFeedGranularity">The frequency with which ingestion from the data source will happen.</param>
        /// <param name="dataFeedSchema">Defines how this <see cref="DataFeed"/> structures the data ingested from the data source in terms of metrics and dimensions.</param>
        /// <param name="dataFeedIngestionSettings">Configures how a <see cref="DataFeed"/> behaves during data ingestion from its data source.</param>
        /// <param name="dataFeedOptions">An optional set of options configuring the behavior of the <see cref="DataFeed"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataFeed"/> instance
        /// containing the ID of the newly created feed.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedName"/>, <paramref name="dataSource"/>, <paramref name="dataFeedGranularity"/>, <paramref name="dataFeedSchema"/>, or <paramref name="dataFeedIngestionSettings"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedName"/> is empty.</exception>
        public virtual Response<DataFeed> CreateDataFeed(string dataFeedName, DataFeedSource dataSource, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings, DataFeedOptions dataFeedOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNull(dataSource, nameof(dataSource));
            Argument.AssertNotNull(dataFeedGranularity, nameof(dataFeedGranularity));
            Argument.AssertNotNull(dataFeedSchema, nameof(dataFeedSchema));
            Argument.AssertNotNull(dataFeedIngestionSettings, nameof(dataFeedIngestionSettings));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataFeed)}");
            scope.Start();
            try
            {
                dataSource.SetDetail(dataFeedName, dataFeedGranularity, dataFeedSchema, dataFeedIngestionSettings, dataFeedOptions);
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateDataFeedHeaders> response = _serviceRestClient.CreateDataFeed(dataSource.DataFeedDetail, cancellationToken);

                string dataFeedId = ClientCommon.GetDataFeedId(response.Headers.Location);
                var createdDataFeed = new DataFeed(dataSource.DataFeedDetail) { Id = dataFeedId };
                return Response.FromValue(createdDataFeed, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The ID of the existing <see cref="DataFeed"/> to update.</param>
        /// <param name="dataFeed">The <see cref="DataFeed"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> or <paramref name="dataFeed"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> UpdateDataFeedAsync(string dataFeedId, DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));
            if (!string.IsNullOrEmpty(dataFeed.Id) && !dataFeedId.Equals(dataFeed.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(dataFeedId)} does not match {nameof(dataFeed.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
                return await _serviceRestClient.UpdateDataFeedAsync(dataFeedGuid, patchModel, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="DataFeed"/>.
        /// </summary>
        /// <param name="dataFeedId">The ID of the existing <see cref="DataFeed"/> to update.</param>
        /// <param name="dataFeed">The <see cref="DataFeed"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataFeedId"/> or <paramref name="dataFeed"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeedId"/> is empty or not a valid GUID.</exception>
        public virtual Response UpdateDataFeed(string dataFeedId, DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));
            if (!string.IsNullOrEmpty(dataFeed.Id) && !dataFeedId.Equals(dataFeed.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(dataFeedId)} does not match {nameof(dataFeed.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
                return _serviceRestClient.UpdateDataFeed(dataFeedGuid, patchModel, cancellationToken);
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
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            async Task<Page<DataFeedIngestionStatus>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = await _serviceRestClient.GetDataFeedIngestionStatusAsync(dataFeedGuid, queryOptions, skip, top, cancellationToken).ConfigureAwait(false);
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
            int? skip = options.SkipCount;
            int? top = options.TopCount;

            Page<DataFeedIngestionStatus> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeedIngestionStatuses)}");
                scope.Start();

                try
                {
                    Response<IngestionStatusList> response = _serviceRestClient.GetDataFeedIngestionStatus(dataFeedGuid, queryOptions, skip, top, cancellationToken);
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

        #endregion DataFeed

        #region AnomalyDetectionConfiguration

        /// <summary>
        /// Creates an <see cref="AnomalyDetectionConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="detectionConfiguration">Specifies how the created <see cref="AnomalyDetectionConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/> instance
        /// containing the ID of the newly created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/> is null.</exception>
        public virtual async Task<Response<AnomalyDetectionConfiguration>> CreateMetricAnomalyDetectionConfigurationAsync(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateMetricAnomalyDetectionConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyDetectionConfigurationHeaders> response = await _serviceRestClient.CreateAnomalyDetectionConfigurationAsync(detectionConfiguration, cancellationToken).ConfigureAwait(false);
                detectionConfiguration.Id = ClientCommon.GetAnomalyDetectionConfigurationId(response.Headers.Location);

                return Response.FromValue(detectionConfiguration, response.GetRawResponse());
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
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyDetectionConfiguration"/> instance
        /// containing the ID of the newly created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfiguration"/> is null.</exception>
        public virtual Response<AnomalyDetectionConfiguration> CreateMetricAnomalyDetectionConfiguration(AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateMetricAnomalyDetectionConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyDetectionConfigurationHeaders> response = _serviceRestClient.CreateAnomalyDetectionConfiguration(detectionConfiguration, cancellationToken);
                detectionConfiguration.Id = ClientCommon.GetAnomalyDetectionConfigurationId(response.Headers.Location);

                return Response.FromValue(detectionConfiguration, response.GetRawResponse());
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
        public virtual async Task<Response<AnomalyDetectionConfiguration>> GetMetricAnomalyDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetMetricAnomalyDetectionConfiguration)}");
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
        public virtual Response<AnomalyDetectionConfiguration> GetMetricAnomalyDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetMetricAnomalyDetectionConfiguration)}");
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
        /// Updates an existing <see cref="AnomalyDetectionConfiguration"/> in this resource.
        /// </summary>
        /// <param name="detectionConfigurationId">The ID of the existing <see cref="AnomalyDetectionConfiguration"/> to update.</param>
        /// <param name="detectionConfiguration">The <see cref="AnomalyDetectionConfiguration"/> instance containing the desired updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="detectionConfiguration"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> UpdateMetricAnomalyDetectionConfigurationAsync(string detectionConfigurationId, AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));
            if (!string.IsNullOrEmpty(detectionConfiguration.Id) && !detectionConfigurationId.Equals(detectionConfiguration.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(detectionConfigurationId)} does not match {nameof(detectionConfiguration.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateMetricAnomalyDetectionConfiguration)}");
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
        /// Updates an existing <see cref="AnomalyDetectionConfiguration"/> in this resource.
        /// </summary>
        /// <param name="detectionConfigurationId">The ID of the existing <see cref="AnomalyDetectionConfiguration"/> to update.</param>
        /// <param name="detectionConfiguration">The <see cref="AnomalyDetectionConfiguration"/> instance containing the desired updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="detectionConfiguration"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response UpdateMetricAnomalyDetectionConfiguration(string detectionConfigurationId, AnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(detectionConfiguration, nameof(detectionConfiguration));
            if (!string.IsNullOrEmpty(detectionConfiguration.Id) && !detectionConfigurationId.Equals(detectionConfiguration.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(detectionConfigurationId)} does not match {nameof(detectionConfiguration.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateMetricAnomalyDetectionConfiguration)}");
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
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="AnomalyDetectionConfiguration"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<IReadOnlyList<AnomalyDetectionConfiguration>>> GetMetricAnomalyDetectionConfigurationsAsync(string metricId, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetMetricAnomalyDetectionConfigurations)}");
            scope.Start();

            try
            {
                Response<AnomalyDetectionConfigurationList> response = await _serviceRestClient.GetAnomalyDetectionConfigurationsByMetricAsync(metricGuid, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="AnomalyDetectionConfiguration"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        public virtual Response<IReadOnlyList<AnomalyDetectionConfiguration>> GetMetricAnomalyDetectionConfigurations(string metricId, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetMetricAnomalyDetectionConfigurations)}");
            scope.Start();

            try
            {
                Response<AnomalyDetectionConfigurationList> response = _serviceRestClient.GetAnomalyDetectionConfigurationsByMetric(metricGuid, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
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
        public virtual async Task<Response> DeleteMetricAnomalyDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteMetricAnomalyDetectionConfiguration)}");
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
        public virtual Response DeleteMetricAnomalyDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteMetricAnomalyDetectionConfiguration)}");
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

        #endregion AnomalyDetectionConfiguration

        #region AnomalyAlertingConfiguration

        /// <summary>
        /// Creates an <see cref="AnomalyAlertConfiguration"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="alertConfiguration">Specifies how the created <see cref="AnomalyAlertConfiguration"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/> instance
        /// containing the ID of the newly created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.MetricAlertConfigurations is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfiguration"/>.MetricAlertConfigurations is empty.</exception>
        public virtual async Task<Response<AnomalyAlertConfiguration>> CreateAnomalyAlertConfigurationAsync(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            Argument.AssertNotNullOrEmpty(alertConfiguration.MetricAlertConfigurations, $"{nameof(alertConfiguration)}.{nameof(alertConfiguration.MetricAlertConfigurations)}");

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateAnomalyAlertConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyAlertingConfigurationHeaders> response = await _serviceRestClient.CreateAnomalyAlertingConfigurationAsync(alertConfiguration, cancellationToken).ConfigureAwait(false);
                alertConfiguration.Id = ClientCommon.GetAnomalyAlertConfigurationId(response.Headers.Location);

                return Response.FromValue(alertConfiguration, response.GetRawResponse());
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
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AnomalyAlertConfiguration"/> instance
        /// containing the ID of the newly created configuration.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfiguration"/> or <paramref name="alertConfiguration"/>.MetricAlertConfigurations is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfiguration"/>.MetricAlertConfigurations is empty.</exception>
        public virtual Response<AnomalyAlertConfiguration> CreateAnomalyAlertConfiguration(AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            Argument.AssertNotNullOrEmpty(alertConfiguration.MetricAlertConfigurations, $"{nameof(alertConfiguration)}.{nameof(alertConfiguration.MetricAlertConfigurations)}");

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateAnomalyAlertConfiguration)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateAnomalyAlertingConfigurationHeaders> response = _serviceRestClient.CreateAnomalyAlertingConfiguration(alertConfiguration, cancellationToken);
                alertConfiguration.Id = ClientCommon.GetAnomalyAlertConfigurationId(response.Headers.Location);

                return Response.FromValue(alertConfiguration, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertConfiguration">The <see cref="AnomalyAlertConfiguration"/> containing the updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertConfiguration"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> UpdateAnomalyAlertConfigurationAsync(string alertConfigurationId, AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            if (!string.IsNullOrEmpty(alertConfiguration.Id) && !alertConfigurationId.Equals(alertConfiguration.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(alertConfigurationId)} does not match {nameof(alertConfiguration.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateAnomalyAlertConfiguration)}");
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
        /// Updates an existing <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <param name="alertConfigurationId">The unique identifier of the <see cref="AnomalyAlertConfiguration"/>.</param>
        /// <param name="alertConfiguration">The <see cref="AnomalyAlertConfiguration"/> containing the updates.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> or <paramref name="alertConfiguration"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response UpdateAnomalyAlertConfiguration(string alertConfigurationId, AnomalyAlertConfiguration alertConfiguration, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));
            Argument.AssertNotNull(alertConfiguration, nameof(alertConfiguration));
            if (!string.IsNullOrEmpty(alertConfiguration.Id) && !alertConfigurationId.Equals(alertConfiguration.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(alertConfigurationId)} does not match {nameof(alertConfiguration.Id)}");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateAnomalyAlertConfiguration)}");
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
        public virtual async Task<Response<AnomalyAlertConfiguration>> GetAnomalyAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAnomalyAlertConfiguration)}");
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
        public virtual Response<AnomalyAlertConfiguration> GetAnomalyAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAnomalyAlertConfiguration)}");
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
        /// <param name="alertConfigurationId">Filters the result. The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/> to which the returned <see cref="AnomalyAlertConfiguration"/>s apply.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="AnomalyAlertConfiguration"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<IReadOnlyList<AnomalyAlertConfiguration>>> GetAnomalyAlertConfigurationsAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAnomalyAlertConfigurations)}");
            scope.Start();

            try
            {
                Response<AnomalyAlertingConfigurationList> response = await _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfigurationAsync(detectionConfigurationGuid, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
        /// <param name="alertConfigurationId">Filters the result. The unique identifier of the <see cref="MetricAnomalyAlertConfiguration"/> to which the returned <see cref="AnomalyAlertConfiguration"/>s apply.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="AnomalyAlertConfiguration"/> items.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="alertConfigurationId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="alertConfigurationId"/> is empty or not a valid GUID.</exception>
        public virtual Response<IReadOnlyList<AnomalyAlertConfiguration>> GetAnomalyAlertConfigurations(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetAnomalyAlertConfigurations)}");
            scope.Start();

            try
            {
                Response<AnomalyAlertingConfigurationList> response = _serviceRestClient.GetAnomalyAlertingConfigurationsByAnomalyDetectionConfiguration(detectionConfigurationGuid, cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
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
        public virtual async Task<Response> DeleteAnomalyAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteAnomalyAlertConfiguration)}");
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
        public virtual Response DeleteAnomalyAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Guid alertConfigurationGuid = ClientCommon.ValidateGuid(alertConfigurationId, nameof(alertConfigurationId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteAnomalyAlertConfiguration)}");
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

        #endregion AnomalyAlertingConfiguration

        #region Hook

        /// <summary>
        /// Creates an <see cref="AlertingHook"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="hook">Specifies how the created <see cref="AlertingHook"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AlertingHook"/> instance
        /// containing the ID of the newly created hook.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> is null; or <paramref name="hook"/> is an <see cref="EmailHook"/> and <paramref name="hook"/>.EmailsToAlert is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hook"/> is an <see cref="EmailHook"/> and <paramref name="hook"/>.EmailsToAlert is empty.</exception>
        public virtual async Task<Response<AlertingHook>> CreateHookAsync(AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook is EmailHook emailHook)
            {
                Argument.AssertNotNullOrEmpty(emailHook.EmailsToAlert, nameof(EmailHook.EmailsToAlert));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateHook)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateHookHeaders> response = await _serviceRestClient.CreateHookAsync(hook, cancellationToken).ConfigureAwait(false);
                hook.Id = ClientCommon.GetHookId(response.Headers.Location);

                return Response.FromValue(hook, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an <see cref="AlertingHook"/> and assigns it a unique ID.
        /// </summary>
        /// <param name="hook">Specifies how the created <see cref="AlertingHook"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AlertingHook"/> instance
        /// containing the ID of the newly created hook.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hook"/> is null; or <paramref name="hook"/> is an <see cref="EmailHook"/> and <paramref name="hook"/>.EmailsToAlert is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hook"/> is an <see cref="EmailHook"/> and <paramref name="hook"/>.EmailsToAlert is empty.</exception>
        public virtual Response<AlertingHook> CreateHook(AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook is EmailHook emailHook)
            {
                Argument.AssertNotNullOrEmpty(emailHook.EmailsToAlert, nameof(EmailHook.EmailsToAlert));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateHook)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2CreateHookHeaders> response = _serviceRestClient.CreateHook(hook, cancellationToken);
                hook.Id = ClientCommon.GetHookId(response.Headers.Location);

                return Response.FromValue(hook, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The ID of the existing <see cref="AlertingHook"/> to update.</param>
        /// <param name="hook">The <see cref="AlertingHook"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> or <paramref name="hook"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> UpdateHookAsync(string hookId, AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook is EmailHook emailHook)
            {
                Argument.AssertNotNullOrEmpty(emailHook.EmailsToAlert, nameof(EmailHook.EmailsToAlert));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateHook)}");
            scope.Start();

            try
            {
                HookInfoPatch patch = AlertingHook.GetPatchModel(hook);

                return await _serviceRestClient.UpdateHookAsync(hookGuid, patch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The ID of the existing <see cref="AlertingHook"/> to update.</param>
        /// <param name="hook">The <see cref="AlertingHook"/> model containing the updates to be applied.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> or <paramref name="hook"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual Response UpdateHook(string hookId, AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));
            Argument.AssertNotNull(hook, nameof(hook));

            if (hook is EmailHook emailHook)
            {
                Argument.AssertNotNullOrEmpty(emailHook.EmailsToAlert, nameof(EmailHook.EmailsToAlert));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateHook)}");
            scope.Start();

            try
            {
                HookInfoPatch patch = AlertingHook.GetPatchModel(hook);

                return _serviceRestClient.UpdateHook(hookGuid, patch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="AlertingHook"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AlertingHook"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<AlertingHook>> GetHookAsync(string hookId, CancellationToken cancellationToken = default)
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
        /// Gets an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="AlertingHook"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is an <see cref="AlertingHook"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hookId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="hookId"/> is empty or not a valid GUID.</exception>
        public virtual Response<AlertingHook> GetHook(string hookId, CancellationToken cancellationToken = default)
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
        /// Deletes an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="AlertingHook"/> to be deleted.</param>
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
        /// Deletes an existing <see cref="AlertingHook"/>.
        /// </summary>
        /// <param name="hookId">The unique identifier of the <see cref="AlertingHook"/> to be deleted.</param>
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
        /// Gets a collection of items describing the existing <see cref="AlertingHook"/>s in this resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="AlertingHook"/>s.</returns>
        public virtual AsyncPageable<AlertingHook> GetHooksAsync(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<AlertingHook>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = await _serviceRestClient.ListHooksAsync(options?.HookNameFilter, options?.SkipCount, options?.TopCount, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<AlertingHook>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = await _serviceRestClient.ListHooksNextPageAsync(nextLink, options?.HookNameFilter, options?.SkipCount, options?.TopCount, cancellationToken).ConfigureAwait(false);
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
        /// Gets a collection of items describing the existing <see cref="AlertingHook"/>s in this resource.
        /// </summary>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="AlertingHook"/>s.</returns>
        public virtual Pageable<AlertingHook> GetHooks(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            Page<AlertingHook> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = _serviceRestClient.ListHooks(options?.HookNameFilter, options?.SkipCount, options?.TopCount, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<AlertingHook> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = _serviceRestClient.ListHooksNextPage(nextLink, options?.HookNameFilter, options?.SkipCount, options?.TopCount, cancellationToken);
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

        #endregion Hook
    }
}
