// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DetectedLanguageResult : TextAnalysisResult
    {
        internal DetectedLanguageResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal DetectedLanguageResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<DetectedLanguage> DetectedLanguages { get; }

        /// <summary>
        /// </summary>
        public DetectedLanguage PrimaryLanguage => DetectedLanguages.OrderBy(l => l.Score).First();
    }
}
