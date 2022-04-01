// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary> The MetricsAdvisorClient service client. </summary>
    public partial class MetricsAdvisorClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential)
            : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <param name="options">A set of options to apply when configuring the client.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, MetricsAdvisorKeyCredential credential, MetricsAdvisorClientsOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MetricsAdvisorClientsOptions();

            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MetricsAdvisorKeyCredentialPolicy(credential));
            _endpoint = endpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricsAdvisorClient"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint to use for connecting to the Metrics Advisor Cognitive Service.</param>
        /// <param name="credential">A credential used to authenticate to the service.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public MetricsAdvisorClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, null)
        {
        }

        #region MetricFeedback

        /// <summary>
        /// Gets a collection of <see cref="MetricFeedback"/> related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetAllFeedbackOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// An <see cref="AsyncPageable{T}"/> containing the collection of <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        [ForwardsClientCalls]
        public virtual AsyncPageable<MetricFeedback> GetAllFeedbackAsync(string metricId, GetAllFeedbackOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            FeedbackFilter filter = options?.Filter;

            MetricFeedbackFilter queryOptions = new MetricFeedbackFilter(metricGuid)
            {
                DimensionFilter = filter
            };

            if (filter != null)
            {
                queryOptions.EndTime = filter.EndsOn;
                queryOptions.FeedbackType = filter.FeedbackKind;
                queryOptions.StartTime = filter.StartsOn;
                queryOptions.TimeMode = filter.TimeMode;
            }

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
            scope.Start();

            try
            {
                RequestContent content = MetricFeedbackFilter.ToRequestContent(queryOptions);
                AsyncPageable<BinaryData> pageableBindaryData = GetMetricFeedbacksAsync(content, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBindaryData, response => MetricFeedbackList.FromResponse(response).Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of <see cref="MetricFeedback"/> related to the given metric.
        /// </summary>
        /// <param name="metricId">The ID of the metric.</param>
        /// <param name="options">The optional <see cref="GetAllFeedbackOptions"/> containing the options to apply to the request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Pageable{T}"/> containing the collection of <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> is empty or not a valid GUID.</exception>
        [ForwardsClientCalls]
        public virtual Pageable<MetricFeedback> GetAllFeedback(string metricId, GetAllFeedbackOptions options = default, CancellationToken cancellationToken = default)
        {
            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            FeedbackFilter filter = options?.Filter;

            MetricFeedbackFilter queryOptions = new MetricFeedbackFilter(metricGuid)
            {
                DimensionFilter = filter
            };

            if (filter != null)
            {
                queryOptions.EndTime = filter.EndsOn;
                queryOptions.FeedbackType = filter.FeedbackKind;
                queryOptions.StartTime = filter.StartsOn;
                queryOptions.TimeMode = filter.TimeMode;
            }

            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;

            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetAllFeedback)}");
            scope.Start();

            try
            {
                RequestContent content = MetricFeedbackFilter.ToRequestContent(queryOptions);
                Pageable<BinaryData> pageableBindaryData = GetMetricFeedbacks(content, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBindaryData, response => MetricFeedbackList.FromResponse(response).Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Adds a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="MetricFeedback"/>
        /// containing information about the newly added feedback.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual async Task<Response<MetricFeedback>> AddFeedbackAsync(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
            scope.Start();

            try
            {
                RequestContent content = MetricFeedback.ToRequestContent(feedback);
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = await CreateMetricFeedbackAsync(content, context).ConfigureAwait(false);

                var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
                string feedbackId = ClientCommon.GetFeedbackId(location);

                try
                {
                    var addedFeedback = await GetFeedbackAsync(feedbackId, cancellationToken).ConfigureAwait(false);

                    return Response.FromValue(addedFeedback, response);
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Adds a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedback">The <see cref="MetricFeedback"/> to be created.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the result of the operation. The result is a <see cref="MetricFeedback"/>
        /// containing information about the newly added feedback.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedback"/> is null.</exception>
        public virtual Response<MetricFeedback> AddFeedback(MetricFeedback feedback, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(feedback, nameof(feedback));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(AddFeedback)}");
            scope.Start();

            try
            {
                RequestContent content = MetricFeedback.ToRequestContent(feedback);
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = CreateMetricFeedback(content, context);

                var location = response.Headers.TryGetValue("Location", out string value) ? value : null;
                string feedbackId = ClientCommon.GetFeedbackId(location);

                try
                {
                    var addedFeedback = GetFeedback(feedbackId, cancellationToken);

                    return Response.FromValue(addedFeedback, response);
                }
                catch (Exception ex)
                {
                    throw new RequestFailedException($"The feedback has been added successfully, but the client failed to fetch its data. Feedback ID: {feedbackId}", ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedbackId">The ID of the <see cref="MetricFeedback"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the requested <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual async Task<Response<MetricFeedback>> GetFeedbackAsync(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = await GetMetricFeedbackAsync(feedbackGuid, context).ConfigureAwait(false);
                MetricFeedback value = MetricFeedback.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a <see cref="MetricFeedback"/>.
        /// </summary>
        /// <param name="feedbackId">The ID of the <see cref="MetricFeedback"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Response{T}"/> containing the requested <see cref="MetricFeedback"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="feedbackId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="feedbackId"/> is empty or not a valid GUID.</exception>
        public virtual Response<MetricFeedback> GetFeedback(string feedbackId, CancellationToken cancellationToken = default)
        {
            Guid feedbackGuid = ClientCommon.ValidateGuid(feedbackId, nameof(feedbackId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetFeedback)}");
            scope.Start();

            try
            {
                RequestContext context = new RequestContext()
                {
                    CancellationToken = cancellationToken,
                };
                Response response = GetMetricFeedback(feedbackGuid, context);
                MetricFeedback value = MetricFeedback.FromResponse(response);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion MetricFeedback

        #region TimeSeries

        /// <summary>
        /// Gets the possible values a <see cref="DataFeedDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="DataFeedDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AsyncPageable{T}"/> containing the collection of values the specified <see cref="DataFeedDimension"/> can assume.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="metricId"/> is not a valid GUID.</exception>
        [ForwardsClientCalls]
        public virtual AsyncPageable<string> GetMetricDimensionValuesAsync(string metricId, string dimensionName, GetMetricDimensionValuesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricDimensionQueryOptions queryOptions = new MetricDimensionQueryOptions(dimensionName)
            {
                DimensionValueFilter = options?.DimensionValueFilter
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
            scope.Start();

            try
            {
                RequestContent content = MetricDimensionQueryOptions.ToRequestContent(queryOptions);
                AsyncPageable<BinaryData> pageableBindaryData = GetMetricDimensionAsync(metricGuid, content, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBindaryData, response => MetricDimensionList.FromResponse(response).Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the possible values a <see cref="DataFeedDimension"/> can assume for a specified <see cref="DataFeedMetric"/>.
        /// </summary>
        /// <param name="metricId">The unique identifier of the <see cref="DataFeedMetric"/>.</param>
        /// <param name="dimensionName">The name of the <see cref="DataFeedDimension"/>.</param>
        /// <param name="options">An optional set of options used to configure the request's behavior.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="Pageable{T}"/> containing the collection of values the specified <see cref="DataFeedDimension"/> can assume.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="dimensionName"/> is empty; or <paramref name="metricId"/> is not a valid GUID.</exception>
        [ForwardsClientCalls]
        public virtual Pageable<string> GetMetricDimensionValues(string metricId, string dimensionName, GetMetricDimensionValuesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dimensionName, nameof(dimensionName));

            Guid metricGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));
            MetricDimensionQueryOptions queryOptions = new MetricDimensionQueryOptions(dimensionName)
            {
                DimensionValueFilter = options?.DimensionValueFilter
            };
            int? skip = options?.Skip;
            int? maxPageSize = options?.MaxPageSize;
            RequestContext context = new RequestContext()
            {
                CancellationToken = cancellationToken,
            };

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(MetricsAdvisorClient)}.{nameof(GetMetricDimensionValues)}");
            scope.Start();

            try
            {
                RequestContent content = MetricDimensionQueryOptions.ToRequestContent(queryOptions);
                Pageable<BinaryData> pageableBindaryData = GetMetricDimension(metricGuid, content, skip, maxPageSize, context);
                return PageableHelpers.Select(pageableBindaryData, response => MetricDimensionList.FromResponse(response).Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion TimeSeries
    }
}
