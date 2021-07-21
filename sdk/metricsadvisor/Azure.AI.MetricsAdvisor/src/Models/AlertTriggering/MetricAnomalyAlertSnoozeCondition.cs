// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Stops alerts temporarily once an alert is triggered. Used to avoid alert spamming.
    /// </summary>
    [CodeGenModel("AlertSnoozeCondition")]
    public partial class MetricAnomalyAlertSnoozeCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricAnomalyAlertSnoozeCondition"/> class.
        /// </summary>
        /// <param name="autoSnooze">The number of data points to be ingested before alerts are enabled again.</param>
        /// <param name="snoozeScope">Defines the set of time series to which this <see cref="MetricAnomalyAlertSnoozeCondition"/> applies.</param>
        /// <param name="isOnlyForSuccessive">If <c>true</c>, snoozing will stop as soon as a data point that's not an anomaly is found. If <c>false</c>, snoozing only stops when the amount of points specified by <paramref name="autoSnooze"/> have been ingested.</param>
        public MetricAnomalyAlertSnoozeCondition(int autoSnooze, SnoozeScope snoozeScope, bool isOnlyForSuccessive)
        {
            AutoSnooze = autoSnooze;
            SnoozeScope = snoozeScope;
            IsOnlyForSuccessive = isOnlyForSuccessive;
        }

        /// <summary>
        /// Defines the set of time series to which this <see cref="MetricAnomalyAlertSnoozeCondition"/>
        /// applies.
        /// </summary>
        public SnoozeScope SnoozeScope { get; set; }

        /// <summary>
        /// The number of data points to be ingested before alerts are enabled again.
        /// </summary>
        public int AutoSnooze { get; set; }

        /// <summary>
        /// If <c>true</c>, snoozing will stop as soon as a data point that's not an anomaly is found.
        /// If <c>false</c>, snoozing only stops when the amount of points specified by <see cref="AutoSnooze"/>
        /// have been ingested.
        /// </summary>
        [CodeGenMember("OnlyForSuccessive")]
        public bool IsOnlyForSuccessive { get; set; }
    }
}
