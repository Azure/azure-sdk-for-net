// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// TODODOCS.
    /// </summary>
    public partial class SmartDetectionCondition
    {
        /// <summary>
        /// Creates a new instance of the <see cref="HardThresholdCondition"/> class.
        /// </summary>
        /// <param name="sensitivity"> sensitivity, value range : (0, 100]. </param>
        /// <param name="anomalyDetectorDirection"> detection direction. </param>
        /// <param name="suppressCondition">Used to avoid outright labeling every single unexpected data point as an anomaly.</param>
        /// <exception cref="ArgumentNullException"><paramref name="suppressCondition"/> is null.</exception>
        public SmartDetectionCondition(double sensitivity, AnomalyDetectorDirection anomalyDetectorDirection, SuppressCondition suppressCondition)
        {
            Argument.AssertNotNull(suppressCondition, nameof(suppressCondition));

            Sensitivity = sensitivity;
            AnomalyDetectorDirection = anomalyDetectorDirection;
            SuppressCondition = suppressCondition;
        }

        /// <summary>
        /// </summary>
        public double Sensitivity { get; }

        /// <summary>
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// Used to avoid outright labeling every single unexpected data point as an anomaly.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
