// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS: properties need clarification.
    /// <summary>
    /// </summary>
    public partial class SmartDetectionCondition
    {
        /// <summary>
        /// Creates a new instance of the <see cref="HardThresholdCondition"/> class.
        /// </summary>
        /// <param name="sensitivity"> sensitivity, value range : (0, 100]. </param>
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
        /// </summary>
        public double Sensitivity { get; }

        /// <summary>
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// The <see cref="Models.SuppressCondition"/> to be applied to every unexpected data point.
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
