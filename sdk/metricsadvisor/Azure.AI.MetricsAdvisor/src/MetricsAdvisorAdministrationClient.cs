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
    /// </summary>
    public class MetricsAdvisorAdministrationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient _serviceRestClient;

        /// <summary>
        /// </summary>
        public MetricsAdvisorAdministrationClient(Uri endpoint, MetricsAdvisorKeyCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// </summary>
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
        /// </summary>
        public MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// </summary>
        public MetricsAdvisorAdministrationClient(Uri endpoint, TokenCredential credential, MetricsAdvisorClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, Constants.DefaultCognitiveScope));

            _serviceRestClient = new AzureCognitiveServiceMetricsAdvisorRestAPIOpenAPIV2RestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        /// <summary>
        /// </summary>
        protected MetricsAdvisorAdministrationClient()
        {
        }

        #region DataFeed

        /// <summary>
        /// </summary>
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
        /// </summary>
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
        /// </summary>
        public virtual AsyncPageable<DataFeed> GetDataFeedsAsync(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            string name = options?.Filter?.Name;
            DataFeedSourceType? sourceType = options?.Filter?.SourceType;
            DataFeedGranularityType? granularityType = options?.Filter?.GranularityType;
            EntityStatus? status = options?.Filter?.Status?.ConvertToEntityStatus();
            string creator = options?.Filter?.Creator;
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
        /// </summary>
        public virtual Pageable<DataFeed> GetDataFeeds(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            string name = options?.Filter?.Name;
            DataFeedSourceType? sourceType = options?.Filter?.SourceType;
            DataFeedGranularityType? granularityType = options?.Filter?.GranularityType;
            EntityStatus? status = options?.Filter?.Status?.ConvertToEntityStatus();
            string creator = options?.Filter?.Creator;
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
        ///
        /// </summary>
        /// <param name="dataFeedName"> The data feed name. </param>
        /// <param name="dataSource"></param>
        /// <param name="dataFeedGranularity"></param>
        /// <param name="dataFeedSchema"></param>
        /// <param name="dataFeedIngestionSettings"></param>
        /// <param name="dataFeedOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response{DataFeed}"/>.</returns>
        public virtual async Task<Response<DataFeed>> CreateDataFeedAsync(string dataFeedName, DataFeedSource dataSource, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings, DataFeedOptions dataFeedOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNull(dataSource, nameof(dataSource));
            Argument.AssertNotNull(dataFeedGranularity, nameof(dataFeedGranularity));
            Argument.AssertNotNull(dataFeedSchema, nameof(dataFeedSchema));
            Argument.AssertNotNullOrEmpty(dataFeedSchema.MetricColumns, $"{nameof(dataFeedSchema)}.{nameof(dataFeedSchema.MetricColumns)}");
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
        ///
        /// </summary>
        /// <param name="dataFeedName"> The data feed name. </param>
        /// <param name="dataSource"></param>
        /// <param name="dataFeedGranularity"></param>
        /// <param name="dataFeedSchema"></param>
        /// <param name="dataFeedIngestionSettings"></param>
        /// <param name="dataFeedOptions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response{DataFeed}"/>.</returns>
        public virtual Response<DataFeed> CreateDataFeed(string dataFeedName, DataFeedSource dataSource, DataFeedGranularity dataFeedGranularity, DataFeedSchema dataFeedSchema, DataFeedIngestionSettings dataFeedIngestionSettings, DataFeedOptions dataFeedOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedName, nameof(dataFeedName));
            Argument.AssertNotNull(dataSource, nameof(dataSource));
            Argument.AssertNotNull(dataFeedGranularity, nameof(dataFeedGranularity));
            Argument.AssertNotNull(dataFeedSchema, nameof(dataFeedSchema));
            Argument.AssertNotNullOrEmpty(dataFeedSchema.MetricColumns, $"{nameof(dataFeedSchema)}.{nameof(dataFeedSchema.MetricColumns)}");
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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="dataFeed"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> UpdateDataFeedAsync(string dataFeedId, DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));
            if (!dataFeedId.Equals(dataFeed.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(dataFeedId)} does not match {nameof(dataFeed.Id)}");
            }

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = DataFeedDetail.GetPatchModel(dataFeed);
                return await _serviceRestClient.UpdateDataFeedAsync(dataFeedGuid, patchModel, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="dataFeed"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response UpdateDataFeed(string dataFeedId, DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(dataFeed, nameof(dataFeed));
            if (!dataFeedId.Equals(dataFeed.Id, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"{nameof(dataFeedId)} does not match {nameof(dataFeed.Id)}");
            }

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(UpdateDataFeed)}");
            scope.Start();
            try
            {
                DataFeedDetailPatch patchModel = DataFeedDetail.GetPatchModel(dataFeed);
                return _serviceRestClient.UpdateDataFeed(dataFeedGuid, patchModel, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response{DataFeed}"/>.</returns>
        public virtual async Task<Response> DeleteDataFeedAsync(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Response{DataFeed}"/>.</returns>
        public virtual Response DeleteDataFeed(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));

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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DataFeedIngestionProgress>> GetDataFeedIngestionProgressAsync(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DataFeedIngestionProgress> GetDataFeedIngestionProgress(string dataFeedId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> ResetDataFeedIngestionStatusAsync(string dataFeedId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(ResetDataFeedIngestionStatus)}");
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
        ///
        /// </summary>
        /// <param name="dataFeedId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response ResetDataFeedIngestionStatus(string dataFeedId, DateTimeOffset startTime, DateTimeOffset endTime, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(ResetDataFeedIngestionStatus)}");
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
        /// </summary>
        public virtual AsyncPageable<DataFeedIngestionStatus> GetDataFeedIngestionStatusesAsync(string dataFeedId, GetDataFeedIngestionStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(options, nameof(options));

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

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
        /// </summary>
        public virtual Pageable<DataFeedIngestionStatus> GetDataFeedIngestionStatuses(string dataFeedId, GetDataFeedIngestionStatusesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataFeedId, nameof(dataFeedId));
            Argument.AssertNotNull(options, nameof(options));

            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

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
        /// </summary>
        public virtual async Task<Response<MetricAnomalyDetectionConfiguration>> CreateMetricAnomalyDetectionConfigurationAsync(MetricAnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
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
        /// </summary>
        public virtual Response<MetricAnomalyDetectionConfiguration> CreateMetricAnomalyDetectionConfiguration(MetricAnomalyDetectionConfiguration detectionConfiguration, CancellationToken cancellationToken = default)
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
        /// </summary>
        public virtual async Task<Response<MetricAnomalyDetectionConfiguration>> GetMetricAnomalyDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
        public virtual Response<MetricAnomalyDetectionConfiguration> GetMetricAnomalyDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
        public virtual async Task<Response<IReadOnlyList<MetricAnomalyDetectionConfiguration>>> GetMetricAnomalyDetectionConfigurationsAsync(string metricId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));

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
        /// </summary>
        public virtual Response<IReadOnlyList<MetricAnomalyDetectionConfiguration>> GetMetricAnomalyDetectionConfigurations(string metricId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));

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
        /// </summary>
        public virtual async Task<Response> DeleteMetricAnomalyDetectionConfigurationAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
        public virtual Response DeleteMetricAnomalyDetectionConfiguration(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
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
        /// </summary>
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
        /// </summary>
        public virtual async Task<Response<AnomalyAlertConfiguration>> GetAnomalyAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));

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
        /// </summary>
        public virtual Response<AnomalyAlertConfiguration> GetAnomalyAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));

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
        /// </summary>
        public virtual async Task<Response<IReadOnlyList<AnomalyAlertConfiguration>>> GetAnomalyAlertConfigurationsAsync(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
        public virtual Response<IReadOnlyList<AnomalyAlertConfiguration>> GetAnomalyAlertConfigurations(string detectionConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));

            Guid detectionConfigurationGuid = ClientCommon.ValidateGuid(detectionConfigurationId, nameof(detectionConfigurationId));

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
        /// </summary>
        public virtual async Task<Response> DeleteAnomalyAlertConfigurationAsync(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));

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
        /// </summary>
        public virtual Response DeleteAnomalyAlertConfiguration(string alertConfigurationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(alertConfigurationId, nameof(alertConfigurationId));

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
        /// </summary>
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
        /// </summary>
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
        /// </summary>
        public virtual async Task<Response> UpdateHookAsync(string hookId, AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

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
        /// </summary>
        public virtual Response UpdateHook(string hookId, AlertingHook hook, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(hook, nameof(hook));

            Guid hookGuid = ClientCommon.ValidateGuid(hookId, nameof(hookId));

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
        /// </summary>
        public virtual async Task<Response<AlertingHook>> GetHookAsync(string hookId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hookId, nameof(hookId));

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
        /// </summary>
        public virtual Response<AlertingHook> GetHook(string hookId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hookId, nameof(hookId));

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
        /// </summary>
        public virtual async Task<Response> DeleteHookAsync(string hookId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hookId, nameof(hookId));

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
        /// </summary>
        public virtual Response DeleteHook(string hookId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(hookId, nameof(hookId));

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
        ///
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<AlertingHook> GetHooksAsync(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<AlertingHook>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = await _serviceRestClient.ListHooksAsync(options?.HookName, options?.SkipCount, options?.TopCount, cancellationToken).ConfigureAwait(false);
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
                    Response<HookList> response = await _serviceRestClient.ListHooksNextPageAsync(nextLink, options?.HookName, options?.SkipCount, options?.TopCount, cancellationToken).ConfigureAwait(false);
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
        ///
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<AlertingHook> GetHooks(GetHooksOptions options = default, CancellationToken cancellationToken = default)
        {
            Page<AlertingHook> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetHooks)}");
                scope.Start();

                try
                {
                    Response<HookList> response = _serviceRestClient.ListHooks(options?.HookName, options?.SkipCount, options?.TopCount, cancellationToken);
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
                    Response<HookList> response = _serviceRestClient.ListHooksNextPage(nextLink, options?.HookName, options?.SkipCount, options?.TopCount, cancellationToken);
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
