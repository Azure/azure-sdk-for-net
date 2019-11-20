// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct LinkedEntityMatch
    {
        internal LinkedEntityMatch(string text, double score, int offset, int length)
        {
            Text = text;
            Score = score;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// </summary>
        public double Score { get; }

        /// <summary>
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// </summary>
        public int Length { get; }
    }
}
