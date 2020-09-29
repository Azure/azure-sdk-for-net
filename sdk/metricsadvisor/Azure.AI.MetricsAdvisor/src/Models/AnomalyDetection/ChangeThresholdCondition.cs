// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public partial class ChangeThresholdCondition
    {
        /// <summary>
        /// </summary>
        public AnomalyDetectorDirection AnomalyDetectorDirection { get; }

        /// <summary>
        /// </summary>
        public double ChangePercentage { get; }

        /// <summary>
        /// </summary>
        public int ShiftPoint { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("WithinRange")]
        public bool IsWithinRange { get; }

        /// <summary>
        /// </summary>
        public SuppressCondition SuppressCondition { get; }
    }
}
