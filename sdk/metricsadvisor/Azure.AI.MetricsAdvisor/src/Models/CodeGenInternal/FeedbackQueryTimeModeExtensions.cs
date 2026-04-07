// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor
{
    internal static partial class FeedbackQueryTimeModeExtensions
    {
        public static string ToSerialString(this FeedbackQueryTimeMode value) => value switch
        {
            FeedbackQueryTimeMode.None => null,
            FeedbackQueryTimeMode.MetricTimestamp => "MetricTimestamp",
            FeedbackQueryTimeMode.FeedbackCreatedOn => "FeedbackCreatedTime",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FeedbackQueryTimeMode value.")
        };
    }
}
