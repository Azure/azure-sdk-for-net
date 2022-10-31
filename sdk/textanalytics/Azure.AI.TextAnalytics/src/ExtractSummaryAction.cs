// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// an Extractive Text Summarization action in a set of documents.
    /// For example, set the model version, specify the order in which extracted
    /// sentences are returned, and more.
    /// </summary>
    public class ExtractSummaryAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryAction"/>
        /// class which allows callers to specify details about how to execute
        /// an extractive text summarization action in a set of documents.
        /// For example, set the model version, specify the order in which extracted
        /// sentences are returned, and more.
        /// </summary>
        public ExtractSummaryAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryAction"/>
        /// class based on the values of a <see cref="ExtractSummaryOptions"/>.
        /// It sets the <see cref="ModelVersion"/>, <see cref="DisableServiceLogs"/>,
        /// <see cref="MaxSentenceCount"/>, and <see cref="OrderBy"/> properties.
        /// </summary>
        public ExtractSummaryAction(ExtractSummaryOptions options)
        {
            ModelVersion = options.ModelVersion;
            DisableServiceLogs = options.DisableServiceLogs;
            MaxSentenceCount = options.MaxSentenceCount;
            OrderBy = options.OrderBy;
        }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result. For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/concepts/model-versioning#available-versions"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// Indicates whether the Language service logs your input text for 48 hours, which is solely to allow for troubleshooting issues.
        /// Setting this property to <c>true</c> disables input logging and may limit our ability to investigate any issues that may occur.
        /// If not set, the service default is used.
        /// <para>
        /// Please see Cognitive Services Compliance and Privacy notes at <see href="https://aka.ms/cs-compliance"/> for additional details,
        /// and Microsoft Responsible AI principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// The name of this action. If not provided, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }

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
