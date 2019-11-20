// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextAnalysisResult
    {
        internal TextAnalysisResult(string id, TextDocumentStatistics statistics)
        {
            Details = new TextAnalysisResultDetails(id, statistics);
        }

        internal TextAnalysisResult(string id, string errorMessage)
        {
            Details = new TextAnalysisResultDetails(id, errorMessage);
        }

        /// <summary>
        /// </summary>
        public TextAnalysisResultDetails Details { get; }
    }
}
