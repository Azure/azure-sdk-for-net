﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class ExtractSummaryOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryOptions"/>
        /// class.
        /// </summary>
        public ExtractSummaryOptions()
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
        /// <see cref="SummarySentencesOrder.Offset"/> to keep the original order in which the sentences appear
        /// in the input document. Use <see cref="SummarySentencesOrder.Rank"/> to order them according to their relevance
        /// to the input document, as determined by the service. If not set, the service default is used.
        /// </summary>
        public SummarySentencesOrder? OrderBy { get; set; }
    }
}
