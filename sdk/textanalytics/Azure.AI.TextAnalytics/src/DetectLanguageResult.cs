// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the detect language operation on a single document,
    /// containing a prediction of what language the document is written in.
    /// </summary>
    public class DetectLanguageResult : TextAnalyticsResult
    {
        internal DetectLanguageResult(string id, TextDocumentStatistics statistics, IList<DetectedLanguage> detectedLanguages)
            : base(id, statistics)
        {
            DetectedLanguages = new ReadOnlyCollection<DetectedLanguage>(detectedLanguages);
        }

        internal DetectLanguageResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            DetectedLanguages = Array.Empty<DetectedLanguage>();
        }

        /// <summary>
        /// Gets a collection of languages detected in the document.  This value
        /// contains a single language.
        /// </summary>
        public IReadOnlyCollection<DetectedLanguage> DetectedLanguages { get; }

        /// <summary>
        /// The primary language detected in the document.
        /// </summary>
        public DetectedLanguage PrimaryLanguage => DetectedLanguages.OrderBy(l => l.Score).FirstOrDefault();
    }
}
