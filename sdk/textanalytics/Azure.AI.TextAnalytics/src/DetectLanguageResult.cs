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
        internal DetectLanguageResult(string id, TextDocumentStatistics statistics, DetectedLanguage detectedLanguage)
            : base(id, statistics)
        {
            PrimaryLanguage = detectedLanguage;
        }

        internal DetectLanguageResult(string id, string errorMessage) : base(id, errorMessage) { }

        /// <summary>
        /// The primary language detected in the document.
        /// </summary>
        public DetectedLanguage PrimaryLanguage { get; }
    }
}
