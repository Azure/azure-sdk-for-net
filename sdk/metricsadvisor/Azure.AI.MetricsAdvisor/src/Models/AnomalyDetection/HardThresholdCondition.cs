// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets fixed upper and/or lower bounds to specify the range in which data points are expected to be.
    /// Values outside of upper or lower bounds will be considered to be anomalous.
    /// </summary>
    public partial class HardThresholdCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HardThresholdCondition"/> class.
        /// </summary>
        /// <param name="anomalyDetectorDirection">
        /// Sets the boundaries that delimit the expected value range. Data points out of this range are considered anomalous.
        /// If <see cref="AnomalyDetectorDirection.Down"/> or <see cref="AnomalyDetectorDirection.Both"/>, <see cref="LowerBound"/>
        /// is required. If <see cref="AnomalyDetectorDirection.Up"/> or <see cref="AnomalyDetectorDirection.Both"/>,
        /// <see cref="UpperBound"/> is required.
        /// </param>
        /// <param name="suppressCondition">The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public HardThresholdCondition(AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// Sets the boundaries that delimit the expected value range. Data points out of this range are considered anomalous.
        /// If <see cref="AnomalyDetectorDirection.Down"/> or <see cref="AnomalyDetectorDirection.Both"/>, <see cref="LowerBound"/>
        /// is required. If <see cref="AnomalyDetectorDirection.Up"/> or <see cref="AnomalyDetectorDirection.Both"/>,
        /// <see cref="UpperBound"/> is required.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; set; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; set; }

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

        internal HardThresholdConditionPatch GetPatchModel() => new HardThresholdConditionPatch()
        {
            AnomalyDetectorDirection = AnomalyDetectorDirection,
            SuppressCondition = SuppressCondition?.GetPatchModel(),
            LowerBound = LowerBound,
            UpperBound = UpperBound
        };
    }
}
