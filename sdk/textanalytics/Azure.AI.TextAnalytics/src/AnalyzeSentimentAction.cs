﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// an Analyze Sentiment action in a set of documents.
    /// For example, execute opinion mining, set model version, and more.
    /// </summary>
    public class AnalyzeSentimentAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeSentimentAction"/>
        /// class which allows callers to specify details about how to execute
        /// an Analyze Sentiment action in a set of documents.
        /// For example, execute opinion mining, set model version, and more.
        /// </summary>
        public AnalyzeSentimentAction()
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
        /// The default value of this property is 'false'. This means, Text Analytics service logs your input text for 48 hours,
        /// solely to allow for troubleshooting issues.
        /// Setting this property to true, disables input logging and may limit our ability to investigate issues that occur.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_5"/> and up.
        /// </remarks>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Whether to mine the opinion of a sentence and conduct more granular analysis around the
        /// targets of a product or service (also known as Aspect-Based sentiment analysis).
        /// If set to true, the returned <see cref="SentenceSentiment.Opinions"/>
        /// will contain the result of this analysis.
        /// <para>Only available for service version v3.1-preview and up.</para>
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_5"/> and up.
        /// </remarks>
        public bool? IncludeOpinionMining { get; set; }
    }
}
