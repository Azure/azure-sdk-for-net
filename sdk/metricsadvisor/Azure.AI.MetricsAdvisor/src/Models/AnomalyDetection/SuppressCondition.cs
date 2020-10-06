// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Every time a time series ingests a new data point, the service takes a look at the latest
    /// points for that series. If the amount of unexpected points exceeds a specified threshold,
    /// then the latest point that caused this will be labeled as an anomaly. A <see cref="SuppressCondition"/>
    /// instance is used to configure this behavior.
    /// </summary>
    public partial class SuppressCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuppressCondition"/> class.
        /// </summary>
        /// <param name="minimumNumber">The amount of data points to consider when looking back on the previously ingested data. Must include the most recent point, so value must be at least 1.</param>
        /// <param name="minimumRatio">The minimum percentage of unexpected values that must be present in the latest ingested data points to detect an anomaly. Value is between (0, 100].</param>
        public SuppressCondition(int minimumNumber, double minimumRatio)
        {
            MinimumNumber = minimumNumber;
            MinimumRatio = minimumRatio;
        }

        /// <summary>
        /// The amount of data points to consider when looking back on the previously ingested data.
        /// Must include the most recent point, so value must be at least 1.
        /// </summary>
        [CodeGenMember("MinNumber")]
        public int MinimumNumber { get; }

        /// <summary>
        /// The minimum percentage of unexpected values that must be present in the latest ingested
        /// data points to detect an anomaly. Value is between (0, 100].
        /// </summary>
        [CodeGenMember("MinRatio")]
        public double MinimumRatio { get; }
    }
}
