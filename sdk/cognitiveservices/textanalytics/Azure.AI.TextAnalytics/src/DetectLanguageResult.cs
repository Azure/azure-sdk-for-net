// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DetectLanguageResult : TextAnalysisResult
    {
        internal DetectLanguageResult(string id, TextDocumentStatistics statistics, IList<DetectedLanguage> detectedLanguages)
            : base(id, statistics)
        {
            DetectedLanguages = new ReadOnlyCollection<DetectedLanguage>(detectedLanguages);
        }

        internal DetectLanguageResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            DetectedLanguages = EmptyArray<DetectedLanguage>.Instance;
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<DetectedLanguage> DetectedLanguages { get; }

        /// <summary>
        /// </summary>
        public DetectedLanguage PrimaryLanguage => DetectedLanguages.OrderBy(l => l.Score).FirstOrDefault();
    }
}
