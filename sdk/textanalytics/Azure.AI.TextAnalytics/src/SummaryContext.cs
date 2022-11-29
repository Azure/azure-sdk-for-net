// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the text that was used as context by the service to produce a given summary.
    /// </summary>
    public readonly struct SummaryContext
    {
        internal SummaryContext(SummaryContextInternal context)
        {
            Offset = context.Offset;
            Length = context.Length;
        }

        /// <summary>
        /// The starting position of the text used as context as it appears in the original document.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// The length of the text used as context as it appears in the original document.
        /// </summary>
        public int Length { get; }
    }
}
