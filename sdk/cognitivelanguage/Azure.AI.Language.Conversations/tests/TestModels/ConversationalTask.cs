// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The input for a custom conversation task. </summary>
    public partial class ConversationalTask : AnalyzeConversationTask
    {
        /// <summary> Initializes a new instance of ConversationalTask. </summary>
        /// <param name="analysisInput"> The input ConversationItem and its optional parameters. </param>
        /// <param name="parameters"> Input parameters necessary for a Conversation task. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analysisInput"/> or <paramref name="parameters"/> is null. </exception>
        public ConversationalTask(ConversationAnalysisOptions analysisInput, ConversationTaskParameters parameters)
        {
            Argument.AssertNotNull(analysisInput, nameof(analysisInput));
            Argument.AssertNotNull(parameters, nameof(parameters));

            AnalysisInput = analysisInput;
            Parameters = parameters;
            Kind = AnalyzeConversationTaskKind.Conversation;
        }

        /// <summary> The input ConversationItem and its optional parameters. </summary>
        public ConversationAnalysisOptions AnalysisInput { get; }
        /// <summary> Input parameters necessary for a Conversation task. </summary>
        public ConversationTaskParameters Parameters { get; }
    }
}
