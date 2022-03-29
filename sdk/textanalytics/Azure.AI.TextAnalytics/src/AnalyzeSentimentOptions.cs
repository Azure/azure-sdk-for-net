// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run. For example, execute opinion mining, set model version,
    /// whether to include statistics, and more.
    /// </summary>
    public class AnalyzeSentimentOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeSentimentOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example, execute opinion mining, set model version,
        /// whether to include statistics, and more.
        /// </summary>
        public AnalyzeSentimentOptions()
        {
        }

        internal AnalyzeSentimentOptions(TextAnalyticsRequestOptions options)
            : base(options.IncludeStatistics, options.ModelVersion)
        {
        }

        /// <summary>
        /// Whether to mine the opinion of a sentence and conduct more granular analysis around the
        /// targets of a product or service (also known as Aspect-Based sentiment analysis).
        /// If set to true, the returned <see cref="SentenceSentiment.Opinions"/>
        /// will contain the result of this analysis.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1"/> and up.
        /// </remarks>
        public bool? IncludeOpinionMining { get; set; }
    }
}
