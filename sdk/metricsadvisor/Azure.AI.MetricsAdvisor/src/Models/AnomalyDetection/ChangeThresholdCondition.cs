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
        /*
        /// <summary> Initializes a new instance of ChangeThresholdCondition. </summary>
        /// <param name="changePercentage"> change percentage, value range : [0, +∞). </param>
        /// <param name="shiftPoint"> shift point, value range : [1, +∞). </param>
        /// <param name="isWithinRange">
        /// if the withinRange = true, detected data is abnormal when the value falls in the range, in this case anomalyDetectorDirection must be Both
        ///
        /// if the withinRange = false, detected data is abnormal when the value falls out of the range.
        /// </param>
        /// <param name="anomalyDetectorDirection"> detection direction. </param>
        /// <param name="suppressCondition"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="suppressCondition"/> is null. </exception>
         */

        /// <summary>
        /// Creates a new instance of the <see cref="ChangeThresholdCondition"/> class.
        /// </summary>
        /// <param name="changePercentage">The relative change </param>
        /// <param name="shiftPoint">When set to N, sets as reference the data point that's N positions before the current point. Value must be at least 1.</param>
        /// <param name="isWithinRange"></param>
        /// <param name="anomalyDetectorDirection"></param>
        /// <param name="suppressCondition">Used to avoid outright labeling every single unexpected data point as an anomaly.</param>
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
        /// TODODOCS.
        /// The percentage of the value of the reference data point.
        /// The relative change to set boundaries around the value of the data point used as reference.
        /// </summary>
        public double ChangePercentage { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("WithinRange")]
        public bool IsWithinRange { get; }

        /// <summary>
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// Used to avoid outright labeling every single unexpected data point as an anomaly.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
