// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A set of options used to configure abstractive summarization, including the display name to use, the maximum
    /// number of sentences that the resulting summary can have, and more.
    /// </summary>
    public class AbstractiveSummarizeOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractiveSummarizeOptions"/> class.
        /// </summary>
        public AbstractiveSummarizeOptions()
        {
        }

        /// <summary>
        /// The optional display name of the operation.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The two-letter ISO 639-1 representation of the default language to consider for automatic language
        /// detection (for example, "en" for English or "fr" for French).
        /// </summary>
        public string AutoDetectionDefaultLanguage { get; set; }

        /// <summary>
        /// The maximum number of sentences that the resulting summaries can have. If not set, the service default is
        /// used.
        /// </summary>
        public int? MaxSentenceCount { get; set; }
    }
}
