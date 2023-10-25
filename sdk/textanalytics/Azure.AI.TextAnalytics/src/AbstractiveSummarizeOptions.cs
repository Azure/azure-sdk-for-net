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
        /// The desired number of sentences in the resulting summaries, which the service will attempt to approximate.
        /// </summary>
        public int? SentenceCount { get; set; }
    }
}
