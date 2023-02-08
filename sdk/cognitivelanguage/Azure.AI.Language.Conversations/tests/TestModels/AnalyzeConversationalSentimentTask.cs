// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Task definition for a sentiment analysis in conversations. </summary>
    public partial class AnalyzeConversationalSentimentTask : AnalyzeConversationLROTask
    {
        /// <summary> Initializes a new instance of AnalyzeConversationalSentimentTask. </summary>
        public AnalyzeConversationalSentimentTask()
        {
            Kind = AnalyzeConversationLROTaskKind.ConversationalSentimentTask;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationalSentimentTask. </summary>
        /// <param name="taskName"></param>
        /// <param name="kind"> Enumeration of supported analysis tasks on a collection of conversation. </param>
        /// <param name="parameters"> Supported parameters for a Conversational sentiment analysis task. </param>
        internal AnalyzeConversationalSentimentTask(string taskName, AnalyzeConversationLROTaskKind kind, ConversationalSentimentTaskParameters parameters) : base(taskName, kind)
        {
            Parameters = parameters;
            Kind = kind;
        }

        /// <summary> Supported parameters for a Conversational sentiment analysis task. </summary>
        public ConversationalSentimentTaskParameters Parameters { get; set; }
    }
}
