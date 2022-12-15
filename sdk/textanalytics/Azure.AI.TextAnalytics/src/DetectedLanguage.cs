// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A prediction of the language in which a document is written in.
    /// </summary>
    public readonly struct DetectedLanguage
    {
        internal DetectedLanguage(DetectedLanguageInternal language, IList<TextAnalyticsWarning> warnings)
            : this(language.Name, language.Iso6391Name, language.ConfidenceScore, language.Script, warnings)
        {
        }

        internal DetectedLanguage(string name, string iso6391Name, double confidenceScore, ScriptKind? script, IList<TextAnalyticsWarning> warnings)
        {
            Name = name;
            Iso6391Name = iso6391Name;
            ConfidenceScore = confidenceScore;
            Script = script;
            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// The spelled-out name of the detected language (for example, "English" or "French").
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The two letter representation of the detected language according to the ISO 639-1 standard (for example,
        /// "en" or "fr").
        /// </summary>
        public string Iso6391Name { get; }

        /// <summary>
        /// The score between 0.0 and 1.0 indicating the confidence that the language was accurately detected.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// The non-native script of the detected language, if applicable (for example, "Latin" in the case of
        /// romanized Hindi).
        /// </summary>
        public ScriptKind? Script { get; }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
