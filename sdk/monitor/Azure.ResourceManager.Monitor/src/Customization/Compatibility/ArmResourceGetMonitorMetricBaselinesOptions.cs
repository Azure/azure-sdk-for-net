// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy options for getting monitor metric baselines for an ARM resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ArmResourceGetMonitorMetricBaselinesOptions
    {
        /// <summary> The aggregation to use. </summary>
        public string Aggregation { get; set; }

        /// <summary> The filter to apply. </summary>
        public string Filter { get; set; }

        /// <summary> The interval to use. </summary>
        public TimeSpan? Interval { get; set; }

        /// <summary> The metric names. </summary>
        public string Metricnames { get; set; }

        /// <summary> The metric namespace. </summary>
        public string Metricnamespace { get; set; }

        /// <summary> The result type. </summary>
        public MonitorResultType? ResultType { get; set; }

        /// <summary> The sensitivities to use. </summary>
        public string Sensitivities { get; set; }

        /// <summary> The timespan to query. </summary>
        public string Timespan { get; set; }
    }
}
