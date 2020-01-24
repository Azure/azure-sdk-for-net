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
        // TODO: clean this up.
        private DetectedLanguage _predictedLanguage;

        internal DetectLanguageResult(string id, TextDocumentStatistics statistics, IList<DetectedLanguage> detectedLanguages)
            : base(id, statistics)
        {
            _predictedLanguage = detectedLanguages.OrderBy(l => l.Score).FirstOrDefault();
        }

        internal DetectLanguageResult(string id, TextAnalyticsError error)
            : base(id, error)
        {
        }

        /// <summary>
        /// The primary language detected in the document.
        /// </summary>
        public DetectedLanguage PredictedLanguage
        {
            get
            {
                if (Error.ErrorCode != default)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for this document, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _predictedLanguage;
            }
        }
    }
}
