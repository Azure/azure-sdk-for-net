// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Determines the list of actions to be passed as arguments for AnalyzeBatchActionsOperation class. </summary>
    public class TextAnalyticsActions
    {
        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// ExtractKeyPhrasesOptions
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesOptions> ExtractKeyPhrasesOptions { get; set; }

        /// <summary>
        /// RecognizeEntitiesOptions
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesOptions> RecognizeEntitiesOptions { get; set; }

        /// <summary>
        /// RecognizePiiEntityOptions
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesOptions> RecognizePiiEntitiesOptions { get; set; }
    }
}
