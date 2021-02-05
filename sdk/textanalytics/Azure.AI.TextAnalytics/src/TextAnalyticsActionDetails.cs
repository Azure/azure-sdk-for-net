// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// TextAnalyticsActionDetails.
    /// </summary>
    public class TextAnalyticsActionDetails
    {
        /// <summary>
        /// TextAnalyticsActionDetails
        /// </summary>
        internal TextAnalyticsActionDetails (DateTimeOffset completedOn, TextAnalyticsErrorInternal error, bool hasError)
        {
            CompletedOn = completedOn;
            Errors = hasError ? Transforms.ConvertToError(error) : default;
            HasError = hasError;
        }

        /// <summary>
        /// CompletedOn
        /// </summary>
        public DateTimeOffset CompletedOn { get; }

        /// <summary>
        /// Error
        /// </summary>
        public TextAnalyticsError Errors { get; }

        /// <summary>
        /// HasError
        /// </summary>
        public bool HasError { get; }
    }
}
