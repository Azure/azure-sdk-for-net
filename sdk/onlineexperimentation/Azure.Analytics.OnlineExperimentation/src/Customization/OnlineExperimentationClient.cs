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
        /// Creates or updates a <see cref="ExperimentMetric"/> asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ExperimentMetric>> CreateOrUpdateMetricAsync(
            string experimentMetricId,
            ExperimentMetric metric,
            RequestConditions requestConditions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(experimentMetricId, nameof(experimentMetricId));
            Argument.AssertNotNull(metric, nameof(metric));

            using RequestContent content = metric.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            using Response response = await CreateOrUpdateMetricAsync(experimentMetricId, content, requestConditions, context).ConfigureAwait(false);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Creates or updates a <see cref="ExperimentMetric"/> asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>
        [ForwardsClientCalls]
        public virtual Response<ExperimentMetric> CreateOrUpdateMetric(
            string experimentMetricId,
            ExperimentMetric metric,
            RequestConditions requestConditions,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(experimentMetricId, nameof(experimentMetricId));
            Argument.AssertNotNull(metric, nameof(metric));

            using RequestContent content = metric.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            using Response response = CreateOrUpdateMetric(experimentMetricId, content, requestConditions, context);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        /// <summary>
        /// Creates or updates a <see cref="ExperimentMetric"/> asynchronously.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        [ForwardsClientCalls]
        public virtual Task<Response<ExperimentMetric>> CreateOrUpdateMetricAsync(
            string experimentMetricId,
            ExperimentMetric metric,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            return CreateOrUpdateMetricAsync(
                experimentMetricId,
                metric,
                new RequestConditions { IfMatch = ifMatch },
                cancellationToken);
        }

        /// <summary>
        /// Creates or updates a <see cref="ExperimentMetric"/>.
        /// </summary>
        /// <param name="experimentMetricId"> Identifier for this experiment metric. Must start with a lowercase letter and contain only lowercase letters, numbers, and underscores. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="ifMatch">Optionally limit requests to resources that have a matching ETag.</param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="experimentMetricId"/> or <paramref name="metric"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="experimentMetricId"/> is empty.</exception>

        public virtual Response<ExperimentMetric> CreateOrUpdateMetric(
            string experimentMetricId,
            ExperimentMetric metric,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            return CreateOrUpdateMetric(
                experimentMetricId,
                metric,
                new RequestConditions { IfMatch = ifMatch },
                cancellationToken);
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
            return SetMetricLifecycleAsync(experimentMetricId, LifecycleStage.Inactive, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Inactive"/>.
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
            return SetMetricLifecycle(experimentMetricId, LifecycleStage.Inactive, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
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
            return SetMetricLifecycleAsync(experimentMetricId, LifecycleStage.Active, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
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
            return SetMetricLifecycle(experimentMetricId, LifecycleStage.Active, ifMatch, cancellationToken);
        }

        private Response<ExperimentMetric> SetMetricLifecycle(
            string experimentMetricId,
            LifecycleStage lifecycle,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(experimentMetricId, nameof(experimentMetricId));
            Argument.AssertNotDefault(ref lifecycle, nameof(lifecycle));

            new ExperimentMetric().ToRequestContent();

            using var content = RequestContent.Create(new { lifecycle = lifecycle.ToString() });
            RequestContext context = FromCancellationToken(cancellationToken);
            var requestConditions = new RequestConditions { IfMatch = ifMatch };
            using Response response = CreateOrUpdateMetric(experimentMetricId, content, requestConditions, context);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }

        private async Task<Response<ExperimentMetric>> SetMetricLifecycleAsync(
            string experimentMetricId,
            LifecycleStage lifecycle,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(experimentMetricId, nameof(experimentMetricId));
            Argument.AssertNotDefault(ref lifecycle, nameof(lifecycle));

            using var content = RequestContent.Create(new { lifecycle = lifecycle.ToString() });
            RequestContext context = FromCancellationToken(cancellationToken);
            var requestConditions = new RequestConditions { IfMatch = ifMatch };
            using Response response = await CreateOrUpdateMetricAsync(experimentMetricId, content, requestConditions, context).ConfigureAwait(false);
            return Response.FromValue(ExperimentMetric.FromResponse(response), response);
        }
    }
}
