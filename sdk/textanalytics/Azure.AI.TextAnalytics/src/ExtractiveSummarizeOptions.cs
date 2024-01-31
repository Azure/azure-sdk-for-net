// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A set of options used to configure extractive summarization, including the display name to use, the maximum
    /// number of sentences to extract, and more.
    /// </summary>
    public class ExtractiveSummarizeOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractiveSummarizeOptions"/> class.
        /// </summary>
        public ExtractiveSummarizeOptions()
        {
        }

        /// <summary>
        /// The optional display name of the operation.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The maximum number of sentences to be returned in the result. If not set, the service default is used.
        /// </summary>
        public int? MaxSentenceCount { get; set; }

        /// <summary>
        /// The order in which the extracted sentences will be returned in the result. Use
        /// <see cref="ExtractiveSummarySentencesOrder.Offset"/> to keep the original order in which the sentences appear
        /// in the input document. Use <see cref="ExtractiveSummarySentencesOrder.Rank"/> to order them according to their
        /// relevance, as determined by the service. If not set, the service default is used.
        /// </summary>
        public ExtractiveSummarySentencesOrder? OrderBy { get; set; }
    }
}
