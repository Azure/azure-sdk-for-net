// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Contains the statistics for the job submitted. </summary>
    public partial class AnalyzeConversationJobStatistics
    {
        /// <summary> Initializes a new instance of AnalyzeConversationJobStatistics. </summary>
        internal AnalyzeConversationJobStatistics()
        {
        }

        /// <summary> Initializes a new instance of AnalyzeConversationJobStatistics. </summary>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        internal AnalyzeConversationJobStatistics(ConversationRequestStatistics statistics)
        {
            Statistics = statistics;
        }

        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public ConversationRequestStatistics Statistics { get; }
    }
}
