// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Determines the set of actions that will get executed on the input documents.</summary>
    public class TextAnalyticsActions
    {
        /// <summary>
        /// Optional display name for the operation.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Extract KeyPhrases actions.
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesAction> ExtractKeyPhrasesActions { get; set; }

        /// <summary>
        /// Recognize Entities actions.
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesAction> RecognizeEntitiesActions { get; set; }

        /// <summary>
        /// Recognize PII Entities actions.
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesAction> RecognizePiiEntitiesActions { get; set; }

        /// <summary>
        /// Recognize Linked Entities actions.
        /// </summary>
        public IReadOnlyCollection<RecognizeLinkedEntitiesAction> RecognizeLinkedEntitiesActions { get; set; }

        /// <summary>
        /// Analyze Sentiment actions.
        /// </summary>
        public IReadOnlyCollection<AnalyzeSentimentAction> AnalyzeSentimentActions { get; set; }
    }
}
