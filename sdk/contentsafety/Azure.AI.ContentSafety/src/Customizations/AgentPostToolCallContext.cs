// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentSafety
{
    [CodeGenSuppress("AgentPostToolCallContext", typeof(DateTimeOffset), typeof(long), typeof(AgentDefinition), typeof(AgentSession), typeof(BinaryData))]
    public partial class AgentPostToolCallContext
    {
        /// <summary> Initializes a new instance of <see cref="AgentPostToolCallContext"/>. </summary>
        /// <param name="timestamp"> UTC instant when the host constructed the context. </param>
        /// <param name="sequence"> Strictly increasing, non-negative emission sequence within the session. </param>
        /// <param name="agent"> Agent definition metadata. </param>
        /// <param name="session"> Execution-session metadata. </param>
        /// <param name="target"> The native JSON value under evaluation. </param>
        /// <param name="toolCall"> Tool-call payload. </param>
        /// <param name="toolResult"> Tool-result payload. </param>
        /// <exception cref="ArgumentNullException"> A required argument is null. </exception>
        public AgentPostToolCallContext(DateTimeOffset timestamp, long sequence, AgentDefinition agent, AgentSession session, BinaryData target, AgentToolCall toolCall, AgentToolResult toolResult) : base(AgentInterceptionPoint.PostToolCall, timestamp, sequence, agent, session, target)
        {
            Argument.AssertNotNull(agent, nameof(agent));
            Argument.AssertNotNull(session, nameof(session));
            Argument.AssertNotNull(target, nameof(target));
            Argument.AssertNotNull(toolCall, nameof(toolCall));
            Argument.AssertNotNull(toolResult, nameof(toolResult));

            ToolCall = toolCall;
            ToolResult = toolResult;
        }
    }
}
