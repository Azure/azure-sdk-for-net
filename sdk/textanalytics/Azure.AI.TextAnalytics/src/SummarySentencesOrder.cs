// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The order in which extracted sentences will be returned on extractive text summarization.
    /// </summary>
    [CodeGenModel("ExtractiveSummarizationTaskParametersSortBy")]
    public enum SummarySentencesOrder
    {
        /// <summary>
        /// Keeps the original order in which the sentences appear in the input.
        /// </summary>
        Offset,

        /// <summary>
        /// Orders sentences according to their relevance to the input document, as decided by the service.
        /// </summary>
        Rank
    }
}
