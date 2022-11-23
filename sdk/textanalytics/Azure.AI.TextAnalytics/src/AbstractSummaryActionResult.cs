// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing an <see cref="AbstractSummaryAction"/> on a given set of
    /// documents.
    /// </summary>
    public class AbstractSummaryActionResult : TextAnalyticsActionResult
    {
        private readonly AbstractSummaryResultCollection _documentsResults;

        /// <summary>
        /// Initializes a successful <see cref="AbstractSummaryActionResult"/>.
        /// </summary>
        internal AbstractSummaryActionResult(
            AbstractSummaryResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Initializes an <see cref="AbstractSummaryActionResult"/> with an error.
        /// </summary>
        internal AbstractSummaryActionResult(string actionName, DateTimeOffset completedOn, Error error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// The collection of results corresponding to each input document.
        /// </summary>
        public AbstractSummaryResultCollection DocumentsResults
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
