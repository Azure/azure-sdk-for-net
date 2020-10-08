// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A condition used for anomaly detection. Using the value of a previously ingested data
    /// point as reference, sets bounds to specify the range in which data points are expected
    /// to be. Points with unexpected values will be considered an anomaly according to the
    /// rules set by the <see cref="SuppressCondition"/>.
    /// </summary>
    public partial class ChangeThresholdCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeThresholdCondition"/> class.
        /// </summary>
        /// <param name="changePercentage">Compared to the previous point, the current point is an anomaly if the percentage of change is more than this value. </param>
        /// <param name="shiftPoint">When set to N, sets as reference the data point that's N positions before the current point. Value must be at least 1.</param>
        /// <param name="isWithinRange">Sets whether to detect data within the range or outside the range.</param>
        /// <param name="anomalyDetectorDirection">A point is considered an anomaly only when the deviation occurs in the specified direction.</param>
        /// <param name="suppressCondition">The <see cref="Models.SuppressCondition"/> to be applied to every unexpected data point.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public ChangeThresholdCondition(double changePercentage, int shiftPoint, bool isWithinRange, AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            ChangePercentage = changePercentage;
            ShiftPoint = shiftPoint;
            IsWithinRange = isWithinRange;
            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// When set to N, sets as reference the data point that's N positions before the current
        /// point. Value must be at least 1.
        /// </summary>
        public int ShiftPoint { get; }

        /// <summary>
        /// Compared to the previous point, the current point is an anomaly if the percentage of change is more than this value.
        /// </summary>
        public double ChangePercentage { get; }

        /// <summary>
        /// Sets whether to detect data within the range or outside the range. If you want to detect fluctuations, select false.
        /// Sets whether to detect data within the range or outside the range. If you want to detect fluctuations, select false.
        /// If you want to detect flat lines in your data, select true.
        /// </summary>
        [CodeGenMember("WithinRange")]
        public bool IsWithinRange { get; }

        /// <summary>
        /// A point is considered an anomaly only when the deviation occurs in the specified direction.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every unexpected data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
