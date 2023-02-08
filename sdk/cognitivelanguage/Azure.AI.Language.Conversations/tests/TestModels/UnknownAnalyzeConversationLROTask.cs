// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownAnalyzeConversationLROTask. </summary>
    internal partial class UnknownAnalyzeConversationLROTask : AnalyzeConversationLROTask
    {
        /// <summary> Initializes a new instance of UnknownAnalyzeConversationLROTask. </summary>
        /// <param name="taskName"></param>
        /// <param name="kind"> Enumeration of supported analysis tasks on a collection of conversation. </param>
        internal UnknownAnalyzeConversationLROTask(string taskName, AnalyzeConversationLROTaskKind kind) : base(taskName, kind)
        {
            Kind = kind;
        }
    }
}
