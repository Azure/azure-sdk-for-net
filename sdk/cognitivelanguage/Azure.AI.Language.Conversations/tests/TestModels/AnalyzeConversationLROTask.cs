// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// The base class for an long running conversation input task.
    /// Please note <see cref="AnalyzeConversationLROTask"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AnalyzeConversationPIITask"/>, <see cref="AnalyzeConversationalSentimentTask"/> and <see cref="AnalyzeConversationSummarizationTask"/>.
    /// </summary>
    public partial class AnalyzeConversationLROTask : TaskIdentifier
    {
        /// <summary> Initializes a new instance of AnalyzeConversationLROTask. </summary>
        public AnalyzeConversationLROTask()
        {
        }

        /// <summary> Initializes a new instance of AnalyzeConversationLROTask. </summary>
        /// <param name="taskName"></param>
        /// <param name="kind"> Enumeration of supported analysis tasks on a collection of conversation. </param>
        internal AnalyzeConversationLROTask(string taskName, AnalyzeConversationLROTaskKind kind) : base(taskName)
        {
            Kind = kind;
        }

        /// <summary> Enumeration of supported analysis tasks on a collection of conversation. </summary>
        internal AnalyzeConversationLROTaskKind Kind { get; set; }
    }
}
