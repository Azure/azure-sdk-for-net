// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class ExperimentMetrics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentMetrics"/> class.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metric"/> parameter is null.</exception>
        public virtual async Task<ExperimentMetric> CreateOrUpdateAsync(
            string experimentMetricId,
            ExperimentMetric metric,
            CancellationToken cancellationToken = default)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

            using var content = RequestContent.Create(metric);
            var context = new RequestContext { CancellationToken = cancellationToken };
            var requestConditions = new RequestConditions
            {
                IfMatch = metric.ETag != default ? metric.ETag : null
            };

            using Response response = await CreateOrUpdateAsync(experimentMetricId, content, requestConditions, context).ConfigureAwait(false);

            var expermentMetric = ExperimentMetric.FromResponse(response);

            return expermentMetric;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentMetrics"/> class.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="metric"> A ExperimentMetric object that describes the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="metric"/> parameter is null.</exception>
        public virtual ExperimentMetric CreateOrUpdate(
            string experimentMetricId,
            ExperimentMetric metric,
            CancellationToken cancellationToken = default)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

            using var content = RequestContent.Create(metric);
            var context = new RequestContext { CancellationToken = cancellationToken };
            var requestConditions = new RequestConditions
            {
                IfMatch = metric.ETag != default ? metric.ETag : null
            };

            using Response response = CreateOrUpdate(experimentMetricId, content, requestConditions, context);

            var expermentMetric = ExperimentMetric.FromResponse(response);

            return expermentMetric;
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Inactive"/>.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        public virtual async Task DeactivateMetricAsync(string experimentMetricId, CancellationToken cancellationToken = default)
        {
            using var content = RequestContent.Create(new ExperimentMetric { Lifecycle = LifecycleStage.Inactive });
            var requestConditions = new RequestConditions { IfMatch = ETag.All };
            var context = new RequestContext { CancellationToken = cancellationToken };
            await CreateOrUpdateAsync(experimentMetricId, content, requestConditions, context).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Inactive"/>.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        public virtual void DeactivateMetric(string experimentMetricId, CancellationToken cancellationToken = default)
        {
            using var content = RequestContent.Create(new ExperimentMetric { Lifecycle = LifecycleStage.Inactive });
            var requestConditions = new RequestConditions { IfMatch = ETag.All };
            var context = new RequestContext { CancellationToken = cancellationToken };
            CreateOrUpdate(experimentMetricId, content, requestConditions, context);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        /// <returns>An awaitable task.</returns>
        public virtual async Task ActivateMetricAsync(string experimentMetricId, CancellationToken cancellationToken = default)
        {
            using var content = RequestContent.Create(new ExperimentMetric { Lifecycle = LifecycleStage.Active });
            var requestConditions = new RequestConditions { IfMatch = ETag.All };
            var context = new RequestContext { CancellationToken = cancellationToken };
            await CreateOrUpdateAsync(experimentMetricId, content, requestConditions, context).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an existing metric setting <see cref="ExperimentMetric.Lifecycle"/> to <see cref="LifecycleStage.Active"/>.
        /// </summary>
        /// <param name="experimentMetricId"> An ID used to uniquely identify and reference the metric. </param>
        /// <param name="cancellationToken"> The token to check for cancellation. </param>
        public virtual void ActivateMetric(string experimentMetricId, CancellationToken cancellationToken = default)
        {
            using var content = RequestContent.Create(new ExperimentMetric { Lifecycle = LifecycleStage.Active });
            var requestConditions = new RequestConditions { IfMatch = ETag.All };
            var context = new RequestContext { CancellationToken = cancellationToken };
            CreateOrUpdate(experimentMetricId, content, requestConditions, context);
        }
    }
}
