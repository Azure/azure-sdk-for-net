// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize healthcare entities in a document,
    /// containing a collection of the <see cref="DocumentHealthcareResult"/> objects
    /// identified in that document.
    /// </summary>
    public class RecognizeHealthcareEntititesResult : TextAnalyticsResult
    {
        private readonly DocumentHealthcareResult _result;

        internal RecognizeHealthcareEntititesResult(string id, TextDocumentStatistics statistics, DocumentHealthcareResult result)
            : base(id, statistics)
        {
            _result = result;
        }

        internal RecognizeHealthcareEntititesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of named entities identified in the document.
        /// </summary>
        public DocumentHealthcareResult Result
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _result;
            }
        }
    }
}
