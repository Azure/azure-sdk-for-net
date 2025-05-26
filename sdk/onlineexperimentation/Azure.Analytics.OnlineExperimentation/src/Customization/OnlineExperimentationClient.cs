// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class OnlineExperimentationClient
    {
        /// <summary>
        /// Creates or update an experiment metric asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="ifMatch"> Optionally limit requests to resources that have a matching ETag. </param>
        /// <param name="ifNoneMatch"> Optionally limit requests to resources that do not match the ETag. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual async Task<Response<ExperimentMetric>> CreateOrUpdateMetricAsync(
            string experimentMetricId,
            ExperimentMetric metric,
            ETag? ifMatch = null,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateOrUpdateMetricAsync(experimentMetricId, content, conditions, context).ConfigureAwait(false);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Create or update an experiment metric.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="ifMatch"> Optionally limit requests to resources that have a matching ETag. </param>
        /// <param name="ifNoneMatch"> Optionally limit requests to resources that do not match the ETag. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> CreateOrUpdateMetric(
            string experimentMetricId,
            ExperimentMetric metric,
            ETag? ifMatch = null,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CreateOrUpdateMetric(experimentMetricId, content, conditions, context);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Creates an experiment metric asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual async Task<Response<ExperimentMetric>> CreateMetricAsync(
            string experimentMetricId,
            ExperimentMetric metric,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfNoneMatch = ETag.All };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateOrUpdateMetricAsync(experimentMetricId, content, conditions, context).ConfigureAwait(false);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Creates an experiment metric.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> CreateMetric(
            string experimentMetricId,
            ExperimentMetric metric,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfNoneMatch = ETag.All };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CreateOrUpdateMetric(experimentMetricId, content, conditions, context);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Updates an experiment metric asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A partial <see cref="ExperimentMetric"/> definition for incremental updates. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual async Task<Response<ExperimentMetric>> UpdateMetricAsync(
            string experimentMetricId,
            ExperimentMetricUpdate metric,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfMatch = ifMatch };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateOrUpdateMetricAsync(experimentMetricId, content, conditions, context).ConfigureAwait(false);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Updates an experiment metric.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A partial <see cref="ExperimentMetric"/> definition for incremental updates. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> UpdateMetric(
            string experimentMetricId,
            ExperimentMetricUpdate metric,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using RequestContent content = metric.ToRequestContent();
            var conditions = new RequestConditions { IfMatch = ifMatch };
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CreateOrUpdateMetric(experimentMetricId, content, conditions, context);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Update <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Inactive"/>.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual Task<Response<ExperimentMetric>> DeactivateMetricAsync(
            string experimentMetricId,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            var payload = new ExperimentMetricUpdate { Lifecycle = LifecycleStage.Inactive };
            return UpdateMetricAsync(experimentMetricId, payload, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Inactive"/>.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> DeactivateMetric(
            string experimentMetricId,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            var payload = new ExperimentMetricUpdate { Lifecycle = LifecycleStage.Inactive };
            return UpdateMetric(experimentMetricId, payload, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual Task<Response<ExperimentMetric>> ActivateMetricAsync(
            string experimentMetricId,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            var payload = new ExperimentMetricUpdate { Lifecycle = LifecycleStage.Active };
            return UpdateMetricAsync(experimentMetricId, payload, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> ActivateMetric(
            string experimentMetricId,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            var payload = new ExperimentMetricUpdate { Lifecycle = LifecycleStage.Active };
            return UpdateMetric(experimentMetricId, payload, ifMatch, cancellationToken);
        }
    }
}
