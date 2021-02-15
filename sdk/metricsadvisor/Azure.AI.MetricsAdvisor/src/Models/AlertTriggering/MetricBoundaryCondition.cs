// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets fixed upper and/or lower bounds to specify the range in which a data point must be
    /// to be able to trigger alerts.
    /// </summary>
    [CodeGenModel("ValueCondition")]
    public partial class MetricBoundaryCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricBoundaryCondition"/> class.
        /// </summary>
        /// <param name="direction">The direction of the specified boundaries. Depending on its value, <see cref="LowerBound"/> and/or <see cref="UpperBound"/> may be required.</param>
        public MetricBoundaryCondition(BoundaryDirection direction)
        {
            Direction = direction;
        }

        /// <summary>
        /// The direction of the specified boundaries. Depending on its value, <see cref="LowerBound"/>
        /// and/or <see cref="UpperBound"/> may be required.
        /// </summary>
        public BoundaryDirection Direction { get; set; }

        /// <summary>
        /// The minimum value a data point can assume to be able to trigger an alert. Must be set if
        /// <see cref="Direction"/> is <see cref="AnomalyDetectorDirection.Down"/> or
        /// <see cref="AnomalyDetectorDirection.Both"/>.
        /// </summary>
        [CodeGenMember("Lower")]
        public double? LowerBound { get; set; }

        /// <summary>
        /// The maximum value a data point can assume to be able to trigger an alert. Must be set if
        /// <see cref="Direction"/> is <see cref="AnomalyDetectorDirection.Up"/> or
        /// <see cref="AnomalyDetectorDirection.Both"/>.
        /// </summary>
        [CodeGenMember("Upper")]
        public double? UpperBound { get; set; }

        /// <summary>
        /// If set, this <see cref="MetricBoundaryCondition"/> will make use of the value of another
        /// metric, specified by this ID, when checking boundaries.
        /// </summary>
        [CodeGenMember("MetricId")]
        public string CompanionMetricId { get; set; }

        /// <summary>
        /// This property must be set if <see cref="CompanionMetricId"/> is defined. If <c>true</c>,
        /// an alert should be triggered if the targeted metric is missing for the current timestamp.
        /// If <c>false</c>, no action is taken in this scenario.
        /// </summary>
        public bool? TriggerForMissing { get; set; }
    }
}
