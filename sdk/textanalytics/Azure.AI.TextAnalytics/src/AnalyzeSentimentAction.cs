// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Initializes a new instance of the <see cref="AnalyzeSentimentAction"/>
        /// class based on the values of a <see cref="AnalyzeSentimentOptions"/>.
        /// It sets the <see cref="ModelVersion"/>, the <see cref="DisableServiceLogs"/>,
        /// and the <see cref="IncludeOpinionMining"/> properties.
        /// </summary>
        public AnalyzeSentimentAction(AnalyzeSentimentOptions options)
        {
            ModelVersion = options.ModelVersion;
            DisableServiceLogs = options.DisableServiceLogs;
            IncludeOpinionMining = options.IncludeOpinionMining;
        }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/language-service/concepts/model-lifecycle#available-versions"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// The default value of this property is 'false'. This means, the Language service logs your input text for 48 hours,
        /// solely to allow for troubleshooting issues.
        /// Setting this property to true, disables input logging and may limit our ability to investigate issues that occur.
        /// <para>
        /// Please see Cognitive Services Compliance and Privacy notes at <see href="https://aka.ms/cs-compliance"/> for additional details,
        /// and Microsoft Responsible AI principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1"/>, <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/>, and newer.
        /// </remarks>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// Whether to mine the opinion of a sentence and conduct more granular analysis around the
        /// targets of a product or service (also known as Aspect-Based sentiment analysis).
        /// If set to true, the returned <see cref="SentenceSentiment.Opinions"/>
        /// will contain the result of this analysis.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1"/>, <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/>, and newer.
        /// </remarks>
        public bool? IncludeOpinionMining { get; set; }

        /// <summary>
        /// Gets or sets a name for this action. If not provided, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }
    }
}
