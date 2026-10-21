// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentSafety
{
    [CodeGenSuppress("AgentPreModelCallContext", typeof(DateTimeOffset), typeof(long), typeof(AgentDefinition), typeof(AgentSession), typeof(BinaryData))]
    public partial class AgentPreModelCallContext
    {
        /// <summary> Initializes a new instance of <see cref="AgentPreModelCallContext"/>. </summary>
        /// <param name="timestamp"> UTC instant when the host constructed the context. </param>
        /// <param name="sequence"> Strictly increasing, non-negative emission sequence within the session. </param>
        /// <param name="agent"> Agent definition metadata. </param>
        /// <param name="session"> Execution-session metadata. </param>
        /// <param name="target"> The native JSON value under evaluation. </param>
        /// <param name="model"> Model metadata. </param>
        /// <param name="messages"> Model messages. </param>
        /// <exception cref="ArgumentNullException"> A required argument is null. </exception>
        public AgentPreModelCallContext(DateTimeOffset timestamp, long sequence, AgentDefinition agent, AgentSession session, BinaryData target, AgentModel model, IEnumerable<AgentMessage> messages) : base(AgentInterceptionPoint.PreModelCall, timestamp, sequence, agent, session, target)
        {
            Argument.AssertNotNull(agent, nameof(agent));
            Argument.AssertNotNull(session, nameof(session));
            Argument.AssertNotNull(target, nameof(target));
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(messages, nameof(messages));

            Model = model;
            // A plain list keeps an explicitly provided empty list defined.
            _messages = new List<AgentMessage>(messages);
        }
    }
}
