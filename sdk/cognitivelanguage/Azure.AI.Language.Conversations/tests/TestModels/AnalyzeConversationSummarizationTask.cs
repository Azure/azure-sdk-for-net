// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Task definition for conversational summarization. </summary>
    public partial class AnalyzeConversationSummarizationTask : AnalyzeConversationLROTask
    {
        /// <summary> Initializes a new instance of AnalyzeConversationSummarizationTask. </summary>
        public AnalyzeConversationSummarizationTask()
        {
            Kind = AnalyzeConversationLROTaskKind.ConversationalSummarizationTask;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationSummarizationTask. </summary>
        /// <param name="taskName"></param>
        /// <param name="kind"> Enumeration of supported analysis tasks on a collection of conversation. </param>
        /// <param name="parameters"> Supported parameters for an conversational summarization task. </param>
        internal AnalyzeConversationSummarizationTask(string taskName, AnalyzeConversationLROTaskKind kind, ConversationSummarizationTaskParameters parameters) : base(taskName, kind)
        {
            Parameters = parameters;
            Kind = kind;
        }

        /// <summary> Supported parameters for an conversational summarization task. </summary>
        public ConversationSummarizationTaskParameters Parameters { get; set; }
    }
}
