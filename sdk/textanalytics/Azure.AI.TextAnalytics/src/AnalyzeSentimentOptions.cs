// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class AnalyzeSentimentOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeSentimentOptions"/>
        /// class.
        /// </summary>
        public AnalyzeSentimentOptions()
        {
        }

        internal AnalyzeSentimentOptions(TextAnalyticsRequestOptions options)
            : base(options.IncludeStatistics, options.ModelVersion)
        {
        }

        /// <summary>
        /// If set to true, response will contain Opinion Mining sentiment analysis results.
        /// Only available for Text Analytics Service version v3.1-preview.1 and above.
        /// </summary>
        public bool IncludeOpinionMining { get; set; } = false;
    }
}
