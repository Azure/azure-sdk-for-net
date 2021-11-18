// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sometimes it's inconvenient to treat every data point outside of an expected range as an anomaly. Transient
    /// fluctuations may occur depending on the nature of the data being monitored. A suppress condition makes it
    /// possible to ignore an initial group of anomalous points, treating them as normal, and start detecting
    /// anomalies only when a specified threshold is exceeded. As soon as a new anomalous data point is detected,
    /// the service peeks at the latest ingested points of the time series it belongs. If the amount of anomalous
    /// points exceed a specified ratio, the current point will be labeled as an anomaly.
    /// </summary>
    public partial class SuppressCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuppressCondition"/> class.
        /// </summary>
        /// <param name="minimumNumber">
        /// The amount of data points to peek at when looking back on the previously ingested data.
        /// Must include the most recent point, so value must be at least 1.
        /// </param>
        /// <param name="minimumRatio">
        /// The minimum percentage of anomalous values that must be present in the latest ingested data
        /// points to consider the current point an anomaly. Value is between (0, 100].
        /// </param>
        public SuppressCondition(int minimumNumber, double minimumRatio)
        {
            MinimumNumber = minimumNumber;
            MinimumRatio = minimumRatio;
        }

        /// <summary>
        /// The amount of data points to peek at when looking back on the previously ingested data.
        /// Must include the most recent point, so value must be at least 1.
        /// </summary>
        [CodeGenMember("MinNumber")]
        public int MinimumNumber { get; set; }

        /// <summary>
        /// The minimum percentage of anomalous values that must be present in the latest ingested
        /// data points to consider the current point an anomaly. Value is between (0, 100].
        /// </summary>
        [CodeGenMember("MinRatio")]
        public double MinimumRatio { get; set; }

        internal SuppressConditionPatch GetPatchModel() => new SuppressConditionPatch()
        {
            MinNumber = MinimumNumber,
            MinRatio = MinimumRatio
        };
    }
}
