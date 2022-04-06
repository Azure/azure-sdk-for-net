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
    /// data feeds, anomaly detection configurations, anomaly alerting configurations, hooks, and credential
    /// entities.
    /// </summary>
    [CodeGenClient("MetricsAdvisorAdministrationClient")]
    public partial class MetricsAdvisorAdministrationClient
    {
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

            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));
            _endpoint = endpoint;
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
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = await GetDataFeedByIdAsync(dataFeedGuid, context).ConfigureAwait(false);
                DataFeedDetail value = DataFeedDetail.FromResponse(response);
                return Response.FromValue(new DataFeed(value), response);
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
            Guid dataFeedGuid = ClientCommon.ValidateGuid(dataFeedId, nameof(dataFeedId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeed)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = GetDataFeedById(dataFeedGuid, context);
                DataFeedDetail value = DataFeedDetail.FromResponse(response);
                return Response.FromValue(new DataFeed(value), response);
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
        [ForwardsClientCalls]
        public virtual AsyncPageable<DataFeed> GetDataFeedsAsync(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
            scope.Start();

            try
            {
                string name = options?.Filter?.Name;
                DataFeedSourceKind? sourceKind = options?.Filter?.SourceKind;
                DataFeedGranularityType? granularityType = options?.Filter?.GranularityType;
                DataFeedStatus? status = options?.Filter?.Status;
                string sourceKindValue = sourceKind.HasValue ? sourceKind.Value.ToString() : null;
                string granularityTypeValue = granularityType.HasValue ? granularityType.Value.ToString() : null;
                string statusValue = status.HasValue ? status.Value.ToString() : null;
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                string creator = options?.Filter?.Creator;
                int? skip = options?.Skip;
                int? maxPageSize = options?.MaxPageSize;

                AsyncPageable<BinaryData> pageableBinaryData = GetDataFeedsValuesAsync(name, sourceKindValue, granularityTypeValue, statusValue, creator, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBinaryData, response => ConvertToDataFeeds(DataFeedList.FromResponse(response).Value));
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
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of <see cref="DataFeed"/>s.</returns>
        [ForwardsClientCalls]
        public virtual Pageable<DataFeed> GetDataFeeds(GetDataFeedsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataFeeds)}");
            scope.Start();

            try
            {
                string name = options?.Filter?.Name;
                DataFeedSourceKind? sourceKind = options?.Filter?.SourceKind;
                DataFeedGranularityType? granularityType = options?.Filter?.GranularityType;
                DataFeedStatus? status = options?.Filter?.Status;
                string sourceKindValue = sourceKind.HasValue ? sourceKind.Value.ToString() : null;
                string granularityTypeValue = granularityType.HasValue ? granularityType.Value.ToString() : null;
                string statusValue = status.HasValue ? status.Value.ToString() : null;
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                string creator = options?.Filter?.Creator;
                int? skip = options?.Skip;
                int? maxPageSize = options?.MaxPageSize;

                Pageable<BinaryData> pageableBinaryData = GetDataFeedsValues(name, sourceKindValue, granularityTypeValue, statusValue, creator, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBinaryData, response => ConvertToDataFeeds(DataFeedList.FromResponse(response).Value));
            }
            catch (Exception e)
            {
                scope.Failed(e);
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
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/>, <paramref name="dataFeed"/>.Name, <paramref name="dataFeed"/>.DataSource, <paramref name="dataFeed"/>.Granularity, <paramref name="dataFeed"/>.Schema, or <paramref name="dataFeed"/>.IngestionSettings is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeed"/>.Name is empty.</exception>
        public virtual async Task<Response<DataFeed>> CreateDataFeedAsync(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

            DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
            RequestContent content = DataFeedDetail.ToRequestContent(dataFeedDetail);
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };

            Response response = await CreateDataFeedAsync(content, context).ConfigureAwait(false);

            var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
            string dataFeedId = ClientCommon.GetDataFeedId(location);

            try
            {
                var createdDataFeed = await GetDataFeedAsync(dataFeedId, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(createdDataFeed, response);
            }
            catch (Exception ex)
            {
                throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
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
        /// <exception cref="ArgumentNullException"><paramref name="dataFeed"/>, <paramref name="dataFeed"/>.Name, <paramref name="dataFeed"/>.DataSource, <paramref name="dataFeed"/>.Granularity, <paramref name="dataFeed"/>.Schema, or <paramref name="dataFeed"/>.IngestionSettings is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataFeed"/>.Name is empty.</exception>
        public virtual Response<DataFeed> CreateDataFeed(DataFeed dataFeed, CancellationToken cancellationToken = default)
        {
            ValidateDataFeedToCreate(dataFeed, nameof(dataFeed));

            DataFeedDetail dataFeedDetail = dataFeed.GetDataFeedDetail();
            RequestContent content = DataFeedDetail.ToRequestContent(dataFeedDetail);
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };
            Response response = CreateDataFeed(content, context);

            var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
            string dataFeedId = ClientCommon.GetDataFeedId(location);

            try
            {
                var createdDataFeed = GetDataFeed(dataFeedId, cancellationToken);

                return Response.FromValue(createdDataFeed, response);
            }
            catch (Exception ex)
            {
                throw new RequestFailedException($"The data feed has been created successfully, but the client failed to fetch its data. Data feed ID: {dataFeedId}", ex);
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

            DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
            RequestContent content = DataFeedDetailPatch.ToRequestContent(patchModel);
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };
            Response response = await UpdateDataFeedAsync(dataFeedGuid, content, context).ConfigureAwait(false);
            DataFeedDetail dataFeedDetail = DataFeedDetail.FromResponse(response);
            return Response.FromValue(new DataFeed(dataFeedDetail), response);
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

            DataFeedDetailPatch patchModel = dataFeed.GetPatchModel();
            RequestContent content = DataFeedDetailPatch.ToRequestContent(patchModel);
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };
            Response response = UpdateDataFeed(dataFeedGuid, content, context);
            DataFeedDetail dataFeedDetail = DataFeedDetail.FromResponse(response);
            return Response.FromValue(new DataFeed(dataFeedDetail), response);
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

            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };
            return await DeleteDataFeedAsync(dataFeedGuid, context).ConfigureAwait(false);
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

            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };
            return DeleteDataFeed(dataFeedGuid, context);
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
        }

        #endregion DataFeed

        #region Credential

        /// <summary>
        /// Gets an existing <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        /// <param name="dataSourceCredentialId">The unique identifier of the <see cref="DataSourceCredentialEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataSourceCredentialEntity"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataSourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<DataSourceCredentialEntity>> GetDataSourceCredentialAsync(string dataSourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(dataSourceCredentialId, nameof(dataSourceCredentialId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                var response = await GetCredentialAsync(credentialGuid, context).ConfigureAwait(false);
                DataSourceCredentialEntity value = DataSourceCredentialEntity.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an existing <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        /// <param name="dataSourceCredentialId">The unique identifier of the <see cref="DataSourceCredentialEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataSourceCredentialEntity"/>
        /// instance containing the requested information.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataSourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual Response<DataSourceCredentialEntity> GetDataSourceCredential(string dataSourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(dataSourceCredentialId, nameof(dataSourceCredentialId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(GetDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                var response = GetCredential(credentialGuid, context);
                DataSourceCredentialEntity value = DataSourceCredentialEntity.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="DataSourceCredentialEntity"/> and assigns it a unique ID. This API provides different ways of
        /// authenticating to a <see cref="DataFeedSource"/> for data ingestion when the default authentication method does not suffice.
        /// Please see <see cref="DataSourceCredentialEntity"/> for a list of supported credentials.
        /// </summary>
        /// <param name="dataSourceCredential">Specifies how the created <see cref="DataSourceCredentialEntity"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataSourceCredentialEntity"/>
        /// instance containing information about the created data source credential entity.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredential"/> is null.</exception>
        public virtual async Task<Response<DataSourceCredentialEntity>> CreateDataSourceCredentialAsync(DataSourceCredentialEntity dataSourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceCredential, nameof(dataSourceCredential));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContent content = DataSourceCredentialEntity.ToRequestContent(dataSourceCredential);
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = await CreateCredentialAsync(content, context).ConfigureAwait(false);

                var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
                string credentialId = ClientCommon.GetCredentialId(location);

                try
                {
                    var createdCredential = await GetDataSourceCredentialAsync(credentialId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(createdCredential, response);
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The data source credential has been created successfully, but the client failed to fetch its data. Datasource Credential ID: {credentialId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a <see cref="DataSourceCredentialEntity"/> and assigns it a unique ID. This API provides different ways of
        /// authenticating to a <see cref="DataFeedSource"/> for data ingestion when the default authentication method does not suffice.
        /// Please see <see cref="DataSourceCredentialEntity"/> for a list of supported credentials.
        /// </summary>
        /// <param name="dataSourceCredential">Specifies how the created <see cref="DataSourceCredentialEntity"/> should be configured.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="DataSourceCredentialEntity"/>
        /// instance containing information about the created data source credential entity.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredential"/> is null.</exception>
        public virtual Response<DataSourceCredentialEntity> CreateDataSourceCredential(DataSourceCredentialEntity dataSourceCredential, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceCredential, nameof(dataSourceCredential));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(CreateDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContent content = DataSourceCredentialEntity.ToRequestContent(dataSourceCredential);
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = CreateCredential(content, context);

                var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
                string credentialId = ClientCommon.GetCredentialId(location);

                try
                {
                    var createdCredential = GetDataSourceCredential(credentialId, cancellationToken);

                    return Response.FromValue(createdCredential, response);
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The data source credential has been created successfully, but the client failed to fetch its data. Datasource Credential ID: {credentialId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        /// <param name="dataSourceCredentialId">The unique identifier of the <see cref="DataSourceCredentialEntity"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataSourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response> DeleteDataSourceCredentialAsync(string dataSourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(dataSourceCredentialId, nameof(dataSourceCredentialId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                return await DeleteCredentialAsync(credentialGuid, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="DataSourceCredentialEntity"/>.
        /// </summary>
        /// <param name="dataSourceCredentialId">The unique identifier of the <see cref="DataSourceCredentialEntity"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response"/> containing the result of the operation.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="dataSourceCredentialId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="dataSourceCredentialId"/> is empty or not a valid GUID.</exception>
        public virtual Response DeleteDataSourceCredential(string dataSourceCredentialId, CancellationToken cancellationToken = default)
        {
            Guid credentialGuid = ClientCommon.ValidateGuid(dataSourceCredentialId, nameof(dataSourceCredentialId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorAdministrationClient)}.{nameof(DeleteDataSourceCredential)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                return DeleteCredential(credentialGuid, context);
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
