// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Task definition for a PII redaction in conversations. </summary>
    public partial class AnalyzeConversationPIITask : AnalyzeConversationLROTask
    {
        /// <summary> Initializes a new instance of AnalyzeConversationPIITask. </summary>
        public AnalyzeConversationPIITask()
        {
            Kind = AnalyzeConversationLROTaskKind.ConversationalPIITask;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationPIITask. </summary>
        /// <param name="taskName"></param>
        /// <param name="kind"> Enumeration of supported analysis tasks on a collection of conversation. </param>
        /// <param name="parameters"> Supported parameters for a Conversational PII detection and redaction task. </param>
        internal AnalyzeConversationPIITask(string taskName, AnalyzeConversationLROTaskKind kind, ConversationPIITaskParameters parameters) : base(taskName, kind)
        {
            Parameters = parameters;
            Kind = kind;
        }

        /// <summary> Supported parameters for a Conversational PII detection and redaction task. </summary>
        public ConversationPIITaskParameters Parameters { get; set; }
    }
}
