// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("ValueCondition")]
    public partial class MetricBoundaryCondition
    {
        /// <summary>
        /// </summary>
        public BoundaryDirection Direction { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("Lower")]
        public double? LowerBound { get; set; }

        /// <summary>
        /// </summary>
        [CodeGenMember("Upper")]
        public double? UpperBound { get; set; }

        /// <summary>
        /// </summary>
        [CodeGenMember("MetricId")]
        public string CompanionMetricId { get; set; }
    }
}
