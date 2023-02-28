// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing an <see cref="ExtractiveSummarizeAction"/> on a given set of
    /// documents.
    /// </summary>
    public class ExtractiveSummarizeActionResult : TextAnalyticsActionResult
    {
        private readonly ExtractiveSummarizeResultCollection _documentsResults;

        /// <summary>
        /// Initializes a successful <see cref="ExtractiveSummarizeActionResult"/>.
        /// </summary>
        internal ExtractiveSummarizeActionResult(
            ExtractiveSummarizeResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Initializes an <see cref="ExtractiveSummarizeActionResult"/> with an error.
        /// </summary>
        internal ExtractiveSummarizeActionResult(string actionName, DateTimeOffset completedOn, Error error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// The collection of results corresponding to each input document.
        /// </summary>
        public ExtractiveSummarizeResultCollection DocumentsResults
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
