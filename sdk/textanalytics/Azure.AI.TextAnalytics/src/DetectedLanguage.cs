// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A prediction of the language in which a document is written in.
    /// </summary>
    public readonly struct DetectedLanguage
    {
        internal DetectedLanguage(string name, string iso6391Name, double score)
        {
            Name = name;
            Iso6391Name = iso6391Name;
            Score = score;
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
        public double Score { get; }
    }
}
