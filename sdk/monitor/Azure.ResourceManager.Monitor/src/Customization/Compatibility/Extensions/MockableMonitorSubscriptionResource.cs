// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorSubscriptionResource
    {
        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AlertRuleResource> GetAlertRules(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AlertRuleResource> GetAlertRulesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionMonitorMetric> GetMonitorMetrics(SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsAsync(SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics with POST. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPost(SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics with POST. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPostAsync(SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}
