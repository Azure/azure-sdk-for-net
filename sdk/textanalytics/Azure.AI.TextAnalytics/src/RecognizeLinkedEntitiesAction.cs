// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Configurations that allow callers to specify details about how to execute
    /// a Recognize Linked Entities action in a set of documents.
    /// For example, set model version and disable service logging.
    /// </summary>
    public class RecognizeLinkedEntitiesAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeLinkedEntitiesAction"/>
        /// class which allows callers to specify details about how to execute
        /// a Recognize Linked Entities action in a set of documents.
        /// For example, set model version and disable service logging.
        /// </summary>
        public RecognizeLinkedEntitiesAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeLinkedEntitiesAction"/>
        /// class based on the values of a <see cref="TextAnalyticsRequestOptions"/>.
        /// It sets the <see cref="ModelVersion"/> and <see cref="DisableServiceLogs"/> properties.
        /// </summary>
        public RecognizeLinkedEntitiesAction(TextAnalyticsRequestOptions options)
        {
            ModelVersion = options.ModelVersion;
            DisableServiceLogs = options.DisableServiceLogs;
        }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the Language service
        /// model that will be used to generate the result.  For supported
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
        /// Gets or sets a name for this action. If not provided, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }
    }
}
