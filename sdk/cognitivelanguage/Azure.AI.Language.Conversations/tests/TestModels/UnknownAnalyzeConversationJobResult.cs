// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownAnalyzeConversationJobResult. </summary>
    internal partial class UnknownAnalyzeConversationJobResult : AnalyzeConversationJobResult
    {
        /// <summary> Initializes a new instance of UnknownAnalyzeConversationJobResult. </summary>
        /// <param name="lastUpdateDateTime"> The last updated time in UTC for the task. </param>
        /// <param name="status"> The status of the task at the mentioned last update time. </param>
        /// <param name="kind"> Enumeration of supported Conversation Analysis task results. </param>
        /// <param name="taskName"></param>
        internal UnknownAnalyzeConversationJobResult(DateTimeOffset lastUpdateDateTime, State status, AnalyzeConversationResultsKind kind, string taskName) : base(lastUpdateDateTime, status, kind, taskName)
        {
            Kind = kind;
        }
    }
}
