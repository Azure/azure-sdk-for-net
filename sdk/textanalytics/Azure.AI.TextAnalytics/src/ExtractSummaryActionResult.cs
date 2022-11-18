// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing an <see cref="ExtractSummaryAction"/> on a given set of
    /// documents.
    /// </summary>
    public class ExtractSummaryActionResult : TextAnalyticsActionResult
    {
        private readonly ExtractSummaryResultCollection _documentsResults;

        /// <summary>
        /// Initializes a successful <see cref="ExtractSummaryActionResult"/>.
        /// </summary>
        internal ExtractSummaryActionResult(
            ExtractSummaryResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Initializes an <see cref="ExtractSummaryActionResult"/> with an error.
        /// </summary>
        internal ExtractSummaryActionResult(string actionName, DateTimeOffset completedOn, Error error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// The collection of results corresponding to each input document.
        /// </summary>
        public ExtractSummaryResultCollection DocumentsResults
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException(
                        $"Cannot access the results of this action, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _documentsResults;
            }
        }
    }
}
