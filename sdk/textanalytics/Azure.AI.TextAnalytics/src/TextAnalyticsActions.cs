// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary> The AnalyzeBatchActions class for LRO. </summary>
    public class TextAnalyticsActions
    {
        /// <summary>
        /// Costructor
        /// </summary>
        public TextAnalyticsActions()
        {
        }

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
