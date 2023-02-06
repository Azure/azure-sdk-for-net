// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Determines the set of actions that will get executed on the input documents.</summary>
    public class TextAnalyticsActions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsActions"/>
        /// class which determines the set of actions that will get executed on the input documents.
        /// For example, execute extract key phrases, recognize entities, and more.
        /// </summary>
        public TextAnalyticsActions()
        {
        }

        /// <summary>
        /// Optional display name for the operation.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The set of <see cref="ExtractKeyPhrasesAction"/> that will get executed on the input documents.
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesAction> ExtractKeyPhrasesActions { get; set; }

        /// <summary>
        /// The set of <see cref="RecognizeEntitiesAction"/> that will get executed on the input documents.
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesAction> RecognizeEntitiesActions { get; set; }

        /// <summary>
        /// The set of <see cref="RecognizePiiEntitiesAction"/> that will get executed on the input documents.
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesAction> RecognizePiiEntitiesActions { get; set; }

        /// <summary>
        /// The set of <see cref="RecognizeLinkedEntitiesAction"/> that will get executed on the input documents.
        /// </summary>
        public IReadOnlyCollection<RecognizeLinkedEntitiesAction> RecognizeLinkedEntitiesActions { get; set; }

        /// <summary>
        /// The set of <see cref="AnalyzeSentimentAction"/> that will get executed on the input documents.
        /// </summary>
        public IReadOnlyCollection<AnalyzeSentimentAction> AnalyzeSentimentActions { get; set; }

        /// <summary>
        /// The set of <see cref="RecognizeCustomEntitiesAction"/> that will get executed on the input documents.
        /// To train a model to recognize your custom entities, see the
        /// <see href="https://aka.ms/azsdk/textanalytics/customentityrecognition">documentation</see>.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<RecognizeCustomEntitiesAction> RecognizeCustomEntitiesActions { get; set; }

        /// <summary>
        /// The set of <see cref="SingleLabelClassifyAction"/> that will get executed on the input documents.
        /// To train a model to classify your documents, see the
        /// <see href="https://aka.ms/azsdk/textanalytics/customfunctionalities">documentation</see>.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<SingleLabelClassifyAction> SingleLabelClassifyActions { get; set; }

        /// <summary>
        /// The set of <see cref="MultiLabelClassifyAction"/> that will get executed on the input documents.
        /// To train a model to classify your documents, see the
        /// <see href="https://aka.ms/azsdk/textanalytics/customfunctionalities">documentation</see>.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<MultiLabelClassifyAction> MultiLabelClassifyActions { get; set; }

        /// <summary>
        /// The set of <see cref="AnalyzeHealthcareEntitiesAction"/> that will get executed on the input documents.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_05_01"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<AnalyzeHealthcareEntitiesAction> AnalyzeHealthcareEntitiesActions { get; set; }

        /// <summary>
        /// The set of <see cref="ExtractiveSummarizeAction"/> that will get executed on the input documents.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<ExtractiveSummarizeAction> ExtractiveSummarizeActions { get; set; }

        /// <summary>
        /// The set of <see cref="AbstractSummaryAction"/> that will get executed on the input documents.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview"/> and newer.
        /// </remarks>
        public IReadOnlyCollection<AbstractSummaryAction> AbstractSummaryActions { get; set; }
    }
}
