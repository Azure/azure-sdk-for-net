// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the detect language operation on a single document,
    /// containing a prediction of what language the document is written in.
    /// </summary>
    public class DetectLanguageResult : TextAnalyticsResult
    {
        private readonly DetectedLanguage _primaryLanguage;

        internal DetectLanguageResult(string id, TextDocumentStatistics statistics, DetectedLanguage detectedLanguage)
            : base(id, statistics)
        {
            _primaryLanguage = detectedLanguage;
        }

        internal DetectLanguageResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The primary language detected in the document.
        /// </summary>
        public DetectedLanguage PrimaryLanguage
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _primaryLanguage;
            }
        }
    }
}
