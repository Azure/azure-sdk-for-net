// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct LinkedEntityMatch
    {
        /// <summary>
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// </summary>
        public int Length { get; set; }
    }
}
