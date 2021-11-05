// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Normally used when metric values stay around a certain range. The threshold is set according to the percentage of change.
    /// The following scenarios are appropriate for this type of anomaly detection condition:
    /// <list type="bullet">
    ///   <item>Your data is normally stable and smooth. You want to be notified when there are fluctuations.</item>
    ///   <item>Your data is normally quite unstable and fluctuates a lot. You want to be notified when it becomes too stable or flat.</item>
    /// </list>
    /// </summary>
    public partial class ChangeThresholdCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeThresholdCondition"/> class.
        /// </summary>
        /// <param name="changePercentage">The percentage of change, compared to the previous point, that delimits the boundary for detecting anomalous points.</param>
        /// <param name="shiftPoint">When set to N, sets as reference the data point that's N positions before the current point. Value must be at least 1.</param>
        /// <param name="withinRange">
        /// If <c>true</c>, points inside the <paramref name="changePercentage"/> boundary are considered anomalous (ideal for detecting flat lines and stable values).
        /// If <c>false</c>, only points outside of the boundary can be considered anomalies (ideal for detecting fluctuations).
        /// </param>
        /// <param name="anomalyDetectorDirection">
        /// Sets the boundaries that delimit the expected value range. When <paramref name="withinRange"/> is <c>true</c>, can only
        /// be set to <see cref="AnomalyDetectorDirection.Both"/>. Otherwise, can only be set to <see cref="AnomalyDetectorDirection.Up"/>
        /// or <see cref="AnomalyDetectorDirection.Down"/>.
        /// </param>
        /// <param name="suppressCondition">The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public ChangeThresholdCondition(double changePercentage, int shiftPoint, bool withinRange, AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            ChangePercentage = changePercentage;
            ShiftPoint = shiftPoint;
            WithinRange = withinRange;
            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// When set to N, sets as reference the data point that's N positions before the current
        /// point. Value must be at least 1.
        /// </summary>
        public int ShiftPoint { get; set; }

        /// <summary>
        /// The percentage of change, compared to the previous point, that delimits the boundary for detecting anomalous points.
        /// </summary>
        public double ChangePercentage { get; set; }

        /// <summary>
        /// If <c>true</c>, points inside the <see cref="ChangePercentage"/> boundary are considered anomalous (ideal for detecting
        /// flat lines and stable values). If <c>false</c>, only points outside of the boundary can be considered anomalies (ideal
        /// for detecting fluctuations). See <see cref="AnomalyDetectorDirection"/> to check which boundaries are supported for each
        /// case.
        /// </summary>
        public bool WithinRange { get; set; }

        /// <summary>
        /// Sets the boundaries that delimit the expected value range. When <see cref="WithinRange"/> is <c>true</c>, can only
        /// be set to <see cref="AnomalyDetectorDirection.Both"/>. Otherwise, can only be set to
        /// <see cref="AnomalyDetectorDirection.Up"/> or <see cref="AnomalyDetectorDirection.Down"/>.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; set; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; set; }

        internal ChangeThresholdConditionPatch GetPatchModel() => new ChangeThresholdConditionPatch()
        {
            ShiftPoint = ShiftPoint,
            ChangePercentage = ChangePercentage,
            WithinRange = WithinRange,
            AnomalyDetectorDirection = AnomalyDetectorDirection,
            SuppressCondition = SuppressCondition?.GetPatchModel()
        };
    }
}
