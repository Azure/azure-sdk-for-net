// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class ExtractKeyPhrasesResult : TextAnalysisResult
    {
        internal ExtractKeyPhrasesResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal ExtractKeyPhrasesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<string> KeyPhrases { get; }
    }
}
