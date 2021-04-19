// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Stores the details for the AnalyzeBatchActionsOperation class.
    /// </summary>
    public class TextAnalyticsActionDetails
    {
        /// <summary>
        /// Initializes the TextAnalyticsActionDetails class by initializing CompletedOn, Error and HasError properties.
        /// </summary>
        internal TextAnalyticsActionDetails (DateTimeOffset completedOn, TextAnalyticsErrorInternal error)
        {
            CompletedOn = completedOn;
            Error = error != null ? Transforms.ConvertToError(error) : default;
        }

        /// <summary>
        /// Indicates the time at which the action was last updated on.
        /// </summary>
        public DateTimeOffset CompletedOn { get; }

        /// <summary>
        /// Determines the TextAnalyticsError object for an action result.
        /// </summary>
        public TextAnalyticsError Error { get; }

        /// <summary>
        /// Indicates that the document was not successfully processed and an error was returned for this document.
        /// </summary>
        public bool HasError => Error.ErrorCode != default;
    }
}
