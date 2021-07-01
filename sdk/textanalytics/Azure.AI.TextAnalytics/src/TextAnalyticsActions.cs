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
    }
}
