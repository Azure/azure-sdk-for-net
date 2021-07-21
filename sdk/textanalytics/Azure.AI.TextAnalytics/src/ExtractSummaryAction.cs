// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class ExtractSummaryAction
    {
        /// <summary>
        /// TODO.
        /// </summary>
        public ExtractSummaryAction()
        {
        }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/concepts/model-versioning#available-versions"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of sentences returned in the result. Defaults to 3.
        /// </summary>
        public int? MaxSentenceCount { get; set; }

        /// <summary>
        /// TODO.
        /// </summary>
        public SummarySentencesOrder? OrderBy { get; set; }
    }
}
