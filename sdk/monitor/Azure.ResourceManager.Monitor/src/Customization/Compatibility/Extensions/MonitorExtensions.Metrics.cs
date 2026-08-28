// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public static partial class MonitorExtensions
    {
        /// <summary> Gets metric baselines for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselines(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMonitorArmClient(client).GetMonitorMetricBaselines(scope, options, cancellationToken);
        }

        /// <summary> Gets metric baselines for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMonitorArmClient(client).GetMonitorMetricBaselinesAsync(scope, options, cancellationToken);
        }

        /// <summary> Gets metrics for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MonitorMetric> GetMonitorMetrics(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMonitorArmClient(client).GetMonitorMetrics(scope, options, cancellationToken);
        }

        /// <summary> Gets metrics for a resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MonitorMetric> GetMonitorMetricsAsync(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableMonitorArmClient(client).GetMonitorMetricsAsync(scope, options, cancellationToken);
        }
    }
}
