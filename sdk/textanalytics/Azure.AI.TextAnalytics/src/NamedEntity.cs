// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A word or phrase identified from the input text as important, as well
    /// as a categorization of the inferred entity into a category in a taxonomy
    /// defined by the text analytics service and described at
    /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
    /// </summary>
    public readonly struct NamedEntity
    {
        internal NamedEntity(string text, string type, string subType, int offset, int length, double score)
        {
            Text = text;
            Type = type;
            SubType = subType;
            Offset = offset;
            Length = length;
            Score = score;
        }

        /// <summary>
        /// Gets the entity text as it appears in the input document.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the entity type inferred by the text analytics service's
        /// named entity recognition model.  The list of available types is
        /// described at
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the sub type of the entity inferred by the text analytics service's
        /// named entity recognition model. The list of available types is
        /// described at
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// </summary>
        public string SubType { get; }

        /// <summary>
        /// Gets the start position for the matching text in the input document.
        /// The offset unit is unicode character count.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the length of the matching text in the input document.
        /// The length unit is unicode character count.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// text substring matches this inferred entity.
        /// </summary>
        public double Score { get; }
    }
}
