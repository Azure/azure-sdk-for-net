// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A detection condition powered by machine learning that learns patterns from historical data, and uses them for future detection.
    /// </summary>
    public partial class SmartDetectionCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartDetectionCondition"/> class.
        /// </summary>
        /// <param name="sensitivity">
        /// A numerical value to adjust the tolerance of the anomaly detection with a range of (0, 100].
        /// It affects the width of the expected value range of each point. When increased, the expected
        /// value range will be tighter, and more anomalies will be reported. When turned down, the expected
        /// value range will be wider, and fewer anomalies will be reported.
        /// </param>
        /// <param name="anomalyDetectorDirection">Sets the boundaries that delimit the expected value range. Data points out of this range are considered anomalous.</param>
        /// <param name="suppressCondition">The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public SmartDetectionCondition(double sensitivity, AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            Sensitivity = sensitivity;
            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// A numerical value to adjust the tolerance of the anomaly detection with a range of (0, 100].
        /// It affects the width of the expected value range of each point. When increased, the expected
        /// value range will be tighter, and more anomalies will be reported. When turned down, the expected
        /// value range will be wider, and fewer anomalies will be reported.
        /// </summary>
        public double Sensitivity { get; set; }

        /// <summary>
        /// Sets the boundaries that delimit the expected value range. Data points out of this range are considered anomalous.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; set; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every anomalous data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; set; }

        internal SmartDetectionConditionPatch GetPatchModel() => new SmartDetectionConditionPatch()
        {
            Sensitivity = Sensitivity,
            AnomalyDetectorDirection = AnomalyDetectorDirection,
            SuppressCondition = SuppressCondition?.GetPatchModel()
        };
    }
}
