// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Action result class for analyze sentiment result.
    /// </summary>
    public class AnalyzeSentimentActionResult : TextAnalyticsActionResult
    {
        internal AnalyzeSentimentActionResult(AnalyzeSentimentResultCollection result, DateTimeOffset completedOn, TextAnalyticsErrorInternal error) : base(completedOn, error)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result collection for analyze sentiment.
        /// </summary>
        public AnalyzeSentimentResultCollection Result { get; }
    }
}
