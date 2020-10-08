// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Anomaly detection using multiple machine learning algorithms.
    /// </summary>
    public partial class SmartDetectionCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HardThresholdCondition"/> class.
        /// </summary>
        /// <param name="sensitivity">
        /// A numerical value to adjust the tolerance of the anomaly detection with a range of (0, 100].
        /// Visually, the higher the value, the narrower the upper and lower boundaries around the time series.
        /// </param>
        /// <param name="anomalyDetectorDirection"> detection direction. </param>
        /// <param name="suppressCondition">The <see cref="Models.SuppressCondition"/> to be applied to every unexpected data point.</param>
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
        /// Visually, the higher the value, the narrower the upper and lower boundaries around the time series.
        /// </summary>
        public double Sensitivity { get; }

        /// <summary>
        /// A point is an anomaly only when the deviation occurs in the specified direction.
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every unexpected data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
