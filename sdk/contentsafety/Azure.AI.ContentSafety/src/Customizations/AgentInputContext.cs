// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentSafety
{
    [CodeGenSuppress("AgentInputContext", typeof(DateTimeOffset), typeof(long), typeof(AgentDefinition), typeof(AgentSession), typeof(BinaryData))]
    public partial class AgentInputContext
    {
        /// <summary> Initializes a new instance of <see cref="AgentInputContext"/>. </summary>
        /// <param name="timestamp"> UTC instant when the host constructed the context. </param>
        /// <param name="sequence"> Strictly increasing, non-negative emission sequence within the session. </param>
        /// <param name="agent"> Agent definition metadata. </param>
        /// <param name="session"> Execution-session metadata. </param>
        /// <param name="target"> The native JSON value under evaluation. </param>
        /// <param name="input"> Input payload. </param>
        /// <exception cref="ArgumentNullException"> A required argument is null. </exception>
        public AgentInputContext(DateTimeOffset timestamp, long sequence, AgentDefinition agent, AgentSession session, BinaryData target, AgentInput input) : base(AgentInterceptionPoint.Input, timestamp, sequence, agent, session, target)
        {
            Argument.AssertNotNull(agent, nameof(agent));
            Argument.AssertNotNull(session, nameof(session));
            Argument.AssertNotNull(target, nameof(target));
            Argument.AssertNotNull(input, nameof(input));

            Input = input;
        }
    }
}
