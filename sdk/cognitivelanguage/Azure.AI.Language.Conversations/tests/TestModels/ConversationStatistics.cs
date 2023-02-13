// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> If showStats=true was specified in the request this field will contain information about the conversation payload. </summary>
    public partial class ConversationStatistics
    {
        /// <summary> Initializes a new instance of ConversationStatistics. </summary>
        /// <param name="transactionsCount"> Number of text units for the request. </param>
        public ConversationStatistics(int transactionsCount)
        {
            TransactionsCount = transactionsCount;
        }

        /// <summary> Number of text units for the request. </summary>
        public int TransactionsCount { get; set; }
    }
}
