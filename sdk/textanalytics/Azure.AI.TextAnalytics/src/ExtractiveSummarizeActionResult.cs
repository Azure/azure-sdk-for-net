// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the execution of an <see cref="ExtractiveSummarizeAction"/> on the input documents.
    /// </summary>
    public class ExtractiveSummarizeActionResult : TextAnalyticsActionResult
    {
        private readonly ExtractiveSummarizeResultCollection _documentsResults;

        /// <summary>
        /// Successful action.
        /// </summary>
        internal ExtractiveSummarizeActionResult(ExtractiveSummarizeResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Action with an error.
        /// </summary>
        internal ExtractiveSummarizeActionResult(string actionName, DateTimeOffset completedOn, Error error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// Gets the result of the execution of an <see cref="ExtractiveSummarizeAction"/> per each input document.
        /// </summary>
        public ExtractiveSummarizeResultCollection DocumentsResults
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access the results of this action, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _documentsResults;
            }
        }
    }
}
