// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary> Determines the set of actions that will get executed on the input documents.</summary>
    public class TextAnalyticsActions
    {
        /// <summary>
        /// Optional display name for the analysis operation.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Extract KeyPhrases actions configurations.
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesOptions> ExtractKeyPhrasesOptions { get; set; }

        /// <summary>
        /// Recognize Entities actions configurations.
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesOptions> RecognizeEntitiesOptions { get; set; }

        /// <summary>
        /// Recognize PII Entities actions configurations.
        /// Note: `CategoriesFilters` will not have an effect on the action. See https://github.com/Azure/azure-sdk-for-net/issues/19237
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesOptions> RecognizePiiEntitiesOptions { get; set; }

        /// <summary>
        /// Recognize Linked Entities actions configurations.
        /// </summary>
        public IReadOnlyCollection<RecognizeLinkedEntitiesOptions> RecognizeLinkedEntitiesOptions { get; set; }
    }
}
