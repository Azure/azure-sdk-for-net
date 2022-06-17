// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The request body. </summary>
    [CodeGenModel("ConversationAnalysisOptions")]
    [CodeGenSuppress("AnalyzeConversationOptions", typeof(string))]
    public partial class AnalyzeConversationOptions
    {
        /// <summary> The conversation utterance to be analyzed. </summary>
        [CodeGenMember("Verbose")]
        public bool Verbose { get; set; }
    }
}
