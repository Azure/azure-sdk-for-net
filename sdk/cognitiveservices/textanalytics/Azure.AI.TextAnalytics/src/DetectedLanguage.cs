// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct DetectedLanguage
    {
        /// <summary>
        /// Gets or sets long name of a detected language (e.g. English,
        /// French).
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets or sets a two letter representation of the detected language
        /// according to the ISO 639-1 standard (e.g. en, fr).
        /// </summary>
        public string Iso6391Name { get; internal set; }

        /// <summary>
        /// Gets or sets a confidence score between 0 and 1. Scores close to 1
        /// indicate 100% certainty that the identified language is true.
        /// </summary>
        public double? Score { get; internal set; }
    }
}
