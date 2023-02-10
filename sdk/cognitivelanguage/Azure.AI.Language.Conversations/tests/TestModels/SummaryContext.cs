// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The context of the summary. </summary>
    public partial class SummaryContext
    {
        /// <summary> Initializes a new instance of SummaryContext. </summary>
        /// <param name="offset"> Start position for the context. Use of different &apos;stringIndexType&apos; values can affect the offset returned. </param>
        /// <param name="length"> The length of the context. Use of different &apos;stringIndexType&apos; values can affect the length returned. </param>
        public SummaryContext(int offset, int length)
        {
            Offset = offset;
            Length = length;
        }

        /// <summary> Start position for the context. Use of different &apos;stringIndexType&apos; values can affect the offset returned. </summary>
        public int Offset { get; set; }
        /// <summary> The length of the context. Use of different &apos;stringIndexType&apos; values can affect the length returned. </summary>
        public int Length { get; set; }
    }
}
