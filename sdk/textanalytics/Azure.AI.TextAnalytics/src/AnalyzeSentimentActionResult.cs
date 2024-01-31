// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the execution of an <see cref="AnalyzeSentimentAction"/> on the input documents.
    /// </summary>
    public class AnalyzeSentimentActionResult : TextAnalyticsActionResult
    {
        private readonly AnalyzeSentimentResultCollection _documentsResults;

        /// <summary>
        /// Successful action.
        /// </summary>
        internal AnalyzeSentimentActionResult(AnalyzeSentimentResultCollection result, string actionName, DateTimeOffset completedOn)
            : base(actionName, completedOn)
        {
            _documentsResults = result;
        }

        /// <summary>
        /// Action with an error.
        /// </summary>
        internal AnalyzeSentimentActionResult(string actionName, DateTimeOffset completedOn, Error error)
            : base(actionName, completedOn, error) { }

        /// <summary>
        /// Gets the result of the execution of an <see cref="AnalyzeSentimentAction"/> per each input document.
        /// </summary>
        public AnalyzeSentimentResultCollection DocumentsResults
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
