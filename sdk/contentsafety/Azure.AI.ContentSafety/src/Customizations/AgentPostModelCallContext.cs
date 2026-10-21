// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentSafety
{
    [CodeGenSuppress("AgentPostModelCallContext", typeof(DateTimeOffset), typeof(long), typeof(AgentDefinition), typeof(AgentSession), typeof(BinaryData))]
    public partial class AgentPostModelCallContext
    {
        /// <summary> Initializes a new instance of <see cref="AgentPostModelCallContext"/>. </summary>
        /// <param name="timestamp"> UTC instant when the host constructed the context. </param>
        /// <param name="sequence"> Strictly increasing, non-negative emission sequence within the session. </param>
        /// <param name="agent"> Agent definition metadata. </param>
        /// <param name="session"> Execution-session metadata. </param>
        /// <param name="target"> The native JSON value under evaluation. </param>
        /// <param name="model"> Model metadata. </param>
        /// <param name="response"> Model response. </param>
        /// <exception cref="ArgumentNullException"> A required argument is null. </exception>
        public AgentPostModelCallContext(DateTimeOffset timestamp, long sequence, AgentDefinition agent, AgentSession session, BinaryData target, AgentModel model, AgentModelResult response) : base(AgentInterceptionPoint.PostModelCall, timestamp, sequence, agent, session, target)
        {
            Argument.AssertNotNull(agent, nameof(agent));
            Argument.AssertNotNull(session, nameof(session));
            Argument.AssertNotNull(target, nameof(target));
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(response, nameof(response));

            Model = model;
            Response = response;
        }
    }
}
