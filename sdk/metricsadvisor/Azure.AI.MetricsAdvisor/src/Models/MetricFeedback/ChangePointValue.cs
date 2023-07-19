// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Used by <see cref="MetricChangePointFeedback"/> to indicate whether or not a set of data points should
    /// be considered change points by the service.
    /// </summary>
    public readonly partial struct ChangePointValue
    {
        /// <summary>
        /// Tells the service to disregard any previous change point feedback given to the set of data
        /// points affected.
        /// </summary>
        public static ChangePointValue AutoDetect { get; } = new ChangePointValue(AutoDetectValue);

        /// <summary>
        /// The data points should have been labeled as change points.
        /// </summary>
        public static ChangePointValue ChangePoint { get; } = new ChangePointValue(ChangePointValue1);

        /// <summary>
        /// The data points should not have been labeled as change points.
        /// </summary>
        public static ChangePointValue NotChangePoint { get; } = new ChangePointValue(NotChangePointValue);
    }
}
