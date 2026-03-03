// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Target for a Voice Live session, specifying either a model or an agent.
    /// </summary>
    /// <remarks>
    /// Use <see cref="SessionTarget.FromModel(string)"/> for model-centric sessions where the LLM is the main actor.
    /// Use <see cref="SessionTarget.FromAgent(AgentSessionConfig)"/> for agent-centric sessions where the agent is the main actor.
    /// </remarks>
    public class SessionTarget
    {
        /// <summary>
        /// The model name for model-centric sessions.
        /// </summary>
        public string? Model { get; private set; }

        /// <summary>
        /// The agent configuration for agent-centric sessions.
        /// </summary>
        public AgentSessionConfig? Agent { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this target specifies a model session.
        /// </summary>
        public bool IsModelSession => Model != null;

        /// <summary>
        /// Gets a value indicating whether this target specifies an agent session.
        /// </summary>
        public bool IsAgentSession => Agent != null;

        private SessionTarget() { }

        /// <summary>
        /// Creates a session target for a model-centric session.
        /// </summary>
        /// <param name="model">The model name to use for the session (e.g., "gpt-4o-realtime-preview").</param>
        /// <returns>A SessionTarget configured for a model session.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="model"/> is empty.</exception>
        public static SessionTarget FromModel(string model)
        {
            Argument.AssertNotNullOrEmpty(model, nameof(model));
            return new SessionTarget { Model = model };
        }

        /// <summary>
        /// Creates a session target for an agent-centric session.
        /// </summary>
        /// <param name="agentConfig">The agent configuration to use for the session.</param>
        /// <returns>A SessionTarget configured for an agent session.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agentConfig"/> is null.</exception>
        public static SessionTarget FromAgent(AgentSessionConfig agentConfig)
        {
            Argument.AssertNotNull(agentConfig, nameof(agentConfig));
            return new SessionTarget { Agent = agentConfig };
        }

        /// <summary>
        /// Implicit conversion from string to SessionTarget for model sessions.
        /// </summary>
        /// <param name="model">The model name.</param>
        public static implicit operator SessionTarget(string model)
        {
            return FromModel(model);
        }

        /// <summary>
        /// Implicit conversion from AgentSessionConfig to SessionTarget for agent sessions.
        /// </summary>
        /// <param name="agentConfig">The agent configuration.</param>
        public static implicit operator SessionTarget(AgentSessionConfig agentConfig)
        {
            return FromAgent(agentConfig);
        }

        /// <summary>
        /// Checks if this SessionTarget specifies an agent session.
        /// </summary>
        /// <returns>True if the target specifies an agent session.</returns>
        public bool IsAgentSessionTarget()
        {
            return this.IsAgentSession;
        }

        /// <summary>
        /// Checks if this SessionTarget specifies a model session.
        /// </summary>
        /// <returns>True if the target specifies a model session.</returns>
        public bool IsModelSessionTarget()
        {
            return this.IsModelSession;
        }
    }
}

#nullable restore
