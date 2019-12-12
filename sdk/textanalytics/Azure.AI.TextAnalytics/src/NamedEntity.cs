// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
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
        /// Entity text as appears in the request.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets entity type from Named Entity Recognition model.
        /// Entity type, such as Person/Location/Org/SSN etc.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets entity sub type from Named Entity Recognition model.
        /// Entity sub type, such as Age/Year/TimeRange etc.
        /// </summary>
        public string SubType { get; }

        /// <summary>
        /// Gets start position (in Unicode characters) for the entity
        /// match text.
        /// Start position (in Unicode characters) for the entity text.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets length (in Unicode characters) for the entity match
        /// text.
        /// Length (in Unicode characters) for the entity text.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Gets (optional) If an entity type is recognized, a decimal
        /// number denoting the confidence level of the entity type will be
        /// returned.
        /// Confidence score between 0 and 1 of the extracted entity.
        /// </summary>
        public double Score { get; }
    }
}
