// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public partial class HardThresholdCondition
    {
        /// <summary>
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
