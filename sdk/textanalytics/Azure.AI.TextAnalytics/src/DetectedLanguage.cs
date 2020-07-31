// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A prediction of the language in which a document is written in.
    /// </summary>
    [CodeGenModel("DetectedLanguage")]
    public readonly partial struct DetectedLanguage
    {
        internal DetectedLanguage(string name, string iso6391Name, double score, IList<TextAnalyticsWarning> warnings)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (iso6391Name == null)
            {
                throw new ArgumentNullException(nameof(iso6391Name));
            }

            Name = name;
            Iso6391Name = iso6391Name;
            ConfidenceScore = score;
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        internal DetectedLanguage(string name, string iso6391Name, double confidenceScore)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (iso6391Name == null)
            {
                throw new ArgumentNullException(nameof(iso6391Name));
            }

            Name = name;
            Iso6391Name = iso6391Name;
            ConfidenceScore = confidenceScore;
            Warnings = new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Gets the spelled-out name of the detected language (for example,
        /// "English" or "French").
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a two letter representation of the detected language
        /// according to the ISO 639-1 standard (for example, "en" or "fr").
        /// </summary>
        public string Iso6391Name { get; }

        /// <summary>
        /// Gets a confidence score between 0 and 1. Scores close to 1
        /// indicate high certainty that the identified language is correct.
        /// </summary>
        public double ConfidenceScore { get; }

        /// <summary>
        /// Gets the warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }
    }
}
