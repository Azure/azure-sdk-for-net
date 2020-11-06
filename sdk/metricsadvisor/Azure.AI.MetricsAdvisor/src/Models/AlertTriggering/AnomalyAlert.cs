// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The properties of a triggered alert. An alert is triggered according to the rules set by an
    /// <see cref="AnomalyAlertConfiguration"/>.
    /// </summary>
    [CodeGenModel("AlertResult")]
    public partial class AnomalyAlert
    {
        /// <summary>
        /// The unique identifier of this alert.
        /// </summary>
        [CodeGenMember("AlertId")]
        public string Id { get; }

        /// <summary>
        /// The timestamp, in UTC, of the data points that triggered this alert, as described by
        /// the <see cref="DataFeed"/>.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The date and time, in UTC, in which this alert entry has been created.
        /// </summary>
        public DateTimeOffset CreatedTime { get; }

        /// <summary>
        /// The date and time, in UTC, in which this alert entry has been modified for the last time.
        /// </summary>
        public DateTimeOffset ModifiedTime { get; }
    }
}
