// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A condition used for anomaly detection. Sets fixed upper and/or lower bounds to specify
    /// the range in which data points are expected to be. Points with unexpected values will be
    /// considered an anomaly according to the rules set by the <see cref="SuppressCondition"/>.
    /// </summary>
    public partial class HardThresholdCondition
    {
        /// <summary>
        /// Creates a new instance of the <see cref="HardThresholdCondition"/> class.
        /// </summary>
        /// <param name="anomalyDetectorDirection">The direction of the specified boundaries. Depending on its value, <see cref="LowerBound"/> and/or <see cref="UpperBound"/> may be required.</param>
        /// <param name="suppressCondition">Used to avoid outright labeling every single unexpected data point as an anomaly.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public HardThresholdCondition(AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// The direction of the specified boundaries. Depending on its value, <see cref="LowerBound"/>
        /// and/or <see cref="UpperBound"/> may be required.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// Used to avoid outright labeling every single unexpected data point as an anomaly.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }

        /// <summary>
        /// The minimum value a data point is expected to assume. Must be set if <see cref="AnomalyDetectorDirection"/>
        /// is <see cref="AnomalyDetectorDirection.Down"/> or <see cref="AnomalyDetectorDirection.Both"/>.
        /// </summary>
        public double? LowerBound { get; set; }

        /// <summary>
        /// The maximum value a data point is expected to assume. Must be set if <see cref="AnomalyDetectorDirection"/>
        /// is <see cref="AnomalyDetectorDirection.Up"/> or <see cref="AnomalyDetectorDirection.Both"/>.
        /// </summary>
        public double? UpperBound { get; set; }
    }
}
