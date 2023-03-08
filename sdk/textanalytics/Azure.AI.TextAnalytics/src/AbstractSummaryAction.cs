// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A set of options used to configure abstractive summarization, including the model version to use, the maximum
    /// number of sentences that the resulting summary can have, and more.
    /// </summary>
    public class AbstractSummaryAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSummaryAction"/> class.
        /// </summary>
        public AbstractSummaryAction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSummaryAction"/> class based on the given
        /// <see cref="AbstractSummaryOptions"/>.
        /// </summary>
        public AbstractSummaryAction(AbstractSummaryOptions options)
        {
            ModelVersion = options.ModelVersion;
            DisableServiceLogs = options.DisableServiceLogs;
            SentenceCount = options.SentenceCount;
        }

        /// <summary>
        /// The version of the text analytics model that will be used to generate the result. To learn more about the
        /// supported model versions for each feature, see
        /// <see href="https://learn.microsoft.com/azure/cognitive-services/language-service/concepts/model-lifecycle"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// Indicates whether the service logs your input text for 48 hours, which is solely to allow for
        /// troubleshooting, if needed. Setting this property to <c>true</c> disables input logging and may limit our
        /// ability to investigate any issues that occur. If not set, the service default is used.
        /// <para>
        /// Please see the Cognitive Services Compliance and Privacy notes at
        /// <see href="https://aka.ms/cs-compliance"/> for additional details, and the Microsoft Responsible AI
        /// principles at <see href="https://www.microsoft.com/ai/responsible-ai"/>.
        /// </para>
        /// </summary>
        public bool? DisableServiceLogs { get; set; }

        /// <summary>
        /// The name of this action. If not set, the service will generate one.
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// The desired number of sentences in the resulting summaries, which the service will attempt to approximate.
        /// </summary>
        public int? SentenceCount { get; set; }
    }
}
