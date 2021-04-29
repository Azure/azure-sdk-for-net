// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The <see cref="FeedbackType"/>. See each specific type for a description of each. </summary>
    public readonly partial struct FeedbackType : IEquatable<FeedbackType>
    {
        /// <summary>
        /// Indicates that the point was incorrectly labeled by the service.
        /// You can specify whether a point should or shouldn't be an anomaly.
        /// </summary>
        public static FeedbackType Anomaly { get; } = new FeedbackType(AnomalyValue);

        /// <summary>
        /// Indicates that this is the start of a trend change.
        /// </summary>
        public static FeedbackType ChangePoint { get; } = new FeedbackType(ChangePointValue);

        /// <summary>
        /// Indicates that this is an interval of seasonality.
        /// </summary>
        public static FeedbackType Period { get; } = new FeedbackType(PeriodValue);

        /// <summary>
        /// A comment describing the reason this point is or is not an anomaly.
        /// </summary>
        public static FeedbackType Comment { get; } = new FeedbackType(CommentValue);
    }
}
