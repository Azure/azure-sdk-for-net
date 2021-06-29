// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The <see cref="MetricFeedbackKind"/>. See each specific type for a description of each. </summary>
    [CodeGenModel("FeedbackType")]
    public readonly partial struct MetricFeedbackKind : IEquatable<MetricFeedbackKind>
    {
        /// <summary>
        /// Indicates that the point was incorrectly labeled by the service.
        /// You can specify whether a point should or shouldn't be an anomaly.
        /// </summary>
        public static MetricFeedbackKind Anomaly { get; } = new MetricFeedbackKind(AnomalyValue);

        /// <summary>
        /// Indicates that this is the start of a trend change.
        /// </summary>
        public static MetricFeedbackKind ChangePoint { get; } = new MetricFeedbackKind(ChangePointValue);

        /// <summary>
        /// Indicates that this is an interval of seasonality.
        /// </summary>
        public static MetricFeedbackKind Period { get; } = new MetricFeedbackKind(PeriodValue);

        /// <summary>
        /// A comment describing the reason this point is or is not an anomaly.
        /// </summary>
        public static MetricFeedbackKind Comment { get; } = new MetricFeedbackKind(CommentValue);
    }
}
