// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets fixed upper and/or lower bounds to specify the range in which a data point is allowed to be.
    /// Points out the specified range can be included in an alert.
    /// </summary>
    [CodeGenModel("ValueCondition")]
    public partial class MetricBoundaryCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricBoundaryCondition"/> class.
        /// </summary>
        /// <param name="direction">
        /// Sets the boundaries that delimit the expected value range of a <see cref="MetricBoundaryCondition"/>. Data points out
        /// of this range can be included in an alert. If <see cref="BoundaryDirection.Down"/> or
        /// <see cref="BoundaryDirection.Both"/>, <see cref="LowerBound"/> is required. If <see cref="BoundaryDirection.Up"/> or
        /// <see cref="BoundaryDirection.Both"/>, <see cref="UpperBound"/> is required.
        /// </param>
        public MetricBoundaryCondition(BoundaryDirection direction)
        {
            Direction = direction;
        }

        /// <summary>
        /// Sets the boundaries that delimit the expected value range of a <see cref="MetricBoundaryCondition"/>. Data points out
        /// of this range can be included in an alert. If <see cref="BoundaryDirection.Down"/> or
        /// <see cref="BoundaryDirection.Both"/>, <see cref="LowerBound"/> is required. If <see cref="BoundaryDirection.Up"/> or
        /// <see cref="BoundaryDirection.Both"/>, <see cref="UpperBound"/> is required.
        /// </summary>
        public BoundaryDirection Direction { get; set; }

        /// <summary>
        /// The minimum value of the boundary where a data point is allowed to be. If below this value, the point can be
        /// included in an alert. Must be set if <see cref="Direction"/> is <see cref="BoundaryDirection.Down"/> or
        /// <see cref="BoundaryDirection.Both"/>.
        /// </summary>
        [CodeGenMember("Lower")]
        public double? LowerBound { get; set; }

        /// <summary>
        /// The maximum value of the boundary where a data point is allowed to be. If above this value, the point can be
        /// included in an alert. Must be set if <see cref="Direction"/> is <see cref="BoundaryDirection.Up"/> or
        /// <see cref="BoundaryDirection.Both"/>.
        /// </summary>
        [CodeGenMember("Upper")]
        public double? UpperBound { get; set; }

        /// <summary>
        /// If set, this <see cref="MetricBoundaryCondition"/> will make use of the value of another metric, specified
        /// by this ID, when checking boundaries. A data point of the companion metric with same dimensions and same
        /// timestamp will be used instead and, if out of range, the current data point can be included in an alert.
        /// You can set the property <see cref="ShouldAlertIfDataPointMissing"/> to tell the service what to do when
        /// the data point in the companion metric is missing.
        /// </summary>
        [CodeGenMember("MetricId")]
        public string CompanionMetricId { get; set; }

        /// <summary>
        /// This property can be used when <see cref="CompanionMetricId"/> is defined to tell the service what to do when
        /// the data point in the companion metric is missing. If <c>true</c>, the current point can still be included in
        /// an alert when the data point in the companion metric is missing. If <c>false</c>, the current point won't be
        /// included. Defaults to <c>false</c>.
        /// </summary>
        [CodeGenMember("TriggerForMissing")]
        public bool? ShouldAlertIfDataPointMissing { get; set; }

        /// <summary>
        /// Specifies which measure should be used when checking boundaries. Defaults to
        /// <see cref="BoundaryMeasureType.Value"/>.
        /// </summary>
        [CodeGenMember("Type")]
        public BoundaryMeasureType? MeasureType { get; set; }
    }
}
